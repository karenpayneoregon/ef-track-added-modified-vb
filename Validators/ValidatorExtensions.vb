﻿Imports System.ComponentModel.DataAnnotations
Imports System.Text
Imports System.Text.RegularExpressions

Public Module ValidatorExtensions
    <Runtime.CompilerServices.Extension>
    Public Function SplitCamelCase(sender As String) As String
        Return Regex.Replace(
            Regex.Replace(sender,
                          "(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), "(\p{Ll})(\P{Ll})", "$1 $2")
    End Function
    ''' <summary>
    ''' Separates tokens with a space e.g. ContactName 
    ''' becomes Contact Name
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension>
    Public Function SanitizedErrorMessage(sender As ValidationResult) As String
        Return Regex.Replace(sender.ErrorMessage.SplitCamelCase(), " {2,}", " ")
    End Function
    ''' <summary>
    ''' Place all validation messages into a string with 
    ''' each validation message on one line
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension>
    Public Function ErrorMessageList(sender As EntityValidationResult) As String

        Dim sb As New StringBuilder
        sb.AppendLine("Validation issues")

        For Each errorItem As ValidationResult In sender.Errors
            sb.AppendLine(errorItem.SanitizedErrorMessage)
        Next

        Return sb.ToString()

    End Function
    <Runtime.CompilerServices.Extension>
    Public Function ErrorItemList(sender As EntityValidationResult) As List(Of ErrorContainer)
        Dim itemList As New List(Of ErrorContainer)

        For Each errorItem As ValidationResult In sender.Errors
            itemList.Add(New ErrorContainer() With
                            {
                            .PropertyName = errorItem.MemberNames.FirstOrDefault(),
                            .ErrorMessage = errorItem.SanitizedErrorMessage
                            })
        Next

        Return itemList

    End Function
End Module