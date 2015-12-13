namespace VehicleManagement
{
	partial class SearchOne
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Close_Bt = new System.Windows.Forms.Button();
			this.Search_Bt = new System.Windows.Forms.Button();
			this.panel_SearchBox = new System.Windows.Forms.Panel();
			this.AddConditon_BT = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Close_Bt
			// 
			this.Close_Bt.Location = new System.Drawing.Point(84, 4);
			this.Close_Bt.Margin = new System.Windows.Forms.Padding(2);
			this.Close_Bt.Name = "Close_Bt";
			this.Close_Bt.Size = new System.Drawing.Size(56, 26);
			this.Close_Bt.TabIndex = 2;
			this.Close_Bt.Text = "关闭";
			this.Close_Bt.UseVisualStyleBackColor = true;
			this.Close_Bt.Click += new System.EventHandler(this.button1_Click);
			// 
			// Search_Bt
			// 
			this.Search_Bt.Location = new System.Drawing.Point(7, 4);
			this.Search_Bt.Margin = new System.Windows.Forms.Padding(2);
			this.Search_Bt.Name = "Search_Bt";
			this.Search_Bt.Size = new System.Drawing.Size(56, 26);
			this.Search_Bt.TabIndex = 1;
			this.Search_Bt.Text = "搜索";
			this.Search_Bt.UseVisualStyleBackColor = true;
			this.Search_Bt.Click += new System.EventHandler(this.Search_Bt_Click);
			// 
			// panel_SearchBox
			// 
			this.panel_SearchBox.Location = new System.Drawing.Point(32, 12);
			this.panel_SearchBox.Name = "panel_SearchBox";
			this.panel_SearchBox.Size = new System.Drawing.Size(309, 27);
			this.panel_SearchBox.TabIndex = 4;
			// 
			// AddConditon_BT
			// 
			this.AddConditon_BT.Location = new System.Drawing.Point(356, 13);
			this.AddConditon_BT.Name = "AddConditon_BT";
			this.AddConditon_BT.Size = new System.Drawing.Size(97, 23);
			this.AddConditon_BT.TabIndex = 6;
			this.AddConditon_BT.Text = "点我增加条件";
			this.AddConditon_BT.UseVisualStyleBackColor = true;
			this.AddConditon_BT.Click += new System.EventHandler(this.AddConditon_BT_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Close_Bt);
			this.panel1.Controls.Add(this.Search_Bt);
			this.panel1.Location = new System.Drawing.Point(166, 22);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(147, 40);
			this.panel1.TabIndex = 7;
			// 
			// SearchOne
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 75);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.AddConditon_BT);
			this.Controls.Add(this.panel_SearchBox);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SearchOne";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "检索";
			this.TopMost = true;
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Close_Bt;
		private System.Windows.Forms.Button Search_Bt;
		private System.Windows.Forms.Panel panel_SearchBox;
		private System.Windows.Forms.Button AddConditon_BT;
		private System.Windows.Forms.Panel panel1;
	}
}