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
    public partial class pay : Form
    {
       public static int x = 0;
       public static int SelectIndexRowDelete = -1;
        public pay(int TabIndex)
        {
            InitializeComponent(); 
            tabControl1.SelectedIndex = TabIndex;
            Font F = new Font("TH Sarabun New",16, FontStyle.Regular);
            dataGridView1.Font = F;
            dataGridView2.Font = F;
        }
        //private void pictureBox13_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CByeartap1.SelectedIndex != -1)
            {
                CBMonth.Enabled = true;
            }
            else
            {
                CBMonth.Enabled = false;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //            SELECT TeacherNo, CAST(c.PrefixNameFull + Fname + ' ' + Lname as NVARCHAR),
            //CASE WHEN IdNo = '' THEN 'null' ELSE IdNo END as id, b.GroupPositionName
            //FROM Personal.dbo.tblTeacherHis as a
            //LEFT JOIN Personal.dbo.tblGroupPosition as b ON a.GroupPositionNo = b.GroupPositionNo
            //LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = a.PrefixNo
            //WHERE TeacherNo = 'T54001'
            //ต้องพิมพ์รหัสอาจารย์ถึง 6 ตัวถึงจะเข้าเงื่อนไข if
            if (TBTeacherNo.Text.Length == 6)
            {
                Class.SQLMethod.ResearhMerberANDinformation(TBTeacherNo.Text,TBTeacherName,TBTeacherBill,TBRl, TBidno, TBTel, TBstatus, TBstra);
            }
            else
            {
                TBTeacherBill.Text = "";
                TBTeacherName.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            //Menu p = new Menu();
            //CloseFrom(p);
            //p.MdiParent = this;
            //p.WindowState = FormWindowState.Maximized;
            //p.Show();
            //this.Hide();
        }
        private void Menuf_SizeChanged(object sender, EventArgs e)
        {
            int x = this.Width / 2 - panel1.Size.Width / 2;
            int y = this.Height / 2 - panel1.Size.Height / 2;
            panel1.Location = new Point(x, y);

           
            //TB3.Location = new Point(TB+120, 15);
            //panel7.Size = new Size(TB+500,72); 
            //tabControl1.Location = new Point(x,y);

            //panel1.MinimumSize = new Size(columnSize * 40, rowSize * 40);
            //panel1.Height = rowSize * 40;
            //panel1.Width = columnSize * 40;
            //MessageBox.Show(this.Width + "" + this.Height);
        }
        private void pay_Load(object sender, EventArgs e)
        {
            //DataTable dt.Tables[0];
            //int count = dt.Rows.Count;

            //for (int x = 0; x < count; x++)
            //{
            //    if (TB1.Text == dt.Rows[x][0].ToString())
            //    {
            //        TB2.Text = dt.Rows[1][0].ToString();
            //    }

            //}
        }
        public void tabPage2_Click(object sender, EventArgs e)
        {
            //TabPage t = tabControl1.TabPages[1];
            //tabControl1.SelectTab(t); 
            ////go to tab
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMonth.SelectedIndex != -1)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //int x = Convert.ToInt32(this.TB4.Text);
            //TB4.Text = x.ToString();
            //if (x.GetType() != typeof(int))
            //{
            //    TB4.Text = string.Empty;
            //    MessageBox.Show("EROR");
            //}
            if (CBStatus.SelectedIndex != -1 && TBStartAmountShare.Text != "")
            {
                BTAdd.Enabled = true;
            }
            else
            {
                BTAdd.Enabled = false;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CByeartap1.SelectedIndex = -1;
            CBMonth.SelectedIndex = -1;
            CBStatus.SelectedIndex = -1;
            TBStartAmountShare.Text = string.Empty;
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CByeartap2.SelectedIndex != -1 )
            {
                BTResearchtap2.Enabled = true;
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CByeartap3.SelectedIndex != -1)
            {
                BTResearchtap3.Enabled = true;
            }
        }
    
        private void CBB3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TBStartAmountShare.Text != "" && CBStatus.SelectedIndex != -1)
            {
                BTAdd.Enabled = true;
            }
            else
            {
                BTAdd.Enabled = false;
            }
        }

        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
           Bank.Search  IN = new Bank.Search(2);
            IN.ShowDialog();
            TBTeacherNo.Text = Bank.Search.Return[0];
        }

        private void TBStartAmountShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void CBB4Oppay_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void BTAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.ToString() != "")
            {
                CBB4Oppay.Enabled = true;
                x += int.Parse(TBStartAmountShare.Text);
                label5.Text = x.ToString();
            }
            dataGridView1.Rows.Add(DateTime.Today.Date.ToString(),CBStatus.Text, TBStartAmountShare.Text);
           
            //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[];
            //row.Cells[1].Value = CBStatus.SelectedItem.ToString();
            //row.Cells[2].Value = TBStartAmountShare.Text;
            //dataGridView1.Rows.Add(row);
        }

        private void CBB4Oppay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (CBB4Oppay.SelectedIndex != -1)
            {
                BTsave.Enabled = true;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow != -1)
                {
                    SelectIndexRowDelete = currentMouseOverRow;
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("ลบออก"));
                    m.Show(dataGridView1, new Point(e.X, e.Y));
                    m.MenuItems[0].Click += new System.EventHandler(this.Delete_Click);
                }
            }
        
          
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (SelectIndexRowDelete != -1)
            {
                dataGridView1.Rows.RemoveAt(SelectIndexRowDelete);
                SelectIndexRowDelete = -1;

            }
        }
    }
}
