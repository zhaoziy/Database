using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;

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

		TextBox lenghtTB = new TextBox();
		TextBox widthTB = new TextBox();
		TextBox heightTB = new TextBox();

		public delegate void ShowDatabase(string str, int mode);
		public static ShowDatabase showData;

		public ManagementMain(int auth)
		{
			InitializeComponent();
			authority = auth;
			showData = ShowDatabaseInfo;
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			init();
        }

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void init()
		{
			string str = "select * from [VehicleInfo]";
			ShowDatabaseInfo(str, 0);
        }

		private void ShowDatabaseInfo(string str,int mode)
		{
			if(mode == 0)
			{
				DatabaseCmd.SqlDataTable("table1", str, out AllInfoDataSet, out AllInfoDataAdapter);
				try
				{
					bindingSource_AllInfo.DataSource = AllInfoDataSet.Tables[0];
					dataGridView_AllInfo.DataSource = bindingSource_AllInfo;
					bindingNavigator1.BindingSource = bindingSource_AllInfo;

					ClearBinding();

					textBox1.DataBindings.Add("Text", bindingSource_AllInfo, "车型");
					textBox2.DataBindings.Add("Text", bindingSource_AllInfo, "厂商");
					textBox3.DataBindings.Add("Text", bindingSource_AllInfo, "级别");
					textBox4.DataBindings.Add("Text", bindingSource_AllInfo, "车身结构");

					lenghtTB.DataBindings.Add("Text", bindingSource_AllInfo, "长");
					widthTB.DataBindings.Add("Text", bindingSource_AllInfo, "宽");
					heightTB.DataBindings.Add("Text", bindingSource_AllInfo, "高");

					textBox5.Text = lenghtTB.Text + "*" + widthTB.Text + "*" + heightTB.Text;
					textBox6.DataBindings.Add("Text", bindingSource_AllInfo, "最高车速");
					textBox7.DataBindings.Add("Text", bindingSource_AllInfo, "百公里加速");
					textBox8.DataBindings.Add("Text", bindingSource_AllInfo, "综合油耗");
					textBox9.DataBindings.Add("Text", bindingSource_AllInfo, "最小离地间隙");
					textBox10.DataBindings.Add("Text", bindingSource_AllInfo, "轴距");
					textBox11.DataBindings.Add("Text", bindingSource_AllInfo, "前轮距");
					textBox12.DataBindings.Add("Text", bindingSource_AllInfo, "后轮距");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				DatabaseCmd.SqlDataTable("table2", str, out SearchDataSet, out SearchoDataAdapter);
				try
				{
					bindingSource_Search.DataSource = SearchDataSet.Tables[0];
					dataGridView_Search.DataSource = bindingSource_Search;
					bindingNavigator2.BindingSource = bindingSource_Search;

					ClearBinding();

					textBox1.DataBindings.Add("Text", bindingSource_Search, "车型");
					textBox2.DataBindings.Add("Text", bindingSource_Search, "厂商");
					textBox3.DataBindings.Add("Text", bindingSource_Search, "级别");
					textBox4.DataBindings.Add("Text", bindingSource_Search, "车身结构");

					lenghtTB.DataBindings.Add("Text", bindingSource_Search, "长");
					widthTB.DataBindings.Add("Text", bindingSource_Search, "宽");
					heightTB.DataBindings.Add("Text", bindingSource_Search, "高");

					textBox5.Text = lenghtTB.Text + "*" + widthTB.Text + "*" + heightTB.Text;
					textBox6.DataBindings.Add("Text", bindingSource_Search, "最高车速");
					textBox7.DataBindings.Add("Text", bindingSource_Search, "百公里加速");
					textBox8.DataBindings.Add("Text", bindingSource_Search, "综合油耗");
					textBox9.DataBindings.Add("Text", bindingSource_Search, "最小离地间隙");
					textBox10.DataBindings.Add("Text", bindingSource_Search, "轴距");
					textBox11.DataBindings.Add("Text", bindingSource_Search, "前轮距");
					textBox12.DataBindings.Add("Text", bindingSource_Search, "后轮距");

					tabControl1.SelectedIndex = 1;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void ClearBinding()
		{
			textBox1.DataBindings.Clear();
			textBox2.DataBindings.Clear();
			textBox3.DataBindings.Clear();
			textBox4.DataBindings.Clear();
			textBox5.DataBindings.Clear();
			textBox6.DataBindings.Clear();
			textBox7.DataBindings.Clear();
			textBox8.DataBindings.Clear();
			textBox9.DataBindings.Clear();
			textBox10.DataBindings.Clear();
			textBox11.DataBindings.Clear();
			textBox12.DataBindings.Clear();
			lenghtTB.DataBindings.Clear();
			widthTB.DataBindings.Clear();
			heightTB.DataBindings.Clear();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			UpdateDatabase("table1");
			Application.Exit();
		}

		private void 导入数据库ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "导入数据库";
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				
			}
		}

		private void Save_Bt_Click(object sender, EventArgs e)
		{
			((BindingSource)dataGridView_AllInfo.DataSource).EndEdit();
			if(AllInfoDataSet.GetChanges() == null)
			{
				return;
			}
			else
			{
				UpdateDatabase("table1");
            }
        }

		private void UpdateDatabase(string str)
		{
			AllInfoDataAdapter.Update(AllInfoDataSet, str);
		}

		private void 检索数据ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SearchOneForm.Show();
        }
	}
}
