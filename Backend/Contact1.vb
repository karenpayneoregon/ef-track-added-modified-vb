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
    <Key>
    Public Property ContactId As Integer

    Public Property FirstName As String

    Public Property LastName As String

    <Column(TypeName:="datetime2")>
    Public Overloads Property LastUpdated As Date?

    Public Overloads Property LastUser As String

    <Column(TypeName:="datetime2")>
    Public Overloads Property CreatedAt As Date?

    Public Overloads Property CreatedBy As String

    Public Property IsDeleted As Boolean?
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional memberName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(memberName))
    End Sub
End Class
