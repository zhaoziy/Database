using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace VehicleManagement
{
    public partial class ManagementMain : Form
    {
		int authority = 0;
		UserFunction userFun = new UserFunction();
		DatabaseCmd databaseCmd = new DatabaseCmd();

		public ManagementMain(int auth)
		{
			InitializeComponent();
			authority = auth;
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

		private void ShowDatabaseInfo()
		{
			string str = "select * from vehicle";
			DatabaseCmd cmd = new DatabaseCmd();
			SqlDataReader myreader;
			cmd.SqlExecuteReader(str, out myreader);
			while (myreader.Read())
			{
								
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
				
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
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

		private void 检索数据ToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
