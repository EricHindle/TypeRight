' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Module DatabaseFunctions

#Region "dB"
    Private ReadOnly oBgTa As New TypeRightDataSetTableAdapters.buttongroupsTableAdapter
    Private oBgTable As New TypeRightDataSet.buttongroupsDataTable
    Private ReadOnly oBtnTa As New TypeRightDataSetTableAdapters.buttonTableAdapter
    Private oBtnTable As New TypeRightDataSet.buttonDataTable
    Private ReadOnly oSndTa As New TypeRightDataSetTableAdapters.sendersTableAdapter
    Private oSndTable As New TypeRightDataSet.sendersDataTable
    Private ReadOnly oSndBtnTa As New TypeRightDataSetTableAdapters.senderButtonTableAdapter
    Private oSndBtnTable As New TypeRightDataSet.senderButtonDataTable
    Private ReadOnly oSmtpTa As New TypeRightDataSetTableAdapters.smtpTableAdapter
    Private oSmtpTable As New TypeRightDataSet.smtpDataTable
    Private ReadOnly oSettingsTa As New TypeRightDataSetTableAdapters.SettingsTableAdapter
    Private oSettingsTable As New TypeRightDataSet.SettingsDataTable
#End Region
#Region "backup"
    Private ReadOnly tableList As New List(Of String)
    Public Sub InitialiseData()
        LogUtil.Info("Initialising data", MethodBase.GetCurrentMethod.Name)
        tableList.Add("Buttons")
        tableList.Add("ButtonGroups")
        tableList.Add("Senders")
        tableList.Add("SenderButtons")
        tableList.Add("Smtp")
        tableList.Add("Settings")
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
                        oBtnTa.TruncateButton()
                        oBtnTa.Update(oBtnTable)
                        rowCount = oBtnTa.GetData().Rows.Count
                    End If
                Case "ButtonGroups"
                    If RecreateTable(oBgTable, datapath) Then
                        oBgTa.TruncateButtonGroups()
                        oBgTa.Update(oBgTable)
                        rowCount = oBgTa.GetData().Rows.Count
                    End If
                Case "Senders"
                    If RecreateTable(oSndTable, datapath) Then
                        oSndTa.TruncateSenders()
                        oSndTa.Update(oSndTable)
                        rowCount = oSndTa.GetData().Rows.Count
                    End If
                Case "SenderButtons"
                    If RecreateTable(oSndBtnTable, datapath) Then
                        oSndBtnTa.TruncateSenderButton()
                        oSndBtnTa.Update(oSndBtnTable)
                        rowCount = oSndBtnTa.GetData().Rows.Count
                    End If
                Case "Smtp"
                    If RecreateTable(oSmtpTable, datapath) Then
                        oSmtpTa.TruncateSmtp()
                        oSmtpTa.Update(oSmtpTable)
                        rowCount = oSmtpTa.GetData().Rows.Count
                    End If
            End Select
        Catch ex As DbException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Db")
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
                DisplayException(MethodBase.GetCurrentMethod, ex, "Db")
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
        LogUtil.Info("Starting SQL Server", MethodBase.GetCurrentMethod.Name)
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
        LogUtil.Info("Getting Button table", MethodBase.GetCurrentMethod.Name)
        Return oBtnTa.GetData()
    End Function
    Public Function GetButtonByGroupAndSeq(_buttonGrpId As Integer, _buttonSeq As Integer) As TypeRightDataSet.buttonRow
        LogUtil.Info("Getting Button row for Grp " & _buttonGrpId & " Seq " & _buttonSeq, MethodBase.GetCurrentMethod.Name)
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillByGroupSeq(oBtnTable, _buttonGrpId, _buttonSeq)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function GetButtonsByGroup(_buttonGrpId As Integer) As TypeRightDataSet.buttonDataTable
        LogUtil.Info("Getting Button table for Grp " & _buttonGrpId, MethodBase.GetCurrentMethod.Name)
        oBtnTa.FillByGroup(oBtnTable, _buttonGrpId)
        Return oBtnTable
    End Function
    Public Function GetButtonById(_buttonId As Integer) As TypeRightDataSet.buttonRow
        LogUtil.Info("Getting button row " & _buttonId, MethodBase.GetCurrentMethod.Name)
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillById(oBtnTable, _buttonId)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function UpdateButtonGroupOnButton(_buttonGrpId As Integer, _buttonId As Integer) As Boolean
        LogUtil.Info("Updating Grp " & _buttonGrpId, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBtnTa.UpdateGroup(_buttonGrpId, _buttonId) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function InsertButton(_button As NbuttonControlLibrary.Nbutton) As Boolean
        LogUtil.Info("Inserting Button for Grp " & _button.Group & " Seq " & _button.Sequence, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBtnTa.InsertButton(_button.Group,
                                       _button.Sequence,
                                       _button.Caption,
                                       _button.Hint,
                                       _button.Value,
                                       _button.FontName,
                                       _button.FontBold,
                                       _button.FontSize,
                                       _button.FontItalic,
                                       _button.Encrypt) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function UpdateButton(_button As NbuttonControlLibrary.Nbutton) As Boolean
        LogUtil.Info("Updating Button " & _button.Id, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBtnTa.UpdateButton(_button.Group,
                                       _button.Sequence,
                                       _button.Caption,
                                       _button.Hint,
                                       _button.Value,
                                       _button.FontName,
                                       _button.FontBold,
                                       _button.FontSize,
                                       _button.FontItalic,
                                       _button.Encrypt,
                                       _button.Id) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function InsertButton(_buttonGrp As Integer,
                                 _buttonSeq As Integer,
                                 _buttontext As String,
                                 _buttonHint As String,
                                 _buttonValue As String,
                                 _buttonFont As String,
                                 _buttonBold As Boolean,
                                 _buttonFontSize As Integer,
                                 _buttonItalic As Boolean,
                                 _buttonEncrypt As Boolean) As Boolean
        LogUtil.Info("Inserting Button row for Grp " & _buttonGrp & " Seq " & _buttonSeq, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBtnTa.InsertButton(_buttonGrp,
                                       _buttonSeq,
                                       _buttontext,
                                       _buttonHint,
                                       _buttonValue,
                                       _buttonFont,
                                       _buttonBold,
                                       _buttonFontSize,
                                       _buttonItalic,
                                       _buttonEncrypt) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function UpdateButton(_buttonGrp As Integer,
                                 _buttonSeq As Integer,
                                 _buttontext As String,
                                 _buttonHint As String,
                                 _buttonValue As String,
                                 _buttonFont As String,
                                 _buttonBold As Boolean,
                                 _buttonFontSize As Integer,
                                 _buttonItalic As Boolean,
                                 _buttonEncrypt As Boolean,
                                 _buttonId As Integer) As Boolean
        LogUtil.Info("Updating Button " & _buttonId, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBtnTa.UpdateButton(_buttonGrp,
                                       _buttonSeq,
                                       _buttontext,
                                       _buttonHint,
                                       _buttonValue,
                                       _buttonFont,
                                       _buttonBold,
                                       _buttonFontSize,
                                       _buttonItalic,
                                       _buttonEncrypt,
                                       _buttonId) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function UpdateButtonSeq(_seq As Integer, _id As Integer) As Boolean
        Dim isOk As Boolean = False
        Try
            isOk = oBtnTa.UpdateSeq(_seq, _id) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function DeleteButton(_Id As Integer) As Boolean
        LogUtil.Info("Deleting Button " & _Id, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBtnTa.DeleteButton(_Id) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Sub ResequenceButtons(_grp As Integer)
        LogUtil.Info("Resequencing buttons", MethodBase.GetCurrentMethod.Name)
        oBtnTable = GetButtonsByGroup(_grp)
        Dim iSeq As Integer = 1
        For Each oRow As TypeRightDataSet.buttonRow In oBtnTable.Rows
            UpdateButtonSeq(iSeq, oRow.buttonId)
            iSeq += 1
        Next
    End Sub
#End Region
#Region "groups"
    Public Function GetButtonGroupById(_id As Integer) As ButtonGroup
        LogUtil.Info("Getting Button Group " & _id, MethodBase.GetCurrentMethod.Name)
        Dim oButtonGroup As New ButtonGroup
        Try
            oBgTa.FillById(oBgTable, _id)
            If oBgTable.Rows.Count > 0 Then
                oButtonGroup = ButtonGroupBuilder.aButtonGroup.StartingWith(oBgTable.Rows(0)).Build
            Else
                LogUtil.Info("ButtonGroup not found ", MethodBase.GetCurrentMethod.Name)
            End If
        Catch ex As Exception
            LogUtil.Exception("ButtonGroup not found: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oButtonGroup
    End Function
    Public Function GetButtonGroupTable() As TypeRightDataSet.buttongroupsDataTable
        LogUtil.Info("Getting Button Group table", MethodBase.GetCurrentMethod.Name)

        oBgTable = New TypeRightDataSet.buttongroupsDataTable
        Try
            oBgTable = oBgTa.GetData()
        Catch ex As Exception
            LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oBgTable
    End Function
    Public Function DeleteButtonGroup(_buttonGrpId As Integer) As Boolean
        LogUtil.Info("Deleting Button Group " & _buttonGrpId, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBgTa.DeleteButtonGroup(_buttonGrpId) = 1
        Catch ex As DbException
            LogUtil.Exception("Delete failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function InsertButtonGroup(_groupname As String) As Boolean
        LogUtil.Info("Inserting Button Group " & _groupname, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBgTa.InsertButtonGroup(_groupname) = 1
        Catch ex As DbException
            LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function UpdateButtonGroupName(_groupname As String, _groupId As Integer) As Boolean
        LogUtil.Info("Updating Button Group " & _groupId, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oBgTa.UpdateGroupName(_groupname, _groupId) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
#End Region
#Region "senders"
    Public Function GetSenderTable() As TypeRightDataSet.sendersDataTable
        LogUtil.Info("Getting Sender table", MethodBase.GetCurrentMethod.Name)
        oSndTable = New TypeRightDataSet.sendersDataTable
        Try
            oSndTable = oSndTa.GetData()
        Catch ex As Exception
            LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oSndTable
    End Function
    Public Function GetSenderRowById(_id As Integer) As TypeRightDataSet.sendersRow

        Dim oSenderRow As TypeRightDataSet.sendersRow = Nothing
        Try
            oSndTa.FillById(oSndTable, _id)
            If oSndTable.Rows.Count > 0 Then
                Dim oSendertable As New TypeRightDataSet.sendersDataTable
                oSendertable.ImportRow(oSndTable.Rows(0))
                oSenderRow = oSendertable.Rows(0)
            Else
                LogUtil.Info("Sender row not found ", MethodBase.GetCurrentMethod.Name)
            End If
        Catch ex As Exception
            LogUtil.Exception("Sender not found: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oSenderRow
    End Function
    Public Function GetSenderById(_id As Integer) As Sender
        LogUtil.Info("Getting Sender " & _id, MethodBase.GetCurrentMethod.Name)
        Dim oSender As New Sender
        Try
            oSndTa.FillById(oSndTable, _id)
            If oSndTable.Rows.Count > 0 Then
                oSender = SenderBuilder.aSender.StartingWith(oSndTable.Rows(0)).Build
            Else
                LogUtil.Info("Sender not found ", MethodBase.GetCurrentMethod.Name)
            End If
        Catch ex As Exception
            LogUtil.Exception("Sender not found: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oSender
    End Function
    Public Function InsertSender(ByRef oSender As Sender) As Boolean
        LogUtil.Info("Inserting Sender " & oSender.FirstName & " " & oSender.LastName, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oSndTa.InsertSender(oSender.Title,
                                       oSender.FirstName,
                                       oSender.LastName,
                                       oSender.Address1,
                                       oSender.Address2,
                                       oSender.Town,
                                       oSender.County,
                                       oSender.Country,
                                       oSender.PostCode,
                                       Format(oSender.DateOfBirth, "yyyy-MM-dd"),
                                       oSender.Email,
                                       oSender.Phone,
                                       oSender.Mobile,
                                       oSender.Password,
                                       oSender.SecretWord,
                                       oSender.Gender,
                                       oSender.Occupation,
                                       oSender.MaritalStatus,
                                       oSender.Username) = 1
        Catch ex As DbException
            LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function UpdateSender(ByRef oSender As Sender) As Boolean
        LogUtil.Info("Updating Sender " & oSender.SenderId, MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            isOk = oSndTa.UpdateSender(oSender.Title,
                                       oSender.FirstName,
                                       oSender.LastName,
                                       oSender.Address1,
                                       oSender.Address2,
                                       oSender.Town,
                                       oSender.County,
                                       oSender.Country,
                                       oSender.PostCode,
                                       Format(oSender.DateOfBirth, "yyyy-MM-dd"),
                                       oSender.Email,
                                       oSender.Phone,
                                       oSender.Mobile,
                                       oSender.Password,
                                       oSender.SecretWord,
                                       oSender.Gender,
                                       oSender.Occupation,
                                       oSender.MaritalStatus,
                                       oSender.Username,
                                       oSender.SenderId) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function DeleteSender(_id As Integer) As Boolean
        LogUtil.Info("Deleting Sender " & _id, MethodBase.GetCurrentMethod.Name)
        Dim isOK As Boolean = False
        Try
            isOK = oSndTa.DeleteSender(_id) = 1
        Catch ex As DbException
            LogUtil.Exception("Delete failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOK
    End Function
#End Region
#Region "senderbuttons"
    Public Function GetSenderButtonTable() As TypeRightDataSet.senderButtonDataTable
        LogUtil.Info("Getting Sender Button table", MethodBase.GetCurrentMethod.Name)
        oSndBtnTable = New TypeRightDataSet.senderButtonDataTable
        Try
            oSndBtnTable = oSndBtnTa.GetData()
        Catch ex As Exception
            LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oSndBtnTable
    End Function
    Public Function GetSenderButton(columnName As String) As SenderButton
        '      LogUtil.Info("Getting Sender Button row for " & columnName, MethodBase.GetCurrentMethod.Name)
        Dim oSenderButton As New SenderButton
        Try
            oSndBtnTa.FillByColName(oSndBtnTable, columnName)
            If oSndBtnTable.Rows.Count = 1 Then
                oSenderButton = SenderButtonBuilder.aSenderButton.StartingWith(oSndBtnTable.Rows(0)).Build
            End If
        Catch ex As DbException
            LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oSenderButton
    End Function
    Public Function DeleteSenderButton(columnName As String) As Boolean
        LogUtil.Info("Deleting Sender Button for " & columnName, MethodBase.GetCurrentMethod.Name)
        Dim isOK As Boolean = False
        Try
            isOK = oSndBtnTa.DeleteSenderButton(columnName) = 1
        Catch ex As DbException
            LogUtil.Exception("Delete failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOK
    End Function
    Public Function InsertSenderButton(pSenderButton As SenderButton) As Boolean
        LogUtil.Info("Insering sender button row for " & pSenderButton.ColumnName, MethodBase.GetCurrentMethod.Name)
        Dim isOK As Boolean = False
        Try
            isOK = oSndBtnTa.InsertSenderButton(pSenderButton.ColumnName, pSenderButton.Bold,
                                            pSenderButton.Italic, pSenderButton.FontName,
                                           pSenderButton.FontSize, pSenderButton.IsEncrypted) = 1
        Catch ex As DbException
            LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOK
    End Function
    Public Function UpdateSenderButton(pSenderButton As SenderButton) As Boolean
        LogUtil.Info("Updating sender button row for " & pSenderButton.ColumnName, MethodBase.GetCurrentMethod.Name)
        Dim isOK As Boolean = False
        Try
            isOK = oSndBtnTa.UpdateSenderButton(pSenderButton.Bold, pSenderButton.Italic,
                                            pSenderButton.FontName, pSenderButton.FontSize,
                                            pSenderButton.IsEncrypted, pSenderButton.ColumnName) = 1
        Catch ex As DbException
            LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOK
    End Function
#End Region
#Region "smtp"
    Public Function GetSmtpTable() As TypeRightDataSet.smtpDataTable
        LogUtil.Info("Getting SMTP table", MethodBase.GetCurrentMethod.Name)
        oSmtpTable = New TypeRightDataSet.smtpDataTable
        Try
            oSmtpTable = oSmtpTa.GetData
        Catch ex As Exception
            LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oSmtpTable
    End Function
    Public Function GetSmtpList() As List(Of Smtp)
        LogUtil.Info("Getting SMTP list", MethodBase.GetCurrentMethod.Name)
        Dim _smtpList As New List(Of Smtp)
        Try
            oSmtpTa.Fill(oSmtpTable)
            For Each _row As TypeRightDataSet.smtpRow In oSmtpTable.Rows
                _smtpList.Add(SmtpBuilder.aSmtp.StartingWith(_row).Build)
            Next
        Catch ex As DbException
            LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _smtpList
    End Function
    Public Function GetSmtpById(pId As Integer) As Smtp
        LogUtil.Info("Getting SMTP by Id", MethodBase.GetCurrentMethod.Name)
        Dim _smtp As New Smtp
        Try
            oSmtpTa.FillById(oSmtpTable, pId)
            If oSmtpTable.Rows.Count > 0 Then
                _smtp = SmtpBuilder.aSmtp.StartingWith(oSmtpTable.Rows(0)).Build
            End If
        Catch ex As DbException
            LogUtil.Exception("SMTP not found: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return _smtp
    End Function
    Public Function InsertSmtp(pSmtp As Smtp) As Boolean
        LogUtil.Info("Inserting SMTP Account", MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            Dim _isSsl As Integer = If(pSmtp.IsEnableSsl, 1, 0)
            Dim _isCred As Integer = If(pSmtp.IsCredentialsRequired, 1, 0)
            isOk = oSmtpTa.InsertSmtp(pSmtp.Username, pSmtp.Password, pSmtp.Host, pSmtp.Port, _isSsl, _isCred)
        Catch ex As DbException
            LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function UpdateSmtp(pSmtp As Smtp) As Boolean
        LogUtil.Info("Updating SMTP", MethodBase.GetCurrentMethod.Name)
        Dim isOk As Boolean = False
        Try
            Dim _isSsl As Integer = If(pSmtp.IsEnableSsl, 1, 0)
            Dim _isCred As Integer = If(pSmtp.IsCredentialsRequired, 1, 0)
            isOk = oSmtpTa.UpdateSmtp(pSmtp.Username, pSmtp.Password, pSmtp.Host, pSmtp.Port, _isSsl, _isCred, pSmtp.SmtpId) = 1
        Catch ex As DbException
            LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOk
    End Function
    Public Function DeleteSmtp(_id As Integer) As Boolean
        LogUtil.Info("Deleting SMTP " & _id, MethodBase.GetCurrentMethod.Name)
        Dim isOK As Boolean = False
        Try
            isOK = oSmtpTa.DeleteSmtp(_id) = 1
        Catch ex As DbException
            LogUtil.Exception("Delete failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return isOK
    End Function
#End Region
#Region "settings"
    Public Function GetSettingsTable() As TypeRightDataSet.SettingsDataTable
        LogUtil.Info("Getting Settings table", MethodBase.GetCurrentMethod.Name)
        oSettingsTable = New TypeRightDataSet.SettingsDataTable
        Try
            oSettingsTable = oSettingsTa.GetData
        Catch ex As Exception
            LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
        End Try
        Return oSettingsTable
    End Function
#End Region
End Module
