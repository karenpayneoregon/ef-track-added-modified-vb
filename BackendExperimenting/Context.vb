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

    Public Overridable Property People As DbSet(Of Person)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
    End Sub
    Public Overloads Function SaveChanges(NewPeople As List(Of Person)) As Integer

        If NewPeople.Count > 0 Then
            For Each person As Person In NewPeople
                Me.People.Add(person)
            Next
        End If

        Return MyBase.SaveChanges()

    End Function
    Public Sub Review()

        ChangeTracker.DetectChanges()
        Dim test = ChangeTracker.Entries()

        For Each currentEntry As DbEntityEntry In ChangeTracker.Entries()
            If currentEntry.State = EntityState.Added Then
                Console.WriteLine()
            End If
            If currentEntry.State = EntityState.Modified Then
                For Each propertyName As String In currentEntry.CurrentValues.PropertyNames

                    If currentEntry.OriginalValues(propertyName).ToString() <> currentEntry.CurrentValues(propertyName).ToString() Then

                        Console.WriteLine(
                            $"ID: {GetPrimaryKeyValue(currentEntry)} " &
                            $"Name {propertyName} " &
                            $"Original value: {currentEntry.OriginalValues(propertyName)} " &
                            $"Current value: {currentEntry.CurrentValues(propertyName)}")

                    End If
                Next
            ElseIf currentEntry.State = EntityState.Deleted Then
                Console.WriteLine()
            End If
        Next

    End Sub
    Private Function GetPrimaryKeyValue(entry As DbEntityEntry) As Object

        Dim objectStateEntry = CType(Me, IObjectContextAdapter).
                ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity)

        Return objectStateEntry.EntityKey.EntityKeyValues(0).Value

    End Function
End Class
