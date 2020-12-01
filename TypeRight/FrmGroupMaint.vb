Imports System.ComponentModel

Public Class FrmGroupMaint
    Private _action As GroupAction
    Public Property Action() As Integer
        Get
            Return _action
        End Get
        Set(ByVal value As Integer)
            _action = value
        End Set
    End Property
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim iActGrp As Integer
        iActGrp = iCurrGrp * -1
        If iGrpAction = GroupAction.GRP_ADD Then
            DeleteButtonGroup(iActGrp)
        End If
        TidyAndClose()
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim iActGrp As Integer
        iActGrp = iCurrGrp * -1
        Dim btnGrpRow As TypeRightDataSet.buttongroupsRow = GetButtonGroup(iActGrp)
        Select Case iGrpAction
            Case GroupAction.GRP_TRANS
                If cmbGroups.SelectedIndex = -1 Then
                    MsgBox("Select group to transfer to", vbExclamation)
                    Exit Sub
                End If
                If cmbGroups.SelectedValue = iCurrGrp * -1 Then
                    MsgBox("Cannot transfer to same group", vbExclamation)
                    Exit Sub
                End If
                Dim btnRow As TypeRightDataSet.buttonRow = GetButtonByGroupAndSeq(iActGrp, iCurrBtn)
                If btnRow Is Nothing Then
                    MsgBox("Button to transfer not found!", vbCritical)
                End If
                UpdateButtonGroupOnButton(iActGrp, btnRow.buttonId)
                'For iBtCt = iButtonCt To 1 Step -1
                '            Unload frmButtonList.cmdText(iBtCt)
                'Next iBtCt
                '   ReSeqButtons
                iButtonCt = 0
        '        frmButtonList.LoadButtons frmButtonList.cboNames.ItemData(frmButtonList.cboNames.ListIndex)
        'frmButtonList.DrawButtons
            Case GroupAction.GRP_ADD
                UpdateButtonGroupName(TxtGrpName.Text, iActGrp)
                                'FrmButtonList.cboNames.AddItem("** " & TxtGrpName.Text & " **")
                'FrmButtonList.cboNames.ItemData(frmButtonList.cboNames.NewIndex) = !GroupNo * -1
                '        frmButtonList.cboNames.ListIndex = frmButtonList.cboNames.NewIndex
            Case GroupAction.GRP_CHG
                UpdateButtonGroupName(TxtGrpName.Text, iActGrp)
                                'FrmButtonList.cboNames.RemoveItem(frmButtonList.cboNames.ListIndex)
                'FrmButtonList.cboNames.AddItem("** " & TxtGrpName.Text & " **")
                'FrmButtonList.cboNames.ItemData(frmButtonList.cboNames.NewIndex) = !GroupNo * -1
                '        frmButtonList.cboNames.ListIndex = frmButtonList.cboNames.NewIndex
            Case GroupAction.GRP_RMV
                DeleteButtonGroup(iActGrp)
                'If frmButtonList.cboNames.ListCount > 0 Then
                '    frmButtonList.cboNames.ListIndex = 0
                '    frmButtonList.cmdReDraw_Click
                'End If
        End Select
        TidyAndClose()
    End Sub
    Private Sub Form_Load()
        Dim iActGrp As Integer
        iActGrp = iCurrGrp * -1
        Select Case iGrpAction
            Case GroupAction.GRP_ADD
                LblThisBtn.Visible = False
                Nbutton1.Visible = False
                LblConfirm.Text = ""
                LblNewGroup.Visible = False
                TxtNewGroup.Visible = False
                cmbGroups.Visible = False
                LblTrans.Visible = False
                TxtNewGroup.Enabled = False
                cmbGroups.Enabled = False
                TxtGrpName.Enabled = True
                iActGrp = InsertButtonGroup("New")
                iCurrGrp = iActGrp * -1
                TxtGrpNumber.Text = CStr(iActGrp)
            Case GroupAction.GRP_CHG
                LblThisBtn.Visible = False
                Nbutton1.Visible = False
                LblConfirm.Text = ""
                LblNewGroup.Visible = True
                TxtNewGroup.Visible = True
                cmbGroups.Visible = False
                LblTrans.Visible = False
                TxtNewGroup.Enabled = True
                cmbGroups.Enabled = False
                TxtGrpName.Enabled = False
                ' Put current value in text boxes
                Dim bgRow As TypeRightDataSet.buttongroupsRow = GetButtonGroup(iActGrp)
                If bgRow IsNot Nothing Then
                    TxtGrpNumber.Text = iActGrp
                    TxtGrpName.Text = bgRow.groupname
                End If
            Case GroupAction.GRP_TRANS
                '               NButton1.Text = frmButtonList.cmdText(iCurrBtn).Text
                LblThisBtn.Visible = True
                Nbutton1.Visible = True
                LblConfirm.Text = ""
                LblNewGroup.Visible = False
                TxtNewGroup.Visible = False
                cmbGroups.Visible = True
                LblTrans.Visible = True
                TxtNewGroup.Enabled = False
                cmbGroups.Enabled = True
                TxtGrpName.Enabled = False
            Case GroupAction.GRP_RMV
                LblThisBtn.Visible = False
                Nbutton1.Visible = False
                LblNewGroup.Visible = False
                TxtNewGroup.Visible = False
                cmbGroups.Visible = False
                LblTrans.Visible = False
                TxtNewGroup.Enabled = False
                cmbGroups.Enabled = False
                TxtGrpName.Enabled = False
                ' Put current value in text boxes
                Dim bgRow As TypeRightDataSet.buttongroupsRow = GetButtonGroup(iActGrp)
                If bgRow IsNot Nothing Then
                    TxtGrpNumber.Text = iActGrp
                    TxtGrpName.Text = bgRow.groupname
                End If
                Dim btnTable As TypeRightDataSet.buttonDataTable = GetButtonsByGroup(iActGrp)
                If btnTable.Rows.Count = 0 Then
                    LblConfirm.Text = "** Click Update to confirm delete **"
                Else
                    LblConfirm.Text = "** Group still has buttons **"
                    BtnUpdate.Enabled = False
                End If
        End Select

    End Sub

    Private Sub TidyAndClose()
        iGrpAction = GroupAction.GRP_TRANS
        LblNewGroup.Visible = False
        TxtNewGroup.Visible = False
        cmbGroups.Visible = False
        LblTrans.Visible = False
        BtnUpdate.Enabled = True
        Me.Close()
    End Sub
    Private Sub FrmGroupMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.GroupMaintPos)
        Me.ButtongroupsTableAdapter.Fill(Me.TypeRightDataSet.buttongroups)
    End Sub

    Private Sub Nbutton1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub FrmGroupMaint_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.GroupMaintPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
End Class