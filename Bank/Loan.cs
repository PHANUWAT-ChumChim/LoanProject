using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example.Bank
{
    public partial class Loan : Form
    {
        //------------------------- index -----------------
        DateTime DateTime;

        String TeacherNoUser = "T40000";
        public static int SelectIndexRowDelete;

        //----------------------- index code -------------------- ////////
        public Loan()
        {
            InitializeComponent();
        }

        //------------------------- FormSize -----------------
        // Comment!
        private void Loan_SizeChanged(object sender, EventArgs e)
        {
            Class.FromSettingMedtod.ChangeSizePanal(this, panel1);
        }

        //----------------------- End code -------------------- ////////

        /// <summary> 
        /// SQLDafaultLoan 
        /// <para>[0] SELECT TeacherName Data INPUT:{TeacherNo} </para> 
        /// <para>[1] SELECT Guarantor Credit Limit INPUT:{GuarantorNo} </para>
        /// <para>[2] SELECT Date Data </para>
        /// <para>[3] INSERT Loan and Get LoanNo INPUT: {TeacherNoAdd}, {TeacherNo}, {MonthPay}, {YearPay}, {LoanAmount}, {PayNo}, {InterestRate}</para>
        /// <para>[4] INSERT Guarantor INPUT: {LoanNo},{TeacherNo},{Amount},{RemainsAmount}</para>
        /// </summary> 
        private String[] SQLDefaultLoan = new String[]
        {
            //[0] SELECT TeacherName Data INPUT:{TeacherNo} 
            "select a.TeacherNo, CAST(ISNULL(c.PrefixNameFull,'') + b.Fname + ' ' + b.Lname as nvarchar) \r\n" +
            "from EmployeeBank.dbo.tblMember as a \r\n" +
            "left join Personal.dbo.tblTeacherHis as b on a.TeacherNo = b.TeacherNo \r\n" +
            "left join BaseData.dbo.tblPrefix as c on b.PrefixNo = c.PrefixNo \r\n" +
            "Where a.TeacherNo = '{TeacherNo}'; \r\n\r\n",

            //[1] SELECT CreditLimit Data INPUT:{GuarantorNo}
            "SELECT a.TeacherNo , d.SavingAmount ,d.SavingAmount - SUM(b.RemainsAmount)\r\n" +
            "FROM EmployeeBank.dbo.tblMember as a\r\n" +
            "LEFT JOIN EmployeeBank.dbo.tblGuarantor as b on a.TeacherNo = b.TeacherNo\r\n" +
            "LEFT JOIN EmployeeBank.dbo.tblLoan as c on b.LoanNo = c.LoanNo\r\n" +
            "LEFT JOIN EmployeeBank.dbo.tblShare as d on a.TeacherNo = d.TeacherNo\r\n" +
            "WHERE a.TeacherNo = '{GuarantorNo}'\r\n" +
            "GROUP BY a.TeacherNo , d.SavingAmount;\r\n"
            ,

            //[2] SELECT Date Data
            "SELECT CAST(CURRENT_TIMESTAMP as DATE); \r\n\r\n",

            //[3] INSERT Loan and Get LoanNo INPUT: {TeacherNoAdd}, {TeacherNo}, {MonthPay}, {YearPay}, {LoanAmount}, {PayNo}, {InterestRate}
            "DECLARE @LoanNo INT;\r\n" +
            "INSERT INTO EmployeeBank.dbo.tblLoan\r\n" +
            "(TeacherNoAddBy, TeacherNo, MonthPay, YearPay, LoanAmount, PayNo, InterestRate, DateAdd)\r\n" +
            "VALUES ('{TeacherNoAdd}', '{TeacherNo}', {MonthPay}, {YearPay}, {LoanAmount}, {PayNo}, {InterestRate}, CAST(CURRENT_TIMESTAMP as DATE));\r\n" +
            "SELECT @LoanNo = SCOPE_IDENTITY();\r\n" +
            "SELECT LoanNo\r\n" +
            "FROM EmployeeBank.dbo.tblLoan\r\n" +
            "WHERE LoanNo = @LoanNo;\r\n"
            ,

            //INSERT Guarantor INPUT: {LoanNo},{TeacherNo},{Amount},{RemainsAmount}
            "INSERT INTO EmployeeBank.dbo.tblGuarantor (LoanNo,TeacherNo,Amount,RemainsAmount)\r\n" +
            "VALUES ('{LoanNo}','{TeacherNo}','{Amount}','{RemainsAmount}');\r\n"
            ,
        };

        //----------------------- PullSQLDate -------------------- ////////
        // ดึงขอมูลวันที่จากฐานข้อมูล
        private void Loan_Load(object sender, EventArgs e)
        {

            DataSet ds = Class.SQLConnection.InputSQLMSSQLDS(SQLDefaultLoan[2]);
            DataTable dt = ds.Tables[0];
            DateTime = DateTime.Parse(dt.Rows[0][0].ToString());
            int Year = int.Parse(DateTime.ToString("yyyy"));
            int Month = int.Parse(DateTime.ToString("MM"));
            for (int Num = 0; Num < 5; Num++)
            {
                CBPayYear.Items.Add(Year);
                Year++;
            }
            for (int a = Month; a <= 12; a++)
            {
                CBPayMonth.Items.Add(a);
            }
        }
        //----------------------- End code -------------------- ////////

        //----------------------- INSERTSQLLoan -------------------- ////////
        // ส่งข้อมูลการกู้ขึ้นไปเก็บบนฐานข้อมูล
        private void BSave_Click(object sender, EventArgs e)
        {
            if (TBTeacherNo.Text != "" && CBPayMonth.Text != "" && CBPayYear.Text != "" &&
                TBLoanAmount.Text != "" && TBPayNo.Text != "" && TBInterestRate.Text != "" && DGVGuarantor.Rows.Count == 4)
            {

                Bank.Search IN = new Bank.Search(2);
                IN.ShowDialog();
                DGVGuarantor.Rows.Clear();
                TBTeacherNo.Text = Bank.Search.Return[0];
                TBTeacherName.Text = Bank.Search.Return[1];
                TBLoanNo.Text = Bank.Search.Return[6];
                TBLoanStatus.Text = Bank.Search.Return[7];
                TBLoanAmount.Text = Bank.Search.Return[9];


                int LoanNo;
                DataSet dsInsertLoan = Class.SQLConnection.InputSQLMSSQLDS(SQLDefaultLoan[3]
                    .Replace("{TeacherNoAdd}", TeacherNoUser)
                    .Replace("{TeacherNo}", TBTeacherNo.Text)
                    .Replace("{MonthPay}", CBPayMonth.Text)
                    .Replace("{YearPay}", CBPayYear.Text)
                    .Replace("{LoanAmount}", TBLoanAmount.Text)
                    .Replace("{PayNo}", TBPayNo.Text)
                    .Replace("{InterestRate}", TBInterestRate.Text)
                    );
                DataTable dtGetLoanNo = dsInsertLoan.Tables[0];
                LoanNo = int.Parse(dtGetLoanNo.Rows[0][0].ToString());

                float credit = int.Parse(TBLoanAmount.Text) / 4;
                bool CheckInt = IsInt(credit);
                int GuarantorCredit = int.Parse(credit.ToString());
                if (!CheckInt)
                {
                    GuarantorCredit += 1;
                }
                for (int Num = 0; Num < DGVGuarantor.Rows.Count; Num++)
                {
                    DataSet dsInsertGuarantor = Class.SQLConnection.InputSQLMSSQLDS(SQLDefaultLoan[4]
                    .Replace("{LoanNo}", LoanNo.ToString())
                    .Replace("{TeacherNo}", DGVGuarantor.Rows[Num].Cells[0].Value.ToString())
                    .Replace("{Amount}", GuarantorCredit.ToString())
                    .Replace("{RemainsAmount}", GuarantorCredit.ToString())
                    );
                }

                MessageBox.Show("บันทึกข้อมูลเสร็จเรียบร้อยแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("โปรดใสข้อมุลให้ครบก่อนบันทึก", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        //----------------------- End code -------------------- ////////

        //------------------------- Pull SQL Member & CheckTBTeacherNo ---------
        // ค้นหารายชชื่อผู้สมัครสมาชิกครูสหกร์จากฐานข้อมูล
        private void TBTeacherNo_TextChanged(object sender, EventArgs e)
        {
            //ต้องพิมพ์รหัสอาจารย์ถึง 6 ตัวถึงจะเข้าเงื่อนไข if

            int credit;
            if (TBTeacherNo.Text.Length == 6)
            {
                DGVGuarantor.Rows.Clear();
                Class.SQLMethod.ReSearchLoan(TBTeacherNo.Text, TBTeacherName, TBLoanNo, TBLoanStatus, TBSavingAmount);

                DataSet ds = Class.SQLConnection.InputSQLMSSQLDS(
                    //SQLDefaultLoan[0].Replace("{TeacherNo}", TBTeacherNo.Text) +

                    SQLDefaultLoan[1].Replace("{GuarantorNo}", TBTeacherNo.Text));

                //DataTable dtTeacherName = ds.Tables[0];
                DataTable dtGuarantorCredit = ds.Tables[0];
                //String aa = dtGuarantorCredit.Rows[0][2].ToString();
                if(dtGuarantorCredit.Rows.Count != 0/* && dtTeacherName.Rows.Count != 0*/)
                {
                    if (dtGuarantorCredit.Rows[0][2].ToString() == "")
                    {
                        credit = int.Parse(dtGuarantorCredit.Rows[0][1].ToString());
                    }
                    else
                    {
                        credit = int.Parse(dtGuarantorCredit.Rows[0][2].ToString());
                    }
                    DGVGuarantor.Rows.Clear();
                    DGVGuarantor.Rows.Add(dtGuarantorCredit.Rows[0][0], TBTeacherName.Text, credit);
                    TBSavingAmount.Text = credit.ToString();
                    //RowDGV = DGVGuarantor.Rows.Count;
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBTeacherNo.Text = "";
                    TBTeacherNo.Focus();
                }

            }
            else
            {
                TBTeacherName.Text = "";
                TBLoanNo.Text = "";
                TBLoanStatus.Text = "";
                TBSavingAmount.Text = "";
                if (DGVGuarantor.Rows.Count > 0)
                {
                    //DGVGuarantor.Rows.Remove()\
                    DGVGuarantor.Rows.Clear();
                }
            }
        }
        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                //DGVGuarantor.Rows.Clear();
                Bank.Search IN = new Bank.Search(2);
                IN.ShowDialog();
                if(Bank.Search.Return.Length > 1)
                {
                    TBTeacherNo.Text = Bank.Search.Return[0];
                    TBTeacherName.Text = Bank.Search.Return[1];
                    TBLoanNo.Text = Bank.Search.Return[6];
                    TBLoanStatus.Text = Bank.Search.Return[7];
                    //TBLoanAmount.Text = Bank.Search.Return[9];
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
        }
        private void TBGuarantorNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (TBTeacherName.Text == "")
            //{
            //    MessageBox.Show("โปรดใส่ข้อมูลด้านบนให้ครบถ้วนก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    TBGuarantorNo.Text = "";
            //}
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool CheckTeacherNo = false;
                for (int Num = 0; Num < DGVGuarantor.Rows.Count; Num++)
                {
                    String aa = DGVGuarantor.Rows[Num].Cells[1].Value.ToString();
                    CheckTeacherNo = TBGuarantorNo.Text.Contains(DGVGuarantor.Rows[Num].Cells[0].Value.ToString());
                    if (CheckTeacherNo)
                        break;
                }
                if ((DGVGuarantor.Rows.Count < 4) && (CheckTeacherNo == false))
                {
                    DataSet ds = Class.SQLConnection.InputSQLMSSQLDS(
                        SQLDefaultLoan[0]
                        .Replace("{TeacherNo}", TBGuarantorNo.Text) +

                        SQLDefaultLoan[1]
                        .Replace("{GuarantorNo}", TBGuarantorNo.Text));
                    DataTable dtGuarantorName = ds.Tables[0];
                    DataTable dtSavingAmount = ds.Tables[1];
                    if (dtGuarantorName.Rows.Count != 0 && dtSavingAmount.Rows.Count != 0)
                    {
                        int credit;
                        if (dtSavingAmount.Rows[0][2].ToString() == "")
                        {
                            credit = int.Parse(dtSavingAmount.Rows[0][1].ToString());
                        }
                        else
                        {
                            credit = int.Parse(dtSavingAmount.Rows[0][2].ToString());
                        }

                        if (credit > 0)
                        {
                            DGVGuarantor.Rows.Add(dtSavingAmount.Rows[0][0].ToString(),
                                dtGuarantorName.Rows[0][1].ToString(),
                                credit);
                        }
                        else
                        {
                            MessageBox.Show("ไม่มียอดเงินที่ใช้ค้ำได้ โปรดเลือกบุคคลอื่น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }




                    }
                    else
                    {
                        DialogResult Result = MessageBox.Show("ไม่มีข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else if (CheckTeacherNo == true)
                    MessageBox.Show("รายชื่อซ้ำ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (DGVGuarantor.Rows.Count >= 4)
                {
                    MessageBox.Show("ผู้ค้ำเกินกหนด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                TBGuarantorNo.Text = "";
            }
        }
        //int RowDGV;
        //----------------------- End code -------------------- ////////

        //----------------------- DatagridView -------------------- ////////
        // Comment!
        private void DGVGuarantor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            LGuarantorAmount.Text = DGVGuarantor.RowCount.ToString() + "/4";
        }
        //Comment!
        private void DGVGuarantor_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LGuarantorAmount.Text = DGVGuarantor.RowCount.ToString() + "/4";
        }
        //----------------------- End code -------------------- ////////

        //----------------------- INNERTNumber in Labal -------------------- ////////
        // Comment!
        bool IsInt(float x)
        {
            try
            {
                int y = Int16.Parse(x.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Comment!
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex > 0 && DGVGuarantor.Rows.Count != 4)
            {
                MessageBox.Show("โปรดเลือกผู้ค้ำให้ครบตามจำนวน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedIndex = 0;
            }
            //else if (tabControl1.SelectedIndex == 2 && DGVGuarantor.Rows.Count == 4)
            //{
            //    int LoanAmount = 0;
            //    for (int Count = 0; Count < DGVGuarantor.Rows.Count; Count++)
            //    {
            //        LoanAmount += int.Parse(DGVGuarantor.Rows[Count].Cells[2].Value.ToString());
            //    }
            //    LLoanAmount.Text = "(" + LoanAmount.ToString() + ")";
            //}
            ////else if (tabControl1.SelectedIndex == 2 && (TBLoanAmount.Text == "" || int.Parse(TBLoanAmount.Text) < 1)
            ////     TBPayNo.Text == "" && TBInterestRate.Text != "" && CBPayMonth.SelectedIndex)
            //else if(tabControl1.SelectedIndex == 2)
            else
            {
                if (tabControl1.SelectedIndex == 1 && DGVGuarantor.Rows.Count == 4)
                {
                    int LoanAmount = 0;
                    for (int Count = 0; Count < DGVGuarantor.Rows.Count; Count++)
                    {
                        LoanAmount += int.Parse(DGVGuarantor.Rows[Count].Cells[2].Value.ToString());
                    }
                    LLoanAmount.Text = "(" + LoanAmount.ToString() + ")";

                }
                else if (tabControl1.SelectedIndex == 2 && (TBLoanAmount.Text != "" && CBPayMonth.SelectedIndex != -1 && CBPayYear.SelectedIndex != -1 && TBPayNo.Text != "" && TBInterestRate.Text != ""))
                {
                    DGVLoanDetail.Rows.Clear();
                    int Month = int.Parse(CBPayMonth.Text), Year = int.Parse(CBPayYear.Text);
                    float Pay = float.Parse(TBLoanAmount.Text) / float.Parse(TBPayNo.Text);
                    float Interest = float.Parse(TBLoanAmount.Text) * float.Parse(TBInterestRate.Text) / 100;

                    for (int Num = 0; Num < int.Parse(TBPayNo.Text); Num++)
                    {
                        float AllpayD = Pay + Interest;
                        int AllPay = 0;
                        Month++;
                        if (Month > 12)
                        {
                            Month = 1;
                            Year++;
                        }
                        if ((!IsInt(AllpayD)) && (Num == (int.Parse(TBPayNo.Text) - 1)))
                        {
                            AllpayD -= 1;
                        }
                        else if (!IsInt(AllpayD))
                        {
                            AllpayD += 1;
                        }
                        AllPay = Convert.ToInt32(AllpayD);
                        DGVLoanDetail.Rows.Add($"{Month}/{Year}", Pay.ToString(), Interest.ToString(), AllPay.ToString());
                    }

                }
            }


        }
        //----------------------- End code -------------------- ////////

        //----------------------- select pay date -------------------- ////////
        // เลือกเดือนจ่าย
        private void CBPayMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int LoanAmount = 0;
            if(TBLoanAmount.Text != "")
                LoanAmount = int.Parse(TBLoanAmount.Text);

            //(CBPayYear.Text != "" && (int.Parse(TBLoanAmount.Text) > int.Parse(LLoanAmount.Text) || int.Parse(TBLoanAmount.Text) < 1))
            String AmountLimit = LLoanAmount.Text.Remove(0, 1);
            AmountLimit = AmountLimit.Remove(AmountLimit.Length - 1);
            if (CBPayYear.SelectedIndex != -1 && (LoanAmount > int.Parse(AmountLimit)))
            {
                DialogResult result = MessageBox.Show("วงเงินกู้เกินกำหนดการค้ำ ต้องการทำต่อหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    TBLoanAmount.Text = "";
                    TBLoanAmount.Focus();
                }
            }
            else if (CBPayYear.Text != "" && (LoanAmount < 1))
            {
                MessageBox.Show("ใส่จำนวนเงินไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBLoanAmount.Text = "";
                TBLoanAmount.Focus();
            }

            //if((CBPayYear.SelectedIndex != -1) && )
            //{
            //    if(MessageBox.Show("คุณยืนยันที่จะใส่เป็นเดือนที่ผ่านมาหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        CBPayMonth.Text = "";
            //        CBPayMonth.Focus();
            //    }
            //}
        }
        // เลือกปีจ่าย
        private void CBPayYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int LoanAmount = 0;
            if(TBLoanAmount.Text != "")
            {
                LoanAmount = int.Parse(TBLoanAmount.Text);
            }
            
            //LoanAmountLimit = int.Parse(LLoanAmount.Text);
            String AmountLimit = LLoanAmount.Text.Remove(0, 1);
            AmountLimit = AmountLimit.Remove(AmountLimit.Length - 1);
            if (CBPayMonth.SelectedIndex != -1 && (LoanAmount > int.Parse(AmountLimit)))
            {
                DialogResult result = MessageBox.Show("วงเงินกู้เกินกำหนดการค้ำ ต้องการทำต่อหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    TBLoanAmount.Text = "";
                    TBLoanAmount.Focus();
                }

            }
            else if (CBPayMonth.SelectedIndex != -1 && (LoanAmount < 1))
            {
                MessageBox.Show("ใส่จำนวนเงินไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBLoanAmount.Text = "";
                TBLoanAmount.Focus();
            }
            if (CBPayYear.SelectedIndex > 0)
            {
                CBPayMonth.Items.Clear();
                for (int Num = 1; Num <= 12; Num++)
                {
                    CBPayMonth.Items.Add(Num);
                }
                CBPayMonth.SelectedIndex = -1;
            }
        }
        //----------------------- End code -------------------- ////////

        //----------------------- select pay EventKey -------------------- ////////
        // อีเว้นตัวเลข ในTB
        private void TBLoanAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            
        }
        // อีเว้นตัวเลข ในTB
        private void TBPayNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        // อีเว้นตัวเลข ในTB
        private void TBInterestRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsNumber(e.KeyChar)) && (!Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        //----------------------- End code -------------------- ////////

        //----------------------- MedtodPrint -------------------- ////////
        public int CurrentRows = 0;
        // Comment!
        public void StartCenter(System.Drawing.Printing.PrintPageEventArgs e, float LocY, String Text, Font fontText, Brush brush)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            float StartLoc = e.PageBounds.Width / 2;
            e.Graphics.DrawString(Text,
                fontText, brush, new PointF(StartLoc, LocY));
        }
        // Comment!
        public void Center(System.Drawing.Printing.PrintPageEventArgs e, float LocY, String Text, Font fontText, Brush brush)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            float StartLoc = e.PageBounds.Width / 2 - SizeString.Width / 2;
            e.Graphics.DrawString(Text,
                fontText, brush, new PointF(StartLoc, LocY));
        }
        // Comment!
        public void KeepRight(System.Drawing.Printing.PrintPageEventArgs e, float LocY, String Text, Font fontText, Brush brush)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            float StartLoc = (e.PageBounds.Width - 50) - SizeString.Width;
            e.Graphics.DrawString(Text,
                fontText, brush, new PointF(StartLoc, LocY));
        }
        // Comment!
        public void KeepLeft(System.Drawing.Printing.PrintPageEventArgs e, float LocY, String Text, Font fontText, Brush brush)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            float StartLoc = 50;
            e.Graphics.DrawString(Text,
                fontText, brush, new PointF(StartLoc, LocY));
        }
        // Comment!
        public void CenterKeepRight(System.Drawing.Printing.PrintPageEventArgs e, float LocY, String Text, Font fontText, Brush brush)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            float StartLoc = ((e.PageBounds.Width / 2) + (e.PageBounds.Width / 2) / 2) - SizeString.Width;
            e.Graphics.DrawString(Text,
                fontText, brush, new PointF(StartLoc, LocY));
        }
        // Comment!
        public void Header(System.Drawing.Printing.PrintPageEventArgs e, Brush brush)
        {
            int Y = 50;
            int SpacePerRow = 25;
            //int CurrentRows = 0;
            Font Header01 = new Font("TH Sarabun New", 20, FontStyle.Bold);
            //Font Normal01 = new Font("TH Sarabun New", 18, FontStyle.Regular);
            String[] Head = new String[] { "APPLICATION FOR EMPLOYMENT", "ใบสมัครงาน", "กรอกข้อมูลด้วยตัวท่านเอง", "(To be completed in own handwriting)" };

            for (int Num = 0; Num < 4; Num++)
            {
                if (Num == 2)
                    Header01 = new Font("TH Sarabun New", 18, FontStyle.Regular);
                SizeF SizeString = e.Graphics.MeasureString(Head[Num], Header01);
                float StartLoc = e.PageBounds.Width / 2 - SizeString.Width / 2;
                e.Graphics.DrawString(Head[Num],
                Header01, brush, new PointF(StartLoc, Y + (SpacePerRow * CurrentRows++)));
            }
        }
        // Comment!
        public void Rect(System.Drawing.Printing.PrintPageEventArgs e, Pen ColorRect, int WidthSize, int HeightSize, float LocY, float LocX)
        {
            //float x = e.PageBounds.Width - 50 - 125;
            e.Graphics.DrawRectangle(ColorRect, LocX, LocY, WidthSize, HeightSize);
        }
        // Comment!
        public void PrintBody(System.Drawing.Printing.PrintPageEventArgs e, float LocY, String Text, Font font, Brush brush)
        {
            float LocX = 96;
            e.Graphics.DrawString(Text, font, brush, LocX, LocY);
        }
        // Comment!
        public void PrintCheckBoxList(System.Drawing.Printing.PrintPageEventArgs e, float LocX, float LocY, Font font, Brush brush, List<String> AllCheckBox, float SpaceCheckList)
        {
            Pen ColorRect = new Pen(Color.Black);

            //for (int Num = 0; Num < AllCheckBox.Count; Num++)
            //{
            //    SizeF SizeText = e.Graphics.MeasureString(AllCheckBox[Num], Normal01);
            //    PrintCheckBoxList(e, SpaceX + (37 * (Num + 1)), Y + (SpacePerRow * CurrentRows), AllCheckBox[Num], Normal01, Normal);
            //    SpaceX += SizeText.Width;
            //}

            for (int Num = 0; Num < AllCheckBox.Count; Num++)
            {
                SizeF SizeText = e.Graphics.MeasureString(AllCheckBox[Num], font);
                e.Graphics.DrawString(AllCheckBox[Num], font, brush, LocX + (SpaceCheckList * (Num + 1)), LocY);
                Rect(e, ColorRect, 15, 15, LocY + 20, LocX + (SpaceCheckList * (Num + 1)) - 17);
                LocX += SizeText.Width;
            }

        }
        //----------------------- End Medtod -------------------- ////////

        //----------------------- Printf -------------------- ////////
        // พิมพ์เอกสารกู้
        private void BPrintLoanDoc_Click_1(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }
        // อัพเอกสารส่ง เซิร์ฟเวอร์
        private void BLoanDocUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("รอก่อนนะยังใช่งานไม่ได้งับ", "ตัวส่ง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //private void button2_Click(object sender, EventArgs e)
            //{
            //    Image File;
            //    //String imgeLocation = "";
            //    try
            //    {
            //        OpenFileDialog dialog = new OpenFileDialog();
            //        dialog.Filter = "pdf files(*.pdf)|*.pdf";
            //        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //        {
            //            //imgeLocation = dialog.FileName;
            //            File = Image.FromFile(dialog.FileName);
            //            //pictureBox1.Image = File;

            //            //        }
            //            //    }
            //            //    catch (Exception)
            //            //    {
            //            //        MessageBox.Show("An Error Occured","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //            //    }
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
        }
        // กระดาษปริ้น
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int PageX = (e.PageBounds.Width);
            int PageY = (e.PageBounds.Height);
            int X = 96;
            int Y = 50;
            int SpacePerRow = 25;
            //int CurrentRows = 0;

            Font Header01 = new Font("TH Sarabun New", 30, FontStyle.Bold);
            Font Normal01 = new Font("TH Sarabun New", 16, FontStyle.Regular);
            Font Toppic = new Font("TH Sarabun New", 18, FontStyle.Bold);
            Brush Normal = Brushes.Black;

            //*Page Header*
            Header(e, Normal);

            //String Text = "เอกสารสมัครสมาชิกสหกรณ์ครู";
            //Center(e, Y + (SpacePerRow * CurrentRows++) - 10, "เอกสารสมัครสมาชิกสหกรณ์ครู" + "\r\n" + 
            //    "aaaaaa" , Header01, Normal);

            //Header(e, Y + (SpacePerRow * CurrentRows++) - 10, Header01, Normal);
            //SizeF SizeString = e.Graphics.MeasureString(Text, Header01);
            //float StartLoc = PageX / 2 - SizeString.Width / 2;
            //e.Graphics.DrawString(Text,
            //    Header01, Normal, new PointF(StartLoc, Y + (SpacePerRow * CurrentRows++)-10));

            //*Rectangle Picture*
            Pen ColorRect = new Pen(Color.Black, 1);
            Rect(e, ColorRect, 125, SpacePerRow * CurrentRows, 50, e.PageBounds.Width - 96 - 125);

            //*NameText And PositionText*
            CurrentRows++;
            String NameTextPrint = "ชื่อ       : ................................................................................................................................................\r\n" +
                "Name\r\n" + "ตำแหน่งที่ต้องการ       1…………………………………………………... เงินเดือน ..........................บาท / เดือน\r\n" +
                "Position applied for       2 …………………………………………… Salary                   Bath / month";
            PrintBody(e, Y + (SpacePerRow * CurrentRows++), NameTextPrint, Normal01, Normal);

            CurrentRows += 4;

            //**Toppic Personal**
            PrintBody(e, Y + (SpacePerRow * CurrentRows++), "Personal information (ประวัติส่วนตัว)", Toppic, Normal);

            //**Detail Personal**
            PrintBody(e, Y + (SpacePerRow * CurrentRows++),
                "ที่อยู่ปัจจุบันเลขที่ ..............หมู่ที่ ........... ถนน ........................................... ตำบล/แขวง.........................\r\n" +
                "Present address           Moo          Road                                 District\r\n" +
                "อำเภอ/เขต ............................................. จังหวัด ........................................ รหัสไปรษณีย์ ....................\r\n" +
                "Amphur                                       Province                            Post code\r\n" +
                "โทรศัพท์ .................................................. เพจเจอร์ .................................... มือถือ .................................\r\n" +
                "Tel.                                             Pager                                Mobile\r\n" +
                "อีเมล์ .........................................................................................................................................................\r\n" +
                "E-mail", Normal01, Normal);

            CurrentRows += 8;

            //**Print Checkbox List**
            List<String> AllCheckBox = new List<string> {
                "อาศัยกับครอบครัว\r\n" + "Living with parent" , "บ้านตัวเอง\r\n" + "Own home", "บ้านเช่า\r\n" + "Hired house", "ห้องเช่า\r\n" + "Hiredflat / Hostel"};
            float SpaceX = X + 15;
            //for (int Num = 0;Num < AllCheckBox.Count; Num++)
            //{
            //    SizeF SizeText = e.Graphics.MeasureString(AllCheckBox[Num], Normal01);
            //    PrintCheckBoxList(e, SpaceX + (37 * (Num + 1)), Y + (SpacePerRow * CurrentRows), AllCheckBox[Num], Normal01, Normal);
            //    SpaceX += SizeText.Width;
            //}
            PrintCheckBoxList(e, SpaceX, Y + (SpacePerRow * CurrentRows), Normal01, Normal, AllCheckBox, 37);

            CurrentRows += 3;
            //**Print Personal02**
            PrintBody(e, Y + (SpacePerRow * CurrentRows),
                "วัน เดือน ปีเกิด ............................................. อายุ ...................... ปี          เชื้อชาติ...............................\r\n" +
                "Date of birth                                     Age                  Yrs.     Race\r\n" +
                "สัญชาติ ...................................................................... ศาสนา.................................................\r\n" +
                "Nationality                                                 Religion\r\n" +
                "บัตรประชาชนเลขที่ ................................................... บัตรหมดอายุ .....................................\r\n" +
                "Identity card no.                                         Expiration date\r\n" +
                "ส่วนสูง ............................ ชม.                            น้ำหนัก ........................... กก.\r\n" +
                "Height                       cm.                           Weight                      kgs.\r\n" +
                "ภาวะทางทหาร\r\n" +
                "Military status\r\n" +
                "สถานภาพ\r\n" +
                "Marital status\r\n" +
                "เพศ\r\n" +
                "Sex", Normal01, Normal);

            CurrentRows += 10;

            //**CheckBox Military status**
            AllCheckBox = new List<string> {
                "ได้รับการยกเว้น\r\n" + "Exempted" , "ปลดเป็นทหารกองหนุน\r\n" + "Served" , "ยังไม่ได้รับการเกณฑ์\r\n" + "Not yet served"};
            PrintCheckBoxList(e, SpaceX + 40, (Y + (SpacePerRow * CurrentRows)) - 10, Normal01, Normal, AllCheckBox, 74);

            CurrentRows += 3;

            //**CheckBox Marital status**
            AllCheckBox = new List<string> {
                "โสด\r\n" + "Single", "แต่งงาน\r\n" + "Married" , "หม้าย\r\n" + "Widowed" , "แยกกัน\r\n" + "Separated"};
            PrintCheckBoxList(e, SpaceX + 40, (Y + (SpacePerRow * CurrentRows)) - 25, Normal01, Normal, AllCheckBox, 74);

            CurrentRows += 3;

            AllCheckBox = new List<string> { "ชาย\r\n" + "Male", "หญิง\r\n" + "Female" };
            PrintCheckBoxList(e, SpaceX + 15, (Y + (SpacePerRow * CurrentRows)) - 45, Normal01, Normal, AllCheckBox, 100);
            //for (int x = 0; x < 20; x++)
            //{
            //    e.Graphics.DrawString("Test",
            //        Normal01, Normal, new PointF(X, Y + (SpacePerRow * CurrentRows++)));

            //    //KeepRight(e, Y + (SpacePerRow * CurrentRows), "Testasd", Normal01, Normal);
            //}

            //float gg = e.PageBounds.Width;
            //SizeF shadowSize = gg;
            //SizeF a = Convert.ChangeType(50, SizeF);
            //e.Graphics.DrawString("Testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt",
            //    Normal01, Normal, new RectangleF(X, Y + (SpacePerRow * CurrentRows++), 200f, 200f));
            //e.Graphics.DrawString("Testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt",
            //    Normal01, Normal, new PointF(X, Y + (SpacePerRow * CurrentRows++) - 50));

            //e.Graphics.DrawString(DTPStartDate.Text, new Font("TH Sarabun New", 18, FontStyle.Regular), Brushes.Black, new PointF(0, 60));
        }
        //----------------------- End Printf -------------------- ////////





        // ------------------------ not working --------------
        // โค้ดที่ไม่ได้ใช้งานหรือเก็บไว้ศึกษาต่อ
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("เดี๋ยวใส่ตอนรวมโปรแกรมครับ", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading, true);
        }
        private void Recycle()
        {
            //private void BPrintLoanDoc_Click(object sender, EventArgs e)
            //{
            //    //Method.SQLMethod.TeacherMember(TBTeacherNo.Text,int.Parse(TBStartAmountShare.Text), button1.Text);
            //    CurrentRows = 0;
            //    DialogResult a = printPreviewDialog1.ShowDialog();
            //}

            //private void RBPresent_CheckedChanged(object sender, EventArgs e)
            //{
            //    CBPayMonth.Items.Clear();
            //    CBPayYear.Items.Clear();
            //    DataSet ds = Class.SQLConnection.InputSQLMSSQLDS(
            //        SQLDefault[2]);
            //    DataTable dt = ds.Tables[0];
            //    DateTime date = DateTime.Parse(dt.Rows[0][0].ToString());
            //    int Month = int.Parse(date.ToString("MM"));
            //    int Year = int.Parse(date.ToString("yyyy"));
            //    if (RBPresent.Checked == true)
            //    {

            //        if (Month == 12)
            //            Month = 1;
            //        for (; Month <= 12; Month++)
            //        {
            //            CBPayMonth.Items.Add(Month);
            //        }
            //        for (int count = 0; count < 10; count++)
            //        {
            //            CBPayYear.Items.Add(Year);
            //            Year++;
            //        }
            //        //for(int count = 0;)
            //        //CBPayMonth.Items.Add("asdasdasd");
            //    }
            //    else
            //    {
            //        for (int count = 1; count <= 12; count++)
            //        {
            //            CBPayMonth.Items.Add(count);
            //        }
            //        Year += 3;
            //        for (int count = 0; count < 15; count++)
            //        {
            //            CBPayYear.Items.Add(Year);
            //            Year--;
            //            //
            //        }
            //    }
            //}
            //private void TBTeacherNo_KeyDown(object sender, KeyEventArgs e)
            //{
            //    if (TBTeacherNo.Text.Length == 6)
            //    {
            //        if (e.KeyCode == Keys.Enter)
            //        {
            //            DataSet ds = Class.SQLConnection.InputSQLMSSQLDS(
            //                SQLDefaultLoan[0]
            //                .Replace("{TeacherNo}", TBTeacherNo.Text));
            //            DataTable dtTeacher = ds.Tables[0];

            //            DataTable dt = ds.Tables[1];


            //        }
            //    }
            //    else
            //    {
            //        TBTeacherName.Text = "";
            //        TBLoanNo.Text = "";
            //        TBLoanStatus.Text = "";
            //        TBSavingAmount.Text = "";
            //    }

            //}
        }

        private void DGVGuarantor_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = DGVGuarantor.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow > 0)
                {
                    SelectIndexRowDelete = currentMouseOverRow;
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("ลบออก"));
                    m.Show(DGVGuarantor, new Point(e.X, e.Y));
                    m.MenuItems[0].Click += new System.EventHandler(this.Delete_Click);
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (SelectIndexRowDelete > 0)
            {
                DGVGuarantor.Rows.RemoveAt(SelectIndexRowDelete);
                SelectIndexRowDelete = -1;

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (TBTeacherName.Text == "")
            {
                MessageBox.Show("โปรดใส่ข้อมูลด้านบนให้ครบถ้วนก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBGuarantorNo.Text = "";
            }
            else
            {
                try
                {
                    //DGVGuarantor.Rows.Clear();
                    Bank.Search IN = new Bank.Search(2);
                    IN.ShowDialog();
                    if (Bank.Search.Return.Length > 1)
                    {
                        //textbox1_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                        KeyEventArgs aaa;
                        Keys aa = Keys.Enter;
                        //aaa.KeyCode
                        TBGuarantorNo.Text = Bank.Search.Return[0];
                        TBGuarantorNo_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
                        //TBTeacherName.Text = Bank.Search.Return[1];
                        //TBLoanNo.Text = Bank.Search.Return[6];
                        //TBLoanStatus.Text = Bank.Search.Return[7];
                        ////TBLoanAmount.Text = Bank.Search.Return[9];
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine(x);
                }
            }
            
        }

        private void TBGuarantorNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBTeacherName.Text == "")
            {
                MessageBox.Show("โปรดใส่ข้อมูลด้านบนให้ครบถ้วนก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBGuarantorNo.Text = "";
                TBTeacherNo.Focus();
            }
        }

        private void TBLoanAmount_TextChanged(object sender, EventArgs e)
        {
            if (CBPayMonth.SelectedIndex != -1 && CBPayYear.SelectedIndex != -1)
            {
                String AmountLimit = LLoanAmount.Text.Remove(0, 1);
                AmountLimit = AmountLimit.Remove(AmountLimit.Length - 1);
                int Amount;
                if(int.TryParse(TBLoanAmount.Text, out Amount))
                {
                    if (Amount > int.Parse(AmountLimit))
                    {
                        if (MessageBox.Show("จำนวนเงินกู้ เกินกำหนดเงินค้ำ\r\n ต้องการทำต่อหรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            TBLoanAmount.Text = "";
                            TBLoanAmount.Focus();
                        }
                    }
                }
                
            }
        }

    }
}


