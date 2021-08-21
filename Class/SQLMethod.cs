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
    class SQLMethod
    {

        /// <summary> 
        /// SQLDafault 
        /// <para>[0] Write to Search ID Teacher INPUT: {TeacherNo} </para> 
        /// <para>[1] Check Register INPUT: {TeacherNo} </para>
        /// <para>[2] INSERT Register Member INPUT:  {TeacherNo} {TeacherAddBy} {StartAmount} {DocPath} </para>
        /// <para>[3] Search Member INPUT: -</para>
        /// <para>[4] paydataMember INPUT:{TeacherNo} {TeacherLicenseNo} {TeacherIdNo} {TelMobile} {MemberStatusName} {StartAmount}  </para>
        /// </summary> 
        private static String[] SQLDefault = new String[]
         { 

          //[0] Write to Search & Search All ID Teacher INPUT: {TeacherNo}
          "SELECT [TeacherNo],CAST(c.PrefixName+' '+[Fname] +' '+ [Lname] as NVARCHAR),[IdNo]  \r\n " +
          "FROM[Personal].[dbo].[tblTeacherHis] as a  \r\n " +
          "LEFT JOIN Personal.dbo.tblGroupPosition as b ON a.GroupPositionNo = b.GroupPositionNo  \r\n " +
          "LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = a.PrefixNo \r\n " +
          "WHERE TeacherNo LIKE 'T{TeacherNo}%' \r\n " +
          "ORDER BY TeacherNo; "
          ,
          //[1] Check Register INPUT: TeacherNo
          "SELECT * \r\n " +
          "FROM EmployeeBank.dbo.tblMember \r\n " +
          "WHERE TeacherNo = '{TeacherNo}'; "
          ,
         //[2] INSERT Register Member INPUT:  {TeacherNo} {TeacherAddBy} {StartAmount} {DocPath}
          "INSERT INTO EmployeeBank.dbo.tblMember(TeacherNo,TeacherAddBy,StartAmount,DocUploadPath,DateAdd) \r\n " +
          "VALUES('{TeacherNo}','{TeacherAddBy}',{StartAmount},'{DocPath}',CURRENT_TIMESTAMP); "
          ,
         //[3] Search Member INPUT: -
          "SELECT a.TeacherNo,CAST(d.PrefixName+' '+Fname +' '+ Lname as NVARCHAR),IdNo \r\n " +
          "FROM EmployeeBank.dbo.tblMember as a \r\n " +
          "LEFT JOIN Personal.dbo.tblTeacherHis as b ON a.TeacherNo = b.TeacherNo \r\n " +
          "LEFT JOIN Personal.dbo.tblGroupPosition as c ON b.GroupPositionNo = c.GroupPositionNo \r\n " +
          "LEFT JOIN BaseData.dbo.tblPrefix as d ON d.PrefixNo = b.PrefixNo \r\n " +
          "WHERE a.MemberStatusNo = 1 \r\n" +
          "ORDER BY a.TeacherNo; "
          ,
         //[4]  paydataMember INPUT:{TeacherNo}
          "SELECT Pn.TeacherLicenseNo,Pn.IdNo,Pn.TelMobile,CAST(Ms.MemberStatusName as nvarchar),Mb.StartAmount" +
          "FROM[Personal].[dbo].[tblTeacherHis] as PnINNER " +
          "JOIN EmployeeBank.dbo.tblMember as Mb on Pn.TeacherNo = Mb.TeacherNoINNER " +
          "JOIN EmployeeBank.dbo.tblMemberStatus as Ms on Mb.MemberStatusNo = Ms.MemberStatusNoWHERE    " +
          "Mb.TeacherNo LIKE '{TeacherNo}' " +
          "ORDER BY Mb.TeacherNo;"
          ,


         };

        public static void Research(string TBTeacherNo, TextBox TBTeacherName, TextBox TBTeacherBill )
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[0].Replace("T{TeacherNo}", TBTeacherNo));
            if (dt.Rows.Count != 0)
            {
                TBTeacherName.Text = dt.Rows[0][1].ToString();
                TBTeacherBill.Text = dt.Rows[0][2].ToString();
            }
        }
        ///<summary>
        /// <para>[AllTeacher_or_Member]</para> 
        /// <para>ถ้าใส่ 0 จะหาอาจารย์ทั้งหมด</para>
        /// <para>ใส่ 1 จะหาแค่อาจารยฺ์ที่สมัครสมาชิกแล้ว ( สถาณะ ใช้งานเท่านั้น )</para>
        ///</summary>
        public static void Search(DataGridView G , int AllTeacher_or_Member)
        {
            int y = 0;

            if (AllTeacher_or_Member == 1)
            {
                y = 3;
            }
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[y].Replace("{TeacherNo}",""));
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

        public static void paydataMember(string TeacherNo,TextBox TeacherLicenseNo,TextBox TeacherIdNo,TextBox TelMobile ,TextBox MemberStatusName,TextBox StartAmount)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL
            (SQLDefault[4].Replace("{TeacherNo}",TeacherNo));
            if (dt.Rows.Count != 0)
            {
                TeacherLicenseNo.Text = dt.Rows[0][1].ToString();
                TeacherIdNo.Text = dt.Rows[0][2].ToString();
                TelMobile.Text = dt.Rows[0][3].ToString();
                MemberStatusName.Text = dt.Rows[0][4].ToString();
                StartAmount.Text = dt.Rows[0][5].ToString();
            }
                
            
        }



        public static void TeacherMember(string TeacherNo,string TeacherAddBy, int StartAmount, string DocUploadPath)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[1].Replace("{TeacherNo}",TeacherNo));
            if (TeacherNo != "")
            {
                if (dt.Rows.Count == 0)
                {
                    DataTable INSERTMember = Class.SQLConnection.InputSQLMSSQL(SQLDefault[2].Replace("{TeacherNo}", TeacherNo)
                        .Replace("{TeacherAddBy}", TeacherAddBy)
                        .Replace("{StartAmount}", StartAmount.ToString())
                        .Replace("{DocPath}",DocUploadPath));
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
