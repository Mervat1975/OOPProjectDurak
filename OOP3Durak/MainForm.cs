/**
 * MainForm.cs - The MainForm of the FormUIDemo Project
 * This project demonstrates adding and removing form controls dynamically. It also shows
 * relocating controls by clicking and by dragging. 
 * @author      Thom MacDonald <thom.macdonald@durhamcollege.ca>
 * @author      Mervat Mustafa <mervat.mustafa@durhamcollege.ca>
 * @author      Oghenefejiro Theodore Abohweyere <oghenefejiro.abohweyere@durhamcollege.ca>
 * @version     3.0
 * @since       2020-03-18
 * @image source https://favpng.com/png_view/king-cap-and-bells-jester-hat-card-game-durak-club-penguin-png/1gqKmMAV
 */



using CardBox;
using CardLib;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Media;
using GameLog;

namespace OOP3Durak
{

    public partial class frmMainForm : Form
    {
        #region FIELDS AND PROPERTIES
        public bool isDragMode = true;
        private static int TrashCardCount = 0;

        private int? id;
        private string storagePath;

        TextUserDataHandler userDataHandler;

        /// <summary>
        ///  Min number of the player card 
        /// </summary>
        private const int INITIAL_CARDS_NUMBER = 6;
        private CardBox.CardBox lastComputerAttack = null;
        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private bool isResult = false;
        private const int POP = 25;
        /// <summary>;
        /// The regular size of a CardBox control
        /// </summary>
        static private Size regularSize = new Size(100, 153);
        /// <summary>
        /// start card to fill the deck 
        /// </summary>
        public static int StartCard = 6;
        /// <summary>
        /// 
        /// </summary>
        int[] CardSettingData = new int[] { 10, 6, 2 };
        /// <summary>
        /// number of player to display
        /// </summary>
        public static int NumberOfPlayer = 2;
        /// <summary>
        /// trump card index depend on the number of player and number of cards
        /// </summary>
        public static int TrumpIndexCard = 13;
        /// <summary>
        /// the trump card object
        /// </summary>
        private Card TrumpCard = null;

        /// <summary>
        /// The cardbox that contains the card of the first successful attack.
        /// 
        /// This needs to be stored because according to the rules of Durak, the cards
        /// after this card will appear on their own(i.e no card will be stackd on them)
        /// </summary>
        private CardBox.CardBox firstSuccessfulAttackInRound = null;

        /// <summary>
        /// The size of the space at the sides of each card that seperate it
        /// from everything else 
        /// </summary>
        private int playPanelSidePadding = 6;

        /// <summary>
        /// The size of the space above and below the card that seperate it from everything
        /// else
        /// </summary>
        private int playPanelTopBottomPadding = 6;
        
        /// <summary>
        /// Percentage of the card's width that is covered when cards are stacked on each
        /// other
        /// </summary>
        private float playPanelPercOfCardWidthCovered = 0.30F;

        /// <summary>
        /// Used to generate Card objects from a Deck
        /// </summary>
        private CardDealer myDealer;

        /// <summary>
        /// Previous max index of the card in the play panel
        /// </summary>
        private int pmi = 0;

        /// <summary>
        /// Refers to the card being dragged from one panel to another.
        /// </summary>

        private CardBox.CardBox dragCard;
        private Hand playerHand1;
        private Hand playerHand2;
        private static int player1Move;
        private static int player2Move;

        #endregion

        #region FORM AND STATIC CONTROL EVENT HANDLERS
        private const int PLAER = 1;
        private const int COMPUTER = 0;

        private Cards plyRoundCards = new Cards();
        private List<CardBox.CardBox> orderedCardBoxes = new List<CardBox.CardBox>();

        private bool isComputerFaildeffense;

        /// <summary>
        /// Constructor for frmMainForm
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
        }

        public frmMainForm(int? id, string storagePath)
        {
            this.id = id;
            this.storagePath = storagePath;
            userDataHandler = new TextUserDataHandler(storagePath, storagePath);

            InitializeComponent();
        }

        /// <summary>
        /// Initializes the card dealer/deck on form Load.
        /// </summary>
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            myDealer = new CardDealer(StartCard, TrumpIndexCard);

            // Set the deck image to a card back image
            pbDeck.Image = Properties.Resources.ResourceManager.GetObject("deck_more_2") as Image;
            // Wire the out of cards event handler 
            myDealer.OutOfCards += myDealer_OutOfCards;
            // Show the number of cards in the deck
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            cmpCardsNumber.Text = lblCardCount.Text;
            // show number of cards for the game
            lblPlayer1CardCount.Text = "";
            lblPlayer2CardCount.Text = "";
            lblTrashCount.Text = "";
            lblCardNumber.Text += " " + myDealer.CardsRemaining.ToString();
            lblPlayer.Text += " " + NumberOfPlayer;
            btnReady.Focus();
            player1Move = 0;
            player2Move = 0;
            prgTrash.BackColor = Color.Black;
            prgTrash.ForeColor = Color.Orange;
            if (isDragMode)
            {
                radClick.Checked = false;
                radDrag.Checked = true;
                lblMode.Text = "Mode: Drag";
            }
            else
            {
                radClick.Checked = true;
                radDrag.Checked = false;
                lblMode.Text = "Mode: Click";
            }


        }
        /// <summary>
        /// change the cards number setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            pnlNumberOfCard.Visible = false;
            StartCard = CardSettingData[cmpCardsNumber.SelectedIndex];
            myDealer = new CardDealer(StartCard, TrumpIndexCard);
            lblCardNumber.Text = "Number of Cards:"+myDealer.CardsRemaining.ToString();
            pnlLeftButtons.Enabled = true;
            pnlRightButtons.Enabled = true;
            pnlPlay.Enabled = true;
            pnlCardPlayer1.Enabled = true;
            if (radDrag.Checked)
            {
                isDragMode = true;
               
                lblMode.Text = "Mode: Drag";
            }
            else
            {
                isDragMode = false;
                lblMode.Text = "Mode: Click";
            }
            ResetDealer();
        }

        /// <summary>
        /// Closes the current form.
        /// </summary>

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// fill the player Hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBat_Click(object sender, EventArgs e)
        {
            timTrash.Start();
        }

        private void btnOkResult_Click(object sender, EventArgs e)
        {
            pnlResult.Visible = false;
            pnlLeftButtons.Enabled = true;
            pnlRightButtons.Enabled = true;
            pnlPlay.Enabled = true;
            pnlCardPlayer1.Enabled = true;
            ResetDealer();

        }

        /// <summary>
        /// Drag Drop on the play area 
        /// Move a card/control when it is dropped from one player1 area  to play area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPlay_DragDrop(object sender, DragEventArgs e)
        {
            
            // If there is a CardBox to move
            if (dragCard != null)
            {
                // MessageBox.Show( "Add card"+ x.ToString());
                if (!AddCardTPlayPanel())
                {
                    SoundPlayer snd = new SoundPlayer(Properties.Resources.wrong1);
                    snd.Play();
                    ShowMessage("Unacceptable Card", "wrong"); }
                 
                GetResult();
            }
        }
        /// <summary>
        /// start the game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReady_Click(object sender, EventArgs e)
        {

            SoundPlayer snd = new SoundPlayer(Properties.Resources.ready);
            snd.Play();

            prgTrash.Visible = false;
            Card card = null;
            //  create hand for players
            playerHand1 = new Hand(true, 1, myDealer.GetCard(TrumpIndexCard - 1).TheSuit);
            playerHand2 = new Hand(false, 2, myDealer.GetCard(TrumpIndexCard - 1).TheSuit);
            for (int i = 0; i < INITIAL_CARDS_NUMBER; i++)
            {
                myDealer.DrawCard(ref card);
                playerHand1.Add(card);
                myDealer.DrawCard(ref card);
                playerHand2.Add(card);
            }
            // drow the trump card

            playerHand1.Sort();
            playerHand2.Sort();

            // get the trump card
            myDealer.DrawCard(ref TrumpCard);
            TrumpCard.FaceUp = true;
            
            lblTrump.Text ="Trump: " + TrumpCard.TheSuit.ToString();
            pbTrumpCard.Image = TrumpCard.GetCardImage() as Image;
            pbTrumpCard.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            TrumpCard.FaceUp = false;
            myDealer.AddCard(TrumpCard);
            Card smallestTrumpPlayer1 = null;
            Card smallestTrumpPlayer2 = null;
            for (int i = 0; i < INITIAL_CARDS_NUMBER; i++)
            {

                pnlCardPlayer1.Controls.Add(GetCardBox(playerHand1.CardList[i] as Card, PLAER));
                if ((playerHand1.CardList[i] as Card).TheSuit == TrumpCard.TheSuit)
                    smallestTrumpPlayer1 = playerHand1.CardList[i] as Card;
                   pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, COMPUTER));
                if ((playerHand2.CardList[i] as Card).TheSuit == TrumpCard.TheSuit)
                    smallestTrumpPlayer2 = playerHand2.CardList[i] as Card;
            }

            RealignCards(pnlCardPlayer2);
            RealignCards(pnlCardPlayer1);

            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            btnTake.Enabled = false;
            btnTake.ForeColor = Color.Gray;
            btnReady.Enabled = false;
            btnReady.ForeColor = Color.Gray;
            btnNewGame.Enabled = true;
            btnNewGame.ForeColor = Color.Orange;
            ///  determine who is the first attacker
            if (smallestTrumpPlayer1 is null && smallestTrumpPlayer2 is null)
            { 
                playerHand1.IsAttacker = true;
                playerHand2.IsAttacker = false;
            }
            else if (smallestTrumpPlayer1 is null && !( smallestTrumpPlayer2 is null))
               {
                playerHand1.IsAttacker = false;
                playerHand2.IsAttacker = true;
                }
            else if (!(smallestTrumpPlayer1 is null) &&  smallestTrumpPlayer2 is null)
            {
                playerHand1.IsAttacker = true;
                playerHand2.IsAttacker = false;
            }
            else
            {
                if(smallestTrumpPlayer1.TheRank< smallestTrumpPlayer2.TheRank)
                {
                    playerHand1.IsAttacker = true;
                    playerHand2.IsAttacker = false;
                }
                    else
                {
                    playerHand1.IsAttacker = false;
                    playerHand2.IsAttacker = true;
                }

            }
             if(playerHand1.IsAttacker)
            {
                lblTurn.Text = "Attack";
            }
             else
            {
                GetComputerAttack();
            }
            ///

            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            player1Move = 0;
            player2Move = 0;
        }
        /// <summary>
        /// add the cards from play area to  the player area hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTake_Click(object sender, EventArgs e)
        {
            
            foreach (CardBox.CardBox aCardBox in pnlPlay.Controls)
            {
                aCardBox.TheCard.FaceUp = true;
                playerHand1.Add(aCardBox.TheCard);
            }
            isComputerFaildeffense = false;
            pnlPlay.Controls.Clear();          
            plyRoundCards.Clear();
            orderedCardBoxes.Clear();
            firstSuccessfulAttackInRound = lastComputerAttack;
            FillHand(); 
            lblTurn.Text = "";
            btnTake.Enabled = false;
            btnTake.ForeColor = Color.Gray;
            btnBat.Enabled = false;
            btnBat.ForeColor = Color.Gray;
            btnPass.Enabled = false;
            btnPass.ForeColor = Color.Gray;
            GetComputerAttack();
            player1Move = 0;
            player2Move = 0;

        }

        /// <summary>
        /// Removes the card back image when the deck is out of cards.
        /// </summary>
        private void myDealer_OutOfCards(object sender, EventArgs e)
        {
            pbDeck.Image = null;
        }

        /// <summary>
        /// Make the mouse pointer a "move" pointer when a drag enters a Panel.
        /// </summary>

        private void pnlPlay_DragEnter(object sender, DragEventArgs e)
        {

            if (pnlPlay.Controls.Count == 0 || playerHand1.IsAttacker)
                e.Effect = DragDropEffects.Move; // Make the mouse pointer a "move" pointer
            else
                e.Effect = DragDropEffects.None;
        }

        private void pnlCardPlayer1_DragOver(object sender, DragEventArgs e)
        {
            if (dragCard != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void pnlPlay_DragOver(object sender, DragEventArgs e)
        {
            if (dragCard != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }


        /// <summary>
        /// Clears the panels and resets the card dealer.
        /// </summary>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Reset the card dealer
            pnlNumberOfCard.Top = (this.Height - pnlNumberOfCard.Height) / 2;
            pnlNumberOfCard.Left = (this.Width - pnlNumberOfCard.Width) / 2;
            pnlNumberOfCard.Visible = true;
            pnlLeftButtons.Enabled = false;
            pnlRightButtons.Enabled = false;
            pnlPlay.Enabled = false;
            pnlCardPlayer1.Enabled = false;
            prgTrash.Visible = false;


        }

        /// <summary>
        /// Pass the play area cards to the computer hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            foreach (CardBox.CardBox aCardBox in pnlPlay.Controls)
            {

                aCardBox.TheCard.FaceUp = false;
                playerHand2.Add(aCardBox.TheCard);
            }
            
            pnlPlay.Controls.Clear();
            plyRoundCards.Clear();
            orderedCardBoxes.Clear();
            btnTake.Enabled = false;
            btnTake.ForeColor = Color.Gray;
            btnBat.Enabled = false;
            btnBat.ForeColor = Color.Gray;
            btnPass.Enabled = false;
            btnPass.ForeColor = Color.Gray;
            lblTurn.Text = "Attack";
            isComputerFaildeffense = false;
            player1Move = 0;
            player2Move = 0;
            FillHand();
            GetResult();
        }

        /// <summary>
        ///  Increase the progress bar value 
        /// when the progress value reaches to the maximum 
        /// check the who is the attacker and made the right 
        ///  response and send the play area cards to trash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timTrash_Tick(object sender, EventArgs e)
        {
            if (prgTrash.Value == 0)
            {
                SoundPlayer snd = new SoundPlayer(Properties.Resources.trash1);
                snd.Play();
            }

            prgTrash.Visible = true;
            prgTrash.Value += 10;
            if (prgTrash.Value == prgTrash.Maximum)
            {
                if (!playerHand1.IsAttacker)
                {
                    btnTake.Enabled = false;
                    btnTake.ForeColor = Color.Gray;
                    btnTake.Focus();
                    btnBat.Enabled = false;
                    btnBat.ForeColor = Color.Gray;
                    btnPass.Enabled = false;
                    btnPass.ForeColor = Color.Gray;
                    playerHand1.CahangeRole();
                    playerHand2.CahangeRole();
                    lblTurn.Text = "Attack";
                    SendTrash();

                }
                else
                {
                    playerHand1.CahangeRole();
                    playerHand2.CahangeRole();
                    isComputerFaildeffense = false;
                    FillHand();
                    SendTrash();
                    GetResult();
                    GetComputerAttack();

                }

                prgTrash.Value = 0;
                prgTrash.Visible = false;
                timTrash.Stop();
            }
        }
        /// <summary>
        /// Demise the panel Messsage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessageOk_Click(object sender, EventArgs e)
        {
            DemiseMessage();
        }
        #endregion

        #region CARD BOX EVENT HANDLERS

        /// <summary>
        ///  CardBox controls grow in size when the mouse is over it.
        /// </summary>
        void CardBox_MouseEnter(object sender, EventArgs e)
        {

            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                aCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);// Enlarge the card for visual effect
                aCardBox.Top = 0;// move the card to the top edge of the panel.              
            }
        }
        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                aCardBox.Size = regularSize; // resize the card back to regular size
                aCardBox.Top = POP; // move the card down to accommodate for the smaller size.
               
                
            }
        }
        /// <summary>
        /// Initiate a card move on the start of a drag.
        /// </summary>
        private void CardBox_MouseDown(object sender, MouseEventArgs e)
        {

            // Set dragCard 
            dragCard = sender as CardBox.CardBox;
            
            // If the conversion worked
            if (dragCard != null)
            {

                // Set the data to be dragged and the allowed effect dragging will have
                DoDragDrop(dragCard, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// Initiate a card move on the start of a drag.
        /// </summary>
        private void CardBox_MouseUp(object sender, MouseEventArgs e)
        {

            CardBox.CardBox aCardBox = sender as CardBox.CardBox;
           // MessageBox.Show("MouseUp" + aCardBox.ToString());

        }
        /// <summary>
        /// When a CardBox is clicked, move to the opposite panel.
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox

            CardBox.CardBox aCardBox = sender as CardBox.CardBox;
            
            // If the conversion worked
            if (aCardBox != null)
            {
                dragCard = aCardBox;               
                if (!AddCardTPlayPanel())
                {
                    SoundPlayer snd = new SoundPlayer(Properties.Resources.wrong1);
                    snd.Play();
                    ShowMessage("Unacceptable Card", "wrong");
                }

                GetResult();
            }
        }

         
  

     
        #endregion

        #region HELPER METHODS

        /// <summary>
        /// Add new card to the play area
        /// </summary>
        /// <param name="cardBox"></param>
        public bool AddCardTPlayPanel()
        {
            //MessageBox.Show("playerHand1.IsAttacker: " + playerHand1.IsAttacker.ToString());

           

            if (player1Move == 6) return false;
            bool isAcceptable = false;
            // the droped card comes from player1 as attacker
            if (playerHand1.IsAttacker == true)
            { 
                
                //MessageBox.Show("IsValidAttack: " + (IsValidAttack(dragCard.TheCard)).ToString());
                //  either the first attack or re-attack
                if (IsValidAttack(dragCard.TheCard))
                {
                    SoundPlayer snd = new SoundPlayer(Properties.Resources.card);
                    snd.Play();

                    player1Move++;
                    isAcceptable = true;
                    // reomve cardbox events
                    dragCard.MouseEnter -= CardBox_MouseEnter;
                    dragCard.MouseLeave -= CardBox_MouseLeave;
                    dragCard.MouseDown -= CardBox_MouseDown;
                    dragCard.Click -= CardBox_Click;

                    // Remove the card from the Player1 Panel and hand
                    playerHand1.Remove(dragCard.TheCard);

                    pnlCardPlayer1.Controls.Remove(dragCard);
                    // Add the card to the play Panel  and play card list  
                    pnlPlay.Controls.Add(dragCard);
                    plyRoundCards.Add(dragCard.TheCard);
                    orderedCardBoxes.Add(dragCard);

                    lblTurn.Text = "";
                    // get the computer defence
                    if (!isComputerFaildeffense)
                        GetComputerDefence(dragCard.TheCard);
                }
            }
            else
            {
               // MessageBox.Show("IsValidDefence:" + (IsValidDefence(dragCard.TheCard)).ToString());
                if (IsValidDefence(dragCard.TheCard))
                {
                    SoundPlayer snd = new SoundPlayer(Properties.Resources.card);
                    snd.Play();

                    player1Move++;
                    isAcceptable = true;
                    dragCard.MouseEnter -= CardBox_MouseEnter;
                    dragCard.MouseLeave -= CardBox_MouseLeave;
                    dragCard.MouseDown -= CardBox_MouseDown;
                    dragCard.Click -= CardBox_Click;
                    pnlCardPlayer1.Controls.Remove(dragCard);
                    playerHand1.Remove(dragCard.TheCard);
                    // Add the card to the Panel it was dropped in 
                    pnlPlay.Controls.Add(dragCard);
                    plyRoundCards.Add(dragCard.TheCard);
                    orderedCardBoxes.Add(dragCard);
                    GetComputerReAttack();
                }
            }
            // Realign cards in both Panels
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            RealignCards(pnlCardPlayer1);
            RealignPlayPanel(pnlPlay);
         
            return isAcceptable;
        }

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand"></param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {   // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;
                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;
                // An offset for the remaining cards
                int offset = 0;
                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = (panelHand.Width - cardWidth - 2 * POP) / (myCount - 1);
                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                        offset = cardWidth;

                    // Determine width of all the cards/controls 
                    int allCardWidth = (myCount - 1) * offset + cardWidth;
                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardWidth) / 2;
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.
                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(panelHand.Controls[myCount - 1].Top.ToString() + "\n");
                panelHand.Controls[myCount - 1].Left = startPoint;
                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {// Align the current card
                    panelHand.Controls[index].Top = POP;

                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;
                }



            }
        }

        /// <summary>
        /// Arrange the cards that have been played according to the rules of Durak
        /// </summary>
        /// <param name="playPanel"></param>
        private void RealignPlayPanel(Panel playPanel)
        {
            if (playPanel.Controls.Count > 0)
            {
                int numberOfCards = playPanel.Controls.Count;
                int nMovesPerRow = 3;
                int nMovesPerColumn = numberOfCards / nMovesPerRow;
                float visibleWidthPercentage = 1 - playPanelPercOfCardWidthCovered;
                int cardWidth = 100; // playPanel.Controls[0].Width;
                int cardHeight = 153; // playPanel.Controls[0].Height;
                double currentRatio = (double)cardWidth / cardHeight;
                int visibleWidth = Convert.ToInt32(visibleWidthPercentage * cardWidth);

             /*   if (numberOfCards > nMovesPerRow * 2)
                {
                    //If the width of the cards is too big for them to fit in the panel
                    if ((nMovesPerRow * (cardWidth + visibleWidth)) + ((nMovesPerRow + 1) * playPanelSidePadding) > playPanel.Width)
                    {
                        //Choose the width of the cards to make them fit
                        cardWidth = Convert.ToInt32((playPanel.Width - (nMovesPerRow * playPanelSidePadding + 1)) / (nMovesPerRow * visibleWidthPercentage + 1));
                        cardHeight = Convert.ToInt32(cardWidth / currentRatio);
                    }

                    //If the height of the cards is too big for them to fit in the panel
                    if ((nMovesPerColumn * cardHeight) + ((nMovesPerColumn + 1) * playPanelTopBottomPadding) > playPanel.Height)
                    {
                        //Choose the height of the cards to make them fit
                        cardHeight = Convert.ToInt32((playPanel.Height - (nMovesPerColumn * playPanelTopBottomPadding + 1)) / nMovesPerColumn);
                        cardWidth = Convert.ToInt32(currentRatio * cardHeight);
                    }
                }*/

                if(pmi > numberOfCards-1)
                {
                    pmi = 0;
                }
                bool foundFailedDefense = false;

                //set position of first card
                Point nextCardLocation = playPanel.DisplayRectangle.Location;
                nextCardLocation.X += playPanelSidePadding;
                nextCardLocation.Y += playPanelTopBottomPadding;

                int secondColumnX = 0;
                int thirdColummnX = 0;
                //arrange the cards in the deck in reverse because the data structure returned
                //by the "Controls" property behaves kinda like a stack
                for (int index = 0; index < numberOfCards; index++)
                {
                    
                    //System.Diagnostics.Debug.WriteLine("Working index: " + working_index + "; Index: " + index);
                    CardBox.CardBox currentCardBox = orderedCardBoxes[index];
                    currentCardBox.Width = cardWidth;
                    currentCardBox.Height = cardHeight;
                    currentCardBox.Location = nextCardLocation;
                    currentCardBox.BringToFront();
                    //if the card of the failed defense has been found
                    if (foundFailedDefense)
                    {
                        //if the end of the row has been reached
                        if ((index == 3 && (pnlPlay.Controls[1] as CardBox.CardBox) == firstSuccessfulAttackInRound)
                            || (index == 2 && (pnlPlay.Controls[2] as CardBox.CardBox) == firstSuccessfulAttackInRound))
                        {
                            //move nextCardLocation to the next row
                            nextCardLocation = playPanel.DisplayRectangle.Location;
                            nextCardLocation.X += playPanelSidePadding;
                            nextCardLocation.Y += playPanelTopBottomPadding + playPanelTopBottomPadding + currentCardBox.Height;
                        }
                        else
                        {
                            nextCardLocation.X += currentCardBox.Width + playPanelSidePadding;
                        }
                    }
                    else
                    {
                        //Stack the cards on each other as dictated by the rules of Durak.
                        if (currentCardBox == firstSuccessfulAttackInRound)
                        {
                            foundFailedDefense = true;
                            System.Diagnostics.Debug.WriteLine("First successful attack found: " + currentCardBox);
                            //if the end of the row has been reached
                            if (index == 4)
                            {
                                //move nextCardLocation to the next row
                                nextCardLocation = playPanel.DisplayRectangle.Location;
                                nextCardLocation.X += playPanelSidePadding;
                                nextCardLocation.Y += playPanelTopBottomPadding + playPanelTopBottomPadding + currentCardBox.Height;
                            }
                            else
                            {
                                nextCardLocation.X += currentCardBox.Width + playPanelSidePadding;
                            }
                        }
                        else
                        {
                            //if the index is an even number then the card is an attack 
                            if (index % 2 == 0)
                            {
                                nextCardLocation.X += Convert.ToInt32(visibleWidthPercentage * currentCardBox.Width);
                            }
                            else
                            {
                                //if the end of the row has been reached
                                if (((index + 1) / 2) % nMovesPerRow == 0)
                                {
                                    //move nextCardLocation to the next row
                                    nextCardLocation = playPanel.DisplayRectangle.Location;
                                    nextCardLocation.X += playPanelSidePadding;
                                    nextCardLocation.Y += playPanelTopBottomPadding + playPanelTopBottomPadding + currentCardBox.Height;
                                }
                                else
                                {
                                    nextCardLocation.X += currentCardBox.Width + playPanelSidePadding;
                                }
                            }
                        }
                    }
                }
                pmi = numberOfCards - 1;
            }
            else
            {
                pmi = 0;
            }
        }

        /// <summary>
        /// Clears the panels and reloads the deck.
        /// </summary>
        void ResetDealer()
        {
            pmi = 0;
            firstSuccessfulAttackInRound = null;
            // Clear the panels and lists

            pnlCardPlayer1.Controls.Clear();
            pnlCardPlayer2.Controls.Clear();
            playerHand1.Clear();
            playerHand2.Clear();
            pnlPlay.Controls.Clear();
            plyRoundCards.Clear();
            orderedCardBoxes.Clear();
            lblTrump.Text = "";
            // Load the card dealer 
            myDealer.LoadCardDealer();
            // Set the image to a card back
            pbDeck.Image = Properties.Resources.ResourceManager.GetObject("deck_more_2") as Image;
            pbcTrash.Image = null;
            pbTrumpCard.Image = null;
            TrashCardCount = 0;
            lblTrashCount.Text ="";
            
            // Display the number of cards remaining in the deck. 
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            // fix the buttons Enabels and Fore color
            btnTake.Enabled = false;
            btnTake.ForeColor = Color.Gray;
            btnBat.Enabled = false;
            btnBat.ForeColor = Color.Gray;
            btnPass.Enabled = false;
            btnPass.ForeColor = Color.Gray;
            btnNewGame.Enabled = true;
            btnNewGame.ForeColor = Color.Orange;
            
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            btnReady.Enabled = true;
            btnReady.ForeColor = Color.Orange;
            
            lblPlayer1CardCount.Text = "";
            lblPlayer2CardCount.Text = "";
            lblTurn.Text = "";
            lblTrump.Text = "";
            isResult = false;


        }

        /// <summary>
        /// Get the cardbox control has the passing card 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="player"></param>
        /// <returns></returns>         
        private CardBox.CardBox GetCardBox(Card card, int player)
        {
            CardBox.CardBox aCardBox = null;
            // Create a new CardBox control based on the card drawn
            aCardBox = new CardBox.CardBox(card);
           if (player != COMPUTER)
            {
                aCardBox.FaceUp = true;
                // Wire events handlers to the new control:

                if( radClick.Checked)
                    aCardBox.Click += CardBox_Click;
                else
                 aCardBox.MouseDown += CardBox_MouseDown;
                // wire CardBox_MouseEnter for the "POP" visual effect  
                aCardBox.MouseEnter += CardBox_MouseEnter;
                // wire CardBox_MouseLeave for the regular visual effect
                aCardBox.MouseLeave += CardBox_MouseLeave;
            }

            return aCardBox;
        }
        /// <summary>
        /// get the computer defence card
        /// </summary>
        /// <param name="aCard"></param>
        public void GetComputerDefence(Card aCard)
        {
            if ( player2Move == 6) return;
                Card defencCard;
             
                defencCard = playerHand2.GetDefenceCard(aCard);

            if (!(defencCard is null))
            {
                SoundPlayer snd = new SoundPlayer(Properties.Resources.card);
                snd.Play();
                isComputerFaildeffense = false;
                player2Move++;
                playerHand2.Remove(defencCard);

                for (int i = 0; i < pnlCardPlayer2.Controls.Count; i++)
                {
                    CardBox.CardBox aCardBox = pnlCardPlayer2.Controls[i] as CardBox.CardBox;
                    if (aCardBox.TheCard == defencCard)
                    {
                        pnlCardPlayer2.Controls.Remove(aCardBox);
                        aCardBox.FaceUp = true;
                        pnlPlay.Controls.Add(aCardBox);
                        plyRoundCards.Add(aCardBox.TheCard);
                        orderedCardBoxes.Add(aCardBox);
                        btnBat.Enabled = true;
                        btnBat.ForeColor = Color.Orange;
                        btnPass.Enabled = false;
                        btnPass.ForeColor = Color.Gray;
                        btnTake.Enabled = false;
                        btnTake.ForeColor = Color.Gray;
                        btnBat.Focus();
                        lblTurn.Text = "Bat or Re-attack";

                    }
                }
                RealignCards(pnlCardPlayer2);
                //RealignCards(pnlPlay);
                lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
                lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
              GetResult(); 
            }

            else// no defence card
            {
                //if no successful attack has been set
                if (firstSuccessfulAttackInRound is null)
                {
                    firstSuccessfulAttackInRound = dragCard;
                    System.Diagnostics.Debug.WriteLine("GetComputerDefence: " + firstSuccessfulAttackInRound);
                }
                isComputerFaildeffense = true;
                btnPass.Enabled = true;
                btnPass.ForeColor = Color.Orange;
                btnBat.Enabled = false;
                btnBat.ForeColor = Color.Gray;
                btnTake.Enabled = false;
                btnTake.ForeColor = Color.Gray;
                btnPass.Focus();
                lblTurn.Text = "Pass";                
            }
            
        }
        /// <summary>
        /// to fill the players hand from the card dealer
        /// </summary>
        public void FillHand()
        { 
             
            Card card = null;
             
            while (playerHand1.RemainingCards() < INITIAL_CARDS_NUMBER && myDealer.CardsRemaining != 0)
            { if (myDealer.CardsRemaining > 0)
                {
                    myDealer.DrawCard(ref card);
                    playerHand1.Add(card);
                }

            }
            
           while ( playerHand2.RemainingCards() < INITIAL_CARDS_NUMBER && myDealer.CardsRemaining != 0)
            {    
                if (myDealer.CardsRemaining > 0)
                {
                    myDealer.DrawCard(ref card);
                    playerHand2.Add(card);
                }
            }

           
            playerHand1.Sort();
            playerHand2.Sort();

            pnlCardPlayer1.Controls.Clear();
            pnlCardPlayer2.Controls.Clear();
            for (int i = 0; i < playerHand1.RemainingCards(); i++)
            {

                pnlCardPlayer1.Controls.Add(GetCardBox(playerHand1.CardList[i] as Card, PLAER));

            }

            for (int i = 0; i < playerHand2.RemainingCards(); i++)
            {
                pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, COMPUTER));
            }

            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            RealignCards(pnlCardPlayer1);
            RealignCards(pnlCardPlayer2);
            if (myDealer.CardsRemaining == 0)
            {
                pbDeck.Image = null;
                pbTrumpCard.Image = null;
            }
            else if (myDealer.CardsRemaining == 3)
            {
                pbDeck.Image =Properties.Resources.ResourceManager.GetObject("deck_equal_2") as Image;

            }
            else if (myDealer.CardsRemaining == 2)
            {
                pbDeck.Image = Properties.Resources.ResourceManager.GetObject("back") as Image;

            }
            else if (myDealer.CardsRemaining == 1)
            {
                pbDeck.Image = null;
            }

        }
        /// <summary>
        /// Get the computer attack
        /// </summary>
        public void GetComputerAttack()
        {
            if (player2Move == 6) return;
            Card aCard = playerHand2.getAttack();
            if (!(aCard is null))
            {
                SoundPlayer snd = new SoundPlayer(Properties.Resources.card);
                snd.Play();
                player2Move++;
                CardBox.CardBox aCardBox = new CardBox.CardBox(aCard);
                aCardBox.FaceUp = true;
                pnlCardPlayer2.Controls.Clear();
                playerHand2.Remove(aCard);
                for (int i = 0; i < playerHand2.RemainingCards(); i++)
                {
                    pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, COMPUTER));

                }
                lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
                btnTake.Enabled = true;
                btnTake.ForeColor = Color.Orange;
                btnBat.Enabled = false;
                btnBat.ForeColor = Color.Gray;
                btnPass.Enabled = false;
                btnPass.ForeColor = Color.Gray;
                btnTake.Focus();

                // Add the card to the play panel   
                pnlPlay.Controls.Add(aCardBox);
                plyRoundCards.Add(aCardBox.TheCard);
                orderedCardBoxes.Add(aCardBox);
                // Realign cards in both Panels
                //RealignPlayPanel(pnlPlay);
                RealignCards(pnlCardPlayer2);
                lastComputerAttack = aCardBox;
                lblTurn.Text = "Defence or Take";
            }else
            {
                GetResult();
            }
        }
        /// <summary>
        /// Get the computer attack
        /// </summary>
        public void GetComputerReAttack()
        {
            if (player2Move == 6) return;

            Card aCard = playerHand2.getReAttack(plyRoundCards);

            if (!(aCard is null))
            {
                SoundPlayer snd = new SoundPlayer(Properties.Resources.card);
                snd.Play();
              player2Move ++;
                CardBox.CardBox aCardBox = new CardBox.CardBox(aCard);
                aCardBox.FaceUp = true;
                pnlCardPlayer2.Controls.Clear();
                playerHand2.Remove(aCard);
                for (int i = 0; i < playerHand2.RemainingCards(); i++)
                {
                    pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, COMPUTER));
                }
                lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
                btnTake.Enabled = true;
                btnTake.ForeColor = Color.Orange;
                btnTake.Focus();
                btnBat.Enabled = false;
                btnBat.ForeColor = Color.Gray;
                btnPass.Enabled = false;
                btnPass.ForeColor = Color.Gray;
                // Add the card to the play panel   
                pnlPlay.Controls.Add(aCardBox);
                plyRoundCards.Add(aCardBox.TheCard);
                orderedCardBoxes.Add(aCardBox);
                lastComputerAttack = aCardBox;
                // Realign cards in both Panels
                //RealignPlayPanel(pnlPlay);
                RealignCards(pnlCardPlayer2);
                lblTurn.Text = "Defence or Take";
                GetResult();
            }
            else
            {
                

                timTrash.Start();
                FillHand();

            }
            

        }
        /// <summary>
        /// This function checks if the player defence card is valid
        /// returns true unless returns false
        /// </summary>
        /// <param name="aCard"></param>
        /// <returns></returns>
        public bool IsValidDefence(Card aCard)
        {
            
            CardBox.CardBox attakedCard = lastComputerAttack;
             // MessageBox.Show(lastComputerAttack.ToString() + "VS" + aCard.ToString());
              
             
                if (aCard.TheSuit == attakedCard.TheCard.TheSuit)
                {
                if (aCard.TheRank == Rank.Ace) return true;
                if (attakedCard.TheRank == Rank.Ace) return false;
                return (aCard.TheRank > attakedCard.TheRank);

                }
                else
                {
                    return (aCard.TheSuit == TrumpCard.TheSuit);
                }
            

        }
        /// <summary>
        /// Move the card from play area to trash area
        /// </summary>
        public  void SendTrash()
        {

            TrashCardCount += pnlPlay.Controls.Count;
            plyRoundCards.Clear();
            orderedCardBoxes.Clear();
            lblTrashCount.Text = TrashCardCount.ToString();
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            if (TrashCardCount == 2)
                pbcTrash.Image = Properties.Resources.ResourceManager.GetObject("deck_equal_2") as Image;

            else
                pbcTrash.Image = Properties.Resources.ResourceManager.GetObject("deck_more_2") as Image;
            pnlPlay.Controls.Clear();
            player1Move = 0;
            player2Move = 0;
            pmi = 0;
            firstSuccessfulAttackInRound = null;
        }
        /// <summary>
        /// Get the Result
        /// </summary>
        public void GetResult()
        {
            if (myDealer.CardsRemaining > 0)
                return;
            SoundPlayer snd = null;
            String result = "";
            if (playerHand1.RemainingCards() == 0)
            {
                 snd = new SoundPlayer(Properties.Resources.winner1);
                snd.Play();
                result = "Congrats!! You are the WINNER";
                pbResult.Image = Properties.Resources.ResourceManager.GetObject("winner") as Image;

                int numericId = id ?? default(int);
                int? currentWins = userDataHandler.getWins(numericId);
                userDataHandler.setWins(numericId, (currentWins ?? default(int))+1);
                userDataHandler.UpdateAll();
            }
            else
        if (playerHand2.RemainingCards() == 0)
            {
                snd = new SoundPlayer(Properties.Resources.sad);
                snd.Stream.Position = 0;
                snd.Play();
                result = "Sorry!! your are the DURAK ";
                pbResult.Image = Properties.Resources.ResourceManager.GetObject("durak") as Image;

                int numericId = id ?? default(int);
                int? currentLosses = userDataHandler.getLosses(numericId);
                userDataHandler.setLosses(numericId, (currentLosses??default(int))+ 1);
                userDataHandler.UpdateAll();
            }
            else if (playerHand1.RemainingCards() == 0 && playerHand2.RemainingCards() == 0)
            {
                result = "Draw!!! ";
                pbResult.Image = Properties.Resources.ResourceManager.GetObject("good_jop") as Image;
                int numericId = id ?? default(int);
                int? currentTies = userDataHandler.getTies(numericId);
                userDataHandler.setTies(numericId, (currentTies ?? default(int))+1);
                userDataHandler.UpdateAll();
            }
            if (!result.Equals("")  && ! isResult)
            {
                
                pnlResult.Top = (this.Height - pnlResult.Height) / 2;
                pnlResult.Left = (this.Width - pnlResult.Width) / 2;
                lblResult.Text = result;
                pnlResult.Visible = true;
                pnlLeftButtons.Enabled = false;
                pnlRightButtons.Enabled = false;
                pnlPlay.Enabled = false;
                pnlCardPlayer1.Enabled = false;
                isResult = true;
                 
               
                
            }

        }
    
       /// <summary>
       /// This function checks the player reattack returns true 
       /// if it is valid unless returns false
       /// </summary>
       /// <param name="aReAttackCard"></param>
       /// <returns></returns>
        public bool IsValidAttack(Card aReAttackCard)
        {

             
            if (plyRoundCards.Count == 0 ) return true;
             
            foreach (Card aCard in plyRoundCards)
            {
                if (aReAttackCard.TheRank == aCard.TheRank)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// View the message panel and enable/disenable form panels
        /// </summary>
        /// <param name="message"></param>
        /// <param name="imgName"></param>
         public void ShowMessage( string message, string imgName)
        {
            lblMessage.Text = message;
            pbMessage.Image = Properties.Resources.ResourceManager.GetObject(imgName) as Image;

            pnlMessage.Top = (this.Height - pnlMessage.Height) / 2;
            pnlMessage.Left = (this.Width - pnlMessage.Width) / 2;
            pnlMessage.Visible = true;
            pnlLeftButtons.Enabled = false;
            pnlRightButtons.Enabled = false;
            pnlPlay.Enabled = false;
            pnlCardPlayer1.Enabled = false;
        }
        /// <summary>
        /// Demise the Messag box panel and enable/disanable form panels
        /// </summary>
        public void DemiseMessage()
        {
            pnlMessage.Visible = false;
            pnlLeftButtons.Enabled = true;
            pnlRightButtons.Enabled = true;
            pnlPlay.Enabled = true;
            pnlCardPlayer1.Enabled = true;
            prgTrash.Visible = false;
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radDrag_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
 
