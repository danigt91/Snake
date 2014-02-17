Public Class clsContenedorSnake

    Private _dimension As Point

    Private _serpientes As List(Of clsSerpiente)
    Private _comida As clsComida

    Private _velocidadMovimiento As Integer
    Private _tamanioRejilla As Integer
    Private _tamanioObjetos As Integer
    
    Dim SpriteTexture As Texture2D
    Dim SpriteBackground As Texture2D

    Dim spriteFont As SpriteFont


    Public Sub New(dimension As Point)

        _dimension = dimension

        _serpientes = New List(Of clsSerpiente)

        _velocidadMovimiento = 60
        _tamanioRejilla = 1
        _tamanioObjetos = 16

        _comida = New clsComida(Me)

    End Sub

    Public Sub New(dimension As Point, numJugadores As Integer)

        _dimension = dimension

        _serpientes = New List(Of clsSerpiente)

        _velocidadMovimiento = 60
        _tamanioRejilla = 1
        _tamanioObjetos = 20

        _comida = New clsComida(Me)

        Select Case numJugadores
            Case 1
                Me.serpientes.Add(New clsSerpiente(Me))
            Case 2
                Me.serpientes.Add(New clsSerpiente(Me))

                Dim serpiente2 As clsSerpiente = New clsSerpiente(Me)
                Dim posiciones2 As New List(Of Point)
                For Each punto As Point In serpiente2.posiciones
                    posiciones2.Add(New Point(punto.X, punto.Y + 10 * Me.tamanioRejilla * Me.tamanioObjetos))
                Next
                serpiente2.posiciones = posiciones2

                serpiente2.left = Keys.A
                serpiente2.right = Keys.D
                serpiente2.up = Keys.W
                serpiente2.down = Keys.S

                Me.serpientes.Add(serpiente2)

        End Select

    End Sub


    Public Function choque(serpiente As clsSerpiente) As Boolean
        Dim _choque As Boolean = False
        'Comprobamos si la cabeza de cada una choca con el cuerpo de otra.
        SyncLock _serpientes

            Dim serpientesAux As List(Of clsSerpiente) = New List(Of clsSerpiente)(_serpientes)
            serpientesAux.Remove(serpiente)
            For Each s As clsSerpiente In serpientesAux
                If s.posiciones.Contains(serpiente.posiciones(0)) Then
                    _choque = True
                End If
            Next
        End SyncLock
        Return _choque

    End Function


    Public Sub run()
        For index As Integer = 0 To serpientes.Count - 1
            serpientes.Item(index).thread.Start()
        Next
    End Sub

    Public Sub parar()
        For index As Integer = 0 To serpientes.Count - 1
            serpientes.Item(index).thread.Abort()
        Next
    End Sub


    Public Sub cargarSprite(Game As Game1)
        SpriteBackground = Game.Content.Load(Of Texture2D)("background")
        clsSerpiente.cargarSpritesSerpiente(Game)
        clsComida.cargarSpritesSerpiente(Game)
        SpriteFont = Game.Content.Load(Of SpriteFont)("SpriteFont1")
    End Sub



    Public Sub pintarContenedor(spriteBatch As SpriteBatch)

        'Dibujamos el fondo del contenedor
        For i As Integer = 0 To dimension.X - 1 Step +400
            For j As Integer = 0 To dimension.Y - 1 Step +400
                spriteBatch.Draw(SpriteBackground, New Rectangle(i, j, i + 400, j + 400), Color.White)
            Next
        Next

        'Dibujamos las puntuaciones de los jugadores
        For i As Integer = 0 To serpientes.Count - 1
            spriteBatch.DrawString(spriteFont, "Jugador " & (i + 1) & ": " & serpientes.Item(i).puntuacion, New Vector2(5, i * 30), Color.Black)
        Next

    End Sub


    Public Sub pintarTodo(spriteBatch As SpriteBatch)

        pintarContenedor(spriteBatch)
        For i As Integer = 0 To serpientes.Count - 1
            serpientes.Item(i).pintarSerpiente(spriteBatch)
        Next
        comida.pintarComida(spriteBatch)

    End Sub




    Public Property tamanioObjetos() As Integer
        Get
            Return _tamanioObjetos
        End Get
        Set(ByVal value As Integer)
            _tamanioObjetos = value
        End Set
    End Property

    Public Property tamanioRejilla() As Integer
        Get
            Return _tamanioRejilla
        End Get
        Set(ByVal value As Integer)
            _tamanioRejilla = value
        End Set
    End Property


    Public ReadOnly Property numRejillasX() As Integer
        Get
            Return CType(_dimension.X / tamanioRejilla, Integer)
        End Get
    End Property

    Public ReadOnly Property numRejillasY() As Integer
        Get
            Return CType(_dimension.Y / tamanioRejilla, Integer)
        End Get
    End Property


    Public ReadOnly Property serpientes() As List(Of clsSerpiente)
        Get
            Return _serpientes
        End Get
    End Property


    Public Property comida() As clsComida
        Get
            Return _comida
        End Get
        Set(ByVal value As clsComida)
            _comida = value
        End Set
    End Property

    Public ReadOnly Property dimension() As Point
        Get
            Return _dimension
        End Get
    End Property



End Class
