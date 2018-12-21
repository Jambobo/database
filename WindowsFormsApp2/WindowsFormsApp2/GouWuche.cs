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
    public partial class GouWuche : Form
    {
        DataTable dt;
        public GouWuche()
        {         
            InitializeComponent();
        }

        private void GouWuche_Load(object sender, EventArgs e)
        {
            if (listView1 != null) listView1.Clear();
            listView1.Columns.Add("商品名", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("买家留言", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("总价", listView1.Width / 4, HorizontalAlignment.Center);
            listView1.Columns.Add("数量", listView1.Width / 4 - 20, HorizontalAlignment.Center);
            if (dt != null) dt.Clear();
            ListViewItem listViewItem;
            int i = 0;
            MemoryStream ms;
            byte[] imagebytes;
            dt = SqlUtil.Datas("select * from Gouwuche,ThingInfo where buyerAc = '" + MarketForm.userac + "' and Gouwuche.tid=ThingInfo.id");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(80, 100);
            foreach (DataRow row in dt.Rows)
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = row["tName"].ToString();
                listViewItem.ImageIndex = i++;
                imagebytes = (byte[])row["tPicture"];
                listView1.FullRowSelect = true;
                listViewItem.SubItems.Add(row["Liuyan"].ToString());
                listViewItem.SubItems.Add("¥" + row["tMoney"].ToString());
                listViewItem.SubItems.Add(row["count"].ToString());
                ms = new MemoryStream(imagebytes);
                Bitmap bt = new Bitmap(ms);
                imageList.Images.Add(bt);
                listView1.Items.Add(listViewItem);
            }
            listView1.SmallImageList = imageList;
            listView1.CheckBoxes = true;
        }
        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;

            e.NewWidth = this.listView1.Columns[e.ColumnIndex].Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {   if (listView1.CheckedItems.Count != 0)
            {
                foreach (ListViewItem lvi in listView1.CheckedItems)
                {                                      
                    SqlUtil.sqlins("delete from Gouwuche where buyerAc = '" + MarketForm.userac + "' and id=" + dt.Rows[listView1.Items.IndexOf(lvi)]["id"]);
                }
                MessageBox.Show("删除成功");
                GouWuche_Load(this, null);
            }
            else MessageBox.Show("未选择任何项");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count != 0)
            {
                string fail = ""; string success = "";
                DataRow dataRow = SqlUtil.Datas("select * from UserInfo where UserAc='" + MarketForm.userac + "'").Rows[0];
                foreach (ListViewItem lvi in listView1.CheckedItems)
                {
                    if (float.Parse(dataRow["Money"].ToString()) >= float.Parse(dt.Rows[listView1.Items.IndexOf(lvi)]["tMoney"].ToString()))
                    {
                        string sql = "insert into TradeInfo values('" + dt.Rows[listView1.Items.IndexOf(lvi)]["userac"] + "','" + MarketForm.userac + "','" + dt.Rows[listView1.Items.IndexOf(lvi)]["tid"] + "','"
                               + dt.Rows[listView1.Items.IndexOf(lvi)]["taddress"] + "','" + DateTime.Now.ToString() + "','','','"
                               + dt.Rows[listView1.Items.IndexOf(lvi)]["tMoney"] + "','" + dt.Rows[listView1.Items.IndexOf(lvi)]["Liuyan"] + "','交易未完成'," + dt.Rows[listView1.Items.IndexOf(lvi)]["count"] + ",1,1,'','卖家未发货')";
                        int n = SqlUtil.sqlins(sql);
                        if (n != 0)
                        {

                            SqlUtil.sqlins("update ThingInfo set tCount = " + (int.Parse(dt.Rows[listView1.Items.IndexOf(lvi)]["tCount"].ToString()) - int.Parse(dt.Rows[listView1.Items.IndexOf(lvi)]["count"].ToString()))
                             + ",sellCount =" + (int.Parse(dt.Rows[listView1.Items.IndexOf(lvi)]["sellCount"].ToString()) + int.Parse(dt.Rows[listView1.Items.IndexOf(lvi)]["count"].ToString()))
                             + " where id ='" + dt.Rows[listView1.Items.IndexOf(lvi)]["tid"] + "'");
                            SqlUtil.sqlins("update UserInfo set Money='" + (float.Parse(dataRow["Money"].ToString()) - float.Parse(dt.Rows[listView1.Items.IndexOf(lvi)]["tMoney"].ToString())) + "' where UserAc ='" + dt.Rows[listView1.Items.IndexOf(lvi)]["buyerAc"] + "'");
                            success += dt.Rows[listView1.Items.IndexOf(lvi)]["tName"] + "\n";
                            SqlUtil.sqlins("delete from Gouwuche where buyerAc = '" + MarketForm.userac + "' and id=" + dt.Rows[listView1.Items.IndexOf(lvi)]["id"]);
                            this.DialogResult = DialogResult.OK;
                        }
                        else MessageBox.Show("未知原因购买失败");
                    }
                    else fail += dt.Rows[listView1.Items.IndexOf(lvi)]["tName"] + "\n";
                }
                if (fail == "")
                    MessageBox.Show("成功购买购物车所有物品");
                else
                    MessageBox.Show("成功购买以下物品：\n" + success + "余额不够买以下物品：\n" + fail);
                GouWuche_Load(this, null);
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
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

