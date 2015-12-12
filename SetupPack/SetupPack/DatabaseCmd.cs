using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace SetupPack
{
	class DatabaseCmd
	{
		static private string DatabaseName = "Vehicle";
		static private string connstr = "server=115.159.90.52;database=" + DatabaseName + "; uid=sa;pwd=Elab2015;connection timeout = 5;";
		private SqlConnection conn = new SqlConnection(connstr);
		private SqlCommand command = new SqlCommand();

		public bool SqlExecuteNonQuery(string sqlcmd)
		{
			conn.Open();
			//SqlTransaction myTran=new SqlTransaction();  
			//注意，SqlTransaction类无公开的构造函数  
			SqlTransaction myTran = conn.BeginTransaction();
			command.Connection = conn;
			command.Transaction = myTran;
			try
			{
				//从此开始，基于该连接的数据操作都被认为是事务的一部分
				//下面绑定连接和事务对象  
				command.CommandText = "USE " + DatabaseName + "";
				command.ExecuteNonQuery();     //更新数据  
				command.CommandText = sqlcmd;
				command.ExecuteNonQuery();
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
				command.Transaction = null;
				conn.Close();
			}
		}  //不返回数据，只用于提交数据，比如insert、update、delete等

		public bool SqlExecuteReader(string sqlcmd, out SqlDataReader myreader)
		{
			conn.Open();
			command.Connection = conn;
            try
			{
				command.CommandText = "USE " + DatabaseName + "";
				command.ExecuteNonQuery();     //更新数据
				command.CommandText = sqlcmd;
				myreader = command.ExecuteReader();
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
			}
			return true;
		}

		public bool SqlExecuteScalar(string sqlcmd, out object obj)
		{
			conn.Open();
			//SqlTransaction myTran=new SqlTransaction();  
			//注意，SqlTransaction类无公开的构造函数  
			SqlTransaction myTran = conn.BeginTransaction();
			command.Connection = conn;
			command.Transaction = myTran;
			try
			{
				//从此开始，基于该连接的数据操作都被认为是事务的一部分
				//下面绑定连接和事务对象  
				command.CommandText = "USE " + DatabaseName + "";
				command.ExecuteNonQuery();     //更新数据  
				command.CommandText = sqlcmd;
				obj = command.ExecuteScalar();
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
				command.Transaction = null;
				conn.Close();
			}
		}  //用于提交数据，返回更新后的第一行第一列的值。例如：插入数据，返回刚刚插入数据的ID.

		public DataTable SqlDataTable(string strname, string str, out DataSet ds, out SqlDataAdapter da)
		{
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
			}
		}

		public SqlConnection GetConnection()
		{
			return conn;
        }

		public SqlCommand GetCommand()
		{
			return command;
		}
	}
}