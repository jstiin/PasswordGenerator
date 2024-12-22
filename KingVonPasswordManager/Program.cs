using System;
using System.Windows.Forms;

namespace KingVonPasswordManager
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            // starts the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PasswordGen form1 = new PasswordGen();  // new form object 
            GeneratorController generatorController = new GeneratorController(form1);   // new generator object with form object as parameter

            Application.Run(form1); // runs the application
        }
    }
}
