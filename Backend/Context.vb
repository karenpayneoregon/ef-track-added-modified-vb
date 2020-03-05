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
    ''' Responsible for setting created, last updated
    ''' and soft delete property before SaveChanges or SaveChangesAsync
    ''' </summary>
    Private Sub BeforeSave()

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

                currentEntry.Property("LastUpdated").CurrentValue = Date.Now
                currentEntry.Property("LastUser").CurrentValue = Environment.UserName

                ' Change state to modified and set delete flag
                currentEntry.State = EntityState.Modified
                CType(currentEntry.Entity, BaseEntity).IsDeleted = True

            End If

        Next

    End Sub

    Public Overrides Function SaveChangesAsync() As Task(Of Integer)

        BeforeSave()
        Return MyBase.SaveChangesAsync()

    End Function

    Public Overrides Function SaveChanges() As Integer

        BeforeSave()
        Return MyBase.SaveChanges()

    End Function
    ''' <summary>
    ''' Simple method to filter out IsDeleted records 
    ''' </summary>
    ''' <typeparam name="TEntity"></typeparam>
    ''' <param name="query"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' This can be done in a generic method also,
    ''' keeping things simple here for starters.
    ''' </remarks>
    Public Function ApplyActiveFilter(Of TEntity As Contact1)(query As IQueryable(Of TEntity)) As IQueryable(Of TEntity)
        Return query.Where(Function(entity) entity.IsDeleted.Value = False)
    End Function

End Class
