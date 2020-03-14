Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Core.Objects
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Text
Imports Backend

Partial Public Class Context
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Context")
    End Sub

    Public Overridable Property People As DbSet(Of Person)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
    End Sub

    Public Overrides Function SaveChanges() As Integer
        'ChangeTracker.DetectChanges()

        BeforeSave()

        Return MyBase.SaveChanges()

    End Function
    ''' <summary>
    ''' Provides validation via data annotations 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ValidateChanges As List(Of ValidationResult)
        Get

            Dim changedEntities =
                    ChangeTracker.Entries().
                    Where(Function(underscore) underscore.State = EntityState.Added OrElse
                                               underscore.State = EntityState.Modified)

            Dim errors As List(Of ValidationResult) = New List(Of ValidationResult)()

            For Each e In changedEntities
                Dim vc = New ValidationContext(e.Entity, Nothing, Nothing)
                Validator.TryValidateObject(e.Entity, vc, errors, validateAllProperties:=True)
            Next

            Return errors

        End Get
    End Property
    ''' <summary>
    ''' Responsible for setting created, last updated
    ''' and soft delete property before SaveChanges or SaveChangesAsync
    ''' </summary>
    Private Sub BeforeSave()

        ChangeTracker.DetectChanges()

        For Each currentEntry As DbEntityEntry In ChangeTracker.Entries()

            If currentEntry.State = EntityState.Added OrElse currentEntry.State = EntityState.Modified Then

                currentEntry.Property("UpdatedUtc").CurrentValue = Date.Now
                currentEntry.Property("UpdaterUserId").CurrentValue = 5

                If TypeOf currentEntry.Entity Is Person AndAlso currentEntry.State = EntityState.Added Then
                    currentEntry.Property("CreatedAt").CurrentValue = Date.Now
                    currentEntry.Property("CreatedBy").CurrentValue = Environment.UserName
                End If

            ElseIf currentEntry.State = EntityState.Deleted Then

                currentEntry.Property("UpdatedUtc").CurrentValue = Date.Now
                currentEntry.Property("UpdaterUserId").CurrentValue = 1

                currentEntry.State = EntityState.Modified
                CType(currentEntry.Entity, BaseEntity).IsDeleted = True

            End If

        Next

    End Sub
    ''' <summary>
    ''' Helper for developers to inspect what changes there are currently
    ''' </summary>
    ''' <returns></returns>
    Public Function Review() As String
        Dim sb As New StringBuilder

        ChangeTracker.DetectChanges()

        Dim originalValue = ""
        Dim currentValue = ""

        For Each currentEntry As DbEntityEntry In ChangeTracker.Entries()

            If currentEntry.State = EntityState.Added Then
                sb.AppendLine("New person")
            End If

            If currentEntry.State = EntityState.Modified Then
                For Each propertyName As String In currentEntry.CurrentValues.PropertyNames

                    If currentEntry.OriginalValues(propertyName) IsNot Nothing Then
                        originalValue = currentEntry.OriginalValues(propertyName).ToString()
                    End If

                    If currentEntry.CurrentValues(propertyName) IsNot Nothing Then
                        currentValue = currentEntry.CurrentValues(propertyName).ToString()
                    End If

                    If originalValue <> currentValue Then

                        sb.AppendLine(
                            $"ID: {GetPrimaryKeyValue(currentEntry)} " &
                            $"Name {propertyName} " &
                            $"Original value: {currentEntry.OriginalValues(propertyName)} " &
                            $"Current value: {currentEntry.CurrentValues(propertyName)}")

                    End If
                Next
            ElseIf currentEntry.State = EntityState.Deleted Then
                sb.AppendLine("Got a person marked for deletion")
            End If
        Next

        If sb.Length = 0 Then
            Return "No changes"
        Else
            Return sb.ToString()
        End If

    End Function
    ''' <summary>
    ''' Get primary key for modified entity, do not use for added entities.
    ''' </summary>
    ''' <param name="entry"></param>
    ''' <returns></returns>
    Private Function GetPrimaryKeyValue(entry As DbEntityEntry) As Object

        Dim objectStateEntry = CType(Me, IObjectContextAdapter).
                ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity)

        Return objectStateEntry.EntityKey.EntityKeyValues(0).Value

    End Function
End Class
