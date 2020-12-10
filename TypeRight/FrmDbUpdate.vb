Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class FrmDbUpdate
#Region "variables"
    Private ReadOnly bAdd As Boolean
    Private iCurrSnd As Integer
    Private ReadOnly sDbFullPath As String
    Private isLoadingForm As Boolean = False
#End Region
#Region "database"
    Dim oSndTable As New TypeRight.TypeRightDataSet.sendersDataTable
    Dim oBtnTable As New TypeRight.TypeRightDataSet.buttonDataTable
    Dim oSndrTable As New TypeRight.TypeRightDataSet.sendersDataTable
    Dim oSndrBtnTable As New TypeRight.TypeRightDataSet.senderButtonDataTable
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
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If IsValid() Then
            ShowStatus("Inserting new sender", True)
            InsertSender(StoreSenderValues())
            LoadSenderTable()
            ShowStatus("Inserted new sender", True)
        End If
    End Sub

    Private Sub ShowStatus(sText As String, isLogged As Boolean)
        LblStatus.Text = sText
        If isLogged Then LogUtil.Info(sText, MyBase.Name)
    End Sub

    Private Sub BtnUpd_Click(sender As Object, e As EventArgs) Handles BtnUpd.Click
        If IsValid() Then
            ShowStatus("Updating sender", True)
            UpdateSender(StoreSenderValues())
            LoadSenderTable()
            ShowStatus("Updated sender", True)
        End If
    End Sub
    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If Not String.IsNullOrEmpty(TxtId.Text) Then
            ShowStatus("Deleting sender", True)
            DeleteSender(CInt(TxtId.Text))
            LoadSenderTable()
            ShowStatus("Deleted sender", True)
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
        ClearForm()
    End Sub
    Private Sub TxtId_TextChanged(sender As Object, e As EventArgs) Handles TxtId.TextChanged
        If Not isLoadingForm Then
            If CInt(TxtId.Text) > -1 Then
                Display_Sender()
            End If
        End If
    End Sub
    Private Sub MnuClose_Click(sender As Object, e As EventArgs) Handles MnuClose.Click
        Me.Close()
    End Sub
    Private Sub MnuBkUpDatabase_Click(sender As Object, e As EventArgs) Handles MnuBkUpDatabase.Click
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
        DataBackupButtons()
        DataBackupGroups()
        DataBackupSenders()
        DataBackupSenderButtons()
    End Sub
    Private Sub MnuRestDatabase_Click(sender As Object, e As EventArgs) Handles MnuRestDatabase.Click
    End Sub
    Private Sub MnuRestButtons_Click(sender As Object, e As EventArgs) Handles MnuRestButtons.Click
    End Sub
    Private Sub MnuRestGroups_Click(sender As Object, e As EventArgs) Handles MnuRestGroups.Click
    End Sub
    Private Sub MnuRestAll_Click(sender As Object, e As EventArgs) Handles MnuRestAll.Click
    End Sub
    Private Sub MnuRestSenderButtons_Click(sender As Object, e As EventArgs) Handles MnuRestSenderButtons.Click
    End Sub
#End Region
#Region "subroutines"
    Private Sub LoadSenderTable()
        oSndTable = GetSenders()
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
        isLoadingForm = True
        Dim IntAge As Integer
        With oSndRow
            ClearForm()
            TxtId.Text = CStr(.SenderId)
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
        isLoadingForm = False
    End Sub
    Private Sub SetAllowUpdate()
        If Not isPro And oSndTable.Rows.Count > 0 Then
            BtnAdd.Enabled = False
            BtnUpd.Enabled = False
            LblStatus.Text = "** Record Limit Reached **"
        Else
            BtnAdd.Enabled = True
            BtnUpd.Enabled = True
            LblStatus.Text = ""
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
        TxtSWord.Text = ""
        TxtUsername.Text = ""
    End Sub
    Private Function StoreSenderValues() As Sender
        Return SenderBuilder.NewSender.StartingWith(CInt(TxtId.Text), TxtForename.Text,
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
        LogUtil.Info("Backup buttons", MyBase.Name)
        oBtnTable = GetButtons()
        Dim sTableName As String = oBtnTable.TableName
        Dim sDbFullPath As String = GetBackupFolder()
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".csv")
        LogUtil.Info("Writing " & sBackupFile, MyBase.Name)
        Using _backupFile As New StreamWriter(sBackupFile, False)
            For Each oRow As TypeRight.TypeRightDataSet.buttonRow In oBtnTable.Rows
                Dim sb As New StringBuilder()
                For Each oCol As DataColumn In oBtnTable.Columns
                    sb.Append(CStr(oRow(oCol.ColumnName))).Append(",")
                Next
                _backupFile.WriteLine(sb.ToString)
            Next
        End Using
    End Sub
    Private Sub DataBackupGroups()
        LogUtil.Info("Backup groups", MyBase.Name)
        oGrpTable = GetButtonGroups()
        Dim sTableName As String = oGrpTable.TableName
        Dim sDbFullPath As String = GetBackupFolder()
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".csv")
        LogUtil.Info("Writing " & sBackupFile, MyBase.Name)
        Using _backupFile As New StreamWriter(sBackupFile, False)
            For Each oRow As TypeRight.TypeRightDataSet.buttongroupsRow In oGrpTable.Rows
                Dim sb As New StringBuilder()
                For Each oCol As DataColumn In oGrpTable.Columns
                    sb.Append(CStr(oRow(oCol.ColumnName))).Append(",")
                Next
                _backupFile.WriteLine(sb.ToString)
            Next
        End Using
    End Sub
    Private Sub DataBackupSenders()
        LogUtil.Info("Backup senders", MyBase.Name)
        oSndrTable = GetSenders()
        Dim sTableName As String = oSndrTable.TableName
        Dim sDbFullPath As String = GetBackupFolder()
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".csv")
        LogUtil.Info("Writing " & sBackupFile, MyBase.Name)
        Using _backupFile As New StreamWriter(sBackupFile, False)
            For Each oRow As TypeRight.TypeRightDataSet.sendersRow In oSndrTable.Rows
                Dim sb As New StringBuilder()
                For Each oCol As DataColumn In oSndrTable.Columns
                    sb.Append(CStr(oRow(oCol.ColumnName))).Append(",")
                Next
                _backupFile.WriteLine(sb.ToString)
            Next
        End Using
    End Sub
    Private Sub DataBackupSenderButtons()
        LogUtil.Info("Backup sender buttons", MyBase.Name)
        oSndrBtnTable = GetSenderButtons()
        Dim sTableName As String = oSndrBtnTable.TableName
        Dim sDbFullPath As String = GetBackupFolder()
        Dim sBackupFile As String = Path.Combine(sDbFullPath, sTableName & ".csv")
        LogUtil.Info("Writing " & sBackupFile, MyBase.Name)
        Using _backupFile As New StreamWriter(sBackupFile, False)
            For Each oRow As TypeRight.TypeRightDataSet.senderButtonRow In oSndrBtnTable.Rows
                Dim sb As New StringBuilder()
                For Each oCol As DataColumn In oSndrBtnTable.Columns
                    sb.Append(CStr(oRow(oCol.ColumnName))).Append(",")
                Next
                _backupFile.WriteLine(sb.ToString)
            Next
        End Using
    End Sub
    Private Sub FrmDbUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.DBUpdatePos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Function GetBackupFolder() As String
        Dim sFolder As String = My.Settings.BackupFolder
        If Not My.Computer.FileSystem.DirectoryExists(sFolder) Then
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
#End Region
End Class