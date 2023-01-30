Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class Form1

    Dim con As New SqlConnection(My.Settings.Setting)
    Dim proceso, mensaje As String
    Sub EjecutarEnSQL(ByVal sql As String, ByVal msg As String)
        Try
            Dim cmd As New SqlCommand(sql, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox(msg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim TipoDeCuenta As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TipoDeCuenta = ""

        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Try
                Dim da As New SqlDataAdapter("if exists (select * from loginn where nombre = 'adm" + TextBox1.Text + "' and contra = 'ads" + TextBox2.Text + "') select* from loginn;", con)
                Dim ds As New DataSet
                da.Fill(ds)
                Me.dtgv.DataSource = ds.Tables(0)
                TipoDeCuenta = "1"
            Catch ex As Exception
            End Try

            Try
                Dim da As New SqlDataAdapter("if exists (select * from loginn where nombre = 'sec" + TextBox1.Text + "' and contra = 'sec" + TextBox2.Text + "') select* from loginn;", con)
                Dim ds As New DataSet
                da.Fill(ds)
                Me.dtgv.DataSource = ds.Tables(0)
                TipoDeCuenta = "2"
            Catch ex As Exception
            End Try


            Try
                Dim da As New SqlDataAdapter("if exists (select * from loginn where nombre = 'cli" + TextBox1.Text + "' and contra = 'cli" + TextBox2.Text + "') select* from loginn;", con)
                Dim ds As New DataSet
                da.Fill(ds)
                Me.dtgv.DataSource = ds.Tables(0)
                TipoDeCuenta = "3"
            Catch ex As Exception
            End Try


            If TipoDeCuenta = "1" Then
                Me.Hide()
                admin.Show()
                admin.Label2.Text = "Administrador"

            ElseIf TipoDeCuenta = "2" Then
                Me.Hide()
                sec.Show()
                sec.lbl_secretario.Text = "Secretario/a"

            ElseIf TipoDeCuenta = "3" Then
                Me.Hide()
                cli.Show()
                cli.lbl_cliente.Text = "Cliente"

            Else
                MsgBox("Contraseña o nombre de usuario incorrecto")
            End If

        Else
            MsgBox("Faltan Datos")
        End If

    End Sub


End Class
