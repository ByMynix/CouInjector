Imports System.IO
Module Module1
    Dim AppPath = System.AppDomain.CurrentDomain.BaseDirectory
    Sub Main()
        Console.Title = "CouInjector Auto-Updater"
        Console.WriteLine("Wait for exit...(CouInjector)")
        System.Threading.Thread.Sleep(3000)
        Dim T As New Process
        With T
            For Each p1 As Process In Process.GetProcessesByName("CouInjector")
                p1.WaitForExit()
            Next
        End With

        Console.WriteLine("Deleting old version...")
        System.Threading.Thread.Sleep(3000)
        File.Delete(AppPath & "\CouInjector.exe")
        Console.WriteLine("Downloading new version...")
        System.Threading.Thread.Sleep(3000)
        Dim uri As System.Uri = New System.Uri("https://bymynix.de/couinjector/CouInjector.exe")
        Dim webclient As System.Net.WebClient = New System.Net.WebClient()
        Dim path As String = New String(AppPath & "\CouInjector.exe")
        Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(path)

        webclient.DownloadFile(uri, path)

        MsgBox("Update successfully downloaded. CouInjector starts automatically")
        Process.Start(AppPath & "\CouInjector.exe")
    End Sub
End Module
