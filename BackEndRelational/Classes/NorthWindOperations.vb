
Imports System.Data.Entity

Public Class NorthWindOperations

    Private _NorthWindContext As NorthWindContext
    Public ReadOnly Property Context() As NorthWindContext
        Get
            Return _NorthWindContext
        End Get
    End Property

    Public Sub New()
        _NorthWindContext = New NorthWindContext()
    End Sub
    Public Function CountryList() As List(Of Country)
        Return _NorthWindContext.Countries.ToList()
    End Function
    Public Function ContactTypeList() As List(Of ContactType)
        Return _NorthWindContext.ContactTypes.ToList()
    End Function
    ''' <summary>
    ''' Read view/projection asynchronously, note the use
    ''' of inner ToListAsync which on larger operations can
    ''' accept a cancellation token yet there are less than
    ''' 90 records here so no need for a token.
    ''' </summary>
    ''' <returns></returns>
    Public Async Function AllCustomersAsync() As Task(Of List(Of CustomerEntity))

        Return Await Task.Run(
            Async Function()
                Dim customerItemsList As List(Of CustomerEntity) =
                        Await Context.Customers.Select(Customer.Projection).ToListAsync()
                Return customerItemsList.OrderBy(Function(customer) customer.CompanyName).ToList()
            End Function)

    End Function
    ''' <summary>
    ''' Get list using conventional joins synchronously
    ''' </summary>
    ''' <returns></returns>
    Public Function AllCustomers() As List(Of CustomerEntity)

        Dim customerData = (
                From customer In _NorthWindContext.Customers
                Join contactType In _NorthWindContext.ContactTypes On customer.ContactTypeIdentifier Equals contactType.ContactTypeIdentifier
                Join contact In _NorthWindContext.Contacts On customer.ContactIdentifier Equals contact.ContactIdentifier
                Select New CustomerEntity With {
                    .CustomerIdentifier = customer.CustomerIdentifier,
                    .CompanyName = customer.CompanyName,
                    .ContactIdentifier = customer.ContactIdentifier,
                    .FirstName = contact.FirstName,
                    .LastName = contact.LastName,
                    .ContactTypeIdentifier = contactType.ContactTypeIdentifier,
                    .ContactTitle = contactType.ContactTitle,
                    .Address = customer.Street,
                    .City = customer.City,
                    .PostalCode = customer.PostalCode,
                    .CountryIdentifier = customer.CountryIdentifier,
                    .CountryName = customer.Country.CountryName
                }).ToList()

        Return customerData

    End Function
    Public Function CustomerFirstOrDefault(customerIdentifier As Integer) As CustomerEntity

        Dim customerData = (
                From customer In _NorthWindContext.Customers
                Where customer.CustomerIdentifier = customerIdentifier
                Join contactType In _NorthWindContext.ContactTypes On customer.ContactTypeIdentifier Equals contactType.ContactTypeIdentifier
                Join contact In _NorthWindContext.Contacts On customer.ContactIdentifier Equals contact.ContactIdentifier
                Select New CustomerEntity With {
                .CustomerIdentifier = customer.CustomerIdentifier,
                .CompanyName = customer.CompanyName,
                .ContactIdentifier = customer.ContactIdentifier,
                .FirstName = contact.FirstName,
                .LastName = contact.LastName,
                .ContactTypeIdentifier = contactType.ContactTypeIdentifier,
                .ContactTitle = contactType.ContactTitle,
                .Address = customer.Street,
                .City = customer.City,
                .PostalCode = customer.PostalCode,
                .CountryIdentifier = customer.CountryIdentifier,
                .CountryName = customer.Country.CountryName
                }).FirstOrDefault()

        Return customerData

    End Function

End Class
