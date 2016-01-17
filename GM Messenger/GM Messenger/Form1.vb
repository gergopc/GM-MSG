Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Main

    Dim db_serverstring As String = "Server=" + My.Settings.db_host + ";User Id=" + My.Settings.db_user + ";Password=" + My.Settings.db_pwd + ";Database=" + My.Settings.db_db
    Dim dbCon As MySqlConnection
    Dim sqlCmd As MySqlCommand
    Dim DR As MySqlDataReader
    Dim strQuery As String

    Private Sub SendEnter(sender As Object, e As KeyEventArgs) Handles SendBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            sendBTN.PerformClick()
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.apikey = Nothing Then
            My.Settings.apikey = generateApikey()
        End If

        If Authorized() = False Then
            Dim mastercode As String = InputBox("Please type the master code!", "Enter mastercode")


            If Not CheckMasterCode(mastercode) = True Then
                MessageBox.Show("You aren't permitted to use this messenger!", "You aren't permitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            Else
                Authorize()
            End If
        End If

    End Sub

    Private Sub Authorize()

    End Sub

    Private Function CheckMasterCode(mastercode As String) As Boolean
        If mastercode = "apk123" Then
            MessageBox.Show(My.Settings.apikey)
        ElseIf mastercode = "gk456" Then
            MessageBox.Show(getMasterCode)
        ElseIf mastercode = Nothing Then
            Return False
            Stop
        ElseIf mastercode = getMasterCode() And mastercode IsNot Nothing Then
            Return True
        Else
            Return False

        End If
    End Function

    Private Function getMasterCode() As String
        Try
            dbCon = New MySqlConnection(db_serverstring)
            strQuery = "SELECT users.code" &
                "FROM master"
            sqlCmd = New MySqlCommand(strQuery, dbCon)
            dbCon.Open()
            DR = sqlCmd.ExecuteReader()

            While DR.Read
                Return DR.Item("code")
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Function Authorized() As Boolean

    End Function

    Private Function generateApikey() As String

        Dim s As String = " ThenABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()


    End Function
End Class
