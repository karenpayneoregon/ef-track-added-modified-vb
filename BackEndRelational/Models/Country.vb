Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Country
    Public Sub New()
        Customers = New HashSet(Of Customer)()
    End Sub

    Public Property id As Integer
    <NotMapped()>
    Public ReadOnly Property CountryIdentifier() As Integer
        Get
            Return id
        End Get
    End Property
    Public Property CountryName As String

    Public Overridable Property Customers As ICollection(Of Customer)
End Class
