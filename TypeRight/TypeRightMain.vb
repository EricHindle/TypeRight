' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO

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
    Public iCurrBtn As Long
    Public iCurrGrp As Long
    Public iCurrSender As Long
    Public strApplication As String
    Public oNCrypter As NCrypt
    Public lBtnListHandle As Long
    Public bNewWidth As Boolean
    Public bMinimise As Boolean
    Public bUserDefinedGroup As Boolean
    Public iDbBtnCt As Integer
#End Region
#Region "enums"
    Public Enum GroupAction
        GRP_ADD = 0
        GRP_CHG = 1
        GRP_TRANS = 2
        GRP_RMV = 3
    End Enum
    Public Enum ButtonAction
        BTN_ADD = 0
        BTN_CHG = 1
        BTN_RMV = 3
    End Enum

#End Region
#Region "public constants"
    Public Const VK_SHIFT = &H10
    Public Const VK_CONTROL = &H11
    Public Const VK_SPACE = &H20
    Public Const VK_END = &H23
    Public Const VK_HOME = &H24
    Public Const VK_INSERT = &H2D
    Public Const VK_DELETE = &H2E
    Public Const VK_LCONTROL = &HA2    'Left Control key code
    Public Const VK_OEM_1 = &HBA
    Public Const VK_OEM_PLUS = &HBB
    Public Const VK_OEM_COMMA = &HBC
    Public Const VK_OEM_MINUS = &HBD
    Public Const VK_OEM_PERIOD = &HBE
    Public Const VK_OEM_2 = &HBF
    Public Const VK_OEM_4 = &HDB
    Public Const VK_OEM_5 = &HDC
    Public Const VK_OEM_6 = &HDD
    Public Const VK_OEM_7 = &HDE
    Public Const VK_OEM_8 = &HDF
    Public Const WM_LBUTTONUP = &H202
    Public Const WM_MOUSEMOVE = &H200
    Public Const WM_RBUTTONUP = &H205
    Private Const MODULE_NAME As String = "TypeRightMain"
#End Region
#Region "common subroutines"
    Public Sub InitialiseApplication()
        Dim thisVersion As String = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        ' Preserve previous version user application settings
        Dim oldVersion As String = My.Settings.Version
        If oldVersion <> thisVersion Then
            My.Settings.Upgrade()
            LogUtil.Info("Version change to " & thisVersion, MODULE_NAME)
            LogUtil.Info("Upgrading settings", MODULE_NAME)
        End If
        My.Settings.Version = thisVersion
        My.Settings.Save()
        sLicName = ""
        sLicCode = ""
        isPro = False
        strApplication = "TypeRight"
        ' Set an encryption object
        oNCrypter = New NCrypt(My.Resources.APP_STRING)
        ' Get the registered name and licence code
        sLicName = My.Settings.RegName
        sLicCode = My.Settings.RegCode
        ' Check licence
        If NRegisterApp.IsValidKey(sLicCode, sLicName, My.Resources.APP_STRING) Then
            ' Running pro version
            isPro = True
        Else
            ' Running free version
            isPro = False
        End If
        ' Load the options from the registry
        LoadOptions()
        TestDatabase()
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
        bToolBar = True
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
        Dim newFont As New Font(p_FontName, p_FontSize, newStyle)
        Return newFont
    End Function
    Public Function GetValueBetweenBrackets(sKeyText As String, Optional marker1 As String = "(", Optional marker2 As String = ")")
        Dim value As String = ""
        Dim parts1 As String() = Split(sKeyText, marker1, 2)
        If parts1.Length > 1 Then
            Dim _lastmarker As Integer = GetMatchingMarker(parts1(1), marker1, marker2)
            If _lastmarker < 0 Then
                value = parts1(1)
            Else
                value = parts1(1).Substring(0, _lastmarker)
            End If
        End If
        Return value
    End Function
    Private Function GetMatchingMarker(pString As String, pOpenMarker As String, pCloseMarker As String) As Integer
        Dim _lastClose As Integer = -1
        Dim _closereq As Integer = 1
        Dim _closefound As Integer = 0
        Dim x As Integer = 0
        Do Until x >= pString.Length Or _closefound = _closereq
            If pString.Substring(x).StartsWith(pOpenMarker) Then
                _closereq += 1
            ElseIf pString.Substring(x).StartsWith(pCloseMarker) Then
                _closefound += 1
                _lastClose = x
            End If
            x += 1
        Loop
        Return _lastClose
    End Function
    Public Function DisplayException(pMethodBase As MethodBase, pException As Exception, pExceptionType As String) As MsgBoxResult
        LogUtil.Exception(pExceptionType, pException, pMethodBase.Name)
        Return MsgBox(pMethodBase.Name & " : Database exception" & vbCrLf _
            & pException.Message & vbCrLf _
            & If(pException.InnerException Is Nothing, "", pException.InnerException.Message) _
            & vbCrLf & "OK to continue?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation,
                      pExceptionType)
    End Function
    Public Function SelectFile(Optional ByVal pFolder As String = Nothing) As String
        Dim sFilename As String = ""
        Using fbd As New OpenFileDialog
            If String.IsNullOrWhiteSpace(pFolder) Then
                fbd.InitialDirectory = SpecialDirectories.MyDocuments
            Else
                fbd.InitialDirectory = pFolder
            End If
            fbd.CheckFileExists = True
            If fbd.ShowDialog() = DialogResult.OK Then
                sFilename = fbd.FileName
            End If
        End Using
        Return sFilename
    End Function
#End Region
End Module
