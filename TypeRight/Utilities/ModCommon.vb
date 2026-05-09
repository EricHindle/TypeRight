' hindleware
' Copyright (c) 2022-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Module ModCommon
    Public Sub OpenDatabaseForm()
        Using _dbUpdate As New FrmDbUpdate
            _dbUpdate.SenderId = iCurrSender
            _dbUpdate.ShowDialog()
        End Using
    End Sub
End Module
