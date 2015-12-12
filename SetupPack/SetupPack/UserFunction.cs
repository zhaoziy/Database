using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace SetupPack
{
	static class UserFunction
	{
		public static string Md5(string strPwd)   //正确的MD5加密
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strPwd);
			bytes = md5.ComputeHash(bytes);
			md5.Clear();

			string ret = "";
			for (int i = 0; i < bytes.Length; i++)
			{
				ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0').ToLower();
			}

			return ret.PadLeft(32, '0');
		}

		public static void FileToBinary(string path, out Byte[] byteData)
		{
			try
			{
				FileInfo fi = new FileInfo(path);
				FileStream fs = fi.OpenRead();
				byteData = new byte[fs.Length];
				fs.Read(byteData, 0, Convert.ToInt32(fs.Length));
				fs.Close();
				fs.Dispose();
			}
			catch (Exception ex)
			{
				byteData = null;
				MessageBox.Show(ex.Message);
			}
		}  //把文件转成二进制流出入数据库

		public static void BinaryToFile(Byte[] File, string path)
		{
			FileStream fs;
			FileInfo fi = new System.IO.FileInfo(path);
			fs = fi.OpenWrite();
			fs.Write(File, 0, File.Length);
			fs.Close();
		}//从数据库中把二进制流读出写入还原成文件

		public static DateTime GetServerDateTime()
		{
			string str = "select getdate() as serverDate";
			DatabaseCmd datacmd = new DatabaseCmd();
			SqlDataReader myreader;
			try
			{
				datacmd.SqlExecuteReader(str, out myreader);
				if (myreader.Read())
				{
					return myreader.GetDateTime(0);
				}
				else
				{
					return DateTime.Now;
				}
			}
			catch (Exception ex)
			{
				return DateTime.Now;
				MessageBox.Show(ex.Message);
			}
			finally
			{
				datacmd.SqlReaderClose();
			}
		}

		public static string GetModelNum(string str)
		{
			string[] strArray = str.Split(' ');
			return strArray[0];
		}

		public static int GetVintage(string str)
		{
			try
			{
				string[] strArray = str.Split(' ');
				string strtemp = strArray[1].Substring(0, 4);
				return Int32.Parse(strtemp);
			}
			catch(Exception ex)
			{
				return -1;
				MessageBox.Show(ex.Message);
			}			
		}

		public static string GetMD5HashFromFile(string fileName)
		{
			try
			{
				using(FileStream reader = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
					{
						byte[] hash = md5.ComputeHash(reader);
						return ByteArrayToString(hash);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("GetMD5HashFromFile() fail, error:" +ex.Message);
			}
		}

		private static string ByteArrayToString(byte[] arrInput)
		{
			StringBuilder BAT = new StringBuilder(arrInput.Length * 2);
			for(int iLoop = 0;iLoop <= arrInput.Length - 1; ++iLoop)
			{
				BAT.Append(arrInput[iLoop].ToString("X2"));
			}
			return BAT.ToString().ToLower();
		}
	}
}
