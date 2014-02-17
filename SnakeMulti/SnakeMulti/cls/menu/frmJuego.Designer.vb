<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJuego
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn2Jugador = New System.Windows.Forms.Button()
        Me.btnOpciones = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btn1Jugador = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn2Jugador
        '
        Me.btn2Jugador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2Jugador.Image = Global.SnakeMulti.My.Resources.Resources.btn
        Me.btn2Jugador.Location = New System.Drawing.Point(79, 61)
        Me.btn2Jugador.Name = "btn2Jugador"
        Me.btn2Jugador.Size = New System.Drawing.Size(75, 23)
        Me.btn2Jugador.TabIndex = 2
        Me.btn2Jugador.Text = "2 Jugadores"
        Me.btn2Jugador.UseVisualStyleBackColor = True
        '
        'btnOpciones
        '
        Me.btnOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOpciones.Image = Global.SnakeMulti.My.Resources.Resources.btn
        Me.btnOpciones.Location = New System.Drawing.Point(79, 90)
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(75, 23)
        Me.btnOpciones.TabIndex = 1
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Image = Global.SnakeMulti.My.Resources.Resources.btn
        Me.btnSalir.Location = New System.Drawing.Point(79, 119)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btn1Jugador
        '
        Me.btn1Jugador.BackgroundImage = Global.SnakeMulti.My.Resources.Resources.btn
        Me.btn1Jugador.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn1Jugador.FlatAppearance.BorderSize = 0
        Me.btn1Jugador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1Jugador.Image = Global.SnakeMulti.My.Resources.Resources.btn
        Me.btn1Jugador.Location = New System.Drawing.Point(79, 32)
        Me.btn1Jugador.Name = "btn1Jugador"
        Me.btn1Jugador.Size = New System.Drawing.Size(75, 23)
        Me.btn1Jugador.TabIndex = 1
        Me.btn1Jugador.Text = "1 Jugador"
        Me.btn1Jugador.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SnakeMulti.My.Resources.Resources.menu
        Me.PictureBox1.Location = New System.Drawing.Point(-8, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(241, 196)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmJuego
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(225, 189)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnOpciones)
        Me.Controls.Add(Me.btn2Jugador)
        Me.Controls.Add(Me.btn1Jugador)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJuego"
        Me.Text = "Snake"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn1Jugador As System.Windows.Forms.Button
    Friend WithEvents btn2Jugador As System.Windows.Forms.Button
    Friend WithEvents btnOpciones As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
