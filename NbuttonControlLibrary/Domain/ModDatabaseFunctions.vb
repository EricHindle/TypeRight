' hindleware
' Copyright (c) 2022-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports HindlewareLib.Logging
Imports NbuttonControlLibrary.TypeRightDataSet

Module ModDatabaseFunctions
#Region "constants"
    Public Const DATA_EXT As String = ".htx"
    Public Const BUTTON_TABLE As String = "Button Table"
#End Region
#Region "dB"
    Private oBtnTable As New buttonDataTable
    Public oDataFolder As String
#End Region
#Region "buttons"
    Public Function GetButtonTable() As buttonDataTable
        LogUtil.Info("Getting Button table", MethodBase.GetCurrentMethod.Name)
        LoadButtonTableFromXml()
        Return oBtnTable
    End Function
    Public Sub LoadButtonTableFromXml()
        LogUtil.Debug("Loading table " & oBtnTable.TableName, MethodBase.GetCurrentMethod.Name)
        oDataFolder = My.Settings.DataFilePath
        Dim oXmlFileName As String
        If My.Computer.FileSystem.DirectoryExists(My.Settings.DataFilePath) Then
            oXmlFileName = Path.Combine(oDataFolder, oBtnTable.TableName & DATA_EXT)
            If My.Computer.FileSystem.FileExists(oXmlFileName) Then
                oBtnTable.Clear()
                oBtnTable.ReadXml(oXmlFileName)
            Else
                Throw New ApplicationException("Button data file missing.")
            End If
        Else
            Throw New ApplicationException("Button folder missing.")
        End If
    End Sub
    Private Function WriteXmlFromTable(pDataTable As DataTable) As String
        Dim sTableName As String = pDataTable.TableName
        LogUtil.Debug("Writing XML file", MethodBase.GetCurrentMethod.Name)
        Dim sTableFile As String
        Try
            sTableFile = Path.Combine(oDataFolder, sTableName & DATA_EXT)
            pDataTable.WriteXml(sTableFile, XmlWriteMode.WriteSchema)
        Catch ex As Exception When (TypeOf ex Is ArgumentException _
                             OrElse TypeOf ex Is InvalidOperationException)
            LogUtil.HandleStatus("Error saving " & sTableName, ex, False, Nothing, Nothing, True, MethodBase.GetCurrentMethod.Name, TraceEventType.Critical, "", 3, False, False, True)
            Throw New ApplicationException("Problem writing XML file for " & sTableName, ex)
        End Try
        Return sTableFile
    End Function
    Public Function GetButtonRowById(_buttonId As Integer) As buttonRow
        LogUtil.Info("Getting Button row for Id " & _buttonId, MethodBase.GetCurrentMethod.Name)
        Dim oButtonRow As TypeRightDataSet.buttonRow = Nothing
        Try
            Dim oButtonRows = From Button In oBtnTable.AsEnumerable()
                              Select Button
                              Where Button.buttonId = _buttonId
            If oButtonRows.Count > 0 Then
                oButtonRow = oButtonRows.First
            End If
        Catch ex As SqlException
            LogUtil.DisplayException(ex, "dB", MethodBase.GetCurrentMethod.Name)
        End Try
        Return oButtonRow

    End Function
#End Region
End Module

