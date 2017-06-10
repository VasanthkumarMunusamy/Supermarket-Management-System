Imports System.Data.OleDb
Public Class PLACE_ORDER

    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim value As Integer
    Public myConnection As OleDbConnection = New OleDbConnection
    Public dr As OleDbDataReader


    Private Sub PLACE_ORDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        dataFile = "C:\Users\varun\Documents\Visual Studio 2012\Projects\Supermarket\Supermarket\DATABASE.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        TextBox2.Clear()
        TextBox3.Clear()
        Dim str As String
        str = "SELECT * FROM PROD_DETAILS WHERE (PRODUCT_NAME = '" & TextBox1.Text & "')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox2.Text = dr("PRODUCT_NAME").ToString
            value = dr("PRICE/KG").ToString
        End While
        TextBox3.Text = value * TextBox4.Text
        myConnection.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        ORDER_DETAILS.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        dataFile = "C:\Users\varun\Documents\Visual Studio 2012\Projects\Supermarket\Supermarket\DATABASE.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        str = "Insert into ORDER_DETAILS([CUSTOMER_NAME],[PRODUCT_NAME],[COST]) Values (?,?,?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("CUSTOMER_NAME", CType(TextBox5.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("PRODUCT_NAME", CType(TextBox2.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("COST", CType(TextBox3.Text, String)))
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox5.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Me.Hide()
        PAYMENT.Show()
    End Sub

End Class