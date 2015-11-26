using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_Test_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			
        }

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = false;
			openFileDialog1.Title = "打开文件";
			openFileDialog1.ShowDialog();
			
		}

		private void 导入数据库ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "导入数据库";
			openFileDialog1.ShowDialog();
			
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 1)  //数据库
			{

			}

		}
	}
}
