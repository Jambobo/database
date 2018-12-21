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
using System.Xml;

namespace WindowsFormsApp2
{
    public partial class MarketForm : Form
    {
        public static string userac="";
        public int flag=0;
        DataTable dt;
       
        public MarketForm()
        {
            InitializeComponent();
            
        }
        private void Market_Load(object sender, EventArgs e)
        {          
            dt = SqlUtil.Datas("select * from savedpw");
            if(userac=="") userac = dt.Rows[0][0].ToString();           
            if (userac=="")
            {   Login_form login_Form=new Login_form();           
                login_Form.ShowDialog();              
                if (login_Form.DialogResult == DialogResult.OK)
                {                   
                    userac = Login_form.ac; Market_Load(null, null);                 
                }
            }
            else
            {
                DataRow dataRow = SqlUtil.Datas("select * from UserInfo where UserAc='" + userac + "'").Rows[0];
                personCenter.Text = dataRow["Username"].ToString();
                homepage_Click(null, null);
            }          
        }
        private void personCenter_Click(object sender, EventArgs e)
        {
            ChangeInfo info = new ChangeInfo(userac,"");
            info.ShowDialog();
            if (info.DialogResult == DialogResult.OK)
            {
                DataRow dataRow = SqlUtil.Datas("select * from UserInfo where UserAc='" + userac + "'").Rows[0];
                personCenter.Text = dataRow["Username"].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login_form login_Form = new Login_form();
            login_Form.ShowDialog();
            
            if (login_Form.DialogResult == DialogResult.OK)
            {
                userac = Login_form.ac; Market_Load(null, null);               
            }
        }

        private void gouwuche_Click(object sender, EventArgs e)
        {
                panel1.Controls.Clear();
                GouWuche gouWuche = new GouWuche();
                gouWuche.TopLevel = false;
                gouWuche.Show();
                gouWuche.Parent = panel1;
        }

        private void sellerpage_Click(object sender, EventArgs e)
        {
                panel1.Controls.Clear();
                SellerPage sellForm = new SellerPage();
                sellForm.TopLevel = false;
                sellForm.Show();
                sellForm.Parent = panel1;
        }
        public void Updatesp()
        {
            panel1.Controls.Clear();
            SellerPage sellForm = new SellerPage();
            sellForm.TopLevel = false;
            sellForm.Show();
            sellForm.Parent = panel1;
        }
        private void buyerpage_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            BuyerPage buyerpage = new BuyerPage();
            buyerpage.TopLevel = false;
            buyerpage.Show();
            buyerpage.Parent = panel1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            BuyerPage buyerpage = new BuyerPage(textBox1.Text);
            buyerpage.TopLevel = false;
            buyerpage.Show();
            buyerpage.Parent = panel1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            panel1.Controls.Clear();
            BuyerPage buyerpage = new BuyerPage(btn.Text,"");
            buyerpage.TopLevel = false;
            buyerpage.Show();
            buyerpage.Parent = panel1;
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            
            Homepage homepage = new Homepage();
            panel1.Controls.Clear();
            homepage.TopLevel = false;
            homepage.Parent = panel1;
            homepage.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
