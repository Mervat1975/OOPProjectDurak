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
			this.rbAll.ForeColor = System.Drawing.SystemColors.ControlLight;
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
			this.lstStats.Location = new System.Drawing.Point(121, 12);
			this.lstStats.Name = "lstStats";
			this.lstStats.Size = new System.Drawing.Size(667, 416);
			this.lstStats.TabIndex = 3;
			this.lstStats.UseCompatibleStateImageBehavior = false;
			this.lstStats.View = System.Windows.Forms.View.Details;
			// 
			// frmStatistics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lstStats);
			this.Controls.Add(this.rbAll);
			this.Controls.Add(this.rbYours);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmStatistics";
			this.Text = "Game statistics";
			this.Load += new System.EventHandler(this.frmStatistics_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.RadioButton rbYours;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.ListView lstStats;
	}
}