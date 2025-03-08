Public Class Account
    Public Customer As Customer

    Public CardInfo As CardInfo

    Public WorkBalance As Decimal
    Public LockedFunds As Decimal
    Public AccountId As Guid

    Public Function GetActualBalance() As Decimal
        Return WorkBalance - LockedFunds
    End Function

End Class
