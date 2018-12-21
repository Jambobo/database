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
        public BuyerPage(string search)
        {
            InitializeComponent();
            this.search = search;
        }
        public BuyerPage()
        {
            InitializeComponent();           
        }

        private void TradeForm_Load(object sender, EventArgs e)
        {   if(search=="")     
                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0");
            else
                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%"+search+"%'");
            ThingInfo(); 
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            Detail detail = new Detail(dt.Rows[listView1.Items.IndexOf(listView1.SelectedItems[0])], 0);
            detail.ShowDialog();
            if (detail.DialogResult == DialogResult.OK)
                TradeForm_Load(this, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "查看：";
            comboBox1.Text = "所有";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("所有");
            comboBox1.Items.Add("已完成");
            comboBox1.Items.Add("未完成");
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
            listView1.Columns.Add("已售", listView1.Width / 4 - 20, HorizontalAlignment.Center);          
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
            listView1.Columns.Add("交易状态", listView1.Width / 4 - 20, HorizontalAlignment.Center);
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
                    case "已完成":
                        {
                            if (dt != null) dt.Clear();
                            dt = SqlUtil.Datas("select * from TradeInfo,ThingInfo where TradeInfo.tid=ThingInfo.id and Finish='已完成' and buyerAc = '" + MarketForm.userac + "' and buyerShow = 1"); buyInfo(); break;
                        }
                    case "未完成":
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
                            if (search=="")
                            dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 order by price desc"); 
                            else
                             dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%" + search + "%' order by price desc");
                            ThingInfo(); break;
                        }
                    case "价格从低到高":
                        {
                            dt.Clear();
                            if (search == "")
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 order by price desc");
                            else
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%" + search + "%' order by price");
                            ThingInfo(); break;                           
                        }
                    case "销量":
                        {                          
                            dt.Clear();
                            if (search == "")
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 order by price desc");
                            else
                                dt = SqlUtil.Datas("select * from ThingInfo where tCount>0 and tName like '%" + search + "%' order by sellCount desc");
                            ThingInfo(); break;
                        }
                }
            }
        }
    }
}
