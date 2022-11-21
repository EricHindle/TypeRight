Imports System.Data
Imports System.IO
Imports System.Windows.Forms

Public Class FrmDbUpdate
#Region "constants"
    Private Const COMPLETE As String = " - complete"
    Private Const INSERT_NEW_SENDER As String = "Inserting new sender"
    Private Const UPDATE_SENDER As String = "Updating sender"
    Private Const DELETE_SENDER As String = "Deleting sender"
    Private Const FULL_BACKUP As String = "Full backup"
    Private Const FULL_RESTORE As String = "Full restore"
    Private Const LIMIT_REACHED As String = "** Record Limit Reached **"
    Private Const BKUP_GRP_BUTTONS As String = "Backing up group buttons"
    Private Const REST_GRP_BUTTONS As String = "Restoring group buttons"
    Private Const BKUP_GROUPS As String = "Backing up groups"
    Private Const REST_GROUPS As String = "Restoring groups"
    Private Const BKUP_SNDR_BUTTONS As String = "Backing up sender buttons"
    Private Const REST_SNDR_BUTTONS As String = "Restoring sender buttons"
    Private Const BKUP_SENDERS As String = "Backing up senders"
    Private Const REST_SENDERS As String = "Restoring senders"
    Private Const LOADING_FROM As String = "Loading from "
    Private Const UNSAVED_CHANGES_WARNING As String = "There are unsaved changes. Do you wish to continue (changes will be lost)?"
#End Region
#Region "variables"
    Private ReadOnly bAdd As Boolean
    Private iCurrSnd As Integer
    Private ReadOnly sDbFullPath As String
    Private isLoadingForm As Boolean = False
    Private isDataChanged As Boolean
#End Region
#Region "database"
    Dim oSndTable As New TypeRight.TypeRightDataSet.sendersDataTable
    ReadOnly oBtnTable As New TypeRight.TypeRightDataSet.buttonDataTable
    ReadOnly oSndrTable As New TypeRight.TypeRightDataSet.sendersDataTable
    ReadOnly oSndrBtnTable As New TypeRight.TypeRightDataSet.senderButtonDataTable
    ReadOnly oGrpTable As New TypeRight.TypeRightDataSet.buttongroupsDataTable
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
        LogUtil.Info(My.Resources.LOADING, MyBase.Name)
        GetFormPos(Me, My.Settings.DBUpdatePos)
        LoadSenderTable()
        isDataChanged = False
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub FrmDbUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
        My.Settings.DBUpdatePos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        If isDataChanged = False OrElse
            MsgBox(UNSAVED_CHANGES_WARNING,
                    MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If IsValid() Then
            DisplayProgress(INSERT_NEW_SENDER)
            InsertSender(StoreSenderValues())
            isDataChanged = False
            LoadSenderTable()
            DisplayProgress(INSERT_NEW_SENDER & COMPLETE)
        End If
    End Sub
    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        If IsValid() Then
            DisplayProgress(UPDATE_SENDER)
            UpdateSender(StoreSenderValues())
            isDataChanged = False
            LoadSenderTable()
            DisplayProgress(UPDATE_SENDER & COMPLETE)
        End If
    End Sub
    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If Not String.IsNullOrEmpty(TxtId.Text) Then
            DisplayProgress(DELETE_SENDER)
            DeleteSender(CInt(TxtId.Text))
            isDataChanged = False
            LoadSenderTable()
            DisplayProgress(DELETE_SENDER & COMPLETE)
            ShowRecord(0, "first")
        End If
    End Sub
    Private Sub BtnTop_Click(sender As Object, e As EventArgs) Handles BtnTop.Click
        ShowRecord(0, "first")
    End Sub
    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        If iCurrSnd > 0 Then
            ShowRecord(iCurrSnd - 1, "previous")
        End If
    End Sub
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If oSndTable.Rows.Count > 0 AndAlso iCurrSnd < (oSndTable.Rows.Count - 1) Then
            ShowRecord(iCurrSnd + 1, "next")
        End If
    End Sub
    Private Sub BtnEnd_Click(sender As Object, e As EventArgs) Handles BtnEnd.Click
        If oSndTable.Rows.Count > 0 Then
            ShowRecord(oSndTable.Rows.Count - 1, "last")
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TxtId.Text = -1
    End Sub
    Private Sub TxtId_TextChanged(sender As Object, e As EventArgs) Handles TxtId.TextChanged
        If Not isLoadingForm Then
            If isDataChanged Then
                If MsgBox(TypeRight.FrmDbUpdate.UNSAVED_CHANGES_WARNING, MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    isLoadingForm = True
                    TxtId.Text = LblId.Text
                    isLoadingForm = False
                    Exit Sub
                End If
            End If
            If IsNumeric(TxtId.Text) Then
                isLoadingForm = True
                If CInt(TxtId.Text) > -1 Then
                    Display_Sender()
                Else
                    ClearForm()
                End If
                isLoadingForm = False
            Else
                Exit Sub
            End If
            isDataChanged = False
        End If

    End Sub
    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Me.Close()
    End Sub
    Private Sub MnuBkUpDatabase_Click(sender As Object, e As EventArgs) Handles MnuBkUpSenders.Click
        DataBackupSenders()
    End Sub
    Private Sub MnuBkUpButtons_Click(sender As Object, e As EventArgs) Handles MnuBkUpButtons.Click
        DataBackupButtons()
    End Sub
    Private Sub MnuBkUpGroups_Click(sender As Object, e As EventArgs) Handles MnuBkUpGroups.Click
        DataBackupGroups()
    End Sub
    Private Sub MnuBkUpSenderButtons_Click(sender As Object, e As EventArgs) Handles MnuBkUpSenderButtons.Click
        DataBackupSenderButtons()
    End Sub
    Private Sub MnuBkUpAll_Click(sender As Object, e As EventArgs) Handles MnuBkUpAll.Click
        DisplayProgress(FULL_BACKUP)
        DataBackupButtons()
        DataBackupGroups()
        DataBackupSenders()
        DataBackupSenderButtons()
        DisplayProgress(FULL_BACKUP & COMPLETE)
    End Sub
    Private Sub MnuRestDatabase_Click(sender As Object, e As EventArgs) Handles MnuRestSenders.Click
        DataRestoreSenders()
    End Sub
    Private Sub MnuRestButtons_Click(sender As Object, e As EventArgs) Handles MnuRestButtons.Click
        DataRestoreButtons()
    End Sub
    Private Sub MnuRestGroups_Click(sender As Object, e As EventArgs) Handles MnuRestGroups.Click
        DataRestoreGroups()
    End Sub
    Private Sub MnuRestAll_Click(sender As Object, e As EventArgs) Handles MnuRestAll.Click
        DisplayProgress(FULL_RESTORE)
        DataRestoreGroups()
        DataRestoreButtons()
        DataRestoreSenders()
        DataRestoreSenderButtons()
        DisplayProgress(FULL_RESTORE & COMPLETE)
    End Sub
    Private Sub MnuRestSenderButtons_Click(sender As Object, e As EventArgs) Handles MnuRestSenderButtons.Click
        DataRestoreSenderButtons()
    End Sub
#End Region
#Region "subroutines"
    Private Sub LoadSenderTable()
        oSndTable = GetSenderTable()
        oSndRow = Nothing
        iCurrSnd = 0
        For Each oRow As TypeRightDataSet.sendersRow In oSndTable.Rows
            If oRow.SenderId = _senderId Then
                oSndRow = oRow
                Exit For
            End If
            iCurrSnd += 1
        Next
        If oSndRow IsNot Nothing Then
            LblId.Text = CStr(oSndRow.SenderId)
            TxtId.Text = CStr(oSndRow.SenderId)
        End If
    End Sub
    Private Function IsValid() As Boolean
        Dim isOK As Boolean
        Dim sErrorMsg As String
        sErrorMsg = ""
        TxtForename.Text = StrConv(TxtForename.Text, vbProperCase)
        TxtSurname.Text = StrConv(TxtSurname.Text, vbProperCase)
        TxtAdd1.Text = StrConv(TxtAdd1.Text, vbProperCase)
        TxtAdd2.Text = StrConv(TxtAdd2.Text, vbProperCase)
        TxtCounty.Text = StrConv(TxtCounty.Text, vbProperCase)
        TxtTown.Text = StrConv(TxtTown.Text, vbProperCase)
        TxtPostCode.Text = StrConv(TxtPostCode.Text, vbUpperCase)
        isOK = True
        If String.IsNullOrEmpty(TxtForename.Text) Then
            sErrorMsg = "First name is mandatory"
            isOK = False
        End If
        If String.IsNullOrEmpty(TxtSurname.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Last name is mandatory"
            isOK = False
        End If
        If String.IsNullOrEmpty(TxtAdd1.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Address1 is mandatory"
            isOK = False
        End If
        If String.IsNullOrEmpty(TxtTown.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Town is mandatory"
            isOK = False
        End If
        If String.IsNullOrEmpty(TxtPostCode.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Postcode is mandatory"
            isOK = False
        End If
        If String.IsNullOrEmpty(TxtEmail.Text) Then
            sErrorMsg = sErrorMsg & vbCrLf & "Email is mandatory"
            isOK = False
        Else
            If Not (TxtEmail.Text Like "?*[@]?*[.]?*") Then
                sErrorMsg = sErrorMsg & vbCrLf & "Email: Invalid format"
                isOK = False
            End If
        End If
        If isOK = False Then
            MsgBox(sErrorMsg, vbExclamation)
        End If
        Return isOK
    End Function
    Private Sub Display_Sender()
        Dim IntAge As Integer
        With oSndRow
            ClearForm()
            TxtId.Text = CStr(.SenderId)
            LblId.Text = TxtId.Text
            CbTitle.SelectedIndex = If(.IsTitleNull, -1, CbTitle.FindString(.Title))
            TxtForename.Text = .FirstName
            TxtSurname.Text = .LastName
            If Not .IsAddress1Null Then
                TxtAdd1.Text = .Address1
            End If
            If Not .IsAddress2Null Then
                TxtAdd2.Text = .Address2
            End If
            If Not .IsTownNull Then
                TxtTown.Text = .Town
            End If
            If Not .IsCountyNull Then
                TxtCounty.Text = .County
            End If
            If Not .IsCountryNull Then
                TxtCountry.Text = .Country
            End If
            If Not .IsPhoneNull Then
                TxtPhone.Text = .Phone
            End If
            If Not .IsEmailNull Then
                TxtEmail.Text = .Email
            End If
            If Not .IsdobNull Then
                DtpDob.Value = .dob
                IntAge = Calc_age(.dob)
                TxtAge.Text = Format(IntAge)
            End If
            If Not .IsPostCodeNull Then
                TxtPostCode.Text = .PostCode
            End If
            If Not .IsMobileNull Then
                TxtMobile.Text = .Mobile
            End If
            If Not .IsPasswdNull Then
                TxtPassword.Text = If(String.IsNullOrEmpty(.Passwd), "", oNCrypter.DecryptData(.Passwd))
            End If
            If Not .IsSecretWordNull Then
                TxtSWord.Text = If(String.IsNullOrEmpty(.SecretWord), "", oNCrypter.DecryptData(.SecretWord))
            End If
            If Not .IsUsernameNull Then
                TxtUsername.Text = .Username
            End If
            If Not .IsgenderNull Then
                CbGender.SelectedIndex = CbGender.FindString(.gender)
            End If
            If Not .IsOccupationNull Then
                CbOcc.SelectedIndex = CbOcc.FindString(.Occupation)
            End If
            If Not .IsMaritalStatusNull Then
                CbMarStat.SelectedIndex = CbMarStat.FindString(.MaritalStatus)
            End If
        End With
    End Sub
    Private Sub SetAllowUpdate()
        If Not isPro And oSndTable.Rows.Count > 0 Then
            BtnAdd.Enabled = False
            BtnUpd.Enabled = False
            DisplayProgress(LIMIT_REACHED)
        Else
            BtnAdd.Enabled = True
            BtnUpd.Enabled = True
            DisplayProgress(String.Empty)
        End If
    End Sub
    Public Shared Function Calc_age(dtDob) As Integer
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
        LblId.Text = ""
        TxtSWord.Text = ""
        TxtUsername.Text = ""
    End Sub
    Private Function StoreSenderValues() As Sender
        Dim senderId As Integer = If(IsNumeric(TxtId.Text), CInt(TxtId.Text), -1)
        Return SenderBuilder.NewSender.StartingWith(senderId, TxtForename.Text,
                                                    TxtSurname.Text, TxtAdd2.Text,
                                                    TxtTown.Text, TxtCounty.Text,
                                                    TxtPostCode.Text, DtpDob.Value,
                                                    CbTitle.SelectedItem,
                                                    TxtAdd1.Text,
                                                    TxtCountry.Text, TxtEmail.Text,
                                                    TxtPhone.Text, TxtMobile.Text,
                                                    oNCrypter.EncryptData(TxtPassword.Text),
                                                    oNCrypter.EncryptData(TxtSWord.Text),
                                                    CbGender.SelectedItem, CbOcc.SelectedItem,
                                                    CbMarStat.SelectedItem, TxtUsername.Text).Build

    End Function
    Private Sub DataBackupButtons()
        DisplayProgress(BKUP_GRP_BUTTONS)
        BackupTable(GetButtonTable())
        DisplayProgress(BKUP_GRP_BUTTONS & COMPLETE)
    End Sub
    Private Sub DataRestoreButtons()
        DisplayProgress(REST_GRP_BUTTONS)
        RestoreTable(oBtnTable)
        For Each oRow As TypeRightDataSet.buttonRow In oBtnTable.Rows
            If GetButtonById(oRow.buttonId) Is Nothing Then
                InsertButton(oRow.buttonGroup, oRow.buttonSeq,
                             oRow.buttonText, oRow.buttonHint,
                             oRow.buttonValue, oRow.buttonFont,
                             oRow.buttonBold, oRow.buttonFontSize,
                             oRow.buttonItalic, oRow.buttonEncrypt)
            Else
                UpdateButton(oRow.buttonGroup, oRow.buttonSeq,
                             oRow.buttonText, oRow.buttonHint,
                             oRow.buttonValue, oRow.buttonFont,
                             oRow.buttonBold, oRow.buttonFontSize,
                             oRow.buttonItalic, oRow.buttonEncrypt, oRow.buttonId)
            End If
        Next
        DisplayProgress(REST_GRP_BUTTONS & COMPLETE)
    End Sub
    Private Sub DataBackupGroups()
        DisplayProgress(BKUP_GROUPS)
        BackupTable(GetButtonGroupTable())
        DisplayProgress(BKUP_GROUPS & COMPLETE)
    End Sub
    Private Sub DataRestoreGroups()
        DisplayProgress(REST_GROUPS)
        RestoreTable(oGrpTable)
        For Each oRow As TypeRightDataSet.buttongroupsRow In oGrpTable.Rows
            If GetButtonGroup(oRow.buttongroupid) Is Nothing Then
                InsertButtonGroup(oRow.groupname)
            Else
                UpdateButtonGroupName(oRow.groupname, oRow.buttongroupid)
            End If
        Next
        DisplayProgress(REST_GROUPS & COMPLETE)
    End Sub
    Private Sub DataBackupSenders()
        DisplayProgress(BKUP_SENDERS)
        BackupTable(GetSenderTable())
        DisplayProgress(BKUP_SENDERS & COMPLETE)
    End Sub
    Private Sub DataRestoreSenders()
        DisplayProgress(REST_SENDERS)
        RestoreTable(oSndTable)
        For Each oRow As TypeRightDataSet.sendersRow In oSndTable.Rows
            Dim oRestoredSender As Sender = SenderBuilder.NewSender().StartingWith(oRow).Build
            If GetSenderRowById(oRow.SenderId) Is Nothing Then
                InsertSender(oRestoredSender)
            Else
                UpdateSender(oRestoredSender)
            End If
        Next
        DisplayProgress(REST_SENDERS & COMPLETE)
    End Sub
    Private Sub DataBackupSenderButtons()
        DisplayProgress(BKUP_SNDR_BUTTONS)
        BackupTable(GetSenderButtonTable())
        DisplayProgress(BKUP_SNDR_BUTTONS & COMPLETE)
    End Sub
    Private Sub DataRestoreSenderButtons()
        DisplayProgress(REST_SNDR_BUTTONS)
        RestoreTable(oSndrBtnTable)
        For Each oRow As TypeRightDataSet.senderButtonRow In oSndrBtnTable.Rows
            If GetSenderButton(oRow.ColumnName) Is Nothing Then
                InsertSenderButton(oRow.ColumnName, oRow.buttonFontName, oRow.buttonFontSize, oRow.buttonItalic, oRow.buttonBold, oRow.buttonEncrypted)
            Else
                UpdateSenderButton(oRow.ColumnName, oRow.buttonFontName, oRow.buttonFontSize, oRow.buttonItalic, oRow.buttonBold, oRow.buttonEncrypted)
            End If
        Next
        DisplayProgress(REST_SNDR_BUTTONS & COMPLETE)
    End Sub
    Private Sub BackupTable(backupDataTable As DataTable)
        Dim sTableName As String = backupDataTable.TableName
        Dim sDbFullPath As String = GetBackupFolder(True)
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        DisplayProgress("Writing " & sBackupFile)
        backupDataTable.WriteXml(sBackupFile)
        DisplayProgress("Writing " & sBackupFile & COMPLETE)
    End Sub
    Private Sub RestoreTable(ByRef restoreDataTable As DataTable)
        restoreDataTable.Rows.Clear()
        Dim sTableName As String = restoreDataTable.TableName
        Dim sDbFullPath As String = GetBackupFolder(False)
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".xml")
        If My.Computer.FileSystem.FileExists(sBackupFile) Then
            DisplayProgress(LOADING_FROM & sBackupFile)
            restoreDataTable.ReadXml(sBackupFile)
            DisplayProgress(LOADING_FROM & sBackupFile & COMPLETE)
        Else
            DisplayProgress("Backup file " & sBackupFile & " missing. Table NOT restored")
        End If
    End Sub
    Private Function GetBackupFolder(isCreateOnMissing As Boolean) As String
        Dim sFolder As String = My.Settings.BackupFolder
        If isCreateOnMissing AndAlso Not My.Computer.FileSystem.DirectoryExists(sFolder) Then
            LogUtil.Info("Creating folder " & sFolder, MyBase.Name)
            My.Computer.FileSystem.CreateDirectory(sFolder)
        End If
        Return sFolder
    End Function
    Private Sub ShowRecord(iRecord As Integer, sText As String)
        If oSndTable.Rows.Count >= iRecord Then
            LogUtil.Info("Go to " & sText & " record", MyBase.Name)
            iCurrSnd = iRecord
            oSndRow = oSndTable.Rows(iCurrSnd)
            TxtId.Text = CStr(oSndRow.SenderId)
        End If
    End Sub
    Private Sub DataChanged(sender As Object, e As EventArgs) Handles CbTitle.SelectedIndexChanged,
                                                                        TxtAdd1.TextChanged,
                                                                        TxtAdd2.TextChanged,
                                                                        TxtCountry.TextChanged,
                                                                        TxtCounty.TextChanged,
                                                                        TxtPostCode.TextChanged,
                                                                        TxtEmail.TextChanged,
                                                                        TxtForename.TextChanged,
                                                                        TxtMobile.TextChanged,
                                                                        TxtPassword.TextChanged,
                                                                        TxtPhone.TextChanged,
                                                                        TxtSurname.TextChanged,
                                                                        TxtSWord.TextChanged,
                                                                        TxtTown.TextChanged,
                                                                        TxtUsername.TextChanged,
                                                                        DtpDob.ValueChanged,
                                                                        CbGender.SelectedIndexChanged,
                                                                        CbMarStat.SelectedIndexChanged,
                                                                        CbOcc.SelectedIndexChanged
        isDataChanged = True
    End Sub
    Private Sub DisplayProgress(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = True)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(LblStatus.Text, MyBase.Name)
    End Sub

#End Region
End Class