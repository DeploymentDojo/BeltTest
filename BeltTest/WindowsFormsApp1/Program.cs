using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                return HandleConfiguration(args);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            return 0;
        }

        private static int HandleConfiguration(string[] args)
        {
            // args[0]   args[1]
            // -customer "New Customer Value"
            if (args.Length != 2 || args[0] != "-customer" || String.IsNullOrEmpty(args[1]))
            {
                return -1;
            }

            try
            {
                ClassLibrary1.Class1.SetCustomer(args[1]);
                return 0;
            }
            catch
            {
                return -2;
            }
        }
    }
}
