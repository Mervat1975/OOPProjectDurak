namespace OOP3Durak
{
	partial class frmStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatistics));
            this.rbYours = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.lstStats = new System.Windows.Forms.ListView();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbYours
            // 
            this.rbYours.AutoSize = true;
            this.rbYours.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbYours.Location = new System.Drawing.Point(4, 175);
            this.rbYours.Name = "rbYours";
            this.rbYours.Size = new System.Drawing.Size(90, 17);
            this.rbYours.TabIndex = 0;
            this.rbYours.Text = "&Your statistics";
            this.rbYours.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbAll.Location = new System.Drawing.Point(4, 198);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(111, 17);
            this.rbAll.TabIndex = 1;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "&All Users\' statistics";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // lstStats
            // 
            this.lstStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lstStats.ForeColor = System.Drawing.SystemColors.Info;
            this.lstStats.FullRowSelect = true;
            this.lstStats.HideSelection = false;
            this.lstStats.Location = new System.Drawing.Point(113, 78);
            this.lstStats.Name = "lstStats";
            this.lstStats.Size = new System.Drawing.Size(688, 372);
            this.lstStats.TabIndex = 2;
            this.lstStats.TabStop = false;
            this.lstStats.UseCompatibleStateImageBehavior = false;
            this.lstStats.View = System.Windows.Forms.View.Details;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHome.Location = new System.Drawing.Point(0, 417);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(116, 33);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "<< Go &Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Orange;
            this.btnClose.Location = new System.Drawing.Point(-1, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Orange;
            this.btnReload.BackgroundImage = global::OOP3Durak.Properties.Resources.refresh;
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(32, 221);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(37, 29);
            this.btnReload.TabIndex = 4;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(238, -91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // frmStatistics
            // 
            this.AcceptButton = this.btnReload;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnHome;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lstStats);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.rbYours);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game statistics";
            this.Load += new System.EventHandler(this.frmStatistics_Load);
            this.Resize += new System.EventHandler(this.frmStatistics_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.RadioButton rbYours;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.ListView lstStats;
		private System.Windows.Forms.Button btnHome;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnReload;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}