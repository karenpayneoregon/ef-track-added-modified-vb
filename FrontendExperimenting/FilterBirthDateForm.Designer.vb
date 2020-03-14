<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterBirthDateForm
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ApplyFilterButton = New System.Windows.Forms.Button()
        Me.RemoveFilterButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(96, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(139, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Birthdates after"
        '
        'ApplyFilterButton
        '
        Me.ApplyFilterButton.Location = New System.Drawing.Point(12, 48)
        Me.ApplyFilterButton.Name = "ApplyFilterButton"
        Me.ApplyFilterButton.Size = New System.Drawing.Size(91, 23)
        Me.ApplyFilterButton.TabIndex = 2
        Me.ApplyFilterButton.Text = "Apply filter"
        Me.ApplyFilterButton.UseVisualStyleBackColor = True
        '
        'RemoveFilterButton
        '
        Me.RemoveFilterButton.Location = New System.Drawing.Point(144, 48)
        Me.RemoveFilterButton.Name = "RemoveFilterButton"
        Me.RemoveFilterButton.Size = New System.Drawing.Size(91, 23)
        Me.RemoveFilterButton.TabIndex = 3
        Me.RemoveFilterButton.Text = "Remove filter"
        Me.RemoveFilterButton.UseVisualStyleBackColor = True
        '
        'FilterBirthDateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 84)
        Me.Controls.Add(Me.RemoveFilterButton)
        Me.Controls.Add(Me.ApplyFilterButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FilterBirthDateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filter BirthDate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents ApplyFilterButton As Button
    Friend WithEvents RemoveFilterButton As Button
End Class
