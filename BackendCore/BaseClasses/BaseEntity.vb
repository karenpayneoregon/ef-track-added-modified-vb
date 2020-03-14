Public Class BaseEntity
    Public Property CreatedUtc() As DateTime?
    Public Property CreatorUserId() As Integer
    Public Property UpdatedUtc() As DateTime?
    Public Property UpdaterUserId() As Integer?
    Public Property IsDeleted As Boolean?
End Class