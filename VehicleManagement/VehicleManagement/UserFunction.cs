﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VehicleManagement
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
			;
            try
			{
				FileInfo fi = new FileInfo(path);
				FileStream fs = fi.OpenRead();
				byteData = new byte[fs.Length];
				fs.Read(byteData, 0, Convert.ToInt32(fs.Length));
				fs.Close();
				fs.Dispose();
			}
			catch(Exception ex)
			{
				byteData = null;
                MessageBox.Show(ex.Message);
			}
		}  //把文件转成二进制流出入数据库

		public static void BinaryToFile(Byte[] Files, string path)
		{
			BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
			bw.Write(Files);
			bw.Close();
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
			catch(Exception ex)
			{
				return DateTime.Now;
				MessageBox.Show(ex.Message);
			}
			finally
			{
				datacmd.SqlReaderClose();
			}
        }
	}
}
