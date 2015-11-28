using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

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

		private static void FileToBinary(string path, out Byte[] byData)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			byData = br.ReadBytes((int)fs.Length);
			fs.Close();
		}  //把文件转成二进制流出入数据库

		private static void BinaryToFile(Byte[] Files, string path)
		{
			BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
			bw.Write(Files);
			bw.Close();
		}//从数据库中把二进制流读出写入还原成文件

		private static void FileToStream(string path, Stream st)
		{

		}
	}
}
