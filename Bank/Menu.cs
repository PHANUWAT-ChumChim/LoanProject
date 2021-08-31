using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example.GOODS
{
    public partial class Menu : Form
    {
        public static int startAmountMin;
        public static int startAmountMax;
        public static int DateAmountChange;
        public static string FontSize;
        static DataTable dt;
        /// <summary> 
        /// SQLDafault 
        /// <para>[0]Check Setting INPUT: - </para> 
        /// </summary> 
        private String[] SQLDefault = new String[]
         { 
             //[0]Check Setting INPUT: - 
             "SELECT DateAmountChange , StartAmountMin , StartAmountMax \r\n" +
             "FROM EmployeeBank.dbo.tblSettingAmount;"
          ,

         };
        public Menu()
        {
            InitializeComponent();
            Class.UserInfo.SetTeacherInformation("T53036", "John YouSuck", "1");

                dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[0]);
                DateAmountChange = Convert.ToInt32(dt.Rows[0][0]);
                startAmountMin = Convert.ToInt32(dt.Rows[0][1]);
                startAmountMax = Convert.ToInt32(dt.Rows[0][2]);
        }
        public void CloseFrom(Form F)
        {
            foreach (Form Menu in this.MdiChildren)
            {
                if (Menu.Name != F.Name)
                    Menu.Close();
                else
                    return;
            }
            F.MdiParent = this;
            F.WindowState = FormWindowState.Maximized;
            F.Show();
        }

        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            e.Item.Visible = false;
        }

        private void หนาเเรกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home Hm = new Home();
            CloseFrom(Hm);
        }
    

        private void สมครสมาชกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.MemberShip Ms = new Bank.MemberShip();
            CloseFrom(Ms);
        }
        private void Menu_Load_1(object sender, EventArgs e)
        {
            Home Hm = new Home();
            CloseFrom(Hm);
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Setting St = new Bank.Setting();
            St.Show();
        }
     
        private void Loan_Click(object sender, EventArgs e)
        {
            Bank.Loan Ln = new Bank.Loan();
            CloseFrom(Ln);
        }

        private void pay_Click(object sender, EventArgs e)
        {
            pay Mn = new pay(0);
            CloseFrom(Mn);
        }
    }
}
