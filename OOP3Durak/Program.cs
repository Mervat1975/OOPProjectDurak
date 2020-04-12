/**
 * program.cs -The main class of the application  
 * @author       Mervat Mustafa <mervat.mustafa@durhamcollege.ca>
 * @version     0.0
 * @since       2020-03-18
 **/
using System;
using System.Windows.Forms;

namespace OOP3Durak
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
            Application.Run(new frmSplashScreen());
            
        }
    }
}
