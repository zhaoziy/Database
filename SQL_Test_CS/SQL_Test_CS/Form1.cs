using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SQL_Test_CS
{
    public partial class Form1 : Form
    {
		string content;
        public Form1()
        {
            InitializeComponent();
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				init();
			}
			catch
			{
			}
			
        }

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = false;
			openFileDialog1.Title = "打开文件";
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				textData.Clear();
				content = File.ReadAllText(openFileDialog1.FileName);
				textData.Text = content;
            }
		}

		private void 导入数据库ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "导入数据库";
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				textData.Clear();
				content = File.ReadAllText(openFileDialog1.FileName);
				textData.Text = content;
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 1)  //数据库
			{
				listView1.Items.Clear();
				ShowDatabaseInfo();
            }
		}

		private void ShowDatabaseInfo()
		{
			string str = "select * from vehicle";
			DatabaseCmd cmd = new DatabaseCmd();
			SqlDataReader myreader;
			cmd.SqlExecuteReader(str, out myreader);
            while (myreader.Read())
			{
				ListViewItem li = new ListViewItem();
				li.SubItems.Clear();
				li.SubItems[0].Text = myreader[0].ToString();
				for (int iLoop = 1; iLoop < listView1.Columns.Count; ++iLoop)
				{
					li.SubItems.Add(myreader[iLoop].ToString());
				}
				listView1.Items.Add(li);
			}
		}

		private void init()
		{
			string str = "select COLUMN_NAME from information_schema.columns order by ORDINAL_POSITION";
			DatabaseCmd cmd = new DatabaseCmd();
			SqlDataReader myreader;
			cmd.SqlExecuteReader(str, out myreader);
			while (myreader.Read())
			{
				listView1.Columns.Add(myreader.GetString(0));
			}
		}
	}
}
