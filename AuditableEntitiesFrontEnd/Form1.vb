Imports System.Data.Entity
Imports AuditableEntitiesFrontEnd.Modules
Imports BackendAuditableEntities

Public Class Form1
    Private dbContext As New Context

    Private Sub AddContactButton_Click(sender As Object, e As EventArgs) Handles AddContactButton.Click
        AddNewTextBox.Text = ""

        Dim contact = New Contact2 With {.FirstName = "Mary", .LastName = "Miller"}
        dbContext.Contact2.Add(contact)
        Dim affected = dbContext.SaveChanges(CurrentUserIdentifier)

        AddNewTextBox.Text = $"Add contact: {affected}"

    End Sub

    Private Sub EditFirstButton_Click(sender As Object, e As EventArgs) Handles EditFirstButton.Click
        EditTextBox.Text = ""

        If Not String.IsNullOrWhiteSpace(NewFirstNameTextBox.Text) Then
            Dim contact = dbContext.Contact2.FirstOrDefault()
            If contact IsNot Nothing Then
                contact.FirstName = NewFirstNameTextBox.Text
                Dim affected = dbContext.SaveChanges(CurrentUserIdentifier)

                EditTextBox.Text = $"Edit contact: {affected}"
            Else
                EditTextBox.Text = "In Edit: Must add a contact first"
            End If
        Else
            MessageBox.Show("First name can not be empty")
        End If

    End Sub
    Private Sub SoftDeleteButton_Click(sender As Object, e As EventArgs) Handles SoftDeleteButton.Click
        SoftTextBox.Text = ""

        Dim contact = dbContext.Contact2.FirstOrDefault()
        If contact IsNot Nothing Then
            dbContext.Entry(contact).State = EntityState.Deleted
            Dim affected = dbContext.SaveChanges(CurrentUserIdentifier)
            SoftTextBox.Text = affected.ToString()
        Else
            SoftTextBox.Text = "In delete: Must add a contact first"
        End If
    End Sub

    Private Sub FirstContactButton_Click(sender As Object, e As EventArgs) Handles FirstContactButton.Click
        FirstTextBox.Text = ""
        Dim contact = dbContext.Contact2.FirstOrDefault()
        If contact IsNot Nothing Then
            Console.WriteLine(contact.FirstName)
            FirstTextBox.Text = $"{contact.FirstName} {contact.LastName}"
        Else
            FirstTextBox.Text = "Add a contact"
        End If
    End Sub
End Class
