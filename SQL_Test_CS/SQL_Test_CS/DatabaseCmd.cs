using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		}

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
		}
	}
}
