Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Module TypeRightMain
#Region "public variables"
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
    Public nSize As Long
    Public lpAppName As String
    Public lpFileName As String
    Public retval As Long
    Public lpVariable As String
    Public lpDefault As String
    Public lpReturnedString As String
    '    Public lpReturnedString As String * 100
    Public strFName As String
    ' Option values
    Public iButtonWidth As Long
    Public iColCt As Integer
    Public iTransPerc As Integer
    Public iButtonCt As Long
    Public bOnTop As Boolean
    Public bToolBar As Boolean
    Public iDelay As Integer
    Public isPro As Boolean
    Public sLicName As String
    Public sLicCode As String
    Public oRegister As NRegisterApp
    Public sDfltFontName As String
    Public iDfltFontSize As Integer
    Public bDfltFontItalic As Boolean
    Public bDfltFontBold As Boolean

    Public strButtonCaption As String
    ' Public strButtonText(60) As String
    Public iCurrBtn As Long
    Public iCurrGrp As Long
    Public iCurrSender As Long
    Public strApplication As String
    '    Public oRegistry As NRegistry
    Public oNCrypter As NCrypt
    Public lBtnListHandle As Long
    Public bNewWidth As Boolean
    Public bMinimise As Boolean
    Public bUserDefinedGroup As Boolean
    Public iDbBtnCt As Integer
    Public iGrpAction As GroupAction
#End Region
#Region "enums"
    Public Enum GroupAction
        GRP_ADD = 0
        GRP_CHG = 1
        GRP_TRANS = 2
        GRP_RMV = 3
    End Enum

#End Region
#Region "public constants"
    Public Const APP_STRING = "skRywTenYbtHgiRepYt"

    'Public Const VK_3 = &H33
    'Public Const VK_BACK = &H8
    'Public Const VK_TAB = &H9
    'Public Const VK_CLEAR = &HC
    'Public Const VK_RETURN = &HD
    Public Const VK_SHIFT = &H10
    Public Const VK_CONTROL = &H11
    'Public Const VK_MENU = &H12
    'Public Const VK_PAUSE = &H13
    'Public Const VK_CAPITAL = &H14
    'Public Const VK_ESCAPE = &H1B
    Public Const VK_SPACE = &H20
    'Public Const VK_PRIOR = &H21
    'Public Const VK_NEXT = &H22
    Public Const VK_END = &H23
    Public Const VK_HOME = &H24
    'Public Const VK_LEFT = &H25
    'Public Const VK_UP = &H26
    'Public Const VK_RIGHT = &H27
    'Public Const VK_DOWN = &H28
    Public Const VK_INSERT = &H2D
    Public Const VK_DELETE = &H2E
    'Public Const VK_MULTIPLY = &H6A
    'Public Const VK_ADD = &H6B
    'Public Const VK_SEPARATOR = &H6C
    'Public Const VK_SUBTRACT = &H6D
    'Public Const VK_DECIMAL = &H6E
    'Public Const VK_DIVIDE = &H6F
    Public Const VK_LCONTROL = &HA2    'Left Control key code
    Public Const VK_OEM_1 = &HBA
    Public Const VK_OEM_PLUS = &HBB
    Public Const VK_OEM_COMMA = &HBC
    Public Const VK_OEM_MINUS = &HBD
    Public Const VK_OEM_PERIOD = &HBE
    Public Const VK_OEM_2 = &HBF
    'Public Const VK_OEM_3 = &HC0
    Public Const VK_OEM_4 = &HDB
    Public Const VK_OEM_5 = &HDC
    Public Const VK_OEM_6 = &HDD
    Public Const VK_OEM_7 = &HDE
    Public Const VK_OEM_8 = &HDF
    'Window message values
    ' Public Const WM_LBUTTONDBLCLK = &H203
    ' Public Const WM_LBUTTONDOWN = &H201
    Public Const WM_LBUTTONUP = &H202
    Public Const WM_MOUSEMOVE = &H200
    ' Public Const WM_RBUTTONDBLCLK = &H206
    ' Public Const WM_RBUTTONDOWN = &H204
    Public Const WM_RBUTTONUP = &H205

#End Region
#Region "common subroutines"
    Public Sub InitialiseApplication()
        Dim thisVersion As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        ' Preserve previous version user application settings
        Dim isVersionChange As Boolean = False
        Dim oldVersion As String = My.Settings.Version
        If oldVersion <> thisVersion Then
            isVersionChange = True
            My.Settings.Upgrade()
        End If
        My.Settings.Version = thisVersion
        My.Settings.Save()
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.StartLogging()
        If isVersionChange Then
            LogUtil.Info("Version change " & oldVersion & " >> " & My.Settings.Version)
            LogUtil.Info("Upgrading settings")
        End If
        sLicName = ""
        sLicCode = ""
        isPro = False
        strApplication = "TypeRight"
        ' Set an encryption object
        oNCrypter = New NCrypt(APP_STRING)
        ' Get the registered name and licence code
        sLicName = My.Settings.RegName
        sLicCode = My.Settings.RegCode
        ' Set a registration object
        Dim oRegister As New NRegisterApp
        ' Check for a valid registration
        If oRegister.IsValidKey(sLicCode, sLicName, APP_STRING) Then
            ' Running pro version
            isPro = True
        Else
            ' Running free version
            isPro = False
        End If
        ' Load the options from the registry
        LoadOptions()
    End Sub
    Public Sub LoadOptions()
        iButtonWidth = My.Settings.ButtonWidth          ' Button width
        iColCt = My.Settings.Columns                    ' Number of columns
        iTransPerc = My.Settings.Transparency           ' Transparency percentage
        iCurrGrp = My.Settings.Group                    ' Current group
        iCurrSender = My.Settings.Sender
        bOnTop = My.Settings.OnTop                      ' Keep on top
        bToolBar = My.Settings.ToolBar                  ' Display Toolbar
        iDelay = My.Settings.Delay                      ' Text injection delay
        bMinimise = My.Settings.Minimise                ' Minimise on startup
        sDfltFontName = My.Settings.FontName            ' Default button caption font
        iDfltFontSize = My.Settings.FontSize
        bDfltFontBold = My.Settings.FontBold
        bDfltFontItalic = My.Settings.FontItalic
        If Not isPro Then
            bToolBar = False
        End If
    End Sub
    Public Sub SaveOptions()
        My.Settings.ButtonWidth = iButtonWidth
        My.Settings.Columns = iColCt
        My.Settings.Transparency = iTransPerc
        My.Settings.Group = iCurrGrp
        My.Settings.Sender = iCurrSender
        My.Settings.OnTop = bOnTop
        My.Settings.ToolBar = bToolBar
        My.Settings.Delay = iDelay
        My.Settings.Minimise = bMinimise
        My.Settings.FontName = sDfltFontName
        My.Settings.FontSize = iDfltFontSize
        My.Settings.FontBold = bDfltFontBold
        My.Settings.FontItalic = bDfltFontItalic
        My.Settings.Save()
    End Sub

    Public Sub GetFormPos(ByRef oForm As Form, ByVal sPos As String)
        Dim thisScreen As Screen = My.Computer.Screen
        Dim workingArea As Rectangle = thisScreen.WorkingArea
        If sPos = "max" Then
            oForm.WindowState = FormWindowState.Maximized
        ElseIf sPos = "min" Then
            oForm.WindowState = FormWindowState.Minimized
        Else
            Dim pos As String() = sPos.Split("~")
            If pos.Length = 4 Then
                oForm.Top = CInt(pos(0))
                oForm.Left = CInt(pos(1))
                oForm.Height = CInt(pos(2))
                oForm.Width = CInt(pos(3))
                If oForm.Left > workingArea.Width Then
                    oForm.Left = workingArea.Width - oForm.Width
                End If
            End If
        End If
    End Sub

#End Region
#Region "common functions"
    Public Function SetFormPos(ByRef oForm As Form) As String
        Dim sPos As String
        If oForm.WindowState = FormWindowState.Maximized Then
            sPos = "max"
        ElseIf oForm.WindowState = FormWindowState.Minimized Then
            sPos = "min"
        Else
            sPos = oForm.Top & "~" & oForm.Left & "~" & oForm.Height & "~" & oForm.Width
        End If
        Return sPos
    End Function
    Public Function GetSourceControl(ByRef menuItem As Object) As Object
        Dim _menuItem As ToolStripMenuItem = CType(menuItem, ToolStripMenuItem)
        Dim menuStrip As ContextMenuStrip = CType(_menuItem.Owner, ContextMenuStrip)
        Return menuStrip.SourceControl
    End Function
    Public Function MakeFont(p_FontName As String, p_FontSize As Integer, isFontBold As Boolean, isFontItalic As Boolean) As Font
        Dim newStyle As FontStyle = If(isFontBold, FontStyle.Bold, FontStyle.Regular) Or If(isFontItalic, FontStyle.Italic, FontStyle.Regular)
        Dim newFont As Font = New Font(p_FontName, p_FontSize, newStyle)
        Return newFont
    End Function

    Public Function GetValueBetweenBrackets(sKeyText As String, Optional marker1 As String = "(", Optional marker2 As String = ")")
        Dim value As String = ""
        Dim parts1 As String() = Split(sKeyText, marker1)
        Dim parts2 As String()
        If parts1.Length > 1 Then
            parts2 = Split(parts1(1), marker2)
            value = parts2(0)
        End If
        Return value
    End Function
#End Region
End Module
