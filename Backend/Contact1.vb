Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Runtime.CompilerServices

Partial Public Class Contact1
    Inherits BaseEntity
    Implements INotifyPropertyChanged

    Private _contactId As Integer
    Private _firstName As String
    Private _lastName As String
    Private _lastUpdated As Date?
    Private _createdAt As Date?
    Private _createdBy As String
    Private _isDeleted1 As Boolean

    <Key>
    Public Property ContactId As Integer
        Get
            Return _contactId
        End Get
        Set
            _contactId = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _firstName
        End Get
        Set
            _firstName = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set
            _lastName = Value
            OnPropertyChanged()
        End Set
    End Property

#Region "This are only needed for immediate updates in the user interface"
    <Column(TypeName:="datetime2")>
    Public Overloads Property LastUpdated As Date?
        Get
            Return _lastUpdated
        End Get
        Set
            _lastUpdated = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Overloads Property LastUser As String

    <Column(TypeName:="datetime2")>
    Public Overloads Property CreatedAt As Date?
        Get
            Return _createdAt
        End Get
        Set
            _createdAt = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Overloads Property CreatedBy As String
        Get
            Return _createdBy
        End Get
        Set
            _createdBy = Value
            OnPropertyChanged()
        End Set
    End Property
#End Region
    ''' <summary>
    ''' Provides a way to peek at properties
    ''' in debug mode
    ''' </summary>
    ''' <returns></returns>
    <NotMapped()>
    Public ReadOnly Property Display() As String
        Get

            Return _
            $"{FirstName},{LastName}{Environment.NewLine}" &
            $"Updated: {LastUpdated} " &
            $"by: {LastUser}{Environment.NewLine}" &
            $"Created: {CreatedAt} by: {CreatedBy}"

        End Get
    End Property
    ''' <summary>
    ''' Provides a default view
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Return $"{FirstName},{LastName}"
    End Function



#Region "INotifyPropertyChanged implementation"

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional memberName As String = Nothing)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(memberName))

    End Sub

#End Region
End Class
