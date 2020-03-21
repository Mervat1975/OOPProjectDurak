/* CardOutOfRange.cs -    Defines the CardOutOfRange class.
 * Author:     Maheera Shariq
 * Since:      2020-02-28
*/
using System;
 
namespace CardLib
{
    class CardOutOfRangeException : Exception
    {
        private Cards deckContents;

        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }

        public CardOutOfRangeException(Cards sourceDeckContents)
           : base("There are only 52 cards in the deck.")
        {
            deckContents = sourceDeckContents;
        }

    }

}
