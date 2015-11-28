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
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// CreateModel_Info
			// 
			this.CreateModel_Info.Location = new System.Drawing.Point(48, 45);
			this.CreateModel_Info.Name = "CreateModel_Info";
			this.CreateModel_Info.Size = new System.Drawing.Size(100, 30);
			this.CreateModel_Info.TabIndex = 0;
			this.CreateModel_Info.Text = "生成模板";
			this.CreateModel_Info.UseVisualStyleBackColor = true;
			this.CreateModel_Info.Click += new System.EventHandler(this.CreateModel_Info_Click);
			// 
			// Upload_Info
			// 
			this.Upload_Info.Location = new System.Drawing.Point(185, 45);
			this.Upload_Info.Name = "Upload_Info";
			this.Upload_Info.Size = new System.Drawing.Size(100, 30);
			this.Upload_Info.TabIndex = 1;
			this.Upload_Info.Text = "导入数据库";
			this.Upload_Info.UseVisualStyleBackColor = true;
			this.Upload_Info.Click += new System.EventHandler(this.Upload_Info_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "模板.xlsx";
			this.openFileDialog1.Filter = "Excel文件|*.xlsx,*.xls";
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
			this.groupBox1.Location = new System.Drawing.Point(21, 22);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(332, 113);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "汽车基本信息";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.Upload_Geo);
			this.groupBox2.Controls.Add(this.CreateModel_Geo);
			this.groupBox2.Location = new System.Drawing.Point(21, 151);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(332, 113);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "汽车几何信息";
			// 
			// Upload_Geo
			// 
			this.Upload_Geo.Location = new System.Drawing.Point(185, 47);
			this.Upload_Geo.Name = "Upload_Geo";
			this.Upload_Geo.Size = new System.Drawing.Size(100, 30);
			this.Upload_Geo.TabIndex = 1;
			this.Upload_Geo.Text = "导入数据库";
			this.Upload_Geo.UseVisualStyleBackColor = true;
			this.Upload_Geo.Click += new System.EventHandler(this.Upload_Geo_Click);
			// 
			// CreateModel_Geo
			// 
			this.CreateModel_Geo.Location = new System.Drawing.Point(48, 47);
			this.CreateModel_Geo.Name = "CreateModel_Geo";
			this.CreateModel_Geo.Size = new System.Drawing.Size(100, 30);
			this.CreateModel_Geo.TabIndex = 0;
			this.CreateModel_Geo.Text = "生成模板";
			this.CreateModel_Geo.UseVisualStyleBackColor = true;
			this.CreateModel_Geo.Click += new System.EventHandler(this.CreateModel_Geo_Click);
			// 
			// UploadToDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 287);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximumSize = new System.Drawing.Size(400, 334);
			this.MinimumSize = new System.Drawing.Size(400, 334);
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
	}
}