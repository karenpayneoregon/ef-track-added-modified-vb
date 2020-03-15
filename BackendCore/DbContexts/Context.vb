Option Infer On

Imports System.Data.Entity.Infrastructure
Imports System.Text
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking

Partial Public Class Context
    Inherits DbContext

    Public Sub New()
    End Sub

    Public Sub New(ByVal options As DbContextOptions(Of Context))
        MyBase.New(options)
    End Sub

    Public Overridable Property Contacts() As DbSet(Of Contact)
    Public Overridable Property Contacts1() As DbSet(Of Contact1)
    Public Overridable Property People As DbSet(Of Person)

    Protected Overrides Sub OnConfiguring(ByVal optionsBuilder As DbContextOptionsBuilder)
        If Not optionsBuilder.IsConfigured Then
            Dim serverName = If(Environment.UserName = "Karens", "KARENS-PC", ".\SQLEXPRESS")

            Dim connectionString = $"Data Source={serverName};Initial Catalog=ShadowEntityCore;Integrated Security=True"
            optionsBuilder.UseSqlServer(connectionString)
        End If
    End Sub

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As ModelBuilder)
        modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687")

        modelBuilder.Entity(Of Contact)().Property(Of DateTime?)("LastUpdated")
        modelBuilder.Entity(Of Contact)().Property(Of String)("LastUser")

        modelBuilder.Entity(Of Contact1)().Property(Of DateTime?)("LastUpdated")
        modelBuilder.Entity(Of Contact1)().Property(Of String)("LastUser")
        modelBuilder.Entity(Of Contact1)().Property(Of DateTime?)("CreatedAt")
        modelBuilder.Entity(Of Contact1)().Property(Of String)("CreatedBy")
        modelBuilder.Entity(Of Contact1)().Property(Of Boolean)("isDeleted")


        modelBuilder.Entity(Of Contact)(Sub(entity)
                                            entity.HasKey(Function(e) e.ContactId)
                                        End Sub)

        modelBuilder.Entity(Of Contact1)(Sub(entity)
                                             entity.HasKey(Function(e) e.ContactId)
                                         End Sub)

        '            
        ' * Setup filter on Contact1 model to show only active records.
        ' * Since IsDeleted is not in the model the string name is used.
        '             
        modelBuilder.Entity(Of Contact1)().
            HasQueryFilter(Function(m) EF.Property(Of Boolean)(m, "isDeleted") = False)

        OnModelCreatingPartial(modelBuilder)

    End Sub
    ''' <summary>
    ''' Set shadow properties, soft delete
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function SaveChanges() As Integer
        BeforeSave()

        Return MyBase.SaveChanges()
    End Function
    ''' <summary>
    ''' User id is hard coded, for a real app this would
    ''' come from a table of authorized users.
    ''' </summary>
    Private Sub BeforeSave()

        ChangeTracker.DetectChanges()

        ' DbEntityEntry in EF6
        For Each currentEntry As EntityEntry In ChangeTracker.Entries()

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

        For Each currentEntry As EntityEntry In ChangeTracker.Entries()

            If currentEntry.State = EntityState.Added Then
                sb.AppendLine("New person")
            End If

            If currentEntry.State = EntityState.Modified Then
                For Each propertyName In currentEntry.CurrentValues.Properties

                    If currentEntry.OriginalValues(propertyName) IsNot Nothing Then
                        originalValue = currentEntry.OriginalValues(propertyName).ToString()
                    End If

                    If currentEntry.CurrentValues(propertyName) IsNot Nothing Then
                        currentValue = currentEntry.CurrentValues(propertyName).ToString()
                    End If

                    If originalValue <> currentValue Then

                        sb.AppendLine(
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

    Partial Private Sub OnModelCreatingPartial(ByVal modelBuilder As ModelBuilder)
    End Sub
End Class