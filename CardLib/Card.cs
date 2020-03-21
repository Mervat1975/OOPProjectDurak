/*  Card.cs - Defines the Card  class
 *  Author:     Mervat Mustafa
 *  Author:     Maheera Shariq
 *  Since:      March 2020 <update>
 */
using System;
using System.Drawing;

namespace CardLib
{
    public class Card : ICloneable, IComparable
    {

        #region FIELD_AND_PROPERTTES
        /// <summary>
        /// Flag for trump usage. If true, trumps are valued higher
        /// than cards of other suits.
        /// </summary>
        public static bool useTrumps = false;

        /// <summary>
        /// Trump suit to use if useTrumps is true.
        /// </summary>
        public static Suit trump = Suit.Club;

        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces.
        /// </summary>
        public static bool isAceHigh = true;

        /// <summary>
        /// Suite Property
        /// Used to set or get the Card Suite
        /// </summary>
        protected Suit mySuit;
        public Suit TheSuit
        {
            get { return mySuit; }
            set { mySuit = value; }

        }
        /// <summary>
        /// Rank Property
        /// Used to set or get the Card Rank
        /// </summary>
        protected Rank myRank;
        public Rank TheRank
        {
            get { return myRank; }
            set { myRank = value; }
        }
        protected int myValue;
        public int TheValue
        {
            get { return myValue; }
            set { myValue = value; }
        }
        /// <summary>
        /// FaceUp property
        /// Used to set or get whether the card is face up.
        /// Set to false by default.
        /// </summary>
        protected bool faceUp = false;
        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }
        #endregion
        #region CONSTRUCTORS
        /// <summary>
        /// Constructor for instances of Card
        /// </summary>
        /// <param name="newSuit"></param>
        /// <param name="newRank"></param>
        public Card(Suit newSuit = Suit.Heart, Rank newRank = Rank.Ace)
        {
            TheSuit = newSuit;
            TheRank = newRank;
            TheValue = (int)newRank;
        }
        /// <summary>
        /// Constructor for  empty instances of CartesianPoint
        /// </summary>
        private Card()
        {
        }
        #endregion

        #region PUBLIC_METHODS

        public Image GetCardImage()
        {
            String imageName;
            Image cardImage;
            if (!faceUp)
            {
                imageName = "back";
            }
            else
            {
                String suiteString = this.mySuit.ToString();

                imageName = suiteString.Substring(0, 1) + (int)this.myRank;
            }
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
            return cardImage;
        }
        /// <summary>
        /// Implementing cloning functionally for the Card class.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// ToString - convert the rank and suit into a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "The " + TheRank + " of " + TheSuit + "s";

        }

        /// <summary>
        /// Overide operator to compares this card to the parameter card for equality.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }
        /// <summary>
        /// A hash code is a numeric value that is used to insert and idenntify the object in hash-code collections.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (TheRank==Rank.Ace)
            return 13 * (int)TheSuit + (int)TheRank + 13;
            else

            return 13 * (int)TheSuit + (int)TheRank;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj">The object the current instance is being compared to.</param>
        /// <returns>An integer indicating whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</returns>
        public int CompareTo(object obj)
        {
            if (obj is Card)
            {
                return this.GetHashCode() - obj.GetHashCode();
            }
            else
            {
                // throw an appropaite exception
                throw (new ArgumentException());

            }
        }
        #endregion
        #region RELATIONAL_OPERATORS
        /// <summary>
        /// Determines if two Cards are the same
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.TheSuit == card2.TheSuit) && (card1.TheRank == card2.TheRank);
        }
        /// <summary>
        /// Determines if two cards are not the same.
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
       
        /// <summary>
        /// Determines if the card1 is greater than card2 
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator >(Card card1, Card card2)
        {
            if (card1.TheSuit == card2.TheSuit)
            {
                if (isAceHigh)
                {
                    if (card1.TheRank == Rank.Ace)
                    {
                        if (card2.TheRank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.TheRank == Rank.Ace)
                            return false;
                        else
                            return (card1.TheRank > card2.TheRank);
                    }
                }
                else
                {
                    return (card1.TheRank > card2.TheRank);
                }
            }
            else
            {
                if (useTrumps && (card2.TheSuit == Card.trump))
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// Determines if the card1 is less than card2 
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }
        /// <summary>
        /// Determines if the card1 is greater than eqaul to card2 
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.TheSuit == card2.TheSuit)
            {
                if (isAceHigh)
                {
                    if (card1.TheRank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (card2.TheRank == Rank.Ace)
                            return false;
                        else
                            return (card1.TheRank >= card2.TheRank);
                    }
                }
                else
                {
                    return (card1.TheRank >= card2.TheRank);
                }
            }
            else
            {
                if (useTrumps && (card2.TheSuit == Card.trump))
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// Determines if the card1 is less than eqaul to card2 
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }
        #endregion
    }

}
