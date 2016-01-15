Public Class Main
    Private Sub SendEnter(sender As Object, e As KeyEventArgs) Handles SendBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            sendBTN.PerformClick()
        End If
    End Sub

End Class
