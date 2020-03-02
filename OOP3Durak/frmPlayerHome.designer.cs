namespace OOP3Durak
{
    partial class frmPlayerHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayerHome));
            this.btnPlayerHistory = new System.Windows.Forms.Button();
            this.btnManageAccount = new System.Windows.Forms.Button();
            this.btnGameRules = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlayerHistory
            // 
            this.btnPlayerHistory.Location = new System.Drawing.Point(155, 81);
            this.btnPlayerHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayerHistory.Name = "btnPlayerHistory";
            this.btnPlayerHistory.Size = new System.Drawing.Size(121, 76);
            this.btnPlayerHistory.TabIndex = 0;
            this.btnPlayerHistory.Text = "Player History";
            this.btnPlayerHistory.UseVisualStyleBackColor = true;
            // 
            // btnManageAccount
            // 
            this.btnManageAccount.Location = new System.Drawing.Point(295, 80);
            this.btnManageAccount.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageAccount.Name = "btnManageAccount";
            this.btnManageAccount.Size = new System.Drawing.Size(119, 78);
            this.btnManageAccount.TabIndex = 1;
            this.btnManageAccount.Text = "Manage Account";
            this.btnManageAccount.UseVisualStyleBackColor = true;
            // 
            // btnGameRules
            // 
            this.btnGameRules.Location = new System.Drawing.Point(295, 162);
            this.btnGameRules.Margin = new System.Windows.Forms.Padding(2);
            this.btnGameRules.Name = "btnGameRules";
            this.btnGameRules.Size = new System.Drawing.Size(119, 74);
            this.btnGameRules.TabIndex = 2;
            this.btnGameRules.Text = "Game Rules";
            this.btnGameRules.UseVisualStyleBackColor = true;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(155, 164);
            this.btnNewGame.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(121, 74);
            this.btnNewGame.TabIndex = 3;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 287);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Orange;
            this.btnExit.Location = new System.Drawing.Point(2, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 27);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // frmPlayerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(557, 376);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnGameRules);
            this.Controls.Add(this.btnManageAccount);
            this.Controls.Add(this.btnPlayerHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPlayerHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Home Interface";
            this.Load += new System.EventHandler(this.frmPlayerHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayerHistory;
        private System.Windows.Forms.Button btnManageAccount;
        private System.Windows.Forms.Button btnGameRules;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
    }
}