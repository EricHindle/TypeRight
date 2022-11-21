Public Class Smtp
    Private _smtpId As Integer
    Private _username As String
    Private _password As String
    Private _host As String
    Private _port As Integer
    Private _ssl As Boolean
    Private _reqCred As Boolean
    Public Property IsCredentialsRequired() As Boolean
        Get
            Return _reqCred
        End Get
        Set(ByVal value As Boolean)
            _reqCred = value
        End Set
    End Property

    Public Property IsEnableSsl() As Boolean
        Get
            Return _ssl
        End Get
        Set(ByVal value As Boolean)
            _ssl = value
        End Set
    End Property

    Public Property Port() As Integer
        Get
            Return _port
        End Get
        Set(ByVal value As Integer)
            _port = value
        End Set
    End Property
    Public Property Host() As String
        Get
            Return _host
        End Get
        Set(ByVal value As String)
            _host = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property
    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property SmtpId() As Integer
        Get
            Return _smtpId
        End Get
        Set(ByVal value As Integer)
            _smtpId = value
        End Set
    End Property
    Public Sub New()
        _smtpId = -1
        _host = ""
        _port = 0
        _username = ""
        _password = ""
        _ssl = False
        _reqCred = False
    End Sub
    Public Sub New(pId As Integer,
                    pUsername As String,
                    pPassword As String,
                    pHost As String,
                    pPort As Integer,
                    pSsl As Boolean,
                    pReqCred As Boolean)
        _smtpId = pId
        _host = pHost
        _port = pPort
        _username = pUsername
        _password = pPassword
        _ssl = pSsl
        _reqCred = pReqCred
    End Sub
End Class
