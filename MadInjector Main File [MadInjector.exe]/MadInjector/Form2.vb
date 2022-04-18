Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim uri As System.Uri = New System.Uri("https://bymynix.de/madinjector/MadInjector%20Setup.exe")
        Dim webclient As System.Net.WebClient = New System.Net.WebClient()

        Dim path As String = New String(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "C:\MadInjector\Updater.exe"))
        Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(path)
        If Not System.IO.Directory.Exists(fileInfo.Directory.FullName) Then
            System.IO.Directory.CreateDirectory(fileInfo.Directory.FullName)
        End If


        AddHandler webclient.DownloadFileCompleted, AddressOf webclient_DownloadDataCompleted
        AddHandler webclient.DownloadProgressChanged, AddressOf DownloadProgressChanged

        webclient.DownloadFileAsync(uri, path)
    End Sub

    Private Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As Net.DownloadProgressChangedEventArgs)
        MetroProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub webclient_DownloadDataCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        MessageBox.Show("Update successfully downloaded. The setup starts automatically")
        Try
            Process.Start("C:\MadInjector\Updater.exe")
        Catch ex As Exception
            MessageBox.Show("File not found! Your antivirus may have removed the update files. Check that your antivirus is deactivated. The program will close automatically")
            Me.Close()
        End Try
        Me.Close()





    End Sub
End Class