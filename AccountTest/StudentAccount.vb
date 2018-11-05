Public Class StudentAccount
    Inherits Account

    Const SERVICE_CHARGE_DECIMAL As Decimal = 0

    ' PROPERTIES

    ' CONSTRUCTORS
    Public Sub New(initialBalanceDecimal As Decimal)

        MyBase.New(initialBalanceDecimal)

    End Sub ' New

    ' METHODS
    Public Overrides Sub Withdraw(inAmount As Decimal)
        ' if withdrawalAmount is greater than Balance, throw an exception
        If inAmount > Balance Then ' invokes lines 45-47

            Balance = Balance - SERVICE_CHARGE_DECIMAL

            Throw New ArgumentOutOfRangeException(
               "Withdrawal amount must be less than or equal to balance. Service Charge applied.")
        ElseIf inAmount <= 0D Then
            Throw New ArgumentOutOfRangeException(
               "Withrawal amount must be positive.")
        End If

        ' subtract withdrawalAmount from balanceValue
        Balance -= inAmount
    End Sub

End Class
