Imports BackendExperimenting
Imports Equin.ApplicationFramework

Public Class FilterBirthDateForm
    Private _customerView As BindingListView(Of Person)
    Public Sub New(customerView As BindingListView(Of Person))
        InitializeComponent()

        _customerView = customerView

    End Sub
    Private Sub ApplyFilterButton_Click(sender As Object, e As EventArgs) Handles ApplyFilterButton.Click
        _customerView.ApplyFilter(Function(person) person.BirthDate.Value > DateTimePicker1.Value)
    End Sub
    Private Sub RemoveFilterButton_Click(sender As Object, e As EventArgs) Handles RemoveFilterButton.Click
        _customerView.Filter = Nothing
    End Sub
End Class