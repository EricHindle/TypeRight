Public Class NButtonBuilder
    Private _Id As Integer
    Private _Group As Integer
    Private _Sequence As Integer
    Private _Text As String
    Private _Hint As String
    Private _Value As String
    Private _FontName As String
    Private _FontSize As Integer
    Private _FontBold As Boolean
    Private _FontItalic As Boolean
    Private _Encrypt As Boolean
    Private _Source As Nbutton.DataSource
    Private ReadOnly oBtnTa As New TypeRightDataSetTableAdapters.buttonTableAdapter
    Private ReadOnly oBtnTable As New TypeRightDataSet.buttonDataTable
    Public Shared Function NewButton() As NButtonBuilder
        Return New NButtonBuilder
    End Function
    Public Function StartingWith(ByVal oNButton As Nbutton) As NButtonBuilder
        _Id = oNButton.Id
        _Group = oNButton.Group
        _Sequence = oNButton.Sequence
        _Text = oNButton.Caption
        _Hint = oNButton.Hint
        _Value = oNButton.Value
        _FontName = oNButton.FontName
        _FontSize = oNButton.FontSize
        _FontBold = oNButton.FontBold
        _FontItalic = oNButton.FontItalic
        _Encrypt = oNButton.Encrypt
        _Source = oNButton.DataType
        Return Me
    End Function
    Public Function StartingWith(ByVal oId As Integer) As NButtonBuilder
        Dim btnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillById(oBtnTable, oId)
        If oBtnTable.Rows.Count = 1 Then
            btnRow = oBtnTable.Rows(0)
        End If
        If btnRow IsNot Nothing Then
            With btnRow
                _Id = .buttonId
                _Text = .buttonText
                _Hint = .buttonHint
                _Value = .buttonValue
                _Sequence = .buttonSeq
                _Group = .buttonGroup
                _FontName = .buttonFont
                _FontBold = .buttonBold
                _FontSize = .buttonFontSize
                _FontItalic = .buttonItalic
                _Encrypt = .buttonEncrypt
                _Source = Nbutton.DataSource.Group
            End With
        End If
        Return Me
    End Function
    Public Function StartingWith(pId As Integer, pGroup As Integer, pSeq As Integer, pCaption As String, pHint As String, pValue As String, pFontName As String, pFontSize As Single, pBold As Boolean, pItalic As Boolean, pEncrypt As Boolean, pSource As Nbutton.DataSource) As NButtonBuilder
        _Id = pId
        _FontName = pFontName
        _FontSize = pFontSize
        _FontBold = pBold
        _FontItalic = pItalic
        _Text = pCaption
        _Value = pValue
        _Hint = pHint
        _Group = pGroup
        _Sequence = pSeq
        _Encrypt = pEncrypt
        _Source = pSource
        Return Me
    End Function
    Public Function StartingWith(ByVal oBtnRow As TypeRightDataSet.buttonRow) As NButtonBuilder
        _Id = oBtnRow.buttonId
        _Group = oBtnRow.buttonGroup
        _Sequence = oBtnRow.buttonSeq
        _Text = oBtnRow.buttonText
        _Hint = oBtnRow.buttonHint
        _Value = oBtnRow.buttonValue
        _FontName = oBtnRow.buttonFont
        _FontSize = oBtnRow.buttonFontSize
        _FontBold = oBtnRow.buttonBold
        _FontItalic = oBtnRow.buttonItalic
        _Encrypt = oBtnRow.buttonEncrypt
        _Source = Nbutton.DataSource.Group
        Return Me
    End Function
    Public Function StartingWithNothing() As NButtonBuilder
        _Id = 0
        _Group = 0
        _Sequence = 0
        _Text = ""
        _Hint = ""
        _Value = ""
        _FontName = "Arial"
        _FontSize = 8.0
        _FontBold = False
        _FontItalic = False
        _Encrypt = False
        _Source = Nbutton.DataSource.Undefined
        Return Me
    End Function
    Public Function WithId(ByVal pId As Integer) As NButtonBuilder
        _Id = pId
        Return Me
    End Function
    Public Function WithGroup(ByVal pGroup As Integer) As NButtonBuilder
        _Group = pGroup
        Return Me
    End Function
    Public Function WithSeq(ByVal pSeq As Integer) As NButtonBuilder
        _Sequence = pSeq
        Return Me
    End Function
    Public Function WithText(ByVal pText As String) As NButtonBuilder
        _Text = pText
        Return Me
    End Function
    Public Function WithHint(ByVal pHint As String) As NButtonBuilder
        _Hint = pHint
        Return Me
    End Function
    Public Function WithValue(ByVal pValue As String) As NButtonBuilder
        _Value = pValue
        Return Me
    End Function
    Public Function WithFontName(ByVal pFontName As String) As NButtonBuilder
        _FontName = pFontName
        Return Me
    End Function
    Public Function WithFontBold(ByVal pFontBold As Boolean) As NButtonBuilder
        _FontBold = pFontBold
        Return Me
    End Function
    Public Function WithFontSize(ByVal pFontSize As Single) As NButtonBuilder
        _FontSize = pFontSize
        Return Me
    End Function
    Public Function WithFontItalic(ByVal pFontItalic As Boolean) As NButtonBuilder
        _FontItalic = pFontItalic
        Return Me
    End Function
    Public Function WithEncrypt(ByVal pEncrypt As Boolean) As NButtonBuilder
        _Encrypt = pEncrypt
        Return Me
    End Function
    Public Function WithSource(ByVal pSource As Nbutton.DataSource) As NButtonBuilder
        _Source = pSource
        Return Me
    End Function
    Public Sub SaveButton()
        oBtnTa.UpdateButton(_Group, _Sequence, _Text, _Hint, _Value, _FontName, _FontBold, _FontSize, _FontItalic, _Encrypt, _Id)
    End Sub
    Public Function Build() As Nbutton
        Return New Nbutton(_Id, _Group, _Sequence, _Text, _Hint, _Value, _FontName, _FontSize, _FontBold, _FontItalic, _Encrypt, _Source)
    End Function
End Class
