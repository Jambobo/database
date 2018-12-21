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
    public partial class BuyerPage : Form
    {
        DataTable dt;
        string search="";
        string fenlei_str="";
        public BuyerPage(string search)
        {
            InitializeComponent();
            this.search = search;
        }
        public BuyerPage(string str,string a)
        {
            InitializeComponent();
            fenlei_str = str;
        }
        public BuyerPage()
        {
            InitializeComponent();           
        }

        private void TradeForm_Load(object sender, EventArgs e)
        {
           
            button2.Hide();button3.Hide();button4.Hide();
            if (search=="")
                if(fenlei_str=="")
                    dt = SqlUtil.Datas("select * from ThingInfo where tCount>0");
                else
                {
                    dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and fenlei='"+fenlei_str+"'");
                }
            else
                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%"+search+"%'");
            ThingInfo();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (label2.Text == "所有商品")
            {
                Detailfm detail = new Detailfm(dt.Rows[listView1.Items.IndexOf(listView1.SelectedItems[0])], 0);
                detail.ShowDialog();
                if (detail.DialogResult == DialogResult.OK)
                    comboBox1_SelectedIndexChanged(this, null);
            }
            if (label2.Text == "你的购买信息")
            {
                if (listView1.CheckBoxes == false)
                {
                    Dingdan dindan = new Dingdan(dt.Rows[listView1.Items.IndexOf(listView1.SelectedItems[0])], false);
                    dindan.ShowDialog();
                    if (dindan.DialogResult == DialogResult.OK)
                        button1_Click(null, null);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Show();
            button3.Show();button4.Show();
            listView1.CheckBoxes = false;
            label1.Text = "查看：";
            comboBox1.Text = "所有";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("所有");
            comboBox1.Items.Add("交易已完成");
            comboBox1.Items.Add("交易未完成");
            label2.Text = "你的购买信息";
            if (dt != null) dt.Clear();
            dt = SqlUtil.Datas("select * from TradeInfo,ThingInfo where TradeInfo.tid=ThingInfo.id and buyerAc = '" + MarketForm.userac + "' and buyerShow = 1");
            buyInfo();
        }
        private void ThingInfo() {
            listView1.Clear();
            listView1.Columns.Add("商品名", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("描述", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("价格", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("已售", listView1.Width / 4 - 15, HorizontalAlignment.Center);          
            ListViewItem listViewItem;
            int i = 0;
            MemoryStream ms;
            byte[] imagebytes;          
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(80, 100);
            foreach (DataRow row in dt.Rows)
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = row["tName"].ToString();
                listViewItem.ImageIndex = i++;
                imagebytes = (byte[])row["tPicture"];
                listView1.FullRowSelect = true;
                listViewItem.SubItems.Add(row["tIntroduce"].ToString());
                listViewItem.SubItems.Add("¥" + row["price"].ToString());
                listViewItem.SubItems.Add(row["sellCount"].ToString());
                ms = new MemoryStream(imagebytes);
                Bitmap bt = new Bitmap(ms);
                imageList.Images.Add(bt);
                listView1.Items.Add(listViewItem);
            }
            listView1.SmallImageList = imageList;
        }
        private void buyInfo() {
           
            listView1.Clear();
            
            listView1.Columns.Add("商品名", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("备注", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("总金额", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("交易状态", listView1.Width / 4 - 3, HorizontalAlignment.Center);
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
        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;

            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (label1.Text != "排序方式：")
            {
                switch (comboBox1.Text)
                {
                    case "所有":
                        {
                            if (dt != null) dt.Clear();
                            dt = SqlUtil.Datas("select * from TradeInfo,ThingInfo where TradeInfo.tid=ThingInfo.id and buyerAc = '" + MarketForm.userac + "' and buyerShow = 1"); buyInfo(); break;
                        }
                    case "交易已完成":
                        {
                            if (dt != null) dt.Clear();
                            dt = SqlUtil.Datas("select * from TradeInfo,ThingInfo where TradeInfo.tid=ThingInfo.id and Finish='已完成' and buyerAc = '" + MarketForm.userac + "' and buyerShow = 1"); buyInfo(); break;
                        }
                    case "交易未完成":
                        {
                            if (dt != null) dt.Clear();
                            dt = SqlUtil.Datas("select * from TradeInfo,ThingInfo where TradeInfo.tid=ThingInfo.id and Finish='未完成' and buyerAc = '" + MarketForm.userac + "' and buyerShow = 1"); buyInfo(); break;
                        }
                }
            }
            else
            {
                switch (comboBox1.Text)
                {
                    case "默认":
                        {
                            if (dt != null) dt.Clear();
                            if(search=="")
                            dt = SqlUtil.Datas("select * from ThingInfo where tCount>0");
                            else
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%" + search + "%'");
                            ThingInfo(); break;
                        }
                    case "价格从高到底":
                        {                           
                            dt.Clear();
                            if (search == "")
                            {
                                if (fenlei_str == "")
                                    dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 order by price desc");
                                else
                                    dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and fenlei='" + fenlei_str + "' order by price desc");
                            }
                            else
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%" + search + "%' order by price desc");
                            ThingInfo(); break;
                        }
                    case "价格从低到高":
                        {
                            dt.Clear();
                            if (search == "")
                            {
                                if (fenlei_str == "")
                                    dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 order by price");
                                else
                                    dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and fenlei='"+fenlei_str+"' order by price");
                            }
                            else
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%" + search + "%' order by price");
                            ThingInfo(); break;                           
                        }
                    case "销量":
                        {
                            dt.Clear();
                            if (search == "")
                            {
                                if (fenlei_str == "")
                                    dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 order by sellCount desc");
                                else dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and fenlei='"+fenlei_str+"' order by sellCount desc");
                            }
                            else
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%" + search + "%' order by sellCount desc");
                            ThingInfo(); break;
                        }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != "确定")
            {
                button2.Text = "确定";
                listView1.CheckBoxes = true;
            }
            else
            {
                foreach (ListViewItem lvi in listView1.CheckedItems)
                {
                    SqlUtil.sqlins("update TradeInfo set buyerShow=0 where id="
                        + dt.Rows[listView1.Items.IndexOf(lvi)]["id"]);
                }
                if (listView1.CheckedItems.Count > 0)
                { MessageBox.Show("删除成功"); button1_Click(null, null); button2.Text = "删除订单";
                    listView1.CheckBoxes = false;
                }
                else MessageBox.Show("未选择任何项");                          
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text != "多选收货")
            {
               
                foreach (ListViewItem lvi in listView1.CheckedItems)
                {
                    SqlUtil.sqlins("update TradeInfo set Finish='交易已完成' where id="
                        + dt.Rows[listView1.Items.IndexOf(lvi)]["id"]);
                    SqlUtil.sqlins("update UserInfo set Money=Money+"+ dt.Rows[listView1.Items.IndexOf(lvi)]["tMoney"]+" where UserAc='"+ dt.Rows[listView1.Items.IndexOf(lvi)]["sellerAc"]+"'");
                }
                if (listView1.CheckedItems.Count > 0)
                { MessageBox.Show("收货成功"); button1_Click(null, null); button3.Text = "多选收货"; listView1.CheckBoxes = false; }
                else MessageBox.Show("未选择任何项");                             
            }
            else{ listView1.CheckBoxes = true;button3.Text = "确定收货"; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;

            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (button2.Text == "确定" || button3.Text == "确定收货") { button1_Click(null, null); button2.Text = "删除订单";button3.Text = "多选收货"; }
            else TradeForm_Load(null,null);
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
    }
}
