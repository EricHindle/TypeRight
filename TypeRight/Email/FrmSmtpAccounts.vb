﻿' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Windows.Forms
Imports HindlewareLib.Domain.Objects
Imports HindlewareLib.Logging
Public Class FrmSmtpAccounts
#Region "variables"
    Private _smtpTable As TypeRightDataSet.smtpDataTable
    Private isLoading As Boolean = False
#End Region
#Region "form control handlers"
    Private Sub FrmSmtpAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        LogUtil.Info("SMTP Account Maint ----", MyBase.Name)
        GetFormPos(Me, My.Settings.SmtpFormPos)
        ClearForm()
        isLoading = False
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        DisplayProgress("Adding SMTP Account details", , True)
        If IsValidAccount() Then
            Dim _username As String = CbSmtpAccount.Text
            Dim _smtp As SmtpAccount = SmtpAccountBuilder.AnSmtpAccount.StartingWith(-1,
                                                               _username,
                                                               TxtPassword.Text,
                                                               TxtHost.Text,
                                                               TxtPort.Text,
                                                               chkSsl.Checked,
                                                               chkCredReq.Checked).Build
            If InsertSmtp(_smtp) Then
                DisplayProgress("Added OK",, True)
            Else
                DisplayProgress("Insert failed.",, True)
            End If
            SetAccountsDatasource()
        End If

    End Sub
    Private Sub FrmSmtpAccounts_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
        My.Settings.SmtpFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub CbSmtpAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSmtpAccount.SelectedIndexChanged
        If Not isLoading Then
            If CbSmtpAccount.SelectedIndex >= 0 Then
                Dim _smtp As SmtpAccount = GetSmtpById(CbSmtpAccount.SelectedValue)
                TxtHost.Text = _smtp.Host
                TxtPort.Text = _smtp.Port
                TxtPassword.Text = _smtp.Password
                chkCredReq.Checked = _smtp.IsCredentialsRequired
                chkSsl.Checked = _smtp.IsEnableSsl
                BtnUpdate.Enabled = True
                BtnDelete.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DisplayProgress("Deleting SMTP Account details",, True)
        Dim _id As Integer = CbSmtpAccount.SelectedValue
        If _id >= 0 Then
            If MsgBox("Confirm deleting SMTP account details", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If GetSmtpById(_id).SmtpId >= 0 Then
                    If DeleteSmtp(_id) Then
                        DisplayProgress("SMTP Account details deleted", , True)
                    Else
                        DisplayProgress("Delete failed.",, True)
                    End If
                    ClearForm()
                Else
                    DisplayProgress("SMTP Account details not found",, True)
                End If
            Else
                DisplayProgress(" ** Delete NOT confirmed", True, True)
            End If
        Else
            DisplayProgress(" ** SMTP Account not selected", True, True)
        End If
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        DisplayProgress("Updating SMTP Account details", , True)
        If IsValidAccount() Then
            Dim _id As Integer = CbSmtpAccount.SelectedValue
            Dim _smtp As SmtpAccount = GetSmtpById(_id)
            If _smtp.SmtpId >= 0 Then
                _smtp = SmtpAccountBuilder.AnSmtpAccount.StartingWith(_smtp) _
                                    .WithPassword(TxtPassword.Text) _
                                    .WithHost(TxtHost.Text) _
                                    .WithPort(TxtPort.Text) _
                                    .WithEnableSsl(chkSsl.Checked) _
                                    .WithRequireCredentials(chkCredReq.Checked) _
                                    .Build
                If UpdateSmtp(_smtp) Then
                    DisplayProgress("SMTP Account details updated",, True)
                Else
                    DisplayProgress("Update failed.",, True)
                End If
                SetAccountsDatasource()
            Else
                DisplayProgress("SMTP Account details not found", , True)
            End If
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub ClearForm()
        SetAccountsDatasource()
        CbSmtpAccount.SelectedIndex = -1
        TxtHost.Text = ""
        TxtPort.Text = ""
        TxtPassword.Text = ""
        chkCredReq.Checked = False
        chkSsl.Checked = False
        BtnDelete.Enabled = False
        BtnUpdate.Enabled = False
        DisplayProgress("")
    End Sub
    Private Function IsValidAccount() As Boolean
        Dim isOk As Boolean = True
        If String.IsNullOrWhiteSpace(TxtPort.Text) OrElse Not IsNumeric(TxtPort.Text) Then
            DisplayProgress(" **Invalid Port", True, False)
            isOk = False
        End If
        If CbSmtpAccount.SelectedIndex = -1 AndAlso String.IsNullOrWhiteSpace(CbSmtpAccount.Text) Then
            DisplayProgress(" **Missing Account", True, False)
            isOk = False
        End If
        If String.IsNullOrWhiteSpace(TxtPassword.Text) Then
            DisplayProgress(" **Missing Password", True, False)
            isOk = False
        End If
        If String.IsNullOrWhiteSpace(TxtHost.Text) Then
            DisplayProgress(" **Missing Host", True, False)
            isOk = False
        End If
        Return isOk
    End Function
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub
    Private Sub SetAccountsDatasource()
        _smtpTable = GetSmtpTable()
        CbSmtpAccount.DataSource = _smtpTable
        CbSmtpAccount.DisplayMember = "smtpUsername"
        CbSmtpAccount.ValueMember = "smtpId"
    End Sub

#End Region
End Class