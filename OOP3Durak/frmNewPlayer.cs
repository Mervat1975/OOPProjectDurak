using System;
 
using System.Windows.Forms;
using CardLib;
using GameLog;

namespace OOP3Durak
{
    public partial class frmNewPlayer : Form
    {
        string userName;
        string password;
        string storagePath;
        TextUserDataHandler userDataHandler;

        public frmNewPlayer()
        {
            InitializeComponent();
        }

        public frmNewPlayer(string userName, string storagePath)
        {
            this.userName = userName;
            this.storagePath = storagePath;
            userDataHandler = new TextUserDataHandler(storagePath, storagePath);

            InitializeComponent();
        }

        /// <summary>
        /// insert new player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        { 
                                    
            //Player newPlayer = new Player(txtUserName.Text, txtPassword.Text, txtEmail.Text);

             
           
               try
               {
                   if (userDataHandler.insert(txtUserName.Text.Trim(), txtPassword.Text.Trim(), 0, 0, 0))
                   {
                       this.Close();
                       new frmLogin(txtUserName.Text.Trim(), storagePath).Show();
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
        /// End the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
