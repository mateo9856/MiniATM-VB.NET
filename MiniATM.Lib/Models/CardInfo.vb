Public Class CardInfo
    Public Account As Account

    Public CardNumber As String
    Public ExpiryDate As Date
    Public Ccv As String

    Public Balance As Decimal

    Public Pin As String

    Public Sub GenerateNewPin()
        Console.WriteLine("Enter new pin...")
        Dim newPin = Console.ReadLine()
        If newPin.Length < 4 Then
            Console.WriteLine("Pin must be at least 4 characters long")
            GenerateNewPin()
            Return
        End If

        Pin = PasswordTools.HashPassword(newPin)
        Console.WriteLine("Pin changed successfully")
    End Sub

End Class
