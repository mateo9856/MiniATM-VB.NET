Imports System
Imports MiniATM.Lib

Module StartConsole
    Sub Main(args As String())
        Console.WriteLine("Start generate card and User Info")
        Dim cardGenerator As New FakeCardGenerator()
        cardGenerator.GenerateCard()
        Console.WriteLine($"Start processing your Card: {cardGenerator.CardNumber}")
        Console.WriteLine("Create new Account, Customer and assign Card")
        Dim clientGenerator As New FakeClientGenerator(cardGenerator)

        Console.WriteLine("Enter your Pin...")
        Dim pinPrompt = Console.ReadLine()

        If Not (PasswordTools.VerifyPassword(pinPrompt, cardGenerator.Pin)) Then
            Console.WriteLine("Pin is incorrect, program stopped.")
        End If

        Console.WriteLine("Logged, rest of logic comming soon...")

    End Sub
End Module
