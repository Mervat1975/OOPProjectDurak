using System;
 
using System.Windows.Forms;
using CardLib;
namespace OOP3Durak
{
    public partial class frmNewPlayer : Form
    {
        public frmNewPlayer()
        {
            InitializeComponent();
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        { 
                                    
            Player newPlayer = new Player(txtUserName.Text, txtPassword.Text, txtEmail.Text);

             
           
               try
               {
                   if (DBL.InsertNewRecord(newPlayer))
                   {
                       this.Close();
                       new frmPlayerHome().Show();
                   }
                   else
                   {
                    lblError.Text="Error!! Player has not been added" ;
                   }
               }
               catch (Exception exc)
               {

                   MessageBox.Show(exc.ToString());
                   lblError.Text = exc.ToString();
               } 
                
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
