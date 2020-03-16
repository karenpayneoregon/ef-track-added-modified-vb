Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Product
    Public Sub New()
        OrderDetails = New HashSet(Of OrderDetail)()
    End Sub

    Public Property ProductID As Integer

    <Required>
    <StringLength(40)>
    Public Property ProductName As String

    Public Property SupplierID As Integer?

    Public Property CategoryID As Integer?

    <StringLength(20)>
    Public Property QuantityPerUnit As String

    <Column(TypeName:="money")>
    Public Property UnitPrice As Decimal?

    Public Property UnitsInStock As Short?

    Public Property UnitsOnOrder As Short?

    Public Property ReorderLevel As Short?

    Public Property Discontinued As Boolean

    <Column(TypeName:="datetime2")>
    Public Property DiscontinuedDate As Date?

    Public Overridable Property Category As Category

    Public Overridable Property OrderDetails As ICollection(Of OrderDetail)

    Public Overridable Property Supplier As Supplier
End Class
