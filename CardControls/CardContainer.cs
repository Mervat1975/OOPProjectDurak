using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.ComponentModel.Design;
using System.ComponentModel;
using CardLib;

namespace CardControls
{
	public enum CardContainerType
	{
		Deck,
		PlayerHand,
		Trash,
		DurakGame,
	}

	[Designer(typeof(Design.CardContainerDesigner), typeof(IRootDesigner))]
	public class CardContainer : ContainerControl
	{
		private CardContainerLayout layoutEngine;
		private CardContainerType containerType = CardContainerType.PlayerHand;
		private Suit trumpSuit;

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

		}

		public override LayoutEngine LayoutEngine
		{
			get
			{
				if(layoutEngine == null)
					layoutEngine =  new CardContainerLayout();

				return layoutEngine;
			}
		}

		public Suit TrumpSuit
		{
			get => trumpSuit;
			set
			{
				trumpSuit = value;
				this.Invalidate();
			}
		}

		public CardContainerType ContainerType
		{
			get => containerType;
			set
			{
				containerType = value;
				this.Invalidate();
			}
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			//this.Invalidate();
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			//this.Invalidate();
		}
	}
}
