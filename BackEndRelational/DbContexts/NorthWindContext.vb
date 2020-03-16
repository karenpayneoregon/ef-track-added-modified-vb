Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Infrastructure
Imports System.Linq

Partial Public Class NorthWindContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=NorthWindContext")
    End Sub

    Public Overridable Property Categories As DbSet(Of Category)
    Public Overridable Property Contacts As DbSet(Of Contact)
    Public Overridable Property ContactContactDevices As DbSet(Of ContactContactDevice)
    Public Overridable Property ContactTypes As DbSet(Of ContactType)
    Public Overridable Property Countries As DbSet(Of Country)
    Public Overridable Property Customers As DbSet(Of Customer)
    Public Overridable Property Employees As DbSet(Of Employee)
    Public Overridable Property OrderDetails As DbSet(Of OrderDetail)
    Public Overridable Property Orders As DbSet(Of Order)
    Public Overridable Property PhoneTypes As DbSet(Of PhoneType)
    Public Overridable Property Products As DbSet(Of Product)
    Public Overridable Property Shippers As DbSet(Of Shipper)
    Public Overridable Property Suppliers As DbSet(Of Supplier)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Country)().
            HasMany(Function(e) e.Customers).
            WithOptional(Function(e) e.Country).
            HasForeignKey(Function(e) e.CountryIdentifier)

        modelBuilder.Entity(Of Customer)().
            HasMany(Function(e) e.Orders).
            WithOptional(Function(e) e.Customer).
            WillCascadeOnDelete()

        modelBuilder.Entity(Of OrderDetail)().
            Property(Function(e) e.UnitPrice).
            HasPrecision(19, 4)

        modelBuilder.Entity(Of Order)().
            Property(Function(e) e.Freight).
            HasPrecision(19, 4)

        modelBuilder.Entity(Of Product)() _
            .Property(Function(e) e.UnitPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Product)() _
            .HasMany(Function(e) e.OrderDetails) _
            .WithRequired(Function(e) e.Product) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Shipper)() _
            .HasMany(Function(e) e.Orders) _
            .WithOptional(Function(e) e.Shipper) _
            .HasForeignKey(Function(e) e.ShipVia)
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

    Public Sub Detect()
        Dim test = DirectCast(Me, IObjectContextAdapter).
            ObjectContext.ObjectStateManager.
            GetObjectStateEntries(EntityState.Added).
            Where(Function(e) e.IsRelationship).Select(Function(r) New With {
                                                          Key .EntityKeyInfo = r.CurrentValues(0),
                                                          Key .CollectionMemberKeyInfo = r.CurrentValues(1),
                                                          Key r.State})



    End Sub
End Class
