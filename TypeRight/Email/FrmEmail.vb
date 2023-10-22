' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.Generic
Imports System.Reflection
Imports System.Windows.Forms
Imports NbuttonControlLibrary

Public Class FrmEmail
#Region "constants"
    Private Const MAILTO As String = "mailto:"
    Private Const SUBJECT As String = "subject"
#End Region
#Region "variables"
    Private oButtonList As New List(Of Nbutton)
    Private isLoading As Boolean = True
    Private oSenderRow As TypeRightDataSet.sendersRow
    Private oSmtpTable As TypeRightDataSet.smtpDataTable
    Private _attachmentList As String()
    Private ReadOnly aAttachList As New List(Of String)

#End Region
#Region "properties"
    Private _groupId As Integer
    Private _senderId As Integer
    Public Property SenderId() As Integer
        Get
            Return _senderId
        End Get
        Set(ByVal value As Integer)
            _senderId = value
        End Set
    End Property
    Public Property GroupId() As Integer
        Get
            Return _groupId
        End Get
        Set(ByVal value As Integer)
            _groupId = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub FrmEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        LogUtil.Info("Email ".PadRight(40, "-"), MyBase.Name)
        GetFormPos(Me, My.Settings.EmailFormPos)
        SetAccountsDatasource()
        oSenderRow = GetSenderRowById(_senderId)
        TxtFromName.Text = oSenderRow.FirstName & " " & oSenderRow.LastName
        SetSplitterDistance()
        RemovePanelButtons(PnlButtons)
        oButtonList = LoadGroupButtons(_groupId)
        Dim _lastRow As Integer = FillButtonPanel(PnlButtons, oButtonList, 0)
        oButtonList = LoadSenderButtons(_senderId, oSenderRow)
        FillButtonPanel(PnlButtons, oButtonList, _lastRow + 1)
        For Each _btn As Nbutton In PnlButtons.Controls
            RemoveHandler _btn.Button1.Click, AddressOf Button_Click
            AddHandler _btn.Button1.Click, AddressOf Button_Click
        Next
        CbAttachList.Items.Clear()
        aAttachList.Clear()
        isLoading = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmEmail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
        My.Settings.EmailFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub FrmEmail_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Not isLoading Then
            SetSplitterDistance()
        End If
    End Sub
    Private Sub BtnPasteTo_Click(sender As Object, e As EventArgs) Handles BtnPasteTo.Click
        TxtTo.SelectedText = Clipboard.GetText
    End Sub
    Private Sub BtnPasteSubject_Click(sender As Object, e As EventArgs) Handles BtnPasteSubject.Click
        TxtSubject.SelectedText = Clipboard.GetText
    End Sub
    Private Sub BtnPasteText_Click(sender As Object, e As EventArgs) Handles BtnPasteText.Click
        TxtText.SelectedText = Clipboard.GetText
    End Sub
    Private Sub Button_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim _button As System.Windows.Forms.Button = TryCast(eventSender, System.Windows.Forms.Button)
        Dim strKeyText As String
        If _button IsNot Nothing Then
            Dim _nButton As Nbutton = _button.Parent
            strKeyText = _nButton.Value
            If Not String.IsNullOrWhiteSpace(strKeyText) Then
                If isPro And _nButton.Encrypt Then
                    strKeyText = oNCrypter.DecryptData(strKeyText)
                End If
                strKeyText = EditFieldValues(GetDBFieldValues(strKeyText, oSenderRow), ReplaceType.None).Replace("{ENTER}", vbCrLf)
                Clipboard.SetText(strKeyText)
                TxtText.SelectedText = strKeyText
            End If
        End If
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        DisplayProgress("Sending Email...",, True)
        BtnSend.Enabled = False
        For Each oAtt As String In CbAttachList.Items
            If My.Computer.FileSystem.FileExists(oAtt) Then
                aAttachList.Add(oAtt)
            End If
        Next
        _attachmentList = aAttachList.ToArray
        If cbSmtpAccounts.SelectedIndex >= 0 Then
            Dim _smtp As Smtp = GetSmtpById(cbSmtpAccounts.SelectedValue)
            If String.IsNullOrWhiteSpace(TxtTo.Text) Or String.IsNullOrWhiteSpace(TxtSubject.Text) Or String.IsNullOrWhiteSpace(TxtText.Text) Then
                DisplayProgress("Missing value(s). Mail not sent.",, True)
            Else
                My.Settings.LastEmailTo = TxtTo.Text
                My.Settings.Save()

                If EmailUtil.SendMailViaSMTP(_smtp, TxtTo.Text, {}, TxtSubject.Text, TxtText.Text, TxtFromName.Text, _attachmentList) Then
                    DisplayProgress("Mail sent OK.", , True)
                Else
                    DisplayProgress("Mail failed.", , True)
                End If
            End If
        Else
            DisplayProgress("From account not selected. Mail not sent.", , True)
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        cbSmtpAccounts.SelectedIndex = -1
        TxtFromName.Text = ""
        TxtSubject.Text = ""
        TxtText.Text = ""
        TxtTo.Text = ""
    End Sub
    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtSubject.DragDrop,
                                                                                           TxtFromName.DragDrop,
                                                                                           TxtText.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim _data As String() = e.Data.GetData(DataFormats.FileDrop)
            Dim _filename As String = _data(0)
            CbAttachList.Items.Add(_filename)
            CbAttachList.SelectedIndex = CbAttachList.Items.Count - 1
        End If
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim _string As String = e.Data.GetData(DataFormats.StringFormat)
            Dim textlen As Integer = oBox.TextLength
            Dim startpos As Integer = oBox.SelectionStart
            If textlen = 0 Then
                oBox.Text = _string.Trim
            Else
                If startpos = 0 Then
                    oBox.SelectedText = _string.TrimStart
                Else
                    oBox.SelectedText = _string
                End If
            End If
        End If
        TopMost = True
        BringToFront()
        TopMost = False
    End Sub
    Private Sub TxtTo_DragDrop(sender As Object, e As DragEventArgs) Handles TxtTo.DragDrop
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim _string As String = e.Data.GetData(DataFormats.StringFormat)
            If _string.StartsWith(MAILTO) Then
                _string = _string.Substring(MAILTO.Length)
            End If
            Dim _splitstring1 As String() = Split(_string, "?", 2)
            If _splitstring1.Length > 1 Then
                _string = _splitstring1(0)
                Dim _splitstring2 As String() = Split(_splitstring1(1), "=", 2)
                If _splitstring2(0).ToLower = SUBJECT Then
                    TxtSubject.Text = _splitstring2(1).Trim
                End If
            End If
            TxtTo.Text = _string.Trim
        End If
        TopMost = True
        BringToFront()
        TopMost = False
    End Sub
    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtTo.DragEnter,
                                                                                                                 TxtSubject.DragEnter,
                                                                                                                 TxtFromName.DragEnter,
                                                                                                                 TxtText.DragEnter,
                                                                                                                 CbAttachList.DragEnter
        If sender.GetType = GetType(TextBox) Then
            If e.Data.GetDataPresent(DataFormats.StringFormat) Then
                e.Effect = DragDropEffects.Copy
            ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) And sender.name = TxtText.Name Then
                e.Effect = DragDropEffects.Copy
            ElseIf e.Data.GetDataPresent(DataFormats.Text) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
        If sender.GetType = GetType(ComboBox) AndAlso sender.name = CbAttachList.Name AndAlso
            e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub BtnSmtp_Click(sender As Object, e As EventArgs) Handles BtnSmtp.Click
        Hide()
        Using _smtpForm As New FrmSmtpAccounts
            _smtpForm.ShowDialog()
        End Using
        SetAccountsDatasource()
        Show()
    End Sub
#End Region
#Region "subroutines"
    Private Sub SetAccountsDatasource()
        oSmtpTable = GetSmtpTable()
        cbSmtpAccounts.DataSource = oSmtpTable
        cbSmtpAccounts.DisplayMember = "smtpUsername"
        cbSmtpAccounts.ValueMember = "smtpId"
    End Sub
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub
    Private Sub SetSplitterDistance()
        Try
            SplitContainer1.SplitterDistance = SplitContainer1.Width - (iColCt * iButtonWidth) - SplitContainer1.SplitterWidth
        Catch ex1 As ArgumentOutOfRangeException
            DisplayException(MethodBase.GetCurrentMethod, ex1, "Out of Range")
        Catch ex2 As InvalidOperationException
            DisplayException(MethodBase.GetCurrentMethod, ex2, "Invalid Operation")
        End Try
    End Sub
    Private Sub BtnClearText_Click(sender As Object, e As EventArgs) Handles BtnClearText.Click
        TxtText.Text = ""
    End Sub
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        TxtTo.Text = ""
        TxtSubject.Text = ""
        TxtText.Text = ""
        CbAttachList.Items.Clear()
        BtnSend.Enabled = True
    End Sub
    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles BtnAttach.Click
        Dim oFilename As String = SelectFile()
        If Not String.IsNullOrWhiteSpace(oFilename) Then
            CbAttachList.Items.Add(oFilename)
            DisplayProgress("Attachment " & oFilename & " added", , True)
        End If
        CbAttachList.SelectedIndex = CbAttachList.Items.Count - 1
    End Sub
    Private Sub BtnRmvAtt_Click(sender As Object, e As EventArgs) Handles BtnRmvAtt.Click
        If CbAttachList.SelectedIndex >= 0 Then
            Dim _index As Integer = CbAttachList.SelectedIndex
            CbAttachList.Items.Remove(CbAttachList.SelectedItem)
            If _index < CbAttachList.Items.Count Then
                CbAttachList.SelectedIndex = _index
            Else
                CbAttachList.SelectedIndex = _index - 1
            End If
            DisplayProgress("Attachment removed", , True)
        End If
    End Sub

    Private Sub CbAttachList_DragDrop(sender As Object, e As DragEventArgs) Handles CbAttachList.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim _data As String() = e.Data.GetData(DataFormats.FileDrop)
            Dim _filename As String = _data(0)
            CbAttachList.Items.Add(_filename)
        ElseIf e.Data.GetDataPresent(DataFormats.StringFormat) Then
            CbAttachList.Items.Add(e.Data.GetData(DataFormats.StringFormat))
        End If
        CbAttachList.SelectedIndex = CbAttachList.Items.Count - 1
    End Sub

    Private Sub BtnLastTo_Click(sender As Object, e As EventArgs) Handles BtnLastTo.Click
        TxtTo.Text = My.Settings.LastEmailTo
    End Sub

    Private Sub MnuPaste_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles MnuPaste.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Paste()
        End If
    End Sub
    Private Sub MnuToLower_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles MnuToLower.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = _textBox.SelectedText.ToLower(myCultureInfo)
        End If
    End Sub
    Private Sub MnuToUpper_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles MnuToUpper.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = _textBox.SelectedText.ToUpper(myCultureInfo)
        End If
    End Sub
    Private Sub MnuToTitle_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles MnuToTitle.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = StrConv(_textBox.SelectedText, VbStrConv.ProperCase)
        End If
    End Sub
    Private Sub MnuClear_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles MnuClear.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Text = String.Empty
        End If
    End Sub

    Private Sub MnuToggle_Click(ByVal menuItem As Object, e As EventArgs) Handles MnuToggle.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            Dim inputArray As Char() = _textBox.Text.ToCharArray()
            Dim _toggleText As String = String.Empty
            For Each c As Char In inputArray
                If Char.IsLower(c) Then
                    _toggleText += [Char].ToUpper(c)
                Else
                    _toggleText += [Char].ToLower(c)
                End If
            Next
            _textBox.Text = _toggleText
        End If
    End Sub

#End Region
End Class