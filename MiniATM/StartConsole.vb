Imports MiniATM.ConsoleUI
Imports MiniATM.Lib

Module StartConsole
    Sub Main(args As String())
        Console.WriteLine("Start generate card and User Info")
        Dim cardGenerator As New FakeCardGenerator()
        cardGenerator.GenerateCard()
        Console.WriteLine($"Start processing your Card: {cardGenerator.CardNumber}")
        Console.WriteLine("Create new Account, Customer and assign Card")
        Dim clientGenerator As New FakeClientGenerator(cardGenerator)

        Dim pinTryCounter As Integer = 0
        Console.WriteLine("Enter your Pin...")

        While True
            Dim pinPrompt = Console.ReadLine()
            If (PasswordTools.VerifyPassword(pinPrompt, cardGenerator.Pin)) Then
                Exit While
            ElseIf pinTryCounter > 3 Then
                Console.WriteLine("You have exceeded the number Of attempts, close app...")
                Environment.Exit(-1)
            Else
                Console.WriteLine("Invalid Pin, try again")
                pinTryCounter += 1
            End If
        End While

        Dim clientData = clientGenerator.GetClient()
        Dim appMenu = New ATMMenu(clientData)
        Console.WriteLine("Logged! Hello {0}!", clientData.Customer.Name)
        appMenu.Run()

    End Sub
End Module
