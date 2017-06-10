Imports System.Data.OleDb
Public Class ORDER_DETAILS
    Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\varun\Documents\Visual Studio 2012\Projects\Supermarket\Supermarket\DATABASE.accdb"
    Dim myConnection As OleDbConnection
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim tables As DataTableCollection
        Dim source1 As New BindingSource

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        myConnection = New OleDbConnection
        myConnection.ConnectionString = connString
        ds = New DataSet
        tables = ds.Tables
        da = New OleDbDataAdapter("Select * from [PROD_DETAILS]", myConnection)
        da.Fill(ds, "PROD_DETAILS")
        Dim view As New DataView(tables(0))
        source1.DataSource = view
        DataGridView1.DataSource = view
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        PLACE_ORDER.Show()
    End Sub
End Class