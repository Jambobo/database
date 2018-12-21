namespace WindowsFormsApp2
{
    partial class MarketForm
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
            this.personCenter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.homepage = new System.Windows.Forms.Button();
            this.buyerpage = new System.Windows.Forms.Button();
            this.sellerpage = new System.Windows.Forms.Button();
            this.gouwuche = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // personCenter
            // 
            this.personCenter.BackColor = System.Drawing.Color.Transparent;
            this.personCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personCenter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.personCenter.Location = new System.Drawing.Point(562, 19);
            this.personCenter.Name = "personCenter";
            this.personCenter.Size = new System.Drawing.Size(125, 94);
            this.personCenter.TabIndex = 4;
            this.personCenter.Text = " 个人信息";
            this.personCenter.UseVisualStyleBackColor = false;
            this.personCenter.Click += new System.EventHandler(this.personCenter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(79, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 170);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button3.Location = new System.Drawing.Point(261, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 88);
            this.button3.TabIndex = 2;
            this.button3.Text = "数码产品";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button2.Location = new System.Drawing.Point(139, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 88);
            this.button2.TabIndex = 1;
            this.button2.Text = "书籍资料";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button1.Location = new System.Drawing.Point(15, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 86);
            this.button1.TabIndex = 1;
            this.button1.Text = "二手杂物";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(35, 212);
            this.panel1.MaximumSize = new System.Drawing.Size(1000, 600);
            this.panel1.MinimumSize = new System.Drawing.Size(500, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 540);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(687, 36);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 46);
            this.button5.TabIndex = 0;
            this.button5.Text = "切换用户";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // homepage
            // 
            this.homepage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homepage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.homepage.Location = new System.Drawing.Point(7, 19);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(133, 94);
            this.homepage.TabIndex = 0;
            this.homepage.Text = "首页";
            this.homepage.UseVisualStyleBackColor = true;
            this.homepage.Click += new System.EventHandler(this.homepage_Click);
            // 
            // buyerpage
            // 
            this.buyerpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buyerpage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.buyerpage.Location = new System.Drawing.Point(144, 19);
            this.buyerpage.Name = "buyerpage";
            this.buyerpage.Size = new System.Drawing.Size(129, 94);
            this.buyerpage.TabIndex = 1;
            this.buyerpage.Text = "购买";
            this.buyerpage.UseVisualStyleBackColor = true;
            this.buyerpage.Click += new System.EventHandler(this.buyerpage_Click);
            // 
            // sellerpage
            // 
            this.sellerpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sellerpage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.sellerpage.Location = new System.Drawing.Point(280, 19);
            this.sellerpage.Name = "sellerpage";
            this.sellerpage.Size = new System.Drawing.Size(145, 94);
            this.sellerpage.TabIndex = 2;
            this.sellerpage.Text = "出售";
            this.sellerpage.UseVisualStyleBackColor = true;
            this.sellerpage.Click += new System.EventHandler(this.sellerpage_Click);
            // 
            // gouwuche
            // 
            this.gouwuche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gouwuche.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.gouwuche.Location = new System.Drawing.Point(431, 19);
            this.gouwuche.Name = "gouwuche";
            this.gouwuche.Size = new System.Drawing.Size(125, 94);
            this.gouwuche.TabIndex = 3;
            this.gouwuche.Text = "购物车";
            this.gouwuche.UseVisualStyleBackColor = true;
            this.gouwuche.Click += new System.EventHandler(this.gouwuche_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MintCream;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(501, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 39);
            this.textBox1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button4.Location = new System.Drawing.Point(734, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 39);
            this.button4.TabIndex = 6;
            this.button4.Text = "搜索";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.gouwuche);
            this.groupBox1.Controls.Add(this.sellerpage);
            this.groupBox1.Controls.Add(this.buyerpage);
            this.groupBox1.Controls.Add(this.homepage);
            this.groupBox1.Controls.Add(this.personCenter);
            this.groupBox1.Location = new System.Drawing.Point(109, 778);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 134);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // MarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.longsky;
            this.ClientSize = new System.Drawing.Size(954, 917);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1700, 1200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 756);
            this.Name = "MarketForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarketForm";
            this.Load += new System.EventHandler(this.Market_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button personCenter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button homepage;
        private System.Windows.Forms.Button buyerpage;
        private System.Windows.Forms.Button sellerpage;
        private System.Windows.Forms.Button gouwuche;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}