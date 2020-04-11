Imports System.ComponentModel
Imports BackEndRelational
Imports Validators

''' <summary>
''' A Work in progress (but does work as is)
''' </summary>
Public Class Form1
    Private operations As New NorthWindOperations

    WithEvents _customerView As SortableBindingList(Of CustomerEntity)
    WithEvents _customerBindingSource As New BindingSource

    Public Sub New()
        InitializeComponent()

        DataGridView1.AutoGenerateColumns = False

    End Sub
    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        '
        ' Read all customers
        '
        Dim customerEntities As List(Of CustomerEntity) = Await operations.AllCustomersAsync()

        '
        ' Setup custom BindingList which provides sorting which
        ' is not supported using a BindingSource alone
        '
        _customerView = New SortableBindingList(Of CustomerEntity)(customerEntities)
        _customerBindingSource.DataSource = _customerView


        '
        ' Setup DataGridViewComboBox column for country data
        '
        CountryColumn.DisplayMember = "CountryName"
        CountryColumn.ValueMember = "CountryIdentifier"
        CountryColumn.DataPropertyName = "CountryIdentifier"
        CountryColumn.DataSource = operations.CountryList()
        CountryColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        '
        ' Setup DataGridViewComboBox column for contact typoe data
        '
        ContactTitleColumn.DisplayMember = "ContactTitle"
        ContactTitleColumn.ValueMember = "ContactTypeIdentifier"
        ContactTitleColumn.DataPropertyName = "ContactTypeIdentifier"
        ContactTitleColumn.DataSource = operations.ContactTypeList()
        ContactTitleColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        DataGridView1.DataSource = _customerBindingSource

        DataGridView1.ExpandColumns()

        '
        ' This is done so that if the data is slow loading the button is not clicked.
        '
        CurrentCustomerButton.Enabled = True

    End Sub
    ''' <summary>
    ''' A good way to figure out errors occuring in the DataGridView, for
    ''' production use a log file.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
#If DEBUG Then
        Console.WriteLine(e.Exception.Message)
        e.Cancel = True
#End If
    End Sub
    ''' <summary>
    ''' Show primary and foreign keys for current customer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CurrentCustomerButton_Click(sender As Object, e As EventArgs) Handles CurrentCustomerButton.Click
        Dim customer As CustomerEntity = _customerView.CurrentCustomer(_customerBindingSource.Position)

        MessageBox.Show(
            $"Company: {customer.CompanyName}{Environment.NewLine}" &
            $"Primary key: {customer.CustomerIdentifier}{Environment.NewLine}" &
            $"Contact key: {customer.ContactIdentifier}{Environment.NewLine}" &
            $"Country key: {customer.CountryIdentifier}")

    End Sub
    ''' <summary>
    ''' On property change for the current customer perform validation, if
    ''' validation fails reset from database, if no validation issues save changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub _customerView_ListChanged(sender As Object, e As ListChangedEventArgs) _
        Handles _customerView.ListChanged

        If e.PropertyDescriptor IsNot Nothing Then

            Dim currentCustomer As CustomerEntity =
                    _customerView.CurrentCustomer(_customerBindingSource.Position)

            If e.ListChangedType = ListChangedType.ItemChanged Then

                Dim customerItem = operations.Context.Customers.
                        FirstOrDefault(
                            Function(customer) customer.CustomerIdentifier =
                                           currentCustomer.CustomerIdentifier)

                If customerItem IsNot Nothing Then
                    Dim customerEntry = operations.Context.Entry(customerItem)
                    customerEntry.CurrentValues.SetValues(currentCustomer)

                    Dim validation = ValidationHelper.ValidateEntity(customerItem)

                    If validation.HasViolations Then

                        Dim errorItems = String.Join(
                            Environment.NewLine,
                            validation.
                                ErrorItemList().
                                Select(Function(containerItem) containerItem.ErrorMessage).
                            ToArray())

                        MessageBox.Show(errorItems & Environment.NewLine & "Customer has been reset!!!",
                                        "Corrections needed")

                        '
                        ' Read current values from database
                        '
                        Dim originalCustomer = operations.CustomerFirstOrDefault(customerItem.CustomerIdentifier)

                        '
                        ' reset current item both in Customer object and CustomerEntity object
                        ' (there are other ways to deal with this but are dependent on business logic)
                        '
                        customerEntry.CurrentValues.SetValues(originalCustomer)
                        _customerView.Item(_customerBindingSource.Position) = originalCustomer

                    Else
                        operations.Context.SaveChanges()
                    End If
                End If
            End If

        End If
    End Sub
    ''' <summary>
    ''' Since first and last name belong to Contact table and not Customer the ListChanged event
    ''' will be unaware of the changes since Customer only knows about the Contact primary key.
    ''' 
    ''' This code executes when a cells is edited belonging to first or last name properties.
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        '
        ' Don't fire when loading the DataGridView
        '
        If DataGridView1.DataSource IsNot Nothing Then
            '
            ' If first or last name save changes, no check to see if there are actual
            ' changes.
            '
            If DataGridView1.Columns(e.ColumnIndex).Name = "FirstNameColumn" OrElse DataGridView1.Columns(e.ColumnIndex).Name = "LastNameColumn" Then
                '
                ' Get current customer for the Contact key, find the Contact
                ' and update first or last name
                '
                Dim customer As CustomerEntity = _customerView.CurrentCustomer(_customerBindingSource.Position)
                Dim contact = operations.Context.Contacts.FirstOrDefault(Function(c) c.ContactIdentifier = CInt(customer.ContactIdentifier))

                If DataGridView1.Columns(e.ColumnIndex).Name = "FirstNameColumn" Then
                    contact.FirstName = CStr(DataGridView1.Rows(e.RowIndex).Cells("FirstNameColumn").Value)
                End If

                If DataGridView1.Columns(e.ColumnIndex).Name = "LastNameColumn" Then
                    contact.LastName = CStr(DataGridView1.Rows(e.RowIndex).Cells("LastNameColumn").Value)
                End If

                operations.Context.SaveChanges()

            End If
        End If
    End Sub
End Class


