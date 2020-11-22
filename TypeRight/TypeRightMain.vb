Imports System.Drawing

Module TypeRightMain
    Public nSize As Long
    Public lpAppName As String
    Public lpFileName As String
    Public retval As Long
    Public lpVariable As String
    ' Public lpDefault As String
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
    Public IconData As NOTIFYICONDATA
    Public bPro As Boolean
    Public sLicName As String
    Public sLicCode As String
    Public oRegister As NRegisterApp
    Public sDBLocation As String
    Public sDfltFontName As String
    Public iDfltFontSize As Integer
    Public bDfltFontItalic As Boolean
    Public bDfltFontBold As Boolean

    Public strButtonCaption As String
    ' Public strButtonText(60) As String
    Public iCurrBtn As Long
    Public iCurrGrp As Long
    Public strApplication As String
    '    Public oRegistry As NRegistry
    Public oNCrypter As NCrypt
    Public lBtnListHandle As Long
    Public bNewWidth As Boolean
    Public bSplash As Boolean
    Public bMinimise As Boolean
    Public bUserDefinedGroup As Boolean
    Public iDbBtnCt As Integer

    Public iGrpAction As Integer

    Public Const APP_STRING = "skRywTenYbtHgiRepYt"
    Public Const GRP_ADD = 0
    Public Const GRP_CHG = 1
    Public Const GRP_TRANS = 2
    Public Const GRP_RMV = 3

    'Public Const VK_3 = &H33
    'Public Const VK_BACK = &H8
    'Public Const VK_TAB = &H9
    'Public Const VK_CLEAR = &HC
    'Public Const VK_RETURN = &HD
    'Public Const VK_SHIFT = &H10
    'Public Const VK_CONTROL = &H11
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

    ' Notify Icon values
    Public Const NIM_ADD = &H0
    Public Const NIM_DELETE = &H2
    Public Const NIM_MODIFY = &H1
    Public Const NIF_ICON = &H2
    Public Const NIF_MESSAGE = &H1
    Public Const NIF_TIP = &H4

    'Window message values
    ' Public Const WM_LBUTTONDBLCLK = &H203
    ' Public Const WM_LBUTTONDOWN = &H201
    Public Const WM_LBUTTONUP = &H202
    Public Const WM_MOUSEMOVE = &H200
    ' Public Const WM_RBUTTONDBLCLK = &H206
    ' Public Const WM_RBUTTONDOWN = &H204
    Public Const WM_RBUTTONUP = &H205

    Structure NOTIFYICONDATA
        Dim cbSize As Long
        Dim hWnd As Long
        Dim uID As Long
        Dim uFlags As Long
        Dim uCallbackMessage As Long
        Dim hIcon As Long
        Dim szTip As String()
        '    Dim szTip As String * 64
    End Structure

    Public Sub Main()
        ' This is the startup object
        Dim iSplashDelay As Integer

        sLicName = ""
        sLicCode = ""
        bPro = False
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
            bPro = True
            iSplashDelay = 2
        Else
            ' Running free version
            bPro = False
            iSplashDelay = 5
        End If

        ' Load the options from the registry
        LoadOptions()

        If bSplash Then
            Using _splash As New FrmSplash
                _splash.Show()
            End Using
        End If

        '       frmButtonList.Show
    End Sub

    Public Sub LoadOptions()
        Dim strwidth As String
        Dim strcols As String

        ' Button width
        strwidth = My.Settings.ButtonWidth
        ' Number of columns
        strcols = My.Settings.Columns
        ' Transparency percentage
        iTransPerc = My.Settings.Transparency
        ' Current group
        iCurrGrp = My.Settings.Group
        ' Keep on top
        bOnTop = My.Settings.OnTop
        ' Position on screen
        iTop = My.Settings.Top
        iLeft = My.Settings.Left
        ' Display Toolbar
        bToolBar = My.Settings.ToolBar
        ' Text injection delay
        iDelay = My.Settings.Delay
        ' Display splash screen on startup
        bSplash = My.Settings.Splash
        ' Minimise on startup
        bMinimise = My.Settings.Minimise
        ' Database location
        sDBLocation = My.Settings.DBLocation
        ' Default button caption font
        sDfltFontName = My.Settings.FontName
        iDfltFontSize = My.Settings.FontSize
        bDfltFontBold = My.Settings.FontBold
        bDfltFontItalic = My.Settings.FontItalic

        If Not bPro Then
            bSplash = True
            bToolBar = False
        End If
        iButtonWidth = CInt(strwidth)
        iColCt = CInt(strcols)
        ' Set window width based on number of columns and button width
        '     frmButtonList.Width = (iColCt * iButtonWidth) + 120
    End Sub

    Public Function MakeFont(p_FontName As String, p_FontSize As Integer, isFontBold As Boolean, isFontItalic As Boolean) As Font
        Dim newStyle As FontStyle = If(isFontBold, FontStyle.Bold, FontStyle.Regular) Or If(isFontItalic, FontStyle.Italic, FontStyle.Regular)
        Dim newFont As Font = New Font(p_FontName, p_FontSize, newStyle)
        Return newFont
    End Function
End Module
