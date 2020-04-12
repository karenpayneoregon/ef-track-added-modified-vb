Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace LanguageExtensions

    Public Module CueBannerTextCodeExtensions
        Public Enum WaterMark
            ' Hide cue text when entering control
            Hide = 0
            ' Show cue text when entering control until user begins to type
            Show = 1
        End Enum
        <DllImport("user32.dll", CharSet:=CharSet.Auto)>
        Private Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> lParam As String) As Int32
        End Function

        <DllImport("user32", EntryPoint:="FindWindowExA", ExactSpelling:=True, CharSet:=CharSet.Ansi, SetLastError:=True)>
        Private Function FindWindowEx(hWnd1 As IntPtr, hWnd2 As IntPtr, lpsz1 As String, lpsz2 As String) As IntPtr
        End Function
        Private Const EM_SETCUEBANNER As Integer = &H1501
        ''' <summary>
        ''' Used to place shadow text into a TextBox or ComboBox when control does not have focus
        ''' </summary>
        ''' <param name="pControl">Name of control</param>
        ''' <param name="pText">Shadow text to show when control does not have focus</param>
        ''' <remarks>
        ''' Some might call this a watermark affect
        ''' </remarks>
        <Extension>
        Public Sub SetCueText(pControl As Control, pText As String)

            If TypeOf pControl Is ComboBox Then
                Dim editHWnd = FindWindowEx(pControl.Handle, IntPtr.Zero, "Edit", Nothing)
                If Not editHWnd = IntPtr.Zero Then
                    SendMessage(editHWnd, EM_SETCUEBANNER, 0, pText)
                End If
            ElseIf TypeOf pControl Is TextBox Then
                SendMessage(pControl.Handle, EM_SETCUEBANNER, 0, pText)
            End If
        End Sub

        ''' <summary>
        ''' Used to place shadow text into a TextBox or ComboBox when control does not have focus
        ''' </summary>
        ''' <param name="pControl">Name of control</param>
        ''' <param name="pText">Shadow text to show when control does not have focus</param>
        ''' <param name="pValue">show water mark upon entering control or not</param>
        ''' <remarks>
        ''' Some might call this a watermark affect
        ''' </remarks>
        <Extension>
        Public Sub SetCueText(pControl As Control, pText As String, pValue As WaterMark)

            If TypeOf pControl Is ComboBox Then
                Dim editHWnd As IntPtr = FindWindowEx(pControl.Handle, IntPtr.Zero, "Edit", Nothing)
                If Not (editHWnd = IntPtr.Zero) Then
                    SendMessage(editHWnd, EM_SETCUEBANNER, Fix(pValue), pText)
                End If
            ElseIf TypeOf pControl Is TextBox Then
                SendMessage(pControl.Handle, EM_SETCUEBANNER, Fix(pValue), pText)
            End If
        End Sub
    End Module
End Namespace