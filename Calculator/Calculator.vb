Public Class Calculator
    'Programmer: Roque, Raniel Christian B
    'BSIT-2A
    'Date Finished: September 28 2019
    Dim x As Double
    Dim Ope As Integer = 0
    Private Sub EnableButtons(ByVal enable As Boolean) 'Function to Enable Disabled Buttons
        AddButt.Enabled = enable
        SubButt.Enabled = enable
        MultButt.Enabled = enable
        DivButt.Enabled = enable
        DeciButt.Enabled = enable
        PerButt.Enabled = enable
        EqualButt.Enabled = enable
        Button12.Enabled = enable
        Button13.Enabled = enable

        If enable = False Then ' Change Color when False (Dark to signify disabled)
            AddButt.BackColor = Color.DarkSlateGray
            SubButt.BackColor = Color.DarkSlateGray
            MultButt.BackColor = Color.DarkSlateGray
            DivButt.BackColor = Color.DarkSlateGray
            DeciButt.BackColor = Color.DimGray
            PerButt.BackColor = Color.DimGray
            EqualButt.BackColor = Color.DarkSlateGray
            Button12.BackColor = Color.FromArgb(&H44, &H44, &H44)
            Button13.BackColor = Color.FromArgb(&H44, &H44, &H44)
        Else ' Change when true
            AddButt.BackColor = Color.Teal
            SubButt.BackColor = Color.Teal
            MultButt.BackColor = Color.Teal
            DivButt.BackColor = Color.Teal
            DeciButt.BackColor = Color.Gray
            PerButt.BackColor = Color.Gray
            EqualButt.BackColor = Color.Teal
            Button12.BackColor = Color.DimGray
            Button13.BackColor = Color.DimGray
        End If
    End Sub
    Private Sub History(ByVal ope2 As String) 'History for textbox2 
        If TextBox2.Text = Nothing Then 'Initial number
            TextBox2.Text = TextBox1.Text + " " + ope2 + " "
        ElseIf TextBox2.Text.Substring(TextBox2.Text.Length - 2, 1) = "=" Then 'Clears when you pressed = already + Initial Num
            TextBox2.Clear()
            TextBox2.Text = TextBox1.Text + " " + ope2 + " "
        Else 'Next numbers
            TextBox2.Text += TextBox1.Text + " " + ope2 + " "
        End If
    End Sub
    Private Sub Calc()
        '1 = Add
        '2 = Sub
        '3 = Multi
        '4 = Div
        '5 = Exponent
        '6 = Mod
        If Ope = "1" Then
            x += TextBox1.Text
        ElseIf Ope = "2" Then
            x -= TextBox1.Text
        ElseIf Ope = "3" Then
            x *= TextBox1.Text
        ElseIf Ope = "4" Then
            If TextBox1.Text = "0" Then '0 is Denominator
                x = Nothing
                Ope = Nothing
                TextBox1.Text = "Undefined"
                EnableButtons(False)
                Exit Sub
            Else
                x /= TextBox1.Text
                TextBox1.Text = "/"
                Ope = "4"
            End If
        ElseIf Ope = "5" Then
            x ^= TextBox1.Text
        ElseIf Ope = "6" Then
            x = x Mod TextBox1.Text
        End If

        'Sets Main Textbox + Resets x and Ope
        TextBox1.Text = x
        x = Nothing
        Ope = Nothing
    End Sub

    Private Sub ValAdd(value As String)
        ' 15 Char Limit
        If TextBox1.Text.Length >= 15 Then
            MessageBox.Show("Maximum character limit reached", "Max Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Concatenating Values
        Select Case TextBox1.Text
            Case "0", "+", "-", "×", "/", "Undefined", "^", "MOD", "∞"
                EnableButtons(True)
                TextBox1.Text = value
            Case Else
                TextBox1.Text = TextBox1.Text & value
        End Select
    End Sub
    Private Sub Button18_MouseHover(sender As Object, e As EventArgs) Handles ScienButt.MouseHover
        ScienButt.Image = My.Resources.Hover
    End Sub
    Private Sub Button18_MouseLeave(sender As Object, e As EventArgs) Handles ScienButt.MouseLeave
        ScienButt.Image = My.Resources.Unhover
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles BackButt.Click
        'Back Button (Unless Undefined = Clear)
        If TextBox1.Text = "Undefined" Then
            EnableButtons(True)
            TextBox2.Clear()
            TextBox1.Clear()
        ElseIf TextBox1.Text.Length > 0 Then
            TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1)
        End If
    End Sub
    ' Compiled Buttons 1-10 for 1-9 and 0 for 10
    Private Sub NumberButton_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click
        Dim button As Button = DirectCast(sender, Button)
        ValAdd(button.Text)
    End Sub

    Private Sub DeciButt_Click(sender As Object, e As EventArgs) Handles DeciButt.Click
        ' Ignores if textbox1 has period already
        If TextBox1.Text.Contains(".") Then Return

        ' Char limit
        If TextBox1.Text.Length >= 15 Then
            MessageBox.Show("Maximum character limit reached", "Max Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Select Case TextBox1.Text
            Case "+", "-", "×", "/", "Undefined", "^", "MOD", "∞"
                EnableButtons(True)
                TextBox1.Text = "0."
            Case ""
                TextBox1.Text = "0."
            Case Else
                TextBox1.Text &= "."
        End Select
    End Sub
    ' Percent
    Private Sub PerButt_Click(sender As Object, e As EventArgs) Handles PerButt.Click
        Dim currentValue As Double

        If Double.TryParse(TextBox1.Text, currentValue) Then
            TextBox1.Text /= 100
        Else
            MessageBox.Show("Please enter a valid number first.", "Invalid Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AddButt_Click(sender As Object, e As EventArgs) Handles AddButt.Click
        ' Calls History First for TextBox2
        History("+")

        ' If Operator is 0 then dont Calculate
        If Ope <> 0 Then
            Calc()
        End If

        ' Initial Val
        If x = Nothing Then
            x = TextBox1.Text
        End If

        ' Disables so no error in User Side + Shows "+" on TextBox1 which equates to Operator = 1
        EnableButtons(False)
        TextBox1.Text = "+"
        Ope = 1
    End Sub
    'Same concept as Add all up to Mod (AddButt, SubButt, MultButt, DivButt, Button12, Button13)
    Private Sub SubButt_Click(sender As Object, e As EventArgs) Handles SubButt.Click
        History("-")

        If Ope <> 0 Then
            Calc()
        End If

        EnableButtons(False)
        If x = Nothing Then
            x = TextBox1.Text
        End If

        TextBox1.Text = "-"
        Ope = 2
    End Sub
    Private Sub MultButt_Click(sender As Object, e As EventArgs) Handles MultButt.Click
        History("×")

        If Ope <> 0 Then
            Calc()
        End If

        EnableButtons(False)
        If x = Nothing Then
            x = TextBox1.Text
        End If

        TextBox1.Text = "×"
        Ope = 3
    End Sub
    Private Sub DivButt_Click(sender As Object, e As EventArgs) Handles DivButt.Click
        History("/")

        If Ope <> 0 Then
            Calc()
        End If

        EnableButtons(False)
        If x = Nothing Then
            x = TextBox1.Text
        End If
        TextBox1.Text = "/"
        Ope = 4

    End Sub
    ' Same Concept except when Ope is 0 (Which means its only an initial value) it does nothing
    Private Sub EqualButt_Click(sender As Object, e As EventArgs) Handles EqualButt.Click
        If Ope = 0 Then
            Return
        Else
            TextBox2.Text += TextBox1.Text + " = "
            Calc()
        End If
    End Sub

    Private Sub DelButt_Click(sender As Object, e As EventArgs) Handles DelButt.Click
        Dim result As DialogResult = MessageBox.Show("Clear Data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If result = DialogResult.Yes Then
            ' Perform the following actions if the user clicks Yes
            EnableButtons(True)
            TextBox2.Text = ""
            TextBox1.Text = "0"
            x = Nothing
            Ope = Nothing
        End If
    End Sub
    ' KEYSSSSSSSSSSSSSSSSSSSSSS
    Private Sub Calculator_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyData
            Case Keys.NumPad1, Keys.D1
                Button1.PerformClick()
                Return
            Case Keys.NumPad2, Keys.D2
                Button2.PerformClick()
                Return
            Case Keys.NumPad3, Keys.D3
                Button3.PerformClick()
                Return
            Case Keys.NumPad4, Keys.D4
                Button4.PerformClick()
                Return
            Case Keys.NumPad5, Keys.D5
                Button5.PerformClick()
                Return
            Case Keys.NumPad6, Keys.D6
                Button6.PerformClick()
                Return
            Case Keys.NumPad7, Keys.D7
                Button7.PerformClick()
                Return
            Case Keys.NumPad8, Keys.D8
                Button8.PerformClick()
                Return
            Case Keys.NumPad9, Keys.D9
                Button9.PerformClick()
                Return
            Case Keys.NumPad0, Keys.D0
                Button10.PerformClick()
                Return
            Case Keys.Add
                AddButt.PerformClick()
                Return
            Case Keys.Subtract
                SubButt.PerformClick()
                Return
            Case Keys.Divide
                MultButt.PerformClick()
                Return
            Case Keys.Multiply
                DivButt.PerformClick()
                Return
            Case Keys.Decimal, Keys.OemPeriod
                DeciButt.PerformClick()
                Return
            Case Keys.Back
                BackButt.PerformClick()
                Return
            Case Keys.Delete
                DelButt.PerformClick()
                Return
        End Select
    End Sub
    ' Resizing based if its big or small for scientific buttons
    Private Sub ScienButt_Click(sender As Object, e As EventArgs) Handles ScienButt.Click
        If Me.Size = New Size(321, 518) Then 'Small to big
            TextBox1.Size = New Size(423, 45)
            TextBox2.Size = New Size(423, 45)

            'Changes Buttons Locations
            For Each button As Button In Me.Controls.OfType(Of Button)()
                button.Location = New Point(button.Location.X + 144, button.Location.Y)
            Next

            'Changes Visibility of Scientific Buttons
            For i As Integer = 11 To 20
                Dim buttonName As String = "Button" & i.ToString()
                Dim button As Button = Me.Controls(buttonName)
                button.Visible = True
            Next

            'Form resize
            Me.Size = New Size(464, 518)

        ElseIf Me.Size = New Size(464, 518) Then 'Big to small
            TextBox1.Size = New Size(281, 45)
            TextBox2.Size = New Size(281, 45)

            For i As Integer = 11 To 20
                Dim buttonName As String = "Button" & i.ToString()
                Dim button As Button = Me.Controls(buttonName)
                button.Visible = False
            Next

            For Each button As Button In Me.Controls.OfType(Of Button)()
                button.Location = New Point(button.Location.X - 144, button.Location.Y)
            Next

            Me.Size = New Size(321, 518)
        End If
    End Sub

    Private Sub Calculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Focus() 'ONLY PLACEHOLDER FOR FOCUS

        ' DEFAULT VALUES INCASE EDITING DESIGN CHANGES VALUES OF FORM SIZE + VISIBILITIES & LOCATION
        For i As Integer = 11 To 20
            Dim buttonName As String = "Button" & i.ToString()
            Dim button As Button = Me.Controls(buttonName)
            button.Visible = False
        Next
        For Each button As Button In Me.Controls.OfType(Of Button)()
            button.Location = New Point(button.Location.X - 144, button.Location.Y)
        Next
        TextBox1.Size = New Size(281, 45)
        TextBox2.Size = New Size(281, 45)
        Me.Size = New Size(321, 518)
    End Sub
    'Squared
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim currentValue As Double

        If Double.TryParse(TextBox1.Text, currentValue) Then
            TextBox1.Text ^= 2
        Else
            MessageBox.Show("Please enter a valid number first.", "Invalid Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    'Exponent
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        History("^")

        If Ope <> 0 Then
            Calc()
        End If

        EnableButtons(False)
        If x = Nothing Then
            x = TextBox1.Text
        End If

        TextBox1.Text = "^"
        Ope = 5
    End Sub
    'Modulus
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        History("MOD")

        If Ope <> 0 Then
            Calc()
        End If

        EnableButtons(False)
        If x = Nothing Then
            x = TextBox1.Text
        End If
        TextBox1.Text = "MOD"
        Ope = 6
    End Sub
    'Square Root
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim currentValue As Double

        If Double.TryParse(TextBox1.Text, currentValue) Then
            TextBox1.Text = Math.Sqrt(currentValue)
        Else
            MessageBox.Show("Please enter a valid number first.", "Invalid Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    '1/x
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim currentValue As Double

        If Not Double.TryParse(TextBox1.Text, currentValue) Then
            MessageBox.Show("Please enter a valid number first.", "Invalid Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If TextBox1.Text = "0" Then
            x = Nothing
            Ope = Nothing
            TextBox1.Text = "Undefined"
            EnableButtons(False)
            Return
        End If

        TextBox1.Text = 1 / currentValue
    End Sub
    ' Negative / Positive
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim currentValue As Double

        If Double.TryParse(TextBox1.Text, currentValue) Then
            TextBox1.Text = -currentValue
        Else
            MessageBox.Show("Please enter a valid number first.", "Invalid Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    ' Factorial (if number is more than 170 it would be infinity so we just informed user its too large instead
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim currentValue As Double

        If Not Double.TryParse(TextBox1.Text, currentValue) Then
            MessageBox.Show("Please enter a valid number first.", "Invalid Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If currentValue < 0 Then
            MessageBox.Show("Please enter a non-negative number.", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If currentValue > 170 Then
            MessageBox.Show("Number too large!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim factorial As Double = 1
        For i As Double = 1 To currentValue
            factorial *= i
        Next

        TextBox1.Text = factorial
    End Sub
    'Absolute Value
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim currentValue As Double

        If Double.TryParse(TextBox1.Text, currentValue) Then
            TextBox1.Text = Math.Abs(currentValue)
        Else
            MessageBox.Show("Please enter a valid number first.", "Invalid Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    'Pi
    Private Sub Button19_Click_1(sender As Object, e As EventArgs) Handles Button19.Click
        EnableButtons(True)
        TextBox1.Text = 3.1415926535898
    End Sub
    'Eulers Number
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        EnableButtons(True)
        TextBox1.Text = 2.718281828459
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        MessageBox.Show("Placeholder for Future Compilation", "Placeholder for Future Compilation", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
