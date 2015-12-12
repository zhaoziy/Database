using System;
using System.Windows.Forms;

namespace SetupPack
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			string path = string.Empty;
			path = (args.Length == 0) ? (null) : (args[0]);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SetupPack(path));
		}
	}
}
