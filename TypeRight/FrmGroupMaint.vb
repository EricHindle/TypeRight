Public Class FrmGroupMaint
    Private oBgTa As New TypeRightDataSetTableAdapters.buttongroupsTableAdapter
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim iActGrp As Integer

        iActGrp = iCurrGrp * -1
        If iGrpAction = GRP_ADD Then
            DeleteButtonGroup(iActGrp)
        End If
        TidyAndClose()
    End Sub


    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim iBtCt As Integer
        Dim sSql As String
        Dim iActGrp As Integer

        iActGrp = iCurrGrp * -1

        Dim btnGrpRow As TypeRightDataSet.buttongroupsRow = GetButtonGroup(iActGrp)

        Select Case iGrpAction
            Case GRP_TRANS
                If cmbGroups.ListIndex = -1 Then
                    MsgBox "Select group to transfer to", vbExclamation
            Exit Sub
                End If
                If cmbGroups.ItemData(cmbGroups.ListIndex) = iCurrGrp * -1 Then
                    MsgBox "Cannot transfer to same group", vbExclamation
            Exit Sub
                End If

                Dim btnRow As TypeRightDataSet.buttonsRow = GetButtonByGroupAndSeq(iActGrp, iCurrBtn)


                If btnRow Is Nothing Then
                    MsgBox("Button to transfer not found!", vbCritical)
                End If

                UpdateButtonGroup(iActGrp, btnRow.buttonid)

                'For iBtCt = iButtonCt To 1 Step -1
                '            Unload frmButtonList.cmdText(iBtCt)
                'Next iBtCt

                ReSeqButtons
                iButtonCt = 0
        '        frmButtonList.LoadButtons frmButtonList.cboNames.ItemData(frmButtonList.cboNames.ListIndex)
        'frmButtonList.DrawButtons
            Case GRP_ADD
                With rsBtnGroups
                    If Not .EOF Then
                        !GroupName = txtGrpName.Text
                        .Update
                        frmButtonList.cboNames.AddItem "** " & !GroupName & " **"
                frmButtonList.cboNames.ItemData(frmButtonList.cboNames.NewIndex) = !GroupNo * -1
                        frmButtonList.cboNames.ListIndex = frmButtonList.cboNames.NewIndex
                    End If
                End With
            Case GRP_CHG
                With rsBtnGroups
                    If Not .EOF Then
                        !GroupName = txtNewGroup.Text
                        .Update
                        frmButtonList.cboNames.RemoveItem frmButtonList.cboNames.ListIndex
                frmButtonList.cboNames.AddItem "** " & !GroupName & " **"
                frmButtonList.cboNames.ItemData(frmButtonList.cboNames.NewIndex) = !GroupNo * -1
                        frmButtonList.cboNames.ListIndex = frmButtonList.cboNames.NewIndex
                    End If
                End With
            Case GRP_RMV
                With rsBtnGroups
                    If Not .EOF Then
                        .Delete adAffectCurrent
                frmButtonList.cboNames.RemoveItem frmButtonList.cboNames.ListIndex
            End If
                End With
                If frmButtonList.cboNames.ListCount > 0 Then
                    frmButtonList.cboNames.ListIndex = 0
                    frmButtonList.cmdReDraw_Click
                End If
        End Select
        TidyAndClose()

    End Sub


    Private Sub cmdGrpUpdate_Click()
        Dim iBtCt As Integer
        Dim sSql As String
        Dim iActGrp As Integer
        Dim rsTemp As ADODB.Recordset

        iActGrp = iCurrGrp * -1

        rsBtnGroups.MoveFirst
        rsBtnGroups.Find "GroupNo = " & iActGrp, 0, adSearchForward

    Select Case iGrpAction
            Case GRP_TRANS
                If cmbGroups.ListIndex = -1 Then
                    MsgBox "Select group to transfer to", vbExclamation
            Exit Sub
                End If
                If cmbGroups.ItemData(cmbGroups.ListIndex) = iCurrGrp * -1 Then
                    MsgBox "Cannot transfer to same group", vbExclamation
            Exit Sub
                End If

        Set rsTemp = New ADODB.Recordset
        sSql = "SELECT * From " & sButtons & " WHERE BtnSeq = " & iCurrBtn & " AND BtnGrp = " & iActGrp

                With rsTemp
                    .CursorType = adOpenKeyset
                    .LockType = adLockOptimistic
                    .Open sSql, db, , , adCmdText
            .MoveFirst
                    If .EOF Then
                        MsgBox "Button to transfer not found!", vbCritical
                rsTemp.Close
                Set rsTemp = Nothing
                Exit Sub
                    End If
                    !BtnGrp = cmbGroups.ItemData(cmbGroups.ListIndex)
                    .Update
                End With
        Set rsTemp = Nothing
        For iBtCt = iButtonCt To 1 Step -1
                    Unload frmButtonList.cmdText(iBtCt)
        Next iBtCt

                ReSeqButtons
                iButtonCt = 0
                frmButtonList.LoadButtons frmButtonList.cboNames.ItemData(frmButtonList.cboNames.ListIndex)
        frmButtonList.DrawButtons
            Case GRP_ADD
                With rsBtnGroups
                    If Not .EOF Then
                        !GroupName = txtGrpName.Text
                        .Update
                        frmButtonList.cboNames.AddItem "** " & !GroupName & " **"
                frmButtonList.cboNames.ItemData(frmButtonList.cboNames.NewIndex) = !GroupNo * -1
                        frmButtonList.cboNames.ListIndex = frmButtonList.cboNames.NewIndex
                    End If
                End With
            Case GRP_CHG
                With rsBtnGroups
                    If Not .EOF Then
                        !GroupName = txtNewGroup.Text
                        .Update
                        frmButtonList.cboNames.RemoveItem frmButtonList.cboNames.ListIndex
                frmButtonList.cboNames.AddItem "** " & !GroupName & " **"
                frmButtonList.cboNames.ItemData(frmButtonList.cboNames.NewIndex) = !GroupNo * -1
                        frmButtonList.cboNames.ListIndex = frmButtonList.cboNames.NewIndex
                    End If
                End With
            Case GRP_RMV
                With rsBtnGroups
                    If Not .EOF Then
                        .Delete adAffectCurrent
                frmButtonList.cboNames.RemoveItem frmButtonList.cboNames.ListIndex
            End If
                End With
                If frmButtonList.cboNames.ListCount > 0 Then
                    frmButtonList.cboNames.ListIndex = 0
                    frmButtonList.cmdReDraw_Click
                End If
        End Select
        TidyAndClose()
    End Sub

    Private Sub Form_Load()
        Dim iActGrp As Integer
        Dim rsTemp As ADODB.Recordset
        Dim sSql As String

        iActGrp = iCurrGrp * -1
        With rsBtnGroups
            Select Case iGrpAction
                Case GRP_ADD
                    lblThisBtn.Visible = False
                    NButton1.Visible = False
                    LblConfirm.Text = ""
                    LblNewGroup.Visible = False
                    TxtNewGroup.Visible = False
                    cmbGroups.Visible = False
                    LblTrans.Visible = False
                    TxtNewGroup.Enabled = False
                    cmbGroups.Enabled = False
                    txtGrpName.Enabled = True
                    .AddNew
                    !GroupName = "New"
                    .Update
                    .MoveNext
                    .MovePrevious
                    iActGrp = !GroupNo
                    iCurrGrp = iActGrp * -1
                    txtGrpNumber.Text = iActGrp
                Case GRP_CHG
                    lblThisBtn.Visible = False
                    NButton1.Visible = False
                    LblConfirm.Text = ""
                    LblNewGroup.Visible = True
                    TxtNewGroup.Visible = True
                    cmbGroups.Visible = False
                    LblTrans.Visible = False
                    TxtNewGroup.Enabled = True
                    cmbGroups.Enabled = False
                    txtGrpName.Enabled = False
                    ' Put current value in text boxes
                    .MoveFirst
                    .Find "GroupNo = " & iActGrp, , adSearchForward
            If Not .EOF Then
                        txtGrpNumber.Text = iActGrp
                        txtGrpName.Text = !GroupName
                    End If
                Case GRP_TRANS
                    NButton1.Text = frmButtonList.cmdText(iCurrBtn).Text
                    lblThisBtn.Visible = True
                    NButton1.Visible = True
                    LblConfirm.Text = ""
                    LblNewGroup.Visible = False
                    txtNewGroup.Visible = False
                    cmbGroups.Visible = True
                    lblTrans.Visible = True
                    txtNewGroup.Enabled = False
                    cmbGroups.Enabled = True
                    txtGrpName.Enabled = False
                    cmbGroups.Clear
                    .MoveFirst
                    ' Load the drop down list
                    Do Until .EOF
                        If !GroupNo = iActGrp Then
                            txtGrpNumber.Text = iActGrp
                            txtGrpName.Text = !GroupName
                        End If
                        cmbGroups.AddItem!GroupName
                        cmbGroups.ItemData(cmbGroups.NewIndex) = !GroupNo
                        .MoveNext
                    Loop
                Case GRP_RMV
                    lblThisBtn.Visible = False
                    NButton1.Visible = False
                    lblNewGroup.Visible = False
                    txtNewGroup.Visible = False
                    cmbGroups.Visible = False
                    lblTrans.Visible = False
                    txtNewGroup.Enabled = False
                    cmbGroups.Enabled = False
                    txtGrpName.Enabled = False
                    ' Put current value in text boxes
                    .MoveFirst
                    .Find "GroupNo = " & iActGrp, , adSearchForward
            If Not .EOF Then
                        txtGrpNumber.Text = iActGrp
                        txtGrpName.Text = !GroupName
                    End If
            Set rsTemp = New ADODB.Recordset
            sSql = "SELECT * From " & sButtons & " WHERE  BtnGrp = " & iActGrp
                    With rsTemp
                        .CursorType = adOpenForwardOnly
                        .LockType = adLockReadOnly
                        .Open sSql, db, , , adCmdText
                If .EOF Then
                            LblConfirm.Text = "** Click Update to confirm delete **"
                        Else
                            LblConfirm.Text = "** Group still has buttons **"
                            BtnUpdate.Enabled = False
                        End If
                        .Close
                    End With

            End Select
        End With
    End Sub

    Private Sub TidyAndClose()
        iGrpAction = GRP_TRANS
        lblNewGroup.Visible = False
        txtNewGroup.Visible = False
        cmbGroups.Visible = False
        lblTrans.Visible = False
        BtnUpdate.Enabled = True
        Me.Close()
    End Sub

    Private Sub Nbutton2_Load(sender As Object, e As EventArgs)

    End Sub
End Class