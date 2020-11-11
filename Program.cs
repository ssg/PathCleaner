using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace PathCleaner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
#if !DEBUG
            checkElevation();
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#pragma warning disable CA2000 // Dispose objects before losing scope
            Application.Run(new MainForm());
#pragma warning restore CA2000 // Dispose objects before losing scope
        }

#if !DEBUG
        private static bool isElevated()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void checkElevation()
        {
            if(isElevated())
            {
                return;
            }
            string selfExecutablePath = Process.GetCurrentProcess().Modules[0].FileName;
            var startInfo = new ProcessStartInfo(selfExecutablePath)
            {
                Verb = "runas",
            };
            _ = Process.Start(startInfo);
            Environment.Exit(0);
        }
#endif
    }
}
