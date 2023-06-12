using Memory_game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_game
{
    namespace Memory_game
    {
        static class Program
        {
            /// <summary>
            /// Der Haupteinstiegspunkt für die Anwendung.
            /// </summary>
            [STAThread]
            static void Main()
            {
                if (Environment.OSVersion.Version.Major >= 6)
                    SetProcessDPIAware();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Anmeldung());

            }

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            private static extern bool SetProcessDPIAware();

        }
    }
}


/*
internal static class Program
{
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
*/
