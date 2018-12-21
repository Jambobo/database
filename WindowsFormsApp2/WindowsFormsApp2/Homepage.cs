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

    public partial class Homepage : Form
    {
        DataTable dt1;
        DataTable dt2;
        public Homepage()
        {
            InitializeComponent();
           
        }
      

        private void Homepage_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
            listView2.FullRowSelect = true;
           
            {// listView2:
                listView2.Clear();
                listView2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                ImageList imageList = new ImageList(); ; int i = 0;
                listView2.Columns.Add("商品名", listView2.Width * 1 / 3 - 10, HorizontalAlignment.Center);
                listView2.Columns.Add("描述", listView2.Width * 2 / 3 - 10, HorizontalAlignment.Center);
                imageList.ImageSize = new Size(50, 60);
                dt2 = SqlUtil.Datas("select * from ThingInfo where tCount>0 and (fenlei='二手杂物' and sellCount in (select MAX(sellCount) from ThingInfo where fenlei = '二手杂物'))or(fenlei = '书籍资料'and sellCount in (select MAX(sellCount) from ThingInfo where fenlei = '书籍资料' ))or(fenlei = '数码产品'and sellCount in (select MAX(sellCount) from ThingInfo where fenlei = '数码产品' ))");
                foreach (DataRow row in dt2.Rows)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = row["tName"].ToString();
                    listViewItem.ImageIndex = i++;
                    byte[] imagebytes = (byte[])row["tPicture"];
                    listViewItem.SubItems.Add(row["tIntroduce"].ToString());
                    MemoryStream ms = new MemoryStream(imagebytes);
                    Bitmap bt = new Bitmap(ms);
                    imageList.Images.Add(bt);
                    listView2.Items.Add(listViewItem);
                }
                listView2.SmallImageList = imageList;
                listView2.LargeImageList = imageList;
            }
            
            {//ListView1:
                listView1.Clear();
                listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                ImageList imageList = new ImageList(); ; int i = 0;
                listView1.Columns.Add("商品名", listView1.Width / 3, HorizontalAlignment.Center);
                listView1.Columns.Add("描述", listView1.Width / 3, HorizontalAlignment.Center);
                listView1.Columns.Add("价格", listView1.Width / 3, HorizontalAlignment.Center);
                //listView1.Columns.Add("已售", listView1.Width / 4 - 20, HorizontalAlignment.Center);
                imageList.ImageSize = new Size(70, 80);
                dt1 = SqlUtil.Datas("select top 10 * from ThingInfo where tCount>0 order by addTime desc");
                foreach (DataRow row in dt1.Rows)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = row["tName"].ToString();
                    listViewItem.ImageIndex = i++;
                    byte[] imagebytes = (byte[])row["tPicture"];
                    listViewItem.SubItems.Add(row["tIntroduce"].ToString());
                    listViewItem.SubItems.Add("¥" + row["price"].ToString());
                    listViewItem.SubItems.Add(row["sellCount"].ToString());
                    MemoryStream ms = new MemoryStream(imagebytes);
                    Bitmap bt = new Bitmap(ms);
                    imageList.Images.Add(bt);
                    listView1.Items.Add(listViewItem);
                }
                listView1.SmallImageList = imageList;
                listView1.LargeImageList = imageList;

            }
        }

        private void listView2_Click(object sender, EventArgs e)
        {           
            Detailfm detail = new Detailfm(dt2.Rows[listView2.Items.IndexOf(listView2.SelectedItems[0])], 0);
            detail.ShowDialog();
            if (detail.DialogResult == DialogResult.OK)
                Homepage_Load(null,null);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            Detailfm detail = new Detailfm(dt1.Rows[listView1.Items.IndexOf(listView1.SelectedItems[0])], 0);
            detail.ShowDialog();
            if (detail.DialogResult == DialogResult.OK)
                Homepage_Load(null, null);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    

