Public Class Customer

    Public Name As String
    Public Surname As String
    Public Address As String
    Private _customerCategory As CustomerType
    Public ClientId As Guid

    Friend Property CustomerCategory As CustomerType
        Get
            Return _customerCategory
        End Get
        Set(value As CustomerType)
            _customerCategory = value
        End Set
    End Property
End Class
