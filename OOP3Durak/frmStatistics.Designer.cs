﻿namespace OOP3Durak
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
			this.rbYours = new System.Windows.Forms.RadioButton();
			this.rbAll = new System.Windows.Forms.RadioButton();
			this.lstStats = new System.Windows.Forms.ListView();
			this.btnHome = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// rbYours
			// 
			this.rbYours.AutoSize = true;
			this.rbYours.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.rbYours.Location = new System.Drawing.Point(4, 33);
			this.rbYours.Name = "rbYours";
			this.rbYours.Size = new System.Drawing.Size(90, 17);
			this.rbYours.TabIndex = 1;
			this.rbYours.Text = "Your statistics";
			this.rbYours.UseVisualStyleBackColor = true;
			// 
			// rbAll
			// 
			this.rbAll.AutoSize = true;
			this.rbAll.Checked = true;
			this.rbAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.rbAll.Location = new System.Drawing.Point(4, 68);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new System.Drawing.Size(111, 17);
			this.rbAll.TabIndex = 2;
			this.rbAll.TabStop = true;
			this.rbAll.Text = "All Users\' statistics";
			this.rbAll.UseVisualStyleBackColor = true;
			// 
			// lstStats
			// 
			this.lstStats.HideSelection = false;
			this.lstStats.Location = new System.Drawing.Point(121, -1);
			this.lstStats.Name = "lstStats";
			this.lstStats.Size = new System.Drawing.Size(680, 451);
			this.lstStats.TabIndex = 3;
			this.lstStats.UseCompatibleStateImageBehavior = false;
			this.lstStats.View = System.Windows.Forms.View.Details;
			// 
			// btnHome
			// 
			this.btnHome.Location = new System.Drawing.Point(12, 291);
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(82, 27);
			this.btnHome.TabIndex = 4;
			this.btnHome.Text = "<< Go Home";
			this.btnHome.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(13, 338);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(81, 28);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = false;
			// 
			// frmStatistics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnHome);
			this.Controls.Add(this.lstStats);
			this.Controls.Add(this.rbAll);
			this.Controls.Add(this.rbYours);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmStatistics";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game statistics";
			this.Load += new System.EventHandler(this.frmStatistics_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.RadioButton rbYours;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.ListView lstStats;
		private System.Windows.Forms.Button btnHome;
		private System.Windows.Forms.Button btnClose;
	}
}