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

        public Search()
        {
            InitializeComponent();
            Return = new String[]{""};
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {
            Class.Method.Search(dataGridView1);
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
