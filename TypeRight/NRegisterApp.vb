Imports System.Diagnostics
Public Class NRegisterApp
    Private Const VALID_CHARS As String = "ABCDEFGHJKLM0123456789NPQRTUVWXY"

    Private Const RANDOM_LOWER As Long = 0
    Private Const RANDOM_UPPER As Long = 31

    Public Shared Function GenerateKey(strRegisteredName As String,
                            strAppChars As String) As String
        Dim lChar As Long
        Dim lCount As Long

        Dim strCodedString As String
        Dim strRegCode As String

        Dim oEncoder As New NCode
        strCodedString = oEncoder.MD5(UCase(strRegisteredName) & strAppChars)

        strRegCode = ""
        For lCount = 1 To 16
            lChar = CLng("&H" & Mid(strCodedString, (lCount * 2) - 1, 2)) Mod 32
            strRegCode &= Mid(VALID_CHARS, lChar + 1, 1)
        Next
        My.Settings.RegCode = strRegCode
        My.Settings.Save()

        Return strRegCode
    End Function

    Public Function IsValidKey(strKey As String,
                           strRegisteredName As String,
                           strAppChars As String) As Boolean

        ' Check for equality
        IsValidKey = (GenerateKey(strRegisteredName, strAppChars) = strKey)
    End Function

End Class
