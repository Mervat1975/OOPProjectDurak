namespace ProjectInterface
{
    partial class frmNewGame
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
            this.lblNoOfCards = new System.Windows.Forms.Label();
            this.lblNoOfPlayers = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rdC24 = new System.Windows.Forms.RadioButton();
            this.rdC36 = new System.Windows.Forms.RadioButton();
            this.rdC52 = new System.Windows.Forms.RadioButton();
            this.rdP2 = new System.Windows.Forms.RadioButton();
            this.rdP3 = new System.Windows.Forms.RadioButton();
            this.rdP4 = new System.Windows.Forms.RadioButton();
            this.rdP5 = new System.Windows.Forms.RadioButton();
            this.rdP6 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblNoOfCards
            // 
            this.lblNoOfCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoOfCards.Location = new System.Drawing.Point(94, 45);
            this.lblNoOfCards.Name = "lblNoOfCards";
            this.lblNoOfCards.Size = new System.Drawing.Size(185, 214);
            this.lblNoOfCards.TabIndex = 2;
            this.lblNoOfCards.Text = "Number of Cards";
            // 
            // lblNoOfPlayers
            // 
            this.lblNoOfPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoOfPlayers.Location = new System.Drawing.Point(369, 45);
            this.lblNoOfPlayers.Name = "lblNoOfPlayers";
            this.lblNoOfPlayers.Size = new System.Drawing.Size(196, 214);
            this.lblNoOfPlayers.TabIndex = 3;
            this.lblNoOfPlayers.Text = "Number of Players";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(282, 295);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 40);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 352);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(54, 47);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // rdC24
            // 
            this.rdC24.AutoSize = true;
            this.rdC24.Location = new System.Drawing.Point(106, 90);
            this.rdC24.Name = "rdC24";
            this.rdC24.Size = new System.Drawing.Size(52, 24);
            this.rdC24.TabIndex = 7;
            this.rdC24.TabStop = true;
            this.rdC24.Text = "24";
            this.rdC24.UseVisualStyleBackColor = true;
            // 
            // rdC36
            // 
            this.rdC36.AutoSize = true;
            this.rdC36.Location = new System.Drawing.Point(106, 133);
            this.rdC36.Name = "rdC36";
            this.rdC36.Size = new System.Drawing.Size(52, 24);
            this.rdC36.TabIndex = 8;
            this.rdC36.TabStop = true;
            this.rdC36.Text = "36";
            this.rdC36.UseVisualStyleBackColor = true;
            // 
            // rdC52
            // 
            this.rdC52.AutoSize = true;
            this.rdC52.Location = new System.Drawing.Point(106, 181);
            this.rdC52.Name = "rdC52";
            this.rdC52.Size = new System.Drawing.Size(52, 24);
            this.rdC52.TabIndex = 9;
            this.rdC52.TabStop = true;
            this.rdC52.Text = "52";
            this.rdC52.UseVisualStyleBackColor = true;
            // 
            // rdP2
            // 
            this.rdP2.AutoSize = true;
            this.rdP2.Location = new System.Drawing.Point(373, 90);
            this.rdP2.Name = "rdP2";
            this.rdP2.Size = new System.Drawing.Size(43, 24);
            this.rdP2.TabIndex = 10;
            this.rdP2.TabStop = true;
            this.rdP2.Text = "2";
            this.rdP2.UseVisualStyleBackColor = true;
            // 
            // rdP3
            // 
            this.rdP3.AutoSize = true;
            this.rdP3.Location = new System.Drawing.Point(373, 120);
            this.rdP3.Name = "rdP3";
            this.rdP3.Size = new System.Drawing.Size(43, 24);
            this.rdP3.TabIndex = 11;
            this.rdP3.TabStop = true;
            this.rdP3.Text = "3";
            this.rdP3.UseVisualStyleBackColor = true;
            // 
            // rdP4
            // 
            this.rdP4.AutoSize = true;
            this.rdP4.Location = new System.Drawing.Point(373, 150);
            this.rdP4.Name = "rdP4";
            this.rdP4.Size = new System.Drawing.Size(43, 24);
            this.rdP4.TabIndex = 12;
            this.rdP4.TabStop = true;
            this.rdP4.Text = "4";
            this.rdP4.UseVisualStyleBackColor = true;
            // 
            // rdP5
            // 
            this.rdP5.AutoSize = true;
            this.rdP5.Location = new System.Drawing.Point(373, 181);
            this.rdP5.Name = "rdP5";
            this.rdP5.Size = new System.Drawing.Size(43, 24);
            this.rdP5.TabIndex = 13;
            this.rdP5.TabStop = true;
            this.rdP5.Text = "5";
            this.rdP5.UseVisualStyleBackColor = true;
            // 
            // rdP6
            // 
            this.rdP6.AutoSize = true;
            this.rdP6.Location = new System.Drawing.Point(373, 211);
            this.rdP6.Name = "rdP6";
            this.rdP6.Size = new System.Drawing.Size(43, 24);
            this.rdP6.TabIndex = 14;
            this.rdP6.TabStop = true;
            this.rdP6.Text = "6";
            this.rdP6.UseVisualStyleBackColor = true;
            // 
            // frmNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 411);
            this.Controls.Add(this.rdP6);
            this.Controls.Add(this.rdP5);
            this.Controls.Add(this.rdP4);
            this.Controls.Add(this.rdP3);
            this.Controls.Add(this.rdP2);
            this.Controls.Add(this.rdC52);
            this.Controls.Add(this.rdC36);
            this.Controls.Add(this.rdC24);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblNoOfPlayers);
            this.Controls.Add(this.lblNoOfCards);
            this.Name = "frmNewGame";
            this.Text = "New Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNoOfCards;
        private System.Windows.Forms.Label lblNoOfPlayers;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rdC24;
        private System.Windows.Forms.RadioButton rdC36;
        private System.Windows.Forms.RadioButton rdC52;
        private System.Windows.Forms.RadioButton rdP2;
        private System.Windows.Forms.RadioButton rdP3;
        private System.Windows.Forms.RadioButton rdP4;
        private System.Windows.Forms.RadioButton rdP5;
        private System.Windows.Forms.RadioButton rdP6;
    }
}