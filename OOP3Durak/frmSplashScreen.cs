using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP3Durak;
namespace OOP3Durak
{
    public partial class frmSplashScreen : Form
    {
        private int counter = 0;
        public frmSplashScreen()
        {
            InitializeComponent();
        }

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
