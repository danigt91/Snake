Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class clsScreen

    Protected Shared PlayerOne As PlayerIndex

    Protected ScreenEvent As EventHandler
    Public Sub New(theScreenEvent As EventHandler)
        ScreenEvent = theScreenEvent
    End Sub


    Public Overridable Sub Update(theTime As GameTime)

    End Sub

    Public Overridable Sub Draw(theTime As GameTime)

    End Sub

End Class
