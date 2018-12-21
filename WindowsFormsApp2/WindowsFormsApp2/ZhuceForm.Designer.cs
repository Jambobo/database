namespace WindowsFormsApp2
{
    partial class ZhuceForm
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
            this.zhuce_account = new System.Windows.Forms.TextBox();
            this.zhuce_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zhuce_button1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.nickname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // zhuce_account
            // 
            this.zhuce_account.Font = new System.Drawing.Font("宋体", 15F);
            this.zhuce_account.ForeColor = System.Drawing.Color.LightGray;
            this.zhuce_account.Location = new System.Drawing.Point(46, 161);
            this.zhuce_account.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zhuce_account.Name = "zhuce_account";
            this.zhuce_account.Size = new System.Drawing.Size(282, 53);
            this.zhuce_account.TabIndex = 0;
            this.zhuce_account.Text = "账号";
            this.zhuce_account.Click += new System.EventHandler(this.zhuce_ac_click);
            this.zhuce_account.Leave += new System.EventHandler(this.zhuce_ac_Leave);
            // 
            // zhuce_password
            // 
            this.zhuce_password.Font = new System.Drawing.Font("宋体", 15F);
            this.zhuce_password.ForeColor = System.Drawing.Color.Silver;
            this.zhuce_password.Location = new System.Drawing.Point(46, 262);
            this.zhuce_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zhuce_password.Name = "zhuce_password";
            this.zhuce_password.Size = new System.Drawing.Size(282, 53);
            this.zhuce_password.TabIndex = 1;
            this.zhuce_password.Text = "密码";
            this.zhuce_password.Click += new System.EventHandler(this.zhuce_pw_click);
            this.zhuce_password.Leave += new System.EventHandler(this.zhuce_pw_leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 2;
            // 
            // zhuce_button1
            // 
            this.zhuce_button1.BackColor = System.Drawing.Color.Transparent;
            this.zhuce_button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zhuce_button1.Font = new System.Drawing.Font("宋体", 13F);
            this.zhuce_button1.Location = new System.Drawing.Point(64, 496);
            this.zhuce_button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zhuce_button1.Name = "zhuce_button1";
            this.zhuce_button1.Size = new System.Drawing.Size(218, 64);
            this.zhuce_button1.TabIndex = 3;
            this.zhuce_button1.Text = "注册并登录";
            this.zhuce_button1.UseVisualStyleBackColor = false;
            this.zhuce_button1.Click += new System.EventHandler(this.zhuce_click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(218, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nickname
            // 
            this.nickname.Font = new System.Drawing.Font("宋体", 15F);
            this.nickname.ForeColor = System.Drawing.Color.Silver;
            this.nickname.Location = new System.Drawing.Point(46, 365);
            this.nickname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nickname.Multiline = true;
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(282, 55);
            this.nickname.TabIndex = 5;
            this.nickname.Text = "昵称";
            this.nickname.Click += new System.EventHandler(this.nickname_Click);
            this.nickname.Leave += new System.EventHandler(this.nickname_Leave);
            // 
            // ZhuceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.bigsky;
            this.ClientSize = new System.Drawing.Size(384, 623);
            this.Controls.Add(this.nickname);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zhuce_button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zhuce_password);
            this.Controls.Add(this.zhuce_account);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ZhuceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZhuceForm";
            this.Activated += new System.EventHandler(this.ZhuceForm_Activated);
            this.Load += new System.EventHandler(this.ZhuceForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZhuceForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox zhuce_account;
        private System.Windows.Forms.TextBox zhuce_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button zhuce_button1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nickname;
    }
}