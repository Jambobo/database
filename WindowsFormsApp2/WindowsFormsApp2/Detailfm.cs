using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Detailfm : Form
    {   DataRow dr;
       
        public Detailfm(DataRow dr,int flag) {
            
            InitializeComponent();
            this.dr = dr;
            if (flag == 1)
            {
                button3.Hide();
                button2.Hide();
            }
            else
                button1.Hide();
        }
       
        public Detailfm()
        {
            InitializeComponent();
        }       

        private void detail_Load(object sender, EventArgs e)
        {
            label1.Focus();
            spname.Enabled = false;
            price.Enabled = false;
            count.Enabled = false;
            miaoshu.Enabled = false;
            spname.Text=dr["tName"].ToString();          
            byte[] imagebytes = (byte[])dr["tPicture"];           
            miaoshu.Text=dr["tIntroduce"].ToString();
            price.Text=dr["price"].ToString();
            count.Text = dr["tCount"].ToString() + "/" + dr["sellCount"].ToString();
            textBox1.Text = SqlUtil.Datas("select Username from UserInfo where UserAc='" + dr["userac"] + "'").Rows[0][0].ToString(); 
            richTextBox1.Text = dr["pingjia"].ToString().Replace("#","\r\n");
            try
            {
                MemoryStream ms = new MemoryStream(imagebytes);
                Bitmap bt = new Bitmap(ms);
                pictureBox1.Image = bt;
            }
            catch { pictureBox1.Image = Image.FromFile("D:\\default.jpg"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddThing addThing = new AddThing(dr);
            addThing.ShowDialog();
            if (addThing.DialogResult == DialogResult.OK)
            {
                updat();
            }
            
        }
        private void updat() {
            DataRow dr1 = SqlUtil.Datas("select * from ThingInfo where id=" + dr["id"]).Rows[0];
            spname.Text = dr1["tName"].ToString();
            byte[] imagebytes = (byte[])dr1["tPicture"];
            miaoshu.Text = dr1["tIntroduce"].ToString();
            price.Text = dr1["price"].ToString();
            count.Text = dr1["tCount"].ToString() + "/" + dr1["sellCount"].ToString();
            try
            {
                MemoryStream ms = new MemoryStream(imagebytes);
                Bitmap bt = new Bitmap(ms);
                pictureBox1.Image = bt;
            }
            catch { }
        }
        private void detail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dr["userac"].ToString() != MarketForm.userac)
            {
                QueRenFm fm = new QueRenFm(dr,0);
                fm.ShowDialog();
                if (fm.DialogResult == DialogResult.OK)
                updat();
            }
            else
            {
                MessageBox.Show("这个是你的商品，你不能购买");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QueRenFm fm = new QueRenFm(dr, 1);
            fm.ShowDialog();
            if (fm.DialogResult == DialogResult.No)
                this.Close();
        }
    }
}
