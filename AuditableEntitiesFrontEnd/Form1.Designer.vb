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
        Me.AddContactButton = New System.Windows.Forms.Button()
        Me.EditFirstButton = New System.Windows.Forms.Button()
        Me.SoftDeleteButton = New System.Windows.Forms.Button()
        Me.FirstContactButton = New System.Windows.Forms.Button()
        Me.AddNewTextBox = New System.Windows.Forms.TextBox()
        Me.FirstTextBox = New System.Windows.Forms.TextBox()
        Me.EditTextBox = New System.Windows.Forms.TextBox()
        Me.SoftTextBox = New System.Windows.Forms.TextBox()
        Me.NewFirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AddContactButton
        '
        Me.AddContactButton.Location = New System.Drawing.Point(21, 51)
        Me.AddContactButton.Name = "AddContactButton"
        Me.AddContactButton.Size = New System.Drawing.Size(186, 23)
        Me.AddContactButton.TabIndex = 0
        Me.AddContactButton.Text = "Add new contact"
        Me.AddContactButton.UseVisualStyleBackColor = True
        '
        'EditFirstButton
        '
        Me.EditFirstButton.Location = New System.Drawing.Point(21, 80)
        Me.EditFirstButton.Name = "EditFirstButton"
        Me.EditFirstButton.Size = New System.Drawing.Size(186, 23)
        Me.EditFirstButton.TabIndex = 1
        Me.EditFirstButton.Text = "Edit first contact"
        Me.EditFirstButton.UseVisualStyleBackColor = True
        '
        'SoftDeleteButton
        '
        Me.SoftDeleteButton.Location = New System.Drawing.Point(21, 109)
        Me.SoftDeleteButton.Name = "SoftDeleteButton"
        Me.SoftDeleteButton.Size = New System.Drawing.Size(186, 23)
        Me.SoftDeleteButton.TabIndex = 2
        Me.SoftDeleteButton.Text = "Soft delete contact"
        Me.SoftDeleteButton.UseVisualStyleBackColor = True
        '
        'FirstContactButton
        '
        Me.FirstContactButton.Location = New System.Drawing.Point(21, 22)
        Me.FirstContactButton.Name = "FirstContactButton"
        Me.FirstContactButton.Size = New System.Drawing.Size(186, 23)
        Me.FirstContactButton.TabIndex = 3
        Me.FirstContactButton.Text = "First contact"
        Me.FirstContactButton.UseVisualStyleBackColor = True
        '
        'AddNewTextBox
        '
        Me.AddNewTextBox.Location = New System.Drawing.Point(213, 54)
        Me.AddNewTextBox.Name = "AddNewTextBox"
        Me.AddNewTextBox.Size = New System.Drawing.Size(200, 20)
        Me.AddNewTextBox.TabIndex = 4
        '
        'FirstTextBox
        '
        Me.FirstTextBox.Location = New System.Drawing.Point(213, 22)
        Me.FirstTextBox.Name = "FirstTextBox"
        Me.FirstTextBox.Size = New System.Drawing.Size(200, 20)
        Me.FirstTextBox.TabIndex = 5
        '
        'EditTextBox
        '
        Me.EditTextBox.Location = New System.Drawing.Point(213, 82)
        Me.EditTextBox.Name = "EditTextBox"
        Me.EditTextBox.Size = New System.Drawing.Size(200, 20)
        Me.EditTextBox.TabIndex = 6
        '
        'SoftTextBox
        '
        Me.SoftTextBox.Location = New System.Drawing.Point(213, 111)
        Me.SoftTextBox.Name = "SoftTextBox"
        Me.SoftTextBox.Size = New System.Drawing.Size(200, 20)
        Me.SoftTextBox.TabIndex = 7
        '
        'NewFirstNameTextBox
        '
        Me.NewFirstNameTextBox.Location = New System.Drawing.Point(431, 83)
        Me.NewFirstNameTextBox.Name = "NewFirstNameTextBox"
        Me.NewFirstNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.NewFirstNameTextBox.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(439, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Change current first name to"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 146)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NewFirstNameTextBox)
        Me.Controls.Add(Me.SoftTextBox)
        Me.Controls.Add(Me.EditTextBox)
        Me.Controls.Add(Me.FirstTextBox)
        Me.Controls.Add(Me.AddNewTextBox)
        Me.Controls.Add(Me.FirstContactButton)
        Me.Controls.Add(Me.SoftDeleteButton)
        Me.Controls.Add(Me.EditFirstButton)
        Me.Controls.Add(Me.AddContactButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NuGet package version"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AddContactButton As Button
    Friend WithEvents EditFirstButton As Button
    Friend WithEvents SoftDeleteButton As Button
    Friend WithEvents FirstContactButton As Button
    Friend WithEvents AddNewTextBox As TextBox
    Friend WithEvents FirstTextBox As TextBox
    Friend WithEvents EditTextBox As TextBox
    Friend WithEvents SoftTextBox As TextBox
    Friend WithEvents NewFirstNameTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
