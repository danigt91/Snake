Enum GameState
    TitleScreen = 0
    GameStarted
    GameEnded
End Enum

''' <summary>
''' This is the main type for your game
''' </summary>
Public Class Game1
    Inherits Microsoft.Xna.Framework.Game

    Private WithEvents graphics As GraphicsDeviceManager
    Private WithEvents spriteBatch As SpriteBatch

    Private oldKeyboardState, currentKeyboardState As KeyboardState

    Private contenedorSnake As clsContenedorSnake

    Private TitleSafe As Rectangle

    Private GameState As GameState

    Private song1, song2 As Song
    Private songQueue As Integer = 1


    Public Sub New()

        GameState = SnakeMulti.GameState.GameStarted

        graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
        graphics.PreferredBackBufferWidth = 1280
        graphics.PreferredBackBufferHeight = 720

        Dim numJugadores As Integer = 2
        contenedorSnake = New clsContenedorSnake(
            New Point(1280, 720), numJugadores)

        contenedorSnake.run()

    End Sub

    ''' <summary>
    ''' Allows the game to perform any initialization it needs to before starting to run.
    ''' This is where it can query for any required services and load any non-graphic
    ''' related content.  Calling MyBase.Initialize will enumerate through any components
    ''' and initialize them as well.
    ''' </summary>
    Protected Overrides Sub Initialize()

        ' TODO: Add your initialization logic here
        currentKeyboardState = New KeyboardState()

        MyBase.Initialize()

    End Sub

    ''' <summary>
    ''' Parar los threads al salir.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnExiting(sender As Object, args As EventArgs)

        MyBase.OnExiting(sender, args)
        contenedorSnake.parar()

    End Sub


    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
    Protected Overrides Sub LoadContent()
        ' Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = New SpriteBatch(GraphicsDevice)

        contenedorSnake.cargarSprite(Me)
        'TitleSafe = GetTitleSafeArea(0.8F)

        song1 = Content.Load(Of Song)("Fun in a Bottle")
        song2 = Content.Load(Of Song)("Hustle")


        ' TODO: use Me.Content to load your game content here
    End Sub

    ''' <summary>
    ''' UnloadContent will be called once per game and is the place to unload
    ''' all content.
    ''' </summary>
    Protected Overrides Sub UnloadContent()
        ' TODO: Unload any non ContentManager content here
    End Sub

    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        ' Allows the game to exit

        'Bucle de música
        If (MediaPlayer.State.Equals(MediaState.Stopped)) Then

            If songQueue = 1 Then
                MediaPlayer.Play(song1)
                songQueue = 2
            ElseIf songQueue = 2 Then
                MediaPlayer.Play(song2)
                songQueue = 1
            End If

        End If

        'Eventos de teclado
        oldKeyboardState = currentKeyboardState
        currentKeyboardState = Keyboard.GetState()

        For Each serpiente As clsSerpiente In contenedorSnake.serpientes
            serpiente.controles(oldKeyboardState, currentKeyboardState)
        Next

        If (GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed) Then
            Me.Exit()
        End If

        If ((currentKeyboardState.IsKeyUp(Keys.Escape)) And (oldKeyboardState.IsKeyDown(Keys.Escape))) Then
            Me.Exit()
        End If


        ' TODO: Add your update logic here
        MyBase.Update(gameTime)
    End Sub

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        GraphicsDevice.Clear(Color.White)


        spriteBatch.Begin()

        If GameState = SnakeMulti.GameState.TitleScreen Then

        ElseIf GameState = SnakeMulti.GameState.GameStarted Then
            contenedorSnake.pintarTodo(spriteBatch)

        ElseIf GameState = SnakeMulti.GameState.GameEnded Then


        End If

        spriteBatch.End()


        ' TODO: Add your drawing code here
        MyBase.Draw(gameTime)
    End Sub




    Protected Function GetTitleSafeArea(percent As Single) As Rectangle
        Dim retval As Rectangle
        retval = New Rectangle(
            graphics.GraphicsDevice.Viewport.X,
            graphics.GraphicsDevice.Viewport.Y,
            graphics.GraphicsDevice.Viewport.Width,
            graphics.GraphicsDevice.Viewport.Height)
        Return retval
    End Function

End Class
