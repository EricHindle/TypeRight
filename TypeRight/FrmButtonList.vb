Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports NbuttonControlLibrary
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Drawing

Public Class FrmButtonList
#Region "constants"
    Const KEYEVENTF_EXTENDEDKEY = &H1
    Const KEYEVENTF_KEYUP = &H2
    Const KEYEVENTF_KEYDOWN = &H0
    Private Const strShiftList As String = "!" + Chr(34) + "£$%^&*(){}@:~<>?_+"
    Private Const strNoShiftList As String = "1234567890"
    Private Const strPunctuationList As String = "[]:@~;'#<>?,./|\_+-= "
    Private FRAME_WIDTH = 18
#End Region
#Region "dll"
    <DllImport("user32.dll")>
    Public Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UInteger)
    End Sub
    Public Shared Function GetForegroundWindow() As Long
    End Function

#End Region
#Region "private variables"
    Private strKeyText As String
    Private iChar As Integer
    Private strChar As String
    Private strUChar As String
    Private iStrLen As Integer
    Private iKbdVal As Integer
    Private strIniTxt As String
    Private strButtonHint As String
    Private strButtonFont As String
    Private isLoading As Boolean = False
    Private iBct As Integer
    Private lResizeActive As Boolean
    Private lMoving As Boolean
    Private groupButtonList As New List(Of Nbutton)
    Private senderButtonList As New List(Of Nbutton)
    Private buttonBuilder As New NButtonBuilder
    Private spath As String
    Private bLockClock As Boolean
    Private bDrag As Boolean
    Private iDragBtnIndex As Integer

#End Region
#Region "form control handlers"
    Private Sub FrmButtonList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        InitialiseApplication()
        Me.Top = iTop
        Me.Left = iLeft
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
        Me.Top = iTop
        Me.Left = iLeft
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
    Private Sub mnuOptions1_Click(sender As Object, e As EventArgs) Handles mnuOptions1.Click
        ShowOptions()
    End Sub
    Private Sub mnuOptions_Click(sender As Object, e As EventArgs) Handles mnuOptions.Click
        ShowOptions()
    End Sub
    Private Sub ImgOptions_Click(sender As Object, e As EventArgs) Handles imgOptions.Click
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
            comboItems.Add(sndRow.senderid, sndRow.firstname & " " & sndRow.lastname)
        Next
        If comboItems.Count > 0 Then
            cbNames.DataSource = New BindingSource(comboItems, Nothing)
            cbNames.DisplayMember = "Value"
            cbNames.ValueMember = "Key"
        End If
    End Sub
    'Private Sub Button_Click(Index As Integer)
    '    If Index = 0 Then
    '        keybd_event(CByte(Keys.Menu), 0, KEYEVENTF_KEYDOWN, 0) ' press Alt
    '        keybd_event(CByte(Keys.Tab), 0, KEYEVENTF_KEYDOWN, 0) ' press tab
    '        keybd_event(CByte(Keys.Tab), 0, KEYEVENTF_KEYUP, 0) ' release Tab
    '        keybd_event(CByte(Keys.Menu), 0, KEYEVENTF_KEYUP, 0) ' release Alt
    '        keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYDOWN, 0)  ' press Control
    '        keybd_event(CByte(Keys.Z), 0, KEYEVENTF_KEYDOWN, 0) ' press Z
    '        keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0) ' release Control
    '    Else
    '        strKeyText = strButtonText(Index)
    '        Post_keys()
    '    End If
    'End Sub
    Private Sub Post_keys()
        ' flip to previous window
        keybd_event(CByte(Keys.Menu), 0, KEYEVENTF_KEYDOWN, 0)  ' press Alt
        keybd_event(CByte(Keys.Tab), 0, KEYEVENTF_KEYDOWN, 0)  ' press tab
        keybd_event(CByte(Keys.Tab), 0, KEYEVENTF_KEYUP, 0)  ' release Tab
        keybd_event(CByte(Keys.Menu), 0, KEYEVENTF_KEYUP, 0) ' release Alt
        iStrLen = Len(strKeyText)
        For iChar = 1 To iStrLen
            strChar = Mid(strKeyText, iChar, 1)

            If InStr(strPunctuationList, strChar) > 0 Then
                Punctuation_char()    ' Punctuation mark
            Else
                If strChar = "{" Then
                    Special_char()    ' Special char (eg Return)
                Else
                    Single_char()     ' Regular char
                End If
            End If
        Next iChar
    End Sub
    Private Sub Punctuation_char()
        Dim i As Integer
        ' Is shift required
        i = InStr(strShiftList, strChar)
        Select Case strChar
            Case "["
                iKbdVal = VK_OEM_4
            Case "]"
                iKbdVal = VK_OEM_6
            Case ":"
                iKbdVal = VK_OEM_1
            Case "¬"
                iKbdVal = VK_OEM_8
            Case "~"
                iKbdVal = VK_OEM_7
            Case ";"
                iKbdVal = VK_OEM_1
            Case "'"
                iKbdVal = VK_OEM_8
            Case "#"
                iKbdVal = VK_OEM_7
            Case "<"
                iKbdVal = VK_OEM_COMMA
            Case ">"
                iKbdVal = VK_OEM_PERIOD
            Case "?"
                iKbdVal = VK_OEM_2
            Case ","
                iKbdVal = VK_OEM_COMMA
            Case "."
                iKbdVal = VK_OEM_PERIOD
            Case "/"
                iKbdVal = VK_OEM_2
            Case "|"
                iKbdVal = VK_OEM_5
            Case "\"
                iKbdVal = VK_OEM_5
            Case "_"
                iKbdVal = VK_OEM_MINUS
            Case "+"
                iKbdVal = VK_OEM_PLUS
            Case "-"
                iKbdVal = VK_OEM_MINUS
            Case "="
                iKbdVal = VK_OEM_PLUS
            Case " "
                iKbdVal = VK_SPACE
            Case "@"
                iKbdVal = 192
        End Select

        If i > 0 Then
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0)
        Else
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
        End If
    End Sub
    Private Sub Single_char()
        Dim i As Integer
        strUChar = UCase(strChar)
        If IsNumeric(strChar) Then
            strChar = ""
        End If
        ' find char in shift list and apply shift to unshifted character
        iKbdVal = Asc(strUChar)
        i = InStr(strShiftList, strUChar)
        If i > 0 Then
            strChar = Mid(strNoShiftList, i, 1)
            iKbdVal = Asc(strChar)
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0)
        Else
            '   if char is uppercase then apply shift
            If strUChar = strChar Then
                keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, 0)
                keybd_event(iKbdVal, 0, KEYEVENTF_KEYDOWN, 0)
                keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
                keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0)
            Else
                keybd_event(iKbdVal, 0, KEYEVENTF_KEYDOWN, 0)
                keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            End If
        End If
    End Sub
    Private Sub Special_char()
        Dim strSpecial As String
        Dim oPos As Integer
        Dim cPos As Integer
        Dim lShift As Boolean
        Dim strBracketTest As String

        lShift = False
        strSpecial = ""
        strBracketTest = Mid(strKeyText, iChar, 3)

        Select Case strBracketTest
            Case "{{}"
                lShift = True
                iKbdVal = VK_OEM_4
                iChar = iChar + 2
            Case "{}}"
                lShift = True
                iKbdVal = VK_OEM_6
                iChar = iChar + 2
            Case Else
                oPos = iChar + 1
                cPos = InStr(oPos, strKeyText, "}")
                If cPos = 0 Then
                    cPos = Len(strKeyText) + 1
                    iChar = Len(strKeyText)
                Else
                    iChar = cPos
                End If
                strSpecial = Mid(strKeyText, oPos, cPos - oPos)
                Select Case strSpecial
        '        Case "."
        '            iKbdVal = vbKeyDecimal
                    Case "Return"
                        iKbdVal = Keys.Return
                    Case "BackTab"
                        lShift = True
                        iKbdVal = Keys.Tab
                    Case "Tab"
                        iKbdVal = Keys.Tab
                    Case "Left"
                        iKbdVal = Keys.Left
                    Case "Right"
                        iKbdVal = Keys.Right
                    Case "Up"
                        iKbdVal = Keys.Up
                    Case "Down"
                        iKbdVal = Keys.Down
        '        Case "Space"
        '            iKbdVal = vbKeySpace
                    Case "PgUp"
                        iKbdVal = Keys.PageUp
                    Case "PgDn"
                        iKbdVal = Keys.PageDown
                    Case "Insert"
                        iKbdVal = VK_INSERT
                    Case "Delete"
                        iKbdVal = VK_DELETE
                    Case "Home"
                        iKbdVal = VK_HOME
                    Case "End"
                        iKbdVal = VK_END
                    Case Else
                        iKbdVal = Keys.Multiply
                End Select
        End Select
        If lShift Then
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0)
        Else
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYDOWN, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
        End If


    End Sub
    'Private Sub cmdText_MouseUp(Index As Integer, Button As Integer, Shift As Integer, x As Single, y As Single)
    '    '   Right Button causes menu to pop up
    '    If Button = vbRightButton Then
    '        mnuBtnEdit.Enabled = True
    '        mnuBtnDelete.Enabled = True
    '        mnuClipCopy.Enabled = True
    '        mnuTransferGrp.Enabled = True

    '        iCurrBtn = Index        ' icurrbtn set to button under mouse
    '        PopupMenu(mnuButtons)
    '    End If
    'End Sub
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
        Dim fulladdr As String
        Dim dtDob As Date
        Dim strAge As String
        'Dim bBoldIt As Boolean
        'Dim iFldCt As Integer

        'bBoldIt = False
        fname = ""
        lname = ""
        fullname = ""
        add1 = ""
        add2 = ""
        town = ""
        county = ""
        country = ""
        pcode = ""
        fulladdr = ""



        Dim oRow As TypeRightDataSet.sendersRow = GetSenderById(sndKey)
        Dim oTable As New TypeRightDataSet.sendersDataTable
        fname = oRow.firstname
        lname = oRow.lastname
        add1 = If(oRow.Isaddress1Null, "", oRow.address1)
        add2 = If(oRow.Isaddress2Null, "", oRow.address2)
        town = If(oRow.IstownNull, "", oRow.town)
        county = If(oRow.IscountyNull, "", oRow.county)
        pcode = If(oRow.IspostcodeNull, "", oRow.postcode)
        dtDob = If(oRow.IsdobNull, Date.MinValue, oRow.dob)
        fullname = Trim(fname & " " & lname)
        Dim addBuilder As New StringBuilder
        If Not String.IsNullOrEmpty(add1) Then
            addBuilder.Append(add1)
        End If
        If Not String.IsNullOrEmpty(add2) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{Return}")
            End If
            addBuilder.Append(add2)
        End If
        If Not String.IsNullOrEmpty(town) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{Return}")
            End If
            addBuilder.Append(town)
        End If
        If Not String.IsNullOrEmpty(county) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{Return}")
            End If
            addBuilder.Append(county)
        End If
        If Not String.IsNullOrEmpty(pcode) Then
            If addBuilder.Length > 0 Then
                addBuilder.Append("{Return}")
            End If
            addBuilder.Append(pcode)
        End If
        fulladdr = addBuilder.ToString
        strAge = Format(calc_age(dtDob))

        AddButton(1, "Full Name", fullname, strButtonFont, 9.0, fullname.Substring(0, Math.Min(fullname.Length, 50)), False, False)
        AddButton(2, "Full Addr", fulladdr, strButtonFont, 9.0, fulladdr.Substring(0, Math.Min(fulladdr.Length, 50)), False, False)

        iBct = 2
        'B = 1

        For Each _col As DataColumn In oTable.Columns
            strButtonValue = oRow(_col.ColumnName)
            strButtonTxt = _col.ColumnName
            strButtonCaption = strButtonTxt.Substring(0, Math.Min(strButtonTxt.Length, 10))
            strButtonHint = strButtonValue.Substring(0, Math.Min(strButtonValue.Length, 50))

            AddButton(B + iBct, strButtonCaption, strButtonValue, strButtonFont, 9.0, strButtonHint, False, False)

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
            Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(btnId, iActGrpNo, btnSeq, btnCaption, btnHint, btnValue, btnFontname,
                                                                            btnSize, isBold, isItalic, isEncrypt, Nbutton.DataSource.Group).Build
            groupButtonList.Add(_nbutton)
        End If

    End Sub
    Public Sub LoadGroupButtons(grpNo As Long)
        groupButtonList.Clear()
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
    'Private Sub AddButton(iPos As Integer, strText As String, strCaption As String, strFont As String, strHint As String, bBold As Boolean)
    '    Dim strFontName As String
    '    Dim iFontSize As Long
    '    Dim bFontItalic As Boolean
    '    Dim pos1 As Long
    '    Dim pos2 As Long

    '    If cmdText.Count < iPos + 1 Then
    '        Load(cmdText(iPos))
    '    End If

    '    strButtonText(iPos) = strText
    '    cmdText(iPos).Caption = strCaption
    '    cmdText(iPos).FontBold = bBold
    '    cmdText(iPos).ToolTipText = strHint
    '    If strFont <> "" Then
    '        pos1 = InStr(strFont, "\")
    '        pos2 = InStr(pos1 + 1, strFont, "\")
    '        strFontName = Left(strFont, InStr(strFont, "\") - 1)
    '        iFontSize = CLng(Mid(strFont, pos1 + 1, pos2 - pos1 - 1))
    '        If Right(strFont, 2) = "\I" Then
    '            bFontItalic = True
    '        End If
    '        cmdText(iPos).FontName = strFontName
    '        cmdText(iPos).FontSize = iFontSize
    '        cmdText(iPos).FontItalic = bFontItalic
    '    End If
    '    cmdText(iPos).Visible = True  ' Make new button visible.

    'End Sub
    'Private Sub Form_MouseMove(Button As Integer, Shift As Integer, x As Single, y As Single)
    '    Static Message As Long
    '    Static RR As Boolean

    '    'x is the current mouse location along the x-axis
    '    Message = x / Screen.TwipsPerPixelX

    '    If RR = False Then
    '        RR = True
    '        If Me.WindowState = vbMinimized Then    ' If reduced to tray icon
    '            Select Case Message
    '            ' Left click (This should open the keylist)
    '                Case WM_LBUTTONUP
    '                    Me.WindowState = vbNormal
    '                    Me.Show()
    '            ' Right button up (This should bring up a menu)
    '                Case WM_RBUTTONUP
    '                    Me.PopupMenu(mnuPopup)
    '            End Select
    '        End If
    '        RR = False
    '    End If
    'End Sub
    'Private Sub Form_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
    '    '   Right Button causes menu to pop up
    '    If Button = vbRightButton Then
    '        mnuBtnEdit.Enabled = False
    '        mnuBtnDelete.Enabled = False
    '        mnuClipCopy.Enabled = False
    '        mnuTransferGrp.Enabled = False

    '        PopupMenu(mnuButtons)
    '    End If

    'End Sub
    'Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    '    If UnloadMode = vbFormControlMenu Then  'unload just minimises to tray icon
    '        Me.WindowState = vbMinimized
    '        Cancel = True
    '    End If
    'End Sub
    'Friend Sub Form_Resize()
    '    Dim iNewColCt
    '    If Me.WindowState = 1 Then
    '        'If minimized selected
    '        Call Shell_NotifyIcon(NIM_ADD, IconData)
    '        ' Add the form's icon to the tray
    '        Me.Hide()
    '        ' Hide the button at the taskbar
    '        Exit Sub
    '    End If

    '    If lResizeActive Then
    '        If bNewWidth Then
    '            bNewWidth = False
    '            iNewColCt = iColCt
    '        Else
    '            iNewColCt = Int(FrmButtonList.Width / iButtonWidth)
    '        End If
    '        If iNewColCt < 1 Then
    '            iNewColCt = 1
    '        End If
    '        If iNewColCt <> iColCt Then
    '            iColCt = iNewColCt
    '            oRegistry.WriteString(strApplication & "Options", "Columns", Format(iColCt))
    '        End If
    '        DrawButtons()
    '    End If
    'End Sub
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
            oPanel.Controls.Add(oBtn)
            oBtn.Top = 1 + (iBtnRow * 27)
            oBtn.Left = 1 + (iBtnCol * iButtonWidth)
            oBtn.Size = New Drawing.Size(iButtonWidth, 27)
            oBtn.Visible = True
            oBtn.ContextMenuStrip = mnuButtons
            iBtnRow += 1
            If iBtnRow > iRowCt - 2 Then
                If iBtnCol > iMod - 1 And iMod > 0 Then
                    Debug.Print("yes")
                    iBtnCol += 1
                    iBtnRow = 0
                    Continue For
                Else
                    Debug.Print("no")
                    If iBtnRow > iRowCt - 1 Then
                        iBtnCol += 1
                        iBtnRow = 0
                    End If
                End If
            End If
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
    Public Function calc_age(dtDob As DateTime) As Integer
        Dim fmm As Integer
        Dim tmm As Integer
        Dim age As Integer

        fmm = Month(dtDob)
        tmm = Month(Now)
        age = Year(Now) - Year(dtDob)
        If fmm > tmm Or (fmm = tmm And dtDob.Day > Now.Day) Then
            age = age - 1
        End If
        calc_age = age
    End Function

    Private Sub imgExit_Click(sender As Object, e As EventArgs) Handles imgExit.Click
        SavePosition
        Me.Close()
    End Sub

    Private Sub SavePosition()
        My.Settings.Top = Me.Top
        My.Settings.Left = Me.Left
        My.Settings.Minimise = Me.WindowState = FormWindowState.Minimized
        My.Settings.Save()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles ImgLock.Click
        GreenClock.Visible = False
        WhiteClock.Visible = True
        RedClock.Visible = False
        bLockClock = False
        ImgLock.Visible = False
    End Sub

    Private Sub DelayTimer_Tick(sender As Object, e As EventArgs) Handles DelayTimer.Tick
        Dim lcurhwnd As Long
        DelayTimer.Enabled = False
        ProgressBar1.Visible = False
        lcurhwnd = GetForegroundWindow()

        If bLockClock Then
            If RedClock.Visible Then
                RedClock.Visible = False
                GreenClock.Visible = True
                If lcurhwnd <> Me.Handle.ToInt32 Then
                    Post_keys()
                End If
            End If
        Else
            If RedClock.Visible Then
                RedClock.Visible = False
                WhiteClock.Visible = True
                If lcurhwnd <> Me.Handle.ToInt32 Then
                    Post_keys()
                End If
            End If
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
                bLockClock = False
                ImgLock.Visible = False
            End If
        End If
    End Sub

    Private Sub Clock_DoubleClick(sender As Object, e As EventArgs) Handles WhiteClock.DoubleClick, GreenClock.DoubleClick, RedClock.DoubleClick
        If Not (bLockClock) Then
            bLockClock = True
            ImgLock.Visible = True
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

    Private Sub mnuButtons_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuButtons.Opening

    End Sub



#End Region
End Class