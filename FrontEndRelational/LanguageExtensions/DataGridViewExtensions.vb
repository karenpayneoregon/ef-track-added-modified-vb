Imports System.Runtime.CompilerServices

Namespace LanguageExtensions

    Public Module DataGridViewExtensions
        <Extension>
        Public Sub ExpandColumns(ByVal sender As DataGridView)
            For Each column As DataGridViewColumn In sender.Columns
                ' ensure we are not attempting to do this on a Entity
                If column.ValueType IsNot Nothing AndAlso column.ValueType.Name <> "ICollection`1" Then
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next
        End Sub
        <Extension()>
        Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
            Dim result As Boolean = False
            If sender.EditType IsNot Nothing Then
                If sender.EditType Is GetType(DataGridViewComboBoxEditingControl) Then
                    result = True
                End If
            End If

            Return result

        End Function
    End Module
End Namespace