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
		UserFunction userFun = new UserFunction();
		DatabaseCmd databaseCmd = new DatabaseCmd();
		public Login()
		{
			InitializeComponent();
		}

		private void Exit_Bt_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Login_Bt_Click(object sender, EventArgs e)
		{
			if (GetAuthority(Num_Textbox.Text, userFun.Md5(Pwd_Textbox.Text)) == 2)
			{
				ManagementMain MainManagement = new ManagementMain(2);
				MainManagement.Show();
				this.Hide();
			}
			if (GetAuthority(Num_Textbox.Text, userFun.Md5(Pwd_Textbox.Text)) == 3)
			{
				ManagementMain MainManagement = new ManagementMain(3);
				MainManagement.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("请检查用户名和密码是否正确");
			}
        }

		private int GetAuthority(string num, string pwd)
		{
			string str = "select 权限 from [member] where 工号 ='" + num + "'and 密码 ='" + pwd + "'";
			SqlDataReader myreader;
			databaseCmd.SqlExecuteReader(str,out myreader);
			if(myreader.Read())
			{
				return myreader.GetInt32(0);
            }
			else
			{
				return 0;
			}
		}
	}
}
