' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ButtonGroup
    Private _groupId As Integer
    Private _groupName As String
    Public Property GroupName() As String
        Get
            Return _groupName
        End Get
        Set(ByVal value As String)
            _groupName = value
        End Set
    End Property
    Public Property GroupId() As Integer
        Get
            Return _groupId
        End Get
        Set(ByVal value As Integer)
            _groupId = value
        End Set
    End Property
    Public Sub New()
        _groupId = -1
        _groupName = ""
    End Sub
    Public Sub New(pId As Integer, pName As String)
        _groupId = pId
        _groupName = pName
    End Sub
    Public Function IsEmpty() As Boolean
        Return _groupId = -1
    End Function
End Class
