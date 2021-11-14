Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Threading
Imports System.Diagnostics
Imports System.Diagnostics.Process
Public Class Form1
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            OpenFileDialog1.ShowDialog()
            My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, "C:\MadInjector\ServiceHub.Microsoft.dll", overwrite:=True)
            MetroButton1.Enabled = True
        Catch ex As Exception
            MessageBox.Show("No File selected")
        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Dim p = Process.GetProcessesByName("csgo")
            If p.Count > 0 Then
                Dim info As New ProcessStartInfo
                info.FileName = ("C:\MadInjector\ServiceHub.Microsoft.exe")
                info.Verb = "runas"
                Process.Start(info)
                My.Computer.Audio.Play("C:\MadInjector\ServiceHub.MicrosoftSound.wav", AudioPlayMode.Background)
            Else
                MessageBox.Show("Process not found! Start CSGO first before you try to inject")
            End If
        Catch ex As Exception
            MessageBox.Show("File not found! Your antivirus may have removed the essential files. Check that your antivirus is deactivated and use the 'Repair all Files' method")
        End Try
    End Sub

    Private Sub MetroLabel1_Click(sender As Object, e As EventArgs) Handles MetroLabel1.Click
        MessageBox.Show("=====================

--How to Use--

- Turn off any antivirus on your computer
- Start CSGO
- Click on [Choose File] and choose your file (cheat.dll)
- Click on [Inject]
- Enjoy !

--------------")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists("C:\MadInjector\Settings.txt") Then
            MetroToggle2.Checked = False
        Else
            Process.Start("http://discord.bymynix.xyz/")
            Process.Start("https://bit.ly/bymynixdevelopments")
            Process.Start("https://bit.ly/github-madinjector-bymynix")
        End If
        Dim client As WebClient = New WebClient()
        If MetroTextBox1.Text = client.DownloadString("https://madinjector.bymynix.xyz/Update%20Checker%201.7.txt") Then

        Else
            Timer1.Interval = 3 * 1000
            Timer1.Start()
        End If
        MetroButton1.Enabled = False
    End Sub

    Private Sub MetroLink2_Click(sender As Object, e As EventArgs)
        Process.Start("https://bit.ly/cheatermad")
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try
            Dim info As New ProcessStartInfo
            info.FileName = ("C:\MadInjector\Repair.exe")
            info.Verb = "runas"
            Process.Start(info)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("File not found! Your antivirus may have removed the essential files. Check that your antivirus is deactivated and reinstall MadInjector")
        End Try
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Dim url As String = "https://madinjector.bymynix.xyz/Changelogs.txt"
        Try
            Using wc As New System.Net.WebClient()
                MsgBox(wc.DownloadString(url))
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MessageBox.Show("New update available! The update will start automatically.")
        Dim h As New Form2
        h.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("http://discord.bymynix.xyz/")
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Process.Start("https://projects.bymynix.xyz/")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Process.Start("https://corsair.wtf/")
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Process.Start("https://bit.ly/cheaterninja")
    End Sub

    Private Sub MetroLink2_Click_1(sender As Object, e As EventArgs) Handles MetroLink2.Click
        Process.Start("https://bit.ly/cheatermad")
    End Sub

    Private Sub MetroToggle2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroToggle2.Click
        If MetroToggle2.Checked = False Then
            System.IO.File.Create("C:\MadInjector\Settings.txt").Close()
        End If
        If MetroToggle2.Checked = True And File.Exists("C:\MadInjector\Settings.txt") Then
            System.IO.File.Delete("C:\MadInjector\Settings.txt")
        End If
    End Sub
End Class
