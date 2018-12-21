using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ChangePW : Form
    {
        public ChangePW()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pw = SqlUtil.Datas("select * from Login where UserAc ='"+MarketForm.userac+"'").Rows[0]["UserPw"].ToString();
            if (textBox1.Text == pw)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlUtil.sqlins("update Login set UserPw='" + textBox2.Text + "' where UserAc = '" + MarketForm.userac + "'");
                    MessageBox.Show("修改成功");
                }
                else MessageBox.Show("两次密码不一致");
            }
                
        }
    }
}
