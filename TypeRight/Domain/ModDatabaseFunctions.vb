' hindleware
' Copyright (c) 2022-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports HindlewareLib.Domain.Objects
Imports HindlewareLib.Logging
Imports NbuttonControlLibrary

Imports TypeRight.TypeRightDataSet1
Namespace Domain
    Module ModDatabaseFunctions
#Region "constants"
        Friend Const TABLE_TAG As String = "T~"
        Public Const DATA_EXT As String = ".htx"
        Public Const BUTTONGROUPS_TABLE As String = "Button Groups Table"
        Public Const BUTTON_TABLE As String = "Button Table"
        Public Const SENDERS_TABLE As String = "Senders Table"
        Public Const SENDERBUTTON_TABLE As String = "Sender Button Table"
        Public Const SMTP_TABLE As String = "Smtp Table"
        Public Const SETTINGS_TABLE As String = "Settings Table"
#End Region
#Region "variables"
        Public oDataFolderName As String
#End Region
#Region "enum"
        Public Enum Tables
            ButtonGroups
            Button
            Senders
            SenderButton
            Smtp
            Settings
        End Enum
#End Region
#Region "dataset"
        Private ReadOnly oButtonGroupsTable As New TypeRightDataSet1.buttongroupsDataTable
        Private ReadOnly oButtonTable As New TypeRightDataSet1.buttonDataTable
        Private ReadOnly oSendersTable As New TypeRightDataSet1.sendersDataTable
        Private ReadOnly oSenderButtonTable As New TypeRightDataSet1.senderButtonDataTable
        Private ReadOnly oSmtpTable As New TypeRightDataSet1.smtpDataTable
        Private ReadOnly oSettingsTable As New TypeRightDataSet1.settingsDataTable
        Public tableList As New List(Of String)
#End Region

#Region "common"
        Public Sub InitialiseData()
            LogUtil.Info("Initialising data", MethodBase.GetCurrentMethod.Name)
            FillTableListFromTableEnum()
            oDataFolderName = My.Settings.DataFilePath
            LogUtil.Info("Data path is " & oDataFolderName, MethodBase.GetCurrentMethod.Name)
            Try
                LoadDataTables()
                If oSendersTable.Rows.Count = 0 Then
                    If MsgBox("No personal details available. Create data record now?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Email Account") = MsgBoxResult.Yes Then
                        OpenDatabaseForm()
                    End If
                End If
            Catch ex As ApplicationException
                LogUtil.DisplayException(ex, "Loading Data", MethodBase.GetCurrentMethod.Name)
            End Try
        End Sub
        Public Sub FillTableTree(ByRef tvtables As TreeView)
            tvtables.Nodes.Clear()
            tvtables.Nodes.Add("Tables")
            For Each oTable As String In tableList
                If Not oTable.Equals("Files") Then
                    tvtables.Nodes(0).Nodes.Add(TABLE_TAG & oTable, oTable)
                End If
            Next
        End Sub
        'Public Function RestoreDataTable(tableType As String, datapath As String) As Integer
        '    Dim rowCount As Integer = 0
        '    Try
        '        LoadDataTableFromXml(tableType, datapath)
        '        Select Case tableType
        '            Case "Settings"
        '                WriteXmlFromTable(oSettingsTable)
        '                rowCount = oSettingsTable.Rows.Count
        '            Case "Tracks"
        '                WriteXmlFromTable(oTracksTable)
        '                rowCount = oTracksTable.Rows.Count
        '            Case "Records"
        '                WriteXmlFromTable(oRecordsTable)
        '                rowCount = oRecordsTable.Rows.Count
        '            Case "RecordFormat"
        '                WriteXmlFromTable(oRecordFormatTable)
        '                rowCount = oRecordFormatTable.Rows.Count
        '            Case "RecordLabels"
        '                WriteXmlFromTable(oRecordLabelsTable)
        '                rowCount = oRecordLabelsTable.Rows.Count
        '            Case "Artists"
        '                WriteXmlFromTable(oArtistsTable)
        '                rowCount = oArtistsTable.Rows.Count
        '            Case "MusicGenres"
        '                WriteXmlFromTable(oMusicGenreTable)
        '                rowCount = oMusicGenreTable.Rows.Count
        '        End Select
        '    Catch ex As Exception
        '        MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
        '    End Try
        '    Return rowCount
        'End Function
        Private Function GetMessage(ex As Exception) As String
            Return If(ex Is Nothing, "", "Exception:  " & ex.Message & vbCrLf & If(ex.InnerException Is Nothing, "", ex.InnerException.Message))
        End Function
#End Region
#Region "Tables"
        Public Sub LoadDataTables()
            LogUtil.LogInfo("Loading Data Tables", MethodBase.GetCurrentMethod.Name)
            Try
                For Each oTable As String In tableList
                    LoadDataTableFromXml(oTable)
                Next
                LogUtil.LogInfo("Data Loaded OK", MethodBase.GetCurrentMethod.Name)
            Catch ex As ApplicationException
                Throw ex
            End Try
        End Sub
        Public Sub FillTableListFromTableEnum()
            tableList.Clear()
            Dim _enumArray As Array = [Enum].GetValues(GetType(Tables))
            For Each _enum In _enumArray
                tableList.Add(_enum.ToString)
            Next
        End Sub
        Public Sub LoadDataTableFromXml(pTable As String)
            Dim oFolder As String = oDataFolderName
            CreateFolder(oDataFolderName, True)
            LoadDataTableFromXml(pTable, oFolder)
        End Sub
        Public Sub LoadDataTableFromXml(otable As String, pFolder As String)
            LogUtil.Debug("Loading table " & otable, MethodBase.GetCurrentMethod.Name)
            Dim oXmlFileName As String
            If My.Computer.FileSystem.DirectoryExists(pFolder) Then
                Select Case otable
                    Case "ButtonGroups"
                        oXmlFileName = Path.Combine(pFolder, oButtonGroupsTable.TableName & DATA_EXT)
                        If Not My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            LogUtil.LogInfo("ButtonGroups file loaded from installation", MethodBase.GetCurrentMethod.Name)
                            LoadDataTableFromInstallation(oXmlFileName)
                        End If
                        oButtonGroupsTable.Clear()
                        oButtonGroupsTable.ReadXml(oXmlFileName)
                    Case "Button"
                        oXmlFileName = Path.Combine(pFolder, oButtonTable.TableName & DATA_EXT)
                        If Not My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            LogUtil.LogInfo("Button file loaded from installation", MethodBase.GetCurrentMethod.Name)
                            LoadDataTableFromInstallation(oXmlFileName)
                        End If
                        oButtonTable.Clear()
                        oButtonTable.ReadXml(oXmlFileName)
                    Case "Senders"
                        oXmlFileName = Path.Combine(pFolder, oSendersTable.TableName & DATA_EXT)
                        If Not My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            LogUtil.LogInfo("Senders file loaded from installation", MethodBase.GetCurrentMethod.Name)
                            LoadDataTableFromInstallation(oXmlFileName)
                        End If
                        oSendersTable.Clear()
                        oSendersTable.ReadXml(oXmlFileName)
                    Case "SenderButton"
                        oXmlFileName = Path.Combine(pFolder, oSenderButtonTable.TableName & DATA_EXT)
                        If Not My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            LogUtil.LogInfo("SenderButton file loaded from installation", MethodBase.GetCurrentMethod.Name)
                            LoadDataTableFromInstallation(oXmlFileName)
                        End If
                        oSenderButtonTable.Clear()
                        oSenderButtonTable.ReadXml(oXmlFileName)
                    Case "Smtp"
                        oXmlFileName = Path.Combine(pFolder, oSmtpTable.TableName & DATA_EXT)
                        If Not My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            LogUtil.LogInfo("Smtp file loaded from installation", MethodBase.GetCurrentMethod.Name)
                            LoadDataTableFromInstallation(oXmlFileName)
                        End If
                        oSmtpTable.Clear()
                        oSmtpTable.ReadXml(oXmlFileName)
                    Case "Settings"
                        oXmlFileName = Path.Combine(pFolder, oSettingsTable.TableName & DATA_EXT)
                        If Not My.Computer.FileSystem.FileExists(oXmlFileName) Then
                            LogUtil.LogInfo("Settings file loaded from installation", MethodBase.GetCurrentMethod.Name)
                            LoadDataTableFromInstallation(oXmlFileName)
                        End If
                        oSettingsTable.Clear()
                        oSettingsTable.ReadXml(oXmlFileName)
                    Case Else
                        LogUtil.LogInfo("Unknown table " & otable & " cannot be loaded", MethodBase.GetCurrentMethod.Name)
                End Select
            Else
                Throw New ApplicationException("Restore folder missing.")
            End If
        End Sub
        Private Sub LoadDataTableFromInstallation(oXmlFileName As String)
            Dim oInstallDataPath As String = Path.Combine(My.Application.Info.DirectoryPath, "Data")
            Dim oSourceFilename As String = Path.GetFileName(oXmlFileName)
            Dim oFullSourceName As String = Path.Combine(oInstallDataPath, oSourceFilename)
            Dim oTargetPath As String = Path.GetDirectoryName(oXmlFileName)
            Dim oFullTargetName As String = Path.Combine(oTargetPath, oSourceFilename)
            TryCopyFile(oFullSourceName, oFullTargetName, False)
        End Sub
        Public Function TryCopyFile(pFullname As String, pDestination As String, pOverwrite As Boolean) As Boolean
            Return TryCopyFile(pFullname, pDestination, pOverwrite, False, False)
        End Function
        Public Function TryCopyFile(pFullname As String, pDestination As String, pOverwrite As Boolean, pIsDisplayException As Boolean) As Boolean
            Return TryCopyFile(pFullname, pDestination, pOverwrite, pIsDisplayException, False)
        End Function
        Public Function TryCopyFile(pFullname As String, pDestination As String, pOverwrite As Boolean, pIsDisplayException As Boolean, pIsThrowException As Boolean) As Boolean
            Dim isCopied As Boolean
            Try
                My.Computer.FileSystem.CopyFile(pFullname, pDestination, pOverwrite)
                isCopied = True
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                        OrElse TypeOf ex Is IOException _
                        OrElse TypeOf ex Is NotSupportedException _
                        OrElse TypeOf ex Is UnauthorizedAccessException _
                        OrElse TypeOf ex Is Security.SecurityException)
                isCopied = False
                If pIsDisplayException Then LogUtil.DisplayException(ex, "Copying file", MethodBase.GetCurrentMethod.Name)
                If pIsThrowException Then Throw New ApplicationException("Copy file failed for " & pFullname, ex)
            End Try
            Return isCopied
        End Function
        Private Function WriteXmlFromTable(pDataTable As DataTable) As String
            Dim sTableName As String = pDataTable.TableName
            LogUtil.Debug("Writing XML file", MethodBase.GetCurrentMethod.Name)
            Dim sTableFile As String
            Try
                sTableFile = Path.Combine(oDataFolderName, sTableName & DATA_EXT)
                pDataTable.WriteXml(sTableFile, XmlWriteMode.WriteSchema)
            Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                 OrElse TypeOf ex Is InvalidOperationException)
                LogUtil.HandleStatus("Error saving " & sTableName, ex, False, Nothing, Nothing, True, MethodBase.GetCurrentMethod.Name, TraceEventType.Critical, "", 3, False, False, True)
                Throw New ApplicationException("Problem writing XML file for " & sTableName, ex)
            End Try
            Return sTableFile
        End Function
        Public Sub CreateFolder(pFoldername As String, pAllowLogging As Boolean)
            If Not My.Computer.FileSystem.DirectoryExists(pFoldername) Then
                If pAllowLogging Then
                    LogUtil.LogInfo("Creating " & pFoldername, MethodBase.GetCurrentMethod.Name)
                End If
                Try
                    My.Computer.FileSystem.CreateDirectory(pFoldername)
                Catch ex As Exception When (TypeOf ex Is ArgumentException _
                                OrElse TypeOf ex Is IO.PathTooLongException _
                                OrElse TypeOf ex Is NotSupportedException _
                                OrElse TypeOf ex Is IOException _
                                OrElse TypeOf ex Is UnauthorizedAccessException)
                    If pAllowLogging Then
                        LogUtil.DisplayException(ex, "Create Folder", MethodBase.GetCurrentMethod.Name)
                    End If
                    Throw New ApplicationException("CreateDirectory Failed for " & pFoldername, ex)
                End Try
            End If
        End Sub
#End Region
#Region "backup"
        Public Function RestoreDataTable(tableType As String, datapath As String) As Integer
            Dim rowCount As Integer = 0
            Try
                LoadDataTableFromXml(tableType, datapath)
                Select Case tableType
                    Case "Settings"
                        WriteXmlFromTable(oSettingsTable)
                        rowCount = oSettingsTable.Rows.Count
                    Case "Button"
                        WriteXmlFromTable(oButtonTable)
                        rowCount = oButtonTable.Rows.Count
                    Case "ButtonGroups"
                        WriteXmlFromTable(oButtonGroupsTable)
                        rowCount = oButtonGroupsTable.Rows.Count
                    Case "Senders"
                        WriteXmlFromTable(oSendersTable)
                        rowCount = oSendersTable.Rows.Count
                    Case "SenderButton"
                        WriteXmlFromTable(oSenderButtonTable)
                        rowCount = oSenderButtonTable.Rows.Count
                    Case "Smtp"
                        WriteXmlFromTable(oSmtpTable)
                        rowCount = oSmtpTable.Rows.Count
                End Select
            Catch ex As Exception
                MsgBox(GetMessage(ex), MsgBoxStyle.Exclamation, "Error")
            End Try
            Return rowCount
        End Function
#End Region
#Region "buttons"
        Public Function GetButtonTable() As buttonDataTable
            Return oButtonTable
        End Function
        Public Function GetButtonById(pId As Integer) As buttonRow
            LogUtil.Debug("Getting Record " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oButtonRow As buttonRow = Nothing
            Try
                Dim oButtonRows = From Button In oButtonTable.AsEnumerable()
                                  Select Button
                                  Where Button.buttonId = pId
                If oButtonRows.Count > 0 Then
                    oButtonRow = oButtonRows.First
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oButtonRow
        End Function
        Public Function GetButtonByGroupAndSeq(_buttonGrpId As Integer, _buttonSeq As Integer) As buttonRow
            LogUtil.Info("Getting Button row for Grp " & _buttonGrpId & " Seq " & _buttonSeq, MethodBase.GetCurrentMethod.Name)
            Dim oButtonRow As buttonRow = Nothing
            Try
                Dim oButtonRows = From Button In oButtonTable.AsEnumerable()
                                  Select Button
                                  Where Button.buttonGroup = _buttonGrpId And Button.buttonSeq = _buttonSeq
                If oButtonRows.Count > 0 Then
                    oButtonRow = oButtonRows.First
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oButtonRow

        End Function
        Public Function GetButtonsByGroup(_buttonGrpId As Integer) As List(Of buttonRow)
            LogUtil.Info("Getting Button row list for Grp " & _buttonGrpId, MethodBase.GetCurrentMethod.Name)
            Dim oButtonList As New List(Of buttonRow)
            Try
                Dim oButtonRows = From Button In oButtonTable.AsEnumerable()
                                  Select Button
                                  Where Button.buttonGroup = _buttonGrpId
                For Each oRow As buttonRow In oButtonRows
                    oButtonList.Add(oRow)
                Next
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oButtonList
        End Function

        Public Function UpdateButtonGroupOnButton(_buttonGrpId As Integer, _buttonId As Integer) As Boolean
            LogUtil.Info("Updating Grp " & _buttonGrpId, MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            Try
                Dim oButtonRow As buttonRow = GetButtonById(_buttonId)
                If oButtonRow IsNot Nothing Then
                    oButtonRow.buttonGroup = _buttonGrpId
                    WriteXmlFromTable(oButtonTable)
                    isUpdated = True
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, BUTTON_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isUpdated
        End Function
        Public Function InsertButton(_button As Nbutton) As Boolean
            LogUtil.Info("Inserting Button for Grp " & _button.Group & " Seq " & _button.Sequence, MethodBase.GetCurrentMethod.Name)
            Dim isinserted As Boolean = False
            Dim oButtonRow As buttonRow = oButtonTable.NewRow
            Try
                oButtonRow = SetButtonRowValues(_button, oButtonRow)
                oButtonTable.Rows.Add(oButtonRow)
                WriteXmlFromTable(oButtonTable)
                isinserted = True

            Catch ex As DbException
                LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isinserted
        End Function
        Private Function SetButtonRowValues(pButton As Nbutton, pButtonRow As buttonRow) As buttonRow
            With pButton
                pButtonRow.buttonGroup = .Group
                pButtonRow.buttonSeq = .Sequence
                pButtonRow.buttonText = .Caption
                pButtonRow.buttonHint = .Hint
                pButtonRow.buttonValue = .Value
                pButtonRow.buttonFont = .FontName
                pButtonRow.buttonBold = .FontBold
                pButtonRow.buttonFontSize = .FontSize
                pButtonRow.buttonItalic = .FontItalic
                pButtonRow.buttonEncrypt = .Encrypt
            End With
            Return pButtonRow
        End Function
        Public Function UpdateButton(_button As Nbutton) As Boolean
            LogUtil.Info("Updating Button " & _button.Id, MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            Try
                Dim oButtonRow As buttonRow = GetButtonById(_button.Id)
                If oButtonRow IsNot Nothing Then
                    SetButtonRowValues(_button, oButtonRow)
                    WriteXmlFromTable(oButtonTable)
                    isUpdated = True
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, BUTTON_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isUpdated
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
                Dim oButton As Nbutton = ButtonBuilder.NewButton.StartingWith(_buttonId, _buttonGrp,
                                 _buttonSeq,
                                 _buttontext,
                                 _buttonHint,
                                 _buttonValue,
                                 _buttonFont,
                                 _buttonFontSize,
                                 _buttonBold,
                                 _buttonItalic,
                                 _buttonEncrypt, Nbutton.DataSource.Undefined).Build

                UpdateButton(oButton)
            Catch ex As DbException
                LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isOk
        End Function
        Public Function DeleteButton(_Id As Integer) As Boolean
            LogUtil.Info("Deleting Button " & _Id, MethodBase.GetCurrentMethod.Name)
            Dim isOk As Boolean = False
            Try
                Dim oButtonRow As buttonRow = GetButtonById(_Id)
                oButtonTable.Rows.Remove(oButtonRow)
                WriteXmlFromTable(oButtonTable)
                isOk = True
            Catch ex As DbException
                LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isOk
        End Function
        Public Sub ResequenceButtons(_grp As Integer)
            LogUtil.Info("Resequencing buttons", MethodBase.GetCurrentMethod.Name)
            Dim iSeq As Integer = 1
            For Each oRow As buttonRow In oButtonTable.Rows
                If oRow.buttonGroup = _grp Then
                    oRow.buttonSeq = iSeq
                    iSeq += 1
                End If
            Next
            WriteXmlFromTable(oButtonTable)
        End Sub
#End Region
#Region "groups"
        Public Function GetButtonGroupsTable() As buttongroupsDataTable
            Return oButtonGroupsTable
        End Function
        Public Function GetButtonGroupById(pId As Integer) As ButtonGroup
            LogUtil.Info("Getting Button Group " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oButtonGroup As New ButtonGroup
            Try
                Dim oButtonGroupRows = From ButtonGroup In oButtonGroupsTable.AsEnumerable()
                                       Select ButtonGroup
                                       Where ButtonGroup.buttongroupid = pId
                If oButtonGroupRows.Count > 0 Then
                    oButtonGroup = ButtonGroupBuilder.aButtonGroup.StartingWith(oButtonGroupRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oButtonGroup
        End Function
        Public Function GetButtonGroupRowById(pId As Integer) As buttongroupsRow
            LogUtil.Info("Getting Button Group " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oButtonGrouprow As buttongroupsRow = Nothing
            Try
                Dim oButtonGroupRows = From ButtonGroup In oButtonGroupsTable.AsEnumerable()
                                       Select ButtonGroup
                                       Where ButtonGroup.buttongroupid = pId
                If oButtonGroupRows.Count > 0 Then
                    oButtonGrouprow = oButtonGroupRows.First
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oButtonGrouprow
        End Function
        Public Function DeleteButtonGroup(_buttonGrpId As Integer) As Boolean
            LogUtil.Info("Deleting Button Group " & _buttonGrpId, MethodBase.GetCurrentMethod.Name)
            Dim isOk As Boolean = False
            Try
                Dim oButtonGroupRow As buttongroupsRow = GetButtonGroupRowById(_buttonGrpId)
                oButtonGroupsTable.Rows.Remove(oButtonGroupRow)
                WriteXmlFromTable(oButtonGroupsTable)
                isOk = True
            Catch ex As DbException
                LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isOk
        End Function
        Public Function InsertButtonGroup(_groupname As String) As Boolean
            LogUtil.Info("Inserting Button Group " & _groupname, MethodBase.GetCurrentMethod.Name)
            Dim isinserted As Boolean = False
            Dim oButtonGroupRow As buttongroupsRow = oButtonGroupsTable.NewRow
            Try
                oButtonGroupRow.groupname = _groupname
                oButtonGroupsTable.Rows.Add(oButtonGroupRow)
                WriteXmlFromTable(oButtonGroupsTable)
                isinserted = True
            Catch ex As DbException
                LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isinserted
        End Function
        Public Function UpdateButtonGroupName(_groupname As String, _groupId As Integer) As Boolean
            LogUtil.Info("Updating Button Group " & _groupId, MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            Try
                Dim oButtonGroupRow As buttongroupsRow = GetButtonGroupRowById(_groupId)
                If oButtonGroupRow IsNot Nothing Then
                    oButtonGroupRow.groupname = _groupname
                    WriteXmlFromTable(oButtonGroupsTable)
                    isUpdated = True
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, BUTTON_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isUpdated
        End Function
#End Region
#Region "senders"
        Public Function GetSenderTable() As sendersDataTable
            Return oSendersTable
        End Function
        Public Function GetSenderById(pId As Integer) As Sender
            LogUtil.Info("Getting Sender " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oSender As New Sender
            Try
                Dim oSenderRows = From Sender In oSendersTable.AsEnumerable()
                                  Select Sender
                                  Where Sender.SenderId = pId
                If oSenderRows.Count > 0 Then
                    oSender = SenderBuilder.ASender.StartingWith(oSenderRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oSender
        End Function
        Public Function GetSenderRowById(pId As Integer) As sendersRow
            LogUtil.Info("Getting Button Group " & pId, MethodBase.GetCurrentMethod.Name)
            Dim oSenderrow As sendersRow = Nothing
            Try
                Dim oSenderRows = From Sender In oSendersTable.AsEnumerable()
                                  Select Sender
                                  Where Sender.SenderId = pId
                If oSenderRows.Count > 0 Then
                    oSenderrow = oSenderRows.First
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oSenderrow
        End Function
        Public Function DeleteSender(_buttonGrpId As Integer) As Boolean
            LogUtil.Info("Deleting Button Group " & _buttonGrpId, MethodBase.GetCurrentMethod.Name)
            Dim isOk As Boolean = False
            Try
                Dim oSenderRow As sendersRow = GetSenderRowById(_buttonGrpId)
                oSendersTable.Rows.Remove(oSenderRow)
                WriteXmlFromTable(oSendersTable)
                isOk = True
            Catch ex As DbException
                LogUtil.Exception("Update failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isOk
        End Function
        Public Function InsertSender(pSender As Sender) As Boolean
            LogUtil.Info("Inserting Sender", MethodBase.GetCurrentMethod.Name)
            Dim isinserted As Boolean = False
            Dim oSenderRow As sendersRow = oSendersTable.NewRow
            Try
                oSenderRow = SetSenderRowValues(pSender, oSenderRow)
                oSendersTable.Rows.Add(oSenderRow)
                WriteXmlFromTable(oSendersTable)
                isinserted = True
            Catch ex As DbException
                LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isinserted
        End Function
        Private Function SetSenderRowValues(pSender As Sender, oSenderRow As sendersRow) As sendersRow
            With pSender

                oSenderRow.Title = .Title
                oSenderRow.FirstName = .FirstName
                oSenderRow.LastName = .LastName
                oSenderRow.Address1 = .Address1
                oSenderRow.Address2 = .Address2
                oSenderRow.Town = .Town
                oSenderRow.County = .County
                oSenderRow.Country = .Country
                oSenderRow.PostCode = .PostCode
                oSenderRow.dob = .DateOfBirth
                oSenderRow.Email = .Email
                oSenderRow.Phone = .Phone
                oSenderRow.Mobile = .Mobile
                oSenderRow.Passwd = .Password
                oSenderRow.SecretWord = .SecretWord
                oSenderRow.gender = .Gender
                oSenderRow.Occupation = .Occupation
                oSenderRow.MaritalStatus = .MaritalStatus
                oSenderRow.Username = .Username
            End With
            Return oSenderRow
        End Function
        Public Function UpdateSender(pSender As Sender) As Boolean
            LogUtil.Info("Updating Sender", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            Try
                Dim oSenderRow As sendersRow = GetSenderRowById(pSender.SenderId)
                If oSenderRow IsNot Nothing Then
                    oSenderRow = SetSenderRowValues(pSender, oSenderRow)
                    WriteXmlFromTable(oSendersTable)
                    isUpdated = True
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, BUTTON_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isUpdated
        End Function
#End Region
#Region "senderbuttons"
        Public Function GetSenderButtonTable() As senderButtonDataTable
            Return oSenderButtonTable
        End Function
        Public Function GetSenderButton(pColumnName As String) As SenderButton
            LogUtil.Info("Getting SenderButton " & pColumnName, MethodBase.GetCurrentMethod.Name)
            Dim oSenderButton As New SenderButton
            Try
                Dim oSenderButtonRows = From SenderButton In oSenderButtonTable.AsEnumerable()
                                        Select SenderButton
                                        Where SenderButton.ColumnName = pColumnName
                If oSenderButtonRows.Count > 0 Then
                    oSenderButton = SenderButtonBuilder.aSenderButton.StartingWith(oSenderButtonRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oSenderButton
        End Function
        Public Function GetSenderButtonRowById(pColumnName As String) As senderButtonRow
            LogUtil.Debug("Getting Sender Button " & pColumnName, MethodBase.GetCurrentMethod.Name)
            Dim oSenderButtonRow As senderButtonRow = Nothing
            Try
                Dim oSenderButtonRows = From SenderButton In oSenderButtonTable.AsEnumerable()
                                        Select SenderButton
                                        Where SenderButton.ColumnName = pColumnName
                If oSenderButtonRows.Count > 0 Then
                    oSenderButtonRow = oSenderButtonRows.First
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oSenderButtonRow
        End Function
        Public Function DeleteSenderButton(pColumnName As String) As Boolean
            LogUtil.Info("Deleting Button Group " & pColumnName, MethodBase.GetCurrentMethod.Name)
            Dim isOk As Boolean = False
            Try
                Dim oSenderButtonRow As senderButtonRow = GetSenderButtonRowById(pColumnName)
                oSenderButtonTable.Rows.Remove(oSenderButtonRow)
                WriteXmlFromTable(oSenderButtonTable)
                isOk = True
            Catch ex As DbException
                LogUtil.Exception("Delete failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isOk
        End Function
        Public Function InsertSenderButton(pSenderButton As SenderButton) As Boolean
            LogUtil.Info("Inserting SenderButton", MethodBase.GetCurrentMethod.Name)
            Dim isinserted As Boolean = False
            Dim oSenderButtonRow As senderButtonRow = oSenderButtonTable.NewRow
            Try
                oSenderButtonRow = SetSenderButtonRowValues(pSenderButton, oSenderButtonRow)
                oSenderButtonTable.Rows.Add(oSenderButtonRow)
                WriteXmlFromTable(oSenderButtonTable)
                isinserted = True
            Catch ex As DbException
                LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isinserted
        End Function
        Private Function SetSenderButtonRowValues(pSenderButton As SenderButton, oSenderButtonRow As senderButtonRow) As senderButtonRow
            With pSenderButton
                oSenderButtonRow.ColumnName = .ColumnName
                oSenderButtonRow.buttonBold = .Bold
                oSenderButtonRow.buttonItalic = .Italic
                oSenderButtonRow.buttonFontName = .FontName
                oSenderButtonRow.buttonFontSize = .FontSize
                oSenderButtonRow.buttonEncrypted = .IsEncrypted
            End With
            Return oSenderButtonRow
        End Function
        Public Function UpdateSenderButton(pSenderButton As SenderButton) As Boolean
            LogUtil.Info("Updating SenderButton", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            Try
                Dim oSenderButtonRow As senderButtonRow = GetSenderButtonRowById(pSenderButton.ColumnName)
                If oSenderButtonRow IsNot Nothing Then
                    oSenderButtonRow = SetSenderButtonRowValues(pSenderButton, oSenderButtonRow)
                    WriteXmlFromTable(oSenderButtonTable)
                    isUpdated = True
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, BUTTON_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isUpdated
        End Function
#End Region
#Region "smtp"
        Public Function GetSmtpTable() As smtpDataTable
            Return oSmtpTable
        End Function
        Public Function GetSmtpById(pId As Integer) As SmtpAccount
            LogUtil.Info("Getting Smtp Account", MethodBase.GetCurrentMethod.Name)
            Dim oSmtp As New SmtpAccount
            Try
                Dim oSmtpRows = From Smtp In oSmtpTable.AsEnumerable()
                                Select Smtp
                                Where Smtp.smtpId = pId
                If oSmtpRows.Count > 0 Then
                    oSmtp = SmtpAccountBuilder.AnSmtpAccount.StartingWith(oSmtpRows.First).Build
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oSmtp
        End Function
        Public Function GetSmtpRowById(pId As Integer) As smtpRow
            LogUtil.Info("Getting SMTP Row ", MethodBase.GetCurrentMethod.Name)
            Dim oSmtpRow As smtpRow = Nothing
            Try
                Dim oSmtpRows = From Smtp In oSmtpTable.AsEnumerable()
                                Select Smtp
                                Where Smtp.smtpId = pId
                If oSmtpRows.Count > 0 Then
                    oSmtpRow = oSmtpRows.First
                End If
            Catch ex As SqlException
                LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
            End Try
            Return oSmtpRow
        End Function
        Public Function DeleteSmtp(pId As Integer) As Boolean
            LogUtil.Info("Deleting SMTP Account", MethodBase.GetCurrentMethod.Name)
            Dim isOk As Boolean = False
            Try
                Dim oSmtpRow As smtpRow = GetSmtpRowById(pId)
                oSmtpTable.Rows.Remove(oSmtpRow)
                WriteXmlFromTable(oSmtpTable)
                isOk = True
            Catch ex As DbException
                LogUtil.Exception("Delete failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isOk
        End Function
        Public Function InsertSmtp(pSmtp As SmtpAccount) As Boolean
            LogUtil.Info("Inserting Smtp", MethodBase.GetCurrentMethod.Name)
            Dim isinserted As Boolean = False
            Dim oSmtpRow As smtpRow = oSmtpTable.NewRow
            Try
                oSmtpRow = SetSmtpRowValues(pSmtp, oSmtpRow)
                oSmtpTable.Rows.Add(oSmtpRow)
                WriteXmlFromTable(oSmtpTable)
                isinserted = True
            Catch ex As DbException
                LogUtil.Exception("Insert failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isinserted
        End Function
        Private Function SetSmtpRowValues(pSmtp As SmtpAccount, oSmtpRow As smtpRow) As smtpRow
            With pSmtp
                oSmtpRow.smtpId = .SmtpId
                oSmtpRow.smtpHost = .Host
                oSmtpRow.smtpPassword = .Password
                oSmtpRow.smtpPort = .Port
                oSmtpRow.smtpReqCred = .IsCredentialsRequired
                oSmtpRow.smtpSsl = .IsEnableSsl
                oSmtpRow.smtpUsername = .Username
            End With
            Return oSmtpRow
        End Function
        Public Function UpdateSmtp(pSmtp As SmtpAccount) As Boolean
            LogUtil.Info("Updating Smtp", MethodBase.GetCurrentMethod.Name)
            Dim isUpdated As Boolean = False
            Try
                Dim oSmtpRow As smtpRow = GetSmtpRowById(pSmtp.SmtpId)
                If oSmtpRow IsNot Nothing Then
                    oSmtpRow = SetSmtpRowValues(pSmtp, oSmtpRow)
                    WriteXmlFromTable(oSmtpTable)
                    isUpdated = True
                End If
            Catch ex As Exception
                LogUtil.DisplayException(ex, BUTTON_TABLE, MethodBase.GetCurrentMethod.Name)
            End Try
            Return isUpdated
        End Function
        Public Function GetSmtpList() As List(Of SmtpAccount)
            LogUtil.Info("Getting SMTP list", MethodBase.GetCurrentMethod.Name)
            Dim _smtpList As New List(Of SmtpAccount)
            Try
                For Each _row As smtpRow In oSmtpTable.Rows
                    _smtpList.Add(SmtpAccountBuilder.AnSmtpAccount.StartingWith(_row).Build)
                Next
            Catch ex As DbException
                LogUtil.Exception("Failed: ", ex, MethodBase.GetCurrentMethod.Name)
            End Try
            Return _smtpList
        End Function
#End Region
#Region "settings"
        Public Function GetSettingsTable() As settingsDataTable
            Return oSettingsTable
        End Function
#End Region
    End Module
End Namespace