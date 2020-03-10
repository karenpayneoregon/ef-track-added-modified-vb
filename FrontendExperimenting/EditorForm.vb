Imports BackendExperimenting

Public Class EditorForm
    Private currentPerson As Person
    Public Sub New(person As Person)
        InitializeComponent()
        currentPerson = person
    End Sub
    Private Sub EditorForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        FirstNameTextBox.DataBindings.Add("Text", currentPerson, "FirstName")
        LastNameTextBox.DataBindings.Add("Text", currentPerson, "LastName")
        'FirstNameTextBox.Text = currentPerson.FirstName
        'LastNameTextBox.Text = currentPerson.LastName


        If currentPerson.BirthDate.HasValue Then
            BirthDateDateTimePicker.Value = currentPerson.BirthDate.Value
        Else
            BirthDateDateTimePicker.Value = Nothing
        End If

    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        If Not String.IsNullOrWhiteSpace(FirstNameTextBox.Text) OrElse Not String.IsNullOrWhiteSpace(LastNameTextBox.Text) Then
            DialogResult = DialogResult.OK
        Else
            MessageBox.Show("First and last name are required")
        End If
    End Sub


End Class