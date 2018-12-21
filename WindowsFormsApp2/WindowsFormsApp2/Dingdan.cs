using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Dingdan : Form
    {
        DataRow dr;
        bool seller = true;
        public Dingdan(DataRow data,bool a)
        {
            InitializeComponent();
            this.dr = data;
            seller = a;
           if(!seller) button1.Text = "确认收货";
        }

        private void Dingdan_Load(object sender, EventArgs e)
        {
            if (dr["tPingjia"].ToString() != "") { label7.Show(); textBox4.Show();
                button1.Hide();button5.Hide();button3.Hide(); textBox4.Text = dr["tPingjia"].ToString(); }
            else { label7.Hide();textBox4.Hide();button3.Hide(); }
            if (seller)
            {
                button3.Hide();button5.Hide();
                byte[] imagebytes = (byte[])dr["tPicture"];
                MemoryStream ms = new MemoryStream(imagebytes);
                Bitmap bt = new Bitmap(ms);
                pictureBox1.Image = bt;
                spname.Text = dr["tName"].ToString();
                count.Text = dr["count"].ToString();
                price.Text = dr["tMoney"].ToString();
                textBox2.Text = dr["taddress"].ToString();
                textBox1.Text = dr["Finish"].ToString() + " " + dr["fahuo"].ToString() + " " + dr["tuihuo"].ToString();
                if (dr["tuihuo"].ToString() == "申请退货")
                {
                    button1.Text = "确定退货";
                }
                else if (dr["fahuo"].ToString() == "卖家已发货") { button1.Enabled = false; button1.Text = "已经发货"; }
                else if (dr["tuihuo"].ToString().Trim() == "退货成功") { button1.Hide(); }
                textBox3.Text = dr["Liuyan"].ToString();
            }
            else
            {
                byte[] imagebytes = (byte[])dr["tPicture"];
                MemoryStream ms = new MemoryStream(imagebytes);
                Bitmap bt = new Bitmap(ms);
                pictureBox1.Image = bt;
                spname.Text = dr["tName"].ToString();
                count.Text = dr["count"].ToString();
                price.Text = dr["tMoney"].ToString();
                textBox2.Text = dr["taddress"].ToString();
                textBox1.Text = dr["Finish"].ToString() + " " + dr["fahuo"].ToString() + " " + dr["tuihuo"].ToString();
                string s = dr["Finish"].ToString();
                if (dr["Finish"].ToString() == "交易已完成" && dr["tPingjia"].ToString() == "") { button3.Show(); button1.Hide(); button5.Hide(); }
                else if (dr["tuihuo"].ToString() != "申请退货") { button1.Text = "确认收货"; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dr["Finish"].ToString() == "交易已完成")
            {
                DialogResult dialogResult = MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) SqlUtil.sqlins("update TradeInfo set sellerShow=0 where id="
                               + dr["id"]);
            }
            else { MessageBox.Show("交易未完成不能删除"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = button1.Text;
            if (button1.Text == "确定发货")
            {
                SqlUtil.sqlins("update TradeInfo set fahuo='卖家已发货' where id="
                                        + dr["id"]);               
                MessageBox.Show("发货成功");
            }
            else if(button1.Text=="确定退货")
            {
                SqlUtil.sqlins("update TradeInfo set tuihuo='退货成功',Finish='交易已完成' where id="
                                           + dr["id"]);
                SqlUtil.sqlins("update UserInfo set Money=Money+'" + dr["tMoney"] + "' where UserAc ='" + dr["buyerAc"] + "'");
                MessageBox.Show("确认退货成功");
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            if (button1.Text == "确认收货") {          
                SqlUtil.sqlins("update UserInfo set Money=Money+'" + dr["tMoney"] + "' where UserAc ='" + dr["sellerAc"] + "'");
                SqlUtil.sqlins("update TradeInfo set Finish='交易已完成' where id='"+dr["id"]+"'");
                MessageBox.Show("收货成功");
                this.Close();
                this.DialogResult = DialogResult.OK;              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (seller)
            {
                ChangeInfo info = new ChangeInfo(dr["buyerAc"].ToString(), "1");
                info.Show();
            }
            else {
                ChangeInfo info = new ChangeInfo(dr["sellerAc"].ToString(), "1");
                info.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定申请退货吗？", "提示", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) SqlUtil.sqlins("update TradeInfo set tuihuo='申请退货' where id="
                               + dr["id"]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "评价")
            {
                label6.Text = "填写评价"; panel1.Hide(); button4.Hide();
                textBox4.Hide(); label7.Hide(); button1.Hide(); button5.Hide();
                textBox3.Enabled = true; button3.Text = "确定评价";
            }
            else
            {
                SqlUtil.sqlins("update TradeInfo set tPingjia='"+textBox3.Text+"' where id="
                               + dr["id"]);
                MessageBox.Show("评价成功");
                this.Controls.Clear();
                InitializeComponent();
                Dingdan_Load(null,null);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
