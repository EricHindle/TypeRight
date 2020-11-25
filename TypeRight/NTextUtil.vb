Imports System.Windows.Forms

Public Class NTextUtil
    Public Shared Function ConvertSelectedTextToLowercase(ByRef _control As Object) As String
        Dim oText As String = ""
        If TypeOf (_control) Is TextBox Or TypeOf (_control) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(_control, TextBoxBase)
            oText = _textBox.SelectedText.ToLower(myCultureInfo)
            _textBox.SelectedText = oText
        End If
        Return oText
    End Function

    Public Shared Function ConvertSelectedTextToUpperCase(ByRef _control As Object) As String
        Dim oText As String = ""
        If TypeOf (_control) Is TextBox Or TypeOf (_control) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(_control, TextBoxBase)
            oText = _textBox.SelectedText.ToUpper(myCultureInfo)
            _textBox.SelectedText = oText
        End If
        Return oText
    End Function

    Public Shared Function ConvertSelectedTextToTitleCase(ByRef _control As Object) As String
        Dim oText As String = ""
        If TypeOf (_control) Is TextBox Or TypeOf (_control) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(_control, TextBoxBase)
            oText = StrConv(_textBox.SelectedText, VbStrConv.ProperCase)
            _textBox.SelectedText = oText
        End If
        Return oText
    End Function

    Public shared Function ToggleCase(ByRef textBoxControl As Object) As String
        Dim oTextBox As TextBox = TryCast(textBoxControl, TextBox)
        Dim oText As String
        If oTextBox IsNot Nothing Then
            oText = ToggleText(oTextBox.SelectedText)
        Else
            Dim oRichTextBox As RichTextBox = TryCast(textBoxControl, RichTextBox)
            If oRichTextBox IsNot Nothing Then
                oText = ToggleText(oRichTextBox.SelectedText)
            Else
                oText = ""
            End If
        End If
        Return oText
    End Function

    Public Shared Function ToggleText(pString As String) As String
        Dim strText As String
        Dim strNewText As String
        strText = pString
        strNewText = ""
        For Each strChar As Char In strText
            If strChar = CStr(strChar).ToUpper Then
                strNewText &= CStr(strChar).ToLower
            Else
                strNewText &= CStr(strChar).ToUpper
            End If
        Next
        Return strNewText
    End Function

    Public Shared Sub SelectAll(ByRef textBoxControl As Object)
        If TypeOf textBoxControl Is TextBox Then
            textBoxControl.SelStart = 0
            textBoxControl.SelLength = Len(textBoxControl.Text)
        ElseIf TypeOf textBoxControl Is RichTextBox Then
            textBoxControl.SelStart = 0
            textBoxControl.SelLength = Len(textBoxControl.Text)
        Else
            ' No action makes sense for the other controls.
        End If
    End Sub

    Public Shared Function DeleteText(ByRef textBoxControl As Object) As String
        textBoxControl.SelectedText = ""

        Return textBoxControl
    End Function

    Public Shared Sub CopyToClipboard(ByRef ActiveControl As Object)
        Clipboard.Clear()

        If TypeOf ActiveControl Is TextBox Then
            Clipboard.SetText(ActiveControl.SelText)
        ElseIf TypeOf ActiveControl Is RichTextBox Then
            Clipboard.SetText(ActiveControl.SelText)
        ElseIf TypeOf ActiveControl Is ComboBox Then
            Clipboard.SetText(ActiveControl.Text)
        ElseIf TypeOf ActiveControl Is PictureBox Then
            Clipboard.SetData(DataFormats.Bitmap, ActiveControl.Picture)
        ElseIf TypeOf ActiveControl Is ListBox Then
            Clipboard.SetText(ActiveControl.Text)
        Else
            ' No action makes sense for the other controls.
        End If
    End Sub

    'Public Sub CutToClipboard(ByRef ActiveControl As Object)
    '    ' Copy and clear contents of active control.
    '    If TypeOf ActiveControl Is TextBox Then
    '        Clipboard.SetText(ActiveControl.SelText)
    '        ActiveControl.SelText = ""
    '    ElseIf TypeOf ActiveControl Is RichTextBox Then
    '        Clipboard.SetText(ActiveControl.SelText)
    '        ActiveControl.SelText = ""
    '    ElseIf TypeOf ActiveControl Is ComboBox Then
    '        Clipboard.SetText(ActiveControl.Text)
    '        ActiveControl.Text = ""
    '    ElseIf TypeOf ActiveControl Is PictureBox Then
    '        Clipboard.SetData(ActiveControl.Picture)
    '        ActiveControl.Picture = LoadPicture()
    '    ElseIf TypeOf Screen.ActiveControl Is ListBox Then
    '        Clipboard.SetText(ActiveControl.Text)
    '        ActiveControl.RemoveItem(Screen.ActiveControl.ListIndex)
    '    Else
    '        ' No action makes sense for the other controls.
    '    End If
    'End Sub

    Public Sub PasteFromClipboard(ByRef ActiveControl As Object)
        If TypeOf ActiveControl Is TextBox Then
            ActiveControl.SelText = Clipboard.GetText()
        ElseIf TypeOf ActiveControl Is RichTextBox Then
            ActiveControl.SelText = Clipboard.GetText()
        ElseIf TypeOf ActiveControl Is ComboBox Then
            ActiveControl.Text = Clipboard.GetText()
        ElseIf TypeOf ActiveControl Is PictureBox Then
            ActiveControl.Picture = Clipboard.GetData(DataFormats.Bitmap)
        ElseIf TypeOf ActiveControl Is ListBox Then
            ActiveControl.AddItem(Clipboard.GetText())
        Else
            ' No action makes sense for the other controls.
        End If
    End Sub

    Public Function UpperCase(ByRef textBoxControl As Object) As String
        If TypeOf textBoxControl Is TextBox Then
            textBoxControl.SelText = UCase(textBoxControl.SelText)
        ElseIf TypeOf textBoxControl Is RichTextBox Then
            textBoxControl.SelText = UCase(textBoxControl.SelText)
        Else
            ' No action makes sense for the other controls.
        End If
        UpperCase = textBoxControl.SelText
    End Function


End Class
