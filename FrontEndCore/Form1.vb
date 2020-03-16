Imports BackendCore

Public Class Form1
    Private Context As New Context
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = Context.People.ToList()
    End Sub
End Class
