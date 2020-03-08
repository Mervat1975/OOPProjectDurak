/* CardOutOfRange.cs -    Defines the CardOutOfRange class.
 * Author:     Maheera Shariq
 * Since:      2020-02-28
*/
using System;
 
namespace CardLib
{
    class CardOutOfRange : Exception
    {
        private Cards deckContents;

        public Cards DeckContents
        {
            get
            {
                return deckContents;
            }
        }

        public CardOutOfRange(Cards sourceDeckContents)
           : base("There are only 52 cards in the deck.")
        {
            deckContents = sourceDeckContents;
        }

    }

}
