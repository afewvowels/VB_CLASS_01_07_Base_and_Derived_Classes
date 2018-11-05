
Public Class AccountTest
    Private objSavingsAccount As New Account(100) ' create an Account object
    Private objCheckingAccount As New CheckingAccount(200D)

    ' display the initial account balance when program executes
    Private Sub AccountTest_Load(sender As Object,
       e As EventArgs) Handles MyBase.Load

        AccountTypeComboBox.SelectedIndex = 0

        ShowBalance()
    End Sub ' AccountTest_Load

    ' process a deposit
    Private Sub depositButton_Click(sender As Object,
       e As EventArgs) Handles depositButton.Click

        Try
            ' get deposit amount
            Dim DepositAmountDecimal As Decimal =
               Convert.ToDecimal(inputTextBox.Text)

            If AccountTypeComboBox.Text = "Savings" Then
                ' savings
                objSavingsAccount.Deposit(DepositAmountDecimal) ' make the deposit
            Else
                ' checking
                objCheckingAccount.Deposit(DepositAmountDecimal)
            End If

        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("Deposit amount must be positive.",
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ShowBalance()

        inputTextBox.Clear() ' clear the inputTextBox
        inputTextBox.Focus() ' allow user to type in the inputTextBox
    End Sub ' depositButton_Click

    ' process a withdrawal
    Private Sub withdrawButton_Click(sender As Object,
       e As EventArgs) Handles withdrawButton.Click

        Try
            ' get withdrawal amount
            Dim WithdrawalAmountDecimal As Decimal =
               Convert.ToDecimal(inputTextBox.Text)
            If AccountTypeComboBox.Text = "Savings" Then
                ' savings
                objSavingsAccount.Withdraw(WithdrawalAmountDecimal) ' make the deposit
            Else
                ' checking
                objCheckingAccount.Withdraw(WithdrawalAmountDecimal)
            End If
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show(ex.Message,
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ShowBalance()


        inputTextBox.Clear() ' clear the inputTextBox
        inputTextBox.Focus() ' allow user to type in the inputTextBox
    End Sub ' withdrawButton_Click

    Private Sub AccountTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AccountTypeComboBox.SelectedIndexChanged
        ShowBalance()
    End Sub

    Sub ShowBalance()
        If AccountTypeComboBox.Text = "Savings" Then
            ' savings
            accountBalanceValueLabel.Text =
                  String.Format("{0:C}", objSavingsAccount.Balance)
        Else
            ' checking
            accountBalanceValueLabel.Text =
                  String.Format("{0:C}", objCheckingAccount.Balance)
        End If
    End Sub
End Class ' AccountTest
