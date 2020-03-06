Namespace Modules
    Public Module KarenDialogs
        Public Function Question(ByVal Text As String) As Boolean
            Return (MessageBox.Show(Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes)
        End Function

    End Module

End Namespace