' hindleware
' Copyright (c) 2022-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports TypeRight.TypeRightDataSet1
Imports NbuttonControlLibrary
Namespace Domain
    Public Class ButtonBuilder
        Inherits NbuttonControlLibrary.NButtonBuilder
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
        Public Shared Function AButtonBuilder() As ButtonBuilder
            Return New ButtonBuilder
        End Function
        Public Overloads Function StartingWith(ByVal oButton As TypeRightDataSet1.buttonRow) As ButtonBuilder
            With oButton
                _Id = .buttonId
                _Group = .buttonGroup
                _Sequence = .buttonSeq
                _Text = .buttonText
                _Hint = .buttonHint
                _Value = .buttonValue
                _FontName = .buttonFont
                _FontSize = .buttonFontSize
                _FontBold = .buttonBold
                _FontItalic = .buttonItalic
                _Encrypt = .buttonEncrypt
                _Source = Nbutton.DataSource.Undefined
            End With
            Return Me
        End Function

        Public Overloads Function Build() As Nbutton
            Return New Nbutton(_Id, _Group, _Sequence, _Text, _Hint, _Value, _FontName, _FontSize, _FontBold, _FontItalic, _Encrypt, _Source)
        End Function
    End Class

End Namespace