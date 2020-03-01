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
	class CardContainerLayout : LayoutEngine
	{
		public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
		{
			Control parent = container as Control;
			Rectangle parentDisplayRectangle = parent.DisplayRectangle;
			Point nextCardLocation = parentDisplayRectangle.Location;

			foreach(Control c in parent.Controls)
			{
				//skip control if it is not visible
				if(!c.Visible)
				{
					continue;
				}


			}
		}
	}
}
