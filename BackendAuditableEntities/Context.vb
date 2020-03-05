Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq
Imports EntityFramework.CommonTools

Partial Public Class Context
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Context")
    End Sub

    Public Overridable Property Contact2 As DbSet(Of Contact2)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
    End Sub
    Public Overloads Function SaveChanges(editorUserId As Integer) As Integer
        UpdateAuditableEntities(editorUserId)
        Return MyBase.SaveChanges()
    End Function

End Class
