﻿using System;
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
        /// <para>[0] SELECT Teachar IN Mont INPUT: {TeacherNo} </para> 
        /// <para>[1] SELECT not pay IN Mont INPUT: {CByear} {CBMonth} </para> 
        /// <para>[2] SELECT TIME INPUT : - </para>
        /// <para>[3] SELECT MEMBER INPUT: {TeacherNo} </para>
        /// </summary> 
        private String[] SQLDefault = new String[]
         {
          //[0] SELECT Teachar IN Mont INPUT: {TeacherNo}
            "SELECT a.TeacherNo , CAST(c.PrefixName+' '+Fname +' '+ Lname as NVARCHAR),f.TypeName,a.StartAmount,a.DateAdd \r\n" +
            "FROM EmployeeBank.dbo.tblMember as a \r\n" +
            "LEFT JOIN Personal.dbo.tblTeacherHis as b ON a.TeacherNo = b.TeacherNo \r\n" +
            "LEFT JOIN BaseData.dbo.tblPrefix as c ON b.PrefixNo = c.PrefixNo \r\n" +
            "LEFT JOIN EmployeeBank.dbo.tblBill as d ON a.TeacherNo = d.TeacherNo \r\n" +
            "LEFT JOIN EmployeeBank.dbo.tblBillDetail as e ON d.BillNo = e.BillNo \r\n" +
            "LEFT JOIN EmployeeBank.dbo.tblBillDetailType as f ON e.TypeNo = f.TypeNo \r\n" +
            "WHERE a.TeacherNo LIKE 'T%' AND e.Mount  IS NULL  AND e.Year IS NULL AND a.MemberStatusNo = 1 AND DATEPART(mm,a.DateAdd) = DATEPART(mm,GETDATE()); "
          ,
          //[1] SELECT not pay IN Mont INPUT: {CByear} {CBMonth}
            "SELECT a.TeacherNo,CAST(e.PrefixName+' '+Fname +' '+ Lname as NVARCHAR) as fname,f.TypeName,a.StartAmount \r\n"+
            "FROM EmployeeBank.dbo.tblMember as a \r\n"+
            "LEFT JOIN EmployeeBank.dbo.tblBill as b on a.TeacherNo = b.TeacherNo \r\n"+
            "LEFT JOIN EmployeeBank.dbo.tblBillDetail as c on b.BillNo = c.BillNo \r\n"+
            "LEFT JOIN Personal.dbo.tblTeacherHis as d on a.TeacherNo = d.TeacherNo \r\n"+
            "LEFT JOIN BaseData.dbo.tblPrefix as e on d.PrefixNo = e.PrefixNo \r\n"+
            "LEFT JOIN EmployeeBank.dbo.tblBillDetailType as f on c.TypeNo = f.TypeNo \r\n"+
            "WHERE a.TeacherNo NOT IN \r\n"+
            "(SELECT aa.TeacherNo FROM EmployeeBank.dbo.tblBill as aa \r\n"+
            "LEFT JOIN EmployeeBank.dbo.tblBillDetail as bb on aa.BillNo = bb.BillNo \r\n"+
            "WHERE bb.Mount = {CBMonth} and bb.Year = {CByear}) \r\n"+
            "GROUP BY a.TeacherNo,CAST(e.PrefixName+' '+Fname +' '+ Lname as NVARCHAR) ,f.TypeName,a.StartAmount \r\n"+
            "ORDER BY Fname;"
          ,
          //[2] SELECT TIME INPUT : -
          "SELECT CONVERT (DATE , CURRENT_TIMESTAMP); "
          ,
          //[3] SELECT MEMBER INPUT: {TeacherNo} 
          "SELECT a.TeacherNo ,  CAST(c.PrefixName+' '+Fname +' '+ Lname as NVARCHAR),a.StartAmount \r\n"+
          "FROM EmployeeBank.dbo.tblMember as a \r\n"+
          "LEFT JOIN Personal.dbo.tblTeacherHis as b ON a.TeacherNo = b.TeacherNo \r\n"+
          "LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = b.PrefixNo \r\n"+
          "WHERE a.TeacherNo LIKE 'T%' and MemberStatusNo = 1 \r\n"+
          "ORDER BY Fname;"
          ,

         };

        public Home()
        {
            InitializeComponent();
            /
          
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
                Bank.Search IN = new Bank.Search(SQLDefault[3].Replace("{TeacherNo}",""));
                IN.ShowDialog();
                TBTeacherNo.Text = Bank.Search.Return[0];
                TBTeacherNo_KeyDown(sender, new KeyEventArgs(Keys.Enter));
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
                    DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[3].Replace("{TeacherNo}", TBTeacherNo.Text));
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
        private void Home_Load(object sender, EventArgs e)
        {
            DataTable date = Class.SQLConnection.InputSQLMSSQL(SQLDefault[2]);
            int Year = Convert.ToInt32((Convert.ToDateTime(date.Rows[0][0])).ToString("yyyy"));
            for (int x = 0; x < 4; x++)
            {
                CByear.Items.Add(Year);
                Year--; 
            }
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[1]
                .Replace("yaer", Year.ToString())
                .Replace("Month",(Convert.ToDateTime(date.Rows[0][0])).ToString("MM")));
            for (int num = 0; num < dt.Rows.Count; num++)
            {
                dataGridView3.Rows.Add(dt.Rows[num][0], dt.Rows[num][1], "สะสม", dt.Rows[num][3]);
            }
        }

        private void automatic_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLDefault[1]
                .Replace("{CBMonth}", CBMonth.Text)
                .Replace("{CByear}", CByear.Text));
            if(dt.Rows.Count != 0)
            {
                for(int num = 0; num < dt.Rows.Count; num++)
                {
                    dataGridView3.Rows.Add(dt.Rows[num][0], dt.Rows[num][1], "สะสม", dt.Rows[num][3]);
                }
            }
        }

        private void CBMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CByear.SelectedIndex != -1)
            {
                automatic.Enabled = true;
            }
        }

        private void CByear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CByear.SelectedIndex != -1)
            {
                CBMonth.Enabled = true;
            }
        }
    }
}

