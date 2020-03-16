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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CompanyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactTitleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PostalColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CountryColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 395)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 55)
        Me.Panel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompanyColumn, Me.ContactNameColumn, Me.ContactTitleColumn, Me.AddressColumn, Me.CityColumn, Me.PostalColumn, Me.CountryColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(800, 395)
        Me.DataGridView1.TabIndex = 1
        '
        'CompanyColumn
        '
        Me.CompanyColumn.DataPropertyName = "CompanyName"
        Me.CompanyColumn.HeaderText = "Company"
        Me.CompanyColumn.Name = "CompanyColumn"
        '
        'ContactNameColumn
        '
        Me.ContactNameColumn.DataPropertyName = "ContactName"
        Me.ContactNameColumn.HeaderText = "Contact"
        Me.ContactNameColumn.Name = "ContactNameColumn"
        '
        'ContactTitleColumn
        '
        Me.ContactTitleColumn.DataPropertyName = "ContactTitle"
        Me.ContactTitleColumn.HeaderText = "Title"
        Me.ContactTitleColumn.Name = "ContactTitleColumn"
        '
        'AddressColumn
        '
        Me.AddressColumn.DataPropertyName = "Address"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CompanyColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContactNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContactTitleColumn As DataGridViewTextBoxColumn
    Friend WithEvents AddressColumn As DataGridViewTextBoxColumn
    Friend WithEvents CityColumn As DataGridViewTextBoxColumn
    Friend WithEvents PostalColumn As DataGridViewTextBoxColumn
    Friend WithEvents CountryColumn As DataGridViewComboBoxColumn
    Friend WithEvents Button1 As Button
End Class
