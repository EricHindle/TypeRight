Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Public Class Nbutton
    Public Enum DataSource
        Undefined
        Group
        Sender
    End Enum
    Private Structure Typeface
        Dim fontName As String
        Dim fontSize As Single
        Dim isItalic As Boolean
        Dim isBold As Boolean
    End Structure
    'Default Property Values:
    Const m_def_Caption As String = "New"
    Const m_def_Value As String = "?"
    Const m_def_Hint As String = ""
    Const m_def_Bold As Boolean = False
    Const m_def_Italic As Boolean = False
    Const m_def_Seq As Integer = 999
    Const m_def_Grp As Integer = 1
    Const m_def_Fontname As String = "Tahoma"
    Const m_def_Size As Single = 8.0
    Const m_def_Encrypt As Boolean = False
    'Property Variables
    Private m_Id As String
    Private m_Typeface As Typeface
    Private m_Caption As String
    Private m_Hint As String
    Private m_Value As String
    Private m_Fontname As String
    Private m_Fontsize As Single
    Private m_Bold As Boolean
    Private m_Italic As Boolean
    Private m_Seq As Integer
    Private m_Group As Integer
    Private m_Encrypt As Boolean
    Private m_dataType As DataSource
    Public Property DataType() As DataSource
        Get
            Return m_dataType
        End Get
        Set(ByVal value As DataSource)
            m_dataType = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(ByVal value As Integer)
            m_Id = value
        End Set
    End Property
    Public Overrides Property Font() As Font
        Get
            Return Button1.Font
        End Get
        Set(ByVal value As Font)
            m_Fontname = value.Name
            m_Fontsize = value.Size
            m_Bold = value.Bold
            m_Italic = value.Italic
            UpdateFont()
        End Set
    End Property

    Public Property FontName() As String
        Get
            Return m_Fontname
        End Get
        Set(ByVal value As String)
            m_Fontname = value
            UpdateFont()
        End Set
    End Property
    Public Property FontSize() As Single
        Get
            Return m_Fontsize
        End Get
        Set(ByVal value As Single)
            m_Fontsize = value
            UpdateFont()
        End Set
    End Property
    Public Property FontBold() As Boolean
        Get
            Return m_Bold
        End Get
        Set(ByVal value As Boolean)
            m_Bold = value
            UpdateFont()
        End Set
    End Property
    Public Property FontItalic() As Boolean
        Get
            Return m_Italic
        End Get
        Set(ByVal value As Boolean)
            m_Italic = value
            UpdateFont()
        End Set
    End Property
    Public Property Caption() As String
        Get
            Return m_Caption
        End Get
        Set(ByVal value As String)
            m_Caption = value
            Button1.Text = m_Caption
        End Set
    End Property
    Public Property Hint() As String
        Get
            Return m_Hint
        End Get
        Set(ByVal value As String)
            m_Hint = value
            ToolTip1.SetToolTip(Button1, value)
        End Set
    End Property
    Public Property Value() As String
        Get
            Return m_Value
        End Get
        Set(ByVal value As String)
            m_Value = value
        End Set
    End Property
    Public Property Sequence() As Integer
        Get
            Return m_Seq
        End Get
        Set(ByVal value As Integer)
            m_Seq = value
        End Set
    End Property
    Public Property Group() As Integer
        Get
            Return m_Group
        End Get
        Set(ByVal value As Integer)
            m_Group = value
        End Set
    End Property
    Public Property Encrypt() As Boolean
        Get
            Return m_Encrypt
        End Get
        Set(ByVal value As Boolean)
            m_Encrypt = value
        End Set
    End Property


    Public Sub New()
        Me.InitializeComponent()
        m_Id = -1
        m_Fontname = m_def_Fontname
        m_Fontsize = m_def_Size
        m_Bold = m_def_Bold
        m_Italic = m_def_Italic
        m_Typeface = MakeTypeface(m_Fontname, m_Fontsize, m_Bold, m_Italic)
        Button1.Text = m_def_Caption
        Button1.Font = MakeFont(m_Typeface)
        Value = m_def_Value
        Hint = m_def_Hint
        Group = m_def_Grp
        Sequence = m_def_Seq
        Encrypt = m_def_Encrypt
        DataType = DataSource.Undefined
    End Sub
    Public Sub New(pId As Integer, pGroup As Integer, pSeq As Integer, pCaption As String, pHint As String, pValue As String, pFontName As String, pFontSize As Single, pBold As Boolean, pItalic As Boolean, pEncrypt As Boolean, pSource As DataSource)
        Me.InitializeComponent()
        m_Id = pId
        m_Fontname = pFontName
        m_Fontsize = pFontSize
        m_Bold = pBold
        m_Italic = pItalic
        UpdateFont()
        m_Caption = pCaption
        Button1.Text = pCaption
        Value = pValue
        Hint = pHint
        Group = pGroup
        Sequence = pSeq
        Encrypt = pEncrypt
        DataType = pSource
    End Sub
    Private Function MakeFont(p_Typeface As Typeface) As Font
        Dim newStyle As FontStyle = If(p_Typeface.isBold, FontStyle.Bold, FontStyle.Regular) Or If(p_Typeface.isItalic, FontStyle.Italic, FontStyle.Regular)
        Dim newFont As Font = New Font(p_Typeface.fontName, p_Typeface.fontSize, newStyle)
        Return newFont
    End Function
    Private Function MakeTypeface(p_FontName As String, p_FontSize As Integer, isFontBold As Boolean, isFontItalic As Boolean) As Typeface
        Dim tf As Typeface
        tf.fontName = p_FontName
        tf.fontSize = p_FontSize
        tf.isBold = isFontBold
        tf.isItalic = isFontItalic
        Return tf
    End Function
    Private Sub UpdateFont()
        m_Typeface = MakeTypeface(m_Fontname, m_Fontsize, m_Bold, m_Italic)
        Button1.Font = MakeFont(m_Typeface)
    End Sub
    Private Sub Nbutton_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Button1.Size = Me.Size
    End Sub
    Private Sub Nbutton_FontChanged(sender As Object, e As EventArgs) Handles Me.FontChanged
        Button1.Font = Me.Font
        m_Fontname = Button1.Font.Name
        m_Fontsize = Button1.Font.Size
        m_Italic = Button1.Font.Italic
        m_Bold = Button1.Font.Bold
    End Sub
    Private Sub Button1_SizeChanged(sender As Object, e As EventArgs) Handles Button1.SizeChanged
        Me.Size = Button1.Size
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        'Add your custom paint code here
    End Sub
End Class
