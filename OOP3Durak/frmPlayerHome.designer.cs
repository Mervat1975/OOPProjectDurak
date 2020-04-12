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
			this.btnPlayerStatistics = new System.Windows.Forms.Button();
			this.btnNewGame = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnLoginAsOther = new System.Windows.Forms.Button();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblUserValue = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnPlayerStatistics
			// 
			this.btnPlayerStatistics.BackColor = System.Drawing.Color.White;
			this.btnPlayerStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPlayerStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnPlayerStatistics.Location = new System.Drawing.Point(163, 142);
			this.btnPlayerStatistics.Margin = new System.Windows.Forms.Padding(2);
			this.btnPlayerStatistics.Name = "btnPlayerStatistics";
			this.btnPlayerStatistics.Size = new System.Drawing.Size(121, 76);
			this.btnPlayerStatistics.TabIndex = 1;
			this.btnPlayerStatistics.Text = "Player &Statistics";
			this.btnPlayerStatistics.UseVisualStyleBackColor = false;
			this.btnPlayerStatistics.Click += new System.EventHandler(this.btnPlayerStatistics_Click);
			// 
			// btnNewGame
			// 
			this.btnNewGame.BackColor = System.Drawing.Color.White;
			this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnNewGame.Location = new System.Drawing.Point(228, 64);
			this.btnNewGame.Margin = new System.Windows.Forms.Padding(2);
			this.btnNewGame.Name = "btnNewGame";
			this.btnNewGame.Size = new System.Drawing.Size(121, 74);
			this.btnNewGame.TabIndex = 0;
			this.btnNewGame.Text = "New &Game";
			this.btnNewGame.UseVisualStyleBackColor = false;
			this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
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
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(2, 2);
			this.btnExit.Margin = new System.Windows.Forms.Padding(2);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(29, 27);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "X";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnLoginAsOther
			// 
			this.btnLoginAsOther.BackColor = System.Drawing.Color.White;
			this.btnLoginAsOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoginAsOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnLoginAsOther.Location = new System.Drawing.Point(288, 142);
			this.btnLoginAsOther.Margin = new System.Windows.Forms.Padding(2);
			this.btnLoginAsOther.Name = "btnLoginAsOther";
			this.btnLoginAsOther.Size = new System.Drawing.Size(121, 76);
			this.btnLoginAsOther.TabIndex = 2;
			this.btnLoginAsOther.Text = "&Login As Other User";
			this.btnLoginAsOther.UseVisualStyleBackColor = false;
			this.btnLoginAsOther.Click += new System.EventHandler(this.btnLoginAsOther_Click);
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.BackColor = System.Drawing.Color.Black;
			this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUser.ForeColor = System.Drawing.Color.Orange;
			this.lblUser.Location = new System.Drawing.Point(136, 365);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(52, 20);
			this.lblUser.TabIndex = 13;
			this.lblUser.Text = "User:";
			// 
			// lblUserValue
			// 
			this.lblUserValue.AutoSize = true;
			this.lblUserValue.BackColor = System.Drawing.Color.White;
			this.lblUserValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserValue.Location = new System.Drawing.Point(194, 366);
			this.lblUserValue.Name = "lblUserValue";
			this.lblUserValue.Size = new System.Drawing.Size(0, 18);
			this.lblUserValue.TabIndex = 14;
			// 
			// frmPlayerHome
			// 
			this.AcceptButton = this.btnNewGame;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(581, 394);
			this.Controls.Add(this.lblUserValue);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.btnLoginAsOther);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnNewGame);
			this.Controls.Add(this.btnPlayerStatistics);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frmPlayerHome";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Player Home Interface";
			this.Load += new System.EventHandler(this.frmPlayerHome_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayerStatistics;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnLoginAsOther;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.Label lblUserValue;
	}
}