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

    Protected Overrides Sub OnModelCreating(ByVal Builder As DbModelBuilder)


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

        Console.WriteLine(entities.Count())
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
    ''' <summary>
    ''' For any entity that is marked for deletion set it's
    ''' state to modified and set the IsDelete property to true
    ''' </summary>
    Private Sub PrepareDeleted()

        For Each EntryItem In ChangeTracker.Entries()
            If EntryItem.State = EntityState.Deleted Then
                EntryItem.State = EntityState.Modified
                'CType(EntryItem.Entity, BaseEntity).IsDeleted = True
            End If
        Next

    End Sub
    Public Overrides Function SaveChangesAsync() As Task(Of Integer)
        ChangeTracker.DetectChanges()
        SetTimestamps()
        PrepareDeleted()

        Return MyBase.SaveChangesAsync()

    End Function

    Public Overrides Function SaveChanges() As Integer
        ChangeTracker.DetectChanges()

        For Each currentEntry As DbEntityEntry In ChangeTracker.Entries()

            If currentEntry.State = EntityState.Added OrElse currentEntry.State = EntityState.Modified Then
                currentEntry.Property("LastUpdated").CurrentValue = Date.Now
                currentEntry.Property("LastUser").CurrentValue = Environment.UserName

                If TypeOf currentEntry.Entity Is Contact1 AndAlso currentEntry.State = EntityState.Added Then
                    currentEntry.Property("CreatedAt").CurrentValue = Date.Now
                    currentEntry.Property("CreatedBy").CurrentValue = Environment.UserName
                End If
            ElseIf currentEntry.State = EntityState.Deleted Then
                ' Change state to modified and set delete flag
                currentEntry.State = EntityState.Modified
                CType(currentEntry.Entity, BaseEntity).IsDeleted = True
            End If

        Next

        Return MyBase.SaveChanges()

    End Function
    Public Function ApplyActiveFilter(Of TEntity As Contact1)(query As IQueryable(Of TEntity)) As IQueryable(Of TEntity)
        Return query.Where(Function(entity) entity.IsDeleted.Value = False)
    End Function

End Class
