Public Class FakeCardGenerator

    Public CardNumber As String
    Public Ccv As String
    Public ValidDate As Date
    Public Pin As String

    Public Sub GenerateCard()
        Dim dateNow = DateTime.Now
        ValidDate = New Date(dateNow.Year + 5, dateNow.Month, GetLastDayOfTheMonth(dateNow.Month))
        Dim random As New Random()
        For I = 1 To 4
            CardNumber &= random.Next(1000, 9999).ToString()
        Next I
        Ccv = random.Next(100, 999).ToString()
        Pin = PasswordTools.HashPassword(random.Next(1000, 9999).ToString())

    End Sub

    Function GetLastDayOfTheMonth(month As Integer) As Integer
        Select Case month
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31
            Case 4, 6, 9, 11
                Return 30
            Case 2 And Year(DateTime.Now) Mod 4 = 0
                Return 29
            Case 2 And Year(DateTime.Now) Mod 4 <> 0
                Return 28
            Case Else
                Return 0
        End Select
    End Function

End Class
