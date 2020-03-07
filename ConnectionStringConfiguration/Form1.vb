Imports System.Configuration
Imports System.Data.SqlClient

Public Class Form1
    Private Sub ViewButton_Click(sender As Object, e As EventArgs) Handles ViewButton.Click
        Dim builder As New SqlConnectionStringBuilder(GetConnectionString())
        If builder.DataSource = ".\SQLEXPRESS" Then
            builder.DataSource = "KARENS-PC"
        Else
            builder.DataSource = ".\SQLEXPRESS"
        End If

        ChangeConnectionString(builder.ConnectionString)
    End Sub
    Private Function GetConnectionString() As String
        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Return config.ConnectionStrings.ConnectionStrings("Context").ConnectionString
    End Function
    Private Sub ChangeConnectionString(connectionString As String)
        Dim config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        config.ConnectionStrings.ConnectionStrings("Context").ConnectionString = connectionString
        config.Save(ConfigurationSaveMode.Modified, True)
        ConfigurationManager.RefreshSection("connectionStrings")
    End Sub
End Class
