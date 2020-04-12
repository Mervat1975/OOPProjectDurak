using System;
using System.Windows.Forms;
using GameLog;

namespace OOP3Durak
{
    public partial class frmNewPlayer : Form
    {
        string userName="";
        string storagePath;
        TextUserDataHandler userDataHandler;

        public frmNewPlayer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the new player form with the current username
        /// and the current storage path
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="storagePath"></param>
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
            try
            {
                if (userDataHandler.insert(txtUserName.Text.Trim(), txtPassword.Text.Trim(), 0, 0, 0))
                {
                    this.Hide();
                    (new frmLogin(txtUserName.Text.Trim(), storagePath)).Show();
                    //this.Close();
                }
                else
                {
                    lblError.Text = "Error!! User Name already exists";
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

        /// <summary>
        /// Go back to the login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new frmLogin()).Show();
        }

        /// <summary>
        /// Put the username passed from the previous form in the
        /// username textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNewPlayer_Load(object sender, EventArgs e)
        {
            txtUserName.Text = userName;
        }
    }
}
