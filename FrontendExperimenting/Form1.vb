Imports System.ComponentModel
Imports BackendExperimenting
Imports Equin.ApplicationFramework

Public Class Form1
    Private Context As New Context
    Private _originalCount As Integer = 0
    Private _customerView As BindingListView(Of Person)
    Private _customerBindingSource As New BindingSource

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

    End Sub
    ''' <summary>
    ''' Provides a starting point to inspect entities
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ReviewChangesButton_Click(sender As Object, e As EventArgs) Handles ReviewChangesButton.Click
        Context.Review()
    End Sub
    ''' <summary>
    ''' Tell the context people have been added or not using the Person List 
    ''' and save
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

        Dim newEntityList As New List(Of Person)

        If _customerView.Count > _originalCount Then
            For index As Integer = _originalCount To _customerView.Count - 1
                newEntityList.Add(_customerView(index).Object)
            Next
        End If

        Dim affected = Context.SaveChanges(newEntityList)
        MessageBox.Show($"Changes pushed to table: {affected}")

    End Sub
    ''' <summary>
    ''' Add new empty Person
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        _customerView.AddNew()
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
        _customerBindingSource.RemoveCurrent()
    End Sub
#End Region

End Class
