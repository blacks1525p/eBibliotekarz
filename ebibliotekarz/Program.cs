using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ebibliotekarz
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (
                Process.GetProcessesByName(
                    Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location))
                    .Count() > 1)
            {
                MessageBox.Show("Aplikacja już działa!");
            }


            Application.Run(new Form1());
        }
    }
}