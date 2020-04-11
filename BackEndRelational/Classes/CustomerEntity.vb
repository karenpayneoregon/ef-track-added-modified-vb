Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.CompilerServices

Public Class CustomerEntity
    Inherits BaseEntity
    Implements INotifyPropertyChanged

    Private _customerIdentifier1 As Integer
    Private _companyName1 As String
    Private _contactIdentifier1 As Integer?
    Private _firstName1 As String
    Private _lastName1 As String
    Private _contactTypeIdentifier1 As Integer
    Private _contactTitle1 As String
    Private _address1 As String
    Private _city1 As String
    Private _postalCode1 As String
    Private _countryIdentifier1 As Integer?
    Private _countyName1 As String

    Public Property CustomerIdentifier() As Integer
        Get
            Return _customerIdentifier1
        End Get
        Set
            _customerIdentifier1 = Value
            OnPropertyChanged()
        End Set
    End Property
    <Required>
    Public Property CompanyName() As String
        Get
            Return _companyName1
        End Get
        Set
            _companyName1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property ContactIdentifier() As Integer?
        Get
            Return _contactIdentifier1
        End Get
        Set
            _contactIdentifier1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _firstName1
        End Get
        Set
            _firstName1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _lastName1
        End Get
        Set
            _lastName1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public ReadOnly Property ContactName() As String
        Get
            Return $"{FirstName} {LastName}"
        End Get
    End Property

    Public Property ContactTypeIdentifier() As Integer
        Get
            Return _contactTypeIdentifier1
        End Get
        Set
            _contactTypeIdentifier1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property ContactTitle() As String
        Get
            Return _contactTitle1
        End Get
        Set
            _contactTitle1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Street() As String
        Get
            Return _address1
        End Get
        Set
            _address1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property City() As String
        Get
            Return _city1
        End Get
        Set
            _city1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property PostalCode() As String
        Get
            Return _postalCode1
        End Get
        Set
            _postalCode1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property CountryIdentifier() As Integer?
        Get
            Return _countryIdentifier1
        End Get
        Set
            _countryIdentifier1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property CountryName() As String
        Get
            Return _countyName1
        End Get
        Set
            _countyName1 = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional memberName As String = Nothing)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(memberName))

    End Sub

End Class
