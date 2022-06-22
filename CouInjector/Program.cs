using System;
using System.Net;
using System.Windows.Forms;

namespace CouInjector
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Internet connection required! Either the connection is blocked or it doesn't exist. CouInjector will now close", "CouInjector Error");
                Application.Exit();
            }
        }
    }
}
