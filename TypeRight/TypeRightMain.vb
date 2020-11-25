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
    Public iTop As Integer
    Public iLeft As Integer
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
    Public bSplash As Boolean
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
        Dim iSplashDelay As Integer
        sLicName = ""
        sLicCode = ""
        isPro = False
        strApplication = "TypeRight"
        ' Set an encryption object
        Dim oNCrypter As New NCrypt
        ' Get the registered name and licence code
        sLicName = My.Settings.RegName
        sLicCode = My.Settings.RegCode
        ' Set a registration object
        Dim oRegister As New NRegisterApp
        ' Check for a valid registration
        If oRegister.IsValidKey(sLicCode, sLicName, APP_STRING) Then
            ' Running pro version
            isPro = True
            iSplashDelay = 2
        Else
            ' Running free version
            isPro = False
            iSplashDelay = 5
        End If
        ' Load the options from the registry
        LoadOptions()
        If bSplash Then
            Using _splash As New FrmSplash
                _splash.Delay = iSplashDelay
                _splash.Show()
            End Using
        End If
    End Sub
    Public Sub LoadOptions()
        iButtonWidth = My.Settings.ButtonWidth          ' Button width
        iColCt = My.Settings.Columns                    ' Number of columns
        iTransPerc = My.Settings.Transparency           ' Transparency percentage
        iCurrGrp = My.Settings.Group                    ' Current group
        iCurrSender = My.Settings.Sender
        bOnTop = My.Settings.OnTop                      ' Keep on top
        iTop = My.Settings.Top                          ' Position on screen
        iLeft = My.Settings.Left
        bToolBar = My.Settings.ToolBar                  ' Display Toolbar
        iDelay = My.Settings.Delay                      ' Text injection delay
        bSplash = My.Settings.Splash                    ' Display splash screen on startup
        bMinimise = My.Settings.Minimise                ' Minimise on startup
        sDfltFontName = My.Settings.FontName            ' Default button caption font
        iDfltFontSize = My.Settings.FontSize
        bDfltFontBold = My.Settings.FontBold
        bDfltFontItalic = My.Settings.FontItalic
        If Not isPro Then
            bSplash = True
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
        My.Settings.Top = iTop
        My.Settings.Left = iLeft
        My.Settings.ToolBar = bToolBar
        My.Settings.Delay = iDelay
        My.Settings.Splash = bSplash
        My.Settings.Minimise = bMinimise
        My.Settings.FontName = sDfltFontName
        My.Settings.FontSize = iDfltFontSize
        My.Settings.FontBold = bDfltFontBold
        My.Settings.FontItalic = bDfltFontItalic
        My.Settings.Save()
    End Sub
#End Region
#Region "common functions"
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
#End Region
End Module
