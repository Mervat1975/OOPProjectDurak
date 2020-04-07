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
            this.pnlCardPlayer1 = new System.Windows.Forms.Panel();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlPlay = new System.Windows.Forms.Panel();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pbTrumpCard = new System.Windows.Forms.PictureBox();
            this.pbcTrash = new System.Windows.Forms.PictureBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.pnlCardPlayer2 = new System.Windows.Forms.Panel();
            this.lblCardCount = new System.Windows.Forms.Label();
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
            this.pnlNumberOfCard = new System.Windows.Forms.Panel();
            this.radClick = new System.Windows.Forms.RadioButton();
            this.radDrag = new System.Windows.Forms.RadioButton();
            this.lblNumberOfcard = new System.Windows.Forms.Label();
            this.cmpCardsNumber = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlLeftButtons = new System.Windows.Forms.Panel();
            this.pnlRightButtons = new System.Windows.Forms.Panel();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnOkResult = new System.Windows.Forms.Button();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.pbMessage = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnMessageOk = new System.Windows.Forms.Button();
            this.prgTrash = new System.Windows.Forms.ProgressBar();
            this.timTrash = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcTrash)).BeginInit();
            this.pnlNumberOfCard.SuspendLayout();
            this.pnlLeftButtons.SuspendLayout();
            this.pnlRightButtons.SuspendLayout();
            this.pnlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.pnlMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCardPlayer1
            // 
            this.pnlCardPlayer1.AllowDrop = true;
            this.pnlCardPlayer1.BackColor = System.Drawing.Color.Black;
            this.pnlCardPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardPlayer1.Location = new System.Drawing.Point(340, 560);
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
            this.lblPlayer.Location = new System.Drawing.Point(1, 12);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(142, 20);
            this.lblPlayer.TabIndex = 9;
            this.lblPlayer.Text = "Number of Players:";
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
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExit.Location = new System.Drawing.Point(8, 108);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 42);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "E&xit";
            this.FormUiDemoTips.SetToolTip(this.btnExit, "Exit the application.");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlPlay
            // 
            this.pnlPlay.AllowDrop = true;
            this.pnlPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlay.ForeColor = System.Drawing.Color.White;
            this.pnlPlay.Location = new System.Drawing.Point(388, 203);
            this.pnlPlay.Name = "pnlPlay";
            this.pnlPlay.Size = new System.Drawing.Size(550, 317);
            this.pnlPlay.TabIndex = 8;
            this.FormUiDemoTips.SetToolTip(this.pnlPlay, "Play Area");
            this.pnlPlay.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlPlay_DragDrop);
            this.pnlPlay.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlPlay_DragEnter);
            this.pnlPlay.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlPlay_DragOver);
            // 
            // pbDeck
            // 
            this.pbDeck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDeck.Location = new System.Drawing.Point(241, 274);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(129, 168);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeck.TabIndex = 2;
            this.pbDeck.TabStop = false;
            this.FormUiDemoTips.SetToolTip(this.pbDeck, "Deck");
            // 
            // pbTrumpCard
            // 
            this.pbTrumpCard.Location = new System.Drawing.Point(161, 308);
            this.pbTrumpCard.Name = "pbTrumpCard";
            this.pbTrumpCard.Size = new System.Drawing.Size(153, 100);
            this.pbTrumpCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTrumpCard.TabIndex = 14;
            this.pbTrumpCard.TabStop = false;
            this.FormUiDemoTips.SetToolTip(this.pbTrumpCard, "Trump Suite");
            // 
            // pbcTrash
            // 
            this.pbcTrash.Location = new System.Drawing.Point(974, 274);
            this.pbcTrash.Name = "pbcTrash";
            this.pbcTrash.Size = new System.Drawing.Size(119, 170);
            this.pbcTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcTrash.TabIndex = 13;
            this.pbcTrash.TabStop = false;
            this.FormUiDemoTips.SetToolTip(this.pbcTrash, "Trash");
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.White;
            this.lblMode.Location = new System.Drawing.Point(2, 74);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(57, 20);
            this.lblMode.TabIndex = 30;
            this.lblMode.Text = "Mode: ";
            this.FormUiDemoTips.SetToolTip(this.lblMode, "Home ");
            // 
            // pnlCardPlayer2
            // 
            this.pnlCardPlayer2.AllowDrop = true;
            this.pnlCardPlayer2.BackColor = System.Drawing.Color.Black;
            this.pnlCardPlayer2.Location = new System.Drawing.Point(420, 12);
            this.pnlCardPlayer2.Name = "pnlCardPlayer2";
            this.pnlCardPlayer2.Size = new System.Drawing.Size(480, 185);
            this.pnlCardPlayer2.TabIndex = 12;
            // 
            // lblCardCount
            // 
            this.lblCardCount.BackColor = System.Drawing.Color.Black;
            this.lblCardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblCardCount.Location = new System.Drawing.Point(270, 239);
            this.lblCardCount.Name = "lblCardCount";
            this.lblCardCount.Size = new System.Drawing.Size(75, 32);
            this.lblCardCount.TabIndex = 1;
            this.lblCardCount.Text = "88";
            this.lblCardCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBat
            // 
            this.btnBat.BackColor = System.Drawing.Color.White;
            this.btnBat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBat.Enabled = false;
            this.btnBat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBat.ForeColor = System.Drawing.Color.Gray;
            this.btnBat.Location = new System.Drawing.Point(5, 26);
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
            this.btnTake.Location = new System.Drawing.Point(5, 107);
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
            this.lblTurn.Location = new System.Drawing.Point(388, 520);
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
            this.lblPlayer1CardCount.Location = new System.Drawing.Point(334, 525);
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
            this.lblPlayer2CardCount.Location = new System.Drawing.Point(368, 38);
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
            this.lblTrashCount.Location = new System.Drawing.Point(992, 239);
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
            this.btnReady.Location = new System.Drawing.Point(8, 27);
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
            this.btnNewGame.Location = new System.Drawing.Point(8, 67);
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
            this.btnPass.Location = new System.Drawing.Point(5, 66);
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
            this.lblTrump.Location = new System.Drawing.Point(185, 445);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(160, 27);
            this.lblTrump.TabIndex = 23;
            this.lblTrump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNumberOfCard
            // 
            this.pnlNumberOfCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNumberOfCard.Controls.Add(this.radClick);
            this.pnlNumberOfCard.Controls.Add(this.radDrag);
            this.pnlNumberOfCard.Controls.Add(this.lblNumberOfcard);
            this.pnlNumberOfCard.Controls.Add(this.cmpCardsNumber);
            this.pnlNumberOfCard.Controls.Add(this.btnOk);
            this.pnlNumberOfCard.Location = new System.Drawing.Point(27, 135);
            this.pnlNumberOfCard.Name = "pnlNumberOfCard";
            this.pnlNumberOfCard.Size = new System.Drawing.Size(287, 189);
            this.pnlNumberOfCard.TabIndex = 24;
            this.pnlNumberOfCard.Visible = false;
            // 
            // radClick
            // 
            this.radClick.AutoSize = true;
            this.radClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radClick.Location = new System.Drawing.Point(144, 95);
            this.radClick.Name = "radClick";
            this.radClick.Size = new System.Drawing.Size(60, 20);
            this.radClick.TabIndex = 16;
            this.radClick.Text = "Click";
            this.radClick.UseVisualStyleBackColor = true;
            // 
            // radDrag
            // 
            this.radDrag.AutoSize = true;
            this.radDrag.Checked = true;
            this.radDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDrag.Location = new System.Drawing.Point(78, 93);
            this.radDrag.Name = "radDrag";
            this.radDrag.Size = new System.Drawing.Size(60, 20);
            this.radDrag.TabIndex = 17;
            this.radDrag.TabStop = true;
            this.radDrag.Text = "Drag";
            this.radDrag.UseVisualStyleBackColor = true;
            this.radDrag.CheckedChanged += new System.EventHandler(this.radDrag_CheckedChanged);
            // 
            // lblNumberOfcard
            // 
            this.lblNumberOfcard.BackColor = System.Drawing.Color.Black;
            this.lblNumberOfcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfcard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblNumberOfcard.Location = new System.Drawing.Point(16, 13);
            this.lblNumberOfcard.Name = "lblNumberOfcard";
            this.lblNumberOfcard.Size = new System.Drawing.Size(253, 32);
            this.lblNumberOfcard.TabIndex = 17;
            this.lblNumberOfcard.Text = "Select Number of Cards";
            this.lblNumberOfcard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmpCardsNumber
            // 
            this.cmpCardsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmpCardsNumber.FormattingEnabled = true;
            this.cmpCardsNumber.Items.AddRange(new object[] {
            "20",
            "36",
            "52"});
            this.cmpCardsNumber.Location = new System.Drawing.Point(78, 52);
            this.cmpCardsNumber.Name = "cmpCardsNumber";
            this.cmpCardsNumber.Size = new System.Drawing.Size(126, 32);
            this.cmpCardsNumber.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(98, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 42);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlLeftButtons
            // 
            this.pnlLeftButtons.Controls.Add(this.btnReady);
            this.pnlLeftButtons.Controls.Add(this.btnExit);
            this.pnlLeftButtons.Controls.Add(this.btnNewGame);
            this.pnlLeftButtons.Location = new System.Drawing.Point(204, 560);
            this.pnlLeftButtons.Name = "pnlLeftButtons";
            this.pnlLeftButtons.Size = new System.Drawing.Size(130, 188);
            this.pnlLeftButtons.TabIndex = 25;
            // 
            // pnlRightButtons
            // 
            this.pnlRightButtons.Controls.Add(this.btnBat);
            this.pnlRightButtons.Controls.Add(this.btnTake);
            this.pnlRightButtons.Controls.Add(this.btnPass);
            this.pnlRightButtons.Location = new System.Drawing.Point(985, 560);
            this.pnlRightButtons.Name = "pnlRightButtons";
            this.pnlRightButtons.Size = new System.Drawing.Size(120, 188);
            this.pnlRightButtons.TabIndex = 26;
            // 
            // pnlResult
            // 
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResult.Controls.Add(this.pbResult);
            this.pnlResult.Controls.Add(this.lblResult);
            this.pnlResult.Controls.Add(this.btnOkResult);
            this.pnlResult.Location = new System.Drawing.Point(27, 330);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(287, 202);
            this.pnlResult.TabIndex = 27;
            this.pnlResult.Visible = false;
            // 
            // pbResult
            // 
            this.pbResult.Location = new System.Drawing.Point(72, 65);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(146, 86);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 18;
            this.pbResult.TabStop = false;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.Black;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblResult.Location = new System.Drawing.Point(16, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(253, 32);
            this.lblResult.TabIndex = 17;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOkResult
            // 
            this.btnOkResult.BackColor = System.Drawing.Color.White;
            this.btnOkResult.Location = new System.Drawing.Point(102, 153);
            this.btnOkResult.Name = "btnOkResult";
            this.btnOkResult.Size = new System.Drawing.Size(75, 42);
            this.btnOkResult.TabIndex = 0;
            this.btnOkResult.Text = "OK";
            this.btnOkResult.UseVisualStyleBackColor = false;
            this.btnOkResult.Click += new System.EventHandler(this.btnOkResult_Click);
            // 
            // pnlMessage
            // 
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMessage.Controls.Add(this.pbMessage);
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Controls.Add(this.btnMessageOk);
            this.pnlMessage.Location = new System.Drawing.Point(1053, 498);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(287, 202);
            this.pnlMessage.TabIndex = 28;
            this.pnlMessage.Visible = false;
            // 
            // pbMessage
            // 
            this.pbMessage.Location = new System.Drawing.Point(72, 65);
            this.pbMessage.Name = "pbMessage";
            this.pbMessage.Size = new System.Drawing.Size(146, 86);
            this.pbMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMessage.TabIndex = 18;
            this.pbMessage.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Black;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMessage.Location = new System.Drawing.Point(17, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(253, 32);
            this.lblMessage.TabIndex = 17;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMessageOk
            // 
            this.btnMessageOk.BackColor = System.Drawing.Color.White;
            this.btnMessageOk.Location = new System.Drawing.Point(102, 153);
            this.btnMessageOk.Name = "btnMessageOk";
            this.btnMessageOk.Size = new System.Drawing.Size(75, 42);
            this.btnMessageOk.TabIndex = 0;
            this.btnMessageOk.Text = "OK";
            this.btnMessageOk.UseVisualStyleBackColor = false;
            this.btnMessageOk.Click += new System.EventHandler(this.btnMessageOk_Click);
            // 
            // prgTrash
            // 
            this.prgTrash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.prgTrash.Location = new System.Drawing.Point(974, 445);
            this.prgTrash.Name = "prgTrash";
            this.prgTrash.Size = new System.Drawing.Size(119, 23);
            this.prgTrash.TabIndex = 29;
            this.prgTrash.Visible = false;
            // 
            // timTrash
            // 
            this.timTrash.Tick += new System.EventHandler(this.timTrash_Tick);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1267, 752);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.prgTrash);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.pnlRightButtons);
            this.Controls.Add(this.pnlLeftButtons);
            this.Controls.Add(this.pnlNumberOfCard);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.lblTrashCount);
            this.Controls.Add(this.lblPlayer2CardCount);
            this.Controls.Add(this.lblPlayer1CardCount);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbTrumpCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcTrash)).EndInit();
            this.pnlNumberOfCard.ResumeLayout(false);
            this.pnlNumberOfCard.PerformLayout();
            this.pnlLeftButtons.ResumeLayout(false);
            this.pnlRightButtons.ResumeLayout(false);
            this.pnlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMessage)).EndInit();
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
        private System.Windows.Forms.Panel pnlNumberOfCard;
        private System.Windows.Forms.Label lblNumberOfcard;
        private System.Windows.Forms.ComboBox cmpCardsNumber;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlLeftButtons;
        private System.Windows.Forms.Panel pnlRightButtons;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnOkResult;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.PictureBox pbMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnMessageOk;
        private System.Windows.Forms.ProgressBar prgTrash;
        private System.Windows.Forms.Timer timTrash;
        private System.Windows.Forms.RadioButton radDrag;
        private System.Windows.Forms.RadioButton radClick;
        private System.Windows.Forms.Label lblMode;
    }
}

