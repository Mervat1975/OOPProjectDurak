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
		int userID;
		TextUserDataHandler userDataHandler;

		public frmStatistics()
		{
			userDataHandler = new TextUserDataHandler("userData.txt", "userData.txt");
			InitializeComponent();
		}

		public frmStatistics(int userID, string storagePath)
		{
			this.userID = userID;
			userDataHandler = new TextUserDataHandler(storagePath, storagePath);
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

			populateListView();
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

		/// <summary>
		/// Populate the listview with the data of users
		/// </summary>
		private void populateListView()
		{
			lstStats.Items.Clear();

			if (rbAll.Checked)
			{
				for (int id = 0; id < userDataHandler.Records.Count; id++)
				{
					ListViewItem userListItem = new ListViewItem(userDataHandler.getName(id));

					userListItem.Checked = true;
					userListItem.SubItems.Add(userDataHandler.getWins(id).ToString());
					userListItem.SubItems.Add(userDataHandler.getTies(id).ToString());
					userListItem.SubItems.Add(userDataHandler.getLosses(id).ToString());
					userListItem.SubItems.Add(userDataHandler.getNumberOfGames(id).ToString());

					lstStats.Items.Add(userListItem);
				}
			}
			else
			{
				ListViewItem userListItem = new ListViewItem(userDataHandler.getName(userID));
				userListItem.Checked = true;
				userListItem.SubItems.Add(userDataHandler.getWins(userID).ToString());
				userListItem.SubItems.Add(userDataHandler.getTies(userID).ToString());
				userListItem.SubItems.Add(userDataHandler.getLosses(userID).ToString());
				userListItem.SubItems.Add(userDataHandler.getNumberOfGames(userID).ToString());

				lstStats.Items.Add(userListItem);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnHome_Click(object sender, EventArgs e)
		{
			this.Hide();
			new frmPlayerHome(userID, userDataHandler.ReadFilePath).ShowDialog();
			this.Close();
		}

		private void frmStatistics_Resize(object sender, EventArgs e)
		{

			lstStats.Width = this.Width - (rbAll.Width+1);
			lstStats.Height = this.Height;
			int columnWidth = Convert.ToInt32(Math.Round((double)lstStats.Width / 5));

			foreach(ColumnHeader column in lstStats.Columns)
			{
				column.Width = columnWidth;
			}
		}

		private void btnReload_Click(object sender, EventArgs e)
		{
			userDataHandler.reload();

			populateListView();
		}

		private void rbAll_CheckedChanged(object sender, EventArgs e)
		{
			populateListView();
		}
	}
}
