Imports System.Data.Odbc
Public Class Form7

    'Sub urutankode()
    '    Call koneksi()
    '    Cmd = New OdbcCommand("Select * from tb_saran where Id_pesan in (select max(Id_pesan) from tb_saran)", Conn)
    '    Dim urutankode As String
    '    Dim hitung As Long
    '    Rd = Cmd.ExecuteReader
    '    Rd.Read()
    '    If Not Rd.HasRows Then
    '        urutankode = "USR" + "001"
    '    Else
    '        hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
    '        urutankode = "USR" + Microsoft.VisualBasic.Right("000" & hitung, 3)
    '    End If
    '    TextBox1.Text = urutankode
    'End Sub

    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.ResetText()
        Call munculgrid()
    End Sub

    Sub munculgrid()
        Call koneksi()
        Da = New OdbcDataAdapter("Select * from tb_saran", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tb_saran")
        DG1.DataSource = Ds.Tables("tb_saran")
        'responsive dg
        DG1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
        'Call urutankode()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Call koneksi()
        Dim edit As String = "update tb_saran set Nama_Anda='" & TextBox2.Text & "',Tanggal='" & DateTimePicker1.Text & "',Email_Anda='" & TextBox3.Text & "',Saran_Kritik='" & TextBox4.Text & "' where id_pesan='" & TextBox1.Text & "'"
        Cmd = New OdbcCommand(edit, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Edit Data Berhasil")
        Call kondisiawal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()
        Dim hapus As String = "delete from tb_saran where id_pesan='" & TextBox1.Text & "'"
        Cmd = New OdbcCommand(hapus, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Data Berhasil di Hapus", MsgBoxStyle.Information, "INFORMATION")
        Call kondisiawal()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            Cmd = New OdbcCommand("Select * from tb_saran where id_pesan='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Id Admin tidak ada")
            Else
                TextBox1.Text = Rd.Item("id_pesan")
                DateTimePicker1.Value = Rd.Item("Tanggal")
                TextBox2.Text = Rd.Item("Nama_Anda")
                TextBox3.Text = Rd.Item("Email_Anda")
                TextBox4.Text = Rd.Item("Saran_Kritik")
            End If
        End If
    End Sub

    Private Sub DG1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    ' cell klik
    'Private Sub DG1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.CellClick
    '    Dim i As Integer
    '    i = DG1.CurrentRow.Index

    '    TextBox1.Text = DG1.Item(0, i).Value
    '    TextBox2.Text = DG1.Item(1, i).Value
    '    TextBox3.Text = DG1.Item(2, i).Value
    '    TextBox4.Text = DG1.Item(3, i).Value

    'End Sub
End Class