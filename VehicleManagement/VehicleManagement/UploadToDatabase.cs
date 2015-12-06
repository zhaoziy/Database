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
using VehicleManagement.Properties;

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
			byte[] res;
			res = new byte[Resources.基本信息模板.Length];
			Resources.基本信息模板.CopyTo(res, 0);
			FileStream fs = new FileStream(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\基本信息模板.xlsx", FileMode.Create, FileAccess.Write);
			fs.Write(res, 0, res.Length);
			fs.Close();
			MessageBox.Show("生成成功，请在桌面查找");
		}
		
		private void CreateModel_Geo_Click(object sender, EventArgs e)
		{
			byte[] res;
			res = new byte[Resources.几何信息模板.Length];
			Resources.几何信息模板.CopyTo(res, 0);
			FileStream fs = new FileStream(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\几何信息模板.xlsx", FileMode.Create, FileAccess.Write);
			fs.Write(res, 0, res.Length);
			fs.Close();
			MessageBox.Show("生成成功，请在桌面查找");
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

					if (filter.ToLower() == ".jpg") {UserFunction.FileToBinary(path, out UpdataGeoInfo.JPGByte);}
					else{UpdataGeoInfo.JPGByte = null;}

					path = (string)excelcmd.GetCell(iLoop, 5);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".bwf") {UserFunction.FileToBinary(path, out UpdataGeoInfo.BWFByte);}
					else{UpdataGeoInfo.BWFByte = null;}

					path = (string)excelcmd.GetCell(iLoop, 6);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".tmplt") {	UserFunction.FileToBinary(path, out UpdataGeoInfo.TMPLTByte);}
					else{UpdataGeoInfo.TMPLTByte = null;}

					path = (string)excelcmd.GetCell(iLoop, 7);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".lqb") {UserFunction.FileToBinary(path, out UpdataGeoInfo.LQBByte);}
					else{UpdataGeoInfo.LQBByte = null;}

					path = (string)excelcmd.GetCell(iLoop, 8);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".prt") {UserFunction.FileToBinary(path, out UpdataGeoInfo.PRTByte);}
					else{UpdataGeoInfo.PRTByte = null;}

					path = (string)excelcmd.GetCell(iLoop, 9);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".stl"){UserFunction.FileToBinary(path, out UpdataGeoInfo.STLByte);}
					else{UpdataGeoInfo.STLByte = null;}

					if ((string)excelcmd.GetCell(iLoop, 10) == "是"){UpdataGeoInfo.IsModel = true;}
					else{UpdataGeoInfo.IsModel = false;}

					string str = "select top 1 版本 from [VehicleGeoInfo] where 汽车ID = " + UpdataGeoInfo.ID + " order by 版本 desc";
					DatabaseCmd datacmd = new DatabaseCmd();

					SqlDataReader myreader;
					datacmd.SqlExecuteReader(str, out myreader);

					UpdataGeoInfo.Version = (myreader.Read()) ? (UpdataGeoInfo.Version = myreader.GetInt32(0) + 1) : (1);
					datacmd.SqlReaderClose();
										
					UpdataGeoInfo.UpdateDate = UserFunction.GetServerDateTime();

					SqlUploadGeoInfo(column, UpdataGeoInfo, 4);
                }
				MessageBox.Show("导入成功");
				excelcmd.ExitExcelApp();			
			}
		}

		public bool SqlUploadGeoInfo(string[] Column, UploadToDatabase.GeoInfo GeoInfoStruct, int ReserveNum)
		{
			DatabaseCmd SelectCmd = new DatabaseCmd();
			string sqlstr = "select count(汽车ID) from [VehicleGeoInfo] where 汽车ID = " + GeoInfoStruct.ID;
			try
			{
				SqlDataReader myreader;
				SelectCmd.SqlExecuteReader(sqlstr, out myreader);
				if (myreader.Read())
				{
					if (myreader.GetInt32(0) > ReserveNum)
					{
						string delStr = "delete from [VehicleGeoInfo] where 汽车ID = " + GeoInfoStruct.ID +
							"and 版本 not in (select top " + ReserveNum + " (版本) from[VehicleGeoInfo] where 汽车ID = " +
							GeoInfoStruct.ID + "order by 版本 desc) ";
						DatabaseCmd deleteCmd = new DatabaseCmd();
						deleteCmd.SqlExecuteNonQuery(delStr);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				SelectCmd.SqlReaderClose();
			}

			DatabaseCmd datacmd = new DatabaseCmd();
			datacmd.GetConnection().Open();
			SqlTransaction myTran = datacmd.GetConnection().BeginTransaction();
			try
			{ 
				datacmd.GetCommand().Connection = datacmd.GetConnection();
				datacmd.GetCommand().Transaction = myTran;
				datacmd.GetCommand().CommandType = CommandType.Text;
				datacmd.GetCommand().CommandText = "insert into VehicleGeoInfo (";
				for (int iLoop = 0; iLoop < 11; ++iLoop)
				{
					datacmd.GetCommand().CommandText = datacmd.GetCommand().CommandText + Column[iLoop] + ",";
				}
				datacmd.GetCommand().CommandText +=  "信息更新时间) values (@int1, @str1, @str2, @byte1, @byte2" +
					", @byte3, @byte4, @byte5, @byte6, @bool1, @int2, @date1)";

				SqlParameter int1 = new SqlParameter("@int1", SqlDbType.Int);
				SqlParameter str1 = new SqlParameter("@str1", SqlDbType.NVarChar);
				SqlParameter str2 = new SqlParameter("@str2", SqlDbType.NVarChar);
				SqlParameter byte1 = new SqlParameter("@byte1", SqlDbType.Image);
				SqlParameter byte2 = new SqlParameter("@byte2", SqlDbType.Image);
				SqlParameter byte3 = new SqlParameter("@byte3", SqlDbType.Image);
				SqlParameter byte4 = new SqlParameter("@byte4", SqlDbType.Image);
				SqlParameter byte5 = new SqlParameter("@byte5", SqlDbType.Image);
				SqlParameter byte6 = new SqlParameter("@byte6", SqlDbType.Image);
				SqlParameter bool1 = new SqlParameter("@bool1", SqlDbType.Bit);
				SqlParameter int2 = new SqlParameter("@int2", SqlDbType.Int);
				SqlParameter date1 = new SqlParameter("@date1", SqlDbType.DateTime);

				int1.Value = GeoInfoStruct.ID;
				str1.Value = GeoInfoStruct.Car;
				str2.Value = GeoInfoStruct.Factory;

				if (GeoInfoStruct.JPGByte != null) { byte1.Value = GeoInfoStruct.JPGByte; }
				else { byte1.Value = System.DBNull.Value; }

				if (GeoInfoStruct.BWFByte != null) { byte2.Value = GeoInfoStruct.BWFByte; }
				else { byte2.Value = System.DBNull.Value; }

				if (GeoInfoStruct.TMPLTByte != null) { byte3.Value = GeoInfoStruct.TMPLTByte; }
				else { byte3.Value = System.DBNull.Value; }

				if (GeoInfoStruct.LQBByte != null) { byte4.Value = GeoInfoStruct.LQBByte; }
				else { byte4.Value = System.DBNull.Value; }

				if (GeoInfoStruct.PRTByte != null) { byte5.Value = GeoInfoStruct.PRTByte; }
				else { byte5.Value = System.DBNull.Value; }

				if (GeoInfoStruct.STLByte != null) { byte6.Value = GeoInfoStruct.STLByte; }
				else { byte6.Value = System.DBNull.Value; }

				bool1.Value = GeoInfoStruct.IsModel;
				int2.Value = GeoInfoStruct.Version;
				date1.Value = GeoInfoStruct.UpdateDate;

				datacmd.GetCommand().Parameters.Add(int1);
				datacmd.GetCommand().Parameters.Add(str1);
				datacmd.GetCommand().Parameters.Add(str2);
				datacmd.GetCommand().Parameters.Add(byte1);
				datacmd.GetCommand().Parameters.Add(byte2);
				datacmd.GetCommand().Parameters.Add(byte3);
				datacmd.GetCommand().Parameters.Add(byte4);
				datacmd.GetCommand().Parameters.Add(byte5);
				datacmd.GetCommand().Parameters.Add(byte6);
				datacmd.GetCommand().Parameters.Add(bool1);
				datacmd.GetCommand().Parameters.Add(int2);
				datacmd.GetCommand().Parameters.Add(date1);

				datacmd.GetCommand().ExecuteNonQuery();

				myTran.Commit();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				myTran.Rollback();
				return false;
			}
			finally
			{
				myTran.Dispose();
				datacmd.GetCommand().Transaction = null;
				datacmd.GetConnection().Close();
			}
		}
	}
}