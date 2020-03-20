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
			this.cardContainer1 = new CardControls.CardContainer();
			this.SuspendLayout();
			// 
			// cardContainer1
			// 
			this.cardContainer1.ContainerType = CardControls.CardContainerType.PlayerHand;
			this.cardContainer1.Location = new System.Drawing.Point(230, 219);
			this.cardContainer1.Name = "cardContainer1";
			this.cardContainer1.Size = new System.Drawing.Size(370, 108);
			this.cardContainer1.TabIndex = 4;
			this.cardContainer1.TrumpSuit = CardLib.Suit.Club;
			this.cardContainer1.Click += new System.EventHandler(this.cardContainer1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cardContainer1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.ResumeLayout(false);

        }

		#endregion
		private CardControls.CardContainer cardContainer1;
	}
}

