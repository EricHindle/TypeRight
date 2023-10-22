' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class FrmEditButton
#Region "variables"
    Private iId As Integer
    Private iSeq As Integer
    Private iGrp As Integer
    Private ReadOnly oTextUtil As NTextUtil
    Private ReadOnly oTable As New TypeRight.TypeRightDataSet.sendersDataTable
    Private actionString As String = "Editing"
#End Region
#Region "properties"
    Private _button As NbuttonControlLibrary.Nbutton
    Private _action As Integer
    Public Property Action() As Integer
        Get
            Return _action
        End Get
        Set(ByVal value As Integer)
            _action = value
        End Set
    End Property
    Public Property Button() As NbuttonControlLibrary.Nbutton
        Get
            Return _button
        End Get
        Set(ByVal value As NbuttonControlLibrary.Nbutton)
            _button = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub FrmEditButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info(My.Resources.LOADING, MyBase.Name)
        GetFormPos(Me, My.Settings.EditButtonPos)
        For Each _col As DataColumn In oTable.Columns
            CbDbValue.Items.Add(_col.ColumnName)
        Next
        grpOpts.Visible = isPro
        chkEncrypt.Checked = False
        If _button IsNot Nothing Then
            If _action = ButtonAction.BTN_ADD Then
                actionString = "Adding"
            End If
            DisplayProgress(actionString & " button " & _button.Caption)
            iSeq = _button.Sequence
            iGrp = _button.Group
            iId = _button.Id
            Dim btnGrp As ButtonGroup = GetButtonGroupById(iGrp)
            BtnFont.Text = _button.FontName & "(" & _button.FontSize & ")"
            If isPro Then
                chkEncrypt.Checked = _button.Encrypt
            End If
            LblBtnSeq.Text = CStr(iSeq)
            LblBtnGrp.Text = btnGrp.GroupName
            TxtHint.Text = _button.Hint
            TxtValue.Text = If(chkEncrypt.Checked, oNCrypter.DecryptData(_button.Value), _button.Value)
            txtCaption.Text = _button.Caption
            BtnFont.Font = _button.Font
        Else

        End If
    End Sub
    Private Sub BtnFont_Click(sender As Object, e As EventArgs) Handles BtnFont.Click
        DisplayProgress("Selecting font")
        Dim dlogResult As DialogResult = DialogResult.Cancel
        With FontDialog1
            .FontMustExist = True
            .Font = MakeFont(sDfltFontName, iDfltFontSize, bDfltFontBold, bDfltFontItalic)
            dlogResult = .ShowDialog()
        End With
        With BtnFont
            If dlogResult = DialogResult.OK Then
                .Text = FontDialog1.Font.Name & " " & Format(FontDialog1.Font.Size)
                .Font = MakeFont(FontDialog1.Font.Name, FontDialog1.Font.Size, FontDialog1.Font.Bold, FontDialog1.Font.Italic)
                DisplayProgress("Font selected")
            Else
                DisplayProgress("Font not selected")
            End If
        End With
    End Sub
    Private Sub BtnCancel_Click() Handles BtnCancel.Click
        DisplayProgress("Button not updated")
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        DisplayProgress(actionString & " button")
        Dim isEncrypted As Boolean
        Dim strNewText As String
        If IsValidated() Then
            If isPro And chkEncrypt.Checked Then
                isEncrypted = True
                strNewText = oNCrypter.EncryptData(TxtValue.Text)
            Else
                isEncrypted = False
                strNewText = TxtValue.Text
            End If
            With _button
                .Caption = txtCaption.Text
                .Hint = TxtHint.Text
                .FontName = BtnFont.Font.Name
                .FontSize = BtnFont.Font.Size
                .FontBold = BtnFont.Font.Bold
                .FontItalic = BtnFont.Font.Italic
                .Value = strNewText
                .Encrypt = isEncrypted
            End With
            If _action = ButtonAction.BTN_ADD Then
                Dim newId As Integer = InsertButton(_button)
            End If
            Dim oBtn As TypeRightDataSet.buttonRow = GetButtonByGroupAndSeq(iGrp, iSeq)
            If oBtn IsNot Nothing Then
                UpdateButton(oBtn.buttonGroup, oBtn.buttonSeq, txtCaption.Text, TxtHint.Text, strNewText, BtnFont.Font.Name, BtnFont.Font.Bold, BtnFont.Font.Size, BtnFont.Font.Italic, isEncrypted, oBtn.buttonId)
            End If
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub
    Private Sub BtnSpecialKey1_Click(sender As Object, e As EventArgs) Handles BtnOpenCurlyBracket.Click,
                                                                                BtnAlt.Click,
                                                                                BtnBackspace.Click,
                                                                                BtnBacktab.Click,
                                                                                BtnCloseCurlyBracket.Click,
                                                                                BtnCtrl.Click,
                                                                                BtnDelete.Click,
                                                                                BtnDownArrow.Click,
                                                                                BtnEnd.Click,
                                                                                BtnHome.Click,
                                                                                BtnInsert.Click,
                                                                                BtnLeftArrow.Click,
                                                                                BtnOpenCurlyBracket.Click,
                                                                                BtnPageDown.Click,
                                                                                BtnPageUp.Click,
                                                                                BtnReturn.Click,
                                                                                BtnRightArrow.Click,
                                                                                BtnTab.Click,
                                                                                BtnUpArrow.Click,
                                                                                BtnPct.Click,
                                                                                BtnCaret.Click,
                                                                                BtnPlus.Click,
                                                                                BtnTilde.Click,
                                                                                BtnOpenBracket.Click,
                                                                                BtnCloseBracket.Click

        Dim specialButton As Windows.Forms.Button = TryCast(sender, Windows.Forms.Button)
        Dim keyText As String = ""
        Dim isAddBrackets As Boolean = True
        If specialButton IsNot Nothing Then
            Select Case specialButton.Name
                Case "BtnPct"
                    keyText = "%"
                Case "BtnCaret"
                    keyText = "^"
                Case "BtnPlus"
                    keyText = "+"
                Case "BtnTilde"
                    keyText = "~"
                Case "BtnOpenBracket"
                    keyText = "("
                Case "BtnCloseBracket"
                    keyText = "("
                Case "BtnAlt"
                    keyText = "%"
                    isAddBrackets = False
                Case "BtnBackspace"
                    keyText = "BACKSPACE"
                Case "BtnBacktab"
                    keyText = "+{TAB}"
                    isAddBrackets = False
                Case "BtnCloseCurlyBracket"
                    keyText = "}"
                Case "BtnCtrl"
                    keyText = "^"
                    isAddBrackets = False
                Case "BtnDelete"
                    keyText = "DELETE"
                Case "BtnDownArrow"
                    keyText = "DOWN"
                Case "BtnEnd"
                    keyText = "END"
                Case "BtnHome"
                    keyText = "HOME"
                Case "BtnInsert"
                    keyText = "INSERT"
                Case "BtnLeftArrow"
                    keyText = "LEFT"
                Case "BtnOpenCurlyBracket"
                    keyText = "{"
                Case "BtnPageDown"
                    keyText = "PGDN"
                Case "BtnPageUp"
                    keyText = "PGUP"
                Case "BtnReturn"
                    keyText = "ENTER"
                Case "BtnRightArrow"
                    keyText = "RIGHT"
                Case "BtnTab"
                    keyText = "TAB"
                Case "BtnUpArrow"
                    keyText = "UP"
            End Select
            Dim pos As Long
            pos = TxtValue.SelectionStart
            If isAddBrackets Then
                TxtValue.Text = TxtValue.Text.Substring(0, pos) + "{" + keyText + "}" + Mid(TxtValue.Text, pos + 1)
                TxtValue.SelectionStart = pos + Len(keyText) + 2
            Else
                TxtValue.Text = TxtValue.Text.Substring(0, pos) + keyText + Mid(TxtValue.Text, pos + 1)
                TxtValue.SelectionStart = pos + Len(keyText) + 2
            End If
        End If
    End Sub
    Private Sub TxtString_TextChanged(sender As Object, e As EventArgs) Handles TxtValue.TextChanged
        Dim iStrLen As Long
        Dim prevText As String
        Dim strChar As String
        Dim iChar As Integer
        Dim specChar As String
        iStrLen = TxtValue.TextLength
        prevText = ""
        For iChar = 1 To iStrLen
            strChar = Mid(TxtValue.Text, iChar, 1)
            If strChar = "{" Then
                specChar = ""
                ' special_char    ' Special char (eg Return)
                While strChar <> "}" And iChar < iStrLen
                    iChar += 1
                    strChar = Mid(TxtValue.Text, iChar, 1)
                    If strChar <> "}" Then
                        specChar &= strChar
                    End If
                End While
                Select Case specChar
                    Case "Tab"
                        prevText &= Chr(9)
                End Select
            Else
                prevText &= strChar    ' Regular char
            End If
        Next iChar
        TxtPreview.Text = prevText
    End Sub
    Private Sub MnuCut_Click(menuItem As Object, e As EventArgs) Handles MnuCut.Click
        GetSourceControl(menuItem).Cut()
    End Sub
    Private Sub MnuCopy_Click(menuItem As Object, e As EventArgs) Handles MnuCopy.Click
        GetSourceControl(menuItem).Copy()
    End Sub
    Private Sub MnuPaste_Click(menuItem As Object, e As EventArgs) Handles MnuPaste.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Paste()
        End If
    End Sub
    Private Sub MnuDelete_Click(menuItem As Object, e As EventArgs) Handles MnuDelete.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = ""
        End If
    End Sub
    Private Sub MnuSelectAll_Click(menuItem As Object, e As EventArgs) Handles MnuSelectAll.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            If _textBox IsNot Nothing Then
                _textBox.SelectAll()
            End If
        End If
    End Sub
    Private Sub MnuLowercase_Click(menuItem As Object, e As EventArgs) Handles MnuLowercase.Click
        NTextUtil.ConvertSelectedTextToLowercase(GetSourceControl(menuItem))
    End Sub
    Private Sub MnuUpperCase_Click(menuItem As Object, e As EventArgs) Handles MnuUpperCase.Click
        NTextUtil.ConvertSelectedTextToUpperCase(GetSourceControl(menuItem))
    End Sub
    Private Sub MnuTitleCase_Click(menuItem As Object, e As EventArgs) Handles MnuTitleCase.Click
        NTextUtil.ConvertSelectedTextToTitleCase(GetSourceControl(menuItem))
    End Sub
    Private Sub MnuToggleCase_Click(menuItem As Object, e As EventArgs) Handles MnuToggleCase.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = NTextUtil.ToggleText(_textBox.SelectedText)
        End If
    End Sub
    Private Sub FrmEditButton_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.EditButtonPos = SetFormPos(Me)
        My.Settings.Save()
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
    End Sub
    Private Sub BtnField_Click(sender As Object, e As EventArgs) Handles BtnField.Click
        If CbDbValue.SelectedIndex >= 0 Then
            Dim _pos As Long
            _pos = TxtValue.SelectionStart
            Dim _sep As String = If(String.IsNullOrEmpty(TxtSep.Text), " ", TxtSep.Text)
            Dim _remains As String = Regex.Replace(TxtSl.Text, "(?:[0-9][0-9]*),(?:[0-9][0-9]*)|(?:[0-9][0-9]*)", "")
            Dim _word As Integer = If(IsNumeric(TxtWordNo.Text), CInt(TxtWordNo.Text), -1)
            Dim subStart As String = String.Empty
            Dim subEnd As String = String.Empty
            Dim splitStart As String = String.Empty
            Dim splitEnd As String = String.Empty

            If ChkSubstring.Checked And String.IsNullOrWhiteSpace(_remains) Then
                subStart = If(ChkSubstring.Checked, SUB_START_MARKER, "")
                subEnd = If(ChkSubstring.Checked, SUB_MID_MARKER & TxtSl.Text & SUB_END_MARKER, "")
            End If
            If ChkSplit.Checked And IsNumeric(TxtWordNo.Text) Then
                splitStart = If(ChkSplit.Checked, SPLIT_START_MARKER, "")
                splitEnd = If(ChkSplit.Checked, SPLIT_MID_MARKER & TxtWordNo.Text & "," & _sep & ", " & If(RbSingle.Checked, "-1", "2") & SPLIT_END_MARKER, "")
            End If

            TxtValue.Text = TxtValue.Text.Substring(0, _pos) & subStart & splitStart & FIELD_START_MARKER & CbDbValue.SelectedItem & FIELD_END_MARKER & splitEnd & subEnd & Mid(TxtValue.Text, _pos + 1)
            TxtValue.SelectionStart = _pos + Len(CbDbValue.SelectedItem) + 2
            End If
    End Sub
#End Region
#Region "subroutines"
    Private Function IsValidated() As Boolean
        Dim isOK As Boolean = True
        If txtCaption.TextLength = 0 Then
            LblErrs.Text &= "Missing Caption | "
            isOK = False
        End If
        If TxtValue.TextLength = 0 Then
            LblErrs.Text &= "Missing Value | "
            isOK = False
        End If
        Return isOK
    End Function
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub
#End Region
End Class

