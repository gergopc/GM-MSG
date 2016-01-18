Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Main


    Dim Credentials(2) As String

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

    Private Sub getCredentials()
        Try
            dbCon = New MySqlConnection(db_serverstring)
            strQuery = "SELECT username
FROM `sql4103243`.`users` WHERE apikey='" + My.Settings.apikey + "';"
            sqlCmd = New MySqlCommand(strQuery, dbCon)
            dbCon.Open()
            DR = sqlCmd.ExecuteReader()

            While DR.Read
                Credentials(0) = DR.Item("username")
            End While


        Catch ex As Exception
            ShowError("Error getting username: " + ex.Message)
        End Try
        Try
            dbCon = New MySqlConnection(db_serverstring)
            strQuery = "SELECT password
FROM `sql4103243`.`users` WHERE apikey='" + My.Settings.apikey + "';"
            sqlCmd = New MySqlCommand(strQuery, dbCon)
            dbCon.Open()
            DR = sqlCmd.ExecuteReader()

            While DR.Read
                Credentials(1) = DR.Item("password")
            End While


        Catch ex As Exception
            ShowError("Error getting password: " + ex.Message)
        End Try
        Try
            dbCon = New MySqlConnection(db_serverstring)
            strQuery = "SELECT becenev
FROM `sql4103243`.`users` WHERE apikey='" + My.Settings.apikey + "';"
            sqlCmd = New MySqlCommand(strQuery, dbCon)
            dbCon.Open()
            DR = sqlCmd.ExecuteReader()

            While DR.Read
                Credentials(2) = DR.Item("becenev")
            End While


        Catch ex As Exception
            ShowError("Error getting alternative name: " + ex.Message)
        End Try
    End Sub

    Private Sub ShowError(message As String, Optional ByVal title As String = "Error")

        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub SendEnter(sender As Object, e As KeyEventArgs) Handles SendBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            sendBTN.PerformClick()
        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCredentials()

        If My.Settings.apikey = Nothing Then
            My.Settings.apikey = generateApikey()
        End If

        If Authorized() = False Then
            Dim mastercode As String = InputBox("Please type the master code!", "Enter mastercode")


            If Not CheckMasterCode(mastercode) = True Then
                ShowError("You aren't permitted to use this messenger!", "You aren't permitted")
                Close()
            Else
                Authorize()
            End If
        Else
            Login()
        End If

    End Sub

    Private Sub Login()
        Dim result As DialogResult = LoginForm1.ShowDialog()
        If result = DialogResult.OK Then
            If Not My.Settings.username = Credentials(0) And Not My.Settings.password = Credentials(1) Then
                Close()
            End If
        Else
                Close()
        End If
    End Sub

    Private Sub Authorize()

        Try
            dbCon = New MySqlConnection(db_serverstring)
            strQuery = "INSERT INTO `sql4103243`.`users` (`apikey`) VALUES ('" + My.Settings.apikey + "');"
            sqlCmd = New MySqlCommand(strQuery, dbCon)
            dbCon.Open()
            sqlCmd.ExecuteNonQuery()
            dbCon.Close()

        Catch ex As Exception
            ShowError(ex.Message)
        End Try

        Register.ShowDialog()
    End Sub

    Private Function CheckMasterCode(mastercode As String) As Boolean


        If mastercode = Nothing Then
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
            strQuery = "SELECT code
FROM `sql4103243`.`master`;"
            sqlCmd = New MySqlCommand(strQuery, dbCon)
            dbCon.Open()
            DR = sqlCmd.ExecuteReader()

            While DR.Read
                Return DR.Item("code")
            End While

        Catch ex As Exception
            ShowError(ex.Message)
        End Try

    End Function
    Private Function Authorized() As Boolean
        Try
            dbCon = New MySqlConnection(db_serverstring)
            strQuery = "SELECT username
FROM `sql4103243`.`users` WHERE apikey='" + My.Settings.apikey + "';"
            sqlCmd = New MySqlCommand(strQuery, dbCon)
            dbCon.Open()
            DR = sqlCmd.ExecuteReader()

            If DR.HasRows Then
                Return True
            Else Return False
            End If

        Catch ex As Exception
            ShowError(ex.Message)
        End Try
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

    Private Sub sendBTN_Click(sender As Object, e As EventArgs) Handles sendBTN.Click
        SendBox.Clear()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.username = Nothing
        My.Settings.password = Nothing
        My.Settings.alternative_name = Nothing

    End Sub
End Class
