using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VehicleManagement
{
	class CheckNewVersion
	{
		public void CheckVerList()
		{
			bool QuickUpdate = false;
			string selectcmd = "select 屏蔽使用,快速升级 from [VerList] where 程序名 = '汽车模型信息管理' and 版本号 = " + Login.Version;
			DatabaseCmd checkUpdate = new DatabaseCmd();
			SqlDataReader myreader;
			checkUpdate.SqlExecuteReader(selectcmd, out myreader);
			if(myreader.Read())
			{
				QuickUpdate = myreader.GetBoolean(1);
				Login.disableCurrentVersion = (myreader.GetBoolean(1) == true) ? (true) : (false);
			}
			checkUpdate.SqlReaderClose();
			update_info();
			if(QuickUpdate == true && Login.disableCurrentVersion == false)
			{
				check();
			}
		} //检查当前版本是否屏蔽，确定是否启动快速升级

		public void update_info()
		{
			if(Login.disableCurrentVersion == true)
			{
				string selectcmd = "select 程序特点 from [VerList] where 程序名 = '汽车模型信息管理' and 屏蔽使用 = '否'";
				DatabaseCmd checkUpdate = new DatabaseCmd();
				SqlDataReader myreader;
				checkUpdate.SqlExecuteReader(selectcmd, out myreader);
				if(myreader.Read())
				{
					if(myreader.GetString(0).ToString() != "")
					{
						MessageBox.Show(myreader.GetString(0).ToString(), "更新信息", MessageBoxButtons.OK);
					}
				}
				checkUpdate.SqlReaderClose();
			}
		} //新版本更新信息，并更新

		public void check()
		{

		}
	}
}
