Imports System.ComponentModel.DataAnnotations
Imports BackendExperimenting
Imports BackendExperimenting.Helpers
Imports Equin.ApplicationFramework
Imports Validators

Public Class Form1
    Private Context As New Context
    Private _originalCount As Integer = 0
    Private _customerView As BindingListView(Of Person)
    WithEvents _customerBindingSource As New BindingSource

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '
        ' Columns and DataPropertyName are defined in the
        ' DataGridView designer
        '
        DataGridView1.AutoGenerateColumns = False

        '
        ' Read people data from database
        '
        _customerView = New BindingListView(Of Person)(Context.People.ToList())

        '
        ' Remember count of people read in for use with save changes
        '
        _originalCount = _customerView.Count
        _customerBindingSource.DataSource = _customerView

        BindingNavigator1.BindingSource = _customerBindingSource
        DataGridView1.DataSource = _customerBindingSource

        ActiveControl = DataGridView1

    End Sub

    ''' <summary>
    ''' Validate there are no issues followed by saving
    ''' changes if any.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        Try
            Dim validationErrors As List(Of ValidationResult) = Context.ValidateChanges

            If validationErrors.Count = 0 Then
                Dim affected = Context.SaveChanges()
                MessageBox.Show($"Changes pushed to table: {affected}")
            Else
                MessageBox.Show(validationErrors.Flatten, "Validation issues")
            End If

        Catch ex As Exception
            MessageBox.Show($"Failed: {ex.Message}")
        End Try

    End Sub
    ''' <summary>
    ''' Add new empty Person
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        _customerView.AddNew()
        Dim p = New Person
        _customerView.NewItemsList.Add(p)
        Context.People.Add(p)
        _customerBindingSource.ResetBindings(False)
        _customerBindingSource.MoveLast()

    End Sub

#Region "Delete current person logic/assertion"
    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) _
        Handles BindingNavigatorDeleteItem.Click

        If _customerBindingSource.Current IsNot Nothing Then
            Dim person = _customerView(_customerBindingSource.Position).Object

            If My.Dialogs.Question($"Remove '{person}'") Then
                RemoveCurrent()
            End If
        End If
    End Sub
    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) _
        Handles DataGridView1.UserDeletingRow

        If _customerBindingSource.Current IsNot Nothing Then
            Dim person = _customerView(_customerBindingSource.Position).Object
            If My.Dialogs.Question($"Remove '{person}'") Then
                RemoveCurrent()
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub RemoveCurrent()
        Context.People.Remove(CType(_customerView(_customerBindingSource.Position), Person))
    End Sub

#End Region
#Region "Edit for current person"

    Private Sub EditCurrentPersonButton_Click(sender As Object, e As EventArgs) Handles EditCurrentPersonButton.Click
        EditCurrentPerson()
    End Sub

    Private Sub EditCurrentPersonToolStripButton_Click(sender As Object, e As EventArgs) Handles EditCurrentPersonToolStripButton.Click
        EditCurrentPerson()
    End Sub
    Private Sub EditCurrentPerson()
        '
        ' Get current person 
        '
        Dim currentPerson As Person = _customerView(_customerBindingSource.Position).Object
        '
        ' Make a copy to be used if edits are cancelled
        '
        Dim revertCopy = ObjectCloner.ObjectCloner.DeepClone(currentPerson)


        Dim editorForm As New EditorForm(currentPerson)

        If editorForm.ShowDialog() = DialogResult.Cancel Then
            currentPerson.CancelEdit(revertCopy)
        End If

    End Sub

#End Region

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        MessageBox.Show("Invalid entry")
        e.Cancel = True
    End Sub
    ''' <summary>
    ''' Starting of peeking at changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ReviewChangesToolStripButton_Click(sender As Object, e As EventArgs) Handles ReviewChangesToolStripButton.Click
        Context.Review()
    End Sub
End Class
