Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Runtime.CompilerServices


<Table("Contact")>
Partial Public Class Contact
    Implements INotifyPropertyChanged

    Private _contactId As Integer
    Private _firstName As String
    Private _lastName As String
    Private _lastUpdated? As DateTime
    Private _lastUser As String

    Public Property ContactId() As Integer
        Get
            Return _contactId
        End Get
        Set(ByVal value As Integer)
            _contactId = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
            OnPropertyChanged()
        End Set
    End Property

#Region "Not needed for shadow properties only for displaying in DataGridView"
    Public Property LastUpdated() As DateTime?
        Get
            Return _lastUpdated
        End Get
        Set(ByVal value? As DateTime)
            _lastUpdated = value
            OnPropertyChanged()
        End Set
    End Property

    Public Property LastUser() As String
        Get
            Return _lastUser
        End Get
        Set(ByVal value As String)
            _lastUser = value
            OnPropertyChanged()
        End Set
    End Property
#End Region

    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName}"
    End Function

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional ByVal propertyName As String = Nothing)
        PropertyChangedEvent?.Invoke(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class