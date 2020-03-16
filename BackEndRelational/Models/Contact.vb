Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("Contact")>
Partial Public Class Contact
    Public Sub New()
        ContactContactDevices = New HashSet(Of ContactContactDevice)()
        Customers = New HashSet(Of Customer)()
    End Sub

    <Key>
    Public Property ContactIdentifier As Integer

    Public Property FirstName As String

    Public Property LastName As String

    Public Overridable Property ContactContactDevices As ICollection(Of ContactContactDevice)

    Public Overridable Property Customers As ICollection(Of Customer)
End Class
