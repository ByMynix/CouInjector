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
            My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, "C:\CouInjector\ServiceHub.Microsoft.dll", overwrite:=True)
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
                info.FileName = ("C:\CouInjector\ServiceHub.Microsoft.exe")
                info.Verb = "runas"
                Process.Start(info)
                My.Computer.Audio.Play("C:\CouInjector\ServiceHub.MicrosoftSound.wav", AudioPlayMode.Background)
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
        If File.Exists("C:\CouInjector\Settings.txt") Then
            MetroToggle2.Checked = False
        Else
            Process.Start("http://dsc.gg/bymynixde")
            Process.Start("https://bit.ly/bymynix--developments")
            Process.Start("https://bit.ly/github-couinjector-bymynix")
        End If
        Dim client As WebClient = New WebClient()
        If "No Updates available!" = client.DownloadString("https://bymynix.de/couinjector/Update%20Checker%201.9.txt") Then

        Else
            Timer1.Interval = 3 * 1000
            Timer1.Start()
        End If
        MetroButton1.Enabled = False
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try
            Dim info As New ProcessStartInfo
            info.FileName = ("C:\CouInjector\Repair.exe")
            info.Verb = "runas"
            Process.Start(info)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("File not found! Your antivirus may have removed the essential files. Check that your antivirus is deactivated and reinstall CouInjector")
        End Try
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Dim url As String = "https://bymynix.de/couinjector/Changelogs.txt"
        Try
            Using wc As New System.Net.WebClient()
                MsgBox(wc.DownloadString(url))
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        MessageBox.Show("New update available! The update will start automatically.")
        Dim h As New Form2
        h.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("http://dsc.gg/bymynixde")
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Process.Start("https://bit.ly/bymynix--developments")
    End Sub

    Private Sub MetroToggle2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroToggle2.Click
        If MetroToggle2.Checked = False Then
            System.IO.File.Create("C:\CouInjector\Settings.txt").Close()
        End If
        If MetroToggle2.Checked = True And File.Exists("C:\CouInjector\Settings.txt") Then
            System.IO.File.Delete("C:\CouInjector\Settings.txt")
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Process.Start("https://cheater.fun/")
    End Sub
End Class
