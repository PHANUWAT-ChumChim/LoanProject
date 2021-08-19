using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace example.Class
{
    class Method
    {

        /// <summary> 
        /// SQLDafault 
        /// <para>[0] Write to Search ID Teacher INPUT: {TeacherNo} </para> 
        /// <para>[1] Check Register INPUT: {TeacherNo} </para>
        /// <para>[2] INSERT Register Member INPUT:  {TeacherNo} {StartAmount} {DocPath} </para>
        /// </summary> 
        private static String[] SQLDefault = new String[]
         { 

          //[0] Write to Search & Search All ID Teacher INPUT: {TeacherNo}
          "SELECT [TeacherNo],CAST(c.PrefixName+' '+[Fname] +' '+ [Lname] as NVARCHAR),[IdNo]  \r\n " +
          "FROM[Personal].[dbo].[tblTeacherHis] as a  \r\n " +
          "LEFT JOIN Personal.dbo.tblGroupPosition as b ON a.GroupPositionNo = b.GroupPositionNo  \r\n " +
          "LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = a.PrefixNo \r\n " +
          "WHERE TeacherNo LIKE 'T%' or TeacherNo = '{TeacherNo}' \r\n " +
          "ORDER BY TeacherNo; "
          ,
          //[1] Check Register INPUT: TeacherNo
          "SELECT * \r\n " +
          "FROM EmployeeBank.dbo.tblMember \r\n " +
          "WHERE TeacherNo = '{TeacherNo}'; "
          ,
         //[2] INSERT Register Member INPUT:  {TeacherNo} {StartAmount} {DocPath}
          "INSERT INTO EmployeeBank.dbo.tblMember(TeacherNo,StartAmount,DocUploadPath,DateAdd) \r\n " +
          "VALUES('{TeacherNo}',{StartAmount},'{DocPath}',CURRENT_TIMESTAMP); "
          ,

         };

        public static void ChangeSizePanal(Form myForm, Panel myPanal)
        {
            myPanal.Location = new System.Drawing.Point(myForm.Width / 2 - myPanal.Size.Width / 2,
            myForm.Height / 2 - myPanal.Size.Height / 2);
        }

        public static void Research(string TBTeacherNo, TextBox TBTeacherName, TextBox TBTeacherBill)
        {
            //ต้องพิมพ์รหัสอาจารย์ถึง 6 ตัวถึงจะเข้าเงื่อนไข if
            if(TBTeacherNo.Length == 6)
            {
                DataTable dt = Class.SQL.InputSQLMSSQL(SQLDefault[0].Replace("{TeacherNo}",TBTeacherNo));
                if(dt.Rows.Count != 0)
                {
                    TBTeacherName.Text = dt.Rows[0][1].ToString();
                    TBTeacherBill.Text = dt.Rows[0][2].ToString();
                }
            }
        }

        public static void Search(DataGridView G)
        {
            DataTable dt = Class.SQL.InputSQLMSSQL(SQLDefault[0]);
            int count = dt.Rows.Count;
            for (int x = 0; x < count; x++)
            {
                G.Rows.Add(dt.Rows[x][0], dt.Rows[x][1], dt.Rows[x][2]);
                if (x % 2 == 1)
                {
                    G.Rows[x].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }
        }


        public static void TeacherMember(string TeacherNo, int StartAmount, string DocUploadPath)
        {
            Font Header01 = new Font("TH Sarabun New", 30, FontStyle.Bold);
            Brush Normal = Brushes.Black;

            //string text = "โปรดเลือกสมาชิกในการสมัคร"
            DataTable dt = Class.SQL.InputSQLMSSQL(SQLDefault[1].Replace("{TeacherNo}",TeacherNo));
            if (TeacherNo != "")
            {
                if (dt.Rows.Count == 0)
                {
                    DataTable INSERTMember = Class.SQL.InputSQLMSSQL(SQLDefault[2].Replace("{TeacherNo}", TeacherNo)
                        .Replace("{StartAmount}", StartAmount.ToString()
                        .Replace("{DocPath}",DocUploadPath))) ;
                    MessageBox.Show("Register Complete.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("รายชื่อซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("โปรดเลือกสมาชิกในการสมัคร", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
