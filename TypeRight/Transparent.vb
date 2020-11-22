Module Transparent
    'Transparancy API's
    Private Declare Function SetLayeredWindowAttributes Lib "user32" (ByVal hWnd As Long, ByVal crKey As Long, ByVal bAlpha As Byte, ByVal dwFlags As Long) As Long
    Private Declare Function UpdateLayeredWindow Lib "user32" (ByVal hWnd As Long, ByVal hdcDst As Long, pptDst As Object, psize As Object, ByVal hdcSrc As Long, pptSrc As Object, crKey As Long, ByVal pblend As Long, ByVal dwFlags As Long) As Long
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hWnd As Long, ByVal nIndex As Long) As Long
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Long, ByVal nIndex As Long, ByVal dwNewLong As Long) As Long

    Private Const GWL_EXSTYLE = (-20)
    Private Const LWA_COLORKEY = &H1
    Private Const LWA_ALPHA = &H2
    Private Const ULW_COLORKEY = &H1
    Private Const ULW_ALPHA = &H2
    Private Const ULW_OPAQUE = &H4
    Private Const WS_EX_LAYERED = &H80000


    Public Function isTransparent(ByVal hWnd As Long) As Boolean
        ' Returns a value depending on whether the window is layered or not
        Try
            Dim Msg As Long
            ' Retrieve the extended window styles
            Msg = GetWindowLong(hWnd, GWL_EXSTYLE)
            ' Check for layered window :
            '    layered windows can be partially translucent, that is, alpha-blended
            If (Msg And WS_EX_LAYERED) = WS_EX_LAYERED Then
                isTransparent = True
            Else
                isTransparent = False
            End If
        Catch ex As Exception

            isTransparent = False
        End Try
    End Function

    Public Function MakeTransparent(ByVal hWnd As Long, ByVal Pcnt As Integer) As Long
        '   Sets the window to layered and sets the opacity to a given percentage
        '   Level of opacity is actually a value between 0 and 255
        Dim Msg As Long
        Try

            Pcnt = ((100 - Pcnt) / 100) * 255
            If Pcnt < 0 Or Pcnt > 255 Then
                ' Percentage invalid value : return percentage error
                MakeTransparent = 1
            Else
                ' Retrieve the extended window styles
                Msg = GetWindowLong(hWnd, GWL_EXSTYLE)
                ' Make Layered
                Msg = Msg Or WS_EX_LAYERED
                SetWindowLong(hWnd, GWL_EXSTYLE, Msg)
                ' Set Alpha value used to describe the opacity of the layered window
                SetLayeredWindowAttributes(hWnd, 0, Pcnt, LWA_ALPHA)
                ' Return OK
                MakeTransparent = 0
            End If
        Catch ex As Exception
            ' return error
            MakeTransparent = 2
        End Try
    End Function

    Public Function MakeOpaque(ByVal hWnd As Long) As Long
        ' Sets the window to non-layered and the opacity to 0
        Dim Msg As Long
        Try
            ' Retrieve the extended window styles
            Msg = GetWindowLong(hWnd, GWL_EXSTYLE)
            ' Make not layered
            Msg = Msg And Not WS_EX_LAYERED
            SetWindowLong(hWnd, GWL_EXSTYLE, Msg)
            ' Set the opacity of the layered window to 0
            SetLayeredWindowAttributes(hWnd, 0, 0, LWA_ALPHA)
            MakeOpaque = 0
        Catch ex As Exception
            ' return error
            MakeOpaque = 2

        End Try
        Return MakeOpaque
    End Function

End Module
