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
				MessageBox.Show("2");
				Form1 MainManagement = new Form1(2);
				MainManagement.Show();
			}
			if (GetAuthority(Num_Textbox.Text, userFun.Md5(Pwd_Textbox.Text)) == 3)
			{
				Form1 MainManagement = new Form1(3);
				MainManagement.Show();
				this.Close();
			}
			else if(GetAuthority(Num_Textbox.Text, userFun.Md5(Pwd_Textbox.Text)) == 0)
			{
				MessageBox.Show("0");
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
