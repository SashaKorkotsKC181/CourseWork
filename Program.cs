using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
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
            FormGameSetUp gameSetUp = new FormGameSetUp();
            while (new FormStartMenu(gameSetUp).ShowDialog() == DialogResult.OK)
            {
                Application.Run(new GameForm(gameSetUp.difficulty));
            }
        }
    }
}
