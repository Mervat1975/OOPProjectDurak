using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CardControls.Design
{
	[ToolboxItemFilter("CardControl.CardContainer", ToolboxItemFilterType.Require)]
	[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	class CardContainerDesigner : DocumentDesigner
	{
	}
}
