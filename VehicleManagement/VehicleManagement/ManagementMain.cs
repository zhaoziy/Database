using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Collections;

namespace VehicleManagement
{
    public partial class ManagementMain : Form
    {
		int authority = 0;
		DataSet AllInfoDataSet;
		SqlDataAdapter AllInfoDataAdapter;

		SearchOne SearchOneForm = new SearchOne();
		DataSet SearchDataSet;
		SqlDataAdapter SearchoDataAdapter;

		TextBox[] txtInfo = new TextBox[39];

		public delegate void ShowDatabase(string str, int mode);
		public static ShowDatabase showData;

		public ManagementMain(int auth)
		{
			InitializeComponent();
			authority = auth;
			showData = ShowDatabaseInfo;
        }

		#region "窗体事件"

		private void Form1_Load(object sender, EventArgs e)
		{
			init();
		}

		private void init()
		{
			MapTxt();
			string str = "select * from [VehicleInfo]";
			ShowDatabaseInfo(str, 0);
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
		}

		private void ShowDatabaseInfo(string str, int mode)
		{
			DatabaseCmd datacmd = new DatabaseCmd();
			if (mode == 0)
			{
				datacmd.SqlDataTable("table1", str, out AllInfoDataSet, out AllInfoDataAdapter);

				try
				{
					bindingSource_AllInfo.DataSource = AllInfoDataSet.Tables[0];
					dataGridView_AllInfo.DataSource = bindingSource_AllInfo;
					bindingNavigator1.BindingSource = bindingSource_AllInfo;

					ClearBinding();

					string[] array1 = Enum.GetNames(typeof(ColName_Vehicle));

					int iLoop = 0;
					for (iLoop = 0; iLoop < 33; ++iLoop)
					{
						txtInfo[iLoop].DataBindings.Add("Text", bindingSource_AllInfo, (string)array1.GetValue(iLoop));
					}

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				datacmd.SqlDataTable("table2", str, out SearchDataSet, out SearchoDataAdapter);
				try
				{
					bindingSource_Search.DataSource = SearchDataSet.Tables[0];
					dataGridView_Search.DataSource = bindingSource_Search;
					bindingNavigator2.BindingSource = bindingSource_Search;

					ClearBinding();

					string[] array1 = Enum.GetNames(typeof(ColName_Vehicle));

					int iLoop = 0;
					for (iLoop = 0; iLoop < 39; ++iLoop)
					{
						txtInfo[iLoop].DataBindings.Add("Text", bindingSource_Search, (string)array1.GetValue(iLoop));
					}
					tabControl1.SelectedIndex = 1;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void InsertRowOfDataSet(DataSet ds, string ColName, ArrayList List)
		{
			ds.Tables[0].Columns.Add(ColName, typeof(string));
			DataRow dr = ds.Tables[0].NewRow();
			dr[0] = List;
			ds.Tables[0].Rows.Add(dr);
		}

		private void ClearBinding()
		{
			int iLoop = 0;
			for (iLoop = 0; iLoop < 39; ++iLoop)
			{
				txtInfo[iLoop].DataBindings.Clear();
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			UpdateDatabase("table1", 0);
			UpdateDatabase("table2", 1);
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
			else
			{
				if (SearchDataSet != null)
				{
					SearchoDataAdapter.Update(SearchDataSet, str);
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
				UpdateDatabase("table1", 0);
			}
		}

		private void SaveSearch_Bt_Click(object sender, EventArgs e)
		{
			((BindingSource)bindingSource_Search.DataSource).EndEdit();
			if (SearchDataSet.GetChanges() == null)
			{
				return;
			}
			else
			{
				UpdateDatabase("table2", 1);
			}

		}

		#endregion

		#region"鼠标焦点事件"

		private void dataGridView_AllInfo_MouseEnter(object sender, EventArgs e)
		{
			dataGridView_AllInfo.Focus();
		}

		private void dataGridView_Search_MouseEnter(object sender, EventArgs e)
		{
			dataGridView_Search.Focus();
		}

		private void splitContainer1_Panel2_MouseEnter(object sender, EventArgs e)
		{
			splitContainer1.Panel2.Focus();
		}

		#endregion
	}

	#region"枚举变量"

	enum ColName_Vehicle
	{
		ID = 0, 车型 = 1, 厂商 = 2, 级别 = 3, 车身结构 = 4, 长 = 5, 宽 = 6, 高 = 7, 最高车速 = 8, 百公里加速 = 9,
		综合油耗 = 10, 最小离地间隙 = 11, 轴距 = 12, 前轮距 = 13, 后轮距 = 14, 整备质量 = 15, 车门数 = 16,
		座位数 = 17, 行李箱容积 = 18, 排量 = 19, 前轮胎规格 = 20, 后轮胎规格 = 21, 电动天窗 = 22, 全景天窗 = 23,
		运动外观套件 = 24, 铝合金轮圈 = 25, 电动吸合门 = 26, 侧滑门 = 27, 电动后备箱 = 28, 感应后备箱 = 29,
		车顶行李架 = 30, 外观颜色 = 31, 信息更新时间 = 32
	}

	enum ColName_VehicleGeo
	{
		ID = 0, 车型 = 1, JPG = 2, BWF = 3, TMPLT = 4, LQB = 5, PRT = 6, STL = 7, 是否模板 = 8, 版本 = 9, 信息更新时间 = 10
	}

	#endregion

}
