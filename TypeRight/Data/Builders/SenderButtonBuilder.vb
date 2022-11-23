' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class SenderButtonBuilder
    Private _columnName As String
    Private _bold As Boolean
    Private _italic As Boolean
    Private _fontName As String
    Private _fontSize As Decimal
    Private _isEncrypted As Boolean

    Public Shared Function aSenderButton() As SenderButtonBuilder
        Return New SenderButtonBuilder
    End Function
    Private Sub Initialise()
        _columnName = ""
        _bold = False
        _italic = False
        _fontName = ""
        _fontSize = 0.0D
        _isEncrypted = False
    End Sub
    Public Function StartingWithNothing() As SenderButtonBuilder
        Initialise()
        Return Me
    End Function
    Public Function StartingWith(pSenderButton As SenderButton) As SenderButtonBuilder
        _columnName = pSenderButton.ColumnName
        _bold = pSenderButton.Bold
        _italic = pSenderButton.Italic
        _fontName = pSenderButton.FontName
        _fontSize = pSenderButton.FontSize
        _isEncrypted = pSenderButton.IsEncrypted
        Return Me
    End Function
    Public Function StartingWith(pSenderButtonRow As TypeRightDataSet.senderButtonRow) As SenderButtonBuilder
        _columnName = pSenderButtonRow.ColumnName
        _bold = pSenderButtonRow.buttonBold = 1
        _italic = pSenderButtonRow.buttonItalic = 1
        _fontName = pSenderButtonRow.buttonFontName
        _fontSize = pSenderButtonRow.buttonFontSize
        _isEncrypted = pSenderButtonRow.buttonEncrypted = 1
        Return Me
    End Function
    Public Function StartingWith(pColumnName As String,
                                 pBold As Boolean,
                                 pItalic As Boolean,
                                 pFontName As String,
                                 pFontsize As Decimal,
                                 pIsEncrypted As Boolean) As SenderButtonBuilder
        _columnName = pColumnName
        _bold = pBold
        _italic = pItalic
        _fontName = pFontName
        _fontSize = pFontsize
        _isEncrypted = pIsEncrypted
        Return Me
    End Function
    Public Function WithColumnName(pColumnName As String) As SenderButtonBuilder
        _columnName = pColumnName
        Return Me
    End Function
    Public Function WithBold(pBold As Boolean) As SenderButtonBuilder
        _bold = pBold
        Return Me
    End Function
    Public Function WithItalic(pItalic As Boolean) As SenderButtonBuilder
        _italic = pItalic
        Return Me
    End Function
    Public Function WithFontName(pFontName As String) As SenderButtonBuilder
        _fontName = pFontName
        Return Me
    End Function
    Public Function WithFontSize(pFontSize As Decimal) As SenderButtonBuilder
        _fontSize = pFontSize
        Return Me
    End Function
    Public Function WithIsEncrypted(pIsEncrypted As Boolean) As SenderButtonBuilder
        _isEncrypted = pIsEncrypted
        Return Me
    End Function
    Public Function Build() As SenderButton
        Return New SenderButton(_columnName,
                                _bold,
                                _italic,
                                _fontName,
                                _fontSize,
                                _isEncrypted)
    End Function
End Class
