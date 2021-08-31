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
    public partial class Search : Form
    {
        public static String[] Return = {""};
        ///<summary>
        /// <para>[AllTeacher_or_Member]</para> 
        /// <para>ถ้าใส่ 0 จะหาอาจารย์ทั้งหมด</para>
        /// <para>ใส่ 1 จะหาแค่อาจารยฺ์ที่สมัครสมาชิกแล้ว ( สถาณะ ใช้งานเท่านั้น ) Return : รหัสอาจารย์ ชื่อ เลขบัตรปชช.</para>
        /// <para>ใส่ 2 จะหาอาจารย์ที่สมัครสมาชิกแล้ว แต่มีข้อมูลสำหรับการกู้เพิ่มเข้ามา (สถาณะใช้งานเท่านั้น) Return : รหัสอาจารย์ ชื่อ เลขบัตรปชช. สถาณะ เลขที่สัญญากู้ หุ้นสะสม</para>
        ///</summary>
        public Search(String SQLCode)
        {
            InitializeComponent();
            Return = new String[]{""};
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            DataTable dt = Class.SQLConnection.InputSQLMSSQL(SQLCode);
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                dataGridView1.Rows.Add(dt.Rows[x][0], dt.Rows[x][1],"");

                if (x % 2 == 1)
                {
                    dataGridView1.Rows[x].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Return = new String[]
                {
                        dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                };

                this.Dispose();

            }
        }
    }
}
