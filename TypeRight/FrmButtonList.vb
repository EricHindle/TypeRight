Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports NbuttonControlLibrary
Public Class FrmButtonList
    Const KEYEVENTF_EXTENDEDKEY = &H1
    Const KEYEVENTF_KEYUP = &H2
    Public strKeyText As String
    Public iChar As Integer
    Public strChar As String
    Public strUChar As String
    Public iStrLen As Integer
    Public iKbdVal As Integer
    Public strIniTxt As String
    Public bOnTop As Boolean
    Public strShiftList As String
    Public strNoShiftList As String
    Public strPunctuationList As String
    Public strButtonHint As String
    Public bButtonBold As Boolean
    Public strButtonFont As String

    Dim iBct As Integer
    Dim lResizeActive As Boolean
    Dim lMoving As Boolean

    Dim buttonList As List(Of Nbutton)
    Dim senderButtonList As List(Of Nbutton)

    Dim buttonBuilder As New NButtonBuilder



    ' Extracts a string from an .ini file
    ' lpAppName = section in square brackets e.g. [Projects] but don't include brackets
    ' lpFileName = ini file name including path
    ' lpVariable = variable value to return
    ' lpDefault = default value to return if not found

    Dim spath As String
    Private Sub BtnReDraw_Click(sender As Object, e As EventArgs) Handles BtnReDraw.Click

        Dim iBct As Integer
        If cbNames.SelectedIndex > -1 Then
            For iBct = iButtonCt To 1 Step -1
                Unload(cmdText(iBct))
            Next iBct
            iButtonCt = 0
            iListidx = cboNames.ListIndex
            If Left(cboNames.List(iListidx), 3) = "** " Then
                LoadButtons(cboNames.ItemData(iListidx))
                DrawButtons()
            Else
                LoadDbButtons()
                DrawButtons()
            End If
            FrmButtonList.Caption = cboNames.List(iListidx)
            iCurrGrp = cboNames.ItemData(iListidx)
        End If
    End Sub

    Private Sub cmdText_Click(Index As Integer)
        If Index = 0 Then
            keybd_event(vbKeyMenu, 0, 0, 0) ' press Alt
            keybd_event(vbKeyTab, 0, 0, 0) ' press tab
            keybd_event(vbKeyTab, 0, KEYEVENTF_KEYUP, 0) ' release Tab
            keybd_event(vbKeyMenu, 0, KEYEVENTF_KEYUP, 0) ' release Alt
            keybd_event(vbKeyControl, 0, 0, 0)  ' press Control
            keybd_event(vbKeyZ, 0, 0, 0) ' press Z
            keybd_event(vbKeyControl, 0, KEYEVENTF_KEYUP, 0) ' release Control
        Else
            strKeyText = strButtonText(Index)
            post_keys()
        End If
    End Sub

    Private Sub post_keys()
        ' flip to previous window
        keybd_event(vbKeyMenu, 0, 0, 0)  ' press Alt
        keybd_event(vbKeyTab, 0, 0, 0)  ' press tab
        keybd_event(vbKeyTab, 0, KEYEVENTF_KEYUP, 0)  ' release Tab
        keybd_event(vbKeyMenu, 0, KEYEVENTF_KEYUP, 0) ' release Alt
        iStrLen = Len(strKeyText)

        For iChar = 1 To iStrLen
            strChar = Mid(strKeyText, iChar, 1)

            If InStr(strPunctuationList, strChar) > 0 Then
                punctuation_char()    ' Punctuation mark
            Else
                If strChar = "{" Then
                    special_char()    ' Special char (eg Return)
                Else
                    single_char()     ' Regular char
                End If
            End If
        Next iChar

    End Sub

    Private Sub punctuation_char()
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
            keybd_event(vbKeyShift, 0, 0, 0)
            keybd_event(iKbdVal, 0, 0, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            keybd_event(vbKeyShift, 0, KEYEVENTF_KEYUP, 0)
        Else
            keybd_event(iKbdVal, 0, 0, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
        End If
    End Sub

    Private Sub single_char()
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
            keybd_event(vbKeyShift, 0, 0, 0)
            keybd_event(iKbdVal, 0, 0, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            keybd_event(vbKeyShift, 0, KEYEVENTF_KEYUP, 0)
        Else
            '   if char is uppercase then apply shift
            If strUChar = strChar Then
                keybd_event(vbKeyShift, 0, 0, 0)
                keybd_event(iKbdVal, 0, 0, 0)
                keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
                keybd_event(vbKeyShift, 0, KEYEVENTF_KEYUP, 0)
            Else
                keybd_event(iKbdVal, 0, 0, 0)
                keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            End If
        End If
    End Sub

    Private Sub special_char()
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
                        iKbdVal = vbKeyReturn
                    Case "BackTab"
                        lShift = True
                        iKbdVal = vbKeyTab
                    Case "Tab"
                        iKbdVal = vbKeyTab
                    Case "Left"
                        iKbdVal = vbKeyLeft
                    Case "Right"
                        iKbdVal = vbKeyRight
                    Case "Up"
                        iKbdVal = vbKeyUp
                    Case "Down"
                        iKbdVal = vbKeyDown
        '        Case "Space"
        '            iKbdVal = vbKeySpace
                    Case "PgUp"
                        iKbdVal = vbKeyPageUp
                    Case "PgDn"
                        iKbdVal = vbKeyPageDown
                    Case "Insert"
                        iKbdVal = VK_INSERT
                    Case "Delete"
                        iKbdVal = VK_DELETE
                    Case "Home"
                        iKbdVal = VK_HOME
                    Case "End"
                        iKbdVal = VK_END
                    Case Else
                        iKbdVal = vbKeyMultiply
                End Select
        End Select
        If lShift Then
            keybd_event(vbKeyShift, 0, 0, 0)
            keybd_event(iKbdVal, 0, 0, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
            keybd_event(vbKeyShift, 0, KEYEVENTF_KEYUP, 0)
        Else
            keybd_event(iKbdVal, 0, 0, 0)
            keybd_event(iKbdVal, 0, KEYEVENTF_KEYUP, 0)
        End If


    End Sub

    Private Sub cmdText_MouseUp(Index As Integer, Button As Integer, Shift As Integer, x As Single, y As Single)
        '   Right Button causes menu to pop up
        If Button = vbRightButton Then
            mnuBtnEdit.Enabled = True
            mnuBtnDelete.Enabled = True
            mnuClipCopy.Enabled = True
            mnuTransferGrp.Enabled = True

            iCurrBtn = Index        ' icurrbtn set to button under mouse
            PopupMenu(mnuButtons)
        End If
    End Sub



    Private Sub LoadOptions()
        Dim strwidth As String
        Dim strcols As String
        strwidth = oRegistry.ReadString(strApplication & "Options", "ButtonWidth", "1200")
        strcols = oRegistry.ReadString(strApplication & "Options", "Columns", "1")
        iTransPerc = CInt(oRegistry.ReadString(strApplication & "Options", "Transparency", "25"))
        iGroups = CInt(oRegistry.ReadString(strApplication & "Options", "Groups", "1"))
        If strwidth <> lpDefault Then
            iButtonWidth = CInt(strwidth)
        Else
            iButtonWidth = 1000
        End If
        If strcols <> lpDefault Then
            iColCt = CInt(strcols)
        Else
            iColCt = 1
        End If
        FrmButtonList.Width = (iColCt * iButtonWidth) + 120
        cmdText(0).Width = iButtonWidth
    End Sub

    Private Sub LoadDbButtons()
        '
        Dim sSql As String
        Dim strBct As String
        Dim B As Integer
        Dim strButtonTxt As String
        Dim strButtonValue As String
        Dim xxx As String
        Dim yyy As String
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
        Dim bBoldIt As Boolean
        Dim iFldCt As Integer

        bBoldIt = False
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


        If cbNames.SelectedIndex > -1 Then
            Dim oRow As TypeRightDataSet.sendersRow = GetSenderById(cbNames.SelectedValue)

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
            AddButton(1, fullname, "Full Name", strButtonFont, fullname, bBoldIt)
            AddButton(2, fulladdr, "Full Addr", strButtonFont, fulladdr.Substring(0, 15), bBoldIt)

            iBct = 2
            B = 1

            For Each _col As DataColumn In oTable.Columns
                strButtonValue = oRow(_col.ColumnName).value
                strButtonTxt = _col.ColumnName
                strButtonCaption = strButtonTxt.Substring(0, 8)
                strButtonHint = strButtonValue.Substring(0, 15)
                If B + iBct > iButtonCt Then
                    iButtonCt = B + iBct
                    buttonList.Add()
                End If
                AddButton(B + iBct, strButtonValue, strButtonCaption, strButtonFont, strButtonHint, bBoldIt)

                B += 1
            Next


            B = iBct + iFldCt
        AddButton(B, strAge, "Age", strButtonFont, strAge, bBoldIt)
        iButtonCt = iButtonCt + 1

        End If
    End Sub

    Public Sub LoadButtons(grpNo As Long)
        buttonList.Clear()
        Dim btnTable As TypeRightDataSet.buttonDataTable = GetButtonsByGroup(grpNo)
        For Each btnRow As TypeRightDataSet.buttonRow In btnTable.Rows
            If Not btnRow.IsbuttonValueNull AndAlso Not String.IsNullOrEmpty(btnRow.buttonValue) Then
                Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(btnRow.buttonId).Build()
                buttonList.Add(_nbutton)
            End If
        Next
        RemoveNButtons()
        LoadNButtons()
    End Sub

    Private Sub LoadNButtons()
        Dim iBtnRow As Integer = 0
        Dim iBtnCol As Integer = 0
        For Each oBtn As Nbutton In buttonList

            ButtonPanel.Controls.Add(oBtn)
            oBtn.Top = grpTop.Top + grpTop.Height + (iBtnRow * BtnModel.Height)
            oBtn.Left = iBtnCol * BtnModel.Width
            oBtn.Size = BtnModel.Size
            Me.Controls.Add(oBtn)
            iBtnRow += 1
            If iBtnRow > iRowCt Then
                iBtnCol += 1
                iBtnRow = 0
            End If
        Next
    End Sub

    Private Sub RemoveNButtons()
        ButtonPanel.Controls.Clear()
    End Sub

    Private Sub AddButton(iPos As Integer, strText As String, strCaption As String, strFont As String, strHint As String, bBold As Boolean)
        Dim strFontName As String
        Dim iFontSize As Long
        Dim bFontItalic As Boolean
        Dim pos1 As Long
        Dim pos2 As Long

        If cmdText.Count < iPos + 1 Then
            Load(cmdText(iPos))
        End If

        strButtonText(iPos) = strText
        cmdText(iPos).Caption = strCaption
        cmdText(iPos).FontBold = bBold
        cmdText(iPos).ToolTipText = strHint
        If strFont <> "" Then
            pos1 = InStr(strFont, "\")
            pos2 = InStr(pos1 + 1, strFont, "\")
            strFontName = Left(strFont, InStr(strFont, "\") - 1)
            iFontSize = CLng(Mid(strFont, pos1 + 1, pos2 - pos1 - 1))
            If Right(strFont, 2) = "\I" Then
                bFontItalic = True
            End If
            cmdText(iPos).FontName = strFontName
            cmdText(iPos).FontSize = iFontSize
            cmdText(iPos).FontItalic = bFontItalic
        End If
        cmdText(iPos).Visible = True  ' Make new button visible.

    End Sub

    Private Sub Form_MouseMove(Button As Integer, Shift As Integer, x As Single, y As Single)
        Static Message As Long
        Static RR As Boolean

        'x is the current mouse location along the x-axis
        Message = x / Screen.TwipsPerPixelX

        If RR = False Then
            RR = True
            If Me.WindowState = vbMinimized Then    ' If reduced to tray icon
                Select Case Message
                ' Left click (This should open the keylist)
                    Case WM_LBUTTONUP
                        Me.WindowState = vbNormal
                        Me.Show()
                ' Right button up (This should bring up a menu)
                    Case WM_RBUTTONUP
                        Me.PopupMenu(mnuPopup)
                End Select
            End If
            RR = False
        End If
    End Sub

    Private Sub Form_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
        '   Right Button causes menu to pop up
        If Button = vbRightButton Then
            mnuBtnEdit.Enabled = False
            mnuBtnDelete.Enabled = False
            mnuClipCopy.Enabled = False
            mnuTransferGrp.Enabled = False

            PopupMenu(mnuButtons)
        End If

    End Sub

    Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
        If UnloadMode = vbFormControlMenu Then  'unload just minimises to tray icon
            Me.WindowState = vbMinimized
            Cancel = True
        End If
    End Sub

    Friend Sub Form_Resize()
        Dim iNewColCt
        If Me.WindowState = 1 Then
            'If minimized selected
            Call Shell_NotifyIcon(NIM_ADD, IconData)
            ' Add the form's icon to the tray
            Me.Hide()
            ' Hide the button at the taskbar
            Exit Sub
        End If

        If lResizeActive Then
            If bNewWidth Then
                bNewWidth = False
                iNewColCt = iColCt
            Else
                iNewColCt = Int(FrmButtonList.Width / iButtonWidth)
            End If
            If iNewColCt < 1 Then
                iNewColCt = 1
            End If
            If iNewColCt <> iColCt Then
                iColCt = iNewColCt
                oRegistry.WriteString(strApplication & "Options", "Columns", Format(iColCt))
            End If
            DrawButtons()
        End If
    End Sub

    Friend Sub DrawButtons()
        Dim iBtnCt As Integer
        Dim iBtnCol As Integer
        Dim iBtnRow As Integer
        Dim iRowCt As Integer
        Dim iRow As Integer
        Dim iCol As Integer
        Dim iMod As Integer
        Dim iLastRow As Integer
        lResizeActive = False
        ' Size of window
        Me.Width = (iColCt * iButtonWidth) + 120
        ' Number of rows
        iRowCt = Int((iButtonCt + 1) / iColCt)
        ' Any left over ? Then add a row
        iMod = (iButtonCt + 1) Mod iColCt
        If iMod > 0 Then
            iRowCt += 1
        End If

        iBtnRow = 0
        iBtnCol = 0
        For Each oBtn In buttonList
            oBtn.Top = grpTop.Top + grpTop.Height + (iBtnRow * BtnModel.Height)
            oBtn.Left = iBtnCol * BtnModel.Width
            oBtn.Size = BtnModel.Size
            Me.Controls.Add(oBtn)
            iBtnRow += 1
            If iBtnRow > iRowCt Then
                iBtnCol += 1
                iBtnRow = 0
            End If
        Next

        Me.Height = (iRowCt * (BtnModel.Height)) + BtnModel.Top + 380 + grpTop.Height
        lResizeActive = True
        ' Reposition the frame that holds the controls at the bottom of the window
        GrpBottom.Top = iRowCt * BtnModel.Height
        GrpBottom.Width = iColCt * BtnModel.Width
        ' Resize the name/group list control
        cbNames.Width = grpTop.Width - 620 - BtnReDraw.Width
        BtnReDraw.Left = cbNames.Left + cbNames.Width + 20

    End Sub

    Private Sub ImgTack_Click()
        If bOnTop Then
            ImgTack.Image = My.Resources.tackdown
        Else
            ImgTack.Image = My.Resources.tackup
        End If
        Me.TopMost = bOnTop
    End Sub


    Public Function calc_age(dtDob) As Integer
        Dim fmm As Integer
        Dim tmm As Integer
        Dim age As Integer

        fmm = Month(dtDob)
        tmm = Month(Now)
        age = Year(Now) - Year(dtDob)
        If fmm > tmm Or (fmm = tmm And Day(dtDob) > Day(Now)) Then
            age = age - 1
        End If
        calc_age = age
    End Function




    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        FrmOptions.Show()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.WindowState = vbNormal
        Me.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        Dim strText As String
        Clipboard.Clear
        strText = strButtonText(iCurrBtn)
        strText = Replace(strText, "{Return}", Chr(10))
        strText = Replace(strText, "{{}", "{")
        strText = Replace(strText, "{}}", "}")
        Clipboard.SetText(strText)
    End Sub

    Private Sub NewButtonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewButtonToolStripMenuItem.Click

        Dim newBtn As Nbutton = NButtonBuilder.NewButton.Build




        Dim iBtCt As Integer
        If Left(cboNames.List(iListidx), 3) = "** " Then
            For iBtCt = 1 To iButtonCt
                Unload(cmdText(iBtCt)) 'unload all buttons
            Next iBtCt
            ' add new item to database
            With rsButtons
                .AddNew
                !btnCaption = "New"
                !btnValue = "?"
                !btnHint = ""
                !btnFont = ""
                !BtnBold = False
                !BtnGrp = cboNames.ItemData(cboNames.ListIndex)
                !btnSeq = 99
                .Update
            End With
            ReSeqButtons
            iButtonCt = 0
            '   Reload and redraw buttons
            LoadButtons(cboNames.ItemData(cboNames.ListIndex))
            DrawButtons()
            iCurrBtn = iButtonCt
            ' set new button as current button and edit
            FrmEditButton.Show()

        End If
    End Sub

    Private Sub EditButtonToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles EditButtonToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is Nbutton Then
            Dim _btn As Nbutton = CType(sourceControl, Nbutton)
            Using _editForm As New FrmEditButton
                _editForm.Button = _btn
                _editForm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub DeleteButtonToolStripMenuItem_Click(menuItem As Object, e As EventArgs) Handles DeleteButtonToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is Nbutton Then
            Dim _btn As Nbutton = CType(sourceControl, Nbutton)
            DeleteButton(_btn.Id)
            LoadButtons(_btn.Group)
        End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        iGrpAction = GRP_ADD
        FrmGroupMaint.Show()
    End Sub

    Private Sub ChangeNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeNameToolStripMenuItem.Click
        iGrpAction = GRP_CHG
        FrmGroupMaint.Show()
    End Sub

    Private Sub TransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferToolStripMenuItem.Click
        iGrpAction = GRP_TRANS
        FrmGroupMaint.Show()
    End Sub

    Private Sub OptionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem1.Click
        FrmOptions.Show()
    End Sub

    Private Sub ImgTackDn_Click(sender As Object, e As EventArgs) Handles ImgTack.Click
        bOnTop = Not (bOnTop)
        ImgTack_Click()

    End Sub

    Private Sub FrmButtonList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TypeRightDataSet.senders' table. You can move, or remove it, as needed.
        Me.SendersTableAdapter.Fill(Me.TypeRightDataSet.senders)
        grpTop.Visible = isPro
        mnuGroups.Visible = isPro
        mnuSep3.Visible = isPro
        bNewWidth = False
        lResizeActive = False
        Me.Opacity = My.Settings.Transparency
        GrpBottom.Visible = bToolBar
        strShiftList = "!" + Chr(34) + "£$%^&*(){}@:~<>?_+"
        strPunctuationList = "[]:@~;'#<>?,./|\_+-= "
        strNoShiftList = "1234567890"
        ' Make window stay on top or not depending on options
        ImgTack_Click()
        BtnModel.Width = iButtonWidth
        Me.Top = iTop
        Me.Left = iLeft
        iButtonCt = 0
        If bToolBar Then
            ButtonPanel.Top = grpTop.Height
        Else
            ButtonPanel.Top = 0
        End If
        cbNames.SelectedIndex = 0
        If iCurrGrp > 0 Then
            bUserDefinedGroup = False



            cbNames.SelectedIndex = cbNames.find

            LoadDbButtons(iCurrGrp)
        Else
            bUserDefinedGroup = True
            Do Until cboNames.ItemData(cboNames.ListIndex) = iCurrGrp
                cboNames.ListIndex = cboNames.ListIndex + 1
            Loop
            LoadButtons iCurrGrp
    End If

        Caption = cboNames.List(cbNames.SelectedItem)
        iListidx = cboNames.ListIndex
        DrawButtons()
        lResizeActive = True
        imgClock(0).Visible = True
        imgClock(1).Visible = False
        imgClock(2).Visible = False
        DelayTimer.Enabled = False
        bLockClock = False
        If bMinimise Then
            Me.WindowState = vbMinimized
        Else
            Me.WindowState = vbNormal
        End If
    End Sub

End Class