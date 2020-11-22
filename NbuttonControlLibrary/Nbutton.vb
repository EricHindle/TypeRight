Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Public Class Nbutton

    Private ReadOnly oBtnTa As New TypeRightDataSetTableAdapters.buttonTableAdapter
    Private ReadOnly oBtnTable As New TypeRightDataSet.buttonDataTable
    'Default Property Values:
    Const m_def_Caption As String = "New"
    Const m_def_Value As String = "?"
    Const m_def_Hint As String = ""
    Const m_def_Bold As Boolean = False
    Const m_def_Seq As Integer = 999
    Const m_def_Grp As Integer = 1
    'Property Variables
    Dim m_Id As String
    Dim stdFont As String

    Public Overrides Property Text() As String
        Get
            Return Button1.Text
        End Get
        Set(ByVal value As String)
            Button1.Text = value
        End Set
    End Property
    Private _hint As String
    Public Property Hint() As String
        Get
            Return _hint
        End Get
        Set(ByVal value As String)
            _hint = value
        End Set
    End Property

    Private _value As String
    Public Property Value() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property

    Private _font As String
    Public Property Typeface() As String
        Get
            Return Button1.Font.Name
        End Get
        Set(ByVal value As String)
            Button1.Font = New Font(value, Button1.Font.Size)
        End Set
    End Property

    Public Property Bold() As Boolean
        Get
            Return Button1.Font.Bold
        End Get
        Set(ByVal value As Boolean)
            Button1.Font = New Font(Button1.Font, If(value, FontStyle.Bold, FontStyle.Regular))
        End Set
    End Property

    Private _seq As Integer
    Public Property Sequence() As Integer
        Get
            Return _seq
        End Get
        Set(ByVal value As Integer)
            _seq = value
        End Set
    End Property

    Private _group As Integer
    Public Property Group() As Integer
        Get
            Return _group
        End Get
        Set(ByVal value As Integer)
            _group = value
        End Set
    End Property

    Public Sub New()
        Me.InitializeComponent()
        stdFont = "Arial"
        Button1.Text = m_def_Caption
        _value = m_def_Value
        Hint = m_def_Hint
        _font = stdFont
    End Sub
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
                _value = .buttonValue
                Typeface = .buttonFont
                Bold = .buttonBold
                _seq = .buttonSeq
                _group = .buttonGroup
            End With
        End If
    End Sub

    Public Sub SaveButton()
        oBtnTa.UpdateButton(_group, _seq, Text, Hint, _value, Typeface, CByte(Bold), m_Id)
    End Sub

    Private Sub Nbutton_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Button1.Size = Size
    End Sub
End Class
