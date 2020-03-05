using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            try
            {
#endif
                Application.Run(new MainForm());
#if DEBUG
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups, das sollte nicht passieren.\nMach bitte ein Screenshot von dem Fehler und schick ihn St0rmy!\n" + ex.ToString());
            }
#endif

        }
    }
}
