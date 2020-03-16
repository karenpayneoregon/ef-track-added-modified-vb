Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class OrderDetail
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property OrderID As Integer

    <Key>
    <Column(Order:=1)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ProductID As Integer

    <Column(TypeName:="money")>
    Public Property UnitPrice As Decimal

    Public Property Quantity As Integer

    Public Property Discount As Single

    Public Overridable Property Order As Order

    Public Overridable Property Product As Product
End Class
