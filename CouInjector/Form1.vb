Imports System.IO
Imports System.Net
Imports System.Threading
Public Class Form1
    Private WithEvents CSGOExit As Thread
    Private WithEvents InjectionExit As Thread
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            OpenFileDialog1.Filter = "Select your cheat|*.dll|All|*.*"
            OpenFileDialog1.ShowDialog()
            My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, "C:\CouInjector\ServiceHub.Microsoft.dll", overwrite:=True)
            MetroButton1.Enabled = True
        Catch ex As System.ArgumentNullException
            MessageBox.Show("No File selected")
        Catch ex As System.IO.IOException
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim p = Process.GetProcessesByName("csgo")
        If p.Count > 0 Then
            MetroButton1.Enabled = False
            MetroButton2.Enabled = False
            My.Computer.FileSystem.WriteAllBytes(System.Environment.CurrentDirectory & "\ServiceHub.TaskRun.Microsoft.exe", My.Resources.Injection, False)
            Process.Start(System.Environment.CurrentDirectory & "\ServiceHub.TaskRun.Microsoft.exe")
            My.Computer.Audio.Play(My.Resources.InjectSound, AudioPlayMode.WaitToComplete)
            Dim InjectionExit As New Threading.Thread(AddressOf WaitingforExitInjection)
            InjectionExit.Start()
            While InjectionExit.IsAlive
                Application.DoEvents()
            End While
            File.Delete(System.Environment.CurrentDirectory & "\ServiceHub.TaskRun.Microsoft.exe")
            Dim CSGOExit As New Threading.Thread(AddressOf WaitingforExitCSGO)
            CSGOExit.Start()
            While CSGOExit.IsAlive
                Application.DoEvents()
            End While
            MetroButton1.Enabled = False
            MetroButton2.Enabled = True
        Else
            MessageBox.Show("Process not found! Start CSGO first before you try to inject")
        End If
    End Sub

    Private Sub WaitingforExitCSGO()
        Dim T As New Process
        With T
            For Each p1 As Process In Process.GetProcessesByName("csgo")
                p1.WaitForExit()
            Next
        End With
    End Sub

    Private Sub WaitingforExitInjection()
        Dim T As New Process
        With T
            For Each p1 As Process In Process.GetProcessesByName("ServiceHub.TaskRun.Microsoft")
                p1.WaitForExit()
            Next
        End With
    End Sub

    Private Sub MetroLabel1_Click(sender As Object, e As EventArgs) Handles MetroLabel1.Click
        MessageBox.Show("=====================

--How to Use--

- Turn off any antivirus on your computer
- Start CSGO
- Click on [Choose File] and select your cheat (.dll file)
- Click on [Inject]
- Enjoy !

--------------")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.ToggleChecked = "False" Then
            MetroToggle2.Checked = False
        Else
            Process.Start("http://dsc.gg/bymynixde")
            Process.Start("https://bit.ly/bymynix--developments")
            Process.Start("https://bit.ly/github-couinjector-bymynix")
        End If
        Dim client As WebClient = New WebClient()
        If "No Updates available!" = client.DownloadString("https://bymynix.de/couinjector/Update%20Checker%201.9.txt") Then

        Else
            MessageBox.Show("New update available! The update will start automatically.")
            Dim h As New Form2
            h.Show()
            Me.Close()
        End If
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try
            Process.Start("C:\CouInjector\Repair.exe")
            Me.Close()
        Catch ex As FileNotFoundException
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("http://dsc.gg/bymynixde")
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Process.Start("https://bit.ly/bymynix--developments")
    End Sub

    Private Sub MetroToggle2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroToggle2.Click
        If MetroToggle2.Checked = False Then
            My.Settings.ToggleChecked = "False"
            MetroToggle2.Checked = False
            My.Settings.Save()
        End If
        If MetroToggle2.Checked = True Then
            My.Settings.ToggleChecked = "True"
            MetroToggle2.Checked = True
            My.Settings.Save()
        End If
    End Sub

    Private Sub MetroLink2_Click(sender As Object, e As EventArgs) Handles MetroLink2.Click
        Process.Start("https://bymynix.de/couinjector/")
    End Sub
End Class
