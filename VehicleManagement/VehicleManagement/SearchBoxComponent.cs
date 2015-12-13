using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehicleManagement
{
	public partial class SearchBoxComponent : UserControl
	{
		private string Option = string.Empty;
		private string Logical = "like";
		private string Conditon = string.Empty;
		private float Num1 = 0.0f;
		private float Num2 = 0.0f;

		public SearchBoxComponent()
		{
			InitializeComponent();
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			string[] Option_String = Enum.GetNames(typeof(ColName_Vehicle));
			foreach(string r in Option_String)
			{
				Option_ComboBox.Items.Add(r);
			}
		}

		private void Option_ComboBox_SelectedValueChanged(object sender, EventArgs e)
		{
			Option = Option_ComboBox.Text;
		}

		private void Logical_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Logical = Logical_ComboBox.Text;
			if (Logical.ToLower() == "like")
			{
				panel1.Enabled = false;
				panel1.Visible = false;
				Condition_TextBox.Enabled = true;
				Condition_TextBox.Visible = true;
				Condition_TextBox.Location = new Point(162, 3);
			}
			else if(Logical.ToLower() == "区间")
			{
				Condition_TextBox.Enabled = false;
				Condition_TextBox.Visible = false;
				panel1.Enabled = true;
				panel1.Visible = true;
				panel1.Location = new Point(162, 3);
			}
		}

		private void Condition_TextBox_TextChanged(object sender, EventArgs e)
		{
			Conditon = Condition_TextBox.Text;
		}

		public string GetOption
		{
			get { return Option; }
			set { Option = value; }
		}

		public string GetLogical
		{
			get { return Logical; }
			set { Logical = value; }
		}

		public string GetConditon
		{
			get { return Conditon; }
			set { Conditon = value; }
		}

		public float GetNumLower
		{
			get { return Num1; }
			set { Num1 = value; }
		}

		public float GetNumUpper
		{
			get { return Num2; }
			set { Num2 = value; }
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			Num1 = (float)numericUpDown1.Value;
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			Num2 = (float)numericUpDown2.Value;
		}
	}
}
