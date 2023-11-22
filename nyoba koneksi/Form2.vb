Public Class Form2


    Sub bukakunci()
        LOGINToolStripMenuItem.Visible = False
        LOGOUTToolStripMenuItem.Visible = True
        DATAToolStripMenuItem.Visible = True
        'Form2.MENUToolStripMenuItem.Enabled = True
    End Sub
    Sub tutupkunci()
        LOGINToolStripMenuItem.Visible = True
        LOGOUTToolStripMenuItem.Visible = False
        DATAToolStripMenuItem.Visible = False
        'Form2.MENUToolStripMenuItem.Enabled = False
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tutupkunci()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
    End Sub

    Private Sub LOGINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGINToolStripMenuItem.Click
        Form1.ShowDialog()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Call tutupkunci()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form5.ShowDialog()
    End Sub

    Private Sub ADMINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADMINToolStripMenuItem.Click
        Form6.ShowDialog()
    End Sub

    Private Sub KRITIKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KRITIKToolStripMenuItem.Click
        Form7.ShowDialog()
    End Sub

    Private Sub FILEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FILEToolStripMenuItem.Click

    End Sub
End Class