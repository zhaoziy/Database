using System;
using System.Windows.Forms;

namespace VehicleManagement
{
	public partial class SearchOne : Form
	{
		public SearchOne()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void Search_Bt_Click(object sender, EventArgs e)
		{
            string str = "SELECT * FROM [vehicleinfo] WHERE 车型 LIKE '%" + textBox1.Text +"%'";
			ManagementMain.showData(str, 1);
		}
	}
}
