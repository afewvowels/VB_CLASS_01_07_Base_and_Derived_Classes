Public Class CheckingAccount
    ' Brings constructors, properties, and methods from the base class 'Account'
    Inherits Account

    ' Overload the constructor, provide data for base class constructor
    ' Base constructor creates account with fixed amount: $100
    Public Sub New()
        MyBase.New(100D)
    End Sub

    Public Sub New(ByVal initialBalance As Decimal)
        ' Can pass through constant values instead of a variable
        MyBase.New(initialBalance)
    End Sub

    ' Override the Withdraw method and provide balance checking logic
    Public Overrides Sub Withdraw(inWithdrawalAmountDecimal As Decimal)
        If (inWithdrawalAmountDecimal >= MyBase.Balance) Then
            Throw New ArgumentOutOfRangeException("Withdrawl amount is greater than account balance.")
        Else
            MyBase.Withdraw(inWithdrawalAmountDecimal)
        End If
    End Sub
End Class
