Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class SmtpBuilder
    Private _smtpId As Integer
    Private _username As String
    Private _password As String
    Private _host As String
    Private _port As Integer
    Private _ssl As Boolean
    Private _reqCred As Boolean

    Public Shared Function NewSmtp() As SmtpBuilder
        Return New SmtpBuilder
    End Function

    Public Function StartingWith(ByVal pSmtp As Smtp) As SmtpBuilder
        _smtpId = pSmtp.SmtpId
        _host = pSmtp.Host
        _port = pSmtp.Port
        _username = pSmtp.Username
        _password = pSmtp.Password
        _ssl = pSmtp.IsEnableSsl
        _reqCred = pSmtp.IsCredentialsRequired
        Return Me
    End Function
    Public Function StartingWith(ByVal pSmtpRow As TypeRightDataSet.smtpRow) As SmtpBuilder
        _smtpId = pSmtpRow.smtpId
        _host = pSmtpRow.smtpHost
        _port = pSmtpRow.smtpPort
        _username = pSmtpRow.smtpUsername
        _password = pSmtpRow.smtpPassword
        _ssl = pSmtpRow.smtpSsl = 1
        _reqCred = pSmtpRow.smtpReqCred = 1
        Return Me
    End Function
    Public Function StartingWith(pId As Integer,
                    pUsername As String,
                    pPassword As String,
                    pHost As String,
                    pPort As Integer,
                    pSsl As Boolean,
                    pReqCred As Boolean) As SmtpBuilder
        _smtpId = pId
        _host = pHost
        _port = pPort
        _username = pUsername
        _password = pPassword
        _ssl = pSsl
        _reqCred = pReqCred
        Return Me
    End Function

    Public Function WithId(pId As Integer) As SmtpBuilder
        _smtpId = pId
        Return Me
    End Function

    Public Function WithUsername(pUsername As String) As SmtpBuilder
        _username = pUsername
        Return Me
    End Function

    Public Function WithPassword(pPassword As String) As SmtpBuilder
        _password = pPassword
        Return Me
    End Function

    Public Function WithHost(pHost As String) As SmtpBuilder
        _host = pHost
        Return Me
    End Function

    Public Function WithPort(pPort As Integer) As SmtpBuilder
        _port = pPort
        Return Me
    End Function

    Public Function WithEnableSsl(pSsl As Boolean) As SmtpBuilder
        _ssl = pSsl
        Return Me
    End Function

    Public Function WithRequireCredentials(pReqCred As Boolean) As SmtpBuilder
        _reqCred = pReqCred
        Return Me
    End Function

    Public Function Build() As Smtp
        Return New Smtp(_smtpId,
                        _username,
                        _password,
                        _host,
                        _port,
                        _ssl,
                        _reqCred)
    End Function
End Class
