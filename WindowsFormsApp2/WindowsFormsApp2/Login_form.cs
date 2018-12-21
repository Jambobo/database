using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp2
{


    public partial class Login_form : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        static public string ac;
        DataTable dt;
        public Login_form()
        {
            InitializeComponent();            
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            dt=SqlUtil.Datas("select * from savedpw");
            if (dt.Rows[0]["password"].ToString() != "")
            {
                account.ForeColor = Color.Black;
                account.Text = dt.Rows[0]["accout"].ToString();
                password.Text = dt.Rows[0]["password"].ToString();
                password.UseSystemPasswordChar = true;
                password.ForeColor = Color.Black;
                checkBox1.Checked = true;
            }
            else {checkBox1.Checked = false; }
        }


        private void pwMouseClick(object sender, MouseEventArgs e)
        {
            if (password.Text == "密码") {
                password.ForeColor = Color.Black;
                password.Text = "";
                password.UseSystemPasswordChar = true;         
                
            }
        }

        private void AcMouseClick(object sender, MouseEventArgs e)
        {
            if (account.Text == "账号") { 
            account.Text = "";
            account.ForeColor = Color.Black;
            }
        }

        private void account_Leave(object sender, EventArgs e)
        {
            if (account.Text == "") { 
            account.Text = "账号";
            account.ForeColor = Color.Silver;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.UseSystemPasswordChar = false;
                password.Text = "密码";
                password.ForeColor = Color.Silver;
            }
        }

        private void Sign_Click(object sender, EventArgs e)
        {       
            ZhuceForm zhuceForm = new ZhuceForm();
            zhuceForm.ShowDialog();
            if (zhuceForm.DialogResult == DialogResult.OK)
                this.DialogResult = DialogResult.OK;
        }

        private void Login_Click(object sender, EventArgs e)
        {

            dt = SqlUtil.Datas("select * from UserInfo where UserAc='" + account.Text.Trim() + "' and UserPw='" + password.Text.Trim() + "'");
            if (dt.Rows.Count!=0)
            {               
                ac = account.Text.Trim();
                if (checkBox1.Checked) SqlUtil.sqlins("update savedpw set accout='" + account.Text.Trim() + "' ,password='" + password.Text + "' where id=1");
                if (!checkBox1.Checked) { SqlUtil.sqlins("update savedpw set accout='' ,password='' where id=1"); }               
                this.DialogResult = DialogResult.OK; this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }          
        }

        private void Moused(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Login_form_Activated(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void FormClose(object sender, EventArgs e)
        {
            if (!checkBox1.Checked) File.Delete(@"d:\acpw.xml");
            this.Close();
            
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            account.Text = "";
            password.Text = "";
            account.Focus();
        }

        private void btn_Click(object sender, EventArgs e)
        {         
            manager manager1 = new manager();
            manager1.Show();
            
        }
    }
}
