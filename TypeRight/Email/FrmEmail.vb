Imports System.Collections.Generic
Imports System.Windows.Forms
Imports NbuttonControlLibrary

Public Class FrmEmail
#Region "variables"
    Private senderButtonList As New List(Of Nbutton)
    Private isLoading As Boolean = True
    Private _senderRow As TypeRightDataSet.sendersRow
    Private _smtpTable As TypeRightDataSet.smtpDataTable
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
        GetFormPos(Me, My.Settings.EmailFormPos)

        SetAccountsDatasource()
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

    Private Sub SetAccountsDatasource()
        _smtpTable = GetSmtpTable()
        cbSmtpAccounts.DataSource = _smtpTable
        cbSmtpAccounts.DisplayMember = "smtpUsername"
        cbSmtpAccounts.ValueMember = "smtpId"
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
        DisplayProgress("Sending Email",, True)
        Dim _smtp As Smtp
        If cbSmtpAccounts.SelectedIndex >= 0 Then
            Dim _smtpId As Integer = cbSmtpAccounts.SelectedValue
            _smtp = GetSmtpById(_smtpId)
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
            MsgBox("From account not selected. Mail not sent.", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        cbSmtpAccounts.SelectedIndex = -1
        TxtFromName.Text = ""
        TxtSubject.Text = ""
        TxtText.Text = ""
        TxtTo.Text = ""
    End Sub
    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtTo.DragDrop,
                                                                                        TxtSubject.DragDrop,
                                                                                        TxtFromName.DragDrop,
                                                                                        TxtText.DragDrop
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = e.Data.GetData(DataFormats.StringFormat)
            If item.StartsWith("mailto:") Then
                item = item.Substring(7)
            End If
            Dim textlen As Integer = oBox.TextLength
            Dim startpos As Integer = oBox.SelectionStart
            If textlen = 0 Then
                oBox.Text = item.Trim
            Else
                If startpos = 0 Then
                    oBox.SelectedText = item.TrimStart
                Else
                    oBox.SelectedText = item
                End If
            End If
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
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub
#End Region
End Class