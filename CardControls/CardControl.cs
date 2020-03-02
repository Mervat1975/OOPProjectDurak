using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.ComponentModel.Design;
using CardLib;

namespace CardControls
{
	[Designer(typeof(Design.CardControlDesign), typeof(IRootDesigner))]
	public class CardControl : Control
	{
		private static int defaultCardWidth = 65;
		private static int defaultCardHeight = 86;
		private Card cardBase;
		private string imgResource = "Image";
		private static Dictionary<int, char> suitCodes;
		private static Dictionary<int, char> rankCodes;
		private bool drag = false;
		private bool isDraggable = false;
		private int previousMouseX = 0;
		private int previousMouseY = 0;
		private float previousRotationAngle = 0;
		private float rotationAngle = 0;

		/// <summary>
		/// Set or get the default width of the card
		/// </summary>
		public static int DefaultCardWidth { get => defaultCardWidth; set => defaultCardWidth = value; }

		/// <summary>
		/// Set or get the default height of the card
		/// </summary>
		public static int DefaultCardHeight { get => defaultCardHeight; set => defaultCardHeight = value; }

		public bool IsDraggable
		{
			get
			{
				return isDraggable;
			}

			set
			{
				isDraggable = value;
				drag = false;
			}
		}

		/// <summary>
		/// Get and set the card that the CardControl represents
		/// </summary>
		public Card CardBase {
			get
			{
				return cardBase;
			}

			set
			{ 
				cardBase = value;
				SetCardImage();
			} 
		}

		public string ImgResource { get => imgResource; set => imgResource = value; }
		public float RotationAngle { 
			get {
				return rotationAngle;
			}
			set {
				rotationAngle = value;
				this.Invalidate();
			} 
		}

		/*
		/// <summary>
		/// Initialize the essential parts of the control
		/// </summary>
		public CardControl()
		{
			
		}
		*/

		/// <summary>
		/// Get the ratio between the default width
		/// and default height of the card so as to
		/// maintain the preferred proportions of the card.
		/// </summary>
		/// <returns></returns>
		public static double GetCardSizeRatio()
		{
			return (DefaultCardWidth/DefaultCardHeight);
		}

		/// <summary>
		/// Get the appropriate card height required to maintain the
		/// preferred proportions given the width.
		/// </summary>
		/// <param name="width"></param>
		/// <returns></returns>
		public static int GetAppropriateHeight(int width)
		{
			return (int)Math.Round(width / GetCardSizeRatio());
		}

		/// <summary>
		/// Get the appropriate card width required to maintain the
		/// preferred proportions given the height.
		/// </summary>
		/// <param name="height"></param>
		/// <returns></returns>
		public static int GetAppropriateWidth(int height)
		{
			return (int)Math.Round(height * GetCardSizeRatio());
		}

		/// <summary>
		/// Set the card's width while maintaining the
		/// preferred proportion
		/// </summary>
		/// <param name="width"></param>
		public void SetCardWidth(int width)
		{
			this.Width = width;
			this.Height = CardControl.GetAppropriateWidth(this.Width);
		}

		/// <summary>
		/// Set the card's height while maintaining the
		/// preferred proportion
		/// </summary>
		/// <param name="height"></param>
		public void SetCardHeight(int height)
		{
			this.Height = height;
			this.Width = CardControl.GetAppropriateWidth(this.Height);
		}

		/// <summary>
		/// Set the card to the default size
		/// </summary>
		public void SetCardToDefaultSize()
		{
			this.Width = CardControl.DefaultCardWidth;
			this.Height = CardControl.DefaultCardHeight;

			this.Refresh();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		/// <summary>
		/// Set the image displayed by the control using
		/// the current CardBase
		/// </summary>
		private void SetCardImage()
		{
			//Use the rank and field to get the appropriate image resource name
			string rank;
			string prefix = "";
			string suit = suitCodes[(int)CardBase.suit].ToString();
			if(CardBase.rank > Rank.Ace && CardBase.rank < Rank.Jack)
			{
				rank = ((int)CardBase.rank).ToString();
				prefix = "_";
			}
			else
			{
				rank = rankCodes[(int)CardBase.rank].ToString();
			}

			//Set the image
			Image cardImage = (Properties.Resources.ResourceManager.GetObject(prefix+rank+suit) as Bitmap);

			ImgResource = prefix+rank+suit;

			this.BackgroundImage = cardImage;
		}

		/// <summary>
		/// Initialize the card to its default state
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			//Initialize rank and suit codes to enable correct image setting
			rankCodes = new Dictionary<int, char>();
			rankCodes.Add((int)Rank.Ace, 'A');
			rankCodes.Add((int)Rank.Jack, 'J');
			rankCodes.Add((int)Rank.King, 'K');
			rankCodes.Add((int)Rank.Queen, 'Q');

			suitCodes = new Dictionary<int, char>();
			suitCodes.Add((int)Suit.Club, 'C');
			suitCodes.Add((int)Suit.Diamond, 'D');
			suitCodes.Add((int)Suit.Heart, 'H');
			suitCodes.Add((int)Suit.Spade, 'S');

			CardBase = new Card(Suit.Diamond, Rank.Eight);

			this.BackgroundImageLayout = ImageLayout.Stretch;
			SetCardToDefaultSize();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			//this.DoDragDrop(CardBase, DragDropEffects.Copy);
			if (IsDraggable)
			{
				drag = true;
				previousMouseX = e.X;
				previousMouseY = e.Y;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			drag = false;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (drag)
			{
				int xDifference = e.X - previousMouseX;
				int yDifference = e.Y - previousMouseY;
				this.Location = new Point( this.Location.X + xDifference, this.Location.Y + yDifference);
			}
		}

		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			/*
			this.Location = new Point(drgevent.X, drgevent.Y);
			this.Invalidate();
			*/
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.RotateTransform(RotationAngle - previousRotationAngle);
			previousRotationAngle = RotationAngle;
			//this.Refresh();
		}
	}
}
