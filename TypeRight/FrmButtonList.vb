Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms
Imports NbuttonControlLibrary
Public Class FrmButtonList
#Region "constants"
    Private Const FRAME_WIDTH As Integer = 18
#End Region
#Region "private variables"
    Private strKeyText As String
    Private ReadOnly iChar As Integer
    Private ReadOnly strChar As String
    Private ReadOnly strUChar As String
    Private ReadOnly iStrLen As Integer
    Private ReadOnly iKbdVal As Integer
    Private ReadOnly strIniTxt As String
    Private strButtonHint As String
    Private ReadOnly strButtonFont As String
    Private isLoading As Boolean = False
    Private iBct As Integer
    Private lResizeActive As Boolean
    Private ReadOnly lMoving As Boolean
    Private groupButtonList As New List(Of Nbutton)
    Private senderButtonList As New List(Of Nbutton)
    Private ReadOnly buttonBuilder As New NButtonBuilder
    Private ReadOnly spath As String
    Private bLockClock As Boolean
    Private ReadOnly bDrag As Boolean
    Private ReadOnly iDragBtnIndex As Integer
    Dim redClockText As String
#End Region
#Region "form control handlers"
    Private Sub FrmButtonList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        InitialiseApplication()
        GetFormPos(Me, My.Settings.ButtonListPos)
        ' Set window width based on number of columns and button width
        Me.Width = (iColCt * iButtonWidth) + FRAME_WIDTH
        FillNamesList()
        For Each cmbItem As KeyValuePair(Of Integer, String) In cbNames.Items
            Dim key As Integer = cmbItem.Key
            Dim value As String = cmbItem.Value
            If iCurrGrp <> 0 AndAlso key * -1 = iCurrGrp Then
                cbNames.SelectedIndex = cbNames.FindString(value)
                Exit For
            ElseIf iCurrSender <> 0 AndAlso key = iCurrSender Then
                cbNames.SelectedIndex = cbNames.FindString(value)
                Exit For
            End If
        Next
        GrpTop.Visible = isPro
        mnuGroups.Visible = isPro
        mnuSep3.Visible = isPro
        Me.Opacity = iTransPerc / 100
        GrpBottom.Visible = bToolBar
        ImgTack_Click()
        iButtonCt = 0
        If isPro Then
            GroupButtonPanel.Top = GrpTop.Height
        Else
            GroupButtonPanel.Top = 0
        End If
        Me.Text = cbNames.SelectedItem.value
        If iCurrGrp > 0 Then
            LoadGroupButtons(iCurrGrp)
            DrawGroupButtons()
        End If
        If iCurrSender > 0 Then
            LoadSenderButtons(iCurrSender)
            DrawSenderButtons()
        End If
        lResizeActive = True
        WhiteClock.Visible = True
        GreenClock.Visible = False
        RedClock.Visible = False
        DelayTimer.Enabled = False
        bLockClock = False
        If bMinimise Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
        isLoading = False
    End Sub
    Private Sub BtnReDraw_Click(sender As Object, e As EventArgs) Handles BtnReDraw.Click
        If cbNames.SelectedIndex > -1 Then
            iButtonCt = 0
            Dim btnVal As Integer = cbNames.SelectedValue
            If btnVal < 0 Then
                LoadGroupButtons(btnVal * -1)
                DrawGroupButtons()
                iCurrGrp = btnVal * -1
            Else
                LoadSenderButtons(btnVal)
                DrawSenderButtons()
                iCurrSender = btnVal
            End If
            Me.Text = cbNames.SelectedItem.value
        End If
    End Sub
    Private Sub ImgTack_Click(sender As Object, e As EventArgs) Handles ImgTack.Click
        bOnTop = Not (bOnTop)
        ImgTack_Click()
        SaveOptions()
    End Sub
    Private Sub MnuOptions1_Click(sender As Object, e As EventArgs) Handles mnuOptions1.Click
        ShowOptions()
    End Sub
    Private Sub MnuOptions_Click(sender As Object, e As EventArgs) Handles mnuOptions.Click
        ShowOptions()
    End Sub
    Private Sub ImgOptions_Click(sender As Object, e As EventArgs) Handles PicOptions.Click
        ShowOptions()
    End Sub
    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub CopyToClipboardToolStripMenuItem_Click(MenuItem As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        Clipboard.Clear()
        Dim sourceControl As Object = GetSourceControl(MenuItem)
        If TypeOf (sourceControl) Is Nbutton Then
            Dim _btn As Nbutton = CType(sourceControl, Nbutton)
            Dim strText As String = _btn.Value.Replace("{Return}", Chr(10)).Replace("{{}", "{").Replace("{}}", "}")
            Clipboard.SetText(strText)
        End If
    End Sub
    Private Sub MnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        If iCurrGrp <> 0 Then
            Dim lastSeq As Integer = groupButtonList(groupButtonList.Count - 1).Sequence
            Dim newBtn As Nbutton = NButtonBuilder.NewButton.StartingWithNothing.WithGroup(iCurrGrp).WithSeq(lastSeq + 1).Build
            Dim newId As Integer = InsertButton(newBtn)
            newBtn.Id = newId
            EditButton(newBtn)
            LoadGroupButtons(iCurrGrp)
            DrawButtons()
        End If
    End Sub
    Private Sub MnuEdit_Click(menuItem As Object, e As EventArgs) Handles mnuEdit.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is Nbutton Then
            Dim _btn As Nbutton = CType(sourceControl, Nbutton)
            If _btn.DataType = Nbutton.DataSource.Group Then
                EditButton(_btn)
                LoadGroupButtons(_btn.Group)
                DrawButtons()
            End If
        End If
    End Sub
    Private Sub MnuDelete_Click(menuItem As Object, e As EventArgs) Handles mnuDelete.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is Nbutton Then
            Dim _btn As Nbutton = CType(sourceControl, Nbutton)
            If _btn.DataType = Nbutton.DataSource.Group Then
                DeleteButton(_btn.Id)
                LoadGroupButtons(_btn.Group)
                DrawButtons()
            End If
        End If
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ShowGroupMaint(GroupAction.GRP_ADD)
    End Sub
    Private Sub ChangeNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeNameToolStripMenuItem.Click
        ShowGroupMaint(GroupAction.GRP_CHG)
    End Sub
    Private Sub TransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferToolStripMenuItem.Click
        ShowGroupMaint(GroupAction.GRP_TRANS)
    End Sub
#End Region
#Region "subroutines"
    Private Sub EditButton(_btn As Nbutton)
        Using _editForm As New FrmEditButton
            Dim buttonbuilder = New NButtonBuilder
            Dim _editButton As Nbutton = buttonbuilder.StartingWith(_btn).Build
            _editForm.Button = _editButton
            Dim rtnValue As DialogResult = _editForm.ShowDialog
            If rtnValue = DialogResult.OK Then
                _btn = _editButton
            End If
        End Using
    End Sub
    Private Sub FillNamesList()
        Dim _senders As TypeRightDataSet.sendersDataTable = GetSenders()
        Dim _groups As TypeRightDataSet.buttongroupsDataTable = GetButtonGroups()
        Dim comboItems As New Dictionary(Of Integer, String)
        For Each grpRow As TypeRightDataSet.buttongroupsRow In _groups.Rows
            comboItems.Add(grpRow.buttongroupid * -1, "** " & grpRow.groupname & " **")
        Next
        For Each sndRow As TypeRightDataSet.sendersRow In _senders.Rows
            comboItems.Add(sndRow.SenderId, sndRow.FirstName & " " & sndRow.LastName)
        Next
        If comboItems.Count > 0 Then
            cbNames.DataSource = New BindingSource(comboItems, Nothing)
            cbNames.DisplayMember = "Value"
            cbNames.ValueMember = "Key"
        End If
    End Sub
    Private Sub Button_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim _button As Button = TryCast(eventSender, Button)
        If _button IsNot Nothing Then
            Dim _nButton As Nbutton = _button.Parent
            strKeyText = _nButton.Value
            If isPro And _nButton.Encrypt Then
                strKeyText = oNCrypter.DecryptData(strKeyText)
            End If

            'strKeyText = getDBFields(strKeyText)

            If GreenClock.Visible = True Then
                RedClock.Visible = True
                GreenClock.Visible = False
                DelayTimer.Interval = iDelay
                ProgressBar1.Maximum = iDelay
                ProgressBar1.Value = iDelay
                ProgressBar1.Visible = True
                ProgressBar1.BringToFront()
                DelayTimer.Enabled = True
                ProgressTimer.Enabled = True
                redClockText = strKeyText
            Else
                SendKeys.Send("%{ESC}")
                SendKeys.Send(strKeyText)
            End If
            ' flip to previous window
            '''keybd_event(System.Windows.Forms.Keys.Menu, 0, 0, 0) ' press Alt
            '''keybd_event(System.Windows.Forms.Keys.Escape, 0, 0, 0) ' press tab
            '''keybd_event(System.Windows.Forms.Keys.Escape, 0, KEYEVENTF_KEYUP, 0) ' release Tab
            '''keybd_event(System.Windows.Forms.Keys.Menu, 0, KEYEVENTF_KEYUP, 0) ' release Alt
            '''post_keys(strKeyText)
            'Else
            '    If imgClock(1).Visible = True Then
            '        imgClock(1).Visible = False
            '        imgClock(2).Visible = True
            '        'UPGRADE_WARNING: Timer property DelayTimer.Interval cannot have a value of 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"'

            '        secondTimer.Interval = 500
            '        secondTimer.Enabled = True
            '    End If
            'End If


        End If
    End Sub
    Private Sub LoadSenderButtons(sndKey As Integer)
        senderButtonList.Clear()
        'Dim sSql As String
        'Dim strBct As String
        Dim B As Integer
        Dim strButtonTxt As String
        Dim strButtonValue As String
        'Dim xxx As String
        'Dim yyy As String
        Dim fname As String
        Dim lname As String
        Dim fullname As String
        Dim add1 As String
        Dim add2 As String
        Dim town As String
        Dim county As String
        Dim country As String
        Dim pcode As String
        Dim username As String
        Dim fulladdr As String
        Dim dtDob As Date
        Dim strAge As String
        Dim oRow As TypeRightDataSet.sendersRow = GetSenderById(sndKey)
        Dim oTable As New TypeRightDataSet.sendersDataTable
        fname = oRow.FirstName
        lname = oRow.LastName
        add1 = If(oRow.IsAddress1Null, "", oRow.Address1)
        add2 = If(oRow.IsAddress2Null, "", oRow.Address2)
        town = If(oRow.IsTownNull, "", oRow.Town)
        county = If(oRow.IsCountyNull, "", oRow.County)
        country = If(oRow.IsCountyNull, "", oRow.Country)
        username = If(oRow.IsUsernameNull, "", oRow.Username)
        pcode = If(oRow.IsPostCodeNull, "", oRow.PostCode)
        dtDob = If(oRow.IsdobNull, Date.MinValue, oRow.dob)
        fullname = Trim(fname & " " & lname)
        Dim addBuilder As New StringBuilder
        If Not String.IsNullOrEmpty(add1) Then
            addBuilder.Append(add1)
        End If
        If Not String.IsNullOrEmpty(add2) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{ENTER}")
            End If
            addBuilder.Append(add2)
        End If
        If Not String.IsNullOrEmpty(town) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{ENTER}")
            End If
            addBuilder.Append(town)
        End If
        If Not String.IsNullOrEmpty(county) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{ENTER}")
            End If
            addBuilder.Append(county)
        End If
        If Not String.IsNullOrEmpty(pcode) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{ENTER}")
            End If
            addBuilder.Append(pcode)
        End If
        fulladdr = addBuilder.ToString
        strAge = Format(Calc_age(dtDob))

        AddButton(1, "Full Name", fullname, strButtonFont, 9.0, fullname.Substring(0, Math.Min(fullname.Length, 50)), False, False)
        AddButton(2, "Full Addr", fulladdr, strButtonFont, 9.0, fulladdr.Substring(0, Math.Min(fulladdr.Length, 50)), False, False)

        iBct = 2
        '   B = 1


        For Each _col As DataColumn In oTable.Columns
            strButtonValue = If(IsDBNull(oRow(_col.ColumnName)), "", oRow(_col.ColumnName))
            strButtonTxt = _col.ColumnName
            strButtonCaption = strButtonTxt.Substring(0, Math.Min(strButtonTxt.Length, 10))
            strButtonHint = strButtonValue.Substring(0, Math.Min(strButtonValue.Length, 50))

            AddButton(B + iBct, strButtonCaption, strButtonValue, strButtonFont, 9.0, strButtonHint, False, False)
            Debug.Print(strButtonTxt)
            B += 1
        Next

        AddButton(B + iBct, "Age", strAge, strButtonFont, 9.0, strAge, False, False)

    End Sub
    Private Sub AddButton(btnSeq As Integer, btnCaption As String, btnValue As String, btnFontName As String, btnSize As Single,
                          btnHint As String, isBold As Boolean, isItalic As Boolean)
        If btnValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(btnValue) Then
            Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(-1, -1, btnSeq, btnCaption, btnHint, btnValue, btnFontName, btnSize, isBold, isItalic, False, Nbutton.DataSource.Sender).Build
            senderButtonList.Add(_nbutton)
        End If

    End Sub
    Private Sub AddButton(btnId As Integer, btnSeq As Integer,
                          btnCaption As String, btnValue As String, btnFontname As String, btnSize As Single,
                          btnHint As String, isBold As Boolean, isItalic As Boolean, isEncrypt As Boolean,
                           iActGrpNo As Integer)
        If btnValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(btnValue) Then
            Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(btnId, iActGrpNo, btnSeq,
                                                                            btnCaption, btnHint, btnValue,
                                                                            btnFontname, btnSize, isBold,
                                                                            isItalic, isEncrypt, Nbutton.DataSource.Group).Build
            groupButtonList.Add(_nbutton)
        End If

    End Sub
    Public Sub LoadGroupButtons(grpNo As Long)
        groupButtonList.Clear()
        Dim _nbb As New NButtonBuilder
        Dim undoButton As Nbutton = _nbb.StartingWith(0, grpNo, 0, "Undo", "", "^z", "Tahoma", 10, False, False, False, Nbutton.DataSource.Undefined).Build
        groupButtonList.Add(undoButton)
        Dim btnTable As TypeRightDataSet.buttonDataTable = GetButtonsByGroup(grpNo)
        For Each btnRow As TypeRightDataSet.buttonRow In btnTable.Rows
            If Not btnRow.IsbuttonValueNull AndAlso Not String.IsNullOrEmpty(btnRow.buttonValue) Then
                Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(btnRow.buttonId).Build()

                groupButtonList.Add(_nbutton)
            End If
        Next
    End Sub
    Private Sub DrawGroupButtons()
        lResizeActive = False
        RemoveGroupButtons()
        FillButtonPanel(GroupButtonPanel, groupButtonList)
        SenderButtonPanel.Top = GroupButtonPanel.Top + GroupButtonPanel.Height
        Me.Height = GrpTop.Height + GroupButtonPanel.Height + SenderButtonPanel.Height + GrpBottom.Height + 36

        GrpBottom.Top = GroupButtonPanel.Top + GroupButtonPanel.Height + SenderButtonPanel.Height
        lResizeActive = True
    End Sub
    Private Sub DrawSenderButtons()
        lResizeActive = False
        RemoveSenderButtons()
        FillButtonPanel(SenderButtonPanel, senderButtonList)
        Me.Height = GrpTop.Height + GroupButtonPanel.Height + SenderButtonPanel.Height + GrpBottom.Height + 36
        GrpBottom.Top = GroupButtonPanel.Top + GroupButtonPanel.Height + SenderButtonPanel.Height
        lResizeActive = True
    End Sub
    Private Sub RemoveGroupButtons()
        GroupButtonPanel.Controls.Clear()
    End Sub
    Private Sub RemoveSenderButtons()
        SenderButtonPanel.Controls.Clear()
    End Sub
    Friend Sub DrawButtons()
        lResizeActive = False
        ' Size of window
        Me.Width = (iColCt * iButtonWidth) + FRAME_WIDTH
        DrawGroupButtons()
        DrawSenderButtons()
        lResizeActive = True
    End Sub

    Private Sub FillButtonPanel(ByRef oPanel As Panel, ByRef oList As List(Of Nbutton))
        iButtonCt = oList.Count
        oPanel.Width = Me.Width - FRAME_WIDTH
        Dim iRowCt As Integer = CInt(iButtonCt / iColCt)
        ' Any left over ? Then add a row
        Dim iMod As Integer = (iButtonCt) Mod iColCt
        If iMod > 0 Then
            iRowCt += 1
        End If
        oPanel.Height = iRowCt * 27
        Dim iBtnRow As Integer = 0
        Dim iBtnCol As Integer = 0
        For Each oBtn In oList
            AddHandler oBtn.Click, AddressOf Button_Click
            oPanel.Controls.Add(oBtn)
            Debug.Print(oBtn.Caption)
            oBtn.Top = 1 + (iBtnRow * 27)
            oBtn.Left = 1 + (iBtnCol * iButtonWidth)
            oBtn.Size = New Drawing.Size(iButtonWidth, 27)
            oBtn.Visible = True
            oBtn.ContextMenuStrip = mnuButtons
            oBtn.Name = oPanel.Name & CStr(iBtnRow) & CStr(iBtnCol)
            iBtnRow += 1
            If iBtnRow > iRowCt - 2 Then
                If iBtnCol > iMod - 1 And iMod > 0 Then
                    iBtnCol += 1
                    iBtnRow = 0
                    Continue For
                Else
                    If iBtnRow > iRowCt - 1 Then
                        iBtnCol += 1
                        iBtnRow = 0
                    End If
                End If
            End If

        Next
        For Each _btn As Nbutton In oPanel.Controls
            AddHandler _btn.Button1.Click, AddressOf Button_Click
        Next

    End Sub

    Private Sub ImgTack_Click()
        If bOnTop Then
            ImgTack.Image = My.Resources.tackdown
        Else
            ImgTack.Image = My.Resources.tackup
        End If
        Me.TopMost = bOnTop
    End Sub
    Private Sub ShowGroupMaint(_action As GroupAction)
        Using _grpMaint As New FrmGroupMaint
            _grpMaint.Action = _action
            _grpMaint.ShowDialog()
        End Using
    End Sub
    Private Sub ShowOptions()
        Using _options As New FrmOptions
            _options.ShowDialog()
            LoadOptions()
            Me.Opacity = iTransPerc / 100
            GrpBottom.Visible = bToolBar

        End Using
    End Sub
#End Region
#Region "functions"
    Public Shared Function Calc_age(dtDob As DateTime) As Integer
        Dim fmm As Integer
        Dim tmm As Integer
        Dim age As Integer

        fmm = Month(dtDob)
        tmm = Month(Now)
        age = Year(Now) - Year(dtDob)
        If fmm > tmm Or (fmm = tmm And dtDob.Day > Now.Day) Then
            age -= 1
        End If
        Calc_age = age
    End Function
    Private Sub ImgExit_Click(sender As Object, e As EventArgs) Handles PicExit.Click
        Me.Close()
    End Sub
    Private Sub SavePosition()
        My.Settings.ButtonListPos = SetFormPos(Me)
    End Sub
    Private Sub PicLock_Click(sender As Object, e As EventArgs) Handles PicLock.Click
        GreenClock.Visible = True
        WhiteClock.Visible = False
        RedClock.Visible = False
        PicLock.Visible = False
        bLockClock = True
    End Sub
    Private Sub DelayTimer_Tick(sender As Object, e As EventArgs) Handles DelayTimer.Tick
        ProgressTimer.Enabled = False
        DelayTimer.Enabled = False
        ProgressBar1.Visible = False
        ProgressBar1.SendToBack()

        If RedClock.Visible Then
            SendKeys.Send("%{ESC}")
            SendKeys.Send(redClockText)
            RedClock.Visible = False
        End If
        If bLockClock Then
            GreenClock.Visible = True
        Else
            WhiteClock.Visible = True
        End If

    End Sub
    Private Sub Clock_Click(sender As Object, e As EventArgs) Handles WhiteClock.Click, GreenClock.Click, RedClock.Click
        If WhiteClock.Visible Then
            GreenClock.Visible = True
            WhiteClock.Visible = False
        Else
            If GreenClock.Visible Then
                WhiteClock.Visible = True
                GreenClock.Visible = False
                DelayTimer.Enabled = False
                bLockClock = False
                PicLock.Visible = True
            End If
        End If
    End Sub
    Private Sub Clock_DoubleClick(sender As Object, e As EventArgs) Handles WhiteClock.DoubleClick, GreenClock.DoubleClick, RedClock.DoubleClick
        If Not (bLockClock) Then
            bLockClock = True
            PicLock.Visible = True
        End If
    End Sub
    Private Sub BtnRmvCol_Click(sender As Object, e As EventArgs) Handles BtnRmvCol.Click
        If iColCt > 1 Then
            iColCt -= 1
            DrawButtons()
        End If
        Me.Width = (iColCt * iButtonWidth) + FRAME_WIDTH
    End Sub
    Private Sub BtnAddCol_Click(sender As Object, e As EventArgs) Handles BtnAddCol.Click
        If (groupButtonList.Count / (iColCt + 1) > 1) Or (senderButtonList.Count / (iColCt + 1) > 1) Then
            iColCt += 1
            DrawButtons()
        End If
        Me.Width = (iColCt * iButtonWidth) + FRAME_WIDTH
    End Sub
    Private Function GetDBFields(ByRef sKeyText As String) As String
        'Dim iFldCt As Short
        'Dim iFldNo As Short

        'Dim iActGrpNo As Short
        'Dim sSql As String
        'Dim iStrLen As Short
        'Dim iCPos As Short
        'Dim sChar As String
        'Dim sNewText As String
        'Dim sFieldName As String
        'Dim bFieldFound As Boolean
        'Dim sFieldValue As String

        'iActGrpNo = VB6.GetItemData(cboNames, cboNames.SelectedIndex)

        ''  Set db2 = New ADODB.Connection
        'rsSender2 = New ADODB.Recordset
        ''  db2.Open sDbName
        'sSql = "SELECT * from " & sSenderTable & " WHERE AddressId = " & VB6.Format(iActGrpNo)
        'rsSender2.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
        'rsSender2.LockType = ADODB.LockTypeEnum.adLockReadOnly
        'rsSender2.Open(sSql, Db,  ,  , ADODB.CommandTypeEnum.adCmdText)

        'iFldCt = rsSender2.Fields.Count

        'iStrLen = Len(sKeyText)

        'For iCPos = 1 To iStrLen
        '    sChar = Mid(sKeyText, iCPos, 1)
        '    If sChar = "{" Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object GetValueBetweenBrackets(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        sFieldName = GetValueBetweenBrackets(sKeyText, iCPos)
        '        bFieldFound = False
        '        For iFldNo = 1 To iFldCt - 1
        '            If rsSender2.Fields(iFldNo).Name = sFieldName Then
        '                bFieldFound = True
        '                Exit For
        '            End If
        '        Next iFldNo
        '        If bFieldFound Then
        '            sFieldValue = rsSender2.Fields(iFldNo).Value
        '            Select Case LCase(rsSender2.Fields(iFldNo).Name)
        '                Case "passwd"
        '                    sFieldValue = oNCrypter.Decrypt(sFieldValue, APP_STRING, False, NetWYrks.frezCryptoEncryptionType.frezBlockEncryption)
        '                Case "secretword"
        '                    sFieldValue = oNCrypter.Decrypt(sFieldValue, APP_STRING, False, NetWYrks.frezCryptoEncryptionType.frezBlockEncryption)
        '            End Select
        '            sNewText = sNewText & sFieldValue
        '        Else
        '            sNewText = sNewText & "{" & sFieldName & "}"
        '        End If

        '    Else
        '        sNewText = sNewText & sChar
        '    End If
        'Next iCPos

        'GetDBFields = sNewText
        'rsSender2.Close()
        '' db2.Close
        ''UPGRADE_NOTE: Object rsSender2 may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'rsSender2 = Nothing
        '' Set db2 = Nothing
        Return Nothing
    End Function
    Private Sub FrmButtonList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SavePosition()
        NotifyIcon1.Visible = False
    End Sub
    Private Sub PicDatabase_Click(sender As Object, e As EventArgs) Handles PicDatabase.Click
        Using _dbUpdate As New FrmDbUpdate
            _dbUpdate.SenderId = iCurrSender
            _dbUpdate.ShowDialog()
        End Using
    End Sub
    Private Sub ProgressTimer_Tick(sender As Object, e As EventArgs) Handles ProgressTimer.Tick
        If ProgressBar1.Value > 0 Then
            If ProgressBar1.Value >= ProgressTimer.Interval Then
                ProgressBar1.Value -= ProgressTimer.Interval
            Else
                ProgressBar1.Value = 0
            End If
        End If
    End Sub

#End Region
End Class