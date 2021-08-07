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
    public partial class MemberShip : Form
    {
        static int POSX = 800;
        // <summary>
		// SQLDafault
		// <para>[0] Insert Teacher Data INPUT:{TeacherNo}, {StartAmount} </para>
        // <para>[1]</para>
		// </summary>
		private String[] SQLDefault = new String[]
        {
			//[0] Insert Teacher Data INPUT:{TeacherNo}, {StartAmount} 
			//"INSERT INTO EmployeeBank.dbo.tblMember(TeacherNo,StartAmount,DateAdd) \r\n"+
   //         "VALUES('{TeacherNo}',{StartAmount}, CURRENT_TIMESTAMP); \r\n\r\n",

            //[1]

            //"SELECT * \r\n"
            //FROM EmployeeBank.dbo.tblMember
            //WHERE TeacherNo = ''
            //ORDER BY TeacherNo;
        };

        //List<String> PrintData;


        public MemberShip()
        {
            InitializeComponent();
            //Class.UserInfo.GetTeacherNo();
        }

        private void membership_Load(object sender, EventArgs e)
        {
            //Method.SQLMethod.ExecuteMSSQL(SQLDefault[0]
            //    .Replace("{TeacherNo}", "T00000")
            //    .Replace("{StartAmount}", "500"));
        }

        private void membership_SizeChanged(object sender,EventArgs e)
        {
            Method.SQLMethod.ChangeSizePanal(this,panel1);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Method.SQLMethod.Research(TBTeacherNo.Text, TBTeacherName,TBIDNo);
        }
        private void TBStartAmountShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
            Search IN = new Search();
            IN.ShowDialog();
            TBTeacherNo.Text = Search.Return[0];
        }
        private void BSave_Click(object sender, EventArgs e)
        {
            //Method.SQLMethod.TeacherMember(TBTeacherNo.Text,int.Parse(TBStartAmountShare.Text), button1.Text);
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Image File;
            //String imgeLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //imgeLocation = dialog.FileName;
                    File = Image.FromFile(dialog.FileName);
                    pictureBox1.Image = File;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void Center(System.Drawing.Printing.PrintPageEventArgs e, float LocY , String Text, Font fontText, Brush brush)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            float StartLoc = e.PageBounds.Width / 2 - SizeString.Width / 2;e.Graphics.DrawString(Text,fontText, brush, new PointF(StartLoc, LocY));
        }
        public void CenterRight(System.Drawing.Printing.PrintPageEventArgs e,string Text,Font fontText, Brush brush, float X, float Y,float Pointplus,float Pointdelete)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);
            X = X - SizeString.Width; e.Graphics.DrawString(Text, fontText, brush, new PointF(Pointplus+X-Pointdelete,Y));
        }
        public void CenterLeft(System.Drawing.Printing.PrintPageEventArgs e, string Text, Font fontText, Brush brush, float X, float Y, float Pointplus, float Pointdelete)
        {
            e.Graphics.DrawString(Text, fontText, brush, new PointF(Pointplus + X - Pointdelete, Y));
        }
        public void Centerset(System.Drawing.Printing.PrintPageEventArgs e, string Text, Font fontText, Brush brush, float X,  float Y,int add, float set)
        {
            SizeF SizeString = e.Graphics.MeasureString(Text, fontText);    
            if(SizeString.ToString().Length >= 80)
            {
                add = 1;
            }
            else if (SizeString.ToString().Length >= 160)
            {
                add = 2;
            }
            else
            {
                add = 3;
            }
            e.Graphics.DrawString(Text,fontText,brush, new RectangleF(X, Y, set, 200f));
        }
        public void ExpPrint()
        {
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
        
        private void printDocument1_PrintPage(object sender,System.Drawing.Printing.PrintPageEventArgs e)
        {
            // X 850 = 22 cm เเนะนำ 800 //
            // A4 = 21 cm   // 
            int PageX = (e.PageBounds.Width);
            int PageY = (e.PageBounds.Height);
            int XP = 0;
            int XD = 0;
            int X = 50;
            int Y = 50;
            int SpacePerRow = 35;
            int CurrentRows = 0;
            int add = 0;
          
            Font Header01 = new Font("TH Sarabun New", 30, FontStyle.Bold);
            Font Normal01 = new Font("TH Sarabun New", 18, FontStyle.Regular);
            Brush Normal = Brushes.Black;
            
          
            Center(e, Y + (SpacePerRow * CurrentRows++) - 10, "ใบสมัครสมาชิกสหกรณ์ครู", Header01, Normal);
            Center(e, Y +(SpacePerRow * CurrentRows++) - 10, "วิทยาลัยเทคโนโลยี อีอีซีเอ็นจิเนีย แหลมฉบัง", Header01, Normal);

            CenterRight(e, "สมาชิกเลขที่................", Normal01, Normal,X+750, Y + (SpacePerRow * CurrentRows++), XP, XD);
            CenterRight(e, "เขียนนที่...........................................................", Normal01, Normal,X+750, Y + (SpacePerRow * CurrentRows++), XP, XD);
            CenterRight(e, "วันที่.........เดือน...................................พ.ศ.......................", Normal01, Normal,X+750, Y + (SpacePerRow * CurrentRows++), XP, XD);

            CenterLeft(e, "ถึงคณะกรรมการดำเนืนการกิจกรรมสหกรณ์ครูวิทยาลัยเทคโนโลยีอีอีซี เอ็นจิเนีย เเหลมฉบัง", Normal01, Normal,  X, Y + (SpacePerRow * CurrentRows++), XP, XD);
            CenterRight(e, "ข้าพเจ้า.........................................................เลขประจำตัวประชาชน..........................................................", Normal01, Normal,X+750, Y + (SpacePerRow * CurrentRows++), XP, XD);
            CenterRight(e, "อยู่บ้านเลขที่......................................หมู่....................ตำบล..................................อำเภอ........................................", Normal01, Normal, X + 750, Y + (SpacePerRow * CurrentRows++), XP, XD);
            CenterRight(e, "จังหวัด...........................................................................เบอร์โทร.............................................................................", Normal01, Normal, X + 750, Y + (SpacePerRow * CurrentRows++), XP, XD);

            Centerset(e, "ได้ทราบข้อบังคับของกิจกรรมสหกรณ์ครูวิทยาลัยเทคโนโลยีอีอีซี เอ็นจิเนีย เเหลมฉบัง ขอสมัครเป็นสมาชิกของสหกรณ์ครู  เเละขอให้คำเป็นหลักฐานดังต่อไปนี้", Normal01, Normal,X, Y + (SpacePerRow * CurrentRows++),add,700);

            CenterLeft(e, "ข้อที่ 1 ข้าพเจ้าเป็นผู้มีคุณสมบัติถูกต้องตามข้อบังคับทุกประการ", Normal01, Normal,X, Y + (SpacePerRow * CurrentRows++ + 35), XP + 50, XD);
            CenterLeft(e, "1.เป็นครู - อาจารย์", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++ + 35), XP + 70, XD);
            CenterLeft(e, "2.เป็นเจ้าหน้าที่ - ภารโรง", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++ + 35), XP + 70, XD);

            CenterLeft(e, "ข้อ 2 ข้าพเจ้าขอถือหุ้นของกิจกรรมสหกรณ์ครู ซึ่งมีค่าหุ้นล่ะ 500 บาท", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++ + 35), XP + 50, XD);
            CenterLeft(e, "2.1 ข้อซื้อหุ้นจำนวน...................หุ้น", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++ + 35), XP + 70, XD);
            CenterLeft(e, "2.2 รับโอนหุ้นจาก........................................................สมาชิกเลขที่.........................................................", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++ + 35), XP + 70, XD);
           
            Centerset(e, "จำนวน..............................หุ้น (ถ้ามี) เเละชำระค่าหุ้น.....................................................บาท ทันทีที่ได้รับเเจ้งให้เข้าเป็นสมาชิก", Normal01, Normal, X, Y + (SpacePerRow * CurrentRows++ +35), add, 700);

            Centerset(e, "ข้อที่ 3 เมื่อ ข้าพเจ้าเป็นสมาชิกจะปฎิบัติตามข้อบังคับทุกประการ เเละจะพยายามส่งเสริมให้กิจกรรมสหกณ์ครูให้เจริญก้าวหน้ายิี่งขึ้นไป", Normal01, Normal, X+50, Y + (SpacePerRow * CurrentRows++ + 70), add, 700);

            CenterRight(e, "ลงชื่อ.........................................................", Normal01, Normal, X+750, Y + (SpacePerRow * CurrentRows++ + 200), XP, XD);
            CenterRight(e, "(..............................................................)", Normal01, Normal, X + 750, Y + (SpacePerRow * CurrentRows++ + 210), XP, XD);
            CenterRight(e, "ผู้สมัคร", Normal01, Normal, X + 750, Y + (SpacePerRow * CurrentRows++ + 220), XP, XD+100);
            //Center(e, Y + (SpacePerRow * CurrentRows++) - 10, "สมาชิกเลขที่", Normal01, Normal);
        }
    }
}
