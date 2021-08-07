using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace example.Method
{
    class SQLMethod
    {        static OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=166.166.1.24;Initial Catalog=Poon_Item;" +
            "User ID=Rice;Password=0854649141asdnm;IntegratedSecurity=true;Encrypt=True;TrustServerCertificate=True;CharacterSet=SQL_Latin1_General_CP1_CI_AS;");

        public static DataSet InputSQLMSSQLDS(string SQLCode)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(SQLCode, con);
            con.Close();
            DataSet ds = new DataSet();
            da.Fill(ds, "Info");
            return ds;
        }

        public static void ChangeSizePanal(Form myForm, Panel myPanal)
        {
            myPanal.Location = new System.Drawing.Point(myForm.Width / 2 - myPanal.Size.Width / 2,
                myForm.Height / 2 - myPanal.Size.Height / 2);
        }
        public static void Research(string TBTeacherNo,TextBox TBTeacherName,TextBox TBTeacherBill)
        {
            DataSet ID = Method.SQLMethod.InputSQLMSSQLDS
           //("SELECT [TeacherNo],CAST([Fname] +' '+ [Lname] as NVARCHAR),[IdNo] FROM[Personal].[dbo].[tblTeacherHis]");
           ("SELECT [TeacherNo],CAST(c.PrefixName+' '+[Fname] +' '+ [Lname] as NVARCHAR),[IdNo] FROM[Personal].[dbo].[tblTeacherHis] as a LEFT JOIN Personal.dbo.tblGroupPosition as b ON a.GroupPositionNo = b.GroupPositionNo LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = a.PrefixNo");
            DataTable dt = ID.Tables[0];
            int count = dt.Rows.Count;

            for (int x = 0; x < count; x++)
            {
                if (TBTeacherNo == dt.Rows[x][0].ToString())
                {
                    TBTeacherName.Text = dt.Rows[x][1].ToString();
                    TBTeacherBill.Text = dt.Rows[x][2].ToString();
                    break;
                }
                else
                {
                    TBTeacherName.Text = "";
                    TBTeacherBill.Text = "";
                }
            }
        }
        public static void Search(DataGridView G)
        {
            DataSet Ds = Method.SQLMethod.InputSQLMSSQLDS
         ("SELECT [TeacherNo],CAST(c.PrefixName+' '+[Fname] +' '+ [Lname] as NVARCHAR),[IdNo] FROM[Personal].[dbo].[tblTeacherHis] as a LEFT JOIN Personal.dbo.tblGroupPosition as b ON a.GroupPositionNo = b.GroupPositionNo LEFT JOIN BaseData.dbo.tblPrefix as c ON c.PrefixNo = a.PrefixNo");

            DataTable dt = Ds.Tables[0];
            int count = dt.Rows.Count;
            for (int x = 0; x < count; x++)
            {
                if (dt.Rows[x][1] != null)
                {
                    G.Rows.Add(dt.Rows[x][0], dt.Rows[x][1], dt.Rows[x][2]);
                    if (x % 2 == 1)
                    {
                        G.Rows[x].DefaultCellStyle.BackColor = Color.AliceBlue;
                    }
                }
                //Color.AntiqueWhite
            }
        }

        public static void TeacherMember(string TeacherNo,int StartAmount,string DocUploadPath)
        {
            DataSet Mb = Method.SQLMethod.InputSQLMSSQLDS
            ($"INSERT INTO EmployeeBank.dbo.tblMember(TeacherNo,StartAmount,DocUploadPath,DateAdd)VALUES('{TeacherNo}',{StartAmount},'{DocUploadPath}',CURRENT_TIMESTAMP);");
        }

        public static void ExecuteMSSQL(string sql)
        {
            //try
            //{
            if (con.State == ConnectionState.Closed)
                con.Open();
            //create sql command
            System.Data.OleDb.OleDbCommand OC = con.CreateCommand();
            //input sql method
            OC.CommandText = sql;
            //execute sql method
            OC.ExecuteNonQuery();
            con.Close();
            //}
            //catch (Exception)
            //{
            //    conMSSQL.Close();
            //}
        }
              

    }
}
