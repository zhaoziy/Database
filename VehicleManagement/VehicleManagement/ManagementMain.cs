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

		DataSet InfoDataSet = new DataSet();
		SqlDataAdapter InfoDataAdapter = new SqlDataAdapter();

		DataSet GeoInfoDataSet = new DataSet();
		SqlDataAdapter GeoInfoDataAdapter = new SqlDataAdapter();

		SearchOne SearchOneForm = new SearchOne();

		TextBox[] txtInfo = new TextBox[43];
		TextBox[] txtGeoInfo = new TextBox[9];

		public delegate void ShowDatabase(string str, int mode);
		public static ShowDatabase showData;

		public delegate void RefreshInfo_delegate();
		public static RefreshInfo_delegate refreshinfo;

		public delegate void RefreshGeoInfo_delegate(string GeoType);
		public static RefreshGeoInfo_delegate refreshgeoinfo;

		public ManagementMain(int auth)
		{
			InitializeComponent();
			authority = auth;
			showData = ShowInfo;
			refreshinfo = RefreshInfo;
			refreshgeoinfo = RefreshGeoInfo;
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

				dataGridView_Info.ReadOnly = true;
				dataGridView_GeoInfo.ReadOnly = true;

				for (int iLoop = 0; iLoop < txtInfo.Length; ++iLoop)
				{
					txtInfo[iLoop].ReadOnly = true;
				}
				for (int iLoop = 0; iLoop < txtGeoInfo.Length; ++iLoop)
				{
					txtGeoInfo[iLoop].ReadOnly = true;
				}

				SaveAllInfo_Bt.Enabled = false;
				SaveAllInfo_Bt.Visible = false;
				SaveGeoInfo_Bt.Enabled = false;
				SaveGeoInfo_Bt.Visible = false;
			}
			RefreshInfo();
			RefreshGeoInfo("BWF");
        }

		private void RefreshInfo()
		{
			string str = "select * from [VehicleInfo]";
			ShowInfo(str, 0);
		}

		private void RefreshGeoInfo(string GeoType)
		{
			string str = "select ID,汽车ID,车型,厂商,版本,是否模板,信息更新时间,信息更新者工号,信息更新者姓名 from [GeoInfo_" + GeoType + "]";
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
			txtInfo[35] = textBox36; txtInfo[36] = textBox37; txtInfo[37] = textBox38; txtInfo[38] = textBox39; txtInfo[39] = textBox40;
			txtInfo[40] = textBox41; txtInfo[41] = textBox42; txtInfo[42] = textBox43;

			txtGeoInfo[0] = textBox44; txtGeoInfo[1] = textBox45; txtGeoInfo[2] = textBox46; txtGeoInfo[3] = textBox47;
			txtGeoInfo[4] = textBox48; txtGeoInfo[5] = textBox49; txtGeoInfo[6] = textBox50; txtGeoInfo[7] = textBox51;
			txtGeoInfo[8] = textBox52;
		}

		private void ShowInfo(string str, int mode)
		{
			DatabaseCmd datacmd = new DatabaseCmd();
			
			InfoDataAdapter = null;

			if (mode == 0)
			{
				if (InfoDataSet.Tables["Info"] != null)
				{
					InfoDataSet.Tables["Info"].Clear();
				}
				datacmd.SqlDataTable("Info", str, out InfoDataSet, out InfoDataAdapter);
				try
				{
					bindingSource_Info.DataSource = InfoDataSet.Tables["Info"];
					dataGridView_Info.DataSource = bindingSource_Info;
					bindingNavigator_Info.BindingSource = bindingSource_Info;

					ClearInfoBinding();

					string[] array1 = Enum.GetNames(typeof(ColName_Vehicle));

					int iLoop = 0;
					for (iLoop = 0; iLoop < array1.Length; ++iLoop)
					{
						txtInfo[iLoop].DataBindings.Add("Text", bindingSource_Info, (string)array1.GetValue(iLoop));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				if (InfoDataSet.Tables["SearchInfo"] != null)
				{
					InfoDataSet.Tables["SearchInfo"].Clear();
				}
				datacmd.SqlDataTable("SearchInfo", str, out InfoDataSet, out InfoDataAdapter);
				try
				{
					bindingSource_Info.DataSource = InfoDataSet.Tables["SearchInfo"];
					dataGridView_Info.DataSource = bindingSource_Info;
					bindingNavigator_Info.BindingSource = bindingSource_Info;

					ClearInfoBinding();

					string[] array1 = Enum.GetNames(typeof(ColName_Vehicle));

					int iLoop = 0;
					for (iLoop = 0; iLoop < array1.Length; ++iLoop)
					{
						txtInfo[iLoop].DataBindings.Add("Text", bindingSource_Info, (string)array1.GetValue(iLoop));
					}
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

			if (GeoInfoDataSet.Tables["GeoInfo"] != null)
			{
				GeoInfoDataSet.Tables["GeoInfo"].Clear();
			}
			datacmd.SqlDataTable("GeoInfo", str, out GeoInfoDataSet, out GeoInfoDataAdapter);

			try
			{
				bindingSource_GeoInfo.DataSource = GeoInfoDataSet.Tables[0];
				dataGridView_GeoInfo.DataSource = bindingSource_GeoInfo;
				bindingNavigator_GeoInfo.BindingSource = bindingSource_GeoInfo;

				ClearGeoInfoBinding();

				txtGeoInfo[0].DataBindings.Add("Text", bindingSource_GeoInfo, "汽车ID");
				txtGeoInfo[1].DataBindings.Add("Text", bindingSource_GeoInfo, "车型");
				txtGeoInfo[2].DataBindings.Add("Text", bindingSource_GeoInfo, "厂商");
				txtGeoInfo[3].DataBindings.Add("Text", bindingSource_GeoInfo, "版本");
				txtGeoInfo[4].DataBindings.Add("Text", bindingSource_GeoInfo, "是否模板");
				txtGeoInfo[5].DataBindings.Add("Text", bindingSource_GeoInfo, "信息更新时间");
				txtGeoInfo[6].DataBindings.Add("Text", bindingSource_GeoInfo, "信息更新者工号");
				txtGeoInfo[7].DataBindings.Add("Text", bindingSource_GeoInfo, "信息更新者姓名");
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
			UpdateDatabase("Info", 0);
			UpdateDatabase("SearchInfo", 0);
			UpdateDatabase("GeoInfo", 1);
			Application.Exit();
		}

		private void UpdateDatabase(string str, int mode)
		{
			if (mode == 0)
			{
				if (InfoDataSet != null && InfoDataSet.Tables[str] != null)
				{
						InfoDataAdapter.Update(InfoDataSet, str);
				}
			}
			else if(mode == 1)
			{
				if (GeoInfoDataSet != null && GeoInfoDataSet.Tables[str] != null)
				{
					GeoInfoDataAdapter.Update(GeoInfoDataSet, str);
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
			((BindingSource)dataGridView_Info.DataSource).EndEdit();
			if (InfoDataSet.GetChanges() == null)
			{
				return;
			}
			else
			{
				UpdateDatabase("SearchInfo", 0);
				UpdateDatabase("Info", 0);
			}
		}

		private void SaveGeoInfo_Bt_Click(object sender, EventArgs e)
		{
			((BindingSource)dataGridView_GeoInfo.DataSource).EndEdit();
			if (GeoInfoDataSet.GetChanges() == null)
			{
				return;
			}
			else
			{
				UpdateDatabase("GeoInfo", 1);
			}
		}

		#endregion

		private void dataGridView_Info_SelectionChanged(object sender, EventArgs e)
		{
			DatabaseCmd databasecmd = new DatabaseCmd();
			SqlDataReader myreader;

			string str = "select count(*) from [GeoInfo_BWF] where 汽车ID = '"
				+ dataGridView_Info.Rows[dataGridView_Info.CurrentRow.Index].Cells[1].Value + "'"
				+ " union all "
				+ "select count(*) from [GeoInfo_LQB] where 汽车ID = '"
				+ dataGridView_Info.Rows[dataGridView_Info.CurrentRow.Index].Cells[1].Value + "'"
				+ " union all "
				+ "select count(*) from [GeoInfo_TMPLT] where 汽车ID = '"
				+ dataGridView_Info.Rows[dataGridView_Info.CurrentRow.Index].Cells[1].Value + "'"
				+ " union all "
				+ "select count(*) from [GeoInfo_PRT] where 汽车ID = '"
				+ dataGridView_Info.Rows[dataGridView_Info.CurrentRow.Index].Cells[1].Value + "'"
				+ " union all "
				+ "select count(*) from [GeoInfo_STL] where 汽车ID = '"
				+ dataGridView_Info.Rows[dataGridView_Info.CurrentRow.Index].Cells[1].Value + "'"
				+ " union all "
				+ "select count(*) from [GeoInfo_JPG] where 汽车ID = '"
				+ dataGridView_Info.Rows[dataGridView_Info.CurrentRow.Index].Cells[1].Value + "'";

			databasecmd.SqlExecuteReader(str, out myreader);
			int iLoop = 0;
			while (myreader.Read())
			{
				txtInfo[iLoop + 37].Text = (myreader.GetInt32(0) != 0) ? ("True") : ("False");
				iLoop++;
			}
			databasecmd.SqlReaderClose();
			myreader = null;
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateDatabase("Info", 0);
			UpdateDatabase("SearchInfo", 1);
			UpdateDatabase("GeoInfo", 2);
		}

		private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateDatabase("GeoInfo", 2);
			tabControl2.TabPages[tabControl2.SelectedIndex].Controls.Add(splitContainer2);
			string str = string.Empty;
			if (tabControl2.TabPages[tabControl2.SelectedIndex].Text != "JPG")
			{
				str = "select ID,汽车ID,车型,厂商,版本,是否模板,信息更新时间,信息更新者工号,信息更新者姓名 from [GeoInfo_" + tabControl2.TabPages[tabControl2.SelectedIndex].Text + "]";
				ShowGeoInfo(str, 0);
			}
			else
			{
				str = "select ID,汽车ID,车型,厂商,视图,版本,是否模板,信息更新时间,信息更新者工号,信息更新者姓名 from [GeoInfo_" + tabControl2.TabPages[tabControl2.SelectedIndex].Text + "]";
				ShowGeoInfo(str, 1);
			}
		}
	}

	#region"枚举变量"

	enum ColName_Vehicle
		{
			汽车ID = 0, 车型 = 1, 型号 = 2, 年款 = 3, 厂商 = 4, 级别 = 5, 车身结构 = 6, 长 = 7, 宽 = 8, 高 = 9,
			最高车速 = 10, 百公里加速 = 11, 综合油耗 = 12, 最小离地间隙 = 13, 轴距 = 14, 前轮距 = 15, 后轮距 = 16,
			整备质量 = 17, 车门数 = 18,  座位数 = 19, 行李厢容积 = 20, 排量 = 21, 前轮胎规格 = 22, 后轮胎规格 = 23,
			电动天窗 = 24, 全景天窗 = 25, 运动外观套件 = 26, 铝合金轮圈 = 27, 电动吸合门 = 28, 侧滑门 = 29,
			电动后备厢 = 30, 感应后备厢 = 31, 车顶行李架 = 32, 外观颜色 = 33, 信息更新时间 = 34, 信息更新者工号= 35,
			信息更新者姓名 = 36
	}

	enum ColName_VehicleGeo
		{
			汽车ID = 0, 车型 = 1, 厂商 = 2, Data = 3, 版本 = 4, 是否模板 = 5,
			信息更新时间 = 6, 信息更新者工号 = 7, 信息更新者姓名 = 8
	}

	#endregion
}
