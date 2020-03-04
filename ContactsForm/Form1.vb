Imports System.Data.Entity
Imports Backend

Public Class Form1
    Private dbContext As New Context
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim contacts = dbContext.Contact1.ToList()
        Console.WriteLine(contacts.Count)

        Dim activeContacts = dbContext.ApplyActiveFilter(dbContext.Contact1).ToList()
        Console.WriteLine(activeContacts.Count)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim contact1 = dbContext.Contact1.FirstOrDefault(Function(contact) contact.ContactId = 1)

        dbContext.Entry(contact1).State = EntityState.Deleted

        dbContext.SaveChanges()
    End Sub
End Class
