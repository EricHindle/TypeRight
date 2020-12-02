Module Db
#Region "dB"
    Private ReadOnly oBgTa As New TypeRightDataSetTableAdapters.buttongroupsTableAdapter
    Private ReadOnly oBgTable As New TypeRightDataSet.buttongroupsDataTable
    Private ReadOnly oBtnTa As New TypeRightDataSetTableAdapters.buttonTableAdapter
    Private ReadOnly oBtnTable As New TypeRightDataSet.buttonDataTable
    Private ReadOnly oSndTa As New TypeRightDataSetTableAdapters.sendersTableAdapter
    Private ReadOnly oSndTable As New TypeRightDataSet.sendersDataTable
#End Region
#Region "buttons"
    Public Function GetButtons()
        oBtnTa.Fill(oBtnTable)
        Return oBtnTable
    End Function
    Public Function GetButtonByGroupAndSeq(_buttonGrpId As Integer, _buttonSeq As Integer) As TypeRightDataSet.buttonRow
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillByGroupSeq(oBtnTable, _buttonGrpId, _buttonSeq)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function GetButtonsByGroup(_buttonGrpId As Integer) As TypeRightDataSet.buttonDataTable
        oBtnTa.FillByGroup(oBtnTable, _buttonGrpId)
        Return oBtnTable
    End Function
    Public Function GetButtonById(_buttonId As Integer) As TypeRightDataSet.buttonRow
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillById(oBtnTable, _buttonId)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function UpdateButtonGroupOnButton(_buttonGrpId As Integer, _buttonId As Integer) As Integer
        Return oBtnTa.UpdateGroup(_buttonGrpId, _buttonId)
    End Function
    Public Function InsertButton(_button As NbuttonControlLibrary.Nbutton) As Integer
        Return oBtnTa.InsertButton(_button.Group, _button.Sequence, _button.Text, _button.Hint, _button.Value, _button.FontName, _button.FontBold, _button.FontSize, _button.FontItalic, _button.Encrypt)
    End Function
    Public Function UpdateButton(_button As NbuttonControlLibrary.Nbutton) As Integer
        Return oBtnTa.UpdateButton(_button.Group, _button.Sequence, _button.Text, _button.Hint, _button.Value, _button.FontName, _button.FontBold, _button.FontSize, _button.FontItalic, _button.Encrypt, _button.Id)
    End Function
    Public Function InsertButton(_buttonGrp As Integer, _buttonSeq As Integer, _buttontext As String, _buttonHint As String, _buttonValue As String, _buttonFont As String, _buttonBold As Boolean, _buttonFontSize As Integer, _buttonItalic As Boolean, _buttonEncrypt As Boolean) As Integer
        Return oBtnTa.InsertButton(_buttonGrp, _buttonSeq, _buttontext, _buttonHint, _buttonValue, _buttonFont, _buttonBold, _buttonFontSize, _buttonItalic, _buttonEncrypt)
    End Function
    Public Function UpdateButton(_buttonGrp As Integer, _buttonSeq As Integer, _buttontext As String, _buttonHint As String, _buttonValue As String, _buttonFont As String, _buttonBold As Boolean, _buttonFontSize As Integer, _buttonItalic As Boolean, _buttonEncrypt As Boolean, _buttonId As Integer) As Integer
        Return oBtnTa.UpdateButton(_buttonGrp, _buttonSeq, _buttontext, _buttonHint, _buttonValue, _buttonFont, CByte(_buttonBold), _buttonFontSize, CByte(_buttonItalic), _buttonEncrypt, _buttonId)
    End Function
    Public Function DeleteButton(_Id As Integer) As Integer
        Return oBtnTa.DeleteButton(_Id)
    End Function
#End Region
#Region "groups"
    Public Function GetButtonGroup(_buttonGrpId As Integer) As TypeRightDataSet.buttongroupsRow
        Dim oBgRow As TypeRightDataSet.buttongroupsRow = Nothing
        oBgTa.FillById(oBgTable, _buttonGrpId)
        If oBgTable.Rows.Count = 1 Then
            oBgRow = oBgTable.Rows(0)
        End If
        Return oBgRow
    End Function
    Public Function GetButtonGroups() As TypeRightDataSet.buttongroupsDataTable
        oBgTa.Fill(oBgTable)
        Return oBgTable
    End Function
    Public Function DeleteButtonGroup(_buttonGrpId As Integer) As Integer
        Return oBgTa.DeleteButtonGroup(_buttonGrpId)
    End Function
    Public Function InsertButtonGroup(_groupname As String) As Integer
        Return oBgTa.InsertButtonGroup(_groupname)
    End Function
    Public Function UpdateButtonGroupName(_groupname As String, _groupId As Integer) As Integer
        Return oBgTa.UpdateGroupName(_groupname, _groupId)
    End Function
#End Region
#Region "senders"
    Public Function GetSenders() As TypeRightDataSet.sendersDataTable
        oSndTa.Fill(oSndTable)
        Return oSndTable
    End Function
    Public Function GetSenderById(_id As Integer) As TypeRightDataSet.sendersRow
        oSndTa.FillById(oSndTable, _id)
        Dim oSndRow As TypeRightDataSet.sendersRow = Nothing
        If oSndTable.Rows.Count > 0 Then
            oSndRow = oSndTable.Rows(0)
        End If
        Return oSndRow
    End Function
    Public Function InsertSender(ByRef oSender As Sender) As Integer
        Return oSndTa.InsertSender(oSender.Title, oSender.FirstName, oSender.LastName, oSender.Address1, oSender.Address2, oSender.Town,
        oSender.County, oSender.Country, oSender.PostCode, Format(oSender.DateOfBirth, "yyyy-MM-dd"),
                            oSender.Email, oSender.Phone, oSender.Mobile, oSender.Password, oSender.SecretWord,
                            oSender.Gender, oSender.Occupation, oSender.MaritalStatus, oSender.Username)
    End Function
    Public Function UpdateSender(ByRef oSender As Sender) As Integer
        Return oSndTa.UpdateSender(oSender.Title, oSender.FirstName, oSender.LastName, oSender.Address1, oSender.Address2, oSender.Town,
        oSender.County, oSender.Country, oSender.PostCode, Format(oSender.DateOfBirth, "yyyy-MM-dd"),
                            oSender.Email, oSender.Phone, oSender.Mobile, oSender.Password, oSender.SecretWord,
                            oSender.Gender, oSender.Occupation, oSender.MaritalStatus, oSender.Username, oSender.SenderId)

    End Function
    Public Function DeleteSender(_id As Integer) As Integer
        Return oSndTa.DeleteSender(_id)
    End Function
#End Region
End Module
