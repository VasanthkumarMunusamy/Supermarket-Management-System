Imports System.Data.OleDb
Public Class CHANGE_PASSWORD
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        dataFile = "C:\Users\varun\Documents\Visual Studio 2012\Projects\Supermarket\Supermarket\DATABASE.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        str = "SELECT COUNT(*) FROM USERS" & " where [USERNAME] = ? and [PASSWORD] = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("USERNAME", CType(TextBox1.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("PASSWORD", CType(TextBox2.Text, String)))
        Dim check = cmd.ExecuteScalar()
        If check.ToString = "0" Then
            MsgBox("Invalid username or password", MsgBoxStyle.Critical)
            TextBox1.Text = ""
            TextBox2.Text = ""
        Else
            Dim str1 As String
            str1 = "update USERS set [PASSWORD]=?" & "WHERE [USERNAME]=?"
            Dim cmd1 As OleDbCommand = New OleDbCommand(str1, myConnection)
            cmd1.Parameters.Add(New OleDbParameter("PASSWORD", CType(TextBox3.Text, String)))
            cmd1.Parameters.Add(New OleDbParameter("USERNAME", CType(TextBox1.Text, String)))

            Try
                cmd1.ExecuteNonQuery()
                MsgBox("Password changed successfully", MsgBoxStyle.Information)
                cmd1.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Me.Hide()
            USER_LOGIN.Show()
        End If
        myConnection.Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        USER_LOGIN.Show()
    End Sub
End Class