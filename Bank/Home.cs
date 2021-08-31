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
    public partial class Home : Form
    {
        public static Font F = new Font("TH Sarabun New",16,FontStyle.Regular);
        int Check = 0;

        /// <summary> 
        /// SQLDafault 
        /// <para>[0] INPUT: </para> 
        /// </summary> 
        private String[] SQLDefault = new String[]
         { 
          //[] INPUT: 
          " "
          ,

         };

        public Home()
        {
            InitializeComponent();
        }
     

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            Class.FromSettingMedtod.ChangeSizePanal(this, P1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
        }

        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                Bank.Search IN = new Bank.Search(SQLDefault[0].Replace("{TeacherNo}",""));
                IN.ShowDialog();
                TBTeacherNo.Text = Bank.Search.Return[0];
                TBTeacherName.Text = Bank.Search.Return[1];
                TBTeacherBill.Text = Bank.Search.Return[2];
            }
            catch(Exception x)
            {
                Console.WriteLine( x );
            }

        }

        private void TBTeacherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TBTeacherNo.Text.Length == 6)
                {
                    DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[0].Replace("{TeacherNo}", TBTeacherNo.Text));
                    if (dt.Rows.Count != 0)
                    {
                        TBTeacherName.Text = dt.Rows[0][0].ToString();
                        TBTeacherBill.Text = "บิลจ้า";
                        Check = 1;
                    }
                    else
                    {
                        MessageBox.Show("รหัสไม่ถูกต้อง", "ระบบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("รหัสไม่ถูกต้อง","ระบบ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (Check == 1)
                {
                    TBTeacherName.Text = "";
                    TBTeacherBill.Text = "";
                    Check = 0;
                }

            }

        }
    }
}
