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
        /// <para>[1] INSERT Register Member INPUT:  {TeacherNo} {TeacherAddBy} {StartAmount} {DocPath} </para>
        /// <para>[2] Search LoanMember INPUT: {TeacherNo} </para>
        /// <para>[3]  AmountpayANDAmountLoanINMonth INPUT: {TeacherNo}  </para>
        ///   <para>[4] CheckAmount INPUT: -  </para>
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
         //[1] INSERT Register Member INPUT:  {TeacherNo} {TeacherAddBy} {StartAmount} {DocPath}
          "INSERT INTO EmployeeBank.dbo.tblMember(TeacherNo,TeacherAddBy,StartAmount,DocUploadPath,DateAdd) \r\n " +
          "VALUES('{TeacherNo}','{TeacherAddBy}',{StartAmount},'{DocPath}',CURRENT_TIMESTAMP); "
          ,     
          //[2] Search LoanMember INPUT: {TeacherNo}
          "SELECT Mb.TeacherNo , CAST(c.PrefixName+' '+[Fname] +' '+ [Lname] as NVARCHAR)AS Name, b.IdNo AS TeacherID, \r\n " +
          "b.TeacherLicenseNo,b.IdNo AS IDNo,b.TelMobile,d.LoanNo,\r\n " +
          "e.LoanStatusName,Mb.StartAmount,f.SavingAmount,CAST(Ms.MemberStatusName as nvarchar) AS UserStatususing \r\n " +
          "FROM EmployeeBank.dbo.tblMember as Mb \r\n " +
          "LEFT JOIN Personal.dbo.tblTeacherHis as b ON Mb.TeacherNo = b.TeacherNo \r\n " +
          "LEFT JOIN BaseData.dbo.tblPrefix as c ON b.PrefixNo = c.PrefixNo \r\n " +
          "LEFT JOIN EmployeeBank.dbo.tblLoan as d ON Mb.TeacherNo = d.TeacherNo \r\n " +
          "LEFT JOIN EmployeeBank.dbo.tblLoanStatus as e ON d.LoanStatusNo = e.LoanStatusNo \r\n " +
          "LEFT JOIN EmployeeBank.dbo.tblShare as f ON Mb.TeacherNo = f.TeacherNo \r\n " +
          "INNER JOIN EmployeeBank.dbo.tblMemberStatus as Ms on Mb.MemberStatusNo = Ms.MemberStatusNo \r\n " +
          "WHERE Mb.TeacherNo LIKE 'T{TeacherNo}%' and Mb.MemberStatusNo = 1 \r\n " +
          "ORDER BY Mb.TeacherNo;"
          ,
          //[3] AmountpayANDAmountLoanINMonth INPUT: {TeacherNo}
          "SELECT Mb.TeacherNo,Mb.StartAmount AS  Amountpay,Mb.DateAdd AS Datepay,Lp.Amount AS AmountLoan,Ln.DateAdd AS DateLoan \r\n"+
          "FROM EmployeeBank.dbo.tblMember as Mb\r\n"+
          "LEFT JOIN EmployeeBank.dbo.tblLoan as Ln on Mb.TeacherNo = Ln.TeacherNo\r\n"+
          "LEFT JOIN EmployeeBank.dbo.tblLoanPay as Lp  on Ln.TeacherNo = Lp.TeacherNo\r\n" +
          "WHERE Mb.TeacherNo = '{TeacherNo}';"
          ,
          //[4] CheckAmount INPUT: -
           "SELECT Bi.TeacherNo,Bi.BillNo,Bd.BillDetailNo,TeacherNoAddBy,TeacherNo,Cancel,Bd.Date,CAST(Bt.TypeName as nvarchar),Bd.Amount \r\n"+
           "FROM EmployeeBank.dbo.tblBill AS Bi\r\n"+
           "LEFT JOIN EmployeeBank.dbo.tblBillDetail As Bd on Bi.BillNo = Bd.BillNo\r\n"+
           "LEFT JOIN EmployeeBank.dbo.tblBillDetailType As Bt on Bd.TypeNo = Bt.TypeNo\r\n"+
           "WHERE   Bt.TypeName IS NULL AND Bd.Date IS NULL AND bd.Amount = 0;"
           ,
          //[5] INSERT Bill : {TeacherNo}
            "INSERT INTO EmployeeBank.dbo.tblBill(TeacherNoAddBy,TeacherNo)\r\n"+
            "VALUES('{}','{}')"
           ,
          //[5] INSERT BillDetail : {TeacherNo}
            "INSERT INTO EmployeeBank.dbo.tblBillDetail(BillNo,Date,TypeNo,Amount) \r\n"+
            "VALUES({},CURRENT_TIMESTAMP,{},{})"



    };

        //เช็ค ยอดจ่ายของสมาชิกในเดือน อัตโนมัติ
        public static void AmountpayANDAmountLoanINMonth(string TeacherNo,TextBox Amount,ComboBox SELECTINDAX)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[3].Replace("{TeacherNo}",TeacherNo));
            if(dt.Rows.Count != 0)
            {
                if(SELECTINDAX.SelectedItem.ToString() == "สะสม")
                {
                    Amount.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Amount.Text = dt.Rows[0][3].ToString();
                }
               
               
            }
        }

        // ค้นหารายชื่อผู้ลงทะเบียนในระบบครู ใส่หมายยเลข
        public static void ResearchUserAllTLC(string TBTeacherNo, TextBox TBTeacherName, TextBox TBTeacherIDNo)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[0].Replace("T{TeacherNo}", TBTeacherNo));
            if (dt.Rows.Count != 0)
            {
                TBTeacherName.Text = dt.Rows[0][1].ToString();
                TBTeacherIDNo.Text = dt.Rows[0][2].ToString();
            }
        }
        // ค้นหารายชื่อผู้สมัครยอดสะสมโดยการ ใส่หมายยเลข
        public static void ResearhMerberANDinformation(string TeacherNo, TextBox TBTeacherName, TextBox TBTeacherIDNo, TextBox TeacherLicenseNo, TextBox TeacherIdNo, TextBox TelMobile, TextBox MemberStatusName, TextBox StartAmount)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[2].Replace("T{TeacherNo}%",TeacherNo));
            if (dt.Rows.Count != 0)
            {
                TBTeacherName.Text = dt.Rows[0][1].ToString();
                TBTeacherIDNo.Text = dt.Rows[0][2].ToString();
                TeacherLicenseNo.Text = dt.Rows[0][3].ToString();
                TeacherIdNo.Text = dt.Rows[0][4].ToString();
                TelMobile.Text = dt.Rows[0][5].ToString();
                StartAmount.Text = dt.Rows[0][8].ToString();
                MemberStatusName.Text = dt.Rows[0][10].ToString();
            }
        }
        // ค้นหารายชื่อผู้กู้โดยการ ใส่หมายยเลข
        public static void ReSearchLoan (string TBTeacherNo,TextBox TBTeacherNane,TextBox LoanNo, TextBox LoanStatusName, TextBox SavingAmount)
        {
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[2].Replace("T{TeacherNo}%", TBTeacherNo));
            if (dt.Rows.Count != 0)
            {
                TBTeacherNane.Text = dt.Rows[0][1].ToString(); 
                LoanStatusName.Text = dt.Rows[0][7].ToString();
                LoanNo.Text = dt.Rows[0][6].ToString();
                SavingAmount.Text = dt.Rows[0][9].ToString();
            }
        }
        ///<summary>
        /// <para>[AllTeacher_or_Member]</para> 
        /// <para>ถ้าใส่ 0 จะหาอาจารย์ทั้งหมด</para>
        /// <para>ใส่ 1 จะหาแค่อาจารยฺ์ที่สมัครสมาชิกแล้ว ( สถาณะ ใช้งานเท่านั้น ) Return : รหัสอาจารย์ ชื่อ เลขบัตรปชช.</para>
        /// <para>ใส่ 2 จะหาอาจารย์ที่สมัครสมาชิกแล้ว แต่มีข้อมูลสำหรับการกู้เพิ่มเข้ามา (สถาณะใช้งานเท่านั้น) Return : รหัสอาจารย์ ชื่อ เลขบัตรปชช. สถาณะ เลขที่สัญญากู้ หุ้นสะสม</para>
        ///</summary>
        public static void SearchINNserDataGridView(DataGridView G , int AllTeacher_or_Member)
        {
            int y = 0;

            if (AllTeacher_or_Member == 1)
            {
                y = 0;
            }
            else if(AllTeacher_or_Member == 2)
            {
                y = 2;
            }
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[y].Replace("{TeacherNo}",""));
            if (y == 0)
            {
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    G.Rows.Add(dt.Rows[x][0], dt.Rows[x][1], dt.Rows[x][2],"","","","");

                    if (x % 2 == 1)
                    {
                        G.Rows[x].DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                }
            }
            else if (y == 2)
            {
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    G.Rows.Add(dt.Rows[x][0], dt.Rows[x][1], dt.Rows[x][2], dt.Rows[x][3], dt.Rows[x][4], dt.Rows[x][5]);

                    if (x % 2 == 1)
                    {
                        G.Rows[x].DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                }
            }
        }
        // สมัครสมาชิกสหกร์ครู
        public static void INERApplyTeacher(string TeacherNo,string TeacherAddBy, int StartAmount, string DocUploadPath)
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
       
        // ถังขยะสำหรับโค้ดที่ไม่ได้ฝช้งานเเต่ต้องการเก็บไว้ศึกษา หรือ เก็บไว้
        public void CodeRecycleBin()
        {
            /// <para>[1] Check Register INPUT: {TeacherNo} </para>
            //  //[1] Check Register INPUT: TeacherNo
            //  "SELECT * \r\n " +
            //  "FROM EmployeeBank.dbo.tblMember \r\n " +
            //  "WHERE TeacherNo = '{TeacherNo}'; "
            //,

            /// <para>[3] Search Member INPUT: -</para>
            //  //[3] Search Member INPUT: -
            //  "SELECT a.TeacherNo,CAST(d.PrefixName+' '+Fname +' '+ Lname as NVARCHAR),IdNo \r\n " +
            //  "FROM EmployeeBank.dbo.tblMember as a \r\n " +
            //  "LEFT JOIN Personal.dbo.tblTeacherHis as b ON a.TeacherNo = b.TeacherNo \r\n " +
            //  "LEFT JOIN Personal.dbo.tblGroupPosition as c ON b.GroupPositionNo = c.GroupPositionNo \r\n " +
            //  "LEFT JOIN BaseData.dbo.tblPrefix as d ON d.PrefixNo = b.PrefixNo \r\n " +
            //  "WHERE a.MemberStatusNo = 1 \r\n" +
            //  "ORDER BY a.TeacherNo; "
            //,

            /// <para>[4] paydataMember INPUT:{TeacherNo} {TeacherLicenseNo} {TeacherIdNo} {TelMobile} {MemberStatusName} {StartAmount}  </para>
            //  //[4]  paydataMember INPUT:{TeacherNo}
            //  "SELECT Pn.TeacherLicenseNo,Pn.IdNo,Pn.TelMobile,CAST(Ms.MemberStatusName as nvarchar),Mb.StartAmount" +
            //  "FROM[Personal].[dbo].[tblTeacherHis] as PnINNER " +
            //  "JOIN EmployeeBank.dbo.tblMember as Mb on Pn.TeacherNo = Mb.TeacherNoINNER " +
            //  "JOIN EmployeeBank.dbo.tblMemberStatus as Ms on Mb.MemberStatusNo = Ms.MemberStatusNoWHERE    " +
            //  "Mb.TeacherNo LIKE '{TeacherNo}' " +
            //  "ORDER BY Mb.TeacherNo;"
            //,

        }
    }
}
