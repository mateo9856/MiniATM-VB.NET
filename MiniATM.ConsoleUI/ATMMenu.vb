Imports MiniATM.[Lib]

Public Class ATMMenu

    Private _account As Account
    Private _continueOptions As Boolean = False

    Public Sub New(account As Account)
        _account = account
    End Sub

    Public Sub Run()
        _continueOptions = True

        While True
            If _continueOptions Then
                ShowOptions()
            End If

            _continueOptions = False

            Dim selectedOption = Console.ReadLine()
            Select Case selectedOption
                Case "1"
                    ' Cash handout
                    Console.WriteLine("Cash handout")
                Case "2"
                    ' Cash payment
                    Console.WriteLine("Cash payment")
                Case "3"
                    ' Account balance
                    Dim balance = _account.GetActualBalance()
                    Console.WriteLine($"Your balance is: {balance}")
                    Console.WriteLine($"Working balance: {_account.WorkBalance}")
                    Console.WriteLine($"Locked funds: {_account.LockedFunds}")
                    Console.WriteLine($"Card balance: {_account.CardInfo.Balance}")

                    _continueOptions = True
                Case "4"
                    ' Change Pin
                    _account.CardInfo.GenerateNewPin()

                    Console.WriteLine($"Type to continue...")
                    Console.ReadLine()

                    _continueOptions = True
                Case "5"
                    ' Exit
                    Return
                Case Else
                    Console.WriteLine("Invalid option")
            End Select
        End While
    End Sub

    Public Sub ShowOptions()
        Console.Clear()
        Console.WriteLine("Select an option:")
        Console.WriteLine("1: Cash handout")
        Console.WriteLine("2: Cash payment")
        Console.WriteLine("3: Account balance")
        Console.WriteLine("4: Change Pin")
        Console.WriteLine("5: Exit")
    End Sub

End Class
