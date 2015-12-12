using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Net;

namespace SetupPack
{
	static class UserFunction
	{
		public static string GetMD5HashFromFile(string fileName)
		{
			try
			{
				using (FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
					{
						byte[] hash = md5.ComputeHash(reader);
						return ByteArrayToString(hash);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("GetMD5HashFromFile() fail, error:" + ex.Message);
			}
		}

		private static string ByteArrayToString(byte[] arrInput)
		{
			StringBuilder BAT = new StringBuilder(arrInput.Length * 2);
			for (int iLoop = 0; iLoop <= arrInput.Length - 1; ++iLoop)
			{
				BAT.Append(arrInput[iLoop].ToString("X2"));
			}
			return BAT.ToString().ToLower();
		}

		public static int DownloadFtp(string filePath, string fileName, string ftpServerIP, string ftpUserID, string ftpPassword)
		{
			FtpWebRequest reqFTP;
			try
			{
				//filePath = < <The full path where the file is to be created.>>, 
				//fileName = < <Name of the file to be created(Need not be the name of the file on FTP server).>> 
				FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

				reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));
				reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
				reqFTP.UseBinary = true;
				reqFTP.KeepAlive = false;
				reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
				FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
				Stream ftpStream = response.GetResponseStream();
				long cl = response.ContentLength;
				int bufferSize = 2048;
				int readCount;
				byte[] buffer = new byte[bufferSize];

				readCount = ftpStream.Read(buffer, 0, bufferSize);
				while (readCount > 0)
				{
					outputStream.Write(buffer, 0, readCount);
					readCount = ftpStream.Read(buffer, 0, bufferSize);
				}

				ftpStream.Close();
				outputStream.Close();
				response.Close();
				return 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return -2;
			}
		}
	}
}
