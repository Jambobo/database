using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class QueRenFm : Form
    {
        DataRow dr;
        public QueRenFm(DataRow dr,int flag)
        {
            this.dr = dr;
            InitializeComponent();
            if (flag == 1)
            {
                this.Text = "加入至购物车";
                button1.Text = "添加";
            }
        }

        private void QueRenFm_Load(object sender, EventArgs e)
        {
            byte[] imagebytes = (byte[])dr["tPicture"];
            MemoryStream ms = new MemoryStream(imagebytes);
            Bitmap bt = new Bitmap(ms);
            pictureBox1.Image = bt;
            textBox1.Enabled = false;
            textBox1.Text = dr["tName"].ToString();
            textBox2.Text = SqlUtil.Datas("select * from UserInfo where UserAc='" + MarketForm.userac + "'").Rows[0]["UserAddress"].ToString(); ;           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dataRow = SqlUtil.Datas("select * from UserInfo where UserAc='" + MarketForm.userac + "'").Rows[0];
            string monstr = SqlUtil.Datas("select * from UserInfo where UserAc='" + MarketForm.userac + "'").Rows[0]["Money"].ToString();
            float money = float.Parse(monstr==""?"0": monstr);
            if (int.Parse(dr["tCount"].ToString()) >= int.Parse(comboBox1.Text))
            {
                if (money >= (float.Parse(dr["price"].ToString()) * int.Parse(comboBox1.Text)))
                {
                    if (button1.Text != "添加")
                    {
                        string sql = "insert into TradeInfo values('" + dr["userac"] + "','" + MarketForm.userac + "','" + dr["id"] + "','"
                        + textBox2.Text + "','" + DateTime.Now.ToString() + "',null,null,'"
                        + int.Parse(dr["price"].ToString()) * int.Parse(comboBox1.Text) + "','" + richTextBox2.Text + "','交易未完成','" + comboBox1.Text + "',1,1,'','卖家未发货')";
                        int n = SqlUtil.sqlins(sql);
                        if (n != 0)
                        {
                            SqlUtil.sqlins("update ThingInfo set tCount = " + (int.Parse(dr["tCount"].ToString()) - int.Parse(comboBox1.Text))
                                + ",sellCount =" + (int.Parse(dr["sellCount"].ToString()) + int.Parse(comboBox1.Text))
                                + " where id ='" + dr["id"] + "'");
                            SqlUtil.sqlins("update UserInfo set Money='" + (float.Parse(monstr) - float.Parse(dr["price"].ToString()) * int.Parse(comboBox1.Text)) + "' where UserAc ='" + MarketForm.userac + "'");
                            MessageBox.Show("购买成功");
                            this.DialogResult = DialogResult.OK;
                        }
                        else MessageBox.Show("购买失败");
                    }
                }
                else MessageBox.Show("你的余额不足");

                if (button1.Text == "添加")
                {
                    SqlUtil.sqlins("insert into Gouwuche values('" + dr["userac"] + "','" + MarketForm.userac + "','" + dr["id"] + "','"
                              + dataRow["UserAddress"].ToString()
                              + "','" + DateTime.Now.ToString() + "','"
                              + int.Parse(dr["price"].ToString()) * int.Parse(comboBox1.Text) + "','" + richTextBox2.Text
                              + "'," + int.Parse(comboBox1.Text) + ")");
                    MessageBox.Show("添加成功");
                    this.Close();
                    this.DialogResult = DialogResult.No;
                }
            }
            else MessageBox.Show("卖家存货不足");                     
        }

    }
}
