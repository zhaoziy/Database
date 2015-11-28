using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace VehicleManagement
{
	public partial class UploadToDatabase : Form
	{
		public UploadToDatabase()
		{
			InitializeComponent();
		}

		private void CreateModel_Info_Click(object sender, EventArgs e)
		{
			ArrayList ColNameList;
			GetColumnNames(0, out ColNameList);

			ExcelCmd excelcmd = new ExcelCmd();
			excelcmd.CreateOrOpenExcelFile(true);
			excelcmd.GetSheetIndex(1);
			excelcmd.RenameSheet(1, "基本信息模板");
			int iLoop = 0;
			for (iLoop = 0; iLoop < ColNameList.Count; ++iLoop)
			{
                excelcmd.FillCell(1, iLoop + 1, ColNameList[iLoop]);
            }

			saveFileDialog1.FileName = "基本信息模板.xlsx";
            DialogResult result = saveFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				excelcmd.SaveFile(saveFileDialog1.FileName);
			}
			else
			{
				MessageBox.Show("未指定保存路径，默认保存到D:\\基本信息模板.xlsx");
				excelcmd.SaveFile("D:\\基本信息模板.xlsx");
			}
			excelcmd.ExitExcelApp();
		}
				
		private void CreateModel_Geo_Click(object sender, EventArgs e)
		{
			ArrayList ColNameList;
			GetColumnNames(1, out ColNameList);

			ExcelCmd excelcmd = new ExcelCmd();
			excelcmd.CreateOrOpenExcelFile(true);
			excelcmd.GetSheetIndex(1);
			excelcmd.RenameSheet(1, "几何信息模板");
			int iLoop = 0;
			for (iLoop = 0; iLoop < ColNameList.Count; ++iLoop)
			{
				excelcmd.FillCell(1, iLoop + 1, ColNameList[iLoop]);
			}

			saveFileDialog1.FileName = "几何信息模板.xlsx";
			DialogResult result = saveFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				excelcmd.SaveFile(saveFileDialog1.FileName);
			}
			else
			{
				MessageBox.Show("未指定保存路径，默认保存到D:\\几何信息模板.xlsx");
				excelcmd.SaveFile("D:\\几何信息模板.xlsx");
			}
			excelcmd.ExitExcelApp();
		}

		private void GetColumnNames(int mode, out ArrayList ColNameList)
		{
			ColNameList = new ArrayList();
			int iLoop = 0;

			if (mode == 0)
			{
				string[] ColName_Vehicle_Array = Enum.GetNames(typeof(ColName_Vehicle));

				for (iLoop = 1; iLoop < 32; ++iLoop)
				{
					ColNameList.Add(ColName_Vehicle_Array[iLoop]);
				}
			}
			else
			{
				ColNameList = new ArrayList();

				string[] ColName_VehicleGeo_Array = Enum.GetNames(typeof(ColName_VehicleGeo));

				for (iLoop = 1; iLoop < 10; ++iLoop)
				{
					ColNameList.Add(ColName_VehicleGeo_Array[iLoop]);
				}
			}
		}

		private void Upload_Info_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "导入数据库";
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{

			}
		}

		private void Upload_Geo_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "导入数据库";
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{

			}
		}
	}
}

#region"枚举变量"

enum ColName_Vehicle
{
	ID = 0, 车型 = 1, 厂商 = 2, 级别 = 3, 车身结构 = 4, 长 = 5, 宽 = 6, 高 = 7, 最高车速 = 8, 百公里加速 = 9,
	综合油耗 = 10, 最小离地间隙 = 11, 轴距 = 12, 前轮距 = 13, 后轮距 = 14, 整备质量 = 15, 车门数 = 16,
	座位数 = 17, 行李箱容积 = 18, 排量 = 19, 前轮胎规格 = 20, 后轮胎规格 = 21, 电动天窗 = 22, 全景天窗 = 23,
	运动外观套件 = 24, 铝合金轮圈 = 25, 电动吸合门 = 26, 侧滑门 = 27, 电动后备箱 = 28, 感应后备箱 = 29,
	车顶行李架 = 30, 外观颜色 = 31, 信息更新时间 = 32
}

enum ColName_VehicleGeo
{
	ID = 0, 车型 = 1, JPG = 2, BWF = 3, TMPLT = 4, LQB = 5, PRT = 6, STL = 7, 是否模板 = 8, 版本 = 9, 信息更新时间 = 10
}

#endregion