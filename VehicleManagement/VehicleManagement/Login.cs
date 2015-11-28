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
			if (GetAuthority(Num_Textbox.Text, UserFunction.Md5(Pwd_Textbox.Text)) == 2)
			{
				ManagementMain MainManagement = new ManagementMain(2);
				MainManagement.Show();
				this.Hide();
			}
			if (GetAuthority(Num_Textbox.Text, UserFunction.Md5(Pwd_Textbox.Text)) == 3)
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
			DatabaseCmd datacmd = new DatabaseCmd();
			datacmd.SqlExecuteReader(str,out myreader);
			if(myreader.Read())
			{
				return myreader.GetInt32(0);
            }
			else
			{
				return 0;
			}
			datacmd.SqlReaderClose();
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
