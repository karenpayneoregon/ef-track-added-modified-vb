Imports BackendExperimenting
Imports Validators

Public Class EditorForm
    Private currentPerson As Person
    Public Sub New(person As Person)
        InitializeComponent()
        currentPerson = person
    End Sub
    Private Sub EditorForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        FirstNameTextBox.DataBindings.Add("Text", currentPerson, "FirstName")
        LastNameTextBox.DataBindings.Add("Text", currentPerson, "LastName")


        If currentPerson.BirthDate.HasValue Then
            BirthDateDateTimePicker.Value = currentPerson.BirthDate.Value
        Else
            BirthDateDateTimePicker.Value = Nothing
        End If

    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        currentPerson.FirstName = FirstNameTextBox.Text
        currentPerson.LastName = LastNameTextBox.Text

        '
        ' validate properties
        '
        Dim validation = ValidationHelper.ValidateEntity(currentPerson)

        If validation.HasViolations Then

            Dim errorItems = String.Join(
                Environment.NewLine,
                validation.ErrorItemList().
                        Select(Function(containerItem) containerItem.ErrorMessage).ToArray())

            MessageBox.Show(errorItems, "Corrections needed")

        Else
            DialogResult = DialogResult.OK
        End If

    End Sub
End Class