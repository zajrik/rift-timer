using System;
using System.Windows.Forms;

namespace rift_timer
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
            try
            {
                Application.Run(new Settings());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
