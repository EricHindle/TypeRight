Imports System.ComponentModel
Imports System.Drawing

Public Class FrmOptions
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
    Private Sub BtnDfltFont_Click(sender As Object, e As EventArgs) Handles BtnDfltFont.Click
        With FontDialog1
            .FontMustExist = True
            .Font = MakeFont(sDfltFontName, iDfltFontSize, bDfltFontBold, bDfltFontItalic)
            .ShowDialog()
        End With
        With BtnDfltFont
            .Text = FontDialog1.Font.Name & " " & Format(FontDialog1.Font.Size)
            .Font = MakeFont(FontDialog1.Font.Name, FontDialog1.Font.Size, FontDialog1.Font.Bold, FontDialog1.Font.Italic)
        End With
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        iDelay = nudDelay.Value
        If isPro = False Then
            sLicName = TxtLicName.Text
            sLicCode = ""
            sLicCode = sLicCode & TxtLic1.Text & TxtLic2.Text & TxtLic3.Text & TxtLic4.Text
            If oRegister.IsValidKey(sLicCode, sLicName, APP_STRING) Then
                My.Settings.RegName = sLicName
                My.Settings.RegCode = sLicCode
                isPro = True
            Else
                If Len(sLicCode) > 0 Then
                    MsgBox("Invalid licence code", vbExclamation)
                End If
                sLicName = ""
            End If
        End If
        bOnTop = cbOnTop.Checked
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
        Me.Close()
    End Sub
    Private Sub FrmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.OptionsPos)
        CbToolBar.Checked = bToolBar
        cbMinimise.Checked = bMinimise
        If isPro Then
            'Image2.Visible = True
            'Image1.Visible = False
            GrpLicence.Enabled = False
        Else
            nudDelay.Visible = False
            CbToolBar.Checked = False
            CbToolBar.Enabled = False
            'Image2.Visible = False
            'Image1.Visible = True
            GrpLicence.Enabled = True
        End If
        TxtLicName.Text = sLicName
        TxtLic1.Text = Mid(sLicCode, 1, 4)
        TxtLic2.Text = Mid(sLicCode, 5, 4)
        TxtLic3.Text = Mid(sLicCode, 9, 4)
        TxtLic4.Text = Mid(sLicCode, 13, 4)
        '   lOrigWidth = frmButtonList.cmdText(0).Width
        'BtnSample.Caption = Format(frmButtonList.cmdText(0).Width)
        'BtnSample.Width = frmButtonList.cmdText(0).Width
        'HScroll1.Value = frmButtonList.cmdText(0).Width
        Slider1.Value = iTransPerc
        cbOnTop.Checked = bOnTop
        nudDelay.Text = Format(iDelay)
        BtnDfltFont.Text = sDfltFontName & " " & Format(iDfltFontSize)
        BtnDfltFont.Font = MakeFont(sDfltFontName, iDfltFontSize, bDfltFontBold, bDfltFontItalic)
    End Sub
    Private Sub HScroll1_Scroll(sender As Object, e As Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
        BtnSample.Text = Format(HScroll1.Value)
        BtnSample.Width = HScroll1.Value
        iButtonWidth = HScroll1.Value
    End Sub
    Private Sub Slider1_Scroll(sender As Object, e As EventArgs) Handles Slider1.Scroll
        MakeTransparent(lBtnListHandle, Slider1.Value)
    End Sub

    Private Sub FrmOptions_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.OptionsPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub BtnPosReset_Click(sender As Object, e As EventArgs) Handles BtnPosReset.Click
        My.Settings.EditButtonPos = "10~10~604~896"
        My.Settings.DBUpdatePos = "10~10~660~836"
        My.Settings.GroupMaintPos = "10~10~300~645"
        My.Settings.OptionsPos = "10~10~468~633"
        My.Settings.ButtonListPos = "10~10~423~124"
        My.Settings.Save()
    End Sub

End Class