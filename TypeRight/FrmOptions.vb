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
        If bPro = False Then
            sLicName = TxtLicName.Text
            sLicCode = ""
            sLicCode = sLicCode & TxtLic1.Text & TxtLic2.Text & TxtLic3.Text & TxtLic4.Text
            If oRegister.IsValidKey(sLicCode, sLicName, APP_STRING) Then
                My.Settings.RegName = sLicName
                My.Settings.RegCode = sLicCode
                bPro = True
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
        If bPro Then
            My.Settings.ToolBar = CbToolBar.Checked
            My.Settings.Splash = cbSplash.Checked
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

        CbToolBar.Checked = bToolBar
        cbSplash.Checked = bSplash
        cbMinimise.Checked = bMinimise
        If bPro Then
            'Image2.Visible = True
            'Image1.Visible = False
            GrpLicence.Enabled = False
        Else
            nudDelay.Visible = False
            cbSplash.Checked = True
            CbToolBar.Checked = False
            cbSplash.Enabled = False
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

    Private Function MakeFont(sDfltFontName As String, iDfltFontSize As Integer, isFontBold As Boolean, isFontItalic As Boolean) As Font
        Dim newStyle As FontStyle = If(isFontBold, FontStyle.Bold, FontStyle.Regular) Or If(isFontItalic, FontStyle.Italic, FontStyle.Regular)
        Dim newFont As Font = New Font(sDfltFontName, iDfltFontSize, newStyle)
        Return newFont
    End Function

End Class