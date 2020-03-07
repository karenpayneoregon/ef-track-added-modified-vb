<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FirstNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastUpdatedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastUpdatedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedAtColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedByColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstNameNewTextBox = New System.Windows.Forms.TextBox()
        Me.LastNameNewTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AddContactButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DeleteCurrentButton = New System.Windows.Forms.Button()
        Me.SaveCurrentButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LastNameEditTextBox = New System.Windows.Forms.TextBox()
        Me.FirstNameEditTextBox = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FirstNameColumn, Me.LastNameColumn, Me.LastUpdatedColumn, Me.LastUpdatedByColumn, Me.CreatedAtColumn, Me.CreatedByColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(696, 160)
        Me.DataGridView1.TabIndex = 3
        '
        'FirstNameColumn
        '
        Me.FirstNameColumn.DataPropertyName = "FirstName"
        Me.FirstNameColumn.HeaderText = "First"
        Me.FirstNameColumn.Name = "FirstNameColumn"
        '
        'LastNameColumn
        '
        Me.LastNameColumn.DataPropertyName = "LastName"
        Me.LastNameColumn.HeaderText = "Last"
        Me.LastNameColumn.Name = "LastNameColumn"
        '
        'LastUpdatedColumn
        '
        Me.LastUpdatedColumn.DataPropertyName = "LastUpdated"
        Me.LastUpdatedColumn.HeaderText = "Updated"
        Me.LastUpdatedColumn.Name = "LastUpdatedColumn"
        '
        'LastUpdatedByColumn
        '
        Me.LastUpdatedByColumn.DataPropertyName = "LastUser"
        Me.LastUpdatedByColumn.HeaderText = "By"
        Me.LastUpdatedByColumn.Name = "LastUpdatedByColumn"
        '
        'CreatedAtColumn
        '
        Me.CreatedAtColumn.DataPropertyName = "CreatedAt"
        Me.CreatedAtColumn.HeaderText = "Created"
        Me.CreatedAtColumn.Name = "CreatedAtColumn"
        '
        'CreatedByColumn
        '
        Me.CreatedByColumn.DataPropertyName = "CreatedBy"
        Me.CreatedByColumn.HeaderText = "By"
        Me.CreatedByColumn.Name = "CreatedByColumn"
        '
        'FirstNameNewTextBox
        '
        Me.FirstNameNewTextBox.Location = New System.Drawing.Point(96, 22)
        Me.FirstNameNewTextBox.Name = "FirstNameNewTextBox"
        Me.FirstNameNewTextBox.Size = New System.Drawing.Size(183, 20)
        Me.FirstNameNewTextBox.TabIndex = 4
        '
        'LastNameNewTextBox
        '
        Me.LastNameNewTextBox.Location = New System.Drawing.Point(96, 48)
        Me.LastNameNewTextBox.Name = "LastNameNewTextBox"
        Me.LastNameNewTextBox.Size = New System.Drawing.Size(183, 20)
        Me.LastNameNewTextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "First name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Last name"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AddContactButton)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LastNameNewTextBox)
        Me.GroupBox1.Controls.Add(Me.FirstNameNewTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 176)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 140)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add new contact"
        '
        'AddContactButton
        '
        Me.AddContactButton.Location = New System.Drawing.Point(96, 74)
        Me.AddContactButton.Name = "AddContactButton"
        Me.AddContactButton.Size = New System.Drawing.Size(183, 23)
        Me.AddContactButton.TabIndex = 8
        Me.AddContactButton.Text = "Add new"
        Me.AddContactButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DeleteCurrentButton)
        Me.GroupBox2.Controls.Add(Me.SaveCurrentButton)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.LastNameEditTextBox)
        Me.GroupBox2.Controls.Add(Me.FirstNameEditTextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(373, 176)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(311, 140)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Edit current contact"
        '
        'DeleteCurrentButton
        '
        Me.DeleteCurrentButton.Enabled = False
        Me.DeleteCurrentButton.Location = New System.Drawing.Point(96, 103)
        Me.DeleteCurrentButton.Name = "DeleteCurrentButton"
        Me.DeleteCurrentButton.Size = New System.Drawing.Size(183, 23)
        Me.DeleteCurrentButton.TabIndex = 10
        Me.DeleteCurrentButton.Text = "Delete current"
        Me.DeleteCurrentButton.UseVisualStyleBackColor = True
        '
        'SaveCurrentButton
        '
        Me.SaveCurrentButton.Enabled = False
        Me.SaveCurrentButton.Location = New System.Drawing.Point(96, 74)
        Me.SaveCurrentButton.Name = "SaveCurrentButton"
        Me.SaveCurrentButton.Size = New System.Drawing.Size(183, 23)
        Me.SaveCurrentButton.TabIndex = 9
        Me.SaveCurrentButton.Text = "Save current"
        Me.SaveCurrentButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Last name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "First name"
        '
        'LastNameEditTextBox
        '
        Me.LastNameEditTextBox.Location = New System.Drawing.Point(96, 48)
        Me.LastNameEditTextBox.Name = "LastNameEditTextBox"
        Me.LastNameEditTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LastNameEditTextBox.Size = New System.Drawing.Size(183, 20)
        Me.LastNameEditTextBox.TabIndex = 5
        '
        'FirstNameEditTextBox
        '
        Me.FirstNameEditTextBox.Location = New System.Drawing.Point(96, 22)
        Me.FirstNameEditTextBox.Name = "FirstNameEditTextBox"
        Me.FirstNameEditTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FirstNameEditTextBox.Size = New System.Drawing.Size(183, 20)
        Me.FirstNameEditTextBox.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 337)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Soft delete/last updated, created"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents FirstNameNewTextBox As TextBox
    Friend WithEvents LastNameNewTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents AddContactButton As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SaveCurrentButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LastNameEditTextBox As TextBox
    Friend WithEvents FirstNameEditTextBox As TextBox
    Friend WithEvents FirstNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastUpdatedColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastUpdatedByColumn As DataGridViewTextBoxColumn
    Friend WithEvents CreatedAtColumn As DataGridViewTextBoxColumn
    Friend WithEvents CreatedByColumn As DataGridViewTextBoxColumn
    Friend WithEvents DeleteCurrentButton As Button
End Class
