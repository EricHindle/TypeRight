Imports NbuttonControlLibrary
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ButtonUtil
#Region "constants"
    Public Const FRAME_WIDTH As Integer = 18
    Public Const SUB_START_MARKER As String = "$="
    Public Const SUB_MID_MARKER As String = "$$"
    Public Const SUB_END_MARKER As String = "=$"
    Public Const FIELD_START_MARKER As String = "?="
    Public Const FIELD_END_MARKER As String = "=?"
#End Region
#Region "variables"
    Public Shared tooltipcommon As New Windows.Forms.ToolTip
    Private Shared strButtonHint As String
    Private Shared oButtonList As List(Of Nbutton)
    Private Shared oCurrentSender As New Sender
#End Region
#Region "subroutines"
    Private Shared Sub AddButtonToList(btnSeq As Integer, oButton As SenderButton, btnCaption As String, btnValue As String, btnHint As String)
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
    Public Shared Sub RemovePanelButtons(ByRef ButtonPanel As Panel)
        ButtonPanel.Controls.Clear()
    End Sub
#End Region
#Region "functions"
    Public Shared Function LoadSenderButtons(sndKey As Integer, oSenderRow As TypeRightDataSet.sendersRow) As List(Of Nbutton)

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
                If senderButton IsNot Nothing AndAlso CBool(senderButton.IsEncrypted) Then
                    strButtonValue = oNCrypter.DecryptData(strButtonValue)
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
    Public Shared Function LoadGroupButtons(grpNo As Long) As List(Of Nbutton)
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
    Public Shared Function FillButtonPanel(ByRef oPanel As Panel, ByRef oList As List(Of Nbutton), Optional rowOffset As Integer = 0, ByRef Optional buttonMenu As ContextMenuStrip = Nothing) As Integer
        iButtonCt = oList.Count
        Dim iRowCt As Integer = CInt(iButtonCt / iColCt)
        ' Any left over ? Then add a row
        Dim iMod As Integer = (iButtonCt) Mod iColCt
        If iMod > 0 Then
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
            oBtn.Name = oPanel.Name & CStr(actualRow) & CStr(iBtnCol)
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
        Return age
    End Function
    Public Shared Function GetDBFields(ByVal sKeyText As String, oSenderRow As TypeRightDataSet.sendersRow) As String
        Dim fieldName As String
        Dim fieldValue As String
        Dim newText As String = sKeyText
        fieldName = GetValueBetweenBrackets(newText, FIELD_START_MARKER, FIELD_END_MARKER)
        Dim _senderButton As SenderButton
        Do Until String.IsNullOrEmpty(fieldName)
            _senderButton = GetSenderButton(fieldName)
            fieldValue = If(IsDBNull(oSenderRow(fieldName)), "", CStr(oSenderRow(fieldName)))
            If _senderButton IsNot Nothing AndAlso CBool(_senderButton.IsEncrypted) Then
                fieldValue = oNCrypter.DecryptData(fieldValue)
            End If
            newText = newText.Replace(FIELD_START_MARKER & fieldName & FIELD_END_MARKER, fieldValue)
            fieldName = GetValueBetweenBrackets(newText, FIELD_START_MARKER, FIELD_END_MARKER)
        Loop
        Return newText
    End Function
    Public Shared Function ApplySubstrings(ByVal sKeyText As String) As String
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
            LogUtil.Exception("Substring Exception", ex, "ApplySubstrings")
        End Try

        Return newText
    End Function
#End Region

End Class
