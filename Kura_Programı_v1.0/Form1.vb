Imports Microsoft.Office.Interop

Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim yeni As String
        Dim varmý As Integer
        yeni = TextBox1.Text
        varmý = ListBox1.Items.IndexOf(yeni)
        If yeni = "Kayýt Bulunmakta..." Then
        Else
            If varmý = -1 Then
                If yeni = "" Then
                    MsgBox("Lütfen Ýsim Giriniz", MsgBoxStyle.Information, "Dikkat")
                Else
                    ListBox1.Items.Add(yeni) //yeni item ekler
                End If
                TextBox1.Clear()
            Else
                TextBox1.Clear()
                Timer1.Start()
                Timer2.Start()
            End If
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim seçili As Integer
        seçili = ListBox1.SelectedIndex
        If seçili <> -1 Then
            ListBox1.Items.RemoveAt(seçili)
        Else
            MsgBox("Önce Silmek Ýstediðiniz Elemaný Seçiniz...", MsgBoxStyle.Exclamation, "Dikkat")
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ListBox2.Items.Count > ListBox1.Items.Count Then
        Else
            If ListBox1.Items.Count = 0 Then
                MsgBox("Henüz Kuraya Giricek Kiþileri Eklemediniz", MsgBoxStyle.Exclamation, "Dikkat")
            Else

1:              Randomize()
                Dim elemans As Integer
                Dim rasgele As Integer
                Dim atanacak As String
                elemans = ListBox1.Items.Count - 1
                rasgele = Rnd() * elemans
                atanacak = ListBox1.Items(rasgele)
                If ListBox2.Items.IndexOf(atanacak) = -1 Then
                    ListBox2.Items.Add(atanacak)
                Else
                    If ListBox2.Items.Count = ListBox1.Items.Count Then
                        MsgBox("Sýnýra Ulaþtýnýz Yeteri Kadar Kiþi Zaten Seçtiniz", MsgBoxStyle.Information, "Dikkat")
                    Else
                        GoTo 1
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub YeniKuraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YeniKuraToolStripMenuItem.Click
        Dim mesaj As MsgBoxResult
        mesaj = MsgBox("Yeni Kura Çekmek Ýstediðinize Eminmisiniz? Önceki Kura Silinecektir..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Dikkat")
        If mesaj = MsgBoxResult.Yes Then
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub KuradaSeçilenleriKayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KuradaSeçilenleriKayToolStripMenuItem.Click
        Dim i As Integer
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            For i = 0 To ListBox2.Items.Count - 1
                If i = 0 Then
                    IO.File.AppendAllText(SaveFileDialog1.FileName, ListBox2.Items(i))
                Else
                    IO.File.AppendAllText(SaveFileDialog1.FileName, vbCrLf & ListBox2.Items(i))
                End If
            Next
        End If
    End Sub
    Private Sub HakkýndaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HakkýndaToolStripMenuItem.Click
        MsgBox("FrmTR.Com üyelerinin fikrinden doðan bir harikadýr herkese teþekkürler.. ---v.1.2--" & vbCrLf & "KodLayan : heavenskhan")
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Label1.Text = 0 Then
            Label1.Text = 1
            TextBox1.Text = ""
            Timer1.Stop()
            Timer2.Stop()
        Else
            Label1.Text -= 1
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TextBox1.Text = "Kayýt Bulunmakta..."
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HakkýndaToolStripMenuItem_Click(sender, e)

    End Sub
    Dim WordApp As New Word.Application
    Private Sub ListeAçToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeAçToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim metin, uzantý As String
            Dim uzunluk As Integer
            metin = OpenFileDialog1.FileName
            uzunluk = metin.Length
            uzantý = metin.Substring(uzunluk - 3, 3)
            Select Case uzantý
                Case "txt"

                    ListBox1.Items.AddRange(IO.File.ReadAllLines(metin))
                Case "doc"
                    WordApp.Documents.Open(metin)
                    ListBox1.Items.AddRange(WordApp.Documents(0).Sections)

                Case "xls"

            End Select

        End If

    End Sub
End Class
