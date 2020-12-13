Imports System.Diagnostics
Imports System.Text
Imports System.Security.Cryptography
Public NotInheritable Class NRegisterApp
    Private Const VALID_CHARS As String = "ABCDEFGHJKLM0123456789NPQRTUVWXY"
    Public Shared Function GenerateKey(strRegisteredName As String,
                            strAppChars As String) As String
        Dim lChar As Long
        Dim lCount As Long
        Dim strCodedString As String
        Dim strRegCode As String
        strCodedString = Md5FromString(UCase(strRegisteredName) & strAppChars)
        strRegCode = ""
        For lCount = 1 To 16
            lChar = CLng("&H" & Mid(strCodedString, (lCount * 2) - 1, 2)) Mod 32
            strRegCode &= Mid(VALID_CHARS, lChar + 1, 1)
        Next
        'My.Settings.RegCode = strRegCode
        'My.Settings.Save()
        Return strRegCode
    End Function
    Public Shared Function IsValidKey(strKey As String,
                           strRegisteredName As String,
                           strAppChars As String) As Boolean
        ' Check for equality
        Return (GenerateKey(strRegisteredName, strAppChars) = strKey)
    End Function
    Private Shared Function Md5FromString(ByVal Source As String) As String
        Dim Bytes() As Byte
        Dim sb As New StringBuilder()
        'Check for empty string.
        If Not String.IsNullOrEmpty(Source) Then
            'Get bytes from string.
            Bytes = Encoding.Default.GetBytes(Source)
            'Get md5 hash
            Bytes = MD5.Create().ComputeHash(Bytes)
            'Loop though the byte array and convert each byte to hex.
            For x As Integer = 0 To Bytes.Length - 1
                sb.Append(Bytes(x).ToString("x2"))
            Next
        End If
        'Return md5 hash.
        Return sb.ToString()
    End Function
End Class
