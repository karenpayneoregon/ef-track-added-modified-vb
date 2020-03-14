Imports BackendCore

Public Class Form1
    Private Context As New Context

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim test = Context.People.ToList()
            Console.WriteLine(test.Count)
        Catch ex As Exception
            Console.WriteLine()
        End Try
    End Sub
End Class
