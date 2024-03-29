﻿' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Windows.Forms
Imports HindlewareLib.Logging

Public Class FrmGroupMaint
#Region "database variables"
    Private oBtnGrp As ButtonGroup
#End Region
#Region "properties"
    Private _button As NbuttonControlLibrary.Nbutton
    Public Property SenderButton() As NbuttonControlLibrary.Nbutton
        Get
            Return _button
        End Get
        Set(ByVal value As NbuttonControlLibrary.Nbutton)
            _button = value
        End Set
    End Property
    Private _action As Integer
    Public Property Action() As Integer
        Get
            Return _action
        End Get
        Set(ByVal value As Integer)
            _action = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim iActGrp As Integer
        iActGrp = iCurrGrp
        DialogResult = DialogResult.OK
        Select Case _action
            Case GroupAction.GRP_TRANS
                If cmbGroups.SelectedIndex = -1 Then
                    MsgBox("Select group to transfer to", vbExclamation, "Missing Information")
                    Exit Sub
                End If
                If cmbGroups.SelectedValue = _button.Group Then
                    MsgBox("Cannot transfer to same group", vbExclamation, "Transfer error")
                    Exit Sub
                End If
                If _button Is Nothing Then
                    MsgBox("Button to transfer not found", vbExclamation, "Transfer error")
                    Exit Sub
                End If
                Dim selectedGroup As Integer = cmbGroups.SelectedValue
                If ChkCopyBtn.Checked Then
                    Dim newbuttonId As Integer = InsertButton(_button)
                    UpdateButtonGroupOnButton(selectedGroup, newbuttonId)
                Else
                    UpdateButtonGroupOnButton(selectedGroup, _button.Id)
                End If
                ResequenceButtons(_button.Group)
                ResequenceButtons(selectedGroup)
            Case GroupAction.GRP_ADD
                InsertButtonGroup(TxtNewGroup.Text)
            Case GroupAction.GRP_CHG
                UpdateButtonGroupName(TxtGrpName.Text, iActGrp)
            Case GroupAction.GRP_RMV
                If GetButtonsByGroup(iActGrp).Rows.Count = 0 Then
                    DeleteButtonGroup(iActGrp)
                Else
                    MsgBox("There are buttons in the group. Group cannot be removed", MsgBoxStyle.Exclamation, "Forbidden action")
                    DialogResult = DialogResult.Cancel
                End If
        End Select

        Close()
    End Sub
    Private Sub FrmGroupMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info(My.Resources.LOADING, MyBase.Name)
        GetFormPos(Me, My.Settings.GroupMaintPos)
        ButtongroupsTableAdapter.Fill(TypeRightDataSet.buttongroups)
        ClearForm()
        TxtGrpNumber.Text = CStr(iCurrGrp)
        oBtnGrp = GetButtonGroupById(iCurrGrp)
        TxtGrpName.Text = oBtnGrp.GroupName
        Select Case _action
            Case GroupAction.GRP_ADD
                LogUtil.Info("Adding new group", MyBase.Name)
                BtnUpdate.Text = "Add"
                BtnCopy.Visible = True
                LblNewGroupName.Visible = True
                TxtNewGroup.Visible = True
            Case GroupAction.GRP_CHG
                LogUtil.Info("Amending group name", MyBase.Name)
                BtnUpdate.Text = "Update"
            Case GroupAction.GRP_RMV
                LogUtil.Info("Removing group", MyBase.Name)
                BtnUpdate.Text = "Remove"
            Case GroupAction.GRP_TRANS
                LogUtil.Info("Transferring button", MyBase.Name)
                If _button IsNot Nothing Then
                    Nbutton1.Caption = _button.Caption
                    Nbutton1.Font = _button.Font
                End If
                Nbutton1.Visible = True
                LblTrans.Visible = True
                cmbGroups.Visible = True
                LblThisBtn.Visible = True
                ChkCopyBtn.Visible = True
                BtnUpdate.Text = "Transfer"
        End Select
    End Sub
    Private Sub FrmGroupMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
        My.Settings.GroupMaintPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
#End Region
#Region "subroutines"
    Private Sub ClearForm()
        BtnCopy.Visible = False
        LblThisBtn.Visible = False
        Nbutton1.Visible = False
        LblTrans.Visible = False
        TxtNewGroup.Visible = False
        LblNewGroupName.Visible = False
        cmbGroups.Visible = False
        TxtGrpNumber.Text = ""
        TxtGrpName.Text = ""
        ChkCopyBtn.Visible = False
    End Sub
    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        TxtNewGroup.Text = TxtGrpName.Text
    End Sub
    Private Sub ChkCopyBtn_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCopyBtn.CheckedChanged
        LblTrans.Text = If(ChkCopyBtn.Checked, "Copy ", "Move ") & "button to group"
    End Sub
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub
#End Region
End Class