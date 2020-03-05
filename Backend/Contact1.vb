Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Runtime.CompilerServices
Imports System.Data.Entity.Spatial

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

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional memberName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(memberName))
    End Sub
End Class
