Imports Backend

Public Class Form1
    Private dbContext As New Context
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim contacts = dbContext.Contact1.ToList()
        contacts.FirstOrDefault().FirstName = "Sam"
        Await dbContext.SaveChangesAsync()
    End Sub
End Class
