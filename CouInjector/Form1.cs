using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;
using ReaLTaiizor.Enum.Poison;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace CouInjector
{
    public partial class Form1 : PoisonForm
    {
        string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public Form1()
        {
            InitializeComponent();
            BorderStyle = ReaLTaiizor.Enum.Poison.FormBorderStyle.FixedSingle;
            ShadowType = FormShadowType.AeroShadow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(AppPath + @"\Updater.exe"))
                System.IO.File.Delete(AppPath + @"\Updater.exe");
            else
            {
            }

            var client = new WebClient();
            if ("No Updates available!" == client.DownloadString("https://bymynix.de/couinjector/Update%20Checker%202.0.txt"))
            {
            }
            else
            {
                System.IO.File.WriteAllBytes(AppPath + @"\Updater.exe", Properties.Resources.Updater);
                PoisonMessageBox.Show(this, "New update available! The Updater will start automatically.", "CouInjector: Update-Checker", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Process.Start(AppPath + @"\Updater.exe");
                Application.Exit();
            }
            if (Properties.Settings.Default.ToggleChecked1 == "False")
                poisonToggle1.Checked = false;
            else
            {
                WshShell wsh = new WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CouInjector.lnk") as IWshRuntimeLibrary.IWshShortcut;
                shortcut.TargetPath = AppPath + @"\CouInjector.exe";
                shortcut.WindowStyle = 1;
                shortcut.WorkingDirectory = AppPath;
                shortcut.IconLocation = AppPath + @"\CouInjector.exe";
                shortcut.Save();
            }
            if (Properties.Settings.Default.ToggleChecked == "False")
                poisonToggle2.Checked = false;
            else
            {
                
            }
        }

        private void poisonTile1_Click_1(object sender, EventArgs e)
        {
            poisonStyleManager1.Theme = poisonStyleManager1.Theme == ThemeStyle.Light ? ThemeStyle.Dark : ThemeStyle.Light;         
        }

        private void poisonLabel10_Click(object sender, EventArgs e)
        {
            PoisonMessageBox.Show(this, "=====================" + Environment.NewLine
+ "- Turn off any antivirus on your computer" + Environment.NewLine
+ "- Click on [Start VAC-ByPass]" + Environment.NewLine
+ "- Start CSGO" + Environment.NewLine
+ "- Click on [Choose File and Inject]" + Environment.NewLine
+ "- Enjoy !" + Environment.NewLine
+ "" + Environment.NewLine
+ "--------------" + Environment.NewLine
+ "", "[How to Use]");
        }

        private void poisonLink3_Click(object sender, EventArgs e)
        {
            Process.Start("https://bymynix.de/couinjector/");
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Process.Start("https://bymynix.de/projects/");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://dsc.gg/bymynixde");
        }

        private void poisonLinkLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ByMynix/CouInjector");
        }

        private void poisonToggle2_Click(object sender, EventArgs e)
        {
            if (poisonToggle2.Checked == false)
            {
                Properties.Settings.Default.ToggleChecked = "False";
                poisonToggle2.Checked = false;
                Properties.Settings.Default.Save();
            }
            if (poisonToggle2.Checked == true)
            {
                Properties.Settings.Default.ToggleChecked = "True";
                poisonToggle2.Checked = true;
                Properties.Settings.Default.Save();
            }
        }

        private void poisonToggle1_Click(object sender, EventArgs e)
        {
            if (poisonToggle1.Checked == false)
            {
                Properties.Settings.Default.ToggleChecked1 = "False";
                poisonToggle1.Checked = false;
                Properties.Settings.Default.Save();
                if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\CouInjector.lnk"))
                    System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\CouInjector.lnk");
            }

            if (poisonToggle1.Checked == true)
            {
                Properties.Settings.Default.ToggleChecked1 = "True";
                poisonToggle1.Checked = true;
                Properties.Settings.Default.Save();

                WshShell wsh = new WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CouInjector.lnk") as IWshRuntimeLibrary.IWshShortcut;
                shortcut.TargetPath = AppPath + @"\CouInjector.exe";
                shortcut.WindowStyle = 1;
                shortcut.WorkingDirectory = AppPath;
                shortcut.IconLocation = AppPath + @"\CouInjector.exe";
                shortcut.Save();
            }
        }

        private void poisonButton3_Click(object sender, EventArgs e)
        {
            string url = "https://bymynix.de/couinjector/Changelogs.txt";
            try
            {
                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    MessageBox.Show(this, wc.DownloadString(url), "Changelogs");
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void poisonButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CSGOInjectionRun(GetPathDLL()))
                {
                    poisonLabel4.Text = "Successfully injected!";
                }
                else
                {
                    PoisonMessageBox.Show(this, "Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetPathDLL()
        {
            string dllPath = string.Empty;

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                fileDialog.Filter = "Select your cheat (*.dll)|*.dll";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    dllPath = fileDialog.FileName;
                }
                else
                {
                    throw new ApplicationException("Dll opening error.");
                }
            }

            return dllPath;
        }

        private static List<FuncDLL> _functions = new List<FuncDLL>()
        {
            new FuncDLL("LoadLibraryExW", "kernel32"),
            new FuncDLL("VirtualAlloc", "kernel32"),
            new FuncDLL("FreeLibrary", "kernel32"),
            new FuncDLL("LoadLibraryExA", "kernel32"),
            new FuncDLL("LoadLibraryW", "kernel32"),
            new FuncDLL("LoadLibraryA", "kernel32"),
            new FuncDLL("VirtualAllocEx", "kernel32"),
            new FuncDLL("LdrLoadDll", "ntdll"),
            new FuncDLL("NtOpenFile", "ntdll"),
            new FuncDLL("VirtualProtect", "kernel32"),
            new FuncDLL("CreateProcessW", "kernel32"),
            new FuncDLL("CreateProcessA", "kernel32"),
            new FuncDLL("VirtualProtectEx", "kernel32"),
            new FuncDLL("FreeLibrary", "KernelBase"),
            new FuncDLL("LoadLibraryExA", "KernelBase"),
            new FuncDLL("LoadLibraryExW", "KernelBase"),
            new FuncDLL("ResumeThread", "KernelBase")
        };

        private static byte[,] originalBytes;
        private static IntPtr hGame = IntPtr.Zero;
        private static UInt32 pid = UInt32.MinValue;

        public static bool CSGOInjectionRun(string pathToDLL)
        {
            Init();

            pid = GetGamePID();

            if (pid == UInt32.MinValue)
            {
                throw new ApplicationException("Process not found! Start CSGO first before you try to inject");
            }

            hGame = OpenProcess(ProcessAccessFlags.All, false, (int)pid);

            if (hGame == IntPtr.Zero)
            {
                throw new ApplicationException("Failed to open process.");
            }

            BypassCSGOHook();
            InjectDLL(pathToDLL);
            RestoreCSGOHook();

            return true;
        }

        private static void Init()
        {
            originalBytes = new byte[17, 6];
            hGame = IntPtr.Zero;
            pid = UInt32.MinValue;
        }

        private static void InjectDLL(string path)
        {
            IntPtr handle = OpenProcess(ProcessAccessFlags.All, false, (Int32)pid);

            if (handle == IntPtr.Zero)
            {
                throw new ApplicationException("Failed to open process.");
            }

            IntPtr size = (IntPtr)path.Length;

            IntPtr DLLMemory = VirtualAllocEx(handle, IntPtr.Zero, size, AllocationType.Reserve | AllocationType.Commit,
                MemoryProtection.ExecuteReadWrite);

            if (DLLMemory == IntPtr.Zero)
            {
                throw new ApplicationException("Memory allocation error.");
            }

            byte[] bytes = Encoding.ASCII.GetBytes(path);

            if (!WriteProcessMemory(handle, DLLMemory, bytes, (int)bytes.Length, out _))
            {
                throw new ApplicationException("Memory read error");
            }

            IntPtr kernel32Handle = GetModuleHandle("Kernel32.dll");
            IntPtr loadLibraryAAddress = GetProcAddress(kernel32Handle, "LoadLibraryA");

            if (loadLibraryAAddress == IntPtr.Zero)
            {
                throw new ApplicationException("Failed to load LoadLibraryA.");
            }

            IntPtr threadHandle = CreateRemoteThread(handle, IntPtr.Zero, 0, loadLibraryAAddress, DLLMemory, 0,
                IntPtr.Zero);

            if (threadHandle == IntPtr.Zero)
            {
                throw new ApplicationException("Failed to create thread.");
            }

            CloseHandle(threadHandle);
            CloseHandle(handle);
        }

        private static UInt32 GetGamePID()
        {
            UInt32 ret = UInt32.MinValue;
            Process[] proc = Process.GetProcessesByName("csgo");

            if (proc.Length == 0)
            {
                return ret;
            }

            IntPtr hwGame = proc[0].MainWindowHandle;

            if (hwGame == IntPtr.Zero)
            {
                return ret;
            }

            GetWindowThreadProcessId(hwGame, out ret);

            return ret;
        }

        private static void BypassCSGOHook()
        {
            for (int i = 0; i < _functions.Count; i++)
            {
                if (!Unhook(_functions[i].MethodName, _functions[i].DLLName, i))
                {
                    throw new ApplicationException($"Failed unhook {_functions[i].MethodName} in {_functions[i].DLLName}.");
                }
            }
        }

        private static void RestoreCSGOHook()
        {
            for (int i = 0; i < _functions.Count; i++)
            {
                if (!RestoreHook(_functions[i].MethodName, _functions[i].DLLName, i))
                {
                    throw new ApplicationException($"Failed restore {_functions[i].MethodName} in {_functions[i].DLLName}.");
                }
            }
        }

        private static bool Unhook(string methodName, string dllName, Int32 index)
        {
            IntPtr originalMethodAddress = GetProcAddress(LoadLibrary(dllName), methodName);

            if (originalMethodAddress == IntPtr.Zero)
            {
                throw new ApplicationException($"The {methodName} address in {dllName} is zero.");
            }

            byte[] originalGameBytes = new byte[6];

            ReadProcessMemory(hGame, originalMethodAddress, originalGameBytes, sizeof(byte) * 6, out _);

            for (int i = 0; i < originalGameBytes.Length; i++)
            {
                originalBytes[index, i] = originalGameBytes[i];
            }

            byte[] originalDLLBytes = new byte[6];

            GCHandle pinnedArray = GCHandle.Alloc(originalDLLBytes, GCHandleType.Pinned);
            IntPtr originalDLLBytesPointer = pinnedArray.AddrOfPinnedObject();

            memcpy(originalDLLBytesPointer, originalMethodAddress, (UIntPtr)(sizeof(byte) * 6));

            return WriteProcessMemory(hGame, originalMethodAddress, originalDLLBytes, sizeof(byte) * 6, out _);
        }

        private static bool RestoreHook(string methodName, string dllName, Int32 index)
        {
            IntPtr originalMethodAdress = GetProcAddress(LoadLibrary(dllName), methodName);

            if (originalMethodAdress == IntPtr.Zero)
            {
                return false;
            }

            byte[] origBytes = new byte[6];

            for (int i = 0; i < origBytes.Length; i++)
            {
                origBytes[i] = originalBytes[index, i];
            }

            return WriteProcessMemory(hGame, originalMethodAdress, origBytes, sizeof(byte) * 6, out _);
        }

        private class FuncDLL
        {
            public string MethodName { get; set; }
            public string DLLName { get; set; }

            public FuncDLL(string methodName, string dllName)
            {
                MethodName = methodName;
                DLLName = dllName;
            }
        }

        #region Win32 DLL Enum

        private const UInt32 INFINITY = 0xFFFFFFFF;

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }


        #endregion

        #region Win32 DLL import

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern IntPtr memcpy(IntPtr dest, IntPtr src, UIntPtr count);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress,
            int dwSize, AllocationType dwFreeType);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);


        #endregion

        private void poisonButton1_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllBytes(AppPath + @"\ServiceHub2.TaskRun.Microsoft.dll", Properties.Resources.VAC_Bypass);
            
            foreach (var process in Process.GetProcessesByName("csgo"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("Steam"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("steamwebhelper"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("SteamService"))
            {
                process.Kill();
            }
            string dllPath = AppPath + @"\ServiceHub2.TaskRun.Microsoft.dll";
            try
            {
                if (VACByPassInjectionRun(GetPathVACDLL()))
                {
                    poisonLabel4.Text = "VAC-ByPass is now active";
                    poisonLabel1.ForeColor = Color.Lime;
                    poisonLabel1.Text = "VAC-ByPass-Status:  Active";
                    poisonButton1.Enabled = false;
                    System.Threading.Thread SteamExit = new System.Threading.Thread(WaitingforSteamExit);
                    SteamExit.Start();
                    while (SteamExit.IsAlive)
                        Application.DoEvents();
                    poisonLabel4.ForeColor = Color.Red;
                    poisonLabel4.Text = "VAC-ByPass-Status:  Inactive";
                    poisonButton1.Enabled = true;
                }
                else
                {
                    PoisonMessageBox.Show(this, "Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                PoisonMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetPathVACDLL()
        {
            string dllPath = string.Empty;

            
            dllPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\ServiceHub2.TaskRun.Microsoft.dll";

            return dllPath;
        }

        private void WaitingforSteamExit()
        {
            Process T = new Process();
            {
                var withBlock = T;
                foreach (Process p1 in Process.GetProcessesByName("Steam"))
                    p1.WaitForExit();
            }
        }

        public static bool VACByPassInjectionRun(string pathToDLL)
        {
            Init();

            pid = GetGamePID();

            if (pid == UInt32.MinValue)
            {
                throw new ApplicationException("Process not found! Start CSGO first before you try to inject");
            }

            hGame = OpenProcess(ProcessAccessFlags.All, false, (int)pid);

            if (hGame == IntPtr.Zero)
            {
                throw new ApplicationException("Failed to open process.");
            }

            BypassCSGOHook();
            InjectDLL(pathToDLL);
            RestoreCSGOHook();

            return true;
        }

    }
}
