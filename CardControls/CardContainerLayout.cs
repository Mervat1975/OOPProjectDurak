using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace CardControls
{
	public class CardContainerLayout : LayoutEngine
	{
		public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
		{
			CardContainer parent = container as CardContainer;
			bool result = true;

			switch (parent.ContainerType)
			{
				case CardContainerType.PlayerHand: PlayerHandLayout(parent); break;
				case CardContainerType.Deck: DeckLayout(parent); break;
		    }
			return result;
		}

		/// <summary>
		/// Arranges the cards for the player's hand
		/// </summary>
		/// <param name="parent">The card container</param>
		private void PlayerHandLayout(CardContainer parent)
		{
			Rectangle parentDisplayRectangle = parent.DisplayRectangle;
			Point nextCardLocation = parentDisplayRectangle.Location;

			foreach (Control card in parent.Controls)
			{
				//skip control if it is not visible
				if (!card.Visible)
				{
					continue;
				}

				//Set the location of the current card and update the nextCardLocation
				card.Location = nextCardLocation;
				nextCardLocation.X += card.Width;

				//If the nextCardLocation is outside the bounds of the parent's horizontal margins
				if ((nextCardLocation.X + card.Width) > (parentDisplayRectangle.Location.X + parentDisplayRectangle.Width))
				{
					//Reset the nextCardLocation to the beginning of the next row
					nextCardLocation.X = parentDisplayRectangle.Location.X;
					nextCardLocation.Y += card.Height;

					//If the nextCardLocation is outside the bound of the parent's vertical margins
					if ((nextCardLocation.Y + card.Height) > (parentDisplayRectangle.Location.Y + parentDisplayRectangle.Height))
					{
						parent.Height += card.Height;
						parentDisplayRectangle = parent.DisplayRectangle;
					}
				}
			}
		}

		/// <summary>
		/// Arrange the cards in the deck
		/// </summary>
		/// <param name="parent"></param>
		private void DeckLayout(CardContainer parent)
		{
			bool trumpPicked = false;
			Random randGen = new Random();
			int xDelta = 2;
			int yDelta = 2;
			int cardsPerStack = Convert.ToInt32(Math.Round(Convert.ToDouble(parent.Controls.Count / 4)));
			cardsPerStack = cardsPerStack >= 1 ? cardsPerStack : 1;

			parent.Height = parent.Controls[0].Height*2;
			Rectangle parentDisplayRectangle = parent.DisplayRectangle;
			Point nextCardLocation = parentDisplayRectangle.Location;

			nextCardLocation.Y += parent.Controls[0].Height;

			for(int index = 0; index < parent.Controls.Count; index++)
			{
				CardControl card = parent.Controls[index] as CardControl;
				bool isPickedTrump = false;

				//skip control if it is not visible
				if (!card.Visible)
				{
					continue;
				}

				//flip card over
				card.IsFaceup = false;

				//If the current card has the trump suit decide whether to
				//display it to show the user what the trump suit is
				if(card.CardBase.suit == parent.TrumpSuit && !trumpPicked)
				{
					//Decide randomly whether to pick this card
					if(randGen.Next(1) == 1)
					{
						isPickedTrump = true;
						trumpPicked = true;
					}
				}
				
				//If the card is picked to be the card of the trump suit to be
				//displayed
				if(isPickedTrump)
				{
					card.IsFaceup = true;

					//Set the trump card to the top center of the container
					int trumpY = parent.Height; //nextCardLocation.Y + ((index % cardsPerStack) * yDelta);
					int midPointX = Convert.ToInt32(
						Math.Round(
							Convert.ToDouble(
								parentDisplayRectangle.Location.X
								+ (parentDisplayRectangle.Width/2))
							)
						);
					int trumpX = Convert.ToInt32(midPointX - (card.Width / 2));

					//card.Location = new Point(4, 0);

					card.Location = new Point(10, 10);
					continue;
				}

				//Put card on the current stack
				card.Location = nextCardLocation;

				//If the card is the last in the current stack
				//begin a new stack
				if((index % cardsPerStack) == cardsPerStack-1)
				{
					nextCardLocation.Y -= (cardsPerStack - 1) * yDelta;
					nextCardLocation.X += card.Width + 2;
				}
				else
				{
					nextCardLocation.Y += yDelta;
					nextCardLocation.X += xDelta;
				}

				//Resize the container if the card is not properly inside it
				if((nextCardLocation.X + card.Width) > (parentDisplayRectangle.Location.X + parentDisplayRectangle.Width))
				{
					parent.Width += (nextCardLocation.X + card.Width) - (parentDisplayRectangle.Location.X + parentDisplayRectangle.Width);
					parentDisplayRectangle = parent.DisplayRectangle;
				}

				if ((nextCardLocation.Y + card.Height) > (parentDisplayRectangle.Location.Y + parentDisplayRectangle.Height))
				{
					parent.Height += (nextCardLocation.Y + card.Height) - (parentDisplayRectangle.Location.Y + parentDisplayRectangle.Height);
					parentDisplayRectangle = parent.DisplayRectangle;
				}

				card.BringToFront();
			}
		}
	}
}
