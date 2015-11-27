using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace VehicleManagement
{
	class UserFunction
	{
		public string Md5(string strPwd)   //正确的MD5加密
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
	}
}
