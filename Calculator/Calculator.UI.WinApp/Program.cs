using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Infrastructure.BootStrapper;

namespace Calculator.UI.WinApp
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
            //привязываемся к IoC контейнеру
            Application.Run(NinjectBootstrapper.GetForm<CalculatorForm>()); 
        }
    }
}
