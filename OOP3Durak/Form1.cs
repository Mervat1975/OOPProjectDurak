using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardControls;
using System.Diagnostics;
using CardLib;

namespace OOP3Durak
{
    public partial class Form1 : Form
    {
        private Rank currentRank = Rank.Queen;

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = false;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            /*
            if(e.Data.GetDataPresent(typeof(Card)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            */
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            cardControl1.CardBase = new Card(Suit.Heart, Rank.Nine);
            cardControl1.IsDraggable = true;

            cardControl2.IsFaceup = false;
            */

            cardContainer1.BorderStyle = BorderStyle.FixedSingle;
            //Test Deck layout of container
            cardContainer1.TrumpSuit = Suit.Diamond;
            //Add CardControls to the container
            for (int suitVal = 0; suitVal <= 3; suitVal++)
            {
                for(int rankVal = 6; rankVal <= 13; rankVal++)
                {
                    CardControl card = new CardControl();
                    card.CardBase = new Card((Suit)suitVal, (Rank)rankVal);

                    card.Parent = cardContainer1;
                }
            }

            cardContainer1.ContainerType = CardContainerType.Deck;
        }

        private void cardContainer1_Click(object sender, EventArgs e)
        {

        }
    }
}
