using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLog;

namespace OOP3Durak
{
    public partial class frmPlayerHome : Form
    {
        int userID;
        TextUserDataHandler userDataHandler;

        public frmPlayerHome()
        {
            InitializeComponent();
        }

        public frmPlayerHome(int userID, string storagePath)
        {
            this.userID = userID;
            userDataHandler = new TextUserDataHandler(storagePath, storagePath);

            InitializeComponent();
        }

        private void frmPlayerHome_Load(object sender, EventArgs e)
        {

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

        private void btnPlayerStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmStatistics(userID, userDataHandler.ReadFilePath).ShowDialog();

            this.Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmMainForm(userID, userDataHandler.ReadFilePath).ShowDialog();
            this.Close();
        }
    }
}
