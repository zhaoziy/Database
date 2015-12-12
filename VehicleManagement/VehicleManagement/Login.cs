using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace VehicleManagement
{
	public partial class Login : Form
	{
		static public int Version = 0;
		static public bool disableCurrentVersion = false;
		public Login()
		{
			InitializeComponent();
			CheckNewVersion checkversion = new CheckNewVersion(Version);
			checkversion.CheckVerList();

			string str = UserFunction.GetFirstPinyin("逯遥");
			MessageBox.Show(str);
		}

		private void Exit_Bt_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Login_Bt_Click(object sender, EventArgs e)
		{
			string Name = null;
			int Authority = GetAuthority(Num_Textbox.Text, UserFunction.Md5(Pwd_Textbox.Text), out Name);
			if (Authority == 2)
			{
				ManagementMain MainManagement = new ManagementMain(2, Num_Textbox.Text, Name);
				MainManagement.Show();
				this.Hide();
			}
			else if (Authority == 3)
			{
				ManagementMain MainManagement = new ManagementMain(3, Num_Textbox.Text, Name);
				MainManagement.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("请检查用户名和密码是否正确");
			}
        }

		private int GetAuthority(string Num, string pwd, out string Name)
		{
			string str = "select 权限,姓名 from [member] where 工号 ='" + Num + "'and 密码 ='" + pwd + "'";
			SqlDataReader myreader;
			DatabaseCmd datacmd = new DatabaseCmd();
			datacmd.SqlExecuteReader(str,out myreader);
			if (myreader.Read())
			{
				Name = myreader.GetString(1);
				int authority = myreader.GetInt32(0);
				datacmd.SqlReaderClose();
				return authority;
			}
			else
			{
				Name = string.Empty;
				datacmd.SqlReaderClose();
				return 0;
			}
		}

		private void Num_Textbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(!(Char.IsNumber(e.KeyChar)) && e.KeyChar !=(char)8)
			{
				e.Handled = true;
			}
		}
	}
}
