/*  Cards.cs - Defines an index-based Cards collection class
 *  Author:     Mervat Mustafa
 *  Since:      Feb 2020 <update>
 */

using System;
using System.Collections;


namespace  CardLib
{
    public class Cards : CollectionBase, ICloneable
    {

        /// <summary>
        /// Implementing cloning functionality for the Cards class.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Cards newCards = new Cards();
            foreach (Card sourceCard in List)
            {
                newCards.Add((Card)sourceCard.Clone());
            }
            return newCards;
        }

        /// <summary>
        ///  Add(), implemented as a strongly typed method.
        /// </summary>
        /// <param name="newCard"></param>
        public void Add(Card newCard)
        {
            List.Add(newCard);
        }

        /// <summary>
        ///  Remove(), implemented as a strongly typed method.
        /// </summary>
        /// <param name="oldCard"></param>
        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }

        /// <summary>
        /// An indexer is a special kind of property that you can add to a class to provide array-like access.
        /// </summary>
        /// <param name="cardIndex"></param>
        /// <returns></returns>
        public Card this[int cardIndex]
        {
            get
            {
                return (Card)List[cardIndex];
            }
            set
            {
                List[cardIndex] = value;
            }
        }
        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
        /// <summary>
        /// Check to see if the Cards collection contains a particular card.
        /// This calls the Contains() method of the ArrayList for the collection,
        /// which you access through the InnerList property.
        /// </summary>
        public bool Contains(Card card)
        {
            return InnerList.Contains(card);
        }
    }


}
