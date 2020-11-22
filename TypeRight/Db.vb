Module Db

    Private oBgTa As New TypeRightDataSetTableAdapters.buttongroupsTableAdapter
    Private oBgTable As New TypeRightDataSet.buttongroupsDataTable
    Private oBtnTa As New TypeRightDataSetTableAdapters.buttonTableAdapter
    Private oBtnTable As New TypeRightDataSet.buttonDataTable
    Public Function DeleteButtonGroup(_buttonGrpId As Integer) As Integer
        Return oBgTa.DeleteButtonGroup(_buttonGrpId)
    End Function
    Public Function GetButtonGroup(_buttonGrpId As Integer) As TypeRightDataSet.buttongroupsRow
        Dim oBgRow As TypeRightDataSet.buttongroupsRow = Nothing
        oBgTa.FillById(oBgTable, _buttonGrpId)
        If oBgTable.Rows.Count = 1 Then
            oBgRow = oBgTable.Rows(0)
        End If
        Return oBgRow
    End Function
    Public Function GetButtonByGroupAndSeq(_buttonGrpId As Integer, _buttonSeq As Integer) As TypeRightDataSet.buttonRow
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillByGroupSeq(oBtnTable, _buttonGrpId, _buttonSeq)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function GetButtonById(_buttonId As Integer) As TypeRightDataSet.buttonRow
        Dim oBtnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillById(oBtnTable, _buttonId)
        If oBtnTable.Rows.Count = 1 Then
            oBtnRow = oBtnTable.Rows(0)
        End If
        Return oBtnRow
    End Function
    Public Function UpdateButtonGroup(_buttonGrpId As Integer, _buttonId As Integer) As Integer
        Return oBtnTa.UpdateGroup(_buttonGrpId, _buttonId)
    End Function
    Public Function UpdateButton(_buttonGrp As Integer, _buttonSeq As Integer, _buttontext As String, _buttonHint As String, _buttonValue As String, _buttonFont As String, _buttonBold As Boolean, _buttonId As Integer) As Integer
        Return oBtnTa.UpdateButton(_buttonGrp, _buttonSeq, _buttontext, _buttonHint, _buttonValue, _buttonFont, CByte(_buttonBold), _buttonId)
    End Function
End Module
