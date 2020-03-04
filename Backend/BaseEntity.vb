Public Class BaseEntity
    Public Property CreatedAt() As Date?
    Public Property CreatedBy() As String
    Public Property LastUpdated() As Date?
    Public Property LastUser() As String
    Public Property IsDeleted As Boolean?
End Class