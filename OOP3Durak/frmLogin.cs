using System;
using System.Windows.Forms;
using CardLib;
namespace OOP3Durak
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        { 
            Player loginPlayer;
            try
            {
                loginPlayer = DBL.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (loginPlayer != null)
                {
                    new frmPlayerHome().Show();
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
            new frmNewPlayer().Show();
            this.Close();

        }
    }
}
