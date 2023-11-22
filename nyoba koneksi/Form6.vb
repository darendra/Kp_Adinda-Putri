Imports System.Data.Odbc
Public Class Form6

    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Call munculgrid()
    End Sub

    Sub munculgrid()
        Call koneksi()
        Da = New OdbcDataAdapter("Select * from tb_register", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tb_register")
        DG1.DataSource = Ds.Tables("tb_register")
        'responsive dg
        DG1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()
        Dim edit As String = "update tb_register set Nama='" & TextBox2.Text & "',Password='" & TextBox3.Text & "' where id='" & TextBox1.Text & "'"
        Cmd = New OdbcCommand(edit, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Edit Data Berhasil")
        Call kondisiawal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Pastikan semua terisi!")
        Else
            Call koneksi()
            Dim InputData As String = "insert into tb_register values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
            Cmd = New OdbcCommand(InputData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Admin baru sudah ditambahkan")
            Call kondisiawal()
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            Cmd = New OdbcCommand("Select * from tb_register where id='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Id Admin tidak ada")
            Else
                TextBox1.Text = Rd.Item("id")
                TextBox2.Text = Rd.Item("Nama")
                TextBox3.Text = Rd.Item("Password")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        Dim hapus As String = "delete from tb_register where id='" & TextBox1.Text & "'"
        Cmd = New OdbcCommand(hapus, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Data Berhasil di Hapus", MsgBoxStyle.Information, "INFORMATION")
        Call kondisiawal()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call kondisiawal()
    End Sub
End Class