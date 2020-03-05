Imports System.Data.Entity
Imports Backend

''' <summary>
''' For testing only, this form will eventually be removed.
''' </summary>
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
        Dim contact2 = dbContext.Contact1.FirstOrDefault(Function(contact) contact.ContactId = 2)

        dbContext.Entry(contact1).State = EntityState.Deleted

        contact2.FirstName = "Mary"

        Dim affected = dbContext.SaveChanges()
        Console.WriteLine(affected)
    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim contact1 = dbContext.Contact1.FirstOrDefault(Function(contact) contact.ContactId = 1)
        Dim contact2 = dbContext.Contact1.FirstOrDefault(Function(contact) contact.ContactId = 2)

        dbContext.Entry(contact1).State = EntityState.Deleted

        contact2.FirstName = "Anne"

        Dim affected = Await dbContext.SaveChangesAsync()
        Console.WriteLine(affected)
    End Sub
End Class
