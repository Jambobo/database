using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddThing : Form
    {
        byte[] imageBytes;
        string filePath;
        DataRow dr;
        bool update=false;
        public AddThing(DataRow dr)
        {
            InitializeComponent();
            button1.Text = "确定修改";
            this.dr = dr;
            spname.Text = dr["tName"].ToString();
            byte[] imgbytes = (byte[])dr["tPicture"];
            miaoshu.Text = dr["tIntroduce"].ToString();
            price.Text = dr["price"].ToString();
            count.Text = dr["tCount"].ToString();
            comboBox1.Text = dr["fenlei"].ToString();
            try
            {
                MemoryStream ms = new MemoryStream(imgbytes);
                Bitmap bt = new Bitmap(ms);
                pictureBox1.Image = bt;
            }
            catch { }
            update = true;
            this.Text = "修改商品";
        }
        public AddThing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs;
            if (pictureBox1.Image == Image.FromFile("img.jpg"))
            { fs = new FileStream("img.jpg", FileMode.Open); }
            else
            {
                pictureBox1.Image.Save("thing1.jpg");
                fs = new FileStream("thing1.jpg", FileMode.Open);
            }
            imageBytes = new byte[fs.Length];
            BinaryReader br = new BinaryReader(fs);
            imageBytes = br.ReadBytes(Convert.ToInt32(fs.Length));
            fs.Close();
            if (!update)
            {
                string insql = "insert into ThingInfo values ('" + MarketForm.userac + "','" + spname.Text + "','" 
                    + miaoshu.Text + "',@image,'" + DateTime.Now.ToString()
                    + "'," + count.Text + "," + 0 + ",'" + price.Text +"','" +comboBox1.Text+"','')";
                int n = SqlUtil.sqlcmd(insql, imageBytes);
                if (n > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("添加成功");
                    this.Close();
                    this.Dispose();                 
                }
                else
                {
                    MessageBox.Show("添加失败，请检查数据再试一次");
                }
            }
            else {
                string upsql = "update ThingInfo set userac='" + MarketForm.userac + "',tName='" + spname.Text 
               + "',tIntroduce='" + miaoshu.Text + "',tPicture=@image, addTime='" + DateTime.Now.ToString()
               + "',tCount=" + count.Text + ",price='" + price.Text + "', fenlei='"+fenlei(comboBox1.Text)+"' where id =" + dr["id"];
                int n = SqlUtil.sqlcmd(upsql,imageBytes);
                if (n > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("更新成功");
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("更新失败，请检查数据再试一次");
                }
            }           
        }
        private string fenlei(string a) {
            if (a == "书籍资料") return "书籍资料";
            if (a == "数码产品") return "数码产品";
            return "二手杂物";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                           
                pictureBox1.Image = Image.FromFile(filePath);                         
            }
        }

        private void AddThing_Load(object sender, EventArgs e)
        {
            if(!update)
            pictureBox1.Image = Image.FromFile("img.jpg");
            label1.Focus();
        }

    }
}
