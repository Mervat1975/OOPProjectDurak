/*  Hand.cs - Defines the Hand class
*  Author:     Mervat Mustafa
*  Since:      March 2020 <update>
*/
using System.Collections;
 
namespace CardLib
{
   public class Hand
    {
        public bool IsAttacker;
        public ArrayList CardList;
        public int PlayerHandNumber;
        public Suit TrumpSuit;
        #region CONSTRUCTOR
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isAttacker"></param>
        /// <param name="playerHandNumber"></param>
        /// <param name="trumpSuit"></param>
        public Hand(bool isAttacker , int playerHandNumber ,Suit trumpSuit)
        {
         CardList= new ArrayList();
            IsAttacker = isAttacker;
            PlayerHandNumber = playerHandNumber;
            TrumpSuit = trumpSuit;
        }
        #endregion
        #region PUBLIC METHODS
        /// <summary>
        /// Add new Card
        /// </summary>
        /// <param name="newCard"></param>
        public void Add(Card newCard)
        {
            CardList.Add(newCard);
            
        }
        /// <summary>
        /// Remove a card 
        /// </summary>
        /// <param name="newCard"></param>
        public void Remove(Card newCard)
        {
            CardList.Remove(newCard);
        }
        /// <summary>
        /// sort the list item
        /// </summary>
        public void Sort()
        {
            CardList.Sort();
        }
        /// <summary>
        /// remove all the list items
        /// </summary>
        public void Clear()
        {
            CardList = new ArrayList();
        }
        /// <summary>
        /// change th roll of the player 
        /// </summary>
        public void CahangeRole()
        {
            IsAttacker = !IsAttacker;
        }
        /// <summary>
        /// return the number of the cards remaining
        /// </summary>
        /// <returns></returns>
        public int RemainingCards()
        {
            return CardList.Count;
        }
        /// <summary>
        /// Get the defence card depending on the passing card
        /// </summary>
        /// <param name="aCard"></param>
        /// <returns></returns>
        public Card GetDefenceCard(Card aCard)
        {

            
            foreach (Card listCard in CardList)
            {
                if (aCard.TheSuit == listCard.TheSuit)
                {
                    if (aCard.CompareTo( listCard)<0)
                    {
                        return listCard;
                    }
                }
            }
           if (aCard.TheSuit != TrumpSuit)
            foreach (Card listCard in CardList)
            {
                if (listCard.TheSuit == TrumpSuit )

                 return listCard;
            }


            return null;
        }
        /// <summary>
        /// get the attack card from the list
        /// </summary>
        /// <returns></returns>
        public Card getAttack()
        {
            if (CardList.Count > 0)
            {
                Card smallestRankCard = null;
                int listCounter = 0;
                while ( listCounter< CardList.Count && smallestRankCard is null)
                {
                    if ((CardList[listCounter] as Card).TheSuit != TrumpSuit)
                    {

                        smallestRankCard = CardList[listCounter] as Card;
                    }
                }

                foreach (Card cardList in CardList )
                {
                    if (cardList.TheSuit != TrumpSuit)
                        if (cardList.TheRank != Rank.Ace)
                            if (smallestRankCard.TheRank > cardList.TheRank)
                                smallestRankCard = cardList;
                }

                if (smallestRankCard is null)
                    smallestRankCard = CardList[0] as Card;

                return smallestRankCard;

            }
            else
                return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Card getReAttack(Cards aCards)
        {

            foreach (Card listCard in CardList)
            {  
                foreach(Card aCard in aCards)
                if (listCard.TheRank == aCard.TheRank)
                {
                    return listCard;
                }
            }
            return null;
        }

        #endregion
    }
}
