Public Class ErrorContainer
    Public Property PropertyName() As String
    Public Property ErrorMessage() As String

    Public Overrides Function ToString() As String
        Return $"[{PropertyName}] : [{ErrorMessage}]"
    End Function
End Class