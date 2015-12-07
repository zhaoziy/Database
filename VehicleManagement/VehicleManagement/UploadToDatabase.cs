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

		private void Upload_Info_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "基本信息导入数据库";
			openFileDialog1.FileName = "基本信息模板.xlsx";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				string[] FilePath = new string[openFileDialog1.FileNames.Length];
				int iLoop = 0;
				foreach (string FileName in openFileDialog1.FileNames)
				{
					FilePath[iLoop] = FileName;
					iLoop++;
				}

				if (UploadInfo(FilePath) == true)
				{
					MessageBox.Show("上传成功");
				}
				else
				{
					MessageBox.Show("上传失败，请查找原因后重试");
				}
			}
		}

		private void Upload_Geo_Click(object sender, EventArgs e)
		{
			progressBar.Minimum = 0;
			progressBar.Value = 0;

			openFileDialog1.Multiselect = false;
			openFileDialog1.Title = "几何信息导入数据库";
			openFileDialog1.FileName = "几何信息模板.xlsx";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
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

				int ProgressCount = 0;

				for (int iLoop = 2; iLoop < ExcelRow; ++iLoop)
				{
					ProgressCount++;
                }
				progressBar.Maximum = ProgressCount;

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

					if (filter.ToLower() == ".jpg") { UserFunction.FileToBinary(path, out UpdataGeoInfo.JPGByte); }
					else { UpdataGeoInfo.JPGByte = null; }

					path = (string)excelcmd.GetCell(iLoop, 5);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".bwf") { UserFunction.FileToBinary(path, out UpdataGeoInfo.BWFByte); }
					else { UpdataGeoInfo.BWFByte = null; }

					path = (string)excelcmd.GetCell(iLoop, 6);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".tmplt") { UserFunction.FileToBinary(path, out UpdataGeoInfo.TMPLTByte); }
					else { UpdataGeoInfo.TMPLTByte = null; }

					path = (string)excelcmd.GetCell(iLoop, 7);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".lqb") { UserFunction.FileToBinary(path, out UpdataGeoInfo.LQBByte); }
					else { UpdataGeoInfo.LQBByte = null; }

					path = (string)excelcmd.GetCell(iLoop, 8);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".prt") { UserFunction.FileToBinary(path, out UpdataGeoInfo.PRTByte); }
					else { UpdataGeoInfo.PRTByte = null; }

					path = (string)excelcmd.GetCell(iLoop, 9);
					filter = Path.GetExtension(path);

					if (filter.ToLower() == ".stl") { UserFunction.FileToBinary(path, out UpdataGeoInfo.STLByte); }
					else { UpdataGeoInfo.STLByte = null; }

					if ((string)excelcmd.GetCell(iLoop, 10) == "是") { UpdataGeoInfo.IsModel = true; }
					else { UpdataGeoInfo.IsModel = false; }

					string str = "select top 1 版本 from [VehicleGeoInfo] where 汽车ID = " + UpdataGeoInfo.ID + " order by 版本 desc";
					DatabaseCmd datacmd = new DatabaseCmd();

					SqlDataReader myreader;
					datacmd.SqlExecuteReader(str, out myreader);

					UpdataGeoInfo.Version = (myreader.Read()) ? (UpdataGeoInfo.Version = myreader.GetInt32(0) + 1) : (1);
					datacmd.SqlReaderClose();

					UpdataGeoInfo.UpdateDate = UserFunction.GetServerDateTime();

					SqlUploadGeoInfo(column, UpdataGeoInfo, 4);

					progressBar.Value++;
                }
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
				datacmd.GetCommand().CommandText += "信息更新时间) values (@int1, @str1, @str2, @byte1, @byte2" +
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

		public bool UploadInfo(string[] FilePath)
		{
			string[] column = Enum.GetNames(typeof(ColName_Vehicle));

			ExcelCmd excelcmd = new ExcelCmd();
			int ProgressCount = 0;
			try
			{
				for (int iLoop = 0; iLoop < FilePath.Length; ++iLoop)
				{
					excelcmd.CreateOrOpenExcelFile(false, FilePath[iLoop]);
					excelcmd.GetSheetIndex(1);

					int ExcelCol = 0;
					do
					{
						ExcelCol++;
					}
					while ((string)excelcmd.GetCell(1, ExcelCol) != "");

					for (int Col = 2; Col <= ExcelCol; ++Col)
					{
						ProgressCount++;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				excelcmd.CloseExcelWorkbooks();
			}

            progressBar.Minimum = 0;
			progressBar.Value = 0;
			progressBar.Maximum = ProgressCount;

            try
			{
				for (int iLoop = 0; iLoop < FilePath.Length; ++iLoop)
				{
					excelcmd.CreateOrOpenExcelFile(false, FilePath[iLoop]);
					excelcmd.GetSheetIndex(1);

					int ExcelCol = 0;
					do
					{
						ExcelCol++;
					}
					while ((string)excelcmd.GetCell(1, ExcelCol) != "");

					for (int Col = 2; Col <= ExcelCol; ++Col)
					{
						Info UploadInfo = new Info();
						try { UploadInfo.汽车ID = Int32.Parse((string)excelcmd.GetCell(Config.汽车ID, Col)); } catch (Exception ex) { }
						try { UploadInfo.车型 = (string)excelcmd.GetCell(Config.车型, Col); } catch (Exception ex) { }
						try { UploadInfo.厂商 = (string)excelcmd.GetCell(Config.厂商, Col); } catch (Exception ex) { }
						try { UploadInfo.级别 = (string)excelcmd.GetCell(Config.级别, Col); } catch (Exception ex) { }
						try { UploadInfo.车身结构 = (string)excelcmd.GetCell(Config.车身结构, Col); } catch (Exception ex) { }
						try { UploadInfo.长 = Int32.Parse((string)excelcmd.GetCell(Config.长, Col)); } catch (Exception ex) { }
						try { UploadInfo.宽 = Int32.Parse((string)excelcmd.GetCell(Config.宽, Col)); } catch (Exception ex) { }
						try { UploadInfo.高 = Int32.Parse((string)excelcmd.GetCell(Config.高, Col)); } catch (Exception ex) { }
						try { UploadInfo.最高车速 = Int32.Parse((string)excelcmd.GetCell(Config.最高车速, Col)); } catch (Exception ex) { }
						try { UploadInfo.百公里加速 = float.Parse((string)excelcmd.GetCell(Config.百公里加速, Col)); } catch (Exception ex) { }
						try { UploadInfo.综合油耗 = float.Parse((string)excelcmd.GetCell(Config.综合油耗, Col)); } catch (Exception ex) { }
						try { UploadInfo.最小离地间隙 = Int32.Parse((string)excelcmd.GetCell(Config.最小离地间隙, Col)); } catch (Exception ex) { }
						try { UploadInfo.轴距 = Int32.Parse((string)excelcmd.GetCell(Config.轴距, Col)); } catch (Exception ex) { }
						try { UploadInfo.前轮距 = Int32.Parse((string)excelcmd.GetCell(Config.前轮距, Col)); } catch (Exception ex) { }
						try { UploadInfo.后轮距 = Int32.Parse((string)excelcmd.GetCell(Config.后轮距, Col)); } catch (Exception ex) { }
						try { UploadInfo.整备质量 = float.Parse((string)excelcmd.GetCell(Config.整备质量, Col)); } catch (Exception ex) { }
						try { UploadInfo.车门数 = Int32.Parse((string)excelcmd.GetCell(Config.车门数, Col)); } catch (Exception ex) { }
						try { UploadInfo.座位数 = Int32.Parse((string)excelcmd.GetCell(Config.座位数, Col)); } catch (Exception ex) { }
						try { UploadInfo.行李厢容积 = Int32.Parse((string)excelcmd.GetCell(Config.行李厢容积, Col)); } catch (Exception ex) { }
						try { UploadInfo.排量 = Int32.Parse((string)excelcmd.GetCell(Config.排量, Col)); } catch (Exception ex) { }
						try { UploadInfo.前轮胎规格 = (string)excelcmd.GetCell(Config.前轮胎规格, Col); } catch (Exception ex) { }
						try { UploadInfo.后轮胎规格 = (string)excelcmd.GetCell(Config.后轮胎规格, Col); } catch (Exception ex) { }
						try { UploadInfo.电动天窗 = ((string)excelcmd.GetCell(Config.电动天窗, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.全景天窗 = ((string)excelcmd.GetCell(Config.全景天窗, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.运动外观套件 = ((string)excelcmd.GetCell(Config.运动外观套件, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.铝合金轮圈 = ((string)excelcmd.GetCell(Config.铝合金轮圈, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.电动吸合门 = ((string)excelcmd.GetCell(Config.电动吸合门, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.侧滑门 = ((string)excelcmd.GetCell(Config.侧滑门, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.电动后备厢 = ((string)excelcmd.GetCell(Config.电动后备厢, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.感应后备厢 = ((string)excelcmd.GetCell(Config.感应后备厢, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.车顶行李架 = ((string)excelcmd.GetCell(Config.车顶行李架, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
						try { UploadInfo.外观颜色 = (string)excelcmd.GetCell(Config.外观颜色, Col); } catch (Exception ex) { }
						try { UploadInfo.信息更新时间 = UserFunction.GetServerDateTime(); } catch (Exception ex) { }

						SqlUpoadeInfo(column, UploadInfo);
						progressBar.Value++;
                    }
				}
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
			finally
			{
				excelcmd.ExitExcelApp();
			}			
		}

		public bool SqlUpoadeInfo(string[] Column, UploadToDatabase.Info InfoStruct)
		{
			try
			{
				string InsertStr = "insert into VehicleInfo (";
				for (int iLoop = 0; iLoop < 32; ++iLoop)
				{
					InsertStr += Column[iLoop] + ",";
				}
				InsertStr += "信息更新时间) values (";
				InsertStr += InfoStruct.汽车ID + ",'";
				InsertStr += InfoStruct.车型 + "','";
				InsertStr += InfoStruct.厂商 + "','";
				InsertStr += InfoStruct.级别 + "','";
				InsertStr += InfoStruct.车身结构 + "',";
				InsertStr += InfoStruct.长 + ",";
				InsertStr += InfoStruct.宽 + ",";
				InsertStr += InfoStruct.高 + ",";
				InsertStr += InfoStruct.最高车速 + ",";
				InsertStr += InfoStruct.百公里加速 + ",";
				InsertStr += InfoStruct.综合油耗 + ",";
				InsertStr += InfoStruct.最小离地间隙 + ",";
				InsertStr += InfoStruct.轴距 + ",";
				InsertStr += InfoStruct.前轮距 + ",";
				InsertStr += InfoStruct.后轮距 + ",";
				InsertStr += InfoStruct.整备质量 + ",";
				InsertStr += InfoStruct.车门数 + ",";
				InsertStr += InfoStruct.座位数 + ",";
				InsertStr += InfoStruct.行李厢容积 + ",";
				InsertStr += InfoStruct.排量 + ",'";
				InsertStr += InfoStruct.前轮胎规格 + "','";
				InsertStr += InfoStruct.后轮胎规格 + "','";
				InsertStr += InfoStruct.电动天窗 + "','";
				InsertStr += InfoStruct.全景天窗 + "','";
				InsertStr += InfoStruct.运动外观套件 + "','";
				InsertStr += InfoStruct.铝合金轮圈 + "','";
				InsertStr += InfoStruct.电动吸合门 + "','";
				InsertStr += InfoStruct.侧滑门 + "','";
				InsertStr += InfoStruct.电动后备厢 + "','";
				InsertStr += InfoStruct.感应后备厢 + "','";
				InsertStr += InfoStruct.车顶行李架 + "','";
				InsertStr += InfoStruct.外观颜色 + "','";
				InsertStr += InfoStruct.信息更新时间;
				InsertStr += "')";

				DatabaseCmd databasecmd = new DatabaseCmd();
				databasecmd.SqlExecuteNonQuery(InsertStr);

				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
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

		public struct Info
		{
			public int 汽车ID;
			public string 车型;
			public string 厂商;
			public string 级别;
			public string 车身结构;
			public int 长;
			public int 宽;
			public int 高;
			public int 最高车速;
			public float 百公里加速;
			public float 综合油耗;
			public int 最小离地间隙;
			public int 轴距;
			public int 前轮距;
			public int 后轮距;
			public float 整备质量;
			public int 车门数;
			public int 座位数;
			public int 行李厢容积;
			public int 排量;
			public string 前轮胎规格;
			public string 后轮胎规格;
			public bool 电动天窗;
			public bool 全景天窗;
			public bool 运动外观套件;
			public bool 铝合金轮圈;
			public bool 电动吸合门;
			public bool 侧滑门;
			public bool 电动后备厢;
			public bool 感应后备厢;
			public bool 车顶行李架;
			public string 外观颜色;
			public DateTime 信息更新时间;
		}
	}
}