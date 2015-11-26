using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQL_Test_CS
{
    class DatabaseCmd
    {
		static string connstr = "Data Source=.;Integrated Security=True;Database=test";

		public bool SqlExecuteNonQuery(string sqlcmd)
		{
			SqlConnection conn = new SqlConnection(connstr);
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
				cmd.CommandText = "USE test";
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

		public bool SqlExecuteReader(string sqlcmd,out SqlDataReader myreader)
		{
			SqlConnection conn = new SqlConnection(connstr);
			conn.Open();
			SqlCommand cmd = new SqlCommand(sqlcmd, conn);
			try
			{
				cmd.CommandText = "USE test";
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

		public bool SqlExecuteScalar(string sqlcmd,out object obj)
		{
			SqlConnection conn = new SqlConnection(connstr);
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
				cmd.CommandText = "USE test";
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

		public DatabaseCmd()
		{ } //构造函数

		~DatabaseCmd()
		{ } //析构函数
	}
}
