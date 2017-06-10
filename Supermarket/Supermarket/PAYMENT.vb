Public Class PAYMENT

    Private Sub PAYMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.TextLength <> 16) Then
            MsgBox("INVALID CARD NUMBER", MsgBoxStyle.Critical)
            TextBox1.Text = ""

        ElseIf (TextBox3.TextLength <> 4) Then
            MsgBox("INVALID PIN", MsgBoxStyle.Critical)
            TextBox3.Text = ""
        ElseIf (ComboBox2.Text.ToString < Now.Year) Then

            MsgBox("Invalid validity", MsgBoxStyle.Critical)

        Else
            MsgBox("BOOKING SUCCESS", MsgBoxStyle.Information)
            TextBox1.Text = ""
            TextBox3.Text = ""
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            Me.Close()
            MsgBox("You have successfully made payment!", MsgBoxStyle.OkOnly)

        End If
    End Sub

End Class