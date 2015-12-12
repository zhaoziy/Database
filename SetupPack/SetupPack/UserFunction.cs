using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
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
	}
}
