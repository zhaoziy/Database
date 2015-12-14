using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
	public partial class SearchOne : Form
	{
		List <SearchBoxComponent> searchBoxComponet = new List<SearchBoxComponent>();
		List<Button> DeleteComponet = new List<Button>();

		public SearchOne()
		{
			InitializeComponent();
			CreateSearchBoxComponet();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void Search_Bt_Click(object sender, EventArgs e)
		{
			string str = "SELECT * FROM [vehicleinfo] WHERE ";
			for(int iLoop = 0; iLoop < searchBoxComponet.Count - 1; ++iLoop)
			{
				if(searchBoxComponet[iLoop].GetLogical.ToLower() == "like" &&
					searchBoxComponet[iLoop].GetConditon != "")
				{
					str += searchBoxComponet[iLoop].GetOption + " like '%" + 
						searchBoxComponet[iLoop].GetConditon + "%' and ";
				}
				else if(searchBoxComponet[iLoop].GetConditon != "")
				{
					str += searchBoxComponet[iLoop].GetOption + ">" +
						searchBoxComponet[iLoop].GetNumLower + " and " +
						searchBoxComponet[iLoop].GetOption + "<" +
						searchBoxComponet[iLoop].GetNumUpper + " and ";
				}
			}

			if (searchBoxComponet[searchBoxComponet.Count - 1].GetLogical.ToLower() == "like" &&
						searchBoxComponet[searchBoxComponet.Count - 1].GetConditon != "")
			{
				str += searchBoxComponet[searchBoxComponet.Count - 1].GetOption + " like '%" +
					searchBoxComponet[searchBoxComponet.Count - 1].GetConditon + "%' ";
				ManagementMain.showData(str, 1);
			}
			else if (searchBoxComponet[searchBoxComponet.Count - 1].GetConditon != "")
			{
				str += searchBoxComponet[searchBoxComponet.Count - 1].GetOption + ">" +
					searchBoxComponet[searchBoxComponet.Count - 1].GetNumLower + " and " +
					searchBoxComponet[searchBoxComponet.Count - 1].GetOption + "<" +
					searchBoxComponet[searchBoxComponet.Count - 1].GetNumUpper + "";
				ManagementMain.showData(str, 1);
			}
			
		}

		private void CreateSearchBoxComponet()
		{
			SearchBoxComponent searchbox = new SearchBoxComponent();
			//Button button_Temp = new Button();

			panel_SearchBox.Controls.Add(searchbox);
			//panel_SearchBox.Controls.Add(button_Temp);

			int Location_Y = 0;
			if (searchBoxComponet.Count == 0)
			{
				Location_Y = 0;
			}
			else
			{
				Location_Y = searchBoxComponet[searchBoxComponet.Count - 1].Location.Y+
					searchBoxComponet[searchBoxComponet.Count - 1].Height;
			}
			searchbox.Location = new Point(0, Location_Y);
			searchBoxComponet.Add(searchbox);
			panel_SearchBox.Size = new Size(309, searchBoxComponet.Count * searchbox.Height);
			this.Height += searchbox.Height;
			panel1.Location = new Point(panel1.Location.X, panel1.Location.Y + searchbox.Height);
		}

		private void AddConditon_BT_Click(object sender, EventArgs e)
		{
			CreateSearchBoxComponet();
		}
	}
}
