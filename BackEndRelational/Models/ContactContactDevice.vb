Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class ContactContactDevice
    <Key>
    Public Property Identifier As Integer

    Public Property ContactIdentifier As Integer?

    Public Property PhoneTypeIdenitfier As Integer?

    Public Property PhoneNumber As String

    Public Property Active As Boolean?

    Public Overridable Property Contact As Contact

    Public Overridable Property PhoneType As PhoneType
End Class
