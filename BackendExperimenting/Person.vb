Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports System.Runtime.CompilerServices

<Table("Person")>
Partial Public Class Person
    Inherits BaseEntity
    Implements INotifyPropertyChanged

    Private _Id As Integer
    Private _FirstName As String
    Private _LastName As String
    Private _BirthDate As DateTime?
    Private _updatedUtc As DateTime?

    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set
            _Id = Value
            OnPropertyChanged()
        End Set
    End Property
    <Required>
    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set
            _FirstName = Value
            OnPropertyChanged()
        End Set
    End Property
    <Required>
    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set
            _LastName = Value
            OnPropertyChanged()
        End Set
    End Property

    <Column(TypeName:="date")>
    Public Property BirthDate As Date?
        Get
            Return _BirthDate
        End Get
        Set
            _BirthDate = Value
            OnPropertyChanged()
        End Set
    End Property
    '<NotMapped>
    Public Property UpdatedUtc() As DateTime?
        Get
            Return _updatedUtc
        End Get
        Set
            _updatedUtc = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName}"
    End Function


#Region "INotifyPropertyChanged implementation"

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional memberName As String = Nothing)

        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(memberName))

    End Sub

#End Region
End Class
