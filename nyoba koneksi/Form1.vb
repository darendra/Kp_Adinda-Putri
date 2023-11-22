Imports System.Data.Odbc
Public Class Form1

    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        Call koneksi()
    End Sub




    Sub bukakunci()
        Form2.LOGINToolStripMenuItem.Visible = False
        Form2.LOGOUTToolStripMenuItem.Visible = True
        Form2.DATAToolStripMenuItem.Visible = True
        'Form2.MENUToolStripMenuItem.Enabled = True
    End Sub

    Sub tutupkunci()
        Form2.LOGINToolStripMenuItem.Visible = True
        Form2.LOGOUTToolStripMenuItem.Visible = False
        Form2.DATAToolStripMenuItem.Visible = False
        'Form2.MENUToolStripMenuItem.Enabled = False
    End Sub

    'Sub munculgrid()
    'Call koneksi()
    'Da = New OdbcDataAdapter("Select * from tb_register", Conn)
    'Ds = New DataSet
    'Da.Fill(Ds, "tb_register")
    'dg1.DataSource = Ds.Tables("tb_register")
    'responsive dg
    'dg1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    'End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        Cmd = New OdbcCommand("Select * from tb_register where Nama = '" & TextBox1.Text & "' and Password ='" & TextBox2.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Me.Close()
            Call bukakunci()
        Else
            MsgBox("USERNAME atau PASSWORD Salah!!")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
        End If
    End Sub
End Class
