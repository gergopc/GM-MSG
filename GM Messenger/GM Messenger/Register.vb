Imports MySql.Data

Public Class Register
    Private Sub CancelBTN_Click(sender As Object, e As EventArgs) Handles CancelBTN.Click
        Close()
        Main.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtPWD.Text = txtCfPWD.Text Then
            RegisterUser()
        Else
            ShowError("The passwords aren't the same")
        End If
    End Sub

    Private Sub RegisterUser()

    End Sub

    Private Sub ShowError(message As String, Optional ByVal title As String = "Error")

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class