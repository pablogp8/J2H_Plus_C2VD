Imports System.IO
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        txtBuscar.Text = TabControl1.SelectedIndex

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NuevaTabPage()
    End Sub



    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        GuardarArch()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        AbrirArch()
    End Sub

    Sub GuardarArch()

        If TabControl1.SelectedIndex > -1 Then
            txtRemplazar.Text = TabControl1.SelectedTab.Controls.Item(0).Text
            If guardarCuadroD.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim oSW As New StreamWriter(guardarCuadroD.FileName)
                'estado = True
                'Dim Linea As String = "Línea de texto " & vbNewLine & "Otra linea de texto"
                oSW.WriteLine(TabControl1.SelectedTab.Controls.Item(0).Text)
                oSW.Flush()
            End If

        End If
        ' guardarCuadroD.ShowDialog()
    End Sub

    Sub AbrirArch()
        If abrirCuadroD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim SPath As String = abrirCuadroD.FileName
                Dim sContent As String = vbNullString


                With My.Computer.FileSystem
                    ' verifica si existe el path  
                    If .FileExists(SPath) Then
                        ' lee todo el contenido  
                        sContent = .ReadAllText(SPath)
                        TabControl1.SelectedTab.Controls.Item(0).Text = sContent.ToString
                        TabControl1.SelectedTab.Text = abrirCuadroD.SafeFileName
                    Else
                        MsgBox("ruta invalida", MsgBoxStyle.Critical, "error")
                    End If
                End With
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If

    End Sub
End Class
