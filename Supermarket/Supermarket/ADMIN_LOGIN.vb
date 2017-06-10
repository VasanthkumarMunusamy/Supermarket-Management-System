Imports System.Data.OleDb
Public Class ADMIN_LOGIN
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub ADMIN_LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        dataFile = "C:\Users\varun\Documents\Visual Studio 2012\Projects\Supermarket\Supermarket\DATABASE.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        str = "SELECT COUNT(*) FROM ADMIN" & " where [USERNAME] = ? and [PASSWORD] = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("USERNAME", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("PASSWORD", CType(TextBox2.Text, String)))
        Dim check = cmd.ExecuteScalar()
        If check.ToString = "0" Then
            MsgBox("Invalid username or password", MsgBoxStyle.Critical)
            TextBox1.Text = ""
            TextBox2.Text = ""
        Else
            cmd.Dispose()
            myConnection.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            Me.Hide()
            ADD_ADMIN.Show()
        End If
        myConnection.Close()

    End Sub
End Class