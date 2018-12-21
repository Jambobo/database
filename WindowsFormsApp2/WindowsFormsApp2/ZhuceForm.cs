using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ZhuceForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private bool Exist=false;
        public ZhuceForm()
        {
            InitializeComponent();
        }

        private void zhuce_ac_click(object sender, EventArgs e)
        {
            if (zhuce_account.Text == "账号")
            {
                zhuce_account.Text = "";
                zhuce_account.ForeColor = Color.Black;
            }
        }

        private void zhuce_ac_Leave(object sender, EventArgs e)
        {
            if (zhuce_account.Text == "")
            {
                zhuce_account.Text = "账号";
                zhuce_account.ForeColor = Color.Silver;
            }
        }

        private void zhuce_pw_click(object sender, EventArgs e)
        {
            if (zhuce_password.Text == "密码")
            {               
                zhuce_password.Text = "";
                zhuce_password.ForeColor = Color.Black;
            }
        }

        private void zhuce_pw_leave(object sender, EventArgs e)
        {
            if (zhuce_password.Text == "")
            {               
                zhuce_password.Text = "密码";
                zhuce_password.ForeColor = Color.Silver;
            }
        }
        private void nickname_Click(object sender, EventArgs e)
        {
            if (nickname.Text == "昵称")
            {
                nickname.Text = "";
                nickname.ForeColor = Color.Black;
            }
        }
        private void nickname_Leave(object sender, EventArgs e)
        {
            if (nickname.Text == "昵称")
            {
                nickname.Text = "";
                nickname.ForeColor = Color.Silver;
            }
        }

        private void zhuce_click(object sender, EventArgs e)
        {
            if (zhuce_account.Text == "账号" || zhuce_account.Text == "" || zhuce_password.Text == "密码" || zhuce_password.Text == "" || nickname.Text == "昵称" || nickname.Text == "")
                MessageBox.Show("以上内容不能留空");
            else
            {
                DataTable dt = SqlUtil.Datas("select * from UserInfo");
                foreach (DataRow row in dt.Rows)
                {
                    if (row[0].ToString() == zhuce_account.Text)
                    {
                        MessageBox.Show("账号已存在!");
                        Exist = true;
                    }
                }
                if (!Exist)
                {
                    Login_form.ac = zhuce_account.Text.Trim();
                    SqlUtil.sqlins("insert into UserInfo(UserAc,Username,UserPw) values('" + zhuce_account.Text.Trim() + "','" + nickname.Text.Trim() + "','" + zhuce_password.Text.Trim() + "')");
                    SqlUtil.sqlins("update savedpw set account='" + zhuce_account.Text.Trim() + "' ,password='" + zhuce_password.Text + "' where id=1");    
                    MessageBox.Show("注册成功");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void ZhuceForm_Load(object sender, EventArgs e)
        {

        }

        private void ZhuceForm_Activated(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void ZhuceForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_form login_Form = new Login_form();
            login_Form.Show();
            this.Close();
        }

        
    }
}
