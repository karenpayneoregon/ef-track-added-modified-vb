<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CurrentCustomerButton = New System.Windows.Forms.Button()
        Me.CustomersDataGridView = New System.Windows.Forms.DataGridView()
        Me.CompanyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactTitleColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.AddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PostalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CountryColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindByCompanyNameToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CompanyNameFindToolStripTextBox = New FrontEndRelational.MyToolStripTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.CustomersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CurrentCustomerButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 269)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1049, 55)
        Me.Panel1.TabIndex = 0
        '
        'CurrentCustomerButton
        '
        Me.CurrentCustomerButton.Enabled = False
        Me.CurrentCustomerButton.Location = New System.Drawing.Point(12, 20)
        Me.CurrentCustomerButton.Name = "CurrentCustomerButton"
        Me.CurrentCustomerButton.Size = New System.Drawing.Size(118, 23)
        Me.CurrentCustomerButton.TabIndex = 1
        Me.CurrentCustomerButton.Text = "Current Customer"
        Me.CurrentCustomerButton.UseVisualStyleBackColor = True
        '
        'CustomersDataGridView
        '
        Me.CustomersDataGridView.AllowUserToAddRows = False
        Me.CustomersDataGridView.AllowUserToDeleteRows = False
        Me.CustomersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CustomersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompanyColumn, Me.FirstNameColumn, Me.LastNameColumn, Me.ContactTitleColumn, Me.AddressColumn, Me.CityColumn, Me.PostalColumn, Me.CountryColumn})
        Me.CustomersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomersDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.CustomersDataGridView.Name = "CustomersDataGridView"
        Me.CustomersDataGridView.Size = New System.Drawing.Size(1049, 244)
        Me.CustomersDataGridView.TabIndex = 1
        '
        'CompanyColumn
        '
        Me.CompanyColumn.DataPropertyName = "CompanyName"
        Me.CompanyColumn.HeaderText = "Company"
        Me.CompanyColumn.Name = "CompanyColumn"
        '
        'FirstNameColumn
        '
        Me.FirstNameColumn.DataPropertyName = "FirstName"
        Me.FirstNameColumn.HeaderText = "First name"
        Me.FirstNameColumn.Name = "FirstNameColumn"
        '
        'LastNameColumn
        '
        Me.LastNameColumn.DataPropertyName = "LastName"
        Me.LastNameColumn.HeaderText = "Last name"
        Me.LastNameColumn.Name = "LastNameColumn"
        '
        'ContactTitleColumn
        '
        Me.ContactTitleColumn.DataPropertyName = "ContactTitle"
        Me.ContactTitleColumn.HeaderText = "Title"
        Me.ContactTitleColumn.Name = "ContactTitleColumn"
        Me.ContactTitleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ContactTitleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'AddressColumn
        '
        Me.AddressColumn.DataPropertyName = "Street"
        Me.AddressColumn.HeaderText = "Address"
        Me.AddressColumn.Name = "AddressColumn"
        '
        'CityColumn
        '
        Me.CityColumn.DataPropertyName = "City"
        Me.CityColumn.HeaderText = "City"
        Me.CityColumn.Name = "CityColumn"
        '
        'PostalColumn
        '
        Me.PostalColumn.DataPropertyName = "PostalCode"
        Me.PostalColumn.HeaderText = "Postal"
        Me.PostalColumn.Name = "PostalColumn"
        '
        'CountryColumn
        '
        Me.CountryColumn.DataPropertyName = "CountyName"
        Me.CountryColumn.HeaderText = "Country"
        Me.CountryColumn.Name = "CountryColumn"
        Me.CountryColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CountryColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ToolStripSeparator1, Me.FindByCompanyNameToolStripButton, Me.CompanyNameFindToolStripTextBox})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(1049, 25)
        Me.BindingNavigator1.TabIndex = 2
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'FindByCompanyNameToolStripButton
        '
        Me.FindByCompanyNameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindByCompanyNameToolStripButton.Image = CType(resources.GetObject("FindByCompanyNameToolStripButton.Image"), System.Drawing.Image)
        Me.FindByCompanyNameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindByCompanyNameToolStripButton.Name = "FindByCompanyNameToolStripButton"
        Me.FindByCompanyNameToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FindByCompanyNameToolStripButton.Text = "ToolStripButton1"
        '
        'CompanyNameFindToolStripTextBox
        '
        Me.CompanyNameFindToolStripTextBox.BackColor = System.Drawing.Color.Cornsilk
        Me.CompanyNameFindToolStripTextBox.CueBanner = Nothing
        Me.CompanyNameFindToolStripTextBox.Name = "CompanyNameFindToolStripTextBox"
        Me.CompanyNameFindToolStripTextBox.Size = New System.Drawing.Size(150, 25)
        Me.CompanyNameFindToolStripTextBox.ToolTipText = "Use to find a company starting with text enter"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 324)
        Me.Controls.Add(Me.CustomersDataGridView)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entity Framework Classic immediate updates"
        Me.Panel1.ResumeLayout(False)
        CType(Me.CustomersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents CustomersDataGridView As DataGridView
    Friend WithEvents CurrentCustomerButton As Button
    Friend WithEvents CompanyColumn As DataGridViewTextBoxColumn
    Friend WithEvents FirstNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContactTitleColumn As DataGridViewComboBoxColumn
    Friend WithEvents AddressColumn As DataGridViewTextBoxColumn
    Friend WithEvents CityColumn As DataGridViewTextBoxColumn
    Friend WithEvents PostalColumn As DataGridViewTextBoxColumn
    Friend WithEvents CountryColumn As DataGridViewComboBoxColumn
    Friend WithEvents BindingNavigator1 As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents FindByCompanyNameToolStripButton As ToolStripButton
    Friend WithEvents CompanyNameFindToolStripTextBox As MyToolStripTextBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
