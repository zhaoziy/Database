using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetupPack
{
	public partial class SetupPack : Form
	{
		private static string SoftName = "汽车模型信息管理";
		private string AppPath = Application.StartupPath + "\\" + SoftName + ".exe";

		public SetupPack(string path)
		{
			InitializeComponent();
			if(path != null)
			{
				AppPath = path;
			}
		}

		private void Setup_Load(object sender, EventArgs e)
		{
			timer1.Interval = 1000;
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (Process.GetProcessesByName(SoftName).Length == 0)
			{
				if (File.Exists(AppPath))
				{
					File.Delete(AppPath);
				}

				UserFunction.DownloadFtp(AppPath.Substring(0, AppPath.LastIndexOf("\\")), "汽车模型信息管理.exe", "115.159.90.52", "zhao", "123abc");

				string NewFileMD5 = UserFunction.GetMD5HashFromFile(AppPath);
				string updatestr = "update [VerList] set MD5 = '" + NewFileMD5
					+ "' where 版本号 =(select TOP 1 版本号 from [VerList] where 程序名 = '汽车模型信息管理' order by 版本号 desc)";
				DatabaseCmd cmd = new DatabaseCmd();
				cmd.SqlExecuteNonQuery(updatestr);
				
				Process ps = new Process();
				ps.StartInfo.FileName = AppPath;
				ps.Start();
				Application.Exit();
			}
		}

		private void SetupPack_Shown(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void SetupPack_FormClosing(object sender, FormClosingEventArgs e)
		{
			DelMyself();
		}

		bool DelMyself()
		{
			try
			{
				StreamWriter batfile = new StreamWriter(Application.StartupPath + "\\" + "Zhao.bat", false, System.Text.Encoding.Default);
				batfile.Write("@echo off");
				batfile.WriteLine();
				batfile.Write("ping 127.1 -n 5 >nul");
				batfile.WriteLine();
				batfile.Write("del " + Application.ExecutablePath + "" + " && del %0");
				batfile.Close();
				batfile = null;

				Process p = new Process();
				p.StartInfo.FileName = Application.StartupPath + "\\" + "Zhao.bat";
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardInput = true;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.RedirectStandardError = true;
				p.StartInfo.CreateNoWindow = true;
				p.Start();

				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}
	}
}
