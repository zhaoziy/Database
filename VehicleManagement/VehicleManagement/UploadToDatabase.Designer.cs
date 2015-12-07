namespace VehicleManagement
{
	partial class UploadToDatabase
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
			this.CreateModel_Info = new System.Windows.Forms.Button();
			this.Upload_Info = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Upload_Geo = new System.Windows.Forms.Button();
			this.CreateModel_Geo = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// CreateModel_Info
			// 
			this.CreateModel_Info.Location = new System.Drawing.Point(36, 28);
			this.CreateModel_Info.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.CreateModel_Info.Name = "CreateModel_Info";
			this.CreateModel_Info.Size = new System.Drawing.Size(75, 24);
			this.CreateModel_Info.TabIndex = 0;
			this.CreateModel_Info.Text = "生成模板";
			this.CreateModel_Info.UseVisualStyleBackColor = true;
			this.CreateModel_Info.Click += new System.EventHandler(this.CreateModel_Info_Click);
			// 
			// Upload_Info
			// 
			this.Upload_Info.Location = new System.Drawing.Point(139, 28);
			this.Upload_Info.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Upload_Info.Name = "Upload_Info";
			this.Upload_Info.Size = new System.Drawing.Size(75, 24);
			this.Upload_Info.TabIndex = 1;
			this.Upload_Info.Text = "导入数据库";
			this.Upload_Info.UseVisualStyleBackColor = true;
			this.Upload_Info.Click += new System.EventHandler(this.Upload_Info_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "模板.xlsx";
			this.openFileDialog1.Filter = "Excel文件|*.xlsx";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "模板.xlsx";
			this.saveFileDialog1.Filter = "Excel文件|*.xlsx";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CreateModel_Info);
			this.groupBox1.Controls.Add(this.Upload_Info);
			this.groupBox1.Location = new System.Drawing.Point(16, 18);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new System.Drawing.Size(249, 74);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "汽车基本信息";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Upload_Geo);
			this.groupBox2.Controls.Add(this.CreateModel_Geo);
			this.groupBox2.Location = new System.Drawing.Point(16, 105);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox2.Size = new System.Drawing.Size(249, 73);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "汽车几何信息";
			// 
			// Upload_Geo
			// 
			this.Upload_Geo.Location = new System.Drawing.Point(139, 28);
			this.Upload_Geo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Upload_Geo.Name = "Upload_Geo";
			this.Upload_Geo.Size = new System.Drawing.Size(75, 24);
			this.Upload_Geo.TabIndex = 1;
			this.Upload_Geo.Text = "导入数据库";
			this.Upload_Geo.UseVisualStyleBackColor = true;
			this.Upload_Geo.Click += new System.EventHandler(this.Upload_Geo_Click);
			// 
			// CreateModel_Geo
			// 
			this.CreateModel_Geo.Location = new System.Drawing.Point(36, 28);
			this.CreateModel_Geo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.CreateModel_Geo.Name = "CreateModel_Geo";
			this.CreateModel_Geo.Size = new System.Drawing.Size(75, 24);
			this.CreateModel_Geo.TabIndex = 0;
			this.CreateModel_Geo.Text = "生成模板";
			this.CreateModel_Geo.UseVisualStyleBackColor = true;
			this.CreateModel_Geo.Click += new System.EventHandler(this.CreateModel_Geo_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 186);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(264, 28);
			this.progressBar.TabIndex = 4;
			// 
			// UploadToDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 222);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximumSize = new System.Drawing.Size(304, 261);
			this.MinimumSize = new System.Drawing.Size(304, 261);
			this.Name = "UploadToDatabase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "导入数据库";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CreateModel_Info;
		private System.Windows.Forms.Button Upload_Info;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button Upload_Geo;
		private System.Windows.Forms.Button CreateModel_Geo;
		private System.Windows.Forms.ProgressBar progressBar;
	}
}