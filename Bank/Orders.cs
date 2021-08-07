using System;
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
    public partial class Orders : Form
    {
        DataTable table = new DataTable("Table");
        int INDEX;
        public Orders()
        {
            InitializeComponent();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a ="",b ="";
            //dataGridView1.Rows.Add(textBox1.Text[0], textBox2.Text[1]/*, textBox3.Text, checkedListBox1.CheckedItems[0].ToString()*/);
           a = textBox1.Text;
           b = textBox2.Text;
            DataSet dss = Method.SQLMethod.InputSQLMSSQLDS
            ($"INSERT INTO Poon_Item.dbo.tblItem(ItemID,ItemName)VALUES('{a}','{b}');");
            //DataTable dt = dss.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pay prod = new pay();
            prod.Show();
            this.Hide();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Orders_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID",Type.GetType("System.String"));
            table.Columns.Add("ชื่อสินค้า", Type.GetType("System.String"));
            table.Columns.Add("ราคา", Type.GetType("System.String"));
            table.Columns.Add("ประเภท", Type.GetType("System.String"));
            dataGridView3.DataSource = table;

            DataSet ds = Method.SQLMethod.InputSQLMSSQLDS
            ("SELECT ItemID,CAST(ItemName as NVARCHAR) FROM Poon_Item.dbo.tblItem;");
           
            DataTable dt = ds.Tables[0];
            int count = dt.Rows.Count;
            for (int x = 0; x < count; x++)
            {
                dataGridView1.Rows.Add(dt.Rows[x][0], dt.Rows[x][1]);
                if (x % 2 == 1)
                {
                    dataGridView1.Rows[x].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }
            }

           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView3.Rows[INDEX];

            newdata.Cells[0].Value = textBox1.Text;
            newdata.Cells[1].Value = textBox2.Text;
            newdata.Cells[2].Value = textBox3.Text;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            INDEX = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[INDEX];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            INDEX = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(INDEX);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text != ""&&textBox4.Text != "")
            {
                textBox4.Text = textBox1.Text;
                textBox4.Show(); 
            }
        }

    }
}
