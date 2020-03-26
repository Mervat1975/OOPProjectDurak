/**
 * MainForm.cs - The MainForm of the FormUIDemo Project
 * 
 * This project demonstrates adding and removing form controls dynamically. It also shows
 * relocating controls by clicking and by dragging. 
 *  
 * @author      Thom MacDonald <thom.macdonald@durhamcollege.ca>
 * @author      Mervat Mustafa <mervat.mustafa@durhamcollege.ca>
 * @version     3.0
 * @since       2020-03-18
 * @see         <video link>
 */



using CardBox;
using CardLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP3Durak
{

    public partial class frmMainForm : Form
    {
        #region FIELDS AND PROPERTIES

        private static int TrashCardCount = 0;
        /// <summary>
        ///  Min number of the player card 
        /// </summary>
        private const int INITIAL_CARDS_NUMBER = 6;
        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>

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
        private int playPanelSidePadding = 1;

        /// <summary>
        /// The size of the space above and below the card that seperate it from everything
        /// else
        /// </summary>
        private int playPanelTopBottomPadding = 1;

        /// <summary>
        /// Percentage of the card's width that is covered when cards are stacked on each
        /// other
        /// </summary>
        private float playPanelPercOfCardWidthCovered = 0.10F;

        /// <summary>
        /// Used to generate Card objects from a Deck
        /// </summary>
        private CardDealer myDealer;

        /// <summary>
        /// Refers to the card being dragged from one panel to another.
        /// </summary>

        private CardBox.CardBox dragCard;
        private Hand playerHand1;
        private Hand playerHand2;

        #endregion

        #region FORM AND STATIC CONTROL EVENT HANDLERS
        private const int PLAER = 1;
        private const int COMPUTER = 0;

        /// <summary>
        /// Constructor for frmMainForm
        /// </summary>
        public frmMainForm()
        {
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
            // show number of cards for the game
            lblPlayer1CardCount.Text = "0";
            lblPlayer2CardCount.Text = "0";
            lblTrashCount.Text = TrashCardCount.ToString();
            lblCardNumber.Text += " " + myDealer.CardsRemaining.ToString();
            lblPlayer.Text += " " + NumberOfPlayer;
            btnReady.Focus();


        }

        /// <summary>
        /// Closes the current form.
        /// </summary>

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// fill the player Hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBat_Click(object sender, EventArgs e)
        {
            FillHand();
            SendTrash();
            GetComputerAttack();


        }
        /// <summary>
        /// Clears the panels and resets the card dealer.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset the card dealer
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
                AddCardTPlayPanel(dragCard);
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
            pbTrumpCard.Image = TrumpCard.GetCardImage() as Image;
            TrumpCard.FaceUp = false;
            myDealer.AddCard(TrumpCard);
           
            for (int i = 0; i < INITIAL_CARDS_NUMBER; i++)
            {

                pnlCardPlayer1.Controls.Add(GetCardBox(playerHand1.CardList[i] as Card, PLAER));
                pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, COMPUTER));
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
            lblTurn.Text = "Your Turn";
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            playerHand1.Add((pnlPlay.Controls[0] as CardBox.CardBox).TheCard as Card);
            pnlPlay.Controls.Clear();
            FillHand();
            GetComputerAttack();
            lblTurn.Text = "";
            btnTake.Enabled = false;
            btnTake.ForeColor = Color.Gray;


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
        /// When a CardBox is clicked, move to the opposite panel.
        /// </summary>
        void CardBox_Click(object sender, EventArgs e)
        {
            // Convert sender to a CardBox

            CardBox.CardBox aCardBox = sender as CardBox.CardBox;
            MessageBox.Show("Card Click" + aCardBox.ToString());
            // If the conversion worked
            if (aCardBox != null)
            {
                AddCardTPlayPanel(aCardBox);
            }

        }

        /// <summary>
        /// When a drag is enters a card, enter the parent panel instead.
        /// </summary>
        private void CardBox_DragEnter(object sender, DragEventArgs e)
        {
            //// Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;
            MessageBox.Show("Card DragEnter" + aCardBox.ToString());
            //// If the conversion worked
            if (aCardBox != null)
            {
                //    // Do the operation on the parent panel instead
                pnlPlay_DragEnter(aCardBox.Parent, e);
            }
        }

        /// <summary>
        /// When a drag is dropped on a card, drop on the parent panel instead.
        /// </summary>
        private void CardBox_DragDrop(object sender, DragEventArgs e)
        {
            //// Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;
            MessageBox.Show("Card DragDrop" + aCardBox.ToString());
            //// If the conversion worked
            if (aCardBox != null)
            {
                //    // Do the operation on the parent panel instead
                pnlPlay_DragDrop(aCardBox.Parent, e);
            }
        }


        #endregion

        #region HELPER METHODS

        /// <summary>
        /// Add new card to the play area
        /// </summary>
        /// <param name="cardBox"></param>
        public void AddCardTPlayPanel(CardBox.CardBox cardBox)
        {
            //MessageBox.Show("1");
            if (playerHand1.IsAttacker == true)
            {

                if (pnlPlay.Controls.Count == 0)
                {
                    // (this would happen if a card is dragged from one spot in the Panel to another)
                    // Remove the card from the Panel it started in
                    pnlCardPlayer1.Controls.Remove(dragCard);
                    // Add the card to the Panel it was dropped in 
                    pnlPlay.Controls.Add(dragCard);
                    // Realign cards in both Panels
                    RealignCards(pnlCardPlayer1);
                    RealignCards(pnlPlay);
                    lblTurn.Text = "";
                    // waite for a while
                     

                    GetComputerDefence(dragCard.TheCard);
                }
            }
            else if (IsValidDefence(dragCard.TheCard))
            {

                pnlCardPlayer1.Controls.Remove(dragCard);
                playerHand1.Remove(dragCard.TheCard);
                // Add the card to the Panel it was dropped in 
                pnlPlay.Controls.Add(dragCard);
                SendTrash();
                FillHand();
                btnBat.Enabled = false;
                btnBat.ForeColor = Color.Gray;
                btnTake.Enabled = false;
                btnTake.ForeColor = Color.Gray;
                // Realign cards in both Panels
                RealignCards(pnlCardPlayer1);
                RealignCards(pnlPlay);
                

            }

            

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
    
        private void RealignPlayPanel(Panel playPanel)
        {
            int numberOfCards = 6;
            int nCardsPerRow = 3;
            int nCardsPerColumn = numberOfCards / nCardsPerRow;
            int cardWidth = Convert.ToInt32((playPanel.Width - (nCardsPerRow * playPanelSidePadding + 1)) / nCardsPerRow);
            int cardHeight = Convert.ToInt32((playPanel.Height - (nCardsPerColumn * playPanelTopBottomPadding + 1))/nCardsPerColumn);

            bool foundFailedDefense = false;

            //set position of first card
            Point nextCardLocation = playPanel.DisplayRectangle.Location;
            nextCardLocation.X += playPanelSidePadding;
            nextCardLocation.Y += playPanelTopBottomPadding;

            //arrange the cards in the deck in reverse
            for(int index = numberOfCards; index >= 0; index--)
            {
                CardBox.CardBox currentCardBox = playPanel.Controls[index] as CardBox.CardBox;
                
                //if the card of the failed defense has been found and passed
                if(foundFailedDefense)
                {
                    currentCardBox.Location = nextCardLocation;

                    //if the end of the row has been reached
                    if (index % nCardsPerRow == nCardsPerRow - 1)
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
                        currentCardBox.Location = nextCardLocation;
                    }
                    else
                    {
                        //an even numbered index is an attack while
                        if(index % 2 == 0)
                        {
                            nextCardLocation.X += Convert.ToInt32((1 - playPanelPercOfCardWidthCovered) * currentCardBox.Width);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Clears the panels and reloads the deck.
        /// </summary>
        void ResetDealer()
        {
            // Clear the panels
            pnlCardPlayer1.Controls.Clear();
            pnlCardPlayer2.Controls.Clear();
            playerHand1.Clear();
            playerHand2.Clear();
            pnlPlay.Controls.Clear();

            // Load the card dealer 
            myDealer.LoadCardDealer();

            // Set the image to a card back
            pbDeck.Image = Properties.Resources.ResourceManager.GetObject("deck_more_2") as Image;
            pbcTrash.Image = null;
            pbTrumpCard.Image = null;
            TrashCardCount = 0;
            lblTrashCount.Text = TrashCardCount.ToString();
            // Display the number of cards remaining in the deck. 
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            // fix the buttons Enabels and Fore color
            btnTake.Enabled = false;
            btnTake.ForeColor = Color.Gray;
            btnBat.Enabled = false;
            btnBat.ForeColor = Color.Gray;
            btnNewGame.Enabled = true;
            btnNewGame.ForeColor = Color.Orange;
            lblTurn.Text = "Your Turn";
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            btnReady.Enabled = true;
            btnReady.ForeColor = Color.Orange;
            btnNewGame.Enabled = false;
            btnNewGame.ForeColor = Color.Gray;
            lblTurn.Text = "";
        }
         
         /// <summary>
         /// Get the cardbox control has the passing card 
         /// </summary>
         /// <param name="card"></param>
         /// <param name="player"></param>
         /// <returns></returns>         
        private CardBox.CardBox GetCardBox(Card card , int player)
        {
             
            CardBox.CardBox aCardBox = null;
            // Draw a card from the card dealer. If it worked...
           
                // Create a new CardBox control based on the card drawn
                aCardBox = new CardBox.CardBox(card);

               if (player != COMPUTER)
                {
                
                aCardBox.FaceUp = true;
                // Wire events handlers to the new control:
                // if Click radio button is checked...

                    // Wire CardBox_Click
                    aCardBox.Click += CardBox_Click;
                System.Diagnostics.Debug.WriteLine("Set click event for " + card);

                // wire CardBox_MouseDown, CardBox_DragEnter, and CardBox_DragDrop
                aCardBox.MouseDown += CardBox_MouseDown;
                     aCardBox.DragDrop  += CardBox_DragDrop;
                    aCardBox.DragEnter += CardBox_DragEnter;

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
        public  void GetComputerDefence( Card aCard)
        {
             
            
            //System.Threading.Thread.Sleep(1000);
            playerHand1.Remove(aCard);
            
            Card defencCard = playerHand2.GetDefenceCard(aCard);
           
            if ( !(defencCard  is null))
            {
                playerHand2.Remove(defencCard);
              
                for (int i = 0; i < pnlCardPlayer2.Controls.Count; i++)
                {  
                    CardBox.CardBox aCardBox = pnlCardPlayer2.Controls[i] as CardBox.CardBox;
                    if (aCardBox.TheCard == defencCard)
                    {
                        pnlCardPlayer2.Controls.Remove(aCardBox);
                        aCardBox.FaceUp = true;
                        pnlPlay.Controls.Add(aCardBox);
                        btnBat.Enabled = true;
                        btnBat.ForeColor = Color.Orange;
                        btnBat.Focus();
                        lblTurn.Text = "Click Bat";
                    }
                } 
            }
                 
            else// no defence card
            {

                CardBox.CardBox attackCard=pnlPlay.Controls[0] as CardBox.CardBox;
                
                playerHand2.Add(attackCard.TheCard);
                attackCard.TheCard.FaceUp = false;
                pnlPlay.Controls.Clear();
                lblTurn.Text = "Your Turn";

                    FillHand();
           }   
            RealignCards(pnlCardPlayer2);
            RealignCards(pnlPlay);
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();

        }
        /// <summary>
        /// to fill the players hand from the card dealer
        /// </summary>
        public void FillHand()
        {
            if (myDealer.CardsRemaining == 0) return;
            Card card = null;

            for (int i= 0; i< INITIAL_CARDS_NUMBER- playerHand1.RemainingCards();i++)
            {  if (myDealer.CardsRemaining>0)
                {
                    myDealer.DrawCard(ref card);

                    playerHand1.Add(card);
                }
               
            }
            for (int i = 0; i < INITIAL_CARDS_NUMBER - playerHand2.RemainingCards(); i++)
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

                pnlCardPlayer1.Controls.Add(GetCardBox(playerHand1.CardList[i] as Card, 1));
                
            }
             for (int i = 0; i < playerHand2.RemainingCards(); i++)
            {              
                pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, 0));
            }
         
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();   
            
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            RealignCards(pnlCardPlayer1);
            RealignCards(pnlCardPlayer2);
            if (myDealer.CardsRemaining==0)
            {
                pbDeck.Image = null;
                pbTrumpCard.Image = null;
            }
        }
        /// <summary>
        /// Get  the computer attack
        /// </summary>
         public void  GetComputerAttack()
        {
            Card aCard = playerHand2.getAttack();   
            CardBox.CardBox  aCardBox = new CardBox.CardBox(aCard);
            aCardBox.FaceUp = true;
            pnlCardPlayer2.Controls.Clear();
            playerHand2.Remove(aCard);
            for (int i = 0; i < playerHand2.RemainingCards(); i++)
            {
                pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, 0));
            }
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            btnTake.Enabled = true;
            btnTake.ForeColor = Color.Orange;
            btnTake.Focus();
            // Add the card to the play panel   
            pnlPlay.Controls.Add(aCardBox);
            // Realign cards in both Panels
            RealignCards(pnlPlay);
            RealignCards(pnlCardPlayer2);
            lblTurn.Text = "Your Turn";

        }
        /// <summary>
        /// check if the player defence card is valid 
        /// </summary>
        /// <param name="aCard"></param>
        /// <returns></returns>
         public  bool IsValidDefence( Card  aCard)
        {
            CardBox.CardBox attakedCard = pnlPlay.Controls[0] as CardBox.CardBox;
             if(aCard.TheSuit== attakedCard.TheCard.TheSuit)
                {
                return (aCard.CompareTo(attakedCard.TheCard) > 0);
                }
             else
              {
                return (aCard.TheSuit == TrumpCard.TheSuit);               
            }

        }
        /// <summary>
        /// 
        /// </summary>
         public void SendTrash()
        {
            playerHand1.CahangeRole();
            playerHand2.CahangeRole();
            TrashCardCount += 2;
            lblTrashCount.Text = TrashCardCount.ToString();
            lblPlayer1CardCount.Text = playerHand1.RemainingCards().ToString();
            lblPlayer2CardCount.Text = playerHand2.RemainingCards().ToString();
            pbcTrash.Image = Properties.Resources.ResourceManager.GetObject("deck_more_2") as Image;
            pnlPlay.Controls.Clear();
        }

        public void  GetResult()
        {

            String result = "";
            if (playerHand1.RemainingCards() == 0)

                result = "Congrats!! You are the Winner";
            else
                    if (playerHand2.RemainingCards() == 0)
              result="Sorry!! your the Druk ";
            else if (playerHand1.RemainingCards() == 0 && playerHand2.RemainingCards() == 0)
               result="Draw!!! ";
            if(!result.Equals(""))
            {
                MessageBox.Show(result);
                ResetDealer();
            }

        }
        #endregion

        private void pnlPlay_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
 
