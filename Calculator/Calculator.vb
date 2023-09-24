Public Class Calculator
    Private Sub Button18_MouseHover(sender As Object, e As EventArgs) Handles Button18.MouseHover
        Button18.Image = Image.FromFile("C:\Users\HP\source\repos\Calculator\Calculator\Resources\Hover.png")
    End Sub
    Private Sub Button18_MouseLeave(sender As Object, e As EventArgs) Handles Button18.MouseLeave
        Button18.Image = Image.FromFile("C:\Users\HP\source\repos\Calculator\Calculator\Resources\Unhover.png")
    End Sub
End Class
