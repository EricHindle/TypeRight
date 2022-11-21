﻿Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Module DatabaseFunctions

#Region "constants"
    Private Const MODULE_NAME As String = "Db"
#End Region

#Region "dB"
    Private ReadOnly oBgTa As New TypeRightDataSetTableAdapters.buttongroupsTableAdapter
    Private ReadOnly oBgTable As New TypeRightDataSet.buttongroupsDataTable
    Private ReadOnly oBtnTa As New TypeRightDataSetTableAdapters.buttonTableAdapter
    Private oBtnTable As New TypeRightDataSet.buttonDataTable
    Private ReadOnly oSndTa As New TypeRightDataSetTableAdapters.sendersTableAdapter
    Private ReadOnly oSndTable As New TypeRightDataSet.sendersDataTable
    Private ReadOnly oSndBtnTa As New TypeRightDataSetTableAdapters.senderButtonTableAdapter
    Private ReadOnly oSndBtnTable As New TypeRightDataSet.senderButtonDataTable
    Private ReadOnly oSmtpTa As New TypeRightDataSetTableAdapters.smtpTableAdapter
    Private ReadOnly oSmtpTable As New TypeRightDataSet.smtpDataTable
#End Region
#Region "backup"
    Private tableList As New List(Of String)
    Public Sub InitialiseData()
        LogUtil.Info("Initialising data", MODULE_NAME)
        tableList.Add("Buttons")
        tableList.Add("ButtonGroups")
        tableList.Add("Senders")
        tableList.Add("SenderButtons")
        tableList.Add("Smtp")

    End Sub
    Public Sub FillTableTree(ByRef tvtables As TreeView)
        tvtables.Nodes.Clear()
        tvtables.Nodes.Add("Tables")
        For Each oTable As String In tableList
            tvtables.Nodes(0).Nodes.Add(oTable)
        Next
    End Sub
    Public Function RestoreDataTable(tableType As String, datapath As String) As Integer
        Dim rowCount As Integer = 0
        Try
            Select Case tableType
                Case "Buttons"
                    If RecreateTable(oBtnTable, datapath) Then
                        '   oBtnTa.TruncatePeople()
                        oBtnTa.Update(oBtnTable)
                        rowCount = oBtnTa.GetData().Rows.Count
                    End If
                Case "ButtonGroups"
                    If RecreateTable(oBgTable, datapath) Then
                        '   oBgTa.TruncatePeople()
                        oBgTa.Update(oBgTable)
                        rowCount = oBgTa.GetData().Rows.Count
                    End If
                Case "Senders"
                    If RecreateTable(oSndTable, datapath) Then
                        '   osndTa.TruncatePeople()
                        oSndTa.Update(oSndTable)
                        rowCount = oSndTa.GetData().Rows.Count
                    End If
                Case "SenderButtons"
                    If RecreateTable(oSndBtnTable, datapath) Then
                        '   osndBtnTa.TruncatePeople()
                        oSndBtnTa.Update(oSndBtnTable)
                        rowCount = oSndBtnTa.GetData().Rows.Count
                    End If
                Case "Smtp"
                    If RecreateTable(oSmtpTable, datapath) Then
                        '   osmtpTa.TruncatePeople()
                        oSmtpTa.Update(oSmtpTable)
                        rowCount = oSmtpTa.GetData().Rows.Count
                    End If
            End Select
        Catch ex As Exception

        End Try
        Return rowCount
    End Function
    Private Function RecreateTable(ByRef restoredDataTable As DataTable, datapath As String) As Boolean
        Dim isTableOK As Boolean = False
        Dim sTableName As String = restoredDataTable.TableName
        Dim sBackupFile As String = Path.Combine(datapath, sTableName & ".xml")
        If My.Computer.FileSystem.FileExists(sBackupFile) Then
            Try
                restoredDataTable.Clear()
                restoredDataTable.ReadXml(sBackupFile)
                Dim rowCount As Integer = restoredDataTable.Rows.Count
                If MsgBox(CStr(rowCount) & " records recovered. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Continue") = MsgBoxResult.Yes Then
                    isTableOK = True
                End If
            Catch ex As Exception

            End Try
        End If
        Return isTableOK
    End Function
#End Region
#Region "buttons"
    Public Function TestDatabase() As Boolean
        Dim isOK As Boolean = True
        Try
            oBtnTa.GetData()
        Catch ex As DbException
            StartSqlService()
            Try
                oBtnTa.GetData()
            Catch ex1 As DbException
                isOK = False
            End Try
        End Try
        Return isOK
    End Function
    Private Sub StartSqlService()
        LogUtil.Info("Starting SQL Server", MODULE_NAME)
        Try
            Dim procStartInfo As New ProcessStartInfo
            With procStartInfo
                .UseShellExecute = True
                .FileName = "net.exe"
                .Arguments = " start ""SQL Server (SQLEXPRESS)"""
                .WindowStyle = ProcessWindowStyle.Normal
                .Verb = "runas"
            End With
            Dim thisProcess As Process = Process.Start(procStartInfo)
            thisProcess.WaitForExit(120000)
        Catch ex As System.ComponentModel.Win32Exception
            DisplayException(MethodBase.GetCurrentMethod, ex, "Win32")
        End Try
    End Sub
    Public Function GetButtonTable()
        LogUtil.Info("Getting button table", MODULE_NAME)
        Return oBtnTa.GetData()
    End Function
    Public Function GetButtonByGroupAndSeq(_buttonGrpId As Integer, _buttonSeq As Integer) As TypeRightDataSet.buttonRow
        LogUtil.Info("Getting button row for Grp " & CStr(_buttonGrpId) & " Seq " & CStr(_buttonSeq), MODULE_NAME)
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillByGroupSeq(oBtnTable, _buttonGrpId, _buttonSeq)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function GetButtonsByGroup(_buttonGrpId As Integer) As TypeRightDataSet.buttonDataTable
        LogUtil.Info("Getting button table for Grp " & CStr(_buttonGrpId), MODULE_NAME)
        oBtnTa.FillByGroup(oBtnTable, _buttonGrpId)
        Return oBtnTable
    End Function
    Public Function GetButtonById(_buttonId As Integer) As TypeRightDataSet.buttonRow
        LogUtil.Info("Getting button row " & CStr(_buttonId), MODULE_NAME)
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillById(oBtnTable, _buttonId)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function UpdateButtonGroupOnButton(_buttonGrpId As Integer, _buttonId As Integer) As Integer
        LogUtil.Info("Updating Grp " & CStr(_buttonGrpId), MODULE_NAME)
        Return oBtnTa.UpdateGroup(_buttonGrpId, _buttonId)
    End Function
    Public Function InsertButton(_button As NbuttonControlLibrary.Nbutton) As Integer
        LogUtil.Info("Inserting button for Grp " & CStr(_button.Group) & " Seq " & CStr(_button.Sequence), MODULE_NAME)
        Return oBtnTa.InsertButton(_button.Group, _button.Sequence,
                                   _button.Caption, _button.Hint,
                                   _button.Value, _button.FontName,
                                   _button.FontBold, _button.FontSize,
                                   _button.FontItalic, _button.Encrypt)
    End Function
    Public Function UpdateButton(_button As NbuttonControlLibrary.Nbutton) As Integer
        LogUtil.Info("Updating button " & CStr(_button.Id), MODULE_NAME)
        Return oBtnTa.UpdateButton(_button.Group, _button.Sequence,
                                   _button.Caption, _button.Hint,
                                   _button.Value, _button.FontName,
                                   _button.FontBold, _button.FontSize,
                                   _button.FontItalic, _button.Encrypt, _button.Id)
    End Function
    Public Function InsertButton(_buttonGrp As Integer, _buttonSeq As Integer, _buttontext As String, _buttonHint As String, _buttonValue As String, _buttonFont As String, _buttonBold As Boolean, _buttonFontSize As Integer, _buttonItalic As Boolean, _buttonEncrypt As Boolean) As Integer
        LogUtil.Info("Inserting button row for Grp " & CStr(_buttonGrp) & " Seq " & CStr(_buttonSeq), MODULE_NAME)
        Return oBtnTa.InsertButton(_buttonGrp, _buttonSeq,
                                   _buttontext, _buttonHint,
                                   _buttonValue, _buttonFont,
                                   _buttonBold, _buttonFontSize,
                                   _buttonItalic, _buttonEncrypt)
    End Function
    Public Function UpdateButton(_buttonGrp As Integer, _buttonSeq As Integer, _buttontext As String, _buttonHint As String, _buttonValue As String, _buttonFont As String, _buttonBold As Boolean, _buttonFontSize As Integer, _buttonItalic As Boolean, _buttonEncrypt As Boolean, _buttonId As Integer) As Integer
        LogUtil.Info("Updating button " & CStr(_buttonId), MODULE_NAME)
        Return oBtnTa.UpdateButton(_buttonGrp, _buttonSeq,
                                   _buttontext, _buttonHint,
                                   _buttonValue, _buttonFont,
                                   CByte(_buttonBold), _buttonFontSize,
                                   CByte(_buttonItalic), _buttonEncrypt, _buttonId)
    End Function
    Public Function UpdateButtonSeq(_seq As Integer, _id As Integer) As Integer
        Return oBtnTa.UpdateSeq(_seq, _id)
    End Function
    Public Function DeleteButton(_Id As Integer) As Integer
        LogUtil.Info("Deleting button " & CStr(_Id), MODULE_NAME)
        Return oBtnTa.DeleteButton(_Id)
    End Function
    Public Sub ResequenceButtons(_grp As Integer)
        LogUtil.Info("Resequencing buttons", MODULE_NAME)
        oBtnTable = GetButtonsByGroup(_grp)
        Dim iSeq As Integer = 1
        For Each oRow As TypeRightDataSet.buttonRow In oBtnTable.Rows
            UpdateButtonSeq(iSeq, oRow.buttonId)
            iSeq += 1
        Next
    End Sub
#End Region
#Region "groups"
    Public Function GetButtonGroup(_buttonGrpId As Integer) As TypeRightDataSet.buttongroupsRow
        LogUtil.Info("Getting group " & CStr(_buttonGrpId), MODULE_NAME)
        Dim oBgRow As TypeRightDataSet.buttongroupsRow = Nothing
        oBgTa.FillById(oBgTable, _buttonGrpId)
        If oBgTable.Rows.Count = 1 Then
            oBgRow = oBgTable.Rows(0)
        End If
        Return oBgRow
    End Function
    Public Function GetButtonGroupTable() As TypeRightDataSet.buttongroupsDataTable
        LogUtil.Info("Getting group table", MODULE_NAME)
        Return oBgTa.GetData
    End Function
    Public Function DeleteButtonGroup(_buttonGrpId As Integer) As Integer
        LogUtil.Info("Deleting group " & CStr(_buttonGrpId), MODULE_NAME)
        Return oBgTa.DeleteButtonGroup(_buttonGrpId)
    End Function
    Public Function InsertButtonGroup(_groupname As String) As Integer
        LogUtil.Info("Inserting group " & _groupname, MODULE_NAME)
        Return oBgTa.InsertButtonGroup(_groupname)
    End Function
    Public Function UpdateButtonGroupName(_groupname As String, _groupId As Integer) As Integer
        LogUtil.Info("Updating group " & CStr(_groupId), MODULE_NAME)
        Return oBgTa.UpdateGroupName(_groupname, _groupId)
    End Function
#End Region
#Region "senders"
    Public Function GetSenderTable() As TypeRightDataSet.sendersDataTable
        LogUtil.Info("Getting sender table", MODULE_NAME)
        Return oSndTa.GetData()
    End Function
    Public Function GetSenderRowById(_id As Integer) As TypeRightDataSet.sendersRow
        LogUtil.Info("Getting sender row " & CStr(_id), MODULE_NAME)
        oSndTa.FillById(oSndTable, _id)
        Dim oSenderRow As TypeRightDataSet.sendersRow = Nothing
        If oSndTable.Rows.Count > 0 Then
            Dim oSendertable As New TypeRightDataSet.sendersDataTable
            oSendertable.ImportRow(oSndTable.Rows(0))
            oSenderRow = oSendertable.Rows(0)
        Else
            LogUtil.Info("Row not found ", MODULE_NAME)
        End If
        Return oSenderRow
    End Function
    Public Function InsertSender(ByRef oSender As Sender) As Integer
        LogUtil.Info("Inserting sender " & oSender.FirstName & " " & oSender.LastName, MODULE_NAME)
        Return oSndTa.InsertSender(oSender.Title, oSender.FirstName,
                                   oSender.LastName, oSender.Address1,
                                   oSender.Address2, oSender.Town,
                                   oSender.County, oSender.Country,
                                   oSender.PostCode, Format(oSender.DateOfBirth, "yyyy-MM-dd"),
                                   oSender.Email, oSender.Phone,
                                   oSender.Mobile, oSender.Password,
                                   oSender.SecretWord, oSender.Gender,
                                   oSender.Occupation, oSender.MaritalStatus, oSender.Username)
    End Function
    Public Function UpdateSender(ByRef oSender As Sender) As Integer
        LogUtil.Info("Updating sender " & oSender.SenderId, MODULE_NAME)
        Return oSndTa.UpdateSender(oSender.Title, oSender.FirstName,
                                   oSender.LastName, oSender.Address1,
                                   oSender.Address2, oSender.Town,
                                    oSender.County, oSender.Country,
                                    oSender.PostCode, Format(oSender.DateOfBirth, "yyyy-MM-dd"),
                                    oSender.Email, oSender.Phone,
                                    oSender.Mobile, oSender.Password,
                                    oSender.SecretWord, oSender.Gender,
                                    oSender.Occupation, oSender.MaritalStatus,
                                    oSender.Username, oSender.SenderId)

    End Function
    Public Function DeleteSender(_id As Integer) As Integer
        LogUtil.Info("Deleting sender " & _id, MODULE_NAME)
        Return oSndTa.DeleteSender(_id)
    End Function
#End Region
#Region "senderbuttons"
    Public Function GetSenderButtonTable() As TypeRightDataSet.senderButtonDataTable
        LogUtil.Info("Getting sender button table", MODULE_NAME)
        Return oSndBtnTa.GetData()
    End Function
    Public Function GetSenderButton(columnName As String) As TypeRight.TypeRightDataSet.senderButtonRow
        '      LogUtil.Info("Getting sender button row for " & columnName, MODULE_NAME)
        Dim oRow As TypeRight.TypeRightDataSet.senderButtonRow = Nothing
        oSndBtnTa.FillByColName(oSndBtnTable, columnName)
        If oSndBtnTable.Rows.Count = 1 Then
            oRow = oSndBtnTable.Rows(0)
        End If
        Return oRow
    End Function
    Public Function DeleteSenderButton(columnName As String) As Integer
        LogUtil.Info("Deleting sender button for " & columnName, MODULE_NAME)
        Return oSndBtnTa.DeleteSenderButton(columnName)
    End Function
    Public Function InsertSenderButton(ColumnName As String, buttonFontName As String, buttonFontSize As Decimal, buttonItalic As Boolean, buttonBold As Boolean, buttonEncrypted As Boolean) As Integer
        LogUtil.Info("Insering sender button row for " & ColumnName, MODULE_NAME)
        Return oSndBtnTa.InsertSenderButton(ColumnName, CByte(buttonBold),
                                            CByte(buttonItalic), buttonFontName,
                                            buttonFontSize, CByte(buttonEncrypted))
    End Function
    Public Function UpdateSenderButton(ColumnName As String, buttonFontName As String, buttonFontSize As Decimal, buttonItalic As Boolean, buttonBold As Boolean, buttonEncrypted As Boolean) As Integer
        LogUtil.Info("Updating sender button row for " & ColumnName, MODULE_NAME)
        Return oSndBtnTa.UpdateSenderButton(CByte(buttonBold), CByte(buttonItalic),
                                            buttonFontName, buttonFontSize,
                                            CByte(buttonEncrypted), ColumnName)
    End Function
#End Region
#Region "smtp"
    Public Function GetSmtpTable() As TypeRightDataSet.smtpDataTable
        LogUtil.Info("Getting SMTP table", MODULE_NAME)
        Return oSmtpTa.GetData
    End Function
    Public Function GetSmtpList() As List(Of Smtp)
        LogUtil.Info("Getting SMTP list", MODULE_NAME)
        Dim _smtpList As New List(Of Smtp)
        oSmtpTa.Fill(oSmtpTable)
        For Each _row As TypeRightDataSet.smtpRow In oSmtpTable.Rows
            _smtpList.Add(SmtpBuilder.NewSmtp.StartingWith(_row).Build)
        Next
        Return _smtpList
    End Function
    Public Function GetSmtpById(pId As Integer) As Smtp
        LogUtil.Info("Getting SMTP by Id", MODULE_NAME)
        Dim _smtp As New Smtp
        oSmtpTa.FillById(oSmtpTable, pId)
        If oSmtpTable.Rows.Count > 0 Then
            _smtp = SmtpBuilder.NewSmtp.StartingWith(oSmtpTable.Rows(0)).Build
        End If
        Return _smtp
    End Function
    Public Function InsertSmtp(pSmtp As Smtp) As Boolean
        LogUtil.Info("Inserting SMTP", MODULE_NAME)
        Dim isOk As Boolean = False
        Try
            Dim _isSsl As Integer = If(pSmtp.IsEnableSsl, 1, 0)
            Dim _isCred As Integer = If(pSmtp.IsCredentialsRequired, 1, 0)
            isOk = oSmtpTa.InsertSmtp(pSmtp.Username, pSmtp.Password, pSmtp.Host, pSmtp.Port, _isSsl, _isCred)
        Catch ex As DbException
        End Try
        Return isOk
    End Function
    Public Function UpdateSmtp(pSmtp As Smtp) As Boolean
        LogUtil.Info("Updating SMTP", MODULE_NAME)
        Dim isOk As Boolean = False
        Try
            Dim _isSsl As Integer = If(pSmtp.IsEnableSsl, 1, 0)
            Dim _isCred As Integer = If(pSmtp.IsCredentialsRequired, 1, 0)
            isOk = oSmtpTa.UpdateSmtp(pSmtp.Username, pSmtp.Password, pSmtp.Host, pSmtp.Port, _isSsl, _isCred, pSmtp.SmtpId)
        Catch ex As DbException
        End Try
        Return isOk
    End Function
    Public Function DeleteSmtp(_id As Integer) As Integer
        LogUtil.Info("Deleting SMTP " & _id, MODULE_NAME)
        Return oSmtpTa.DeleteSmtp(_id)
    End Function
#End Region

End Module