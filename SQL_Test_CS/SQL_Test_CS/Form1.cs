using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_Test_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			DatabaseCmd select = new DatabaseCmd();
			string str = "select * from Vehicle";
			SqlDataReader myreader = null;
			select.SqlExecuteReader(str, out myreader);
			if (myreader.Read())
			{
				string a = "";
				a = myreader.GetString(2);
				MessageBox.Show(a);
			}
        }
	}
}
