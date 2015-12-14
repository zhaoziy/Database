namespace VehicleManagement
{
	partial class SearchBoxComponent
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Option_ComboBox = new System.Windows.Forms.ComboBox();
			this.Condition_TextBox = new System.Windows.Forms.TextBox();
			this.Logical_ComboBox = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// Option_ComboBox
			// 
			this.Option_ComboBox.DropDownWidth = 120;
			this.Option_ComboBox.FormattingEnabled = true;
			this.Option_ComboBox.Location = new System.Drawing.Point(3, 3);
			this.Option_ComboBox.MaxDropDownItems = 10;
			this.Option_ComboBox.Name = "Option_ComboBox";
			this.Option_ComboBox.Size = new System.Drawing.Size(81, 20);
			this.Option_ComboBox.TabIndex = 0;
			this.Option_ComboBox.SelectedValueChanged += new System.EventHandler(this.Option_ComboBox_SelectedValueChanged);
			// 
			// Condition_TextBox
			// 
			this.Condition_TextBox.Location = new System.Drawing.Point(162, 3);
			this.Condition_TextBox.Name = "Condition_TextBox";
			this.Condition_TextBox.Size = new System.Drawing.Size(134, 21);
			this.Condition_TextBox.TabIndex = 1;
			this.Condition_TextBox.TextChanged += new System.EventHandler(this.Condition_TextBox_TextChanged);
			// 
			// Logical_ComboBox
			// 
			this.Logical_ComboBox.FormattingEnabled = true;
			this.Logical_ComboBox.Items.AddRange(new object[] {
            "Like",
            "区间"});
			this.Logical_ComboBox.Location = new System.Drawing.Point(90, 3);
			this.Logical_ComboBox.Name = "Logical_ComboBox";
			this.Logical_ComboBox.Size = new System.Drawing.Size(53, 20);
			this.Logical_ComboBox.TabIndex = 2;
			this.Logical_ComboBox.Text = "Like";
			this.Logical_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Logical_ComboBox_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.numericUpDown2);
			this.panel1.Controls.Add(this.numericUpDown1);
			this.panel1.Location = new System.Drawing.Point(139, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(138, 24);
			this.panel1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(61, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(11, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "-";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.DecimalPlaces = 1;
			this.numericUpDown2.Location = new System.Drawing.Point(80, 0);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(54, 21);
			this.numericUpDown2.TabIndex = 1;
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 1;
			this.numericUpDown1.Location = new System.Drawing.Point(0, 0);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(54, 21);
			this.numericUpDown1.TabIndex = 0;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// SearchBoxComponent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Logical_ComboBox);
			this.Controls.Add(this.Condition_TextBox);
			this.Controls.Add(this.Option_ComboBox);
			this.DoubleBuffered = true;
			this.Name = "SearchBoxComponent";
			this.Size = new System.Drawing.Size(370, 28);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox Option_ComboBox;
		private System.Windows.Forms.TextBox Condition_TextBox;
		private System.Windows.Forms.ComboBox Logical_ComboBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
	}
}
