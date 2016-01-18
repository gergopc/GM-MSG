Imports MySql.Data.MySqlClient

Public Class Register

    Dim dbCon As MySqlConnection
    Dim sqlCmd As MySqlCommand
    Dim DR As MySqlDataReader
    Dim strQuery As String
    Dim db_serverstring As String = getSQLStr()

    Private Function getSQLStr() As String
        Try
            Dim reader As IO.StreamReader = New IO.StreamReader("GMC.xyz")

            Return reader.ReadToEnd()

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
    End Function
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

        '        Try
        '            dbCon = New MySqlConnection(db_serverstring)
        '            strQuery = "SELECT code
        'FROM `sql4103243`.`master`;"
        '            sqlCmd = New MySqlCommand(strQuery, dbCon)
        '            dbCon.Open()
        '            DR = sqlCmd.ExecuteReader()

        '            While DR.Read
        '                Return DR.Item("code")
        '            End While

        '        Catch ex As Exception
        '            ShowError(ex.Message)
        '        End Try


    End Sub

    Private Sub ShowError(message As String, Optional ByVal title As String = "Error")

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class