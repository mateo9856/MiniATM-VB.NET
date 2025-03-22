Imports MiniATM.Lib

Public Class CashHandout

    Private _account As Account
    Public Sub New(account As Account)
        _account = account
    End Sub

    Public Sub HandoutView()
        Dim amounts() As Double = {500.0, 1000.0, 2000.0, 5000.0}

        Console.WriteLine("Select the amount to handout.")
        Console.WriteLine("1. 500.00")
        Console.WriteLine("2. 1000.00")
        Console.WriteLine("3. 2000.00")
        Console.WriteLine("4. 5000.00")
        Console.WriteLine("5. Other")
        Console.WriteLine("Any key: Back")

        Dim selectedOption = Console.ReadLine()
        Dim assignedAmount As Double
        If selectedOption >= 1 And selectedOption <= 4 Then
            assignedAmount = amounts(selectedOption - 1)
        ElseIf selectedOption = 5 Then
            Console.WriteLine("Enter the amount to handout.")
            Dim value = Console.ReadLine()
            If Not Decimal.TryParse(value, New Decimal) Then
                Console.WriteLine("Invalid amount")
                Return
            End If
            assignedAmount = value
            _account.HadnoutCash(value)
            Return
        Else
            Return
        End If

        Dim actualBalance = _account.GetActualBalance()
        If actualBalance < assignedAmount Then
            Console.WriteLine("Insufficient funds")
            Return
        End If

        _account.HadnoutCash(assignedAmount)
        Console.WriteLine("Cash handout successful")
    End Sub

End Class
