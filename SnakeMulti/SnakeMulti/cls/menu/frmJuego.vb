Public Class frmJuego

    Private thread As Threading.Thread

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btn1Jugador.Click
        Dim thread As Threading.Thread
        thread = New Threading.Thread(AddressOf Me.run1)
        thread.Start()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btn2Jugador.Click


        thread = New Threading.Thread(AddressOf Me.run2)
        thread.Start()


    End Sub

    Private Sub run1()
        Using game As New Game1(1)
            game.Run()
        End Using
    End Sub

    Private Sub run2()
        Using game As New Game1(2)
            game.Run()
        End Using
    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        If thread IsNot Nothing Then
            thread.Abort()
        End If
        Me.Close()
    End Sub
End Class