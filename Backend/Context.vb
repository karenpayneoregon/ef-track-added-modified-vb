Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Infrastructure
Imports System.Linq

Partial Public Class Context
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Context")
    End Sub

    Public Overridable Property Contact1 As DbSet(Of Contact1)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
    End Sub
    ''' <summary>
    ''' Responsible for setting created and last updated information
    ''' prior to saving changes.
    ''' </summary>
    Private Sub SetTimestamps()

        Dim entities = ChangeTracker.Entries().
                Where(
                    Function(entityItem)
                        Return TypeOf entityItem.Entity Is BaseEntity AndAlso
                               (entityItem.State = EntityState.Added OrElse
                                entityItem.State = EntityState.Modified)
                    End Function)

        Dim currentUsername = Environment.UserName

        For Each currentEntry As DbEntityEntry In entities

            If currentEntry.State = EntityState.Added Then
                CType(currentEntry.Entity, BaseEntity).CreatedAt = Date.Now
                CType(currentEntry.Entity, BaseEntity).CreatedBy = currentUsername
            End If

            CType(currentEntry.Entity, BaseEntity).LastUpdated = Date.Now
            CType(currentEntry.Entity, BaseEntity).LastUser = currentUsername

        Next
    End Sub

    Public Overrides Function SaveChangesAsync() As Task(Of Integer)
        SetTimestamps()
        Return MyBase.SaveChangesAsync()
    End Function
End Class
