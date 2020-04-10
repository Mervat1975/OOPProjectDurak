using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLog;

namespace OOP3Durak
{
	public partial class frmStatistics : Form
	{
		TextUserDataHandler userDataHandler;

		public frmStatistics()
		{
			userDataHandler = new TextUserDataHandler("userData.txt", "userData.txt");
			InitializeComponent();
		}

		private void frmStatistics_Load(object sender, EventArgs e)
		{

			//lstStats.View = View.Details;
			int columnWidth = Convert.ToInt32(Math.Round((double)lstStats.Width / 5));

			lstStats.Columns.Add("Name", columnWidth, HorizontalAlignment.Center);
			lstStats.Columns.Add("Wins", columnWidth, HorizontalAlignment.Center);
			lstStats.Columns.Add("Draws", columnWidth, HorizontalAlignment.Center);
			lstStats.Columns.Add("Losses", columnWidth, HorizontalAlignment.Center);
			lstStats.Columns.Add("Number Of Games", columnWidth, HorizontalAlignment.Center);

			for(int id = 0; id < userDataHandler.Records.Count; id++)
			{
				ListViewItem userListItem = new ListViewItem(userDataHandler.getName(id));

				userListItem.Checked = true;
				userListItem.SubItems.Add(userDataHandler.getWins(id).ToString());
				userListItem.SubItems.Add(userDataHandler.getTies(id).ToString());
				userListItem.SubItems.Add(userDataHandler.getLosses(id).ToString());
				userListItem.SubItems.Add(userDataHandler.getNumberOfGames(id).ToString());

				lstStats.Items.Add(userListItem);
			}

			/*
			bool columnsAdded = false;
			foreach(Dictionary<string, string> record in records)
			{
				string[] values = new string[record.Keys.Count];
				int count = 0;
				foreach(string key in record.Keys)
				{
					if (!columnsAdded)
					{
						dgStats.Columns.Add(key, key);
					}
					values[count] = record[key];
					count++;
				}
				columnsAdded = true;
				dgStats.Rows.Add(values);
			}
			*/
		}
	}
}
