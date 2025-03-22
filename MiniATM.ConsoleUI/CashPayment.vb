Imports MiniATM.Lib

Public Class CashPayment

    Private _account As Account
    Public Sub New(account As Account)
        _account = account
    End Sub

    Public Sub PaymentView()
        Console.WriteLine("Enter the amount to pay.")
        Dim value = Console.ReadLine()
        If Not Decimal.TryParse(value, New Decimal) Then
            Console.WriteLine("Invalid amount")
            Return
        End If
        _account.PayCash(value)
        Console.WriteLine("Cash payment successful")
    End Sub

End Class
