/* CardDealer.cs - Defines the Card Dealer  class
 * Author:     Mervat Mustafa
 * Since:      March 2020 <update>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
     public class CardDealer : ICloneable
    {
        #region FIELD_AND_PROPERTTES
        private Deck myDeck;
        public  int NumberOfCards;
        public int Start;
        public int TrumpCardIndex;
        public  int CardsRemaining;
        public int CurrentCardIndex;
        #endregion
        #region CONSTRUCTORS
        /// <summary>
        /// Defualt Constrctor
        /// </summary>
        public CardDealer()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDeck"></param>
        public CardDealer( Deck newDeck)
        {
            myDeck = newDeck;
        }
        
        public CardDealer(int start, int trumpCardIndex)
        {
            myDeck = new Deck (start, trumpCardIndex);
            myDeck.Shuffle();
            Start = start;
            TrumpCardIndex = trumpCardIndex;
            CardsRemaining = myDeck.DeckCards.Count;
            CurrentCardIndex = 0;
        }

        #endregion
        #region PUBLIC METHODES
        /// <summary>
        /// Implementing cloning functionally for the Deck class.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            CardDealer newCardDealer = new CardDealer(myDeck.Clone() as Deck);
            return newCardDealer;
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadCardDealer()
        {
            myDeck = new Deck(Start, TrumpCardIndex);
            myDeck.Shuffle();
            CardsRemaining = myDeck.DeckCards.Count;
            CurrentCardIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool  DrawCard( ref Card card)
        {   if (CardsRemaining > 0)
            {
                card = myDeck.GetCard(CurrentCardIndex);
                CurrentCardIndex++;
                CardsRemaining--;
                return true;
            }
            else
                return false;

          
        }
        /// <summary>
        /// Get  a specific card from the dealer deck
        /// </summary>
        /// <param name="cardIndex"></param>
        /// <returns></returns>
        public Card GetCard( int cardIndex)
        {
            return myDeck.GetCard(cardIndex);
        }
        public void AddCard(Card aCard)
        {   
            CardsRemaining++;
            myDeck.Add(aCard);
            
             
        }
        #endregion
        #region EVENT AND EVENT HANDLER
        public event EventHandler OutOfCards;
        #endregion
    }
}
