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
        private string userName;
        private string password;
        private string storagePath;
        TextUserDataHandler userDataHandler;

        public frmPlayerHome()
        {
            InitializeComponent();
        }

        public frmPlayerHome(string userName, string password, string storagePath)
        {
            this.userName = userName;
            this.password = password;
            this.storagePath = storagePath;
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
    }
}
