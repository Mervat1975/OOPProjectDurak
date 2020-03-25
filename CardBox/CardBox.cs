/*  CardBox.cs -  The card Box  class.
 *  Author:     Mervat Mustafa
 *  Since:      March 13, 2020 <update>
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLib;
namespace CardBox
{
    public partial class CardBox : UserControl
    {
        #region FIELDS_AND_PROPERTIES
        /// <summary>
        /// TheCard property: sets the underlying Card object
        /// </summary>
        private Card myCard;
        public Card TheCard
        {
            set
            {
                myCard = value;
                UpdateCardImage();// Update the Card image
            }
            get { return myCard; }
        }
        /// <summary>
        /// set and get the Suite of the TheCard
        /// </summary>
        public Suit TheSuit
        {
            set
            {
                TheCard.TheSuit = value;
                UpdateCardImage();
            }
            get
            {
                return TheCard.TheSuit;
            }
        }
        /// <summary>
        /// get and set the Rank of TheCard
        /// </summary>
        public Rank TheRank
        {
            set
            {
                TheCard.TheRank = value;
                UpdateCardImage();
            }
            get
            {
                return TheCard.TheRank;
            }
        }
        public bool FaceUp
        {
            set
            {
                if (myCard.FaceUp != value)
                {
                    myCard.FaceUp = value;
                    UpdateCardImage();
                    if (CardFlipped != null)
                        CardFlipped(this, new EventArgs());
                }
            }
            get { return TheCard.FaceUp; }
        }
        /// <summary>
        /// CardOrientation Property: sets/gets the Orientation of the card
        /// iIf setting this property chanages the state of control, swaps
        /// the height and width of the control and update the image
        /// </summary>
        private Orientation myOrientation;
        public Orientation TheOrientation
        {
            set
            {
                if (myOrientation != value)
                {
                    myOrientation = value;
                    this.Size = new Size(this.Size.Height, this.Size.Width);
                    UpdateCardImage();
                }
            }
            get { return myOrientation; }
        }

        
        #endregion
        #region CONTRUCTORS
        /// <summary>
        /// Constructor
        /// </summary>
        public CardBox()
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = new Card();

        }
        /// <summary>
        /// CardBox(Card, Orientation) , Constructs the control using parmeters
        /// </summary>
        /// <param name="card"></param>
        /// <param name="orientation"></param>
        public CardBox(Card card, Orientation orientation = Orientation.Vertical)
        {
            InitializeComponent();
            myOrientation = orientation;
            myCard = card;
        }
        #endregion
        #region OTHER_METHOD
        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();

            if (myOrientation == Orientation.Horizontal)
            {

                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            }
        }
        /// <summary>
        /// ToString()" Overrides object.System.ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TheCard.ToString();
        }
        #endregion
        #region EVENT_AND_EVENT_HANDLER
        /// <summary>
        /// An event handler for the load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }
        /// <summary>
        /// An event the client program can handle when the card flips face up/down.
        /// </summary>
        public event EventHandler CardFlipped;
        /// <summary>
        /// An event the client program can handle when the user clicks the control.
        /// </summary>
        new public event EventHandler Click;
        /// <summary>
        /// An event  handler for the user clicking the picturebox control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        new public event MouseEventHandler MouseDown;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pbMyPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
                MouseDown(this, e);

        }
    

        new public event DragEventHandler DragDrop;
        private void pbMyPictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDrop != null)
                DragDrop(this, e);
        }
       
        /// <summary>
        /// 
        /// </summary>
        new public event DragEventHandler DragEnter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMyPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (DragEnter != null)
                DragEnter(this, e);
        }


       
        new public event EventHandler MouseEnter;
        /// <summary>
        /// An event  handler for the user clicking the picturebox control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMyPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEnter != null)
                MouseEnter(this, e);
        }
       
        new public event EventHandler MouseLeave;
        /// <summary>
        /// An event  handler for the user clicking the picturebox control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMyPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (MouseLeave != null)
                MouseLeave(this, e);

        }
        #endregion
    } 

       
}
