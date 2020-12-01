﻿Public Class sender
    Private _id As Integer
    Private _firstname As String
    Private _lastname As String
    Private _address2 As String
    Private _town As String
    Private _county As String
    Private _postcode As String
    Private _dob As DateTime
    Private _title As String
    Private _housenumber As String
    Private _street As String
    Private _country As String
    Private _email As String
    Private _phone As String
    Private _mobile As String
    Private _password As String
    Private _secretword As String
    Private _gender As String
    Private _occupation As String
    Private _maritalstatus As String
    Private _username As String
    Public Property SenderId() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property FirstName() As String
        Get
            Return _firstname
        End Get
        Set(ByVal value As String)
            _firstname = value
        End Set
    End Property
    Public Property LastName() As String
        Get
            Return _lastname
        End Get
        Set(ByVal value As String)
            _lastname = value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return _address2
        End Get
        Set(ByVal value As String)
            _address2 = value
        End Set
    End Property
    Public Property Town() As String
        Get
            Return _town
        End Get
        Set(ByVal value As String)
            _town = value
        End Set
    End Property
    Public Property County() As String
        Get
            Return _county
        End Get
        Set(ByVal value As String)
            _county = value
        End Set
    End Property
    Public Property PostCode() As String
        Get
            Return _postcode
        End Get
        Set(ByVal value As String)
            _postcode = value
        End Set
    End Property
    Public Property DateOfBirth() As DateTime
        Get
            Return _dob
        End Get
        Set(ByVal value As DateTime)
            _dob = value
        End Set
    End Property
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property
    Public Property HouseNumber() As String
        Get
            Return _housenumber
        End Get
        Set(ByVal value As String)
            _housenumber = value
        End Set
    End Property
    Public Property Street() As String
        Get
            Return _street
        End Get
        Set(ByVal value As String)
            _street = value
        End Set
    End Property
    Public Property Country() As String
        Get
            Return _country
        End Get
        Set(ByVal value As String)
            _country = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Public Property Phone() As String
        Get
            Return _phone
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property
    Public Property Mobile() As String
        Get
            Return _mobile
        End Get
        Set(ByVal value As String)
            _mobile = value
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
    Public Property SecretWord() As String
        Get
            Return _secretword
        End Get
        Set(ByVal value As String)
            _secretword = value
        End Set
    End Property
    Public Property Gender() As String
        Get
            Return _gender
        End Get
        Set(ByVal value As String)
            _gender = value
        End Set
    End Property
    Public Property Occupation() As String
        Get
            Return _occupation
        End Get
        Set(ByVal value As String)
            _occupation = value
        End Set
    End Property
    Public Property MaritalStatus() As String
        Get
            Return _maritalstatus
        End Get
        Set(ByVal value As String)
            _maritalstatus = value
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
    Public Sub New()
        SenderId = -1
        FirstName = ""
        LastName = ""
        Address2 = ""
        Town = ""
        County = ""
        PostCode = ""
        DateOfBirth = Date.MinValue
        Title = ""
        HouseNumber = ""
        Street = ""
        Country = ""
        Email = ""
        Phone = ""
        Mobile = ""
        Password = ""
        SecretWord = ""
        Gender = ""
        Occupation = ""
        MaritalStatus = ""
        Username = ""
    End Sub
    Public Sub New(pId As Integer,
                    pFirstName As String,
                    pLastName As String,
                    pAddress2 As String,
                    pTown As String,
                    pCounty As String,
                    pPostCode As String,
                    pDateOfBirth As DateTime,
                    pTitle As String,
                    pHouseNumber As String,
                    pStreet As String,
                    pCountry As String,
                    pEmail As String,
                    pPhone As String,
                    pMobile As String,
                    pPassword As String,
                    pSecretWord As String,
                    pGender As String,
                    pOccupation As String,
                    pMaritalStatus As String,
                    pUsername As String
)
        SenderId = pId
        FirstName = pFirstName
        LastName = pLastName
        Address2 = pAddress2
        Town = pTown
        County = pCounty
        PostCode = pPostCode
        DateOfBirth = pDateOfBirth
        Title = pTitle
        HouseNumber = pHouseNumber
        Street = pStreet
        Country = pCountry
        Email = pEmail
        Phone = pPhone
        Mobile = pMobile
        Password = pPassword
        SecretWord = pSecretWord
        Gender = pGender
        Occupation = pOccupation
        MaritalStatus = pMaritalStatus
        Username = pUsername

    End Sub
End Class
