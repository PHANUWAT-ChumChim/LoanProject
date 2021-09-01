
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static example.Class.ProtocolSharing.ConnectSMB;

namespace example.Bank
{
    public partial class MemberShip : Form
    {
        //------------------------- index -----------------


        //----------------------- index code -------------------- ////////

        public MemberShip()
        {
            InitializeComponent();
            TBStartAmountShare.Text = example.GOODS.Menu.startAmountMin.ToString();
        }

        //------------------------- FormSize -----------------
        // Comment!
        private void membership_SizeChanged(object sender, EventArgs e)
        {
            Class.FromSettingMedtod.ChangeSizePanal(this, panel1);
        }
        //----------------------- End code -------------------- ////////

        /// <summary>
        /// SQLDafault
        /// <para>[0] Insert Teacher Data INPUT:{TeacherNo}{TeacherAddBy}, {StartAmount} </para>
        /// <para>[1] SELECT Member  INPUT:{TeacherNo} </para>
        /// <para>[2]  Select Detail Memner INPUT: {TeacherNo} </para>
        /// </summary>
        private String[] SQLDefault = new String[]
        {
			//[0] Insert Teacher Data INPUT:{TeacherNo},{TeacherAddBy},{StartAmount} 
			"INSERT INTO EmployeeBank.dbo.tblMember(TeacherNo,TeacherAddBy,StartAmount,DateAdd) \r\n"+
            "VALUES('{TeacherNo}','{TeacherAddBy}',{StartAmount}, CURRENT_TIMESTAMP); \r\n\r\n",
   
            //[1] SELECT Member  INPUT:{TeacherNo}
          "SELECT a.TeacherNo ,  CAST(b.PrefixName+' '+Fname +' '+ Lname as NVARCHAR) \r\n " +
          "FROM Personal.dbo.tblTeacherHis as a \r\n " +
          "LEFT JOIN BaseData.dbo.tblPrefix as b ON a.PrefixNo = b.PrefixNo  \r\n " +
          "WHERE NOT a.TeacherNo IN(SELECT TeacherNo FROM EmployeeBank.dbo.tblMember) and a.TeacherNo LIKE 'T{TeacherNo}%' \r\n " +
          "ORDER BY Fname "

          ,
          //[2]  Select Detail Memner INPUT: {TeacherNo} 
          "SELECT a.TeacherNo ,CAST(b.PrefixName+' '+Fname +' '+ Lname as NVARCHAR)AS Name, a.IdNo ,a.cNo,a.cMu,c.TumBonName,d.AmPhurName,e.JangWatLongName,a.TelMobile \r\n " +
          "FROM Personal.dbo.tblTeacherHis as a \r\n " +
          "LEFT JOIN BaseData.dbo.tblPrefix as b ON a.PrefixNo = b.PrefixNo  \r\n " +
          "LEFT JOIN BaseData.dbo.tblTumBon as c on a.cTumBonNo = c.TumBonNo \r\n " +
          "LEFT JOIN BaseData.dbo.tblAmphur as d on a.cAmPhurNo = d.AmphurNo \r\n " +
          "LEFT JOIN BaseData.dbo.tblJangWat as e on a.cJangWatNo = e.JangWatNo \r\n " +
          "WHERE a.TeacherNo = '{TeacherNo}'; "

          ,


        };

        //----------------------- PullSQL -------------------- ////////
        // Comment!
        // Available values| ResearchUserAllTLC / TB /
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ////ต้องพิมพ์รหัสอาจารย์ถึง 6 ตัวถึงจะเข้าเงื่อนไข if
            //if (TBTeacherNo.Text.Length == 6)
            //{
            //    Class.SQLMethod.ResearchUserAllTLC(TBTeacherNo.Text, TBTeacherName, TBIDNo , 0);
            //}
            //else
            //{
            //    TBIDNo.Text = "";
            //    TBTeacherName.Text = "";
            //}

        }
        // Comment!
        // Available values|  BSearchTeacher / TB /
        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                Search IN = new Search(SQLDefault[1].Replace("{TeacherNo}", ""));
                IN.ShowDialog();
                if (Search.Return[0] != "")
                {
                    TBTeacherNo.Text = Search.Return[0];
                    TBTeacherNo_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
        }
        // Comment!
        // Available values|  SQLDefault[1] / TB /
        private void BSave_Click_1(object sender, EventArgs e)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[1].Replace("{TeacherNo}", TBTeacherNo.Text));
            if (TBTeacherName.Text != "")
            {
                if (Convert.ToInt32(TBStartAmountShare.Text) >= example.GOODS.Menu.startAmountMin && Convert.ToInt32(TBStartAmountShare.Text) <= example.GOODS.Menu.startAmountMax)
                {
                    if (dt.Rows.Count == 0)
                    {
                        Class.SQLConnection.InputSQLMSSQL(SQLDefault[0].Replace("{TeacherNo}", TBTeacherNo.Text)
                            .Replace("{TeacherAddBy}", Class.UserInfo.TeacherNo)
                            .Replace("{StartAmount}", TBStartAmountShare.Text)
                            .Replace("{DocPath}", "file"));
                        MessageBox.Show("สมัครเสร็จสิ้น", "การยืนยันการสมัคร", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TBIDNo.Text = "";
                        TBStartAmountShare.Text = example.GOODS.Menu.startAmountMin.ToString();
                        TBTeacherName.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("รายชื่อซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("ไม่สามารถสมัครสมาชิกได้เนื่องจาก \r\n ราคาหุ้นเริ่มต้นต่ำหรือสูงเกินไป \r\n โปรดแก้ไข ราคาหุ้นขั้นต่ำ หรือ สูงสุด ที่หน้าตั้งค่า", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("โปรดเลือกสมาชิกในการสมัคร", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //----------------------- End code -------------------- ////////





        //----------------------- EventKey -------------------- ////////
        // Available values| TB /
        private void TBStartAmountShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        //----------------------- End code -------------------- ////////


        //----------------------- Outgoing -------------------- ////////
        private void BExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //----------------------- End code -------------------- ////////


        //----------------------- OpenPrintf -------------------- ////////
        private void BTPrintfShare_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }
        //----------------------- End code -------------------- ////////

        private void membership_Load(object sender, EventArgs e)
        {
            //Method.SQLMethod.ExecuteMSSQL(SQLDefault[0]
            //    .Replace("{TeacherNo}", "T00000")
            //    .Replace("{StartAmount}", "500"));
        }


        // ใช้งานเเน่นอนไม่ต้องลบนะครับ
        private void T()
        {
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


        //----------------------- MetodPrintf -------------------- ////////
        // Comment!
        public void Center(System.Drawing.Printing.PrintPageEventArgs e, float LocY, String Text, Font fontText, Brush brush)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            float StartLoc = e.PageBounds.Width / 2 - SizeString.Width / 2; e.Graphics.DrawString(Text, fontText, brush, new PointF(StartLoc, LocY));
        }
        // Comment!
        public void CenterRight(System.Drawing.Printing.PrintPageEventArgs e, string Text, Font fontText, Brush brush, float X, float Y, float Pointplus, float Pointdelete)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            X = X - SizeString.Width; e.Graphics.DrawString(Text, fontText, brush, new PointF(Pointplus + X - Pointdelete, Y));
        }
        // Comment!
        public void CenterLeft(System.Drawing.Printing.PrintPageEventArgs e, string Text, Font fontText, Brush brush, float X, float Y, float Pointplus, float Pointdelete)
        {
            e.Graphics.DrawString(Text, fontText, brush, new PointF(Pointplus + X - Pointdelete, Y));
        }
        // Comment!
        public int Centerset(System.Drawing.Printing.PrintPageEventArgs e, string Text, Font fontText, Brush brush, float X, float Y, float Rfwidth, float height, Boolean Debug = false)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText, (int)Rfwidth);
            float startingpoint = X + 750 - Rfwidth;
            if (Debug)
            {
                e.Graphics.DrawRectangle(Pens.Black, startingpoint, Y, Rfwidth, height);
            }
            float upheight = 40; int ExtraRow;
            if (SizeString.Height < height)
            {
                ExtraRow = (Convert.ToInt32(SizeString.Height) / Convert.ToInt32(upheight) + 1);
            }
            else
            {
                SizeString.Height = height;
                ExtraRow = (Convert.ToInt32(SizeString.Height) / Convert.ToInt32(upheight) + 1);
            }
            e.Graphics.DrawString(Text, fontText, brush, new RectangleF(startingpoint, Y, Rfwidth, height));
            return ExtraRow;
        }
        //----------------------- End code -------------------- ////////
        public void ExpPrint()
        {
            //int ExtraRow = (Convert.ToInt32(SizeString.Height) / Convert.ToInt32(Rfwidth) + 1);
            // loop text //
            //for (int x = 0; x < 20; x++)
            //    e.Graphics.DrawString("Test",
            //        Normal01, Normal, new PointF(X, Y + (SpacePerRow * CurrentRows++)));

            //กำหนด จุดสิ้นสุด * วาดตาราง //
            //e.Graphics.DrawString("Testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt",
            //    Normal01, Normal, new RectangleF(X, Y + (SpacePerRow * CurrentRows++), 200f, 200f));

            //print normal //
            //e.Graphics.DrawString("Testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt",
            //    Normal01, Normal, new PointF(X, Y + (SpacePerRow * CurrentRows++)-50));

            //e.Graphics.DrawString(DTPStartDate.Text, new Font("TH Sarabun New",18, FontStyle.Regular), Brushes.Black, new PointF(0, 60));

            //SizeF SizeString = e.Graphics.MeasureString(Text, Header01);
            //float StartLoc = PageX / 2 - SizeString.Width / 2;
            //e.Graphics.DrawString(Text,
            //    Header01, Normal, new PointF(StartLoc, Y + (SpacePerRow * CurrentRows++)-10));
        }

        //----------------------- Printf -------------------- ////////
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // X 850 = 22 cm เเนะนำ 800 //
            // A4 = 21 cm  {Width = 356.70163 Height = 136.230438} {Width = 356.70163 Height = 102.954086} // 
            int PageX = (e.PageBounds.Width);
            int PageY = (e.PageBounds.Height);
            int XP = 0;
            int XD = 0;
            int X = 50;
            int Y = 50;
            int SpacePerRow = 35;
            int CurrentRows = 0;


            Font Header01 = new Font("TH Sarabun New", 30, FontStyle.Bold);
            Font Normal01 = new Font("TH Sarabun New", 18, FontStyle.Regular);
            Brush Normal = Brushes.Black;
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[2].Replace("{TeacherNo}",TBTeacherNo.Text));

            //----------------------

            string D, M, y, m;
            D = DTPStartDate.Text; y = D; M = y;
            D = D.Remove(2, D.Length - 2); y = y.Remove(0, y.Length - 4); M = M.Remove(M.Length - 4, 4);
            m = M; m = m.Remove(0, 2);
            //------------------------

            // ส่วนหัว
            Center(e, Y + (SpacePerRow * CurrentRows++), "ใบสมัครสมาชิกสหกรณ์ครู", Header01, Normal);
            Center(e, Y + (SpacePerRow * CurrentRows++), "วิทยาลัยเทคโนโลยี อีอีซีเอ็นจิเนีย แหลมฉบัง", Header01, Normal);
            // วันที่
            string MemberID = "สมาชิกเลขที่ " + dt.Rows[0][0].ToString();
            string School = "เขียนที่ วิทยาลัยเทคโนโลยี อีอีซีเอ็นจิเนีย แหลมฉบัง";
            string Enter = "\r\n";
            
            // ข้อมูลส่วนตัว
            string Name = "ข้าพเจ้า " + dt.Rows[0][1].ToString();
            string IdCardNum = "เลขประจำตัวประชาชน " + dt.Rows[0][2].ToString();
            string HouseNum = "อยู่บ้านเลขที่ "+ dt.Rows[0][3].ToString();
            string Village = "หมู่ " + dt.Rows[0][4].ToString();
            string SubDistrict = "ตำบล " + dt.Rows[0][5].ToString();
            string District = "อำเภอ " + dt.Rows[0][6].ToString();
            string Province = "จังหวัด " + dt.Rows[0][7].ToString();
            string TelNo = "เบอร์โทร " + dt.Rows[0][8].ToString();

            //รายละเอียด
            string amountbauy = "ข้อ 2 ข้าพเจ้าขอถือหุ้นของกิจกรรมสหกรณ์ครู ซึ่งมีค่าหุ้นล่ะ 500 บาท";
            string buy = $"2.1 ข้อซื้อหุ้นจำนวน{TBStartAmountShare.Text}หุ้น";
            string share = "2.2 รับโอนหุ้นจาก -";
            string Who = "สมาชิกเลขที่ -";
            string quantity = "จำนวน - หุ้น (ถ้ามี)";
            string price = "เเละชำระค่าหุ้น - บาท ทันทีที่ได้รับเเจ้งให้เข้าเป็นสมาชิก";

            CurrentRows += Centerset(e, $"{MemberID}{Enter}" +
                                                  $"{School}{Enter}" +
                                                  $"วันที่ {D} เดือน {m} พ.ศ. {y}{Enter}",
                      Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++), 400f, 200, false);

            CenterLeft(e, "ถึงคณะกรรมการดำเนืนการกิจกรรมสหกรณ์ครูวิทยาลัยเทคโนโลยีอีอีซี เอ็นจิเนีย เเหลมฉบัง", Normal01, Normal, X+XD, Y + (SpacePerRow * CurrentRows++), XP, XD);


            CurrentRows += Centerset(e, $"{Name} {IdCardNum}{Enter}" +
                                       $"{HouseNum} {Village}{Enter}" +
                                       $"{SubDistrict} {District}{Enter}" +
                                       $"{Province} {TelNo}{Enter}", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++), 700, 200, false);


            CurrentRows += Centerset(e, "ได้ทราบข้อบังคับของกิจกรรมสหกรณ์ครูวิทยาลัยเทคโนโลยีอีอีซี เอ็นจิเนีย เเหลมฉบัง ขอสมัครเป็นสมาชิกของสหกรณ์ครู  เเละขอให้คำเป็นหลักฐานดังต่อไปนี้", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows), 750, 200, false);

            string status = "ข้อที่ 1 ข้าพเจ้าเป็นผู้มีคุณสมบัติถูกต้องตามข้อบังคับทุกประการ";
            string teacher = "1.เป็นครู - อาจารย์";
            string officer = "2.เป็นเจ้าหน้าที่ - ภารโรง";

            CurrentRows += Centerset(e, $"{status}{Enter}" +
                                        $"  {teacher}{Enter}" +
                                        $"  {officer}{Enter}", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++), 700, 200, false);

            CurrentRows += Centerset(e, $"{amountbauy}{Enter}" +
                                       $"  {buy}{Enter}" +
                                       $"  {share} {Who}{Enter}" +
                                       $"{quantity} {price}{Enter}", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++), 700, 200, false);

            CurrentRows += Centerset(e, "ข้อที่ 3 เมื่อ ข้าพเจ้าเป็นสมาชิกจะปฎิบัติตามข้อบังคับทุกประการ เเละจะพยายามส่งเสริมให้กิจกรรมสหกณ์ครูให้เจริญก้าวหน้ายิี่งขึ้นไป", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++), 750, 700);
            //// ตกลง
            //CurrentRows += Centerset(e, "ลงชื่อ......................................................." +
            //                            "(..............................................................)", Normal01, Normal, X + 400, Y + (SpacePerRow * CurrentRows++) + 50, 400, 700);

            //CenterRight(e, "ผู้สมัคร", Normal01, Normal, X + 550, Y + (SpacePerRow * CurrentRows++) + 50, XP, XD);

        }

        private void BTOpenfile_Click(object sender, EventArgs e)
        {

        }

        private void TBTeacherNo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void TBTeacherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[1].Replace("T{TeacherNo}", TBTeacherNo.Text));
                TBTeacherName.Text = dt.Rows[0][1].ToString();
                TBIDNo.Text = "รอใส่จ้าาา";
            }
        }

        private void BTdeletefile_Click(object sender, EventArgs e)
        {

        }
        //----------------------- End code -------------------- ////////




        // ------------------------ not working --------------
        //----------------------- End code -------------------- ////////


    }
}
            
            
       
          
