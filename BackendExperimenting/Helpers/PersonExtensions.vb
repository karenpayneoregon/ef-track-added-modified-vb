Imports System.Data.Common
Imports System.Data.Entity
Imports System.Runtime.CompilerServices

Public Module PersonExtensions
    <Extension>
    Public Sub CancelEdit(OriginalPerson As Person, RevertPerson As Person)
        OriginalPerson.FirstName = RevertPerson.FirstName
        OriginalPerson.LastName = RevertPerson.LastName
        OriginalPerson.BirthDate = RevertPerson.BirthDate
    End Sub
End Module
