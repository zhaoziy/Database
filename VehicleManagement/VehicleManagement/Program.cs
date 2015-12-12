﻿using System;
using System.Windows.Forms;

namespace VehicleManagement
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

		static void Main()
        {
			LoadResourceDll.RegistDLL();
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
        }
    }
}
