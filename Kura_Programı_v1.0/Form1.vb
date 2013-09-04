Imports Microsoft.Office.Interop

Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim yeni As String
        Dim varm� As Integer
        yeni = TextBox1.Text
        varm� = ListBox1.Items.IndexOf(yeni)
        If yeni = "Kay�t Bulunmakta..." Then
        Else
            If varm� = -1 Then
                If yeni = "" Then
                    MsgBox("L�tfen �sim Giriniz", MsgBoxStyle.Information, "Dikkat")
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
        Dim se�ili As Integer
        se�ili = ListBox1.SelectedIndex
        If se�ili <> -1 Then
            ListBox1.Items.RemoveAt(se�ili)
        Else
            MsgBox("�nce Silmek �stedi�iniz Eleman� Se�iniz...", MsgBoxStyle.Exclamation, "Dikkat")
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ListBox2.Items.Count > ListBox1.Items.Count Then
        Else
            If ListBox1.Items.Count = 0 Then
                MsgBox("Hen�z Kuraya Giricek Ki�ileri Eklemediniz", MsgBoxStyle.Exclamation, "Dikkat")
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
                        MsgBox("S�n�ra Ula�t�n�z Yeteri Kadar Ki�i Zaten Se�tiniz", MsgBoxStyle.Information, "Dikkat")
                    Else
                        GoTo 1
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub YeniKuraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YeniKuraToolStripMenuItem.Click
        Dim mesaj As MsgBoxResult
        mesaj = MsgBox("Yeni Kura �ekmek �stedi�inize Eminmisiniz? �nceki Kura Silinecektir..", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Dikkat")
        If mesaj = MsgBoxResult.Yes Then
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub KuradaSe�ilenleriKayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KuradaSe�ilenleriKayToolStripMenuItem.Click
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
    Private Sub Hakk�ndaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hakk�ndaToolStripMenuItem.Click
        MsgBox("FrmTR.Com �yelerinin fikrinden do�an bir harikad�r herkese te�ekk�rler.. ---v.1.2--" & vbCrLf & "KodLayan : heavenskhan")
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
        TextBox1.Text = "Kay�t Bulunmakta..."
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Hakk�ndaToolStripMenuItem_Click(sender, e)

    End Sub
    Dim WordApp As New Word.Application
    Private Sub ListeA�ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListeA�ToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim metin, uzant� As String
            Dim uzunluk As Integer
            metin = OpenFileDialog1.FileName
            uzunluk = metin.Length
            uzant� = metin.Substring(uzunluk - 3, 3)
            Select Case uzant�
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
