namespace OOP3Durak
{
    partial class frmSplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashScreen));
            this.prgSplash = new System.Windows.Forms.ProgressBar();
            this.picSplash = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timSplash = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // prgSplash
            // 
            this.prgSplash.BackColor = System.Drawing.Color.Black;
            this.prgSplash.ForeColor = System.Drawing.Color.LawnGreen;
            this.prgSplash.Location = new System.Drawing.Point(12, 218);
            this.prgSplash.Name = "prgSplash";
            this.prgSplash.Size = new System.Drawing.Size(389, 23);
            this.prgSplash.TabIndex = 0;
            // 
            // picSplash
            // 
            this.picSplash.Image = ((System.Drawing.Image)(resources.GetObject("picSplash.Image")));
            this.picSplash.Location = new System.Drawing.Point(41, -28);
            this.picSplash.Name = "picSplash";
            this.picSplash.Size = new System.Drawing.Size(333, 246);
            this.picSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSplash.TabIndex = 1;
            this.picSplash.TabStop = false;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(62, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version   0.0";
            // 
            // timSplash
            // 
            this.timSplash.Enabled = true;
            this.timSplash.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(62, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "2020";
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(413, 248);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picSplash);
            this.Controls.Add(this.prgSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frimSplashscreen";
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgSplash;
        private System.Windows.Forms.PictureBox picSplash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timSplash;
        private System.Windows.Forms.Label label2;
    }
}