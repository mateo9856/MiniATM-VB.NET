Public Class FakeClientGenerator
    Private UserAccount As Account
    Private UserCustomer As Customer

    Private _random As New Random()

    Public Sub New(cardInfo As FakeCardGenerator)
        Dim randomData = GetCustomerData()

        UserCustomer = New Customer()
        UserCustomer.Name = randomData.Name
        UserCustomer.Surname = randomData.Surname
        UserCustomer.Address = randomData.Address
        UserCustomer.CustomerCategory = CustomerType.Individual
        UserCustomer.ClientId = Guid.NewGuid()
        UserAccount = New Account()
        UserAccount.Customer = UserCustomer
        UserAccount.AccountId = Guid.NewGuid()
        UserAccount.WorkBalance = _random.Next(0, 100000.0F)
        UserAccount.LockedFunds = 0
        UserAccount.CardInfo = New CardInfo()
        UserAccount.CardInfo.Account = UserAccount
        UserAccount.CardInfo.CardNumber = cardInfo.CardNumber
        UserAccount.CardInfo.Ccv = cardInfo.Ccv
        UserAccount.CardInfo.ExpiryDate = cardInfo.ValidDate
        UserAccount.CardInfo.Balance = _random.Next(0, UserAccount.WorkBalance)
        UserAccount.CardInfo.Pin = cardInfo.Pin
    End Sub

    Function GetCustomerData() As (Name As String, Surname As String, Address As String)
        Return (PredictName(), PredictSurname(), PredictAddress())
    End Function

    Function PredictName() As String
        Dim randomNames() As String = {"John", "Jane", "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hank"}
        Return randomNames(_random.Next(0, randomNames.Length))
    End Function

    Function PredictSurname() As String
        Dim randomSurnames() As String = {"Doe", "Smith", "Johnson", "Brown", "Williams", "Jones", "Garcia", "Martinez", "Hernandez", "Lopez"}
        Return randomSurnames(_random.Next(0, randomSurnames.Length))
    End Function

    Function PredictAddress() As String
        Dim randomAddress() As String = {"1234 Elm Street", "5678 Oak Street", "9101 Pine Street", "1213 Maple Street", "1415 Cedar Street", "1617 Birch Street", "1819 Ash Street", "2021 Walnut Street", "2223 Spruce Street", "2425 Chestnut Street"}
        Return randomAddress(_random.Next(0, randomAddress.Length))
    End Function

End Class
