Imports System.Data.Entity
Imports AuditableEntitiesFrontEnd.Modules
Imports BackendAuditableEntities

Public Class Form1
    Private dbContext As New Context

    Private Sub AddConectButton_Click(sender As Object, e As EventArgs) Handles AddConectButton.Click
        Dim contact = New Contact2 With {.FirstName = "Mary", .LastName = "Miller"}
        dbContext.Contact2.Add(contact)
        Dim affected = dbContext.SaveChanges(CurrentUserIdentifier)
        Console.WriteLine(affected)
    End Sub

    Private Sub EditFirstButton_Click(sender As Object, e As EventArgs) Handles EditFirstButton.Click
        Dim contact = dbContext.Contact2.FirstOrDefault()
        If contact IsNot Nothing Then
            contact.FirstName = "Mike"
            Dim affected = dbContext.SaveChanges(CurrentUserIdentifier)
            Console.WriteLine(affected)
        End If
    End Sub
    Private Sub SoftDeleteButton_Click(sender As Object, e As EventArgs) Handles SoftDeleteButton.Click
        Dim contact = dbContext.Contact2.FirstOrDefault()
        If contact IsNot Nothing Then
            dbContext.Entry(contact).State = EntityState.Deleted
            Dim affected = dbContext.SaveChanges(CurrentUserIdentifier)
            Console.WriteLine(affected)
        End If
    End Sub
End Class
