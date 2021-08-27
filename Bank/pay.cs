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

        //------------------------- index -----------------
        public static int x = 0;
        public static int sum = 0;
        public static int SelectIndexRowDelete = -1;
        //----------------------- index code -------------------- ////////

        public pay(int TabIndex)
        {
            InitializeComponent();
            tabControl1.SelectedIndex = TabIndex;

            Font F = new Font("TH Sarabun New", 16, FontStyle.Regular);

            Font F = new Font("TH Sarabun New",16, FontStyle.Regular,GraphicsUnit.Point);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = F;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = F;
        }
        //------------------------- FormSize -----------------
        // Comment!
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
        //----------------------- End code -------------------- ////////



        //----------------------- PullSQL -------------------- ////////
        // Comment! Pull SQL Member & CheckTBTeacherNo
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ต้องพิมพ์รหัสอาจารย์ถึง 6 ตัวถึงจะเข้าเงื่อนไข if
            if (TBTeacherNo.Text.Length == 6)
            {
                Class.SQLMethod.ResearhMerberANDinformation(TBTeacherNo.Text, TBTeacherName, TBTeacherBill, TBTeacherIDNo, TBidno, TBTel, TBstatus, TBStartAmount2);
                CBStatus.Enabled = true;
            }
            else
            {
                sum = 0; x = 0;
                label5.Text = sum.ToString();
                dataGridView1.Rows.Clear();
                TBStartAmountShare.Text = "";
                CBStatus.SelectedIndex = -1;
                TBTeacherBill.Text = "";
                TBTeacherName.Text = "";
                CBStatus.Enabled = false;
            }
        }
        // Comment! Pull SQL Member & CheckTBTeacherNo
        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                Bank.Search IN = new Bank.Search(2);
                IN.ShowDialog();
                TBTeacherNo.Text = Bank.Search.Return[0];
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }

            sum = 0; x = 0;
            label5.Text = sum.ToString();
            dataGridView1.Rows.Clear();
            TBStartAmountShare.Clear();
            CBStatus.SelectedIndex = -1;
        }
        // บันทึกรายการเเล้ว ส่งขึ้นไปบนฐานข้อมูล
        private void BTsave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("ยืนยันการชำระ", "การเเจ้งเตือนการชำระ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something /
                    MessageBox.Show("การชำระเสร็จสิ้น", "การเเจ้งเตือนการชำระ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else/
                    MessageBox.Show("การชำระล้มเหลว", "การเเจ้งเตือนการชำระ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            else
            {
                MessageBox.Show("รายการชำระไม่ถูกต้อง", "การเเจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //----------------------- End code -------------------- ////////


        //-------------------------- if.Enbled Text ------------------------
        // if message in textCByer nothing will not Open next
        // ถ้า ไม่มีข้อความ ใน กล่องปี จะไม่เปิดใช่งานกล่อง ถัดไป
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
        // if message in textMonth nothing will not Open next
        // ถ้า ไม่มีข้อความ ใน กล่องเดือน จะไม่เปิดใช่งานกล่อง ถัดไป
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
        // if message in Text nothing will not Open next
        // ถ้า ไม่มีข้อความ ใน กล่อง จะไม่เปิดใช่งานกล่อง ถัดไป
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CByeartap2.SelectedIndex != -1)
            {
                BTResearchtap2.Enabled = true;
            }
        }
        // if message in Text nothing will not Open next
        // ถ้า ไม่มีข้อความ ใน กล่อง จะไม่เปิดใช่งานกล่อง ถัดไป
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CByeartap3.SelectedIndex != -1)
            {
                BTResearchtap3.Enabled = true;
            }
        }
        // if message in Text nothing will not Open next
        // ถ้า ไม่มีข้อความ ใน กล่อง จะไม่เปิดใช่งานกล่อง ถัดไป
        private void CBB3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBStatus.SelectedIndex != -1 && TBTeacherNo.Text.Length  == 6)
            {
                Class.SQLMethod.AmountpayANDAmountLoanINMonth(TBTeacherNo.Text, TBStartAmountShare, CBStatus);
                BTAdd.Enabled = true;
            }
            else
            {

                TBStartAmountShare.Text = "";
                CBStatus.Text = "";
                
                BTAdd.Enabled = false;
            }
        }
        // if message in Text nothing will not Open next
        // ถ้า ไม่มีข้อความ ใน กล่อง จะไม่เปิดใช่งานกล่อง ถัดไป
        private void CBB4Oppay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != 0)
            {
                CBB4Oppay.Enabled = true;
            }
            if (CBB4Oppay.SelectedIndex != -1)
            {
                BTsave.Enabled = true;
                
            }
            else { BTsave.Enabled = false; }
        }
        //----------------------- End code -------------------- ////////

     

        //------------------------- ClickDelete&Empty --------- //
        // Comment!
        private void button1_Click_1(object sender, EventArgs e)
        {
            CByeartap1.SelectedIndex = -1;
            CBMonth.SelectedIndex = -1;
            CBStatus.SelectedIndex = -1;
            TBStartAmountShare.Text = string.Empty;
        }
        // Comment!
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
        // Comment!
        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                sum -= int.Parse(dataGridView1.Rows[SelectIndexRowDelete].Cells[2].Value.ToString());
                x = sum;
                label5.Text = sum.ToString();
            }
            if (SelectIndexRowDelete != -1)
            {
                dataGridView1.Rows.RemoveAt(SelectIndexRowDelete);
                SelectIndexRowDelete = -1;
                if (dataGridView1.Rows.Count == 0)
                {
                    CBB4Oppay.Enabled = false;
                    CBB4Oppay.SelectedIndex = -1;
                }
            }
        }
        //----------------------- End code -------------------- ////////

        //------------------------- SUMAmountShare --------- //
        // Comment! //
        private void BTAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.ToString() != "")
            {
                CBB4Oppay.Enabled = true;
                if (TBStartAmountShare.Text != "")
                {
                    x += int.Parse(TBStartAmountShare.Text);
                    sum = x;
                    label5.Text = sum.ToString();
                }
                else { TBStartAmountShare.Text = "0"; }
            }

            dataGridView1.Rows.Add(CByeartap1.SelectedItem.ToString() +" / "+ CBMonth.SelectedItem.ToString(), CBStatus.Text, TBStartAmountShare.Text);


            dataGridView1.Rows.Add(DateTime.Today.Date.ToString(), CBStatus.Text, TBStartAmountShare.Text);
           


            //DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[];
            //row.Cells[1].Value = CBStatus.SelectedItem.ToString();
            //row.Cells[2].Value = TBStartAmountShare.Text;
            //dataGridView1.Rows.Add(row);
        }
        //----------------------- End code -------------------- ////////



     









        // ------------------------ not working -------------- //
        private void button3_Click(object sender, EventArgs e)
        {

            //Menu p = new Menu();
            //CloseFrom(p);
            //p.MdiParent = this;
            //p.WindowState = FormWindowState.Maximized;
            //p.Show();
            //this.Hide();
        }
        public void tabPage2_Click(object sender, EventArgs e)
        {
            //TabPage t = tabControl1.TabPages[1];
            //tabControl1.SelectTab(t); 
            ////go to tab
        }
        private void TBStartAmountShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

      

        private void BTsave_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("ยืนยันการชำระ", "การเเจ้งเตือนการชำระ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something 
                        Class.SQLMethod.InsertBillandUpdateValue(TBTeacherNo.Text,Class.UserInfo.TeacherNo,dataGridView1);
                    }
                    else
                    {
                        //do something else/
                        MessageBox.Show("การชำระล้มเหลว", "การเเจ้งเตือนการชำระ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }

                }
                else
                {
                    MessageBox.Show("รายการชำระไม่ถูกต้อง", "การเเจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }




            //----------------------- End code -------------------//
        }

        }

        //----------------------- End code -------------------

    }
}
