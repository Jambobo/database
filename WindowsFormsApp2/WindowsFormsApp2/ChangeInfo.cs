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
    public partial class ChangeInfo : Form
    {
        string account;
        public ChangeInfo(string ac,string a)
        {
            InitializeComponent();
            this.account = ac;
            if (a == "")
            {     
                label7.Text = ac;
            }
            else
            {
                label5.Text="";
                label8.Text = "";
                button1.Hide(); button2.Hide();button3.Hide();
                label7.Text = ""; label6.Text = "";
            }
            
        }

        private void ChangeInfo_Load(object sender, EventArgs e)
        {
            DataRow dataRow= SqlUtil.Datas("select * from UserInfo where UserAc='" + account+"'").Rows[0];
            if(label5.Text!="")   label8.Text = (dataRow["Money"].ToString()==""?"0": dataRow["Money"].ToString());
            textBox1.Text = str(dataRow["Username"].ToString());
            textBox2.Text = str(dataRow["Sex"].ToString());
            textBox3.Text = str(dataRow["Age"].ToString());
            textBox4.Text = str(dataRow["UserAddress"].ToString());
            textBox5.Text = str(dataRow["Jianjie"].ToString());
            textBox6.Text = str(dataRow["PhoneNo"].ToString());
        }
        private string str(string s) {
            string st;
            return st = (s == "" ? "未添加" : s);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "确定")
            {              
                string sql = "update UserInfo set Username='" + textBox1.Text 
                      + "',Age='" + textBox3.Text
                      + "',Sex='" + textBox2.Text + "',UserAddress='" + textBox4.Text + "',Jianjie='" + textBox5.Text
                      + "',PhoneNo='"+textBox6.Text+"' where UserAc='"+account+"'";
                int n = SqlUtil.sqlins(sql);
                if (n != 0) { MessageBox.Show("修改成功"); this.DialogResult=DialogResult.OK;
                    button1.Text = "点击修改";
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                }
                else MessageBox.Show("修改失败，请检查数据后再试一次");
                
            }
            else
            {
                button1.Text = "确定";
                if (textBox1.Text == "未添加") textBox1.Text = "";
                if (textBox2.Text == "未添加") textBox2.Text = "";
                if (textBox3.Text == "未添加") textBox3.Text = "";
                if (textBox4.Text == "未添加") textBox4.Text = "";
                if (textBox5.Text == "未添加") textBox5.Text = "";
                if (textBox6.Text == "未添加") textBox6.Text = "";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePW pW = new ChangePW();
            pW.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlUtil.sqlins("update UserInfo set Money ="+(float.Parse(label8.Text)+10)+ " where UserAc='" + account + "'");
            label8.Text = (float.Parse(label8.Text) + 10).ToString();
        }
    }
}
