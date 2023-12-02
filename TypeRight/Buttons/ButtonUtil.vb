' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports HindlewareLib.Logging
Imports HindlewareLib.Security
Imports NbuttonControlLibrary
Module ButtonUtil
#Region "enum"
    Friend Enum ReplaceType
        None
        Split
        Substring
    End Enum
#End Region
#Region "constants"
    Public Const FRAME_WIDTH As Integer = 18
    Public Const SUB_START_MARKER As String = "$="
    Public Const SUB_MID_MARKER As String = "$$"
    Public Const SUB_END_MARKER As String = "=$"
    Public Const FIELD_START_MARKER As String = "?="
    Public Const FIELD_END_MARKER As String = "=?"
    Public Const SPLIT_START_MARKER As String = "/="
    Public Const SPLIT_MID_MARKER As String = "//"
    Public Const SPLIT_END_MARKER As String = "=/"
#End Region
#Region "variables"
    Public tooltipcommon As New Windows.Forms.ToolTip
    Private strButtonHint As String
    Private oButtonList As List(Of Nbutton)
    Private oCurrentSender As New Sender
#End Region
#Region "subroutines"
    Private Sub AddButtonToList(btnSeq As Integer, oButton As SenderButton, btnCaption As String, btnValue As String, btnHint As String)
        Dim isButtonBold As Boolean
        Dim isButtonItalic As Boolean
        Dim strButtonFontName As String
        Dim dButtonFontSize As Decimal
        If Not oButton.IsEmpty Then
            isButtonBold = oButton.Bold
            isButtonItalic = oButton.Italic
            strButtonFontName = oButton.FontName
            dButtonFontSize = oButton.FontSize
        Else
            strButtonFontName = My.Settings.FontName
            isButtonBold = My.Settings.FontBold
            isButtonItalic = My.Settings.FontItalic
            dButtonFontSize = My.Settings.FontSize
        End If
        If btnValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(btnValue) Then
            Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(-1, -1, btnSeq, btnCaption, btnHint, btnValue, strButtonFontName, dButtonFontSize, isButtonBold, isButtonItalic, False, Nbutton.DataSource.Sender).Build
            oButtonList.Add(_nbutton)
        End If
    End Sub
    Public Sub RemovePanelButtons(ByRef ButtonPanel As Panel)
        ButtonPanel.Controls.Clear()
    End Sub
#End Region
#Region "functions"
    Public Function LoadSenderButtons(sndKey As Integer, oSenderRow As TypeRightDataSet.sendersRow) As List(Of Nbutton)

        oButtonList = New List(Of Nbutton)
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
        oCurrentSender = GetSenderById(sndKey)
        If Not oCurrentSender.IsEmpty Then
            Dim iBct As Integer
            fname = oCurrentSender.FirstName
            lname = oCurrentSender.LastName
            add1 = oCurrentSender.Address1
            add2 = oCurrentSender.Address2
            town = oCurrentSender.Town
            county = oCurrentSender.County
            country = oCurrentSender.Country
            username = oCurrentSender.Username
            pcode = oCurrentSender.PostCode
            dtDob = oCurrentSender.DateOfBirth
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
            Dim oSenderTable As New TypeRightDataSet.sendersDataTable
            Dim senderButton As SenderButton
            For Each _col As DataColumn In oSenderTable.Columns
                senderButton = GetSenderButton(_col.ColumnName)
                strButtonValue = If(IsDBNull(oSenderRow(_col.ColumnName)), "", oSenderRow(_col.ColumnName))
                If senderButton IsNot Nothing AndAlso senderButton.IsEncrypted Then
                    strButtonValue = EncryptionUtil.DecryptText(strButtonValue, My.Resources.APP_STRING)
                End If
                strButtonTxt = _col.ColumnName
                strButtonCaption = strButtonTxt.Substring(0, Math.Min(strButtonTxt.Length, 20))
                strButtonHint = strButtonValue.Substring(0, Math.Min(strButtonValue.Length, 50))
                AddButtonToList(iBct, senderButton, strButtonCaption, strButtonValue, strButtonHint)
                iBct += 1
            Next
            Dim caption As String = "Full Name"
            AddButtonToList(iBct, GetSenderButton(caption), caption, fullname, fullname.Substring(0, Math.Min(fullname.Length, 50)))
            iBct += 1
            caption = "Full Addr"
            AddButtonToList(iBct, GetSenderButton(caption), caption, fulladdr, fulladdr.Substring(0, Math.Min(fulladdr.Length, 50)))
            iBct += 1
            caption = "Age"
            AddButtonToList(iBct, GetSenderButton(caption), caption, strAge, strAge)
        End If
        Return oButtonList
    End Function
    Public Function LoadGroupButtons(grpNo As Long) As List(Of Nbutton)
        Dim groupButtonList As New List(Of Nbutton)
        Dim _nbb As New NButtonBuilder
        Dim undoButton As Nbutton = _nbb.StartingWith(0, grpNo, 0, "Undo", "", "^z", "Tahoma", 10, False, False, False, Nbutton.DataSource.Undefined).Build
        groupButtonList.Add(undoButton)
        Dim btnTable As TypeRightDataSet.buttonDataTable = GetButtonsByGroup(grpNo)
        For Each btnRow As TypeRightDataSet.buttonRow In btnTable.Rows
            If Not String.IsNullOrEmpty(btnRow.buttonValue) Then
                Dim _nbutton As Nbutton = NButtonBuilder.NewButton.StartingWith(btnRow.buttonId).Build()
                groupButtonList.Add(_nbutton)
            End If
        Next
        If Int(groupButtonList.Count / 2) * 2 <> groupButtonList.Count Then
            groupButtonList.Add(NButtonBuilder.NewButton.WithValue("").WithFontSize(10).Build)
        End If
        Return groupButtonList
    End Function
    Public Function FillButtonPanel(ByRef oPanel As Panel, ByRef oList As List(Of Nbutton), Optional rowOffset As Integer = 0, ByRef Optional buttonMenu As ContextMenuStrip = Nothing) As Integer
        iButtonCt = oList.Count
        Dim iRowCt As Integer = iButtonCt / iColCt
        ' Any left over ? Then add a row
        Dim iMod As Integer = iButtonCt Mod iColCt
        If iColCt * iRowCt < oList.Count Then
            iRowCt += 1
        End If
        oPanel.Height = (iRowCt + rowOffset) * 27
        Dim iBtnRow As Integer = 0
        Dim iBtnCol As Integer = 0
        Dim iMaxRow As Integer = 0
        For Each oBtn In oList
            Dim actualRow As Integer = iBtnRow + rowOffset
            oPanel.Controls.Add(oBtn)
            tooltipcommon.SetToolTip(oBtn.Button1, oBtn.Value)
            oBtn.Top = 0 + (actualRow * 27)
            oBtn.Left = 0 + (iBtnCol * iButtonWidth)
            oBtn.Size = New Drawing.Size(iButtonWidth, 27)
            oBtn.Visible = True
            If buttonMenu IsNot Nothing Then
                oBtn.ContextMenuStrip = buttonMenu
            End If
            oBtn.Name = oPanel.Name & actualRow & iBtnCol
            iBtnRow += 1
            If actualRow > iMaxRow Then iMaxRow = actualRow
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
        Return iMaxRow
    End Function
    Public Function Calc_age(dtDob As DateTime) As Integer
        Dim fmm As Integer
        Dim tmm As Integer
        Dim age As Integer
        fmm = Month(dtDob)
        tmm = Month(Now)
        age = Year(Now) - Year(dtDob)
        If fmm > tmm Or (fmm = tmm And dtDob.Day > Now.Day) Then
            age -= 1
        End If
        Return age
    End Function
    '
    ' Look for database field names and replace with values from the database
    '
    Public Function GetDBFieldValues(ByVal sKeyText As String, oSenderRow As TypeRightDataSet.sendersRow) As String
        Dim fieldName As String
        Dim fieldValue As String
        Dim newText As String = sKeyText
        fieldName = GetValueBetweenBrackets(newText, FIELD_START_MARKER, FIELD_END_MARKER)
        Dim _senderButton As SenderButton
        Do Until String.IsNullOrEmpty(fieldName)
            _senderButton = GetSenderButton(fieldName)
            fieldValue = If(IsDBNull(oSenderRow(fieldName)), "", CStr(oSenderRow(fieldName)))
            If _senderButton IsNot Nothing AndAlso _senderButton.IsEncrypted Then
                fieldValue = EncryptionUtil.DecryptText(fieldValue, My.Resources.APP_STRING)
            End If
            newText = newText.Replace(FIELD_START_MARKER & fieldName & FIELD_END_MARKER, fieldValue)
            fieldName = GetValueBetweenBrackets(newText, FIELD_START_MARKER, FIELD_END_MARKER)
        Loop
        Return newText
    End Function
    '
    ' apply substring or select words from text according to delimiters
    ' process nested delimiters first
    '
    Public Function EditFieldValues(ByVal sKeyText As String, ByVal pReplaceType As ReplaceType) As String
        Dim newText As String = sKeyText
        Do While newText.Contains(SUB_START_MARKER) Or newText.Contains(SPLIT_START_MARKER)
            Dim _replaceType As ReplaceType
            Dim subText As String = GetSubtext(newText, _replaceType)
            Dim isSub As Boolean = _replaceType = ReplaceType.Substring
            Dim isSplit As Boolean = _replaceType = ReplaceType.Split
            If subText.Contains(SUB_START_MARKER) Or subText.Contains(SPLIT_START_MARKER) Then
                Dim editedText As String = EditFieldValues(subText, _replaceType)
                newText = newText.Replace(subText, editedText)
                Continue Do
            Else
                newText = EditText(newText, subText, _replaceType)
            End If
        Loop
        Return newText
    End Function
    Private Function EditText(newtext As String, subtext As String, _replacetype As ReplaceType) As String
        If _replacetype = ReplaceType.Substring Then
            newtext = GetSubstring(newtext, subtext)
        ElseIf _replacetype = ReplaceType.Split Then
            newtext = GetWord(newtext, subtext)
        End If
        Return newtext
    End Function
    '
    ' Get next text string marked by any accepted delimiters and return delimiter type
    '
    Private Function GetSubtext(ByVal pText As String, ByRef pType As ReplaceType) As String
        Dim subText As String = String.Empty
        Dim _index1 As Integer = pText.IndexOf(SUB_START_MARKER)
        Dim _index2 As Integer = pText.IndexOf(SPLIT_START_MARKER)
        Dim isSubstring As Boolean = _index1 >= 0
        Dim isSplit As Boolean = _index2 >= 0
        pType = ReplaceType.None
        If isSubstring And isSplit Then
            If _index1 < _index2 Then
                pType = ReplaceType.Substring
            Else
                pType = ReplaceType.Split
            End If
        ElseIf isSubstring Then
            pType = ReplaceType.Substring
        ElseIf isSplit Then
            pType = ReplaceType.Split
        End If
        If pType = ReplaceType.Substring Then
            subText = GetValueBetweenBrackets(pText, SUB_START_MARKER, SUB_END_MARKER)
        End If
        If pType = ReplaceType.Split Then
            subText = GetValueBetweenBrackets(pText, SPLIT_START_MARKER, SPLIT_END_MARKER)
        End If
        Return subText
    End Function
    Private Function GetSubstring(ByVal newText As String, subtext As String) As String
        Try
            Dim subparts As String() = Split(subtext, SUB_MID_MARKER)
            Dim subValue As String = subparts(0)
            If subparts.Length > 1 Then
                Dim subInts As String() = Split(subparts(1), ",")
                Dim _start As Integer = If(IsNumeric(subInts(0)), Math.Abs(CInt(subInts(0))), 0)
                Dim _length As Integer = If(subInts.Length > 1 AndAlso IsNumeric(subInts(1)), Math.Abs(CInt(subInts(1))), 0)
                If subInts.Length > 2 Then
                    Dim rPad As String = subInts(2)
                    subValue = subValue.PadRight(_start + _length, rPad)
                End If
                If _start > -1 AndAlso _start + _length <= subValue.Length Then
                    If subInts.Length = 2 And _length > 0 Then
                        subValue = subValue.Substring(_start, _length)
                    Else
                        subValue = subValue.Substring(_start)
                    End If
                End If
                newText = newText.Replace(SUB_START_MARKER & subtext & SUB_END_MARKER, subValue)
            Else
                newText = newText.Replace(SUB_START_MARKER, "!!").Replace(SUB_END_MARKER, "!!")
            End If
        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("Substring Exception", ex, "ApplySubstrings")
        End Try
        Return newText
    End Function
    Private Function GetWord(ByVal newText As String, subtext As String) As String
        Try
            Dim subparts As String() = Split(subtext, SPLIT_MID_MARKER)
            Dim subValue As String
            If subparts.Length = 2 Then
                Dim subInts As String() = Split(subparts(1), ",")
                If subInts.Length = 3 Then
                    subValue = Split(subparts(0), subInts(1), subInts(2))(subInts(0))
                Else
                    subValue = ""
                End If
                newText = newText.Replace(SPLIT_START_MARKER & subtext & SPLIT_END_MARKER, subValue)
            Else
                newText = newText.Replace(SUB_START_MARKER, "!!").Replace(SUB_END_MARKER, "!!")
            End If
        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("Substring Exception", ex, "ApplySubstrings")
        End Try
        Return newText
    End Function
#End Region
End Module
