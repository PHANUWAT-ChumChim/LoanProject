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

        //------------------------- index -----------------
        public static int x = 0;
        public static int sum = 0;
        public static int SelectIndexRowDelete = -1;
        //----------------------- index code -------------------- ////////


        /// <summary> 
        /// SQLDafault 
        /// <para>[0] SELECT MEMBER INPUT: {TeacherNo} </para> 
        /// <para>[1] SELECT TIME INPUT : - </para>
        /// <para>[2] INSERT Bill and BillDetail INPUT: {TeacherAddBy} {TeacherNo} {TypeNo} {LoanNo} {Amount} {Mount} {Year}</para>
        /// <para>[3] UPDATE SavingAmount INPUT: {TeacherNo} {Amount}</para>
        /// <para>[4] UPDATE REMAIN INPUT: {TeacherNo} {Amount}</para>
        /// <para>[5] AmountpayANDAmountLoanINMonth INPUT: {TeacherNo}</para>
        /// <para>[6] SELECT Detail Member INPUT: {TeacherNo}</para>
        /// </summary> 
        private String[] SQLDefault = new String[]
         { 
          //[0] SELECT MEMBER INPUT: {TeacherNo} 
          "SELECT a.TeacherNo ,  CAST(c.PrefixName+' '+Fname +' '+ Lname as NVARCHAR) \r\n " +
          "FROM EmployeeBank.dbo.tblMember as a \r\n " +
          "LEFT JOIN Personal.dbo.tblTeacherHis as b ON a.TeacherNo = b.TeacherNo \r\n " +
          "LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = b.PrefixNo \r\n " +
          "WHERE a.TeacherNo LIKE 'T{TeacherNo}%' and MemberStatusNo = 1 \r\n " +
          "ORDER BY Fname; "
          ,
          //[1] SELECT TIME INPUT : -
          "SELECT CONVERT (DATE , CURRENT_TIMESTAMP); "
             ,
          //[2] INSERT Bill and BillDetail INPUT: {TeacherAddBy} {TeacherNo} {TypeNo} {LoanNo} {Amount} {Mount} {Year}
          "DECLARE @BillNo INT; \r\n " +
          "DECLARE @TeacherNo VARCHAR(20); \r\n " +
          "DECLARE @TeacherNoAddBy VARCHAR (20); \r\n " +
          " \r\n " +
          "SET @TeacherNoAddBy = '{TeacherAddBy}'; \r\n " +
          "SET @TeacherNo = '{TeacherNo}'; \r\n " +
          " \r\n " +
          "INSERT INTO EmployeeBank.dbo.tblBill (TeacherNo, TeacherNoAddBy , DateAdd) \r\n " +
          "VALUES (@TeacherNo, @TeacherNoAddBy , CURRENT_TIMESTAMP); \r\n " +
          " \r\n " +
          "SELECT @BillNo = SCOPE_IDENTITY(); \r\n " +
          " \r\n " +
          "INSERT INTO EmployeeBank.dbo.tblBillDetail (BillNo,TypeNo,LoanNo,Amount,Mount,Year) \r\n " +
          "VALUES (@BillNo,'{TypeNo}','{LoanNo}','{Amount}','{Mount}','{Year}'); "
             ,
         //[3] UPDATE SavingAmount INPUT: {TeacherNo} {Amount}
          "DECLARE @Saving INT; \r\n " +
          " \r\n " +
          "SET @Saving = (SELECT SavingAmount \r\n " +
          "FROM EmployeeBank.dbo.tblShare \r\n " +
          "WHERE TeacherNo = '{TeacherNo}'); \r\n " +
          " \r\n " +
          "UPDATE EmployeeBank.dbo.tblShare \r\n " +
          "SET SavingAmount = @Saving + '{Amount}' \r\n " +
          "WHERE TeacherNo = '{TeacherNo}' \r\n " +
          " \r\n " +
          " "
          ,
         //[4] UPDATE REMAIN INPUT: {TeacherNo} {Amount}
          "DECLARE @Remain INT; \r\n " +
          " \r\n " +
          "SET @Remain = (SELECT Remain \r\n " +
          "FROM EmployeeBank.dbo.tblLoanPay \r\n " +
          "WHERE TeacherNo = '{TeacherNo}'); \r\n " +
          " \r\n " +
          "UPDATE EmployeeBank.dbo.tblLoanPay \r\n " +
          "SET Remain = @Remain - '{Amount}' \r\n " +
          "WHERE TeacherNo = '{TeacherNo}' \r\n " +
          " \r\n " +
          " "
          ,
          //[5] AmountpayANDAmountLoanINMonth INPUT: {TeacherNo}
          "SELECT Mb.TeacherNo,Mb.StartAmount AS  Amountpay,Mb.DateAdd AS Datepay,Lp.Amount AS AmountLoan,Ln.DateAdd AS DateLoan \r\n"+
          "FROM EmployeeBank.dbo.tblMember as Mb\r\n"+
          "LEFT JOIN EmployeeBank.dbo.tblLoan as Ln on Mb.TeacherNo = Ln.TeacherNo\r\n"+
          "LEFT JOIN EmployeeBank.dbo.tblLoanPay as Lp  on Ln.TeacherNo = Lp.TeacherNo\r\n" +
          "WHERE Mb.TeacherNo = '{TeacherNo}';"
             ,
          //[6] SELECT Detail Member INPUT: {TeacherNo}
          "SELECT a.TeacherNo , CAST(c.PrefixName+' '+[Fname] +' '+ [Lname] as NVARCHAR)AS Name, b.IdNo AS TeacherID,   \r\n " +
          " b.TeacherLicenseNo,b.IdNo AS IDNo,b.TelMobile ,a.StartAmount,CAST(d.MemberStatusName as nvarchar) AS UserStatususing   \r\n " +
          " FROM EmployeeBank.dbo.tblMember as a   \r\n " +
          " LEFT JOIN Personal.dbo.tblTeacherHis as b ON a.TeacherNo = b.TeacherNo   \r\n " +
          " LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = b.PrefixNo  \r\n " +
          " INNER JOIN EmployeeBank.dbo.tblMemberStatus as d on a.MemberStatusNo = d.MemberStatusNo  \r\n " +
          " WHERE a.TeacherNo LIKE 'T{TeacherNo}%' and a.MemberStatusNo = 1   \r\n " +
          " ORDER BY a.TeacherNo;  "
          ,


         };
        public pay(int TabIndex)
        {
            InitializeComponent();
            tabControl1.SelectedIndex = TabIndex;

            Font F = new Font("TH Sarabun New", 16, FontStyle.Regular);



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
        }
        // Comment! Pull SQL Member & CheckTBTeacherNo
        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                Bank.Search IN = new Bank.Search(SQLDefault[0].Replace("{TeacherNo}",""));
                IN.ShowDialog();
                TBTeacherNo.Text = Bank.Search.Return[0];
                TBTeacherNo_KeyDown(sender, new KeyEventArgs(Keys.Enter));
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
                    String LoanNo = "";
                    int TypeNo = 0;

                    for (int x = 0; x < dataGridView1.Rows.Count; x++)
                    {
                        string[] MountandYear = dataGridView1.Rows[x].Cells[0].Value.ToString().Replace(" ", "").Split('/');
                        if (dataGridView1.Rows[x].Cells[1].Value.ToString() == "สะสม")
                        {
                            DataTable LoanID = Class.SQLConnection.InputSQLMSSQL(SQLDefault[6].Replace("{TeacherNo}", TBTeacherNo.Text));
                            if (LoanID.Rows.Count == 1)
                            {
                                LoanNo = LoanID.Rows[0][0].ToString();
                            }
                            else
                            {
                                MessageBox.Show("ไม่พบรายการ", "การแจ้งเตือนการชำระ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            TypeNo = 1;
                        }
                        else if (dataGridView1.Rows[x].Cells[1].Value.ToString() == "กู้")
                        {
                            TypeNo = 2;
                        }
                        try
                        {
                            Class.SQLConnection.InputSQLMSSQL(SQLDefault[2].Replace("{TeacherNo}", TBTeacherNo.Text)
                                .Replace("{TeacherAddBy}", Class.UserInfo.TeacherName)
                                .Replace("{TypeNo}", TypeNo.ToString())
                                .Replace("{LoanNo}", LoanNo)
                                .Replace("{Amount}", dataGridView1.Rows[x].Cells[2].Value.ToString())
                                .Replace("{Mount}", MountandYear[1])
                                .Replace("{Year}", MountandYear[0]));
                            if (TypeNo == 1)
                            {
                                Class.SQLConnection.InputSQLMSSQL(SQLDefault[3].Replace("{TeacherNo}", TBTeacherNo.Text)
                                    .Replace("{Amount}", dataGridView1.Rows[x].Cells[2].Value.ToString()));
                            }
                            else if (TypeNo == 2)
                            {
                                Class.SQLConnection.InputSQLMSSQL(SQLDefault[4].Replace("{TeacherNo}", TBTeacherNo.Text)
                                     .Replace("{Amount}", dataGridView1.Rows[x].Cells[2].Value.ToString()));
                            }
                            MessageBox.Show("การชำระเสร็จสิ้น", "การเเจ้งเตือนการชำระ", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        }
                        catch
                        {
                            MessageBox.Show("การชำระล้มเหลว", "การเเจ้งเตือนการชำระ", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                    }
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
                DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[5].Replace("{TeacherNo}", TBTeacherNo.Text));
                if (dt.Rows.Count != 0)
                {
                    if (CBStatus.SelectedIndex == 0)
                    {
                        TBStartAmountShare.Text = dt.Rows[0][1].ToString();
                    }
                    else
                    {
                        TBStartAmountShare.Text = dt.Rows[0][3].ToString();
                    }


                }
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
            String Time = Convert.ToDateTime(Class.SQLConnection.InputSQLMSSQL(SQLDefault[1]).Rows[0][0]).ToString("yyyy/MM");
            dataGridView1.Rows.Add(Time, CBStatus.Text, TBStartAmountShare.Text);


            //dataGridView1.Rows.Add(DateTime.Today.Date.ToString(), CBStatus.Text, TBStartAmountShare.Text);
           


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

        private void TBTeacherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[6].Replace("T{TeacherNo}", TBTeacherNo.Text));
                if (dt.Rows.Count != 0)
                {
                    TBTeacherName.Text = dt.Rows[0][1].ToString();
                    TBTeacherBill.Text = dt.Rows[0][2].ToString();
                    TBTeacherIDNo.Text = dt.Rows[0][3].ToString();
                    TBidno.Text = dt.Rows[0][4].ToString();
                    TBTel.Text = dt.Rows[0][5].ToString();
                    TBStartAmount2.Text = dt.Rows[0][6].ToString();
                    TBstatus.Text = dt.Rows[0][7].ToString();
                }
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pay_Load(object sender, EventArgs e)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[1]);
            int Year = Convert.ToInt32((Convert.ToDateTime(dt.Rows[0][0])).ToString("yyyy"));
            for(int x = 0; x < 4; x++)
            {
                CByeartap1.Items.Add(Year);
                CByeartap2.Items.Add(Year);
                CByeartap3.Items.Add(Year);
                Year--;
            }


        }





        //----------------------- End code -------------------//




    }
}
