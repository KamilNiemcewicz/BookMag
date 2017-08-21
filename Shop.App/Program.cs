using Shop.Core.UI;
using Shop.Core.Security.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm fLogin = new LoginForm())
            {
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
            }

            Application.Exit();
        }
    }
}
