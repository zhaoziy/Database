namespace VehicleManagement
{
	partial class Login
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Num_Textbox = new System.Windows.Forms.TextBox();
			this.Pwd_Textbox = new System.Windows.Forms.TextBox();
			this.Login_Bt = new System.Windows.Forms.Button();
			this.Exit_Bt = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(64, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "工号";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(64, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "密码";
			// 
			// Num_Textbox
			// 
			this.Num_Textbox.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.Num_Textbox.Location = new System.Drawing.Point(107, 61);
			this.Num_Textbox.MaxLength = 11;
			this.Num_Textbox.Name = "Num_Textbox";
			this.Num_Textbox.Size = new System.Drawing.Size(224, 25);
			this.Num_Textbox.TabIndex = 2;
			this.Num_Textbox.Text = "21422011";
			this.Num_Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Num_Textbox_KeyPress);
			// 
			// Pwd_Textbox
			// 
			this.Pwd_Textbox.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.Pwd_Textbox.Location = new System.Drawing.Point(107, 121);
			this.Pwd_Textbox.Name = "Pwd_Textbox";
			this.Pwd_Textbox.PasswordChar = '*';
			this.Pwd_Textbox.Size = new System.Drawing.Size(224, 25);
			this.Pwd_Textbox.TabIndex = 3;
			this.Pwd_Textbox.Text = "123abc";
			// 
			// Login_Bt
			// 
			this.Login_Bt.Location = new System.Drawing.Point(96, 186);
			this.Login_Bt.Name = "Login_Bt";
			this.Login_Bt.Size = new System.Drawing.Size(85, 30);
			this.Login_Bt.TabIndex = 4;
			this.Login_Bt.Text = "登录";
			this.Login_Bt.UseVisualStyleBackColor = true;
			this.Login_Bt.Click += new System.EventHandler(this.Login_Bt_Click);
			// 
			// Exit_Bt
			// 
			this.Exit_Bt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Exit_Bt.Location = new System.Drawing.Point(218, 186);
			this.Exit_Bt.Name = "Exit_Bt";
			this.Exit_Bt.Size = new System.Drawing.Size(85, 30);
			this.Exit_Bt.TabIndex = 5;
			this.Exit_Bt.Text = "退出";
			this.Exit_Bt.UseVisualStyleBackColor = true;
			this.Exit_Bt.Click += new System.EventHandler(this.Exit_Bt_Click);
			// 
			// Login
			// 
			this.AcceptButton = this.Login_Bt;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.CancelButton = this.Exit_Bt;
			this.ClientSize = new System.Drawing.Size(409, 266);
			this.Controls.Add(this.Exit_Bt);
			this.Controls.Add(this.Login_Bt);
			this.Controls.Add(this.Pwd_Textbox);
			this.Controls.Add(this.Num_Textbox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(427, 313);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(427, 313);
			this.Name = "Login";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "登录";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Num_Textbox;
		private System.Windows.Forms.TextBox Pwd_Textbox;
		private System.Windows.Forms.Button Login_Bt;
		private System.Windows.Forms.Button Exit_Bt;
	}
}