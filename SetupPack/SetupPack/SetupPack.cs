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
				HttpDownloadFile("http://115.159.90.52//Resource//汽车模型信息管理.exe", AppPath);
				Application.Exit();
			}
		}

		public static string HttpDownloadFile(string url, string path)
		{
			// 设置参数
			HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
			//发送请求并获取相应回应数据
			HttpWebResponse response = request.GetResponse() as HttpWebResponse;
			//直到request.GetResponse()程序才开始向目标网页发送Post请求
			Stream responseStream = response.GetResponseStream();
			//创建本地文件写入流
			Stream stream = new FileStream(path, FileMode.Create);
			byte[] bArr = new byte[1024];
			int size = responseStream.Read(bArr, 0, (int)bArr.Length);
			while (size > 0)
			{
				stream.Write(bArr, 0, size);
				size = responseStream.Read(bArr, 0, (int)bArr.Length);
			}
			stream.Close();
			responseStream.Close();
			return path;
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
