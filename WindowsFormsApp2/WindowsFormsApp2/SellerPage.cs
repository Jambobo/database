using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class SellerPage : Form
    {
        DataTable dt;
        public SellerPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "确定")
            {
                AddThing add = new AddThing();
                add.ShowDialog();
                if (add.DialogResult == DialogResult.OK)
                    SellerPage_Load(this, null);
            }
            else
            {
                if (listView1.CheckedItems.Count != 0)
                {
                    DialogResult dr = new DialogResult(); int a = 0;
                    foreach (ListViewItem lvi in listView1.CheckedItems)
                    {

                        if (SqlUtil.Datas("select  * from TradeInfo where tid='" + dt.Rows[listView1.Items.IndexOf(lvi)]["id"].ToString() + "'").Rows.Count != 0)
                        {
                            if (SqlUtil.Datas("select  * from TradeInfo where tid='" + dt.Rows[listView1.Items.IndexOf(lvi)]["id"].ToString() + "'").Rows[0]["Finish"].ToString() == "交易已完成")
                            {
                                SqlUtil.Datas("delete from TradeInfo where tid='" + dt.Rows[listView1.Items.IndexOf(lvi)]["id"].ToString() + "'");
                                SqlUtil.Datas("delete from ThingInfo where id=" + dt.Rows[listView1.Items.IndexOf(lvi)]["id"]);
                                a++;
                            }
                            else { }
                        }
                        else { SqlUtil.Datas("delete from ThingInfo where id=" + dt.Rows[listView1.Items.IndexOf(lvi)]["id"]); a++; }
                    }

                    dr = MessageBox.Show("成功删除" + a + "个，失败" + (listView1.CheckedItems.Count - a) + "个(有未完成的订单，不能删除)");
                    if (dr == DialogResult.OK)
                        SellerPage_Load(this, null);
                    button1.Text = "添加物品";
                    label1.Text = "你的商品";
                }
                else { MessageBox.Show("未选择任何项"); }
    
            }
        }

        private void SellerPage_Load(object sender, EventArgs e)
        {
            
            button4.Hide(); button5.Hide(); button6.Hide();
            listView1.CheckBoxes = false;
            label1.Text = "你的商品"; button1.Show(); button2.Show();
            if (listView1 != null) listView1.Clear();
            listView1.Columns.Add("商品名", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("描述", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("价格", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("已售", listView1.Width / 4-10, HorizontalAlignment.Center);
            if (dt != null) dt.Clear();
            ListViewItem listViewItem;
            int i = 0;
            MemoryStream ms;
            byte[] imagebytes;
            dt = SqlUtil.Datas("select * from ThingInfo where userac = '" + MarketForm.userac + "'");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(80, 100);
            foreach (DataRow row in dt.Rows)
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = row["tName"].ToString();
                listViewItem.ImageIndex = i++;
                imagebytes = (byte[])row["tPicture"];
                try
                {
                    ms = new MemoryStream(imagebytes);
                    Bitmap bt = new Bitmap(ms);
                    imageList.Images.Add(bt);
                }
                catch { imageList.Images.Add(Image.FromFile("D:\\default.jpg")); }

                listView1.FullRowSelect = true;
                listViewItem.SubItems.Add(row["tIntroduce"].ToString());
                listViewItem.SubItems.Add("¥" + row["price"].ToString());
                listViewItem.SubItems.Add(row["sellCount"].ToString());
                listView1.Items.Add(listViewItem);
            }
            listView1.SmallImageList = imageList;
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;

            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "你的商品")
            {
                Detailfm detail = new Detailfm(dt.Rows[listView1.Items.IndexOf(listView1.SelectedItems[0])], 1);
                detail.ShowDialog();
                if (detail.DialogResult == DialogResult.OK)
                { SellerPage_Load(this, null); button3.Text = "查看交易信息"; }
            }
            if (label1.Text == "你的销售信息" && button4.Text == "删除订单")
            {
                Dingdan dindan = new Dingdan(dt.Rows[listView1.Items.IndexOf(listView1.SelectedItems[0])], true);
                dindan.ShowDialog();
                if (dindan.DialogResult == DialogResult.OK)
                    button3_Click(this, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.CheckBoxes = true;
            label1.Text = "选择要删除的商品";
            button1.Text = "确定";
            button6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "查看交易信息")
            {
                button3.Text = "查看所有商品";
                label1.Text = "你的销售信息";
                button4.Show();
                button1.Hide();
                button2.Hide(); button6.Show();
                listView1.Clear();
                listView1.Columns.Add("商品名", listView1.Width / 4 - 10, HorizontalAlignment.Center);
                listView1.Columns.Add("买家留言", listView1.Width / 4, HorizontalAlignment.Center);
                listView1.Columns.Add("总金额", listView1.Width / 4, HorizontalAlignment.Center);
                listView1.Columns.Add("交易状态", listView1.Width / 4 - 10, HorizontalAlignment.Center);
                if (dt != null) dt.Clear();
                dt = SqlUtil.Datas("select * from TradeInfo,ThingInfo where TradeInfo.tid=ThingInfo.id and sellerAc = '" + MarketForm.userac + "' and sellerShow = 1");
                ImageList imageList = new ImageList();
                imageList.ImageSize = new Size(80, 100);
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = row["tName"].ToString();
                    listViewItem.ImageIndex = i++;
                    byte[] imagebytes = (byte[])row["tPicture"];
                    listView1.FullRowSelect = true;
                    listViewItem.SubItems.Add(row["Liuyan"].ToString());
                    listViewItem.SubItems.Add("¥" + row["tMoney"].ToString());
                    listViewItem.SubItems.Add(row["Finish"].ToString());
                    MemoryStream ms = new MemoryStream(imagebytes);
                    Bitmap bt = new Bitmap(ms);
                    imageList.Images.Add(bt);
                    listView1.Items.Add(listViewItem);
                }
                listView1.SmallImageList = imageList;
            }
            else { SellerPage_Load(null, null); button3.Text = "查看交易信息"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text != "确定")
            {
                button4.Text = "确定";
                listView1.CheckBoxes = true;
            }
            else
            {
                if (listView1.CheckedItems.Count != 0)
                {
                    foreach (ListViewItem lvi in listView1.CheckedItems)
                    {
                        SqlUtil.sqlins("update TradeInfo set sellerShow=0 where id="
                            + dt.Rows[listView1.Items.IndexOf(lvi)]["id"]);
                    }
                    MessageBox.Show("删除成功");
                    button4.Text = "删除订单";
                    listView1.CheckBoxes = false;
                    button3_Click(null, null);
                }
                else MessageBox.Show("没有选中任何项");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button4.Text == "确定")
            {
                button4.Text = "删除订单";
                listView1.CheckBoxes = false;
            }
            else { SellerPage_Load(null, null); button3.Text = "查看交易信息"; }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            Point curPos = this.listView1.PointToClient(Control.MousePosition);
            ListViewItem lvwItem = this.listView1.GetItemAt(curPos.X, curPos.Y);


            if (lvwItem != null)
            {
                lvwItem.Checked = !lvwItem.Checked;
                listView1.Refresh();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

       
    }
}
