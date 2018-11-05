Public Class CheckingAccount
    ' Brings constructors, properties, and methods from the base class 'Account'
    Inherits Account

    ' Constant service charge
    Const SERVICE_CHARGE_DECIMAL As Decimal = 25D

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
            MyBase.Withdraw(SERVICE_CHARGE_DECIMAL)
            Throw New ArgumentOutOfRangeException("Withdrawal amount is greater than account balance, service fee assessed.")
        Else
            MyBase.Withdraw(inWithdrawalAmountDecimal)
        End If
    End Sub
End Class
