using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
	}
}