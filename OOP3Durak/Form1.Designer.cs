namespace OOP3Durak
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.cardContainer1 = new CardControls.CardContainer();
			this.cardControl3 = new CardControls.CardControl();
			this.cardControl2 = new CardControls.CardControl();
			this.cardControl1 = new CardControls.CardControl();
			this.cardControl4 = new CardControls.CardControl();
			this.cardContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cardContainer1
			// 
			this.cardContainer1.Controls.Add(this.cardControl3);
			this.cardContainer1.Location = new System.Drawing.Point(141, 12);
			this.cardContainer1.Name = "cardContainer1";
			this.cardContainer1.Size = new System.Drawing.Size(198, 208);
			this.cardContainer1.TabIndex = 4;
			// 
			// cardControl3
			// 
			this.cardControl3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardControl3.BackgroundImage")));
			this.cardControl3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cardControl3.ImgResource = "_8D";
			this.cardControl3.IsDraggable = false;
			this.cardControl3.Location = new System.Drawing.Point(0, 0);
			this.cardControl3.Name = "cardControl3";
			this.cardControl3.RotationAngle = 40F;
			this.cardControl3.Size = new System.Drawing.Size(65, 86);
			this.cardControl3.TabIndex = 2;
			this.cardControl3.Text = "cardControl3";
			// 
			// cardControl2
			// 
			this.cardControl2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardControl2.BackgroundImage")));
			this.cardControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cardControl2.ImgResource = "_6D";
			this.cardControl2.IsDraggable = false;
			this.cardControl2.Location = new System.Drawing.Point(378, 239);
			this.cardControl2.Name = "cardControl2";
			this.cardControl2.RotationAngle = 40F;
			this.cardControl2.Size = new System.Drawing.Size(65, 86);
			this.cardControl2.TabIndex = 1;
			this.cardControl2.Text = "cardControl2";
			// 
			// cardControl1
			// 
			this.cardControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardControl1.BackgroundImage")));
			this.cardControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cardControl1.ImgResource = "_8D";
			this.cardControl1.IsDraggable = false;
			this.cardControl1.Location = new System.Drawing.Point(378, 26);
			this.cardControl1.Name = "cardControl1";
			this.cardControl1.RotationAngle = 40F;
			this.cardControl1.Size = new System.Drawing.Size(65, 86);
			this.cardControl1.TabIndex = 0;
			this.cardControl1.Text = "cardControl1";
			// 
			// cardControl4
			// 
			this.cardControl4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardControl4.BackgroundImage")));
			this.cardControl4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cardControl4.ImgResource = "_8D";
			this.cardControl4.IsDraggable = false;
			this.cardControl4.Location = new System.Drawing.Point(510, 26);
			this.cardControl4.Name = "cardControl4";
			this.cardControl4.RotationAngle = 40F;
			this.cardControl4.Size = new System.Drawing.Size(65, 86);
			this.cardControl4.TabIndex = 3;
			this.cardControl4.Text = "cardControl4";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cardContainer1);
			this.Controls.Add(this.cardControl2);
			this.Controls.Add(this.cardControl1);
			this.Controls.Add(this.cardControl4);
			
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.cardContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private CardControls.CardControl cardControl1;
		private CardControls.CardControl cardControl2;
		private CardControls.CardControl cardControl3;
		private CardControls.CardControl cardControl4;
		private CardControls.CardContainer cardContainer1;
	}
}

