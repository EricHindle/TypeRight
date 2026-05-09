' hindleware
' Copyright (c) 2022-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports HindlewareLib.Logging
Imports TypeRight.Domain
Imports TypeRight.TypeRightDataSet1
Public Class FrmSenderButtonFormat
#Region "database variables"
    Private ReadOnly oTable As New sendersDataTable
    Private oSenderButton As SenderButton
#End Region
#Region "properties"
    Private _startField As String
    Public Property StartField() As String
        Get
            Return _startField
        End Get
        Set(ByVal value As String)
            _startField = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub FrmSenderButtonMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info(My.Resources.LOADING, MyBase.Name)
        GetFormPos(Me, My.Settings.SndrBtnFormPos)
        For Each _col As DataColumn In oTable.Columns
            CbDbValue.Items.Add(_col.ColumnName)
        Next
        If String.IsNullOrEmpty(_startField) Then
            CbDbValue.SelectedIndex = -1
        Else
            CbDbValue.SelectedIndex = CbDbValue.FindString(_startField)
            If CbDbValue.SelectedIndex < 0 Then
                CbDbValue.Items.Add(_startField)
                CbDbValue.SelectedIndex = CbDbValue.Items.Count - 1
            End If
        End If
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub CbDbValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbDbValue.SelectedIndexChanged
        If CbDbValue.SelectedIndex >= 0 Then
            Dim _colName As String = CbDbValue.SelectedItem
            oSenderButton = GetSenderButton(_colName)
            If Not oSenderButton.IsEmpty Then
                Dim _style As Drawing.FontStyle = If(oSenderButton.Bold, FontStyle.Bold, FontStyle.Regular) Or If(oSenderButton.Italic, FontStyle.Italic, FontStyle.Regular)
                BtnFont.Font = New Drawing.Font(oSenderButton.FontName, oSenderButton.FontSize, _style)
                BtnFont.Text = oSenderButton.FontName & " (" & oSenderButton.FontSize & ")"
                chkEncrypted.Checked = oSenderButton.IsEncrypted
            End If
        Else
            ClearForm()
            oSenderButton = Nothing
        End If
    End Sub
    Private Sub BtnFont_Click(sender As Object, e As EventArgs) Handles BtnFont.Click
        LogUtil.Info("Selecting font", MyBase.Name)
        Dim dlogResult As DialogResult = DialogResult.Cancel
        With FontDialog1
            .FontMustExist = True
            .Font = MakeFont(sDfltFontName, iDfltFontSize, bDfltFontBold, bDfltFontItalic)
            dlogResult = .ShowDialog()
        End With
        With BtnFont
            If dlogResult = DialogResult.OK Then
                .Text = FontDialog1.Font.Name & " " & Format(FontDialog1.Font.Size)
                .Font = MakeFont(FontDialog1.Font.Name, FontDialog1.Font.Size, FontDialog1.Font.Bold, FontDialog1.Font.Italic)
                LogUtil.Info("Font selected", MyBase.Name)
            Else
                LogUtil.Info("Font not selected", MyBase.Name)
            End If
        End With
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If CbDbValue.SelectedIndex >= 0 Then
            Dim fontName As String = BtnFont.Font.Name
            Dim fontSize As Decimal = BtnFont.Font.Size
            Dim fontBold As Boolean = BtnFont.Font.Bold
            Dim fontItalic As Boolean = BtnFont.Font.Italic
            Dim isEncrypted As Boolean = chkEncrypted.Checked
            Dim oColumnName As String = CbDbValue.SelectedItem
            Dim oOldSenderButton As SenderButton = GetSenderButton(oColumnName)
            Dim oNewSenderbutton As SenderButton = SenderButtonBuilder.aSenderButton.StartingWith(oColumnName,
                                                                                           fontBold,
                                                                                           fontItalic,
                                                                                           fontName,
                                                                                           fontSize,
                                                                                           isEncrypted).Build
            If oOldSenderButton.IsEmpty Then
                LogUtil.Info("Inserting " & oColumnName, MyBase.Name)
                Dim isInserted As Boolean = InsertSenderButton(oNewSenderbutton)
                If isInserted Then
                    LogUtil.ShowStatus("Inserted OK", LblStatus)
                Else
                    LogUtil.ShowStatus("Insert failed", LblStatus)
                End If
            Else
                LogUtil.Info("Updating " & oColumnName, MyBase.Name)
                Dim isUpdated As Boolean = UpdateSenderButton(oNewSenderbutton)
                If isUpdated Then
                    LogUtil.ShowStatus("Updated OK", LblStatus)
                Else
                    LogUtil.ShowStatus("Update failed", LblStatus)
                End If
            End If
        End If
    End Sub
    Private Sub FrmSenderButtonMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.SndrBtnFormPos = SetFormPos(Me)
        My.Settings.Save()
        LogUtil.Info(My.Resources.CLOSING, MyBase.Name)
    End Sub
#End Region
#Region "subroutine"
    Private Sub ClearForm()
        Dim _style As Drawing.FontStyle = My.Settings.FontBold Or My.Settings.FontItalic
        BtnFont.Font = New Drawing.Font(My.Settings.FontName, My.Settings.FontSize, _style)
        BtnFont.Text = My.Settings.FontName & " (" & My.Settings.FontSize & ")"
        chkEncrypted.Checked = False
    End Sub
#End Region
End Class