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
    public partial class manager : Form
    {
        public manager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SqlUtil.Datas("select * from manage where mAc='" + textBox1.Text + "' and mPw='" + textBox2.Text + "'").Rows.Count != 0)
            {
                MessageBox.Show("登陆成功");
                MaForm mf = new MaForm(textBox1.Text, textBox2.Text);
                mf.Show(); this.Close();
            }
            else MessageBox.Show("没有该数据库管理员");
        }

        private void manager_Load(object sender, EventArgs e)
        {

        }
    }
}
