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
        Me.AddConectButton = New System.Windows.Forms.Button()
        Me.EditFirstButton = New System.Windows.Forms.Button()
        Me.SoftDeleteButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'AddConectButton
        '
        Me.AddConectButton.Location = New System.Drawing.Point(12, 23)
        Me.AddConectButton.Name = "AddConectButton"
        Me.AddConectButton.Size = New System.Drawing.Size(186, 23)
        Me.AddConectButton.TabIndex = 0
        Me.AddConectButton.Text = "Add new contact"
        Me.AddConectButton.UseVisualStyleBackColor = True
        '
        'EditFirstButton
        '
        Me.EditFirstButton.Location = New System.Drawing.Point(12, 52)
        Me.EditFirstButton.Name = "EditFirstButton"
        Me.EditFirstButton.Size = New System.Drawing.Size(186, 23)
        Me.EditFirstButton.TabIndex = 1
        Me.EditFirstButton.Text = "Edit first contact"
        Me.EditFirstButton.UseVisualStyleBackColor = True
        '
        'SoftDeleteButton
        '
        Me.SoftDeleteButton.Location = New System.Drawing.Point(12, 81)
        Me.SoftDeleteButton.Name = "SoftDeleteButton"
        Me.SoftDeleteButton.Size = New System.Drawing.Size(186, 23)
        Me.SoftDeleteButton.TabIndex = 2
        Me.SoftDeleteButton.Text = "Soft delete contact"
        Me.SoftDeleteButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 137)
        Me.Controls.Add(Me.SoftDeleteButton)
        Me.Controls.Add(Me.EditFirstButton)
        Me.Controls.Add(Me.AddConectButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AddConectButton As Button
    Friend WithEvents EditFirstButton As Button
    Friend WithEvents SoftDeleteButton As Button
End Class
