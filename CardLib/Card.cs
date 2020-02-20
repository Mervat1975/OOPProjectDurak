/*  Card.cs - Defines the Card  class
 * 
 *  Author:     Mervat Mustafa
 *  Since:      Feb 2020 <update>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public class Card : ICloneable
    {
        /// <summary>
        /// Implementing cloning functionality for the card class.
        /// </summary>
        /// <returns>A shallow copy of the object.</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
        public readonly Suit suit;
        public readonly Rank rank;
        /// <summary>
        /// Constructor for instances of Card
        /// </summary>
        /// <param name="newSuit"></param>
        /// <param name="newRank"></param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }
        /// <summary>
        /// Constructor for  empty instances of CartesianPoint
        /// </summary>
        private Card()
        {
        }
        /// <summary>
        /// ToString - converts the card  into a string in the accepted notation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }
    }
}
