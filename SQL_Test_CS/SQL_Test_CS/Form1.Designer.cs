namespace SQL_Test_CS
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.导入数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.textData = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabText = new System.Windows.Forms.TabPage();
			this.tabDatabase = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabText.SuspendLayout();
			this.tabDatabase.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.退出ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(633, 25);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.导入数据库ToolStripMenuItem});
			this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
			this.文件ToolStripMenuItem.Text = "文件";
			// 
			// 打开ToolStripMenuItem
			// 
			this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
			this.打开ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.打开ToolStripMenuItem.Text = "打开";
			this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
			// 
			// 导入数据库ToolStripMenuItem
			// 
			this.导入数据库ToolStripMenuItem.Name = "导入数据库ToolStripMenuItem";
			this.导入数据库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.导入数据库ToolStripMenuItem.Text = "导入数据库";
			this.导入数据库ToolStripMenuItem.Click += new System.EventHandler(this.导入数据库ToolStripMenuItem_Click);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "文本文件|*.txt|所有文件|*.*";
			// 
			// textData
			// 
			this.textData.AcceptsReturn = true;
			this.textData.AcceptsTab = true;
			this.textData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textData.Location = new System.Drawing.Point(2, 2);
			this.textData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textData.Multiline = true;
			this.textData.Name = "textData";
			this.textData.Size = new System.Drawing.Size(621, 291);
			this.textData.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabText);
			this.tabControl1.Controls.Add(this.tabDatabase);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 25);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(633, 321);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabText
			// 
			this.tabText.Controls.Add(this.textData);
			this.tabText.Location = new System.Drawing.Point(4, 22);
			this.tabText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabText.Name = "tabText";
			this.tabText.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabText.Size = new System.Drawing.Size(625, 295);
			this.tabText.TabIndex = 0;
			this.tabText.Text = "文本信息";
			this.tabText.UseVisualStyleBackColor = true;
			// 
			// tabDatabase
			// 
			this.tabDatabase.Controls.Add(this.listView1);
			this.tabDatabase.Location = new System.Drawing.Point(4, 22);
			this.tabDatabase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabDatabase.Name = "tabDatabase";
			this.tabDatabase.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabDatabase.Size = new System.Drawing.Size(625, 295);
			this.tabDatabase.TabIndex = 1;
			this.tabDatabase.Text = "数据库";
			this.tabDatabase.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(2, 2);
			this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(621, 291);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 346);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabText.ResumeLayout(false);
			this.tabText.PerformLayout();
			this.tabDatabase.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 导入数据库ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textData;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabText;
		private System.Windows.Forms.TabPage tabDatabase;
		private System.Windows.Forms.ListView listView1;
	}
}

