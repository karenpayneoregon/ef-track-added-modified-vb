Imports System.Runtime.CompilerServices

Namespace Helpers

    Public Module PersonExtensions
        <Extension>
        Public Sub CancelEdit(OriginalPerson As Person, RevertPerson As Person)
            OriginalPerson.FirstName = RevertPerson.FirstName
            OriginalPerson.LastName = RevertPerson.LastName
            OriginalPerson.BirthDate = RevertPerson.BirthDate
        End Sub
    End Module
End Namespace