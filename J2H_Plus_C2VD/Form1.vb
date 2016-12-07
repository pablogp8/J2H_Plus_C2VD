Public Class Form1

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        NuevaTabPage()
    End Sub

    Sub NuevaTabPage()

        Dim tbP1 As New TabPage()
        Dim cuadroTxt As New ScintillaNET.Scintilla()

        cuadroTxt.Width = 693
        cuadroTxt.Height = 325
        cuadroTxt.Margins.Margin0.Width = 20
        cuadroTxt.Text = "Scintilla1"
        tbP1.Controls.Add(cuadroTxt)
        tbP1.Text = "Nuevo Editor"
        TabControl1.TabPages.Add(tbP1)

    End Sub

End Class
