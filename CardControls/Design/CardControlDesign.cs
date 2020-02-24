using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CardControls.Design
{
	[ToolboxItemFilter("CardControl.CardControl", ToolboxItemFilterType.Require)]
	[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	class CardControlDesign : DocumentDesigner
	{
	}
}
