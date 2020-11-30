Imports System.Windows.Forms

Public Class FrmEditButton
    Private CtrlOn As Boolean
    Private AltOn As Boolean
    Private iId As Integer
    Private iSeq As Integer
    Private iGrp As Integer

    Private ReadOnly oTextUtil As NTextUtil
    Private _button As NbuttonControlLibrary.Nbutton
    Public Property Button() As NbuttonControlLibrary.Nbutton
        Get
            Return _button
        End Get
        Set(ByVal value As NbuttonControlLibrary.Nbutton)
            _button = value
        End Set
    End Property
    Private Sub FrmEditButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SendersTableAdapter.Fill(Me.TypeRightDataSet.senders)
        grpOpts.Visible = isPro
        chkEncrypt.Checked = False
        If _button IsNot Nothing Then
            iSeq = _button.Sequence
            iGrp = _button.Group
            iId = _button.Id
            Dim btnGrpRow As TypeRightDataSet.buttongroupsRow = GetButtonGroup(iGrp)
            BtnFont.Text = _button.FontName & "(" & CStr(_button.FontSize) & ")"
            If isPro Then
                chkEncrypt.Checked = _button.Encrypt
            End If
            LblBtnSeq.Text = CStr(iSeq)
            LblBtnGrp.Text = btnGrpRow.groupname
            TxtHint.Text = _button.Hint
            TxtValue.Text = If(chkEncrypt.Checked, oNCrypter.DecryptData(_button.Value), _button.Value)
            txtCaption.Text = _button.Caption
            BtnFont.Font = _button.Font
        Else

        End If

        'If bUserDefinedGroup Then
        '    LblDbField.Visible = False
        '    CbDbValue.Visible = False
        'Else
        '    LblDbField.Visible = True
        '    CbDbValue.Visible = True
        'End If
        Dim oTextUtil As New NTextUtil
        CtrlOn = False
        AltOn = False
    End Sub
    Private Sub CbDBValue_Click()
        Dim pos As Long
        pos = TxtValue.SelectionStart
        TxtValue.Text = TxtValue.Text.Substring(0, pos) + "{" + Trim(CbDbValue.Text) + "}" + TxtValue.Text.Substring(pos + 1)
        TxtValue.SelectionStart = pos + Trim(CbDbValue.Text).Length + 2
    End Sub
    Private Sub BtnFont_Click(sender As Object, e As EventArgs) Handles BtnFont.Click
        ' Set Cancel to True
        With FontDialog1
            .FontMustExist = True
            .Font = BtnFont.Font
            .ShowDialog()
        End With
        With BtnFont
            .Font = FontDialog1.Font
            .Text = .Font.Name & "(" & CStr(.Font.Size) & ")"
        End With
    End Sub
    Private Sub BtnCancel_Click() Handles BtnCancel.Click
        Me.Close()
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click

        Dim isEncrypted As Boolean
        Dim strNewText As String
        If isValidated() Then




            If isPro And chkEncrypt.Checked Then
                isEncrypted = True
                strNewText = oNCrypter.EncryptData(TxtValue.Text)
            Else
                isEncrypted = False
                strNewText = TxtValue.Text
            End If
            If bUserDefinedGroup Then
                '    iBtnGrp = FrmButtonList.cbNames.ItemData(iListidx) * -1
                '    iOffset = 0
            Else
                '    iBtnGrp = 0
                '    iOffset = iDbBtnCt
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
            Dim oBtn As TypeRightDataSet.buttonRow = GetButtonByGroupAndSeq(iGrp, iSeq)
            If oBtn IsNot Nothing Then
                UpdateButton(oBtn.buttonGroup, oBtn.buttonSeq, txtCaption.Text, TxtHint.Text, strNewText, BtnFont.Font.Name, BtnFont.Font.Bold, BtnFont.Font.Size, BtnFont.Font.Italic, isEncrypted, oBtn.buttonId)
            End If
            Me.Close()
        End If
    End Sub
    Private Function isValidated() As Boolean
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
                                                                                btnCaret.Click,
                                                                                BtnPlus.Click,
                                                                                BtnTilde.Click,
                                                                                BtnOpenBracket.Click,
                                                                                BtnCloseBracket.Click

        Dim specialButton As Windows.Forms.Button = TryCast(sender, Windows.Forms.Button)
        Dim keyText As String = ""
        Dim isAddBrackets As Boolean = True
        Select Case specialButton.Name
            Case "BtnPct"
                keyText = "%"
            Case "btnCaret"
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
    Private Sub CutToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        GetSourceControl(menuItem).Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        GetSourceControl(menuItem).Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Paste()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = ""
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            If _textBox IsNot Nothing Then
                _textBox.SelectAll()
            End If
        End If
    End Sub

    Private Sub LowercaseToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles LowercaseToolStripMenuItem.Click
        NTextUtil.ConvertSelectedTextToLowercase(GetSourceControl(menuItem))
    End Sub

    Private Sub UPPERCASEToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles UPPERCASEToolStripMenuItem.Click
        NTextUtil.ConvertSelectedTextToUpperCase(GetSourceControl(menuItem))
    End Sub

    Private Sub TitleCaseToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles TitleCaseToolStripMenuItem.Click
        NTextUtil.ConvertSelectedTextToTitleCase(GetSourceControl(menuItem))
    End Sub

    Private Sub TOGGLECASEToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles TOGGLECASEToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = NTextUtil.ToggleText(_textBox.SelectedText)
        End If
    End Sub

End Class