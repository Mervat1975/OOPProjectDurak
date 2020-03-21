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
        /// <summary>
        /// 
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
        public  static int StartCard=6;
        /// <summary>
        /// number of player to display
        /// </summary>
        public  static int NumberOfPlayer=2;
        /// <summary>
        /// trump card index depend on the number of player and number of cards
        /// </summary>
        public static int TrampIndexCard=13;
        /// <summary>
        /// the trump card object
        /// </summary>
        private Card TrumpCard = null;
        /// <summary>
        /// Used to generate Card objects from a Deck
        /// </summary>
        private CardDealer myDealer;
        
        /// <summary>
        /// Refers to the card being dragged from one panel to another.
        /// </summary>

        private CardBox.CardBox dragCard;
        private Hand playerHand1 = new Hand();
        private Hand playerHand2 = new Hand();

        #endregion

        #region FORM AND STATIC CONTROL EVENT HANDLERS

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
            myDealer= new CardDealer(StartCard, TrampIndexCard);
            // Set the deck image to a card back image
            pbDeck.Image = Properties.Resources.ResourceManager.GetObject("deck_more_2") as Image;
            // Wire the out of cards event handler 
            myDealer.OutOfCards += myDealer_OutOfCards;
            // Show the number of cards in the deck
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            // show number of cards for the game
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
        /// Clears the panels and resets the card dealer.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset the card dealer
            ResetDealer();

            // Set option back to click
            optClick.Checked = true;
        }

        /// <summary>
        /// Resets the card dealer when the options are changed.
        /// </summary>
        private void optClick_CheckedChanged(object sender, EventArgs e)
        {
            ResetDealer();
        }


 
        /// <summary>
        /// start the game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReady_Click(object sender, EventArgs e)
        {
            Card card = null;
             // fill hand of the player 1
            for (int i = 0; i < INITIAL_CARDS_NUMBER; i++)
            {
                myDealer.DrawCard(ref card);
              playerHand1.Add(card);       
            }
            for (int i = 0; i < INITIAL_CARDS_NUMBER; i++)
            {
                myDealer.DrawCard(ref card);
                playerHand2.Add(card);

            }
            playerHand1.Sort();
            playerHand2.Sort();
            for (int i = 1; i < INITIAL_CARDS_NUMBER; i++)
            {
                 
                pnlCardPlayer1.Controls.Add(GetCardBox(playerHand1.CardList[i] as Card, 1));
                pnlCardPlayer2.Controls.Add(GetCardBox(playerHand2.CardList[i] as Card, 0));
            }
             
            RealignCards(pnlCardPlayer2);
            RealignCards(pnlCardPlayer1);
            
            
            if (myDealer.DrawCard(ref TrumpCard))
            {
                TrumpCard.FaceUp = true;
                pbTrumpCard.Image = TrumpCard.GetCardImage() as Image;
            } 

            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            btnReady.Enabled = false;
            btnReady.ForeColor = Color.Gray;
            btnNewGame.Enabled = true;
            btnNewGame.ForeColor = Color.Orange;
        }

        private void btnTake_Click(object sender, EventArgs e)
        {

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
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; // Make the mouse pointer a "move" pointer
        }

        /// <summary>
        /// Move a card/control when it is dropped from one Panel to another.
        /// </summary>
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            // If there is a CardBox to move
            if (dragCard != null)
            {
                // Determine which Panel is which

                Panel thisPanel = sender as Panel;
                Panel fromPanel = dragCard.Parent as Panel;
                // if the Panels are not the same 
                if (thisPanel != null && fromPanel != null)
                {
                    // (this would happen if a card is dragged from one spot in the Panel to another)
                    // Remove the card from the Panel it started in
                    fromPanel.Controls.Remove(dragCard);
                    // Add the card to the Panel it was dropped in 
                    thisPanel.Controls.Add(dragCard);
                    // Realign cards in both Panels
                    RealignCards(thisPanel);
                    RealignCards(fromPanel);
                }
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
            // If the conversion worked
            if (aCardBox != null)
            {
                // if the card is in the home panel...
                if (aCardBox.Parent == pnlCardPlayer1)
                {
                    pnlCardPlayer1.Controls.Remove(aCardBox); // Remove the card from the home panel
                    pnlPlay.Controls.Add(aCardBox);// Add the control to the play panel
                }
                else
                {
                    // otherwise...
                    // Remove the card from the play panel
                    pnlPlay.Controls.Remove(aCardBox);
                    // Add the control to the home panel
                    pnlCardPlayer1.Controls.Add(aCardBox);
                }
                // Realign the cards
                RealignCards(pnlCardPlayer1);
                RealignCards(pnlPlay);
            }

        }

        /// <summary>
        /// When a drag is enters a card, enter the parent panel instead.
        /// </summary>
        private void CardBox_DragEnter(object sender, DragEventArgs e)
        {
            //// Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            //// If the conversion worked
            if (aCardBox != null)
            {
                //    // Do the operation on the parent panel instead
                Panel_DragEnter(aCardBox.Parent, e);
            }
        }

        /// <summary>
        /// When a drag is dropped on a card, drop on the parent panel instead.
        /// </summary>
        private void CardBox_DragDrop(object sender, DragEventArgs e)
        {
            //// Convert sender to a CardBox
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            //// If the conversion worked
            if (aCardBox != null)
            {
                //    // Do the operation on the parent panel instead
                Panel_DragDrop(aCardBox.Parent, e);
            }
        }

        #endregion

        #region HELPER METHODS

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

            pbTrumpCard.Image = null;
            // Display the number of cards remaining in the deck. 
            lblCardCount.Text = myDealer.CardsRemaining.ToString();
            // fix the buttons Enabels and Fore color
            btnReady.Enabled = true;
            btnReady.ForeColor = Color.Orange;
            btnNewGame.Enabled = false;
            btnNewGame.ForeColor = Color.Gray;
        }

        private CardBox.CardBox GetCardFromDealer(int player)
        {
            Card card = new Card();
            CardBox.CardBox aCardBox = null;
            // Draw a card from the card dealer. If it worked...
            if (myDealer.DrawCard(ref card))
            {
                // Create a new CardBox control based on the card drawn
                aCardBox = new CardBox.CardBox(card);
                if (player != 0)
                {
                    aCardBox.FaceUp = true;
                    // Wire events handlers to the new control:
                    // if Click radio button is checked...

                    // Wire CardBox_Click
                    aCardBox.Click += CardBox_Click;

                    // otherwise...
                    // wire CardBox_MouseDown, CardBox_DragEnter, and CardBox_DragDrop
                    //  aCardBox.MouseDown += CardBox_MouseDown;
                    //  aCardBox.DragDrop  += CardBox_DragDrop;
                    //  aCardBox.DragEnter += CardBox_DragEnter;

                    // wire CardBox_MouseEnter for the "POP" visual effect  
                    aCardBox.MouseEnter += CardBox_MouseEnter;
                    // wire CardBox_MouseLeave for the regular visual effect
                    aCardBox.MouseLeave += CardBox_MouseLeave;
                }
               

            }
            return aCardBox;
        }

        private CardBox.CardBox GetCardBox(Card card , int player)
        {
             
            CardBox.CardBox aCardBox = null;
            // Draw a card from the card dealer. If it worked...
           
                // Create a new CardBox control based on the card drawn
                aCardBox = new CardBox.CardBox(card);
                if (player != 0)
                {
                    aCardBox.FaceUp = true;
                    // Wire events handlers to the new control:
                    // if Click radio button is checked...

                    // Wire CardBox_Click
                    aCardBox.Click += CardBox_Click;

                    // otherwise...
                    // wire CardBox_MouseDown, CardBox_DragEnter, and CardBox_DragDrop
                     //  aCardBox.MouseDown += CardBox_MouseDown;
                    //  aCardBox.DragDrop  += CardBox_DragDrop;
                    //   aCardBox.DragEnter += CardBox_DragEnter;

                    // wire CardBox_MouseEnter for the "POP" visual effect  
                    aCardBox.MouseEnter += CardBox_MouseEnter;
                    // wire CardBox_MouseLeave for the regular visual effect
                    aCardBox.MouseLeave += CardBox_MouseLeave;
                }


             
            return aCardBox;
        }

        #endregion

    }
}
