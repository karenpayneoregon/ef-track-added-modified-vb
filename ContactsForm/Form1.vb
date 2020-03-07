Imports System.ComponentModel
Imports System.Data.Entity
Imports Backend
Imports ContactsForm.Extensions
Imports ContactsForm.Modules

''' <summary>
''' For testing only, this form will eventually be removed.
''' </summary>
Public Class Form1
    ''' <summary>
    ''' AutoDetectChangesEnabled is true
    ''' </summary>
    Private dbContext As New Context
    Private _bindingListContacts As New BindingList(Of Contact1)()

    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' no filter
        'Dim contacts = Await dbContext.Contact1.ToListAsync()
        Dim activeContacts = dbContext.ApplyActiveFilter(dbContext.Contact1).ToList()

        If activeContacts.Count > 0 Then
            SaveCurrentButton.Enabled = True
            DeleteCurrentButton.Enabled = True
        End If

        _bindingListContacts = New BindingList(Of Contact1)(activeContacts)
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = _bindingListContacts

        '            
        ' Data bind all exists contacts
        '             
        FirstNameEditTextBox.DataBindings.Add("Text", _bindingListContacts, "FirstName")
        LastNameEditTextBox.DataBindings.Add("Text", _bindingListContacts, "LastName")

        SetCueText(FirstNameEditTextBox, "Enter a first name")
        SetCueText(LastNameEditTextBox, "Enter a last name")

        SetCueText(FirstNameNewTextBox, "Enter a first name")
        SetCueText(LastNameNewTextBox, "Enter a last name")

    End Sub
    ''' <summary>
    ''' Save current contact to database, update DataGridView via INotifyPropertyChanged in Contact1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveCurrentButton_Click(sender As Object, e As EventArgs) Handles SaveCurrentButton.Click
        If (Not String.IsNullOrWhiteSpace(FirstNameEditTextBox.Text)) AndAlso (Not String.IsNullOrWhiteSpace(LastNameEditTextBox.Text)) Then

            Dim contact = _bindingListContacts(DataGridView1.CurrentRow.Index)

            contact.FirstName = FirstNameEditTextBox.Text
            contact.LastName = LastNameEditTextBox.Text

            dbContext.SaveChanges()
        Else
            MessageBox.Show("Requires both first and last name to save current contact")
        End If

    End Sub
    ''' <summary>
    ''' Save new contact to database, update DataGridView via INotifyPropertyChanged in Contact1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddContactButton_Click(sender As Object, e As EventArgs) Handles AddContactButton.Click

        If (Not String.IsNullOrWhiteSpace(FirstNameNewTextBox.Text)) AndAlso (Not String.IsNullOrWhiteSpace(LastNameNewTextBox.Text)) Then

            Dim contact = New Contact1() With {.FirstName = FirstNameNewTextBox.Text, .LastName = LastNameNewTextBox.Text, .IsDeleted = False}

            dbContext.Contact1.Add(contact)
            dbContext.SaveChanges()
            _bindingListContacts.Add(contact)

            SaveCurrentButton.Enabled = True

        Else
            MessageBox.Show("Requires both first and last name to add a new contact")
        End If
    End Sub

    Private Async Sub DeleteCurrentButton_Click(sender As Object, e As EventArgs) Handles DeleteCurrentButton.Click
        Dim contact = _bindingListContacts(DataGridView1.CurrentRow.Index)

        If Question($" Remove {contact.FirstName} {contact.LastName}?") Then

            dbContext.Entry(contact).State = EntityState.Deleted
            Dim affected = Await dbContext.SaveChangesAsync()
            _bindingListContacts.Remove(contact)

        End If

    End Sub
End Class
