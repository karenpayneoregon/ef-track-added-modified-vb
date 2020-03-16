Imports System.ComponentModel
Imports BackEndRelational
Imports Equin.ApplicationFramework

''' <summary>
''' A Work in progress (but does work as is)
''' </summary>
Public Class Form1
    Private operations As New NorthWindOperations

    Private _customerView As BindingListView(Of CustomerEntity)
    WithEvents _customerBindingSource As New BindingSource

    Public Sub New()
        InitializeComponent()

        DataGridView1.AutoGenerateColumns = False

    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        _customerView = New BindingListView(Of CustomerEntity)(operations.AllCustomers())
        _customerBindingSource.DataSource = _customerView


        CountryColumn.DisplayMember = "CountryName"
        CountryColumn.ValueMember = "CountryIdentifier"
        CountryColumn.DataPropertyName = "CountryIdentifier"
        CountryColumn.DataSource = operations.CountryList()
        CountryColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        DataGridView1.DataSource = _customerBindingSource

    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Console.WriteLine(e.Exception.Message)
        e.Cancel = True
    End Sub

End Class


