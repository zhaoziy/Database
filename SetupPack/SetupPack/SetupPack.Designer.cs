namespace SetupPack
{
	partial class SetupPack
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.myProgressControl = new System.Windows.Forms.ProgressBar();
			this.lbl_ftpStakt = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// myProgressControl
			// 
			this.myProgressControl.Location = new System.Drawing.Point(3, 35);
			this.myProgressControl.Name = "myProgressControl";
			this.myProgressControl.Size = new System.Drawing.Size(396, 30);
			this.myProgressControl.TabIndex = 0;
			// 
			// lbl_ftpStakt
			// 
			this.lbl_ftpStakt.AutoSize = true;
			this.lbl_ftpStakt.Location = new System.Drawing.Point(9, 77);
			this.lbl_ftpStakt.Name = "lbl_ftpStakt";
			this.lbl_ftpStakt.Size = new System.Drawing.Size(41, 12);
			this.lbl_ftpStakt.TabIndex = 1;
			this.lbl_ftpStakt.Text = "label1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "有新版本，正在更新中";
			// 
			// SetupPack
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 99);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbl_ftpStakt);
			this.Controls.Add(this.myProgressControl);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetupPack";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Setup";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupPack_FormClosing);
			this.Load += new System.EventHandler(this.Setup_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ProgressBar myProgressControl;
		private System.Windows.Forms.Label lbl_ftpStakt;
		private System.Windows.Forms.Label label1;
	}
}