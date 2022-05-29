Imports System.IO
Imports System.Threading
Module Module1
    Sub Main()
        Console.WriteLine("Wait for exit...(CouInjector)")
        Dim T As New Process
        With T
            For Each p1 As Process In Process.GetProcessesByName("CouInjector")
                p1.WaitForExit()
            Next
        End With

        Console.WriteLine("Deleting old version...")
        File.Delete(Environment.CurrentDirectory & "\CouInjector.exe")
        Console.WriteLine("Downloading new version...")
        Dim uri As System.Uri = New System.Uri("https://bymynix.de/couinjector/CouInjector.exe")
        Dim webclient As System.Net.WebClient = New System.Net.WebClient()

        Dim path As String = New String(System.Environment.CurrentDirectory & "\CouInjector.exe")
        Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(path)


        AddHandler webclient.DownloadFileCompleted, AddressOf webclient_DownloadDataCompleted

        webclient.DownloadFileAsync(uri, path)
    End Sub

    Private Sub webclient_DownloadDataCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        MsgBox("Update successfully downloaded. CouInjector starts automatically")

        Process.Start(System.Environment.CurrentDirectory & "\CouInjector.exe")



    End Sub
End Module
