/**
 * @author Oghenefejiro Abohweyere
 * @description This form displays login form
 * @since 2020-04-12
 */
using System;
using System.Windows.Forms;
using GameLog;

namespace OOP3Durak
{
    public partial class frmLogin : Form
    {
        private string userName = "";

        /// <summary>
        /// Storage path of user data file
        /// </summary>
        private string storagePath = "userData.txt";
        TextUserDataHandler userDataHandler;

        /// <summary>
        /// Initialize login form with default
        /// storage file set to default
        /// </summary>
        public frmLogin()
        {
            userDataHandler = new TextUserDataHandler(storagePath, storagePath);
            InitializeComponent();
        }

        /// <summary>
        /// Store the information for the current user
        /// and the storage path that contains user data
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="storagePath"></param>
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
        /// Log the user into the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        { 
            int? id = userDataHandler.login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (id != null)
            {

                int userID = id ?? default(int);
                this.Hide();
                new frmPlayerHome(userID, storagePath).Show();
            }
            else
            {
                lblError.Text = "Wrong Login data!! Please Try again...";
            }
        }

        /// <summary>
        /// Opens the form to allow user to register
        /// as a new user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmNewPlayer(userName, storagePath).Show();
            //this.Close();

        }
    }
}
