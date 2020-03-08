/*  Players.cs - Defines an index-based Players collection class
 *  Author:     Mervat Mustafa
 *  Since:      Feb 2020 <update>
 */

using System;
using System.Collections;

namespace CardLib
{
    public class Players: CollectionBase, ICloneable
    {
        /// <summary>
        /// Implementing cloning functionality for the Cards class.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Players newPlayers = new Players();
            foreach (Player sourcePlayer in List)
            {
                newPlayers.Add((Player)sourcePlayer.Clone());
            }
            return newPlayers;
        }

        

        /// <summary>
        ///  Add(), implemented as a strongly typed method.
        /// </summary>
        /// <param name="newCard"></param>
        public void Add(Player newPlayer)
        {
            List.Add(newPlayer);
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
        public Player this[int playerIndex]
        {
            get
            {
                return (Player)List[playerIndex];
            }
            set
            {
                List[playerIndex] = value;
            }
        }
        /// <summary>
        /// Utility method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        /// </summary>
        public void CopyTo(Players targetPlayers)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetPlayers[index] = this[index];
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