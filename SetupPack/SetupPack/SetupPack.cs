using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace SetupPack
{
	public partial class SetupPack : Form
	{
		bool flag = false;
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
			this.lbl_ftpStakt.Text = "网络连接中";
			timer1.Interval = 300;
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (Process.GetProcessesByName(SoftName).Length == 0)
			{
				if (flag == true)
				{
					return;
				}
				flag = true;

				if (File.Exists(AppPath))
				{
					File.Delete(AppPath);
				}

				FtpDownload(AppPath.Substring(0, AppPath.LastIndexOf("\\")), "汽车模型信息管理.exe", "115.159.90.52", "zhao", "123abc");

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

		#region FTP下载带进度条
		/// <param name="filePath">下载到客户端的地址</param>
		/// <param name="fileName">FTP上对应的文件名</param>
		private bool FtpDownload(string filePath, string fileName, string ftpServerIP, string ftpUserID, string ftpPassword)
		{
			this.lbl_ftpStakt.Text = "网络连接中";
			FtpWebRequest reqFTP;
			try
			{
				//打开一个文件流 (System.IO.FileStream) 去读要下载的文件
				FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));
				// ftp用户名和密码
				reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
				// 指定执行什么命令
				reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
				// 指定数据传输类型
				reqFTP.UseBinary = true;

				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

				Stream ftpStream = response.GetResponseStream();
				//这里其实取不到FTP上该文件的大小，应另写方法来获取(WebRequestMethods.Ftp.GetFileSize)
				//long cl = response.ContentLength;
				// 缓冲大小设置为2kb
				int bufferSize = 2048;// 4096;// 2048; //局域网内可以放大点

				int readCount;

				byte[] buffer = new byte[bufferSize];

				readCount = ftpStream.Read(buffer, 0, bufferSize);
				//FTP上文件的大小
				int allbye = this.GetFtpFileSize(fileName, ftpServerIP, ftpUserID, ftpPassword);
				int startbye = 0;
				this.myProgressControl.Maximum = allbye;
				this.myProgressControl.Minimum = 0;
				this.myProgressControl.Visible = true;
				this.lbl_ftpStakt.Visible = true;
				// 流内容没有结束
				while (readCount > 0)
				{
					// 把内容从file stream 写入 DownLoadStream
					outputStream.Write(buffer, 0, readCount);

					readCount = ftpStream.Read(buffer, 0, bufferSize);
					//
					startbye += readCount;
					this.lbl_ftpStakt.Text = "已下载:" + (int)(startbye / 1024) + "KB/" + "总长度:" + (int)(allbye / 1024) + "KB" + " " + " 文件名:" + fileName;
					myProgressControl.Value = startbye;
					Application.DoEvents();
					Thread.Sleep(5);
				}
				this.myProgressControl.Visible = false;
				this.lbl_ftpStakt.Text = "下载成功!";
				ftpStream.Close();
				outputStream.Close();
				response.Close();
				return true;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
			}
		}
		#endregion

		#region 获取FTP服务器上指定文件的大小
		/// <summary>
		/// 获取FTP服务器上指定文件的大小
		/// </summary>
		/// <param name="fileName">FTP服务器上的文件名</param>
		/// <returns></returns>
		private int GetFtpFileSize(string fileName, string ftpServerIP, string ftpUserID, string ftpPassword)
		{
			FtpWebRequest reqFTP;
			int fileSize = 0;
			try
			{
				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));

				reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

				reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;

				reqFTP.UseBinary = true;
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				Stream ftpStream = response.GetResponseStream();
				fileSize = (int)response.ContentLength;

				ftpStream.Close();
				response.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return fileSize;
		}
		#endregion

	}
}
