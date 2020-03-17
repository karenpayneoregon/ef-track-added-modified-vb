Imports System.Runtime.CompilerServices
Imports BackEndRelational
Imports Equin.ApplicationFramework

Public Module BindingSourceExtensions
    <Extension>
    Public Function CurrentCustomer(ByVal sender As SortableBindingList(Of CustomerEntity), postion As Integer) As CustomerEntity
        Return sender.Item(postion)
    End Function

End Module