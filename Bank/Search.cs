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
        /// <para>ใส่ 1 จะหาแค่อาจารยฺ์ที่สมัครสมาชิกแล้ว ( สถาณะ ใช้งานเท่านั้น )</para>
        ///</summary>
        public Search(int AllTeacher_or_Member)
        {
            InitializeComponent();
            Return = new String[]{""};
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Class.Method.Search(dataGridView1, AllTeacher_or_Member);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e, int AllTeacher_or_Member)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                Return = new String[]
                {
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()
                };
                this.Dispose();

            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
