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
using System.IO;

namespace VehicleManagement
{
	public partial class UploadToDatabase : Form
	{
		public UploadToDatabase()
		{
			InitializeComponent();
		}

		public struct GeoInfo
		{
			public int ID;
			public string Car;
			public string Factory;
			public Byte[] JPGByte;
			public Byte[] BWFByte;
			public Byte[] TMPLTByte;
			public Byte[] LQBByte;
			public Byte[] PRTByte;
			public Byte[] STLByte;
			public bool IsModel;
			public int Version;
			public DateTime UpdateDate;
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

				for (iLoop = 0; iLoop < 10; ++iLoop)
				{
					ColNameList.Add(ColName_VehicleGeo_Array[iLoop]);
				}
			}
		}

		private void Upload_Info_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "基本信息导入数据库";
			openFileDialog1.FileName = "基本信息模板.xlsx";
            DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{

			}
		}

		private void Upload_Geo_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "几何信息导入数据库";
			openFileDialog1.FileName = "几何信息模板.xlsx";
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				ExcelCmd excelcmd = new ExcelCmd();
				excelcmd.CreateOrOpenExcelFile(false, openFileDialog1.FileName);
				excelcmd.GetSheetIndex(1);

				string[] column = Enum.GetNames(typeof(ColName_VehicleGeo));

				int ExcelRow = 0;
				do
				{
					ExcelRow++;
				}
				while ((string)excelcmd.GetCell(ExcelRow, 1) != "");

				for (int iLoop = 2; iLoop < ExcelRow; ++iLoop)
				{
					string path = string.Empty;
					string filter = string.Empty;
					GeoInfo UpdataGeoInfo = new GeoInfo();

					UpdataGeoInfo.ID = Int32.Parse((string)excelcmd.GetCell(iLoop, 1));
					UpdataGeoInfo.Car = (string)excelcmd.GetCell(iLoop, 2);
					UpdataGeoInfo.Factory = (string)excelcmd.GetCell(iLoop, 3);

					path = (string)excelcmd.GetCell(iLoop, 4);
					filter = Path.GetExtension(path);

					if (filter == ".jpg")
					{
						UserFunction.FileToBinary(path, out UpdataGeoInfo.JPGByte);
					}
					else
					{
						UpdataGeoInfo.JPGByte = null;
					}

					path = (string)excelcmd.GetCell(iLoop, 5);
					filter = Path.GetExtension(path);

					if (filter == ".bwf" || filter == ".BWF")
					{
						UserFunction.FileToBinary(path, out UpdataGeoInfo.BWFByte);
					}
					else
					{
						UpdataGeoInfo.BWFByte = null;
					}

					path = (string)excelcmd.GetCell(iLoop, 6);
					filter = Path.GetExtension(path);

					if (filter == ".tmplt" || filter == ".TMPLT")
					{
						UserFunction.FileToBinary(path, out UpdataGeoInfo.TMPLTByte);
					}
					else
					{
						UpdataGeoInfo.TMPLTByte = null;
					}

					path = (string)excelcmd.GetCell(iLoop, 7);
					filter = Path.GetExtension(path);

					if (filter == ".lqb" || filter == ".LQB")
					{
						UserFunction.FileToBinary(path, out UpdataGeoInfo.LQBByte);
					}
					else
					{
						UpdataGeoInfo.LQBByte = null;
					}

					path = (string)excelcmd.GetCell(iLoop, 8);
					filter = Path.GetExtension(path);

					if (filter == ".prt" || filter == ".PRT")
					{
						UserFunction.FileToBinary(path, out UpdataGeoInfo.PRTByte);
					}
					else
					{
						UpdataGeoInfo.PRTByte = null;
					}

					path = (string)excelcmd.GetCell(iLoop, 9);
					filter = Path.GetExtension(path);

					if (filter == ".stl" || filter == ".STL")
					{
						UserFunction.FileToBinary(path, out UpdataGeoInfo.STLByte);
					}
					else
					{
						UpdataGeoInfo.STLByte = null;
					}

					if ((string)excelcmd.GetCell(iLoop, 10) == "是")
					{
						UpdataGeoInfo.IsModel = true;
					}
					else
					{
						UpdataGeoInfo.IsModel = false;
					}

					UpdataGeoInfo.Version = 0;
					UpdataGeoInfo.UpdateDate = UserFunction.GetServerDateTime();

					DatabaseCmd datacmd = new DatabaseCmd();
					datacmd.SqlUploadGeoInfo(column, UpdataGeoInfo);
                }
				MessageBox.Show("导入成功");
				excelcmd.ExitExcelApp();			
			}
		}
	}
}