Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Core.Objects
Imports System.Data.Entity.Infrastructure
Imports System.Linq

Partial Public Class Context
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Context")
    End Sub

    Public Overridable Property People As DbSet(Of Person)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
    End Sub

    Public Overrides Function SaveChanges() As Integer
        ChangeTracker.DetectChanges()
        Dim test = ChangeTracker.Entries()
        Console.WriteLine(test.Count())

        Dim tester = ChangeTracker.Entries().Where(Function(item) item.State = EntityState.Added).Count()

        Return MyBase.SaveChanges()

    End Function
    Public ReadOnly Property ValidateChanges As List(Of ValidationResult)
        Get
            Dim changedEntities = ChangeTracker.Entries().Where(Function(underscore) underscore.State = EntityState.Added OrElse underscore.State = EntityState.Modified)

            Dim errors As List(Of ValidationResult) = New List(Of ValidationResult)()
            For Each e In changedEntities
                Dim vc = New ValidationContext(e.Entity, Nothing, Nothing)
                Validator.TryValidateObject(e.Entity, vc, errors, validateAllProperties:=True)
            Next

            Return errors

        End Get
    End Property



    Public Sub Review()

        ChangeTracker.DetectChanges()

        Dim originalValue = ""
        Dim currentValue = ""

        For Each currentEntry As DbEntityEntry In ChangeTracker.Entries()
            If currentEntry.State = EntityState.Added Then
                Console.WriteLine()
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

                        Console.WriteLine(
                            $"ID: {GetPrimaryKeyValue(currentEntry)} " &
                            $"Name {propertyName} " &
                            $"Original value: {currentEntry.OriginalValues(propertyName)} " &
                            $"Current value: {currentEntry.CurrentValues(propertyName)}")

                    End If
                Next
            ElseIf currentEntry.State = EntityState.Deleted Then
                Console.WriteLine("Got a person marked for deletion")
            End If
        Next

    End Sub
    Private Function GetPrimaryKeyValue(entry As DbEntityEntry) As Object

        Dim objectStateEntry = CType(Me, IObjectContextAdapter).
                ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity)

        Return objectStateEntry.EntityKey.EntityKeyValues(0).Value

    End Function
End Class
