' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Windows.Forms
Imports HindlewareLib.Logging

Public Class FrmOptions
#Region "form control handlers"
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        LogUtil.Info("Changes not saved", MyBase.Name)
        Close()
    End Sub
    Private Sub BtnDfltFont_Click(sender As Object, e As EventArgs) Handles BtnDfltFont.Click
        DisplayProgress("Selecting font")
        Dim dlogResult As DialogResult = DialogResult.Cancel
        With FontDialog1
            .FontMustExist = True
            .Font = MakeFont(sDfltFontName, iDfltFontSize, bDfltFontBold, bDfltFontItalic)
            dlogResult = .ShowDialog()
        End With
        With BtnDfltFont
            If dlogResult = DialogResult.OK Then
                .Text = FontDialog1.Font.Name & " " & Format(FontDialog1.Font.Size)
                .Font = MakeFont(FontDialog1.Font.Name, FontDialog1.Font.Size, FontDialog1.Font.Bold, FontDialog1.Font.Italic)
                DisplayProgress("Font selected")
            Else
                DisplayProgress("Font not selected")
            End If
        End With
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        LogUtil.Info("Updating Options", MyBase.Name)
        iDelay = nudDelay.Value
        If isPro = False Then
            sLicName = TxtLicName.Text
            sLicCode = ""
            sLicCode = sLicCode & TxtLic1.Text & TxtLic2.Text & TxtLic3.Text & TxtLic4.Text
            If NRegisterApp.IsValidKey(sLicCode, sLicName, My.Resources.APP_STRING) Then
                My.Settings.RegName = sLicName
                My.Settings.RegCode = sLicCode
                isPro = True
            Else
                If Len(sLicCode) > 0 Then
                    MsgBox("Invalid licence code - not saved", vbExclamation)
                    LogUtil.Info("Invalid licence code", MyBase.Name)
                End If
                sLicName = ""
            End If
        End If
        bOnTop = cbOnTop.Checked
        My.Settings.DebugOn = CbDebug.Checked
        LogUtil.IsDebugOn = CbDebug.Checked
        If MissingFolderResolved(TxtLogFolder.Text.Trim, "Log") = True Then
            My.Settings.LogFolder = TxtLogFolder.Text.Trim
        End If
        If MissingFolderResolved(TxtBkUpFolder.Text.Trim, "Backup") Then
            My.Settings.BackupFolder = TxtBkUpFolder.Text.Trim
        End If
        My.Settings.ButtonWidth = HScroll1.Value
        My.Settings.Transparency = Slider1.Value
        My.Settings.Delay = iDelay
        If isPro Then
            My.Settings.ToolBar = CbToolBar.Checked
            My.Settings.Minimise = cbMinimise.Checked
        End If
        iTransPerc = Slider1.Value
        sDfltFontName = BtnDfltFont.Font.Name
        bDfltFontBold = BtnDfltFont.Font.Bold
        bDfltFontItalic = BtnDfltFont.Font.Italic
        iDfltFontSize = BtnDfltFont.Font.Size
        My.Settings.FontName = sDfltFontName
        My.Settings.FontSize = iDfltFontSize
        My.Settings.FontBold = bDfltFontBold
        My.Settings.FontItalic = bDfltFontItalic
        My.Settings.Save()
        LogUtil.Info("Saved", MyBase.Name)
        Close()
    End Sub
    Private Sub FrmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info(My.Resources.LOADING, MyBase.Name)
        GetFormPos(Me, My.Settings.OptionsPos)
        CbToolBar.Checked = bToolBar
        cbMinimise.Checked = bMinimise
        If isPro Then
            Image2.Visible = True
            Image1.Visible = False
            GrpLicence.Enabled = False
        Else
            nudDelay.Visible = False
            CbToolBar.Checked = False
            CbToolBar.Enabled = False
            Image2.Visible = False
            Image1.Visible = True
            GrpLicence.Enabled = True
        End If
        TxtLicName.Text = sLicName
        TxtLic1.Text = Mid(sLicCode, 1, 4)
        TxtLic2.Text = Mid(sLicCode, 5, 4)
        TxtLic3.Text = Mid(sLicCode, 9, 4)
        TxtLic4.Text = Mid(sLicCode, 13, 4)
        Slider1.Value = iTransPerc
        HScroll1.Value = iButtonWidth
        BtnSample.Width = iButtonWidth
        cbOnTop.Checked = bOnTop
        nudDelay.Text = Format(iDelay)
        BtnDfltFont.Text = sDfltFontName & " " & Format(iDfltFontSize)
        BtnDfltFont.Font = MakeFont(sDfltFontName, iDfltFontSize, bDfltFontBold, bDfltFontItalic)
        TxtBkUpFolder.Text = My.Settings.BackupFolder
        TxtLogFolder.Text = My.Settings.LogFolder
        CbDebug.Checked = My.Settings.DebugOn
        LblVersion.Text = System.String.Format(LblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
    End Sub
    Private Sub HScroll1_Scroll(sender As Object, e As Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
        ScrollValueChanged()
    End Sub
    Private Sub ScrollValueChanged()
        BtnSample.Text = Format(HScroll1.Value)
        BtnSample.Width = HScroll1.Value
        iButtonWidth = HScroll1.Value
    End Sub
    Private Sub Slider1_Scroll(sender As Object, e As EventArgs) Handles Slider1.Scroll
        Owner.Opacity = Slider1.Value / 100
    End Sub
    Private Sub BtnPosReset_Click(sender As Object, e As EventArgs) Handles BtnPosReset.Click
        My.Settings.EditButtonPos = "10~10~628~913"
        My.Settings.DBUpdatePos = "10~10~627~829"
        My.Settings.GroupMaintPos = "10~10~263~649"
        My.Settings.OptionsPos = "10~10~459~674"
        My.Settings.ButtonListPos = "10~10~600~124"
        My.Settings.SndrBtnFormPos = "10~10~286~393"
        My.Settings.LogViewerPos = "10~10~876~588"
        My.Settings.EmailFormPos = "10~10~546~954"
        My.Settings.SmtpFormPos = "10~10~327~600"
        My.Settings.Save()
        DisplayProgress("Form screen positions reset")
    End Sub
    Private Sub BtnViewLog_Click(sender As Object, e As EventArgs) Handles BtnViewLog.Click
        Using _logView As New FrmLogViewer
            _logView.ShowDialog()
        End Using
    End Sub
    Private Sub FrmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
        My.Settings.OptionsPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
#End Region
#Region "subroutines"
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = True)
        lblStatus.Text = If(isAppend, lblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub
    Private Sub HScroll1_ValueChanged(sender As Object, e As EventArgs) Handles HScroll1.ValueChanged
        ScrollValueChanged()
    End Sub
    Private Function MissingFolderResolved(folderName As String, folderType As String) As Boolean
        Dim isOK As Boolean = False
        If My.Computer.FileSystem.DirectoryExists(folderName) Then
            isOK = True
        Else
            If MsgBox(folderType & " folder does not exist. Create?", vbExclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                My.Computer.FileSystem.CreateDirectory(folderName)
                isOK = True
                DisplayProgress("Created log folder " & folderName)
            Else
                LogUtil.Info("Invalid " & folderType & " folder name", MyBase.Name)
                isOK = False
            End If
        End If
        Return isOK
    End Function
    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
    End Sub
    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Using _restore As New FrmRestore
            _restore.ShowDialog()
        End Using
    End Sub
#End Region
End Class