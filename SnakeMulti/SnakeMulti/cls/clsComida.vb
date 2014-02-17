Public Class clsComida


    Private _contenedor As clsContenedorSnake
    Private _posicion As Point
    Private _color As Color

    Public Shared _spriteComida As Texture2D


    Public Sub New(contenedor As clsContenedorSnake)

        _contenedor = contenedor
        _posicion = generarPosicion()

    End Sub


    'Método que genera un punto en una posicion aleatoria y no ocupada
    Public Function generarPosicion() As Point

        Dim resPosicion As Point = Nothing
        Dim coincide As Boolean = False

        Do

            Dim rand As New Random
            Dim xInteger As Integer = rand.Next(0, CInt(_contenedor.numRejillasX / _contenedor.tamanioObjetos)) * _contenedor.tamanioObjetos
            Dim yInteger As Integer = rand.Next(0, CInt(_contenedor.numRejillasY / _contenedor.tamanioObjetos)) * _contenedor.tamanioObjetos
            'Genera una posicion aleatoria
            resPosicion = New Point(xInteger, yInteger)

            For Each s As clsSerpiente In _contenedor.serpientes

                'Comprueba si la posicion esta ocupada
                coincide = s.posiciones.Contains(resPosicion)

            Next

        Loop While coincide

        Return resPosicion

    End Function


    Public Shared Sub cargarSpritesSerpiente(Game As Game1)
        _spriteComida = Game.Content.Load(Of Texture2D)("apple")
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




End Class
