/*  Deck.cs - Defines the Deck class
 *  Author:     Mervat Mustafa
 *  Since:      Feb 2020 <update>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  CardLib
{

    public class Deck : ICloneable
    {
        public event EventHandler LastCardDrawn;
       
        /// <summary>
        /// Nondefault constructor. Allows aces to be set high.
        /// </summary>
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }
        /// <summary>
        /// Nondefault constructor. Allows a trump suit to be used.
        /// </summary>
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Nondefault constructor. Allows aces to be set high and a trump suit
        /// to be used.
        /// </summary>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        /// <summary>
        /// Implementing cloning functionality for the Deck class.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }

        /// <summary>
        /// create new deck
        /// </summary>
        /// <param name="newCards"></param>
        private Deck(Cards newCards)
        {
            cards = newCards;
        }
        /// <summary>
        /// 
        /// </summary>
        private  Cards cards = new Cards();
        public Cards DeckCards
        {
            get { return cards; }
        }
        /// <summary>
        /// creat new deck (defualt constroctor)
        /// </summary>
        public Deck()
        {
            // Line of code removed here
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
        /// <summary>
        /// creat new deck (defualt constroctor)
        /// </summary>
        public Deck(int start , int trumpCardIndex)
        {
             
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                cards.Add(new Card((Suit)suitVal, Rank.Ace));
                for (int rankVal =start; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }

            Card.isAceHigh = true;
            Card.useTrumps = true;
            Card.trump = cards[trumpCardIndex].TheSuit;
        }
        /// <summary>
        /// get card from the deck
        /// </summary>
        /// <param name="cardNum"> number of the card which will be gettn</param>
        /// <returns></returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum < cards.Count)
            {
                if ((cardNum ==  cards.Count) && (LastCardDrawn != null))
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException((Cards)cards.Clone());
        }
        /// <summary>
        /// to shuffled the deck cards
        /// </summary>
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[ cards.Count];
            Random sourceGen = new Random();
            for (int i = 0; i <  cards.Count; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(cards.Count);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }


    }
}
