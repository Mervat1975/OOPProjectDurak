using System;
using System.Windows.Forms;
using CardLib;
using GameLog;

namespace OOP3Durak
{
    public partial class frmLogin : Form
    {
        public static Player loginPlayer;
        private string userName = "";
        private string password = "";
        private string storagePath;
        TextUserDataHandler userDataHandler;

        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(string userName, string storagePath)
        {
            this.userName = userName;
            this.storagePath = storagePath;
            userDataHandler = new TextUserDataHandler(storagePath, storagePath);

            InitializeComponent();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        { 
           
            try
            {
                //loginPlayer = DBL.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                int? id = userDataHandler.login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (id != null)
                {
                    
                    
                    new frmMainForm(id, storagePath).Show();

                    this.Close();
                }
                else
                {
                    lblError.Text = "Wrong Login data!! Please Try again...";
                }
            }
            catch (Exception exc)
            {
                lblError.Text = exc.ToString();
                MessageBox.Show(lblError.Text);
            }
            


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            new frmNewPlayer(userName, storagePath).Show();
            this.Close();

        }
    }
}
