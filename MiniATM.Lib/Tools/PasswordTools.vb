Imports System.Security.Cryptography

Public Module PasswordTools

    Private Const SaltSize As Integer = 16
    Private Const HashSize As Integer = 32
    Private Const Iterations As Integer = 100000

    Private ReadOnly AlgorithmName As HashAlgorithmName = HashAlgorithmName.SHA512

    Function HashPassword(password As String) As String
        Dim salt() As Byte = RandomNumberGenerator.GetBytes(SaltSize)
        Dim bytes() As Byte = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, AlgorithmName, HashSize)

        Return $"{Convert.ToBase64String(bytes)}:{Convert.ToBase64String(salt)}"

    End Function

    Public Function VerifyPassword(password As String, passwordHash As String) As Boolean
        Dim parts() As String = passwordHash.Split(":"c)
        Dim hash() As Byte = Convert.FromBase64String(parts(0))
        Dim salt() As Byte = Convert.FromBase64String(parts(1))
        Dim newHash() As Byte = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, AlgorithmName, HashSize)

        Return CryptographicOperations.FixedTimeEquals(hash, newHash)

    End Function

End Module
