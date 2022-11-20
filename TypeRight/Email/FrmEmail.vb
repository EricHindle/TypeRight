Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports NbuttonControlLibrary
Imports TypeRight.TypeRightDataSetTableAdapters

Public Class FrmEmail
    Private senderButtonList As New List(Of Nbutton)
    Private _senderId As Integer
    Private isLoading As Boolean = True
    Private _senderRow As TypeRightDataSet.sendersRow
    Private _smtpTable As TypeRightDataSet.smtpDataTable
    Public Property SenderId() As Integer
        Get
            Return _senderId
        End Get
        Set(ByVal value As Integer)
            _senderId = value
        End Set
    End Property
    Private _groupId As Integer
    Public Property GroupId() As Integer
        Get
            Return _groupId
        End Get
        Set(ByVal value As Integer)
            _groupId = value
        End Set
    End Property
    Private Sub FrmEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        _smtpTable = GetSmtp()
        cbEmailUsername.DataSource = _smtpTable
        cbEmailUsername.DisplayMember = "smtpUsername"
        cbEmailUsername.ValueMember = "smtpId"
        _senderRow = GetSenderRowById(_senderId)
        TxtFromName.Text = _senderRow.FirstName & " " & _senderRow.LastName
        SplitContainer1.SplitterDistance = SplitContainer1.Width - (iColCt * iButtonWidth) - SplitContainer1.SplitterWidth
        ButtonUtil.RemovePanelButtons(SenderButtonPanel)
        senderButtonList = ButtonUtil.LoadGroupButtons(_groupId)
        Dim _lastRow As Integer = ButtonUtil.FillButtonPanel(SenderButtonPanel, senderButtonList, 0)
        senderButtonList = ButtonUtil.LoadSenderButtons(_senderId)
        ButtonUtil.FillButtonPanel(SenderButtonPanel, senderButtonList, _lastRow)
        For Each _btn As Nbutton In SenderButtonPanel.Controls
            RemoveHandler _btn.Button1.Click, AddressOf Button_Click
            AddHandler _btn.Button1.Click, AddressOf Button_Click
        Next
        isLoading = False
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmEmail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub

    Private Sub FrmEmail_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Not isLoading Then
            SplitContainer1.SplitterDistance = SplitContainer1.Width - (iColCt * iButtonWidth) - SplitContainer1.SplitterWidth
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
            If isPro And _nButton.Encrypt Then
                strKeyText = oNCrypter.DecryptData(strKeyText)
            End If
            strKeyText = ButtonUtil.GetDBFields(strKeyText)
            strKeyText = ButtonUtil.ApplySubstrings(strKeyText)
            Clipboard.SetText(strKeyText.Replace("{ENTER}", vbCrLf))
            TxtText.SelectedText = strKeyText.Replace("{ENTER}", vbCrLf)
        End If
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Dim _smtp As New Smtp
        If cbEmailUsername.SelectedIndex >= 0 Then
            Dim _smtpId As Integer = cbEmailUsername.SelectedValue
            _smtp = GetSmtpById(_smtpId)
            If String.IsNullOrWhiteSpace(TxtTo.Text) Or String.IsNullOrWhiteSpace(TxtSubject.Text) Or String.IsNullOrWhiteSpace(TxtText.Text) Then
                MsgBox("Missing value(s). Mail not sent.", MsgBoxStyle.Exclamation, "Error")
            Else
                If EmailUtil.SendMailViaSMTP(_smtp, TxtTo.Text, {}, TxtSubject.Text, TxtText.Text, TxtFromName.Text) Then
                    MsgBox("Mail sent OK.", MsgBoxStyle.Information, "OK")
                Else
                    MsgBox("Mail failed.", MsgBoxStyle.Exclamation, "Error")
                End If
            End If
        Else
            MsgBox("From account not selected. Mail not sent.", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub


End Class