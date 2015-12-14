using System;
using System.Data.SqlClient;

namespace VehicleManagement
{
	class CheckNewVersion
	{
		private int Version = 0;

		public CheckNewVersion(int Ver)
		{
			Version = Ver;
		}

		public void CheckVerList()
		{
			bool QuickUpdate = false;
			string selectcmd = "select 屏蔽使用,快速升级 from [VerList] where 程序名 = '汽车模型信息管理' and 版本号 = " + Version;
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
			if(QuickUpdate == true || Login.disableCurrentVersion == true)
			{
				check();
			}
		} //检查当前版本是否屏蔽，确定是否启动快速升级

		public void update_info()
		{
			if(Login.disableCurrentVersion == true)
			{
				string selectcmd = "select 程序特点 from [VerList] where 程序名 = '汽车模型信息管理' and 屏蔽使用 = 'false'";
				DatabaseCmd checkUpdate = new DatabaseCmd();
				SqlDataReader myreader;
				checkUpdate.SqlExecuteReader(selectcmd, out myreader);
				if(myreader.Read())
				{
					if(myreader.GetValue(0).ToString() != "")
					{
						System.Windows.Forms.MessageBox.Show((string)myreader.GetValue(0).ToString(), "更新信息", System.Windows.Forms.MessageBoxButtons.OK);
					}
				}
				checkUpdate.SqlReaderClose();
			}
		} //新版本更新信息，并更新

		public void check()
		{
			string ThisApp = System.Windows.Forms.Application.ExecutablePath;
			string ThisAppMD5 = UserFunction.GetMD5HashFromFile(ThisApp);
			DatabaseCmd checkver = new DatabaseCmd();
			object obj = null;
			checkver.SqlExecuteScalar("select * from [VerList] where MD5 = '" + ThisAppMD5 + "'", out obj);
			if(obj == null)
			{
				update();
			}
		}

		public void update()
		{
			string AppPath = System.Windows.Forms.Application.StartupPath;

			byte[] res = new byte[VehicleManagement.Properties.Resources.SetupPack.Length];
			VehicleManagement.Properties.Resources.SetupPack.CopyTo(res, 0);
			System.IO.FileStream fs = new System.IO.FileStream(AppPath + "\\SetupPack.exe", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			fs.Write(res, 0, res.Length);
			fs.Close();

			string str1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
			System.Diagnostics.Process.Start(AppPath + "\\SetupPack.exe", str1);
			Environment.Exit(0);
		}  //更新
	}
}
