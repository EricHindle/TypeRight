Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmSenderButtonFormat
    Private ReadOnly oTable As New TypeRightDataSet.sendersDataTable
    Private oRow As TypeRight.TypeRightDataSet.senderButtonRow
    Private _startField As String
    Public Property StartField() As String
        Get
            Return _startField
        End Get
        Set(ByVal value As String)
            _startField = value
        End Set
    End Property
    Private Sub FrmSenderButtonMaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.SndrBtnFormPos)
        For Each _col As DataColumn In oTable.Columns
            CbDbValue.Items.Add(_col.ColumnName)
        Next
        If String.IsNullOrEmpty(_startField) Then
            CbDbValue.SelectedIndex = -1
        Else
            CbDbValue.SelectedIndex = CbDbValue.FindString(_startField)
        End If

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub CbDbValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbDbValue.SelectedIndexChanged
        If CbDbValue.SelectedIndex >= 0 Then
            Dim _colName As String = CbDbValue.SelectedItem
            oRow = GetSenderButton(_colName)
            If oRow IsNot Nothing Then
                Dim _style As Drawing.FontStyle
                _style = If(CBool(oRow.buttonBold), FontStyle.Bold, FontStyle.Regular) Or If(CBool(oRow.buttonItalic), FontStyle.Italic, FontStyle.Regular)
                BtnFont.Font = New Drawing.Font(oRow.buttonFontName, oRow.buttonFontSize, _style)
                BtnFont.Text = oRow.buttonFontName & " (" & oRow.buttonFontSize & ")"
                chkEncrypted.Checked = CBool(oRow.buttonEncrypted)
            End If
        Else
            oRow = Nothing
        End If
    End Sub

    Private Sub BtnFont_Click(sender As Object, e As EventArgs) Handles BtnFont.Click
        With FontDialog1
            .FontMustExist = True
            .Font = BtnFont.Font
            .ShowDialog()
        End With
        With BtnFont
            .Font = FontDialog1.Font
            .Text = .Font.Name & "(" & CStr(.Font.Size) & ")"
        End With
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim fontName As String = BtnFont.Font.Name
        Dim fontSize As Decimal = BtnFont.Font.Size
        Dim fontBold As Boolean = BtnFont.Font.Bold
        Dim fontItalic As Boolean = BtnFont.Font.Italic
        Dim isEncrypted As Boolean = chkEncrypted.Checked
        If oRow IsNot Nothing Then
            LogUtil.Info("Updating " & CbDbValue.SelectedItem, MyBase.Name)
            UpdateSenderButton(CbDbValue.SelectedItem, fontName, fontSize, fontItalic, fontBold, isEncrypted)
        Else
            LogUtil.Info("Inserting " & CbDbValue.SelectedItem, MyBase.Name)
            InsertSenderButton(CbDbValue.SelectedItem, fontName, fontSize, fontItalic, fontBold, isEncrypted)
        End If
    End Sub

    Private Sub FrmSenderButtonMaint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.SndrBtnFormPos = SetFormPos(Me)
        My.Settings.Save()
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
End Class