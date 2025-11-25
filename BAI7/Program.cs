using System;
using System.Windows.Forms;

namespace BAI7
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Chạy Form đăng nhập đầu tiên
            Application.Run(new LoginForm());
        }
    }
}