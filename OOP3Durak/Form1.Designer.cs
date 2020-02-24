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
			this.cardControl1 = new CardControls.CardControl();
			this.cardControl2 = new CardControls.CardControl();
			this.SuspendLayout();
			// 
			// cardControl1
			// 
			this.cardControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardControl1.BackgroundImage")));
			this.cardControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cardControl1.ImgResource = "_8D";
			this.cardControl1.Location = new System.Drawing.Point(216, 97);
			this.cardControl1.Name = "cardControl1";
			this.cardControl1.Size = new System.Drawing.Size(65, 86);
			this.cardControl1.TabIndex = 0;
			this.cardControl1.Text = "cardControl1";
			// 
			// cardControl2
			// 
			this.cardControl2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cardControl2.BackgroundImage")));
			this.cardControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.cardControl2.ImgResource = "_8D";
			this.cardControl2.Location = new System.Drawing.Point(318, 97);
			this.cardControl2.Name = "cardControl2";
			this.cardControl2.Size = new System.Drawing.Size(78, 86);
			this.cardControl2.TabIndex = 1;
			this.cardControl2.Text = "cardControl2";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cardControl2);
			this.Controls.Add(this.cardControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

        }

        #endregion

        private CardControls.CardControl cardControl1;
        private CardControls.CardControl cardControl2;
    }
}

