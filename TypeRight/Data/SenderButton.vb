Public Class SenderButton
#Region "properties"

    Private _columnName As String
    Private _bold As Boolean
    Private _italic As Boolean
    Private _fontName As String
    Private _fontSize As Decimal
    Private _isEncrypted As Boolean
    Public Property IsEncrypted() As Boolean
        Get
            Return _isEncrypted
        End Get
        Set(ByVal value As Boolean)
            _isEncrypted = value
        End Set
    End Property
    Public Property FontSize() As Decimal
        Get
            Return _fontSize
        End Get
        Set(ByVal value As Decimal)
            _fontSize = value
        End Set
    End Property
    Public Property FontName() As String
        Get
            Return _fontName
        End Get
        Set(ByVal value As String)
            _fontName = value
        End Set
    End Property
    Public Property Italic() As Boolean
        Get
            Return _italic
        End Get
        Set(ByVal value As Boolean)
            _italic = value
        End Set
    End Property
    Public Property Bold() As Boolean
        Get
            Return _bold
        End Get
        Set(ByVal value As Boolean)
            _bold = value
        End Set
    End Property
    Public Property ColumnName() As String
        Get
            Return _columnName
        End Get
        Set(ByVal value As String)
            _columnName = value
        End Set
    End Property

#End Region
#Region "constructors"
    Public Sub New()
        _columnName = ""
        _bold = False
        _italic = False
        _fontName = ""
        _fontSize = 0.0D
        _isEncrypted = False
    End Sub
    Public Sub New(pColumnName As String,
                   pBold As Boolean,
                   pItalic As Boolean,
                   pFontName As String,
                   pFontSize As Decimal,
                   pIsEncrypted As Boolean)
        _columnName = pColumnName
        _bold = pBold
        _italic = pItalic
        _fontName = pFontName
        _fontSize = pFontSize
        _isEncrypted = pIsEncrypted
    End Sub
#End Region
#Region "methods"
    Public Function IsEmpty() As Boolean
        Return String.IsNullOrWhiteSpace(_columnName)
    End Function
#End Region
End Class
