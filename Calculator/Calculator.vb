Public Class Calculator
    Dim x, y As Double
    Dim Ope As Integer = 0
    Private Function Calc() As Integer
        If Ope = "1" Then
            x += TextBox1.Text
        ElseIf Ope = "2" Then
            x -= TextBox1.Text
        ElseIf Ope = "3" Then
            x *= TextBox1.Text
        ElseIf Ope = "4" Then
            If TextBox1.Text = "0" Then
                x = Nothing
                Ope = Nothing
                TextBox1.Text = "Undefined"
                Button11.Enabled = False
                Button12.Enabled = False
                Button13.Enabled = False
                Button14.Enabled = False
                Button16.Enabled = False
                Button17.Enabled = False
                Return x
            Else
                x /= TextBox1.Text
                TextBox1.Text = "/"
                Ope = "4"
            End If
        End If

        TextBox1.Text = x.ToString()
        x = Nothing
        Ope = Nothing

        Return x
    End Function

    Private Sub ValAdd(value As String)
        If TextBox1.Text.Length >= 15 Then
            MessageBox.Show("Maximum character limit reached", "Max Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If TextBox1.Text = "0" Or TextBox1.Text = "+" Or TextBox1.Text = "-" Or TextBox1.Text = "×" Or TextBox1.Text = "/" Or TextBox1.Text = "Undefined" Then
            Button11.Enabled = True
            Button12.Enabled = True
            Button13.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True
            Button17.Enabled = True
            TextBox1.Text = value
        Else
            TextBox1.Text = TextBox1.Text & value
        End If
    End Sub
    Private Sub Button18_MouseHover(sender As Object, e As EventArgs) Handles Button18.MouseHover
        Button18.Image = My.Resources.Hover
    End Sub
    Private Sub Button18_MouseLeave(sender As Object, e As EventArgs) Handles Button18.MouseLeave
        Button18.Image = My.Resources.Unhover
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If TextBox1.Text = "Undefined" Then
            TextBox1.Clear()
        ElseIf TextBox1.Text.Length > 0 Then
            TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ValAdd(1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ValAdd(2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ValAdd(3)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ValAdd(4)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ValAdd(5)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ValAdd(6)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ValAdd(7)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ValAdd(8)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ValAdd(9)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ValAdd(0)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If TextBox1.Text.Length >= 15 Then
            MessageBox.Show("Maximum character limit reached", "Max Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If TextBox1.Text.Contains(".") Then
            Return
        ElseIf TextBox1.Text = "+" Or TextBox1.Text = "-" Or TextBox1.Text = "×" Or TextBox1.Text = "/" Or TextBox1.Text = "Undefined" Then
            Button11.Enabled = True
            Button12.Enabled = True
            Button13.Enabled = True
            Button14.Enabled = True
            Button16.Enabled = True
            Button17.Enabled = True
            TextBox1.Text = "0."
        ElseIf TextBox1.Text = "" Then
            TextBox1.Text = "0."
        Else
            TextBox1.Text = TextBox1.Text & "."
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim currentValue As Double

        If Double.TryParse(TextBox1.Text, currentValue) Then
            Dim percentageValue As Double = currentValue / 100
            Dim result As String = percentageValue.ToString()

            If result.Length > 15 Then
                MessageBox.Show("Result exceeds maximum character limit", "Max Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                TextBox1.Text = result
            End If
        Else
            MessageBox.Show("Invalid input. Please enter a valid number.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Ope <> 0 Then
            Calc()
        End If

        If x = Nothing Then
            x = TextBox1.Text
        End If

        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        TextBox1.Text = "+"
        Ope = 1
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Ope <> 0 Then
            Calc()
        End If

        Button11.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        If x = Nothing Then
            x = TextBox1.Text
        End If

        TextBox1.Text = "-"
        Ope = 2
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If Ope <> 0 Then
            Calc()
        End If

        Button11.Enabled = False
        Button12.Enabled = False
        Button14.Enabled = False
        If x = Nothing Then
            x = TextBox1.Text
        End If

        TextBox1.Text = "×"
        Ope = 3
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Ope <> 0 Then
            Calc()
        End If

        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        If x = Nothing Then
            x = TextBox1.Text
        End If
        TextBox1.Text = "/"
        Ope = 4

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If Ope = 0 Then
            Return
        Else
            Calc()
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        TextBox1.Text = "0"
        x = Nothing
        Ope = Nothing
    End Sub
End Class