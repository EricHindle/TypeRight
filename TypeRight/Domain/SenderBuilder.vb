Public Class SenderBuilder
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

    Public Shared Function NewSender() As SenderBuilder
        Return New SenderBuilder
    End Function

    Public Function StartingWith(ByVal pSender As sender) As SenderBuilder
        _id = pSender.SenderId
        _firstname = pSender.FirstName
        _lastname = pSender.LastName
        _address2 = pSender.Address2
        _town = pSender.Town
        _county = pSender.County
        _postcode = pSender.PostCode
        _dob = pSender.DateOfBirth
        _title = pSender.Title
        _housenumber = pSender.HouseNumber
        _street = pSender.Street
        _country = pSender.Country
        _email = pSender.Email
        _phone = pSender.Phone
        _mobile = pSender.Mobile
        _password = pSender.Password
        _secretword = pSender.SecretWord
        _gender = pSender.Gender
        _occupation = pSender.Occupation
        _maritalstatus = pSender.MaritalStatus
        _username = pSender.Username
        Return Me
    End Function

    Public Function StartingWith(ByVal oRow As TypeRight.TypeRightDataSet.sendersRow) As SenderBuilder
        _id = oRow.senderid
        _firstname = oRow.firstname
        _lastname = oRow.lastname
        _address2 = oRow.address2
        _town = oRow.town
        _county = oRow.county
        _postcode = oRow.postcode
        _dob = oRow.dob
        _title = oRow.title
        _housenumber = oRow.housenumber
        _street = oRow.street
        _country = oRow.country
        _email = oRow.email
        _phone = oRow.phone
        _mobile = oRow.mobile
        _password = oRow.passwd
        _secretword = oRow.secretword
        _gender = oRow.gender
        _occupation = oRow.occupation
        _maritalstatus = oRow.maritalstatus
        _username = oRow.username

        Return Me
    End Function
    Public Function StartingWith(pId As Integer,
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
                    pUsername As String) As SenderBuilder

        _id = pId
        _firstname = pFirstName
        _lastname = pLastName
        _address2 = pAddress2
        _town = pTown
        _county = pCounty
        _postcode = pPostCode
        _dob = pDateOfBirth
        _title = pTitle
        _housenumber = pHouseNumber
        _street = pStreet
        _country = pCountry
        _email = pEmail
        _phone = pPhone
        _mobile = pMobile
        _password = pPassword
        _secretword = pSecretWord
        _gender = pGender
        _occupation = pOccupation
        _maritalstatus = pMaritalStatus
        _username = pUsername
        Return Me
    End Function

    Public Function Build() As sender
        Return New sender(_id,
                    _firstname,
                    _lastname,
                    _address2,
                    _town,
                    _county,
                    _postcode,
                    _dob,
                    _title,
                    _housenumber,
                    _street,
                    _country,
                    _email,
                    _phone,
                    _mobile,
                    _password,
                    _secretword,
                    _gender,
                    _occupation,
                    _maritalstatus,
                    _username)
    End Function

End Class
