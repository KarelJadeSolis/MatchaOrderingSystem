using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchaOrderingSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLitePCL.Batteries.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Application.Run( new Landing_Page());
           

        }
    }
}
