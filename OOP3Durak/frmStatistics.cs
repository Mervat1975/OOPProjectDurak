/**
 * @author Oghenefejiro Abohweyere
 * @description This form displays the statistics for each user
 * @since 2020-04-12
 */
using System;
using System.Windows.Forms;
using GameLog;

namespace OOP3Durak
{
	public partial class frmStatistics : Form
	{
		int userID;
		TextUserDataHandler userDataHandler;

		/// <summary>
		/// Initialize the form with the default user data storage path
		/// </summary>
		public frmStatistics()
		{
			userDataHandler = new TextUserDataHandler("userData.txt", "userData.txt");
			InitializeComponent();
		}

		/// <summary>
		/// Store user id as well as the storage path of the user data file
		/// </summary>
		/// <param name="userID"></param>
		/// <param name="storagePath"></param>
		public frmStatistics(int userID, string storagePath)
		{
			this.userID = userID;
			userDataHandler = new TextUserDataHandler(storagePath, storagePath);
			InitializeComponent();
		}

		/// <summary>
		/// Add the column headers to the list view as soon as the form loads
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Close the entire application including hidden forms
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Display player home form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnHome_Click(object sender, EventArgs e)
		{
			this.Hide();
			new frmPlayerHome(userID, userDataHandler.ReadFilePath).Show();
		}

		/// <summary>
		/// Resize the list view with the form window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmStatistics_Resize(object sender, EventArgs e)
		{

			lstStats.Width = this.Width - (rbAll.Width+1);
			lstStats.Height = this.Height;

			lstStats.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		/// <summary>
		/// Reload the list view in case something has changed in the user data file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReload_Click(object sender, EventArgs e)
		{
			userDataHandler.reload();

			populateListView();
		}

		/// <summary>
		/// Populate the list view based on the checked
		/// radio button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbAll_CheckedChanged(object sender, EventArgs e)
		{
			populateListView();
		}
	}
}
