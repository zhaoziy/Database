using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using VehicleManagement.Properties;
using System.Text.RegularExpressions;

namespace VehicleManagement
{
	public partial class UploadToDatabase : Form
	{
		public UploadToDatabase(string Num, string Name)
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
			MessageBox.Show("生成成功，请在桌面查找 : 基本信息模板.xlsx");
		}

		private void CreateModel_Geo_Click(object sender, EventArgs e)
		{
			byte[] res;
			res = new byte[Resources.几何信息模板.Length];
			Resources.几何信息模板.CopyTo(res, 0);
			FileStream fs = new FileStream(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\几何信息模板.xlsx", FileMode.Create, FileAccess.Write);
			fs.Write(res, 0, res.Length);
			fs.Close();
			MessageBox.Show("生成成功，请在桌面查找 : 几何信息模板.xlsx");
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
			ManagementMain.refreshinfo();
		}

		public bool UploadInfo(string[] FilePath)
		{
			string[] column = Enum.GetNames(typeof(ColName_Vehicle));

			ExcelCmd excelcmd = new ExcelCmd();
			int ProgressCount = 0;

			for (int iLoop = 0; iLoop < FilePath.Length; ++iLoop)
			{
				excelcmd.CreateOrOpenExcelFile(false, FilePath[iLoop]);
				excelcmd.SetActiveSheet(1);

				int ExcelCol = 0;
				do
				{
					ExcelCol++;
				}
				while ((string)excelcmd.GetCell(10, ExcelCol) != "");
				ProgressCount += (ExcelCol - 2);
				excelcmd.CloseExcelWorkbooks();
			}

			progressBar.Minimum = 0;
			progressBar.Value = 0;
			progressBar.Maximum = ProgressCount;

			for (int iLoop = 0; iLoop < FilePath.Length; ++iLoop)
			{
				excelcmd.CreateOrOpenExcelFile(false, FilePath[iLoop]);
				excelcmd.SetActiveSheet(1);

				Config config = new Config(FilePath[iLoop]);

				int ExcelCol = 0;
				do
				{
					ExcelCol++;
				}
				while ((string)excelcmd.GetCell(10, ExcelCol) != "");

				for (int Col = 2; Col < ExcelCol; ++Col)
				{
					progressBar.Value++;

					Info UploadInfo = new Info();
					try { UploadInfo.车型 = (string)excelcmd.GetCell(config.车型, Col); } catch (Exception ex) { }
					try { UploadInfo.型号 = UserFunction.GetModelNum(UploadInfo.车型); } catch (Exception ex) { }

					try
					{
						Regex reg = new Regex("[1-2]\\d\\d\\d");
						Match match = reg.Match(UploadInfo.车型);
						UploadInfo.年款 = Int32.Parse(match.Value);
					}
					catch (Exception ex) { }

					try { UploadInfo.品牌 = (string)excelcmd.GetCell(config.品牌, Col); } catch (Exception ex) { }
					try { UploadInfo.厂商 = (string)excelcmd.GetCell(config.厂商, Col); } catch (Exception ex) { }
					try { UploadInfo.级别 = (string)excelcmd.GetCell(config.级别, Col); } catch (Exception ex) { }
					try { UploadInfo.车身结构 = (string)excelcmd.GetCell(config.车身结构, Col); } catch (Exception ex) { }
					try { UploadInfo.长 = Int32.Parse((string)excelcmd.GetCell(config.长, Col)); } catch (Exception ex) { }
					try { UploadInfo.宽 = Int32.Parse((string)excelcmd.GetCell(config.宽, Col)); } catch (Exception ex) { }
					try { UploadInfo.高 = Int32.Parse((string)excelcmd.GetCell(config.高, Col)); } catch (Exception ex) { }
					try { UploadInfo.最高车速 = Int32.Parse((string)excelcmd.GetCell(config.最高车速, Col)); } catch (Exception ex) { }
					try { UploadInfo.百公里加速 = float.Parse((string)excelcmd.GetCell(config.百公里加速, Col)); } catch (Exception ex) { }
					try { UploadInfo.综合油耗 = float.Parse((string)excelcmd.GetCell(config.综合油耗, Col)); } catch (Exception ex) { }
					try { UploadInfo.最小离地间隙 = Int32.Parse((string)excelcmd.GetCell(config.最小离地间隙, Col)); } catch (Exception ex) { }
					try { UploadInfo.轴距 = Int32.Parse((string)excelcmd.GetCell(config.轴距, Col)); } catch (Exception ex) { }
					try { UploadInfo.前轮距 = Int32.Parse((string)excelcmd.GetCell(config.前轮距, Col)); } catch (Exception ex) { }
					try { UploadInfo.后轮距 = Int32.Parse((string)excelcmd.GetCell(config.后轮距, Col)); } catch (Exception ex) { }
					try { UploadInfo.整备质量 = float.Parse((string)excelcmd.GetCell(config.整备质量, Col)); } catch (Exception ex) { }
					try { UploadInfo.车门数 = Int32.Parse((string)excelcmd.GetCell(config.车门数, Col)); } catch (Exception ex) { }
					try { UploadInfo.座位数 = Int32.Parse((string)excelcmd.GetCell(config.座位数, Col)); } catch (Exception ex) { }
					try { UploadInfo.行李厢容积 = Int32.Parse((string)excelcmd.GetCell(config.行李厢容积, Col)); } catch (Exception ex) { }
					try { UploadInfo.排量 = Int32.Parse((string)excelcmd.GetCell(config.排量, Col)); } catch (Exception ex) { }
					try { UploadInfo.最大马力 = Int32.Parse((string)excelcmd.GetCell(config.最大马力, Col)); } catch (Exception ex) { }
					try { UploadInfo.最大功率 = Int32.Parse((string)excelcmd.GetCell(config.最大功率, Col)); } catch (Exception ex) { }
					try { UploadInfo.前轮胎规格 = (string)excelcmd.GetCell(config.前轮胎规格, Col); } catch (Exception ex) { }
					try { UploadInfo.后轮胎规格 = (string)excelcmd.GetCell(config.后轮胎规格, Col); } catch (Exception ex) { }
					try { UploadInfo.电动天窗 = ((string)excelcmd.GetCell(config.电动天窗, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.全景天窗 = ((string)excelcmd.GetCell(config.全景天窗, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.运动外观套件 = ((string)excelcmd.GetCell(config.运动外观套件, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.铝合金轮圈 = ((string)excelcmd.GetCell(config.铝合金轮圈, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.电动吸合门 = ((string)excelcmd.GetCell(config.电动吸合门, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.侧滑门 = ((string)excelcmd.GetCell(config.侧滑门, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.电动后备厢 = ((string)excelcmd.GetCell(config.电动后备厢, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.感应后备厢 = ((string)excelcmd.GetCell(config.感应后备厢, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.车顶行李架 = ((string)excelcmd.GetCell(config.车顶行李架, Col) != "-") ? (true) : (false); } catch (Exception ex) { }
					try { UploadInfo.外观颜色 = (string)excelcmd.GetCell(config.外观颜色, Col); } catch (Exception ex) { }
					try { UploadInfo.变速箱 = (string)excelcmd.GetCell(config.变速箱, Col); } catch (Exception ex) { }
					try { UploadInfo.信息更新时间 = UserFunction.GetServerDateTime(); } catch (Exception ex) { }
					try { UploadInfo.信息更新者工号 = ManagementMain.UserNum; } catch (Exception ex) { }
					try { UploadInfo.信息更新者姓名 = ManagementMain.UserName; } catch (Exception ex) { }

					try
					{
						UploadInfo.汽车ID = UserFunction.GetFirstPinyin(UploadInfo.型号) + "_" + UploadInfo.年款.ToString() + "_" +
							UserFunction.GetFirstPinyin(UploadInfo.厂商) + "_" + UploadInfo.排量 + "_" + UploadInfo.最大马力 + "_" +
							UploadInfo.最大功率 + "_" + UserFunction.GetFirstPinyin(UploadInfo.变速箱) + "_" +
							UserFunction.GetFirstPinyin(UploadInfo.车身结构)  + "_" +
							UserFunction.GetFirstPinyin(UserFunction.GetLastLabel(UploadInfo.车型));
					}
					catch (Exception ex) { }

					SqlUploadeInfo(column, UploadInfo);
				}
			}
			excelcmd.ExitExcelApp();
			return true;
		}

		public bool SqlUploadeInfo(string[] Column, Info InfoStruct)
		{
			string InsertStr = "insert into VehicleInfo (";
			for (int iLoop = 0; iLoop < Column.Length - 1; ++iLoop)
			{
				InsertStr += Column[iLoop] + ",";
			}
			InsertStr += "信息更新者姓名) values ('";
			InsertStr += InfoStruct.汽车ID + "','";
			InsertStr += InfoStruct.车型 + "','";
			InsertStr += InfoStruct.型号 + "','";
			InsertStr += InfoStruct.品牌 + "',";
			InsertStr += InfoStruct.年款 + ",'";
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
			InsertStr += InfoStruct.排量 + ",";
			InsertStr += InfoStruct.最大马力 + ",";
			InsertStr += InfoStruct.最大功率 + ",'";
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
			InsertStr += InfoStruct.变速箱 + "','";
			InsertStr += InfoStruct.信息更新时间 + "','";
			InsertStr += InfoStruct.信息更新者工号 + "','";
			InsertStr += InfoStruct.信息更新者姓名 + "')";

			DatabaseCmd databasecmd = new DatabaseCmd();
			if (databasecmd.SqlExecuteNonQuery(InsertStr) == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void Upload_Geo_Click(object sender, EventArgs e)
		{
			openFileDialog1.Multiselect = false;
			openFileDialog1.Title = "几何信息导入数据库";
			openFileDialog1.FileName = "几何信息模板.xlsx";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				ExcelCmd excelcmd = new ExcelCmd();
				excelcmd.CreateOrOpenExcelFile(false, openFileDialog1.FileName);
				excelcmd.SetActiveSheet(1);

				string[] column = Enum.GetNames(typeof(ColName_VehicleGeo));

				int ExcelRow = excelcmd.GetLastRow(1);

				progressBar.Minimum = 0;
				progressBar.Value = 0;
				progressBar.Maximum = ExcelRow - 1;

				for (int iLoop = 2; iLoop <= ExcelRow; ++iLoop)
				{
					progressBar.Value++;
					GeoInfo UpdataGeoInfo = new GeoInfo();

					UpdataGeoInfo.视图 = (string)excelcmd.GetCell(iLoop, 5);
					string path = (string)excelcmd.GetCell(iLoop, 4);
					string filter = Path.GetExtension(path).Substring(1, Path.GetExtension(path).Length - 1);

					UpdataGeoInfo.Ext = filter;
					if (UpdataGeoInfo.Ext.ToUpper() == "TMPLT" ||
							UpdataGeoInfo.Ext.ToUpper() == "LQB" ||
							UpdataGeoInfo.Ext.ToUpper() == "BWF" ||
							UpdataGeoInfo.Ext.ToUpper() == "PRT" ||
							UpdataGeoInfo.Ext.ToUpper() == "STL" ||
							UpdataGeoInfo.Ext.ToUpper() == "JPG")
					{
						UpdataGeoInfo.汽车ID = (string)excelcmd.GetCell(iLoop, 1);
						UpdataGeoInfo.Car = (string)excelcmd.GetCell(iLoop, 2);
						UpdataGeoInfo.Factory = (string)excelcmd.GetCell(iLoop, 3);

						string str = "select top 1 版本 from [GeoInfo_" + UpdataGeoInfo.Ext + 
							"] where 汽车ID = '" + UpdataGeoInfo.汽车ID + "' and 视图= '" + UpdataGeoInfo.视图 + 
							" 'order by 版本 desc";
						DatabaseCmd datacmd = new DatabaseCmd();
						SqlDataReader myreader;
						datacmd.SqlExecuteReader(str, out myreader);

						UpdataGeoInfo.Version = (myreader.Read()) ? (UpdataGeoInfo.Version = myreader.GetInt32(0) + 1) : (1);
						datacmd.SqlReaderClose();

						UserFunction.FileToBinary(path, out UpdataGeoInfo.ByteData);
						UpdataGeoInfo.IsModel = ((string)excelcmd.GetCell(iLoop, 6) == "是") ? (true) : (false);
						UpdataGeoInfo.UpdateDate = UserFunction.GetServerDateTime();
						UpdataGeoInfo.信息更新者工号 = ManagementMain.UserNum;
						UpdataGeoInfo.信息更新者姓名 = ManagementMain.UserName;

						if (UpdataGeoInfo.ByteData != null)
						{
							SqlUploadGeoInfo(column, UpdataGeoInfo, 5);
						}
					}
					else
					{
						MessageBox.Show("请上传正确的数据文件");
					}
				}
				excelcmd.ExitExcelApp();
				MessageBox.Show("导入成功");
				ManagementMain.refreshgeoinfo("", 1);
			}
		}

		public bool SqlUploadGeoInfo(string[] Column, GeoInfo GeoInfoStruct, int ReserveNum)
		{
			DatabaseCmd SelectCmd = new DatabaseCmd();
			string sqlstr = "select count(汽车ID) from [GeoInfo_" + GeoInfoStruct.Ext + 
				"] where 汽车ID = '" + GeoInfoStruct.汽车ID + "' and 视图 = '" + GeoInfoStruct.视图 + "'";
			try
			{
				SqlDataReader myreader;
				SelectCmd.SqlExecuteReader(sqlstr, out myreader);
				if (myreader.Read())
				{
					if (myreader.GetInt32(0) >= ReserveNum)
					{
						string delStr = "delete from [GeoInfo_" + GeoInfoStruct.Ext + "] where 汽车ID = '" + GeoInfoStruct.汽车ID +
							"' and 视图 = '" + GeoInfoStruct.视图 + "' and 版本 not in (select top " + (ReserveNum - 1) + " (版本) from [GeoInfo_" +
							GeoInfoStruct.Ext + "] where 汽车ID = '" + GeoInfoStruct.汽车ID + "' order by 版本 desc) ";
						DatabaseCmd deleteCmd = new DatabaseCmd();
						deleteCmd.SqlExecuteNonQuery(delStr);
					}
				}
			}
			catch (Exception ex){MessageBox.Show(ex.Message);}
			finally{SelectCmd.SqlReaderClose();}

			DatabaseCmd datacmd = new DatabaseCmd();
			datacmd.GetConnection().Open();
			SqlTransaction myTran = datacmd.GetConnection().BeginTransaction();
			try
			{
				datacmd.GetCommand().Connection = datacmd.GetConnection();
				datacmd.GetCommand().Transaction = myTran;
				datacmd.GetCommand().CommandType = CommandType.Text;
				datacmd.GetCommand().CommandText = "insert into [GeoInfo_" + GeoInfoStruct.Ext + "] (";
				for (int iLoop = 0; iLoop < Column.Length - 2; ++iLoop)
				{
					datacmd.GetCommand().CommandText = datacmd.GetCommand().CommandText + Column[iLoop] + ",";
				}
				datacmd.GetCommand().CommandText += "信息更新者姓名) values (@str1, @str2, @str3, @byte1, @str4, @int1" +
					", @bool1, @date1, @str5, @str6)";

				SqlParameter str1 = new SqlParameter("@str1", SqlDbType.NVarChar);
				SqlParameter str2 = new SqlParameter("@str2", SqlDbType.NVarChar);
				SqlParameter str3 = new SqlParameter("@str3", SqlDbType.NVarChar);
				SqlParameter byte1 = new SqlParameter("@byte1", SqlDbType.Image);
				SqlParameter str4 = new SqlParameter("@str4", SqlDbType.NVarChar);
				SqlParameter int1 = new SqlParameter("@int1", SqlDbType.Int);
				SqlParameter bool1 = new SqlParameter("@bool1", SqlDbType.Bit);
				SqlParameter date1 = new SqlParameter("@date1", SqlDbType.DateTime);
				SqlParameter str5 = new SqlParameter("@str5", SqlDbType.NVarChar);
				SqlParameter str6 = new SqlParameter("@str6", SqlDbType.NVarChar);

				str1.Value = GeoInfoStruct.汽车ID;
				str2.Value = GeoInfoStruct.Car;
				str3.Value = GeoInfoStruct.Factory;

				if (GeoInfoStruct.ByteData != null) { byte1.Value = GeoInfoStruct.ByteData; }
				else { byte1.Value = System.DBNull.Value; }

				str4.Value = GeoInfoStruct.视图;

				int1.Value = GeoInfoStruct.Version;
				bool1.Value = GeoInfoStruct.IsModel;
				date1.Value = GeoInfoStruct.UpdateDate;
				str5.Value = GeoInfoStruct.信息更新者工号;
				str6.Value = GeoInfoStruct.信息更新者姓名;

				datacmd.GetCommand().Parameters.Add(str1);
				datacmd.GetCommand().Parameters.Add(str2);
				datacmd.GetCommand().Parameters.Add(str3);
				datacmd.GetCommand().Parameters.Add(byte1);
				datacmd.GetCommand().Parameters.Add(str4);
				datacmd.GetCommand().Parameters.Add(int1);
				datacmd.GetCommand().Parameters.Add(bool1);
				datacmd.GetCommand().Parameters.Add(date1);
				datacmd.GetCommand().Parameters.Add(str5);
				datacmd.GetCommand().Parameters.Add(str6);

				datacmd.GetCommand().ExecuteNonQuery();
				myTran.Commit();

				if (GeoInfoStruct.IsModel == true)
				{
					string updatestr = "update [GeoInfo_" + GeoInfoStruct.Ext + "] set 是否模板 = 'false' where 汽车ID = '" +
						GeoInfoStruct.汽车ID + "' and 版本 <>" + GeoInfoStruct.Version;
					DatabaseCmd updatedatabase = new DatabaseCmd();
					updatedatabase.SqlExecuteNonQuery(updatestr);
				}

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

		public struct GeoInfo
		{
			public string 汽车ID;
			public string Car;
			public string Factory;
			public Byte[] ByteData;
			public string 视图;
			public int Version;
			public bool IsModel;
			public DateTime UpdateDate;
			public string 信息更新者工号;
			public string 信息更新者姓名;
			public string Ext;
		}

		public struct Info
		{
			public string 汽车ID;
			public string 车型;
			public string 型号;
			public string 品牌;
			public int 年款;
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
			public int 最大马力;
			public int 最大功率;
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
			public string 变速箱;
			public DateTime 信息更新时间;
			public string 信息更新者工号;
			public string 信息更新者姓名;
		}
	}
}