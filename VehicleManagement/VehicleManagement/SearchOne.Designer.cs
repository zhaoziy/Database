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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Close_Bt
			// 
			this.Close_Bt.Location = new System.Drawing.Point(191, 92);
			this.Close_Bt.Name = "Close_Bt";
			this.Close_Bt.Size = new System.Drawing.Size(75, 33);
			this.Close_Bt.TabIndex = 2;
			this.Close_Bt.Text = "关闭";
			this.Close_Bt.UseVisualStyleBackColor = true;
			this.Close_Bt.Click += new System.EventHandler(this.button1_Click);
			// 
			// Search_Bt
			// 
			this.Search_Bt.Location = new System.Drawing.Point(88, 92);
			this.Search_Bt.Name = "Search_Bt";
			this.Search_Bt.Size = new System.Drawing.Size(75, 33);
			this.Search_Bt.TabIndex = 1;
			this.Search_Bt.Text = "搜索";
			this.Search_Bt.UseVisualStyleBackColor = true;
			this.Search_Bt.Click += new System.EventHandler(this.Search_Bt_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 15);
			this.label1.TabIndex = 3;
			this.label1.Text = "车型";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(88, 33);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(207, 25);
			this.textBox1.TabIndex = 0;
			// 
			// SearchOne
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 163);
			this.ControlBox = false;
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Search_Bt);
			this.Controls.Add(this.Close_Bt);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SearchOne";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "检索";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Close_Bt;
		private System.Windows.Forms.Button Search_Bt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
	}
}