Imports System.Data.OleDb

Public Class SIGNUP
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
        str = "Insert into USERS([USERNAME],[PASSWORD]) Values (?,?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("USERNAME", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("PASSWORD", CType(TextBox2.Text, String)))
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Me.Hide()
        USER_LOGIN.Show()
    End Sub

End Class