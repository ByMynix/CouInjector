Imports System.IO
Imports System.Net
Imports System.Threading
Public Class Form1
    Private WithEvents CSGOExit As Thread
    Private WithEvents InjectionExit As Thread
    Private WithEvents VACExit As Thread
    Private WithEvents SteamExit As Thread

    Dim AppPath = System.AppDomain.CurrentDomain.BaseDirectory
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            OpenFileDialog1.Filter = "Select your cheat|*.dll|All|*.*"
            OpenFileDialog1.ShowDialog()
            My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, AppPath & "\ServiceHub.Microsoft.dll", overwrite:=True)
            MetroButton1.Enabled = True
            Label2.Text = "Selected file: " + OpenFileDialog1.FileName
        Catch ex As System.ArgumentNullException
            Label2.Text = "No File selected"
        Catch ex As System.IO.IOException
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Dim p = Process.GetProcessesByName("csgo")
        If p.Count > 0 Then
            MetroButton1.Enabled = False
            MetroButton2.Enabled = False
            Label2.Text = "Preparing injection..."
            My.Computer.FileSystem.WriteAllBytes(AppPath & "\ServiceHub.TaskRun.Microsoft.exe", My.Resources.Injection, False)
            Process.Start(AppPath & "\ServiceHub.TaskRun.Microsoft.exe")
            My.Computer.Audio.Play(My.Resources.InjectSound, AudioPlayMode.WaitToComplete)
            Label2.Text = "Successfully injected!"
            Dim InjectionExit As New Threading.Thread(AddressOf WaitingforExitInjection)
            InjectionExit.Start()
            While InjectionExit.IsAlive
                Application.DoEvents()
            End While
            IO.File.Delete(AppPath & "\ServiceHub.TaskRun.Microsoft.exe")
            Dim CSGOExit As New Threading.Thread(AddressOf WaitingforExitCSGO)
            CSGOExit.Start()
            Label2.Text = "Have fun to cheat! [Wait for CSGO exit, to clean up files]"
            While CSGOExit.IsAlive
                Application.DoEvents()
            End While
            IO.File.Delete(AppPath & "\ServiceHub.Microsoft.dll")
            MetroButton1.Enabled = False
            MetroButton2.Enabled = True
            Label2.Text = "Cleaned up files!"
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
- Click on [Start VAC-ByPass]
- Start CSGO
- Click on [Choose File] and select your cheat (.dll file)
- Click on [Inject]
- Enjoy !

--------------")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(AppPath & "\Updater.exe") Then
            IO.File.Delete(AppPath & "\Updater.exe")
        Else
        End If
        If My.Settings.ToggleChecked1 = "False" Then
            MetroToggle1.Checked = False
        Else
            Dim WSH As Object = CreateObject("WScript.Shell")
            WSH = CreateObject("WScript.Shell")
            Dim MyShortcut, DesktopPath
            DesktopPath = WSH.SpecialFolders("Desktop")

            MyShortcut = WSH.CreateShortcut(DesktopPath & "\CouInjector.lnk")
            MyShortcut.TargetPath = WSH.ExpandEnvironmentStrings(AppPath & "\CouInjector.exe")
            MyShortcut.WorkingDirectory = WSH.ExpandEnvironmentStrings(AppPath)
            MyShortcut.WindowStyle = 1
            MyShortcut.IconLocation = AppPath & "\CouInjector.exe"
            MyShortcut.Save()
        End If
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
            My.Computer.FileSystem.WriteAllBytes(AppPath & "\Updater.exe", My.Resources.Updater, False)
            MessageBox.Show("New update available! The Updater will start automatically.")
            Process.Start(AppPath & "\Updater.exe")
            Me.Close()
        End If
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

    Private Sub MetroToggle1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroToggle1.Click
        If MetroToggle1.Checked = False Then
            My.Settings.ToggleChecked1 = "False"
            MetroToggle1.Checked = False
            My.Settings.Save()
            If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) & "\CouInjector.lnk") Then
                IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) & "\CouInjector.lnk")
            End If
        End If

        If MetroToggle1.Checked = True Then
            My.Settings.ToggleChecked1 = "True"
            MetroToggle1.Checked = True
            My.Settings.Save()

            Dim WSH As Object = CreateObject("WScript.Shell")
            WSH = CreateObject("WScript.Shell")
            Dim MyShortcut, DesktopPath
            DesktopPath = WSH.SpecialFolders("Desktop")

            MyShortcut = WSH.CreateShortcut(DesktopPath & "\CouInjector.lnk")
            MyShortcut.TargetPath = WSH.ExpandEnvironmentStrings(AppPath & "\CouInjector.exe")
            MyShortcut.WorkingDirectory = WSH.ExpandEnvironmentStrings(AppPath)
            MyShortcut.WindowStyle = 1
            MyShortcut.IconLocation = AppPath & "\CouInjector.exe"
            MyShortcut.Save()
        End If
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        My.Computer.FileSystem.WriteAllBytes(AppPath & "\ServiceHub2.TaskRun.Microsoft.exe", My.Resources.VAC_ByPass, False)
        Process.Start(AppPath & "\ServiceHub2.TaskRun.Microsoft.exe")
        Label1.ForeColor = Color.Lime
        Label1.Text = "VAC-ByPass-Status:  Active"
        MetroButton3.Enabled = False
        Dim VACExit As New Threading.Thread(AddressOf WaitingforVACExit)
        VACExit.Start()
        While VACExit.IsAlive
            Application.DoEvents()
        End While
        IO.File.Delete(AppPath & "\ServiceHub2.TaskRun.Microsoft.exe")
        Dim SteamExit As New Threading.Thread(AddressOf WaitingforSteamExit)
        SteamExit.Start()
        While SteamExit.IsAlive
            Application.DoEvents()
        End While
        Label1.ForeColor = Color.Red
        Label1.Text = "VAC-ByPass-Status:  Inactive"
        MetroButton3.Enabled = True
    End Sub

    Private Sub WaitingforVACExit()
        Dim T As New Process
        With T
            For Each p1 As Process In Process.GetProcessesByName("ServiceHub2.TaskRun.Microsoft")
                p1.WaitForExit()
            Next
        End With
    End Sub

    Private Sub WaitingforSteamExit()
        Dim T As New Process
        With T
            For Each p1 As Process In Process.GetProcessesByName("Steam")
                p1.WaitForExit()
            Next
        End With
    End Sub
End Class
