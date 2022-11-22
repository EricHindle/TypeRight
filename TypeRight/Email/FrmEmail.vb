Imports System.Collections.Generic
Imports System.Linq
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
        LogUtil.Info("Email ----------", MyBase.Name)
        GetFormPos(Me, My.Settings.EmailFormPos)
        SetAccountsDatasource()
        oSenderRow = GetSenderRowById(_senderId)
        TxtFromName.Text = oSenderRow.FirstName & " " & oSenderRow.LastName
        SetSplitterDistance()
        ButtonUtil.RemovePanelButtons(PnlButtons)
        oButtonList = ButtonUtil.LoadGroupButtons(_groupId)
        Dim _lastRow As Integer = ButtonUtil.FillButtonPanel(PnlButtons, oButtonList, 0)
        oButtonList = ButtonUtil.LoadSenderButtons(_senderId, oSenderRow)
        ButtonUtil.FillButtonPanel(PnlButtons, oButtonList, _lastRow + 1)
        For Each _btn As Nbutton In PnlButtons.Controls
            RemoveHandler _btn.Button1.Click, AddressOf Button_Click
            AddHandler _btn.Button1.Click, AddressOf Button_Click
        Next
        isLoading = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
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
                strKeyText = ButtonUtil.ApplySubstrings(ButtonUtil.GetDBFields(strKeyText, oSenderRow)).Replace("{ENTER}", vbCrLf)
                Clipboard.SetText(strKeyText)
                TxtText.SelectedText = strKeyText
            End If
        End If
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        DisplayProgress("Sending Email",, True)
        BtnSend.Enabled = False
        If cbSmtpAccounts.SelectedIndex >= 0 Then
            Dim _smtp As Smtp = GetSmtpById(cbSmtpAccounts.SelectedValue)
            If String.IsNullOrWhiteSpace(TxtTo.Text) Or String.IsNullOrWhiteSpace(TxtSubject.Text) Or String.IsNullOrWhiteSpace(TxtText.Text) Then
                DisplayProgress("Missing value(s). Mail not sent.",, True)
            Else
                If EmailUtil.SendMailViaSMTP(_smtp, TxtTo.Text, {}, TxtSubject.Text, TxtText.Text, TxtFromName.Text) Then
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
    End Sub
    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtTo.DragEnter,
                                                                                                                 TxtSubject.DragEnter,
                                                                                                                 TxtFromName.DragEnter,
                                                                                                                 TxtText.DragEnter
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            e.Effect = DragDropEffects.Copy
        Else
            If e.Data.GetDataPresent(DataFormats.Text) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub
    Private Sub BtnSmtp_Click(sender As Object, e As EventArgs) Handles BtnSmtp.Click
        Me.Hide()
        Using _smtpForm As New FrmSmtpAccounts
            _smtpForm.ShowDialog()
        End Using
        SetAccountsDatasource()
        Me.Show()
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
        SplitContainer1.SplitterDistance = SplitContainer1.Width - (iColCt * iButtonWidth) - SplitContainer1.SplitterWidth
    End Sub

    Private Sub BtnClearText_Click(sender As Object, e As EventArgs) Handles BtnClearText.Click
        TxtText.Text = ""
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        BtnSend.Enabled = True
    End Sub
#End Region
End Class