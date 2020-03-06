Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports EntityFramework.CommonTools

Partial Public Class Contact2
    Implements IFullAuditable(Of Integer)

    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property CreatedUtc As Date Implements ICreationTrackable.CreatedUtc
    Public Property UpdatedUtc As Date? Implements IModificationTrackable.UpdatedUtc
    Public Property IsDeleted As Boolean Implements ISoftDeletable.IsDeleted
    Public Property DeletedUtc As Date? Implements IDeletionTrackable.DeletedUtc
    Public Property CreatorUserId As Integer Implements ICreationAuditable(Of Integer).CreatorUserId
    Public Property UpdaterUserId As Integer? Implements IModificationAuditable(Of Integer).UpdaterUserId
    Public Property DeleterUserId As Integer? Implements IDeletionAuditable(Of Integer).DeleterUserId
End Class
