' hindleware
' Copyright (c) 2022-26 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports HindlewareLib.Domain

Namespace Domain

    Public Class SmtpAccountBuilder
        Inherits Builders.SmtpAccountBuilder
        Public Overloads Shared Function AnSmtpAccount() As SmtpAccountBuilder
            Return New SmtpAccountBuilder
        End Function
        Public Overloads Function StartingWith(ByVal pSmtpRow As TypeRightDataSet1.smtpRow) As SmtpAccountBuilder
            WithId(pSmtpRow.smtpId)
            WithHost(pSmtpRow.smtpHost)
            WithPort(pSmtpRow.smtpPort)
            WithUsername(pSmtpRow.smtpUsername)
            WithPassword(pSmtpRow.smtpPassword)
            WithEnableSsl(pSmtpRow.smtpSsl = 1)
            WithRequireCredentials(pSmtpRow.smtpReqCred = 1)
            Return Me
        End Function
    End Class
End Namespace
