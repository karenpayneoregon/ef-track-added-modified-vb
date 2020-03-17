Imports System.ComponentModel
Imports BackEndRelational
Imports Equin.ApplicationFramework

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

        Dim customerEntities = Await operations.AllCustomersAsync()

        _customerView = New SortableBindingList(Of CustomerEntity)(customerEntities)
        _customerBindingSource.DataSource = _customerView


        CountryColumn.DisplayMember = "CountryName"
        CountryColumn.ValueMember = "CountryIdentifier"
        CountryColumn.DataPropertyName = "CountryIdentifier"
        CountryColumn.DataSource = operations.CountryList()
        CountryColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        DataGridView1.DataSource = _customerBindingSource

        CurrentCustomerButton.Enabled = True


    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Console.WriteLine(e.Exception.Message)
        e.Cancel = True
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

    Private Sub _customerView_ListChanged(sender As Object, e As ListChangedEventArgs) Handles _customerView.ListChanged
        If e.PropertyDescriptor IsNot Nothing Then

            If DataGridView1.CurrentCell.IsComboBoxCell() Then
                '
                ' TODO handle DataGridViewComboBox differently
                '
            End If

            Dim currentCustomer As CustomerEntity = _customerView.CurrentCustomer(_customerBindingSource.Position)

            If e.ListChangedType = ListChangedType.ItemChanged Then
                Dim customerItem = operations.Context.Customers.FirstOrDefault(Function(cust) cust.CustomerIdentifier = currentCustomer.CustomerIdentifier)

                If customerItem IsNot Nothing Then
                    Dim customerEntry = operations.Context.Entry(customerItem)
                    customerEntry.CurrentValues.SetValues(currentCustomer)
                End If
            End If

        End If
    End Sub
End Class


