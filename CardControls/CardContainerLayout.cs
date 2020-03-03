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
			Control parent = container as Control;
			bool result = true;
			Rectangle parentDisplayRectangle = parent.DisplayRectangle;
			Point nextCardLocation = parentDisplayRectangle.Location;


			foreach(CardControl c in parent.Controls)
			{
				//skip control if it is not visible
				if(!c.Visible)
				{
					continue;
				}

				//Set the location of the current card and update the nextCardLocation
				c.Location = nextCardLocation;
				nextCardLocation.X += c.Width;

				//If the nextCardLocation is outside the bounds of the parent's horizontal margins
				if((nextCardLocation.X + c.Width)  > (parentDisplayRectangle.Location.X + parentDisplayRectangle.Width))
				{
					//Reset the nextCardLocation to the beginning of the next row
					nextCardLocation.X = parentDisplayRectangle.Location.X;
					nextCardLocation.Y += c.Height;

					//If the nextCardLocation is outside the bound of the parent's vertical margins
					if((nextCardLocation.Y + c.Height) > (parentDisplayRectangle.Location.Y + parentDisplayRectangle.Height))
					{
						parent.Height += c.Height;
						parentDisplayRectangle = parent.DisplayRectangle;
					}
				}

				//Rotate each control by 30 degrees
				//c.RotationAngle = 30;
			}

			return result;
		}
	}
}
