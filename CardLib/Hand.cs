using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CardLib
{
   public class Hand
    {
         public ArrayList CardList = new ArrayList();
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
        /// 
        /// </summary>
        public void Sort()
        {
            CardList.Sort();
        }

        public void Clear()
        {
            CardList = new ArrayList();
        }

    }
}
