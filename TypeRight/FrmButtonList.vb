Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Text
Imports System.Windows.Forms
Imports NbuttonControlLibrary
Public Class FrmButtonList
#Region "constants"
    Private Const FRAME_WIDTH As Integer = 18
    Private Const SUB_START_MARKER As String = "$="
    Private Const SUB_MID_MARKER As String = "$$"
    Private Const SUB_END_MARKER As String = "=$"
    Private Const FIELD_START_MARKER As String = "?="
    Private Const FIELD_END_MARKER As String = "=?"
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
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.StartLogging()
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
        SetTopMost()
    End Sub
    Private Sub BtnReDraw_Click(sender As Object, e As EventArgs) Handles BtnReDraw.Click
        RedrawButtons()
    End Sub
    Private Sub RedrawButtons()
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
        SetTopMost()
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
            Try
                EditButton(newBtn, ButtonAction.BTN_ADD)
                LoadGroupButtons(iCurrGrp)
                DrawButtons()
                LogUtil.Info("Button added", MyBase.Name)
            Catch ex As DbException
                LogUtil.Exception("Exception adding new button", ex, MyBase.Name)
            End Try
        End If
    End Sub
    Private Sub MnuEdit_Click(menuItem As Object, e As EventArgs) Handles mnuEdit.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is Nbutton Then
            Dim _btn As Nbutton = CType(sourceControl, Nbutton)
            Try
                If _btn.DataType = Nbutton.DataSource.Group Then
                    EditButton(_btn, ButtonAction.BTN_CHG)
                    LoadGroupButtons(_btn.Group)
                    DrawGroupButtons()
                Else
                    EditSenderButton(_btn)
                    LoadSenderButtons(iCurrSender)
                    DrawSenderButtons()
                End If
                LogUtil.Info("Button edited", MyBase.Name)
            Catch ex As DbException
                LogUtil.Exception("Exception editing button", ex, MyBase.Name)
            End Try
        End If
    End Sub
    Private Sub MnuDelete_Click(menuItem As Object, e As EventArgs) Handles mnuDelete.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is Nbutton Then
            Dim _btn As Nbutton = CType(sourceControl, Nbutton)
            LogUtil.Info("Deleting button " & CStr(_btn.Id), MyBase.Name)
            If _btn.DataType = Nbutton.DataSource.Group Then
                Try
                    DeleteButton(_btn.Id)
                    ResequenceButtons(_btn.Group)
                    LoadGroupButtons(_btn.Group)
                    DrawButtons()
                    LogUtil.Info("Button deleted", MyBase.Name)
                Catch ex As DbException
                    LogUtil.Exception("Exception deleting button", ex, MyBase.Name)
                End Try
            End If
        End If
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        ShowGroupMaint(GroupAction.GRP_ADD, Nothing)
    End Sub
    Private Sub ChangeNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeNameToolStripMenuItem.Click
        ShowGroupMaint(GroupAction.GRP_CHG, Nothing)
    End Sub
    Private Sub RemoveGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveGroupToolStripMenuItem.Click
        ShowGroupMaint(GroupAction.GRP_RMV, Nothing)
    End Sub
    Private Sub TransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferToolStripMenuItem.Click
        Dim _menu As ToolStripDropDownMenu = CType(sender.Owner, ToolStripDropDownMenu)
        Dim _menuTopItem As ToolStripMenuItem = CType(_menu.OwnerItem, ToolStripMenuItem)
        Dim _strip As ContextMenuStrip = CType(_menuTopItem.Owner, ContextMenuStrip)
        Dim selectedButton As Nbutton = _strip.SourceControl
        ShowGroupMaint(GroupAction.GRP_TRANS, selectedButton)
    End Sub
    Private Sub FrmButtonList_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState <> FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
        End If
    End Sub
    Private Sub BtnMinimise_Click(sender As Object, e As EventArgs) Handles BtnMinimise.Click, mnuMinimise.Click, MnuMinimise1.Click
        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub ResetPositionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetPositionToolStripMenuItem.Click
        LogUtil.Info("Resetting button list position", MyBase.Name)
        Me.Top = 50
        Me.Left = 50
    End Sub
    Private Sub FrmButtonList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
        SavePosition()
        NotifyIcon1.Visible = False
    End Sub
    Private Sub PicDatabase_Click(sender As Object, e As EventArgs) Handles PicDatabase.Click
        LogUtil.Info("Updating Database", MyBase.Name)
        Using _dbUpdate As New FrmDbUpdate
            _dbUpdate.SenderId = iCurrSender
            _dbUpdate.ShowDialog()
        End Using
        FillNamesList()
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
    Private Sub PicLock_Click(sender As Object, e As EventArgs) Handles PicLock.Click
        LogUtil.Info("Lock timer on", MyBase.Name)
        GreenClock.Visible = True
        WhiteClock.Visible = False
        RedClock.Visible = False
        PicLock.Visible = False
        bLockClock = True
    End Sub
    Private Sub DelayTimer_Tick(sender As Object, e As EventArgs) Handles DelayTimer.Tick
        LogUtil.Info("Clock tick", MyBase.Name)
        ProgressTimer.Enabled = False
        DelayTimer.Enabled = False
        ProgressBar1.Visible = False
        ProgressBar1.SendToBack()
        If RedClock.Visible Then
            LogUtil.Info("Red clock - posting keys", MyBase.Name)
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
        LogUtil.Info("Clock click", MyBase.Name)
        If WhiteClock.Visible Then
            LogUtil.Info("White clock", MyBase.Name)
            GreenClock.Visible = True
            WhiteClock.Visible = False
        Else
            If GreenClock.Visible Then
                LogUtil.Info("Green clock", MyBase.Name)
                WhiteClock.Visible = True
                GreenClock.Visible = False
                DelayTimer.Enabled = False
                bLockClock = False
                PicLock.Visible = True
            End If
        End If
    End Sub
    Private Sub BtnRmvCol_Click(sender As Object, e As EventArgs) Handles BtnRmvCol.Click
        If iColCt > 1 Then
            LogUtil.Info("Remove a button list column", MyBase.Name)
            iColCt -= 1
            DrawButtons()
        End If
        Me.Width = (iColCt * iButtonWidth) + FRAME_WIDTH
        My.Settings.Columns = iColCt
        My.Settings.Save()
    End Sub
    Private Sub BtnAddCol_Click(sender As Object, e As EventArgs) Handles BtnAddCol.Click
        If (groupButtonList.Count / (iColCt + 1) > 1) Or (senderButtonList.Count / (iColCt + 1) > 1) Then
            LogUtil.Info("Add a button list column", MyBase.Name)
            iColCt += 1
            DrawButtons()
        End If
        Me.Width = (iColCt * iButtonWidth) + FRAME_WIDTH
        My.Settings.Columns = iColCt
        My.Settings.Save()
    End Sub
    Private Sub ImgExit_Click(sender As Object, e As EventArgs) Handles PicExit.Click
        Me.Close()
    End Sub
#End Region
#Region "subroutines"
    Private Sub EditButton(_btn As Nbutton, _action As Integer)
        Using _editForm As New FrmEditButton
            Dim _editButton As Nbutton = NButtonBuilder.NewButton().StartingWith(_btn).Build
            _editForm.Button = _editButton
            _editForm.Action = _action
            Dim rtnValue As DialogResult = _editForm.ShowDialog
            If rtnValue = DialogResult.OK Then
                _btn = _editButton
            End If
        End Using
    End Sub
    Private Sub EditSenderButton(_btn As Nbutton)
        Using _editForm As New FrmSenderButtonFormat
            _editForm.StartField = _btn.Caption
            Dim rtnValue As DialogResult = _editForm.ShowDialog
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
            strKeyText = GetDBFields(strKeyText)
            strKeyText = ApplySubstrings(strKeyText)
            Clipboard.SetText(strKeyText.Replace("{ENTER}", vbCrLf))
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
        End If
    End Sub
    Private Sub LoadSenderButtons(sndKey As Integer)
        LogUtil.Info("Fill button list with buttons for sender " & CStr(sndKey), MyBase.Name)
        senderButtonList.Clear()
        Dim strButtonTxt As String
        Dim strButtonValue As String
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
        iBct = 0
        Dim senderButton As TypeRightDataSet.senderButtonRow
        For Each _col As DataColumn In oTable.Columns
            senderButton = GetSenderButton(_col.ColumnName)
            strButtonValue = If(IsDBNull(oRow(_col.ColumnName)), "", oRow(_col.ColumnName))
            If senderButton IsNot Nothing AndAlso CBool(senderButton.buttonEncrypted) Then
                strButtonValue = oNCrypter.DecryptData(strButtonValue)
            End If
            strButtonTxt = _col.ColumnName
            strButtonCaption = strButtonTxt.Substring(0, Math.Min(strButtonTxt.Length, 20))
            strButtonHint = strButtonValue.Substring(0, Math.Min(strButtonValue.Length, 50))
            AddSenderButton(iBct, senderButton, strButtonCaption, strButtonValue, strButtonHint)
            iBct += 1
        Next
        Dim caption As String = "Full Name"
        AddSenderButton(iBct, GetSenderButton(caption), caption, fullname, fullname.Substring(0, Math.Min(fullname.Length, 50)))
        iBct += 1
        caption = "Full Addr"
        AddSenderButton(iBct, GetSenderButton(caption), caption, fulladdr, fulladdr.Substring(0, Math.Min(fulladdr.Length, 50)))
        iBct += 1
        caption = "Age"
        AddSenderButton(iBct, GetSenderButton(caption), caption, strAge, strAge)
    End Sub
    Private Sub AddSenderButton(btnSeq As Integer, oSenderButton As TypeRightDataSet.senderButtonRow, btnCaption As String, btnValue As String, btnHint As String)
        Dim isButtonBold As Boolean
        Dim isButtonItalic As Boolean
        Dim strButtonFontName As String
        Dim dButtonFontSize As Decimal
        If oSenderButton IsNot Nothing Then
            isButtonBold = oSenderButton.buttonBold
            isButtonItalic = oSenderButton.buttonItalic
            strButtonFontName = oSenderButton.buttonFontName
            dButtonFontSize = oSenderButton.buttonFontSize
        Else
            strButtonFontName = "Tahoma"
            isButtonBold = False
            isButtonItalic = False
            dButtonFontSize = 9.0
        End If
        If btnValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(btnValue) Then
            Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(-1, -1, btnSeq, btnCaption, btnHint, btnValue, strButtonFontName, dButtonFontSize, isButtonBold, isButtonItalic, False, Nbutton.DataSource.Sender).Build
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
    Private Sub LoadGroupButtons(grpNo As Long)
        groupButtonList.Clear()
        Dim _nbb As New NButtonBuilder
        LogUtil.Info("Loading group buttons", MyBase.Name)
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
        LogUtil.Info("Draw group buttons", MyBase.Name)
        lResizeActive = False
        RemoveGroupButtons()
        FillButtonPanel(GroupButtonPanel, groupButtonList)
        SenderButtonPanel.Top = GroupButtonPanel.Top + GroupButtonPanel.Height + 4
        Me.Height = GrpTop.Height + GroupButtonPanel.Height + SenderButtonPanel.Height + GrpBottom.Height + 40
        GrpBottom.Top = GroupButtonPanel.Top + GroupButtonPanel.Height + SenderButtonPanel.Height
        lResizeActive = True
    End Sub
    Private Sub DrawSenderButtons()
        LogUtil.Info("Draw sender buttons", MyBase.Name)
        lResizeActive = False
        RemoveSenderButtons()
        FillButtonPanel(SenderButtonPanel, senderButtonList)
        Me.Height = GrpTop.Height + GroupButtonPanel.Height + SenderButtonPanel.Height + GrpBottom.Height + 40
        GrpBottom.Top = GroupButtonPanel.Top + GroupButtonPanel.Height + SenderButtonPanel.Height + 4
        lResizeActive = True
    End Sub
    Private Sub RemoveGroupButtons()
        GroupButtonPanel.Controls.Clear()
    End Sub
    Private Sub RemoveSenderButtons()
        SenderButtonPanel.Controls.Clear()
    End Sub
    Friend Sub DrawButtons()
        LogUtil.Info("Draw all buttons", MyBase.Name)
        lResizeActive = False
        ' Size of window
        Me.Width = (iColCt * iButtonWidth) + FRAME_WIDTH
        DrawGroupButtons()
        DrawSenderButtons()
        lResizeActive = True
    End Sub
    Private Sub FillButtonPanel(ByRef oPanel As Panel, ByRef oList As List(Of Nbutton))
        LogUtil.Info("Fill button panel " & oPanel.Name, MyBase.Name)
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
            'AddHandler oBtn.Click, AddressOf Button_Click
            oPanel.Controls.Add(oBtn)
            ToolTip1.SetToolTip(oBtn.button1, oBtn.Value)
            oBtn.Top = 0 + (iBtnRow * 27)
            oBtn.Left = 0 + (iBtnCol * iButtonWidth)
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
            RemoveHandler _btn.Button1.Click, AddressOf Button_Click
            AddHandler _btn.Button1.Click, AddressOf Button_Click
        Next
    End Sub
    Private Sub SetTopMost()
        If bOnTop Then
            ImgTack.Image = My.Resources.tackdown
        Else
            ImgTack.Image = My.Resources.tackup
        End If
        Me.TopMost = bOnTop
        If bOnTop Then
            Me.BringToFront()
        End If
    End Sub
    Private Sub ShowGroupMaint(_action As GroupAction, _button As Nbutton)
        LogUtil.Info("Showing group maintenance", MyBase.Name)
        Dim result As DialogResult = DialogResult.None
        Using _grpMaint As New FrmGroupMaint
            _grpMaint.SenderButton = _button
            _grpMaint.Action = _action
            result = _grpMaint.ShowDialog()
        End Using
        If result = DialogResult.OK Then
            FillNamesList()
            RedrawButtons()
        End If
    End Sub
    Private Sub ShowOptions()
        LogUtil.Info("Showing options", MyBase.Name)
        Using _options As New FrmOptions
            _options.Owner = Me
            _options.ShowDialog()
            '       LoadOptions()
            Me.Opacity = iTransPerc / 100
            GrpBottom.Visible = bToolBar
            SetTopMost()
            If Me.Width <> (iColCt * iButtonWidth) + FRAME_WIDTH Then
                DrawButtons()
            End If
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
    Private Sub SavePosition()
        LogUtil.Info("Saved screen position", MyBase.Name)
        My.Settings.ButtonListPos = SetFormPos(Me)
    End Sub
    Private Function GetDBFields(ByVal sKeyText As String) As String
        Dim fieldName As String
        Dim fieldValue As String
        Dim oRow As TypeRightDataSet.sendersRow = GetSenderById(iCurrSender)
        Dim newText As String = sKeyText
        fieldName = GetValueBetweenBrackets(newText, FIELD_START_MARKER, FIELD_END_MARKER)
        Dim fieldRow As TypeRightDataSet.senderButtonRow
        Do Until String.IsNullOrEmpty(fieldName)
            fieldRow = GetSenderButton(fieldName)
            fieldValue = If(IsDBNull(oRow(fieldName)), "", CStr(oRow(fieldName)))
            If fieldRow IsNot Nothing AndAlso CBool(fieldRow.buttonEncrypted) Then
                fieldValue = oNCrypter.DecryptData(fieldValue)
            End If
            newText = newText.Replace(FIELD_START_MARKER & fieldName & FIELD_END_MARKER, fieldValue)
            fieldName = GetValueBetweenBrackets(newText, FIELD_START_MARKER, FIELD_END_MARKER)
        Loop
        Return newText
    End Function
    Private Function ApplySubstrings(ByVal sKeyText As String) As String
        Dim newText As String = sKeyText
        Try
            Dim subText As String = GetValueBetweenBrackets(newText, SUB_START_MARKER, SUB_END_MARKER)
            Do Until String.IsNullOrEmpty(subText)
                Dim subparts As String() = Split(subText, SUB_MID_MARKER)
                Dim subValue As String
                If subparts.Length = 2 Then
                    Dim subInts As String() = Split(subparts(1), ",")
                    If subInts.Length = 2 Then
                        subValue = subparts(0).Substring(CInt(subInts(0)), CInt(subInts(1)))
                    Else
                        subValue = subparts(0).Substring(CInt(subInts(0)))
                    End If
                    newText = newText.Replace(SUB_START_MARKER & subText & SUB_END_MARKER, subValue)
                    subText = GetValueBetweenBrackets(newText, SUB_START_MARKER, SUB_END_MARKER)
                Else
                    newText = newText.Replace(SUB_START_MARKER, "!!").Replace(SUB_END_MARKER, "!!")
                    subText = ""
                End If
            Loop
        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("Substring Exception", ex, MyBase.Name)
        End Try

        Return newText
    End Function

#End Region
End Class