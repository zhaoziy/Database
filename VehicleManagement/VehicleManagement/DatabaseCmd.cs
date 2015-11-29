﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace VehicleManagement
{
	class DatabaseCmd
	{
		static private string DatabaseName = "Vehicle";
		static private string connstr = "Data Source=.;Integrated Security=True;Database=" + DatabaseName + "";
		private SqlConnection conn = new SqlConnection(connstr);

		public bool SqlExecuteNonQuery(string sqlcmd)
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sqlcmd, conn);
			//SqlTransaction myTran=new SqlTransaction();  
			//注意，SqlTransaction类无公开的构造函数  
			SqlTransaction myTran = conn.BeginTransaction();
			cmd.Connection = conn;
			cmd.Transaction = myTran;
			try
			{
				//从此开始，基于该连接的数据操作都被认为是事务的一部分
				//下面绑定连接和事务对象  
				cmd.CommandText = "USE " + DatabaseName + "";
				cmd.ExecuteNonQuery();     //更新数据  
				cmd.CommandText = sqlcmd;
				cmd.ExecuteNonQuery();
				//提交事务  
				myTran.Commit();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				try
				{
					myTran.Rollback();
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message);
				}
				return false;
			}
			finally
			{
				myTran.Dispose();
				cmd.Transaction = null;
				conn.Close();
				conn.Dispose();
			}
		}  //不返回数据，只用于提交数据，比如insert、update、delete等

		public bool SqlExecuteReader(string sqlcmd, out SqlDataReader myreader)
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sqlcmd, conn);
			try
			{
				cmd.CommandText = "USE " + DatabaseName + "";
				cmd.ExecuteNonQuery();     //更新数据
				cmd.CommandText = sqlcmd;
				myreader = cmd.ExecuteReader();
				return true;
			}
			catch (Exception ex)
			{
				myreader = null;
				MessageBox.Show(ex.Message);
				return false;
			}
		}  //提交查询并返回数据，用于select

		public bool SqlReaderClose()
		{
			if (conn.State == ConnectionState.Open)
			{
				conn.Close();
				conn.Dispose();
			}
			else
			{
				conn.Dispose();
			}
			return true;
		}

		public bool SqlExecuteScalar(string sqlcmd, out object obj)
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sqlcmd, conn);
			//SqlTransaction myTran=new SqlTransaction();  
			//注意，SqlTransaction类无公开的构造函数  
			SqlTransaction myTran = conn.BeginTransaction();
			cmd.Connection = conn;
			cmd.Transaction = myTran;
			try
			{
				//从此开始，基于该连接的数据操作都被认为是事务的一部分
				//下面绑定连接和事务对象  
				cmd.CommandText = "USE " + DatabaseName + "";
				cmd.ExecuteNonQuery();     //更新数据  
				cmd.CommandText = sqlcmd;
				obj = cmd.ExecuteScalar();
				//提交事务  
				myTran.Commit();
				return true;
			}
			catch (Exception ex)
			{
				obj = null;
				MessageBox.Show(ex.Message);
				try
				{
					myTran.Rollback();
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message);
				}
				return false;
			}
			finally
			{
				myTran.Dispose();
				cmd.Transaction = null;
				conn.Close();
				conn.Dispose();
			}
		}  //用于提交数据，返回更新后的第一行第一列的值。例如：插入数据，返回刚刚插入数据的ID.

		public DataTable SqlDataTable(string strname, string str, out DataSet ds, out SqlDataAdapter da)
		{
			SqlConnection conn = new SqlConnection(connstr);
			try
			{
				conn.Open();
				da = new SqlDataAdapter(str, connstr);
				SqlCommandBuilder thisBuilder = new SqlCommandBuilder(da);
				ds = new DataSet();
				da.Fill(ds, strname);
				DataTable mytable = new DataTable();
				mytable = ds.Tables[0];
				return mytable;
			}
			catch (Exception ex)
			{
				da = null;
				ds = null;
				MessageBox.Show(ex.Message);
				return null;
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		public bool SqlUploadGeoInfo(string[] Column, UploadToDatabase.GeoInfo GeoInfoStruct)
		{
            conn.Open();
			SqlCommand cmd = new SqlCommand();

			SqlTransaction myTran = conn.BeginTransaction();
			cmd.Connection = conn;
			cmd.Transaction = myTran;

			try
			{
				cmd.CommandType = CommandType.Text;
				






				cmd.CommandText = "insert into VehicleGeoInfo (";
				for (int iLoop = 0; iLoop < 11; ++iLoop)
				{
					cmd.CommandText = cmd.CommandText + Column[iLoop] + ",";
				}
				cmd.CommandText = cmd.CommandText + "信息更新时间) values (@int1, @str1, @str2, @byte1, @byte2" +
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

				if(GeoInfoStruct.JPGByte != null){byte1.Value = GeoInfoStruct.JPGByte;}
				else{byte1.Value = System.DBNull.Value;}

				if(GeoInfoStruct.BWFByte != null){byte2.Value = GeoInfoStruct.BWFByte;}
				else{byte2.Value = System.DBNull.Value;}

				if(GeoInfoStruct.TMPLTByte != null){byte3.Value = GeoInfoStruct.TMPLTByte;}
				else{byte3.Value = System.DBNull.Value;}

				if(GeoInfoStruct.LQBByte != null){byte4.Value = GeoInfoStruct.LQBByte;}
				else{byte4.Value = System.DBNull.Value;}

				if(GeoInfoStruct.PRTByte != null){byte5.Value = GeoInfoStruct.PRTByte;}
				else{byte5.Value = System.DBNull.Value;}

				if(GeoInfoStruct.STLByte != null){byte6.Value = GeoInfoStruct.STLByte;}
				else{byte6.Value = System.DBNull.Value;}

				bool1.Value = GeoInfoStruct.IsModel;
				int2.Value = 1;
				date1.Value = GeoInfoStruct.UpdateDate;

				cmd.Parameters.Add(int1);
				cmd.Parameters.Add(str1);
				cmd.Parameters.Add(str2);
				cmd.Parameters.Add(byte1);
				cmd.Parameters.Add(byte2);
				cmd.Parameters.Add(byte3);
				cmd.Parameters.Add(byte4);
				cmd.Parameters.Add(byte5);
				cmd.Parameters.Add(byte6);
				cmd.Parameters.Add(bool1);
				cmd.Parameters.Add(int2);
				cmd.Parameters.Add(date1);

				cmd.ExecuteNonQuery();

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
				cmd.Transaction = null;
				conn.Close();
				conn.Dispose();
			}
		}

		//public bool SqlUploadGeoInfo(string[] Column, UploadToDatabase.GeoInfo GeoInfoStruct)
		//{
		//	conn.Open();
		//	SqlCommand cmd = new SqlCommand();

		//	SqlTransaction myTran = conn.BeginTransaction();
		//	cmd.Connection = conn;
		//	cmd.Transaction = myTran;

		//	try
		//	{
		//		cmd.CommandType = CommandType.Text;
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//		return false;
		//	}
		//	finally
		//	{
		//		myTran.Dispose();
		//		cmd.Transaction = null;
		//		conn.Close();
		//		conn.Dispose();
		//	}
		//}
	}
}