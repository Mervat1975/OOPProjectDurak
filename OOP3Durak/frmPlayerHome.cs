/**
 * @author Oghenefejiro Abohweyere
 * @description This form displays the home window which allows the user to navigate
 *              to different parts of the application
 * @since 2020-04-12
 */
using System;
using System.Windows.Forms;
using GameLog;

namespace OOP3Durak
{
    public partial class frmPlayerHome : Form
    {
        int userID;
        TextUserDataHandler userDataHandler;

        /// <summary>
        /// Initialize home without user id or storage path
        /// </summary>
        public frmPlayerHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Store user id information
        /// as well as path of user data file
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="storagePath"></param>
        public frmPlayerHome(int userID, string storagePath)
        {
            this.userID = userID;
            userDataHandler = new TextUserDataHandler(storagePath, storagePath);

            InitializeComponent();
        }

        /// <summary>
        /// Display the current user's name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPlayerHome_Load(object sender, EventArgs e)
        {
            lblUserValue.Text = userDataHandler.getName(userID);
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
        /// Display user statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayerStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmStatistics(userID, userDataHandler.ReadFilePath).ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Begin a new game for the current user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmMainForm(userID, userDataHandler.ReadFilePath).Show();
        }

        /// <summary>
        /// Go back to the login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginAsOther_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new frmLogin()).Show();
        }
    }
}
