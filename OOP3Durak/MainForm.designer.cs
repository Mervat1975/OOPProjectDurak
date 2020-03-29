namespace OOP3Durak
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.FormUiDemoTips = new System.Windows.Forms.ToolTip(this.components);
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pnlCardPlayer1 = new System.Windows.Forms.Panel();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.pnlCardPlayer2 = new System.Windows.Forms.Panel();
            this.pbcTrash = new System.Windows.Forms.PictureBox();
            this.pbTrumpCard = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblCardCount = new System.Windows.Forms.Label();
            this.pnlPlay = new System.Windows.Forms.Panel();
            this.btnBat = new System.Windows.Forms.Button();
            this.btnTake = new System.Windows.Forms.Button();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblPlayer1CardCount = new System.Windows.Forms.Label();
            this.lblPlayer2CardCount = new System.Windows.Forms.Label();
            this.lblTrashCount = new System.Windows.Forms.Label();
            this.btnReady = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnPass = new System.Windows.Forms.Button();
            this.lblTrump = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcTrash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDeck
            // 
            this.pbDeck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDeck.Location = new System.Drawing.Point(219, 227);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(129, 168);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 2;
            this.pbDeck.TabStop = false;
            this.FormUiDemoTips.SetToolTip(this.pbDeck, "Deck");
            // 
            // pnlCardPlayer1
            // 
            this.pnlCardPlayer1.AllowDrop = true;
            this.pnlCardPlayer1.BackColor = System.Drawing.Color.Black;
            this.pnlCardPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardPlayer1.Location = new System.Drawing.Point(319, 560);
            this.pnlCardPlayer1.Name = "pnlCardPlayer1";
            this.pnlCardPlayer1.Size = new System.Drawing.Size(639, 190);
            this.pnlCardPlayer1.TabIndex = 10;
            this.FormUiDemoTips.SetToolTip(this.pnlCardPlayer1, "Click  or drag cards to move them to the play area.");
            this.pnlCardPlayer1.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlCardPlayer1_DragOver);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.ForeColor = System.Drawing.Color.White;
            this.lblPlayer.Location = new System.Drawing.Point(2, 9);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(134, 20);
            this.lblPlayer.TabIndex = 9;
            this.lblPlayer.Text = "Number of Player:";
            this.FormUiDemoTips.SetToolTip(this.lblPlayer, "Home ");
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNumber.ForeColor = System.Drawing.Color.White;
            this.lblCardNumber.Location = new System.Drawing.Point(2, 41);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(133, 20);
            this.lblCardNumber.TabIndex = 7;
            this.lblCardNumber.Text = "Number of Cards:";
            this.FormUiDemoTips.SetToolTip(this.lblCardNumber, "Home ");
            // 
            // pnlCardPlayer2
            // 
            this.pnlCardPlayer2.AllowDrop = true;
            this.pnlCardPlayer2.BackColor = System.Drawing.Color.Black;
            this.pnlCardPlayer2.Location = new System.Drawing.Point(399, 12);
            this.pnlCardPlayer2.Name = "pnlCardPlayer2";
            this.pnlCardPlayer2.Size = new System.Drawing.Size(480, 193);
            this.pnlCardPlayer2.TabIndex = 12;
            // 
            // pbcTrash
            // 
            this.pbcTrash.Location = new System.Drawing.Point(953, 274);
            this.pbcTrash.Name = "pbcTrash";
            this.pbcTrash.Size = new System.Drawing.Size(119, 170);
            this.pbcTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcTrash.TabIndex = 13;
            this.pbcTrash.TabStop = false;
            this.FormUiDemoTips.SetToolTip(this.pbcTrash, "Trash");
            // 
            // pbTrumpCard
            // 
            this.pbTrumpCard.Location = new System.Drawing.Point(232, 323);
            this.pbTrumpCard.Name = "pbTrumpCard";
            this.pbTrumpCard.Size = new System.Drawing.Size(100, 153);
            this.pbTrumpCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTrumpCard.TabIndex = 14;
            this.pbTrumpCard.TabStop = false;
            this.FormUiDemoTips.SetToolTip(this.pbTrumpCard, "Trump Suite");
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.Location = new System.Drawing.Point(201, 707);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 42);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "E&xit";
            this.FormUiDemoTips.SetToolTip(this.btnExit, "Exit the application.");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblCardCount
            // 
            this.lblCardCount.BackColor = System.Drawing.Color.Black;
            this.lblCardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblCardCount.Location = new System.Drawing.Point(250, 192);
            this.lblCardCount.Name = "lblCardCount";
            this.lblCardCount.Size = new System.Drawing.Size(75, 32);
            this.lblCardCount.TabIndex = 1;
            this.lblCardCount.Text = "88";
            this.lblCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPlay
            // 
            this.pnlPlay.AllowDrop = true;
            this.pnlPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlay.ForeColor = System.Drawing.Color.White;
            this.pnlPlay.Location = new System.Drawing.Point(367, 211);
            this.pnlPlay.Name = "pnlPlay";
            this.pnlPlay.Size = new System.Drawing.Size(550, 305);
            this.pnlPlay.TabIndex = 8;
            this.FormUiDemoTips.SetToolTip(this.pnlPlay, "Play Area");
            this.pnlPlay.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlPlay_DragDrop);
            this.pnlPlay.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlPlay_DragEnter);
            this.pnlPlay.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlPlay_DragOver);
            // 
            // btnBat
            // 
            this.btnBat.BackColor = System.Drawing.Color.White;
            this.btnBat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBat.Enabled = false;
            this.btnBat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBat.ForeColor = System.Drawing.Color.Gray;
            this.btnBat.Location = new System.Drawing.Point(964, 625);
            this.btnBat.Name = "btnBat";
            this.btnBat.Size = new System.Drawing.Size(112, 42);
            this.btnBat.TabIndex = 7;
            this.btnBat.Text = "Bat";
            this.btnBat.UseVisualStyleBackColor = false;
            this.btnBat.Click += new System.EventHandler(this.btnBat_Click);
            // 
            // btnTake
            // 
            this.btnTake.BackColor = System.Drawing.Color.White;
            this.btnTake.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTake.Enabled = false;
            this.btnTake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTake.ForeColor = System.Drawing.Color.Gray;
            this.btnTake.Location = new System.Drawing.Point(964, 706);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(112, 42);
            this.btnTake.TabIndex = 8;
            this.btnTake.Text = "Take";
            this.btnTake.UseVisualStyleBackColor = false;
            this.btnTake.Click += new System.EventHandler(this.btnTake_Click);
            // 
            // lblTurn
            // 
            this.lblTurn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.Black;
            this.lblTurn.Location = new System.Drawing.Point(367, 516);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(550, 38);
            this.lblTurn.TabIndex = 15;
            this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1CardCount
            // 
            this.lblPlayer1CardCount.BackColor = System.Drawing.Color.Black;
            this.lblPlayer1CardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1CardCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblPlayer1CardCount.Location = new System.Drawing.Point(313, 525);
            this.lblPlayer1CardCount.Name = "lblPlayer1CardCount";
            this.lblPlayer1CardCount.Size = new System.Drawing.Size(51, 32);
            this.lblPlayer1CardCount.TabIndex = 16;
            this.lblPlayer1CardCount.Text = "88";
            this.lblPlayer1CardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2CardCount
            // 
            this.lblPlayer2CardCount.BackColor = System.Drawing.Color.Black;
            this.lblPlayer2CardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2CardCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblPlayer2CardCount.Location = new System.Drawing.Point(347, 38);
            this.lblPlayer2CardCount.Name = "lblPlayer2CardCount";
            this.lblPlayer2CardCount.Size = new System.Drawing.Size(49, 32);
            this.lblPlayer2CardCount.TabIndex = 17;
            this.lblPlayer2CardCount.Text = "88";
            this.lblPlayer2CardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrashCount
            // 
            this.lblTrashCount.BackColor = System.Drawing.Color.Black;
            this.lblTrashCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrashCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTrashCount.Location = new System.Drawing.Point(971, 239);
            this.lblTrashCount.Name = "lblTrashCount";
            this.lblTrashCount.Size = new System.Drawing.Size(75, 32);
            this.lblTrashCount.TabIndex = 18;
            this.lblTrashCount.Text = "88";
            this.lblTrashCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.Color.White;
            this.btnReady.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReady.Location = new System.Drawing.Point(201, 625);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(112, 42);
            this.btnReady.TabIndex = 20;
            this.btnReady.Text = "Ready";
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.White;
            this.btnNewGame.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewGame.Enabled = false;
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.Color.Gray;
            this.btnNewGame.Location = new System.Drawing.Point(201, 665);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(112, 42);
            this.btnNewGame.TabIndex = 19;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnPass
            // 
            this.btnPass.BackColor = System.Drawing.Color.White;
            this.btnPass.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPass.Enabled = false;
            this.btnPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPass.ForeColor = System.Drawing.Color.Gray;
            this.btnPass.Location = new System.Drawing.Point(964, 665);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(112, 42);
            this.btnPass.TabIndex = 22;
            this.btnPass.Text = "Pass";
            this.btnPass.UseVisualStyleBackColor = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // lblTrump
            // 
            this.lblTrump.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrump.Location = new System.Drawing.Point(201, 479);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(160, 27);
            this.lblTrump.TabIndex = 23;
            this.lblTrump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1267, 752);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTrashCount);
            this.Controls.Add(this.lblPlayer2CardCount);
            this.Controls.Add(this.lblPlayer1CardCount);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.btnBat);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.pbTrumpCard);
            this.Controls.Add(this.pbcTrash);
            this.Controls.Add(this.pnlCardPlayer2);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.pnlPlay);
            this.Controls.Add(this.pnlCardPlayer1);
            this.Controls.Add(this.lblCardCount);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form UI Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcTrash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip FormUiDemoTips;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.Label lblCardCount;
        private System.Windows.Forms.Panel pnlCardPlayer1;
        private System.Windows.Forms.Panel pnlPlay;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.Panel pnlCardPlayer2;
        private System.Windows.Forms.PictureBox pbcTrash;
        private System.Windows.Forms.PictureBox pbTrumpCard;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Button btnBat;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblPlayer1CardCount;
        private System.Windows.Forms.Label lblPlayer2CardCount;
        private System.Windows.Forms.Label lblTrashCount;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Label lblTrump;
    }
}

