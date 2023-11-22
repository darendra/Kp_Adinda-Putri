Imports System.Data.Odbc
Public Class Form5
    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.ResetText()
        Call munculgridpesan()
        Call urutankode()
    End Sub

    Sub urutankode()
        Call koneksi()
        Cmd = New OdbcCommand("Select * from tb_saran where Id_pesan in (select max(Id_pesan) from tb_saran)", Conn)
        Dim urutankode As String
        Dim hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            urutankode = "USR" + "001"
        Else
            hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            urutankode = "USR" + Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        TextBox1.Text = urutankode
    End Sub

    Sub munculgridpesan()
        Call koneksi()
        Call koneksi()
        Da = New OdbcDataAdapter("Select * from tb_saran", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tb_saran")
        dgsaran.DataSource = Ds.Tables("tb_saran")
        'responsive dg
        dgsaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
        Call urutankode()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If Button1.Text = "KIRIM" Then
        '    Button1.Text = "SIMPAN"
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
        'End If


        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Pastikan Field Terisi semuanya!")
        Else
            Call koneksi()
            Dim InputData As String = "insert into tb_saran values ('" & TextBox1.Text & "','" & DateTimePicker1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            Cmd = New OdbcCommand(InputData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Saran & Kritik Anda telah tersampaikan!!")
            Call kondisiawal()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class