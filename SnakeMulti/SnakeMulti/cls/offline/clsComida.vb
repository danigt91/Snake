Public Class clsComida


    Private _contenedor As clsContenedorSnake
    Private _posicion As Point
    Private _color As Color
    Private _puntos As Integer
    Private _tiempoCambio As Integer

    Public _spriteComida As Texture2D
    Public nombreSprite As String = "apple"

    Private Shared rand As Random = New Random

    Public thread As Threading.Thread


    Public Sub New(contenedor As clsContenedorSnake)

        _contenedor = contenedor
        _posicion = generarPosicion()
        _puntos = 1
        _tiempoCambio = 5000

        thread = New Threading.Thread(AddressOf Me.run)

        thread.Start()

    End Sub


    'Método que genera un punto en una posicion aleatoria y no ocupada
    Public Function generarPosicion() As Point

        Dim resPosicion As Point = Nothing
        Dim coincide As Boolean = False

        Do

            Dim xInteger As Integer = rand.Next(0, CInt(_contenedor.numRejillasX / _contenedor.tamanioObjetos)) * _contenedor.tamanioObjetos
            Dim yInteger As Integer = rand.Next(0, CInt(_contenedor.numRejillasY / _contenedor.tamanioObjetos)) * _contenedor.tamanioObjetos
            'Genera una posicion aleatoria
            resPosicion = New Point(xInteger, yInteger)

            For i As Integer = 0 To _contenedor.serpientes.Count - 1
                coincide = _contenedor.serpientes.Item(i).posiciones.Contains(resPosicion)
                If coincide Then
                    i = _contenedor.serpientes.Count
                End If
            Next

            Dim comidasAux As New List(Of clsComida)(_contenedor.comidas)
            comidasAux.Remove(Me)
            For i As Integer = 0 To comidasAux.Count - 1
                coincide = comidasAux.Item(i).posicion.Equals(resPosicion)
                If coincide Then
                    i = comidasAux.Count
                End If
            Next

        Loop While coincide

        Return resPosicion

    End Function


    Private Sub run()
        While (True)

            Threading.Thread.Sleep(_tiempoCambio)
            posicion = generarPosicion()

        End While
    End Sub

    Public Sub parar()
        If thread IsNot Nothing Then
            thread.Abort()
            Me.Finalize()
        End If
    End Sub



    Public Sub cargarSpritesComida(Game As Game1, nombre As String)
        _spriteComida = Game.Content.Load(Of Texture2D)(nombre)
    End Sub

    Public Sub pintarComida(spriteBatch As SpriteBatch)

        Dim pos As Rectangle = New Rectangle(posicion.X, posicion.Y, _contenedor.tamanioRejilla * _contenedor.tamanioObjetos, _contenedor.tamanioRejilla * _contenedor.tamanioObjetos)
        spriteBatch.Draw(_spriteComida, pos, Color.White)

    End Sub


    Public Property posicion() As Point
        Get
            Return _posicion
        End Get
        Set(value As Point)
            _posicion = value
        End Set
    End Property

    Public Property puntos() As Integer
        Get
            Return _puntos
        End Get
        Set(value As Integer)
            _puntos = value
        End Set
    End Property




End Class
