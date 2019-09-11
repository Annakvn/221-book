' Book Project
' Display the total price
' Anna Kovneva March 11,2017

Option Explicit On
Option Strict On
Option Infer Off

Public Class MainForm
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles booksTextBox.KeyPress
        ' accept only numbers and the backspace
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub CalcButton_Click(sender As Object, e As EventArgs) Handles CalcButton.Click
        ' calculate the total price
        Const Price1To3 As Double = 2.99
        Const Price4To6 As Double = 2.49
        Const PriceOver6 As Double = 1.75
        Dim numBooks As Integer
        Dim totalPrice As Double
        Dim discount As Double = 0.1
        Dim discountedPrice As Double
        Dim button As DialogResult
        Dim button2 As DialogResult

        Integer.TryParse(booksTextBox.Text, numBooks)
        Select Case numBooks
            Case 1 To 3
                totalPrice = Price1To3 * numBooks
            Case 4 To 6
                totalPrice = Price4To6 * numBooks
            Case Is > 6
                totalPrice = PriceOver6 * numBooks
                button = MessageBox.Show("$1 coupon?", "Book Shack", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If button = DialogResult.Yes Then
                    totalPrice -= 1
                End If
        End Select
        button2 = MessageBox.Show("Are you a member of the Shack Book Club?", "Book Shack", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If button2 = DialogResult.Yes Then
            discountedPrice = totalPrice * discount
            totalPrice = totalPrice - discountedPrice
        End If
        TotalLabel.Text = totalPrice.ToString("C2")
        booksTextBox.Focus()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
