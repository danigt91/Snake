Imports System.Threading
Public Class clsSerpiente

    Private _contenedor As clsContenedorSnake

    Private _isViva As Boolean
    Private _direccionMovimiento As Point
    Private _velocidadMovimiento As Integer
    Private _puntuacion As Integer
    Private _color As Color
    Private _posiciones As List(Of Point)
    Private _isPulsable As Boolean
    Private _left As Keys
    Private _right As Keys
    Private _up As Keys
    Private _down As Keys

    Public Shared _spriteSerpiente As Texture2D

    Dim _thread As Thread


    Public Sub New(contenedor As clsContenedorSnake)

        _contenedor = contenedor
        _isViva = True
        _velocidadMovimiento = 60
        _direccionMovimiento = New Point(1, 0)
        _puntuacion = 0
        _color = Color.Orange
        _posiciones = New List(Of Point)
        For index As Integer = 5 To 0 Step -1
            posiciones.Add(New Point(index * contenedor.tamanioObjetos * contenedor.tamanioRejilla, 0))
        Next

        _left = Keys.Left
        _right = Keys.Right
        _up = Keys.Up
        _down = Keys.Down

        _thread = New Thread(AddressOf Me.run)

    End Sub

    'Método por el cual comprueba si la serpiente "come" la comida referenciada
    Public Sub comer(comida As clsComida)

        'Si la primera posicion de la serpiente es igual a la posicion de la comida
        If comida.posicion.Equals(_posiciones.Item(0)) Then

            _puntuacion += 1
            'Crece la serpiente
            _posiciones.Add(New Point(_posiciones.Item(_posiciones.Count - 1).X, _posiciones.Item(_posiciones.Count - 1).Y))
            'Generamos nueva posicion para la comida
            comida.posicion = comida.generarPosicion
            'Aumentamos la velocidad de ejecucion de la serpiente
            If _velocidadMovimiento >= 3 Then
                _velocidadMovimiento -= 1
            End If

        End If

    End Sub


    Public Sub mover()

        'Asignamos las posiciones de n a n-1 menos la primera posicion que se movera con la velocidad
        For index = posiciones.Count - 1 To 1 Step -1
            posiciones.Item(index) = posiciones.Item(index - 1)
        Next

        Dim cabeza As Point = _posiciones.Item(0)

        'Movemos la primera posicion segun la velocidad
        _posiciones.Item(0) = New Point(cabeza.X + _direccionMovimiento.X * _contenedor.tamanioRejilla * _contenedor.tamanioObjetos, _
                                       cabeza.Y + _direccionMovimiento.Y * _contenedor.tamanioRejilla * _contenedor.tamanioObjetos)

        cabeza = _posiciones.Item(0)

        'Para velocidad X positiva: Comprobamos si la primera posicion sale del eje X del panel, si es asi vuelve al principio
        If cabeza.X >= _contenedor.dimension.X - (_contenedor.tamanioRejilla * _contenedor.tamanioObjetos - 1) Then
            _posiciones.Item(0) = New Point(0, cabeza.Y)
        ElseIf cabeza.X < 0 Then
            _posiciones.Item(0) = New Point(_contenedor.numRejillasX * _contenedor.tamanioRejilla - _contenedor.tamanioObjetos * _contenedor.tamanioRejilla, cabeza.Y)
        ElseIf cabeza.Y >= _contenedor.dimension.Y - (_contenedor.tamanioRejilla * _contenedor.tamanioObjetos - 1) Then
            _posiciones.Item(0) = New Point(cabeza.X, 0)
        ElseIf cabeza.Y < 0 Then
            _posiciones.Item(0) = New Point(cabeza.X, _contenedor.numRejillasY * _contenedor.tamanioRejilla - _contenedor.tamanioObjetos * _contenedor.tamanioRejilla)
        End If

        'Si choca consigo misma, muere
        Dim posicionesAux As New List(Of Point)(_posiciones)
        posicionesAux.Remove(posicionesAux.Item(0))
        If posicionesAux.Contains(_posiciones.Item(0)) Then
            _isViva = False
        End If

        'Desbloquea el estado de la pulsacion de teclado para esta serpiente
        If Not _isPulsable Then
            _isPulsable = True
        End If

    End Sub


    Public Sub run()
        'Mientras la serpiente viva
        While isViva
            If isViva Then
                'Mover, comer
                mover()
                comer(_contenedor.comida)
                'Comprueba si choca con otras
                If _contenedor.choque(Me) Then
                    isViva = False
                End If
            End If

            'Hace la pausa para el siguiente movimiento
            thread.Sleep(_velocidadMovimiento)

        End While

    End Sub


    Public Shared Sub cargarSpritesSerpiente(Game As Game1)
        _spriteSerpiente = Game.Content.Load(Of Texture2D)("circle-16")
    End Sub

    Public Sub pintarSerpiente(spriteBatch As SpriteBatch)

        For i As Integer = 0 To posiciones.Count - 1
            Dim pos As Rectangle = New Rectangle(posiciones.Item(i).X, posiciones.Item(i).Y, _contenedor.tamanioRejilla * _contenedor.tamanioObjetos, _contenedor.tamanioRejilla * _contenedor.tamanioObjetos)
            spriteBatch.Draw(spriteSerpiente, pos, Color.White)
        Next


    End Sub


    Public Sub controles(old As KeyboardState, current As KeyboardState)

        If isPulsable Then

            If current.IsKeyDown(Me._left) And isPulsable Then
                If Not Me._direccionMovimiento.Equals(New Point(1, 0)) Then
                    Me._direccionMovimiento = New Point(-1, 0)
                    Me._isPulsable = False
                End If
            End If
            If current.IsKeyDown(Me._right) And isPulsable Then
                If Not Me._direccionMovimiento.Equals(New Point(-1, 0)) Then
                    Me._direccionMovimiento = New Point(1, 0)
                    Me._isPulsable = False
                End If
            End If

            If current.IsKeyDown(Me._up) And isPulsable Then
                If Not Me._direccionMovimiento.Equals(New Point(0, 1)) Then
                    Me._direccionMovimiento = New Point(0, -1)
                    Me._isPulsable = False
                End If
            End If

            If current.IsKeyDown(Me._down) And isPulsable Then
                If Not Me._direccionMovimiento.Equals(New Point(0, -1)) Then
                    Me._direccionMovimiento = New Point(0, 1)
                    Me._isPulsable = False
                End If
            End If

        End If

    End Sub




    Public Property posiciones() As List(Of Point)
        Get
            Return _posiciones
        End Get
        Set(value As List(Of Point))
            _posiciones = value
        End Set
    End Property

    Public Property puntuacion() As Integer
        Get
            Return _puntuacion
        End Get
        Set(value As Integer)
            _puntuacion = value
        End Set
    End Property


    Public Property isViva() As Boolean
        Get
            Return _isViva
        End Get
        Set(value As Boolean)
            _isViva = value
        End Set
    End Property


    Public Property isPulsable() As Boolean
        Get
            Return _isPulsable
        End Get
        Set(value As Boolean)
            _isPulsable = value
        End Set
    End Property

    Public Property spriteSerpiente() As Texture2D
        Get
            Return _spriteSerpiente
        End Get
        Set(value As Texture2D)
            _spriteSerpiente = value
        End Set
    End Property

    Public ReadOnly Property thread() As Thread
        Get
            Return _thread
        End Get
    End Property

    Public Property left() As Keys
        Get
            Return _left
        End Get
        Set(value As Keys)
            _left = value
        End Set
    End Property

    Public Property right() As Keys
        Get
            Return _right
        End Get
        Set(value As Keys)
            _right = value
        End Set
    End Property

    Public Property up() As Keys
        Get
            Return _up
        End Get
        Set(value As Keys)
            _up = value
        End Set
    End Property

    Public Property down() As Keys
        Get
            Return _down
        End Get
        Set(value As Keys)
            _down = value
        End Set
    End Property


End Class
