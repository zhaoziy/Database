using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Collections;
using System.Drawing;

namespace VehicleManagement
{
	public partial class ManagementMain : Form
	{
		int authority = 0;

		DataSet AllInfoDataSet;
		SqlDataAdapter AllInfoDataAdapter;

		DataSet AllGeoInfoDataSet;
		SqlDataAdapter AllGeoInfoDataAdapter;

		SearchOne SearchOneForm = new SearchOne();
		DataSet SearchDataSet;
		SqlDataAdapter SearchoDataAdapter;

		TextBox[] txtInfo = new TextBox[39];
		TextBox[] txtGeoInfo = new TextBox[7];

		public delegate void ShowDatabase(string str, int mode);
		public static ShowDatabase showData;

		public delegate void RefreshInfo_delegate();
		public static RefreshInfo_delegate refreshinfo;

		public delegate void RefreshGeoInfo_delegate();
		public static RefreshGeoInfo_delegate refreshgeoinfo;

		public ManagementMain(int auth)
		{
			InitializeComponent();
			authority = auth;
			showData = ShowInfo;
			refreshinfo = RefreshInfo;
			refreshgeoinfo = RefreshGeoInfo;

			panel_Info.Enabled = true;
			panel_Info.Visible = true;
			panel_Info.Location = new Point(12, 3);
			panel_Info.Size = new Size(741, 259);

			panel_GeoInfo.Enabled = false;
			panel_GeoInfo.Visible = false;
        }

		#region "窗体事件"

		private void Form1_Load(object sender, EventArgs e)
		{
			init();
		}

		private void init()
		{
			MapTxt();
			if (authority == 2)
			{
				导入数据库ToolStripMenuItem.Enabled = false;
				导入数据库ToolStripMenuItem.Visible = false;
				dataGridView_AllInfo.ReadOnly = true;
				dataGridView_Search.ReadOnly = true;
				dataGridView_AllGeoInfo.ReadOnly = true;
				for (int iLoop = 0; iLoop < 39; ++iLoop)
				{
					txtInfo[iLoop].ReadOnly = true;
				}
				SaveAllInfo_Bt.Enabled = false;
				SaveAllInfo_Bt.Visible = false;
				SaveSearch_Bt.Enabled = false;
				SaveSearch_Bt.Visible = false;
				SaveGeoInfo_Bt.Enabled = false;
				SaveGeoInfo_Bt.Visible = false;
			}
			RefreshInfo();
			RefreshGeoInfo();
        }

		private void RefreshInfo()
		{
			string str = "select * from [VehicleInfo]";
			ShowInfo(str, 0);
		}

		private void RefreshGeoInfo()
		{
			string str = "select ID,汽车ID,车型,厂商,Ext,版本,是否模板,信息更新时间 from [VehicleGeoInfo]";
			ShowGeoInfo(str, 0);
		}

		private void MapTxt()
		{
			txtInfo[0] = textBox1; txtInfo[1] = textBox2; txtInfo[2] = textBox3; txtInfo[3] = textBox4; txtInfo[4] = textBox5;
			txtInfo[5] = textBox6; txtInfo[6] = textBox7; txtInfo[7] = textBox8; txtInfo[8] = textBox9; txtInfo[9] = textBox10;
			txtInfo[10] = textBox11; txtInfo[11] = textBox12; txtInfo[12] = textBox13; txtInfo[13] = textBox14; txtInfo[14] = textBox15;
			txtInfo[15] = textBox16; txtInfo[16] = textBox17; txtInfo[17] = textBox18; txtInfo[18] = textBox19; txtInfo[19] = textBox20;
			txtInfo[20] = textBox21; txtInfo[21] = textBox22; txtInfo[22] = textBox23; txtInfo[23] = textBox24; txtInfo[24] = textBox25;
			txtInfo[25] = textBox26; txtInfo[26] = textBox27; txtInfo[27] = textBox28; txtInfo[28] = textBox29; txtInfo[29] = textBox30;
			txtInfo[30] = textBox31; txtInfo[31] = textBox32; txtInfo[32] = textBox33; txtInfo[33] = textBox34; txtInfo[34] = textBox35;
			txtInfo[35] = textBox36; txtInfo[36] = textBox37; txtInfo[37] = textBox38; txtInfo[38] = textBox39;

			txtGeoInfo[0] = textBox40; txtGeoInfo[1] = textBox41; txtGeoInfo[2] = textBox42; txtGeoInfo[3] = textBox43;
			txtGeoInfo[4] = textBox44; txtGeoInfo[5] = textBox45; txtGeoInfo[6] = textBox46;
		}

		private void ShowInfo(string str, int mode)
		{
			DatabaseCmd datacmd = new DatabaseCmd();
			if (mode == 0)
			{
				datacmd.SqlDataTable("AllInfo", str, out AllInfoDataSet, out AllInfoDataAdapter);

				try
				{
					bindingSource_AllInfo.DataSource = AllInfoDataSet.Tables[0];
					dataGridView_AllInfo.DataSource = bindingSource_AllInfo;
					bindingNavigator1.BindingSource = bindingSource_AllInfo;

					ClearInfoBinding();

					string[] array1 = Enum.GetNames(typeof(ColName_Vehicle));

					int iLoop = 0;
					for (iLoop = 0; iLoop < 32; ++iLoop)
					{
						txtInfo[iLoop].DataBindings.Add("Text", bindingSource_AllInfo, (string)array1.GetValue(iLoop));
					}
					txtInfo[38].DataBindings.Add("Text", bindingSource_AllInfo, (string)array1.GetValue(32));
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				datacmd.SqlDataTable("SearchAllInfo", str, out SearchDataSet, out SearchoDataAdapter);
				try
				{
					bindingSource_Search.DataSource = SearchDataSet.Tables[0];
					dataGridView_Search.DataSource = bindingSource_Search;
					bindingNavigator2.BindingSource = bindingSource_Search;

					ClearInfoBinding();

					string[] array1 = Enum.GetNames(typeof(ColName_Vehicle));

					int iLoop = 0;
					for (iLoop = 0; iLoop < array1.Length - 1; ++iLoop)
					{
						txtInfo[iLoop].DataBindings.Add("Text", bindingSource_Search, (string)array1.GetValue(iLoop));
					}
					tabControl1.SelectedIndex = 2;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void ShowGeoInfo(string str, int mode)
		{
			DatabaseCmd datacmd = new DatabaseCmd();

			datacmd.SqlDataTable("GeoInfo", str, out AllGeoInfoDataSet, out AllGeoInfoDataAdapter);

			try
			{
				bindingSource_GeoInfo.DataSource = AllGeoInfoDataSet.Tables[0];
				dataGridView_AllGeoInfo.DataSource = bindingSource_GeoInfo;
				bindingNavigator3.BindingSource = bindingSource_GeoInfo;

				ClearGeoInfoBinding();

				txtGeoInfo[0].DataBindings.Add("Text", bindingSource_GeoInfo, "汽车ID");
				txtGeoInfo[1].DataBindings.Add("Text", bindingSource_GeoInfo, "车型");
				txtGeoInfo[2].DataBindings.Add("Text", bindingSource_GeoInfo, "厂商");
				txtGeoInfo[3].DataBindings.Add("Text", bindingSource_GeoInfo, "Ext");
				txtGeoInfo[4].DataBindings.Add("Text", bindingSource_GeoInfo, "版本");
				txtGeoInfo[5].DataBindings.Add("Text", bindingSource_GeoInfo, "是否模板");
				txtGeoInfo[6].DataBindings.Add("Text", bindingSource_GeoInfo, "信息更新时间");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ClearInfoBinding()
		{
			int iLoop = 0;
			for (iLoop = 0; iLoop < txtInfo.Length; ++iLoop)
			{
				txtInfo[iLoop].DataBindings.Clear();
			}
		}

		private void ClearGeoInfoBinding()
		{
			int iLoop = 0;
			for (iLoop = 0; iLoop < txtGeoInfo.Length; ++iLoop)
			{
				txtGeoInfo[iLoop].DataBindings.Clear();
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			UpdateDatabase("AllInfo", 0);
			UpdateDatabase("SearchAllInfo", 1);
			UpdateDatabase("GeoInfo", 2);
			Application.Exit();
		}

		private void UpdateDatabase(string str, int mode)
		{
			if (mode == 0)
			{
				if (AllInfoDataSet != null)
				{
					AllInfoDataAdapter.Update(AllInfoDataSet, str);
				}
			}
			else if(mode == 1)
			{
				if (SearchDataSet != null)
				{
					SearchoDataAdapter.Update(SearchDataSet, str);
				}
			}
			else if (mode == 2)
			{
				if (AllGeoInfoDataSet != null)
				{
					AllGeoInfoDataAdapter.Update(AllGeoInfoDataSet, str);
				}
			}
		}

		#endregion

		#region"菜单事件"

		private void 导入数据库ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UploadToDatabase upload = new UploadToDatabase();
			upload.ShowDialog();
			upload.Dispose();
		}

		private void 检索数据ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SearchOneForm.Show();
		}

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		#endregion

		#region "按钮事件"

		private void Save_Bt_Click(object sender, EventArgs e)
		{
			((BindingSource)dataGridView_AllInfo.DataSource).EndEdit();
			if (AllInfoDataSet.GetChanges() == null)
			{
				return;
			}
			else
			{
				UpdateDatabase("AllInfo", 0);
			}
		}

		private void SaveSearch_Bt_Click(object sender, EventArgs e)
		{
			((BindingSource)dataGridView_Search.DataSource).EndEdit();
			if (SearchDataSet.GetChanges() == null)
			{
				return;
			}
			else
			{
				UpdateDatabase("SearchAllInfo", 1);
			}

		}

		private void SaveGeoInfo_Bt_Click(object sender, EventArgs e)
		{
			((BindingSource)dataGridView_AllGeoInfo.DataSource).EndEdit();
			if (AllGeoInfoDataSet.GetChanges() == null)
			{
				return;
			}
			else
			{
				UpdateDatabase("GeoInfo", 2);
			}
		}

		#endregion

		private void dataGridView_AllInfo_SelectionChanged(object sender, EventArgs e)
		{
			DatabaseCmd databasecmd = new DatabaseCmd();
			SqlDataReader myreader;

			string str = "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_AllInfo.Rows[dataGridView_AllInfo.CurrentRow.Index].Cells[1].Value + "' and Ext = 'JPG'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_AllInfo.Rows[dataGridView_AllInfo.CurrentRow.Index].Cells[1].Value + "' and Ext = 'BWF'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_AllInfo.Rows[dataGridView_AllInfo.CurrentRow.Index].Cells[1].Value + "' and Ext = 'TMPLT'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_AllInfo.Rows[dataGridView_AllInfo.CurrentRow.Index].Cells[1].Value + "' and Ext = 'LQB'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_AllInfo.Rows[dataGridView_AllInfo.CurrentRow.Index].Cells[1].Value + "' and Ext = 'PRT'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_AllInfo.Rows[dataGridView_AllInfo.CurrentRow.Index].Cells[1].Value + "' and Ext = 'STL'";

			databasecmd.SqlExecuteReader(str, out myreader);
			int iLoop = 0;
			while (myreader.Read())
			{
				txtInfo[iLoop + 32].Text = (myreader.GetInt32(0) != 0) ? ("True") : ("False");
				iLoop++;
			}
			databasecmd.SqlReaderClose();
			myreader = null;
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateDatabase("AllInfo", 0);
			UpdateDatabase("SearchAllInfo", 1);
			UpdateDatabase("GeoInfo", 2);

			if (tabControl1.SelectedIndex == 0)
			{
				panel_Info.Enabled = true;
				panel_Info.Visible = true;
				panel_Info.Location = new Point(12, 3);
				panel_Info.Size = new Size(741, 259);

				panel_GeoInfo.Enabled = false;
				panel_GeoInfo.Visible = false;
            }
			else if (tabControl1.SelectedIndex == 1)
			{
				panel_GeoInfo.Enabled = true;
				panel_GeoInfo.Visible = true;
				panel_GeoInfo.Location = new Point(12, 3);
				panel_GeoInfo.Size = new Size(741, 259);

				panel_Info.Enabled = false;
				panel_Info.Visible = false;
			}
			else if (tabControl1.SelectedIndex == 2)
			{
				panel_Info.Enabled = true;
				panel_Info.Visible = true;
				panel_Info.Location = new Point(12, 3);
				panel_Info.Size = new Size(741, 259);

				panel_GeoInfo.Enabled = false;
				panel_GeoInfo.Visible = false;
			}
		}

		private void dataGridView_Search_SelectionChanged(object sender, EventArgs e)
		{
			DatabaseCmd databasecmd = new DatabaseCmd();
			SqlDataReader myreader;

			string str = "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_Search.Rows[dataGridView_Search.CurrentRow.Index].Cells[1].Value + "' and Ext = 'JPG'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_Search.Rows[dataGridView_Search.CurrentRow.Index].Cells[1].Value + "' and Ext = 'BWF'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_Search.Rows[dataGridView_Search.CurrentRow.Index].Cells[1].Value + "' and Ext = 'TMPLT'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_Search.Rows[dataGridView_Search.CurrentRow.Index].Cells[1].Value + "' and Ext = 'LQB'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_Search.Rows[dataGridView_Search.CurrentRow.Index].Cells[1].Value + "' and Ext = 'PRT'"
				+ " union all "
				+ "select count(*) from [VehicleGeoInfo] where 汽车ID = '"
				+ dataGridView_Search.Rows[dataGridView_Search.CurrentRow.Index].Cells[1].Value + "' and Ext = 'STL'";

			databasecmd.SqlExecuteReader(str, out myreader);
			int iLoop = 0;
			while (myreader.Read())
			{
				txtInfo[iLoop + 32].Text = (myreader.GetInt32(0) != 0) ? ("True") : ("False");
				iLoop++;
			}
			databasecmd.SqlReaderClose();
			myreader = null;
		}
	}

	#region"枚举变量"

	enum ColName_Vehicle
		{
			汽车ID = 0, 车型 = 1, 厂商 = 2, 级别 = 3, 车身结构 = 4, 长 = 5, 宽 = 6, 高 = 7, 最高车速 = 8, 百公里加速 = 9,
			综合油耗 = 10, 最小离地间隙 = 11, 轴距 = 12, 前轮距 = 13, 后轮距 = 14, 整备质量 = 15, 车门数 = 16,
			座位数 = 17, 行李厢容积 = 18, 排量 = 19, 前轮胎规格 = 20, 后轮胎规格 = 21, 电动天窗 = 22, 全景天窗 = 23,
			运动外观套件 = 24, 铝合金轮圈 = 25, 电动吸合门 = 26, 侧滑门 = 27, 电动后备厢 = 28, 感应后备厢 = 29,
			车顶行李架 = 30, 外观颜色 = 31, 信息更新时间 = 32
		}

	enum ColName_VehicleGeo
		{
			汽车ID = 0, 车型 = 1, 厂商 = 2, Data = 3, Ext = 4, 版本 = 5, 是否模板 = 6, 信息更新时间 = 7
		}

	#endregion
}
