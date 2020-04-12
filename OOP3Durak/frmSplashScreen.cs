/**
 * @author  Mervat Mustafa
 * @description This form displays Splash screen
 * @since 2020-04-12
 */
using System;
 using System.Windows.Forms;
namespace OOP3Durak
{
    public partial class frmSplashScreen : Form
    {
        private int counter = 0;
        public frmSplashScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// move the progress bar and view the next form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter < prgSplash.Maximum)
            {
                counter += 10;
                prgSplash.Value = counter;   }
            else
            {

              
                timSplash.Stop();
                this.Hide();
                
                
                 
                new frmLogin().ShowDialog();
                

            }
            
        }

         
    }
}
