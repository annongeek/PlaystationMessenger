using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playstation_Friends_List
    {
    static class Program
        {
        private static FormMain mainWindow;
        public static FormMain MainWindow
            {
            get { return mainWindow; }
            set { mainWindow = value; }
            }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
     
        [STAThread]
        static void Main()
            {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            mainWindow = new FormMain();
            Application.Run(mainWindow);
            }
        }
    }
