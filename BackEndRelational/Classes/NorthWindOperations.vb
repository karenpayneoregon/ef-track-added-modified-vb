
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

End Class
