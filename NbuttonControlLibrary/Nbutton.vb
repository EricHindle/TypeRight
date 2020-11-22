Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Public Class Nbutton
    Private Structure Typeface
        Dim fontName As String
        Dim fontSize As Single
        Dim isItalic As Boolean
        Dim isBold As Boolean
    End Structure

    Private ReadOnly oBtnTa As New TypeRightDataSetTableAdapters.buttonTableAdapter
    Private ReadOnly oBtnTable As New TypeRightDataSet.buttonDataTable
    'Default Property Values:
    Const m_def_Caption As String = "New"
    Const m_def_Value As String = "?"
    Const m_def_Hint As String = ""
    Const m_def_Bold As Boolean = False
    Const m_def_Italic As Boolean = False
    Const m_def_Seq As Integer = 999
    Const m_def_Grp As Integer = 1
    Const m_def_Fontname As String = "Arial"
    Const m_def_Size As Single = 8.0

    'Property Variables
    Dim m_Id As String
    Dim m_Typeface As Typeface
    Dim m_Caption As String
    Dim m_Hint As String
    Dim m_Value As String
    Dim m_Fontname As String
    Dim m_Fontsize As Single
    Dim m_Bold As Boolean
    Dim m_Italic As Boolean
    Dim m_Seq As Integer
    Dim m_Group As Integer

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
    'Public Property FontName() As String
    '    Get
    '        Return m_Fontname
    '    End Get
    '    Set(ByVal value As String)
    '        m_Fontname = value
    '        Button1.Font = MakeFont(MakeTypeface(m_Fontname, m_Fontsize, m_Bold, m_Italic))
    '    End Set
    'End Property
    'Public Property Bold() As Boolean
    '    Get
    '        Return m_Bold
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_Bold = value
    '        Button1.Font = MakeFont(MakeTypeface(m_Fontname, m_Fontsize, m_Bold, m_Italic))
    '    End Set
    'End Property
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
    'Public Property Italic() As Boolean
    '    Get
    '        Return m_Italic
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_Italic = value
    '        Button1.Font = MakeFont(MakeTypeface(m_Fontname, m_Fontsize, m_Bold, m_Italic))
    '    End Set
    'End Property
    'Public Property FontSize() As Single
    '    Get
    '        Return m_Fontsize
    '    End Get
    '    Set(ByVal value As Single)
    '        m_Fontsize = value
    '        Button1.Font = MakeFont(MakeTypeface(m_Fontname, m_Fontsize, m_Bold, m_Italic))
    '    End Set
    'End Property
    Public Sub New()
        Me.InitializeComponent()
        m_Typeface = MakeTypeface(m_def_Fontname, m_def_Size, m_def_Bold, m_def_Italic)
        Button1.Text = m_def_Caption
        Button1.Font = MakeFont(m_Typeface)
        m_Fontsize = m_def_Size
        m_Fontname = m_def_Fontname
        Value = m_def_Value
        m_Bold = m_def_Bold
        m_Italic = m_def_Italic
        Hint = m_def_Hint
        Group = m_def_Grp
        Sequence = m_def_Seq

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
    Public Sub LoadButton(_btnId As Integer)
        Dim btnRow As TypeRightDataSet.buttonRow = Nothing
        oBtnTa.FillById(oBtnTable, _btnId)
        If oBtnTable.Rows.Count = 1 Then
            btnRow = oBtnTable.Rows(0)
        End If
        If btnRow IsNot Nothing Then
            With btnRow
                m_Id = .buttonId
                Text = .buttonText
                Hint = .buttonHint
                Value = .buttonValue
                m_Fontname = .buttonFont
                m_Bold = .buttonBold
                Sequence = .buttonSeq
                Group = .buttonGroup
            End With
        End If
        Button1.Font = MakeFont(MakeTypeface(m_Fontname, m_Fontsize, m_Bold, m_Italic))
    End Sub

    Public Sub SaveButton()
        oBtnTa.UpdateButton(m_Group, m_Seq, Text, Hint, m_Value, m_Fontname, CByte(m_Bold), m_Id)
    End Sub

    Private Sub Nbutton_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Button1.Size = Size
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
End Class
