Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("PhoneType")>
Partial Public Class PhoneType
    Public Sub New()
        ContactContactDevices = New HashSet(Of ContactContactDevice)()
    End Sub

    <Key>
    Public Property PhoneTypeIdenitfier As Integer

    Public Property PhoneTypeDescription As String

    Public Overridable Property ContactContactDevices As ICollection(Of ContactContactDevice)
End Class
