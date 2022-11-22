Imports System.Windows.Forms

Public Class ButtonGroupBuilder
    Private _groupId As Integer
    Private _groupName As String
    Public Shared Function aButtonGroup() As ButtonGroupBuilder
        Return New ButtonGroupBuilder
    End Function
    Private Sub Initialise()
        _groupId = -1
        _groupName = ""
    End Sub
    Public Function StartingWithNothing() As ButtonGroupBuilder
        Initialise()
        Return Me
    End Function
    Public Function StartingWithNothing(pGroup As ButtonGroup) As ButtonGroupBuilder
        _groupId = pGroup.GroupId
        _groupName = pGroup.GroupName
        Return Me
    End Function
    Public Function StartingWith(ByVal pGroupRow As TypeRightDataSet.buttongroupsRow) As ButtonGroupBuilder
        _groupId = pGroupRow.buttongroupid
        _groupName = pGroupRow.groupname
        Return Me
    End Function
    Public Function StartingWith(pId As Integer, pName As String) As ButtonGroupBuilder
        _groupId = pId
        _groupName = pName
        Return Me
    End Function
    Public Function WithId(pId As Integer) As ButtonGroupBuilder
        _groupId = pId
        Return Me
    End Function
    Public Function WithUsername(pName As String) As ButtonGroupBuilder
        _groupName = pName
        Return Me
    End Function
    Public Function Build() As ButtonGroup
        Return New ButtonGroup(_groupId, _groupName)
    End Function
End Class
