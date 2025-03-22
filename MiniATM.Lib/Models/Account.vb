Public Class Account
    Public Customer As Customer

    Public CardInfo As CardInfo

    Public WorkBalance As Decimal
    Public LockedFunds As Decimal
    Public AccountId As Guid

    Public Function GetActualBalance() As Decimal
        Return WorkBalance - LockedFunds
    End Function

    Public Function HadnoutCash(Value As Double) As (Short, String)

        Return (-1, "Another Handout Error.")
    End Function

    Public Function PayCash(Value As Double) As (Short, String)

        Return (-1, "Another Payment Error.")
    End Function

End Class
