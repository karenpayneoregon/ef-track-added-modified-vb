Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Data.Entity.Core.Objects

Partial Public Class Context
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ContextKaren") ' or secondary connection string
    End Sub
    Public Sub New(ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub

    Public Overridable Property Contact1 As DbSet(Of Contact1)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
    End Sub

    ''' <summary>
    ''' Responsible for setting created, last updated
    ''' and soft delete property before SaveChanges or SaveChangesAsync
    ''' 
    ''' 3/20/2020 altered logic to filter tractable that they must inherit
    ''' from BaseEntity so that if another model without the proper columns
    ''' does not throw a runtime exception.
    ''' </summary>
    Private Sub BeforeSave()

        ChangeTracker.DetectChanges()

        For Each currentEntry As DbEntityEntry In ChangeTracker.Entries()

            If currentEntry.State = EntityState.Added OrElse currentEntry.State = EntityState.Modified Then

                Dim entityType As Type = ObjectContext.GetObjectType(currentEntry.Entity.GetType())

                If entityType.IsSubclassOf(GetType(BaseEntity)) Then
                    currentEntry.Property("LastUpdated").CurrentValue = Date.Now
                    currentEntry.Property("LastUser").CurrentValue = Environment.UserName

                    If currentEntry.State = EntityState.Added Then
                        currentEntry.Property("CreatedAt").CurrentValue = Date.Now
                        currentEntry.Property("CreatedBy").CurrentValue = Environment.UserName
                    End If
                End If


            ElseIf currentEntry.State = EntityState.Deleted Then

                Dim entityType As Type = ObjectContext.GetObjectType(currentEntry.Entity.GetType())

                If entityType.IsSubclassOf(GetType(BaseEntity)) Then

                    currentEntry.Property("LastUpdated").CurrentValue = Date.Now
                    currentEntry.Property("LastUser").CurrentValue = Environment.UserName

                    ' Change state to modified and set delete flag
                    currentEntry.State = EntityState.Modified
                    CType(currentEntry.Entity, BaseEntity).IsDeleted = True

                End If


            End If

        Next

    End Sub
    ''' <summary>
    ''' Get primary key
    ''' In order to retrieve the primary keys, we must cast our DbContext down 
    ''' to IObjectContextAdapter and query the ObjectStateManager. Once we have access 
    ''' to that manager, we can get the primary key value (note that this method assumes 
    ''' a single-column primary key, which is not necessarily a good real-world scenario).
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <returns></returns>
    Private Function GetPrimaryKeyValue(entry As DbEntityEntry) As Object

        Dim objectStateEntry = CType(Me, IObjectContextAdapter).
                ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity)

        Return objectStateEntry.EntityKey.EntityKeyValues(0).Value

    End Function
    Public Sub Review()

        ChangeTracker.DetectChanges()

        For Each currentEntry As DbEntityEntry In ChangeTracker.Entries()
            If currentEntry.State = EntityState.Added OrElse currentEntry.State = EntityState.Modified Then
                For Each propertyName As String In currentEntry.CurrentValues.PropertyNames
                    If currentEntry.OriginalValues(propertyName).ToString() <> currentEntry.CurrentValues(propertyName).ToString() Then

                        Console.WriteLine(
                            $"ID: {GetPrimaryKeyValue(currentEntry)} " &
                            $"Name {propertyName} " &
                            $"Original value: {currentEntry.OriginalValues(propertyName)} " &
                            $"Current value: {currentEntry.CurrentValues(propertyName)}")

                    End If
                Next
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
