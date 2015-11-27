using System;
using System.IO;

namespace VehicleManagement
{
	class FileBinary
	{
		private void FileToBinary(string path, out Byte[] byData)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			byData = br.ReadBytes((int)fs.Length);
			fs.Close();
		}  //把文件转成二进制流出入数据库

		private void BinaryToFile(Byte[] Files, string path)
		{
			BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
			bw.Write(Files);
			bw.Close();
		}//从数据库中把二进制流读出写入还原成文件
	}
}
