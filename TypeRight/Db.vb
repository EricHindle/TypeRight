Imports System.Data.Common
Imports System.Reflection

Module Db
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
    Public Function GetButtons()
        LogUtil.Info("Getting button table", "Db")
        Return oBtnTa.GetData()
    End Function
    Public Function GetButtonByGroupAndSeq(_buttonGrpId As Integer, _buttonSeq As Integer) As TypeRightDataSet.buttonRow
        LogUtil.Info("Getting button row for Grp " & CStr(_buttonGrpId) & " Seq " & CStr(_buttonSeq), "Db")
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillByGroupSeq(oBtnTable, _buttonGrpId, _buttonSeq)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function GetButtonsByGroup(_buttonGrpId As Integer) As TypeRightDataSet.buttonDataTable
        LogUtil.Info("Getting button table for Grp " & CStr(_buttonGrpId), "Db")
        oBtnTa.FillByGroup(oBtnTable, _buttonGrpId)
        Return oBtnTable
    End Function
    Public Function GetButtonById(_buttonId As Integer) As TypeRightDataSet.buttonRow
        LogUtil.Info("Getting button row " & CStr(_buttonId), "Db")
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillById(oBtnTable, _buttonId)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function UpdateButtonGroupOnButton(_buttonGrpId As Integer, _buttonId As Integer) As Integer
        LogUtil.Info("Updating Grp " & CStr(_buttonGrpId), "Db")
        Return oBtnTa.UpdateGroup(_buttonGrpId, _buttonId)
    End Function
    Public Function InsertButton(_button As NbuttonControlLibrary.Nbutton) As Integer
        LogUtil.Info("Inserting button for Grp " & CStr(_button.Group) & " Seq " & CStr(_button.Sequence), "Db")
        Return oBtnTa.InsertButton(_button.Group, _button.Sequence,
                                   _button.Caption, _button.Hint,
                                   _button.Value, _button.FontName,
                                   _button.FontBold, _button.FontSize,
                                   _button.FontItalic, _button.Encrypt)
    End Function
    Public Function UpdateButton(_button As NbuttonControlLibrary.Nbutton) As Integer
        LogUtil.Info("Updating button " & CStr(_button.Id), "Db")
        Return oBtnTa.UpdateButton(_button.Group, _button.Sequence,
                                   _button.Caption, _button.Hint,
                                   _button.Value, _button.FontName,
                                   _button.FontBold, _button.FontSize,
                                   _button.FontItalic, _button.Encrypt, _button.Id)
    End Function
    Public Function InsertButton(_buttonGrp As Integer, _buttonSeq As Integer, _buttontext As String, _buttonHint As String, _buttonValue As String, _buttonFont As String, _buttonBold As Boolean, _buttonFontSize As Integer, _buttonItalic As Boolean, _buttonEncrypt As Boolean) As Integer
        LogUtil.Info("Inserting button row for Grp " & CStr(_buttonGrp) & " Seq " & CStr(_buttonSeq), "Db")
        Return oBtnTa.InsertButton(_buttonGrp, _buttonSeq,
                                   _buttontext, _buttonHint,
                                   _buttonValue, _buttonFont,
                                   _buttonBold, _buttonFontSize,
                                   _buttonItalic, _buttonEncrypt)
    End Function
    Public Function UpdateButton(_buttonGrp As Integer, _buttonSeq As Integer, _buttontext As String, _buttonHint As String, _buttonValue As String, _buttonFont As String, _buttonBold As Boolean, _buttonFontSize As Integer, _buttonItalic As Boolean, _buttonEncrypt As Boolean, _buttonId As Integer) As Integer
        LogUtil.Info("Updating button " & CStr(_buttonId), "Db")
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
        LogUtil.Info("Deleting button " & CStr(_Id), "Db")
        Return oBtnTa.DeleteButton(_Id)
    End Function
    Public Sub ResequenceButtons(_grp As Integer)
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
        LogUtil.Info("Getting group " & CStr(_buttonGrpId), "Db")
        Dim oBgRow As TypeRightDataSet.buttongroupsRow = Nothing
        oBgTa.FillById(oBgTable, _buttonGrpId)
        If oBgTable.Rows.Count = 1 Then
            oBgRow = oBgTable.Rows(0)
        End If
        Return oBgRow
    End Function
    Public Function GetButtonGroups() As TypeRightDataSet.buttongroupsDataTable
        LogUtil.Info("Getting group table", "Db")
        Return oBgTa.GetData
    End Function
    Public Function DeleteButtonGroup(_buttonGrpId As Integer) As Integer
        LogUtil.Info("Deleting group " & CStr(_buttonGrpId), "Db")
        Return oBgTa.DeleteButtonGroup(_buttonGrpId)
    End Function
    Public Function InsertButtonGroup(_groupname As String) As Integer
        LogUtil.Info("Inserting group " & _groupname, "Db")
        Return oBgTa.InsertButtonGroup(_groupname)
    End Function
    Public Function UpdateButtonGroupName(_groupname As String, _groupId As Integer) As Integer
        LogUtil.Info("Updating group " & CStr(_groupId), "Db")
        Return oBgTa.UpdateGroupName(_groupname, _groupId)
    End Function
#End Region
#Region "senders"
    Public Function GetSenders() As TypeRightDataSet.sendersDataTable
        LogUtil.Info("Getting sender table", "Db")
        Return oSndTa.GetData()
    End Function
    Public Function GetSenderById(_id As Integer) As TypeRightDataSet.sendersRow
        LogUtil.Info("Getting sender row " & CStr(_id), "Db")
        oSndTa.FillById(oSndTable, _id)
        Dim oSndRow As TypeRightDataSet.sendersRow = Nothing
        If oSndTable.Rows.Count > 0 Then
            oSndRow = oSndTable.Rows(0)
        Else
            LogUtil.Info("Row not found ", "Db")
        End If
        Return oSndRow
    End Function
    Public Function InsertSender(ByRef oSender As Sender) As Integer
        LogUtil.Info("Inserting sender " & oSender.FirstName & " " & oSender.LastName, "Db")
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
        LogUtil.Info("Updating sender " & oSender.SenderId, "Db")
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
        LogUtil.Info("Deleting sender " & _id, "Db")
        Return oSndTa.DeleteSender(_id)
    End Function
#End Region
#Region "senderbuttons"
    Public Function GetSenderButtons() As TypeRightDataSet.senderButtonDataTable
        LogUtil.Info("Getting sender button table", "Db")
        Return oSndBtnTa.GetData()
    End Function
    Public Function GetSenderButton(columnName As String) As TypeRight.TypeRightDataSet.senderButtonRow
        '      LogUtil.Info("Getting sender button row for " & columnName, "Db")
        Dim oRow As TypeRight.TypeRightDataSet.senderButtonRow = Nothing
        oSndBtnTa.FillByColName(oSndBtnTable, columnName)
        If oSndBtnTable.Rows.Count = 1 Then
            oRow = oSndBtnTable.Rows(0)
        End If
        Return oRow
    End Function
    Public Function DeleteSenderButton(columnName As String) As Integer
        LogUtil.Info("Deleting sender button for " & columnName, "Db")
        Return oSndBtnTa.DeleteSenderButton(columnName)
    End Function
    Public Function InsertSenderButton(ColumnName As String, buttonFontName As String, buttonFontSize As Decimal, buttonItalic As Boolean, buttonBold As Boolean, buttonEncrypted As Boolean) As Integer
        LogUtil.Info("Insering sender button row for " & ColumnName, "Db")
        Return oSndBtnTa.InsertSenderButton(ColumnName, CByte(buttonBold),
                                            CByte(buttonItalic), buttonFontName,
                                            buttonFontSize, CByte(buttonEncrypted))
    End Function
    Public Function UpdateSenderButton(ColumnName As String, buttonFontName As String, buttonFontSize As Decimal, buttonItalic As Boolean, buttonBold As Boolean, buttonEncrypted As Boolean) As Integer
        LogUtil.Info("Updating sender button row for " & ColumnName, "Db")
        Return oSndBtnTa.UpdateSenderButton(CByte(buttonBold), CByte(buttonItalic),
                                            buttonFontName, buttonFontSize,
                                            CByte(buttonEncrypted), ColumnName)
    End Function
#End Region

End Module
