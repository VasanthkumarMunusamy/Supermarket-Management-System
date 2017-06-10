Imports System.Data.OleDb
Public Class CUSTOMER_DETAILS
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        dataFile = "C:\Users\varun\Documents\Visual Studio 2012\Projects\Supermarket\Supermarket\DATABASE.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        str = "Insert into CUSTOMER_DETAILS([NAME],[CONTACT_NO],[ADDRESS]) Values (?,?,?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("NAME", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("CONTACT_NO", CType(TextBox2.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("ADDRESS", CType(TextBox3.Text, String)))
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Me.Hide()
        ORDER_DETAILS.Show()
    End Sub

End Class
