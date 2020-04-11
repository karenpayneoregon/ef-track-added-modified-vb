Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq.Expressions
Imports WindowsApp2.Classes

Partial Public Class Customer
    <NotMapped>
    Public Property FirstName As String
    <NotMapped>
    Public Property LastName As String
    Public Shared ReadOnly Property Projection() As Expression(Of Func(Of Customer, CustomerEntity))

        Get
            Return Function(customer) New CustomerEntity() With {
                .CustomerIdentifier = customer.CustomerIdentifier,
                .CompanyName = customer.CompanyName,
                .Street = customer.Street,
                .City = customer.City,
                .PostalCode = customer.PostalCode,
                .ContactTypeIdentifier = customer.ContactTypeIdentifier.Value,
                .ContactTitle = customer.ContactType.ContactTitle,
                .CountryName = customer.Country.CountryName,
                .FirstName = customer.Contact.FirstName,
                .LastName = customer.Contact.LastName,
                .ContactIdentifier = CInt(customer.ContactIdentifier),
                .CountryIdentifier = customer.CountryIdentifier}
        End Get

    End Property
End Class