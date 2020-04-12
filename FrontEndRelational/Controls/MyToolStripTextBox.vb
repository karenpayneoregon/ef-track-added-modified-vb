Imports System.Runtime.InteropServices

<ToolboxBitmap(GetType(ToolStripTextBox))>
Public Class MyToolStripTextBox
    Inherits ToolStripTextBox

    Private Const EM_SETCUEBANNER As Integer = &H1501
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As String) As Int32
    End Function
    Public Sub New()
        AddHandler Control.HandleCreated, AddressOf Control_HandleCreated
    End Sub
    Private Sub Control_HandleCreated(ByVal sender As Object, ByVal e As EventArgs)
        If Not String.IsNullOrEmpty(_cueBanner) Then
            UpdateCueBanner()
        End If
    End Sub
    Private _cueBanner As String
    Public Property CueBanner() As String
        Get
            Return _cueBanner
        End Get
        Set
            _cueBanner = Value
            UpdateCueBanner()
        End Set
    End Property
    Private Sub UpdateCueBanner()
        SendMessage(Control.Handle, EM_SETCUEBANNER, 0, _cueBanner)
    End Sub
End Class
