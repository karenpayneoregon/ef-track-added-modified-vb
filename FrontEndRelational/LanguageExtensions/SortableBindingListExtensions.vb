Imports System.Runtime.CompilerServices
Imports BackEndRelational
Imports FrontEndRelational.Classes

Namespace LanguageExtensions
    ''' <summary>
    ''' Helpers to keep form code clean
    ''' </summary>
    Public Module SortableBindingListExtensions
        ''' <summary>
        ''' Wrapper to get current CustomerEntity by current position in a BindingSource attached to a DataGridView
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="postion"></param>
        ''' <returns></returns>
        <Extension>
        Public Function CurrentCustomer(sender As SortableBindingList(Of CustomerEntity), postion As Integer) As CustomerEntity
            Return sender.Item(postion)
        End Function
        ''' <summary>
        ''' Find CustomerEntity by company name
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="companyName"></param>
        ''' <returns>CustomerEntity if found in list or Nothing if not found in list</returns>
        ''' <remarks>
        ''' The BindingSource set to the SortableBindingList(Of CustomerEntity) does not support Find method
        ''' which means either modifying the SortableBindingList or have this extension method. Using
        ''' and extension method makes sense here than modify the SortableBindingList.
        ''' </remarks>
        <Extension>
        Public Function FindCompanyByName(sender As SortableBindingList(Of CustomerEntity), companyName As String) As CompanyItem

            Return sender.Select(Function(customerEntity, index) New CompanyItem With {.RowIndex = index, .Entity = customerEntity}).
                FirstOrDefault(Function(companyItem) companyItem.Entity.CompanyName = companyName)

        End Function
        ''' <summary>
        ''' Find CustomerEntity by contact first and last name
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="firstName">Contact first name</param>
        ''' <param name="lastName">Contact last name</param>
        ''' <returns>CustomerEntity if found in list or Nothing if not found in list</returns>
        ''' <remarks>
        ''' The BindingSource set to the SortableBindingList(Of CustomerEntity) does not support Find method
        ''' which means either modifying the SortableBindingList or have this extension method. Using
        ''' and extension method makes sense here than modify the SortableBindingList.
        ''' </remarks>
        <Extension>
        Public Function FindCompanyByContactName(
             sender As SortableBindingList(Of CustomerEntity),
             firstName As String,
             lastName As String) As CompanyItem

            Return sender.Select(
                Function(customerEntity, index)

                    Return New CompanyItem With {.RowIndex = index, .Entity = customerEntity}

                End Function).
                FirstOrDefault(
                    Function(companyItem)

                        Return companyItem.Entity.FirstName = firstName AndAlso companyItem.Entity.LastName = lastName

                    End Function)

        End Function
        ''' <summary>
        ''' Find first company name using starts with case insensitive 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="companyName"></param>
        ''' <returns></returns>
        <Extension()>
        Public Function FindCompanyByNameStartsWith(sender As SortableBindingList(Of CustomerEntity), companyName As String) As CompanyItem
            Return sender.Select(
                Function(customerEntity, index)

                    Return New CompanyItem With {.RowIndex = index, .Entity = customerEntity}

                End Function).
                FirstOrDefault(
                    Function(item)
                        Return item.Entity.CompanyName.StartsWith(companyName,
                                StringComparison.InvariantCultureIgnoreCase)
                    End Function)


        End Function
    End Module
End Namespace