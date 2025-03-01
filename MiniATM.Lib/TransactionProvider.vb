Public Class TransactionProvider

    Public SessionId As Guid

    Private _sessionLocked As Boolean

    Public Sub New()
        SessionId = Guid.NewGuid()
        _sessionLocked = False
    End Sub

    Public Sub StartTransaction()
        _sessionLocked = True
    End Sub

    Public Sub CommitTransaction()
        _sessionLocked = False
    End Sub

    Public Sub RollbackTransaction()
        _sessionLocked = False
    End Sub


End Class
