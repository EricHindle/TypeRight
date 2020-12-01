Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports System.Text


Public Class FrmDbUpdate
#Region "variables"
    Dim bAdd As Boolean

    Dim iCurrSnd As Integer
    Private sDbFullPath As String       '   Full database path based on location in Options
    Private isLoadingForm As Boolean = False

#End Region
#Region "database"
    Dim oSndTable As New TypeRight.TypeRightDataSet.sendersDataTable
    Dim oBtnTable As New TypeRight.TypeRightDataSet.buttonDataTable
    Dim oSndrTable As New TypeRight.TypeRightDataSet.sendersDataTable
    Dim oGrpTable As New TypeRight.TypeRightDataSet.buttongroupsDataTable
    Dim oSndRow As TypeRight.TypeRightDataSet.sendersRow = Nothing
#End Region
#Region "properties"
    Private _senderId As Integer
    Public Property SenderId() As Integer
        Get
            Return _senderId
        End Get
        Set(ByVal value As Integer)
            _senderId = value
        End Set
    End Property
#End Region
#Region "form handlers"
    Private Sub FrmDbUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.EditButtonPos)
        LoadSenderTable()
    End Sub

    Private Sub LoadSenderTable()
        oSndTable = GetSenders()
        oSndRow = Nothing
        iCurrSnd = 0
        For Each oRow As TypeRightDataSet.sendersRow In oSndTable.Rows
            If oRow.senderid = _senderId Then
                oSndRow = oRow
                Exit For
            End If
            iCurrSnd += 1
        Next
        If oSndRow IsNot Nothing Then
            TxtId.Text = CStr(oSndRow.senderid)
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Function isValid() As Boolean
        Dim bMissingData As Boolean
        Dim sErrorMsg As String

        sErrorMsg = ""
        TxtForename.Text = StrConv(TxtForename.Text, vbProperCase)
        TxtSurname.Text = StrConv(TxtSurname.Text, vbProperCase)
        TxtAdd1.Text = StrConv(TxtAdd1.Text, vbProperCase)
        TxtAdd2.Text = StrConv(TxtAdd2.Text, vbProperCase)
        TxtCounty.Text = StrConv(TxtCounty.Text, vbProperCase)
        TxtTown.Text = StrConv(TxtTown.Text, vbProperCase)
        TxtPostCode.Text = StrConv(TxtPostCode.Text, vbUpperCase)

        bMissingData = False
        If String.IsNullOrEmpty(TxtForename.Text) Then
            sErrorMsg = "First name is mandatory"
            bMissingData = True
        End If
        If String.IsNullOrEmpty(TxtSurname.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Last name is mandatory"
            bMissingData = True
        End If
        If String.IsNullOrEmpty(TxtAdd1.Text = "") Then
            sErrorMsg = sErrorMsg & vbCrLf & "Address1 is mandatory"
            bMissingData = True
        End If
        If String.IsNullOrEmpty(TxtTown.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Town is mandatory"
            bMissingData = True
        End If
        If String.IsNullOrEmpty(TxtPostCode.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Postcode is mandatory"
            bMissingData = True
        End If

        If String.IsNullOrEmpty(TxtEmail.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Email is mandatory"
            bMissingData = True
        Else
            If Not (TxtEmail.Text Like "?*[@]?*[.]?*") Then
                sErrorMsg = sErrorMsg & vbCrLf & "Email: Invalid format"
                bMissingData = True
            End If
        End If
        'If Not (IsCharMatch(TxtPhone.Text, "[- 0-9]")) Then
        '    sErrorMsg = sErrorMsg & vbCrLf & "Phone: Invalid format"
        '    bMissingData = True
        'End If
        'If Not (IsCharMatch(TxtMobile.Text, "[- 0-9]")) Then
        '    sErrorMsg = sErrorMsg & vbCrLf & "Mobile: Invalid format"
        '    bMissingData = True
        'End If
        If bMissingData = True Then
            MsgBox(sErrorMsg, vbExclamation)
        End If
        Return bMissingData

    End Function

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        InsertSender(StoreSenderValues())
        LoadSenderTable()
    End Sub

    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        UpdateSender(StoreSenderValues())
        LoadSenderTable()
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If Not String.IsNullOrEmpty(TxtId.Text) Then
            DeleteSender(CInt(TxtId.Text))
        End If
        Display_Sender()
        SetAllowUpdate()

    End Sub

    Private Sub BtnTop_Click(sender As Object, e As EventArgs) Handles BtnTop.Click
        If oSndTable.Rows.Count > 0 Then
            iCurrSnd = 0
            oSndRow = oSndTable.Rows(iCurrSnd)
            TxtId.Text = CStr(oSndRow.senderid)
        End If
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        If oSndTable.Rows.Count > 0 AndAlso iCurrSnd > 0 Then
            iCurrSnd -= 1
            oSndRow = oSndTable.Rows(iCurrSnd)
            TxtId.Text = CStr(oSndRow.senderid)
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click

        If oSndTable.Rows.Count > 0 AndAlso iCurrSnd < (oSndTable.Rows.Count - 1) Then
            iCurrSnd += 1
            oSndRow = oSndTable.Rows(iCurrSnd)
            TxtId.Text = CStr(oSndRow.senderid)
        End If
    End Sub

    Private Sub BtnEnd_Click(sender As Object, e As EventArgs) Handles BtnEnd.Click
        If oSndTable.Rows.Count > 0 Then
            iCurrSnd = oSndTable.Rows.Count - 1
            oSndRow = oSndTable.Rows(iCurrSnd)
            TxtId.Text = CStr(oSndRow.senderid)
        End If
    End Sub

    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Me.Close()
    End Sub

    Private Sub MnuBkUpDatabase_Click(sender As Object, e As EventArgs) Handles MnuBkUpDatabase.Click
        dataBackupSenders()
    End Sub

    Private Sub MnuBkUpButtons_Click(sender As Object, e As EventArgs) Handles MnuBkUpButtons.Click
        dataBackupButtons()
    End Sub

    Private Sub MnuBkUpGroups_Click(sender As Object, e As EventArgs) Handles MnuBkUpGroups.Click
        dataBackupGroups()
    End Sub

    Private Sub MnuBkUpAll_Click(sender As Object, e As EventArgs) Handles MnuBkUpAll.Click
        dataBackupButtons()
        dataBackupGroups()
        dataBackupSenders()
    End Sub

    Private Sub MnuRestDatabase_Click(sender As Object, e As EventArgs) Handles MnuRestDatabase.Click
    End Sub

    Private Sub MnuRestButtons_Click(sender As Object, e As EventArgs) Handles MnuRestButtons.Click

    End Sub

    Private Sub MnuRestGroups_Click(sender As Object, e As EventArgs) Handles MnuRestGroups.Click
    End Sub

    Private Sub MnuRestAll_Click(sender As Object, e As EventArgs) Handles MnuRestAll.Click

    End Sub
#End Region
#Region "subroutines"
    Private Sub frmEnable(bState As Boolean)
        TxtForename.Enabled = bState
        TxtSurname.Enabled = bState
        txtHouseNo.Enabled = bState
        TxtAdd1.Enabled = bState
        TxtAdd2.Enabled = bState
        TxtTown.Enabled = bState
        TxtCounty.Enabled = bState
        TxtCountry.Enabled = bState
        TxtPhone.Enabled = bState
        TxtEmail.Enabled = bState
        DtpDob.Enabled = bState
        TxtPostCode.Enabled = bState
        TxtMobile.Enabled = bState
        TxtPassword.Enabled = bState
        CbTitle.Enabled = bState
        CbGender.Enabled = bState
        CbMarStat.Enabled = bState
        CbOcc.Enabled = bState
        TxtSWord.Enabled = bState
        TxtUsername.Enabled = bState
    End Sub
    Private Sub Display_Sender()
        isLoadingForm = True

        Dim IntAge As Integer

        With oSndRow
            ClearForm()
            TxtId.Text = CStr(.senderid)
            TxtForename.Text = .firstname
            TxtSurname.Text = .lastname

            If Not .IshousenumberNull Then
                txtHouseNo.Text = .housenumber
            End If
            If Not .IsstreetNull Then
                TxtAdd1.Text = .street
            End If
            If Not .Isaddress2Null Then
                TxtAdd2.Text = .address2
            End If
            If Not .IstownNull Then
                TxtTown.Text = .town
            End If
            If .IscountyNull Then
                TxtCounty.Text = .county
            End If
            If Not .IscountryNull Then
                TxtCountry.Text = .country
            End If
            If Not .IsphoneNull Then
                TxtPhone.Text = .phone
            End If
            If Not .IsemailNull Then
                TxtEmail.Text = .email
            End If
            If Not .IsdobNull Then
                DtpDob.Value = .dob
                IntAge = calc_age(.dob)
                TxtAge.Text = Format(IntAge)
            End If
            If Not .IspostcodeNull Then
                TxtPostCode.Text = .postcode
            End If
            If Not .IsmobileNull Then
                TxtMobile.Text = .mobile
            End If
            If Not .IspasswdNull Then
                TxtPassword.Text = If(String.IsNullOrEmpty(.passwd), "", oNCrypter.DecryptData(.passwd))
            End If
            If Not .IssecretwordNull Then
                TxtSWord.Text = If(String.IsNullOrEmpty(.secretword), "", oNCrypter.DecryptData(.secretword))
            End If
            If Not .username Then
                TxtUsername.Text = .username
            End If

            If Not .IstitleNull Then
                CbTitle.SelectedIndex = CbTitle.FindString(.title)
            End If

            If Not .IsgenderNull Then
                CbGender.SelectedIndex = CbGender.FindString(.gender)
            End If

            If Not .IsoccupationNull Then
                CbOcc.SelectedIndex = CbOcc.FindString(.occupation)
            End If

            If Not .IsmaritalstatusNull Then
                CbMarStat.SelectedIndex = CbMarStat.FindString(.maritalstatus)
            End If

        End With
        isLoadingForm = False
    End Sub
    Private Sub SetAllowUpdate()
        If Not isPro And oSndTable.Rows.Count > 0 Then
            BtnAdd.Enabled = False
            BtnUpd.Enabled = False
            LblMsg.Text = "** Record Limit Reached **"
        Else
            BtnAdd.Enabled = True
            BtnUpd.Enabled = True
            LblMsg.Text = ""
        End If
    End Sub

    Public Function calc_age(dtDob) As Integer
        Dim age As Integer
        age = Today.Year - Year(dtDob)
        If (dtDob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    Private Sub ClearForm()
        CbTitle.SelectedIndex = -1
        CbGender.SelectedIndex = -1
        CbMarStat.SelectedIndex = -1
        CbOcc.SelectedIndex = -1
        TxtForename.Text = ""
        TxtSurname.Text = ""
        TxtAdd1.Text = ""
        TxtAdd2.Text = ""
        TxtTown.Text = ""
        TxtCounty.Text = ""
        TxtCountry.Text = ""
        TxtPhone.Text = ""
        TxtEmail.Text = ""
        TxtAge.Text = ""
        DtpDob.Value = New Date(Today.Ticks)
        TxtPostCode.Text = ""
        TxtMobile.Text = ""
        TxtPassword.Text = ""
        TxtId.Text = ""
        TxtSWord.Text = ""
        TxtUsername.Text = ""
    End Sub




    Private Function StoreSenderValues() As sender

        Return SenderBuilder.NewSender.StartingWith(CInt(TxtId.Text), TxtForename.Text,
                                                    TxtSurname.Text, TxtAdd2.Text,
                                                    TxtTown.Text, TxtCounty.Text,
                                                    TxtPostCode.Text, DtpDob.Value,
                                                    CbTitle.SelectedItem,
                                                    txtHouseNo.Text, TxtAdd1.Text,
                                                    TxtCountry.Text, TxtEmail.Text,
                                                    TxtPhone.Text, TxtMobile.Text,
                                                    oNCrypter.EncryptData(TxtPassword.Text),
                                                    oNCrypter.EncryptData(TxtSWord.Text),
                                                    CbGender.SelectedItem, CbOcc.SelectedItem,
                                                    CbMarStat.SelectedItem, TxtUsername.Text).Build

    End Function
    Private Sub dataBackupButtons()
        oBtnTable = GetButtons()
        Dim sTableName As String = oBtnTable.TableName
        Dim sDbFullPath As String = My.Settings.BackupFolder
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".csv")
        Using _backupFile As New StreamWriter(sBackupFile, False)
            For Each oRow As TypeRight.TypeRightDataSet.buttonRow In oBtnTable.Rows
                Dim sb As New StringBuilder()
                For Each oCol In oBtnTable.Columns
                    sb.Append(CStr(oRow(oCol.index).value)).Append(",")
                Next
                _backupFile.WriteLine(sb.ToString)
            Next
        End Using

    End Sub
    Private Sub dataBackupGroups()
        oGrpTable = GetButtonGroups()
        Dim sTableName As String = oGrpTable.TableName
        Dim sDbFullPath As String = My.Settings.BackupFolder
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".csv")
        Using _backupFile As New StreamWriter(sBackupFile, False)
            For Each oRow As TypeRight.TypeRightDataSet.buttongroupsRow In oGrpTable.Rows
                Dim sb As New StringBuilder()
                For Each oCol In oGrpTable.Columns
                    sb.Append(CStr(oRow(oCol.index).value)).Append(",")
                Next
                _backupFile.WriteLine(sb.ToString)
            Next
        End Using

    End Sub

    Private Sub dataBackupSenders()
        oSndrTable = GetSenders()
        Dim sTableName As String = oSndrTable.TableName
        Dim sDbFullPath As String = My.Settings.BackupFolder
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".csv")
        Using _backupFile As New StreamWriter(sBackupFile, False)
            For Each oRow As TypeRight.TypeRightDataSet.sendersRow In oSndrTable.Rows
                Dim sb As New StringBuilder()
                For Each oCol In oSndrTable.Columns
                    sb.Append(CStr(oRow(oCol.index).value)).Append(",")
                Next
                _backupFile.WriteLine(sb.ToString)
            Next
        End Using

    End Sub


    Private Sub FrmDbUpdate_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.DBUpdatePos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TxtId.Text = -1
        ClearForm()
    End Sub

    Private Sub TxtId_TextChanged(sender As Object, e As EventArgs) Handles TxtId.TextChanged
        If Not isLoadingForm Then
            If CInt(TxtId.Text) > -1 Then
                Display_Sender()
            End If
        End If
    End Sub
#End Region
End Class