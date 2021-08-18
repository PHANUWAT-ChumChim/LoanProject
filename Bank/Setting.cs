using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace example.Bank
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            if (x == 0)
            {
                dt = Method.SQLMethod.InputSQLMSSQL(SQLDefault[0]);
                DateAmountChange = Convert.ToInt32(dt.Rows[0][0]);
                startAmountMin = Convert.ToInt32(dt.Rows[0][1]);
                startAmountMax = Convert.ToInt32(dt.Rows[0][2]);
                x++;
            }

            TB_Min.Text = startAmountMin.ToString();
            TB_Max.Text = startAmountMax.ToString();
            if (DateAmountChange == 1)
            {
                CHB_edittime.Checked = true;
            }
            chb = CHB_edittime.Checked;
            Minn = Convert.ToInt32(TB_Min.Text);
            Maxx = Convert.ToInt32(TB_Max.Text);
            
            PBSilder.Height = 30;
        }
        float Defaultvalue = 0.0f, Min = 0.0f, Max = 1.0f;
        //--------
        public float Bar(float value)
        {
            return (PBSilder.Width - 21) * (value - Min) / ((float)Max - Min);
        }

        public void Tamnum(float value)
        {
            if (value < Min) value = Min;
            if (value > Max) value = Max;
            Defaultvalue = value;
            PBSilder.Refresh();
        }

        bool mouse = false;
        private void PBSilder_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = true;
            Tamnum(Sliderwidth(e.X));
        }

        private void PBSilder_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouse) return;
            Tamnum(Sliderwidth(e.X));
            TBtest.Text = Defaultvalue.ToString();
        }

        private void PBSilder_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
        }

        public float Sliderwidth(int X)
        {
            return Min + (Max - Min) * X / (float)(PBSilder.Width);
        }

        private void PBSilder_Paint(object sender, PaintEventArgs e)
        {
            float Barsize = 0.45f; // ขนาด บาร์
            float x = Bar(Defaultvalue);
            float y = (int)(PBSilder.Height * Barsize);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(Brushes.Black, 0, y, PBSilder.Width, y / 2);

            e.Graphics.FillRectangle(Brushes.Red, 0, y, x, PBSilder.Height - 2 * y);
            using (Pen Pen = new Pen(Color.White, 8))
            {
                e.Graphics.DrawEllipse(Pen, x + 4, y - 6, PBSilder.Height / 2, PBSilder.Height / 2);
                e.Graphics.FillEllipse(Brushes.Red, x + 4, y - 6, PBSilder.Height / 2, PBSilder.Height / 2);
            }
            using (Pen Pen = new Pen(Color.White, 5))
            {
                e.Graphics.DrawEllipse(Pen, x + 4, y - 6, PBSilder.Height / 2, PBSilder.Height / 2);
            }
        }
        //------
        static DataTable dt;
        static int x = 0;

        public static int DateAmountChange;
        public static int startAmountMin;
        public static int startAmountMax;

        static int Minn;
        static int Maxx;
        static bool chb;

        /// <summary>
        /// SQLDafault
        /// <para>[0]Check Setting INPUT: - </para>
        /// <para>//[1]Edit Setting INPUT: {DateAmountChange} {StartAmountMin} {StartAmountMax}</para>
        /// </summary>
        private String[] SQLDefault = new String[]
        { 
             //[0]Check Setting INPUT: - 
             "SELECT DateAmountChange , StartAmountMin , StartAmountMax \r\n" +
             "FROM EmployeeBank.dbo.tblSettingAmount;"

            ,
             //[1]Edit Setting INPUT: {DateAmountChange} {StartAmountMin} {StartAmountMax}
             "UPDATE EmployeeBank.dbo.tblSettingAmount \r\n" +
             "SET DateAmountChange = {DateAmountChange}, StartAmountMin = {StartAmountMin} , StartAmountMax = {StartAmountMax} \r\n" +
             "WHERE SettingNo = 1 ;"
        };

        private void B_Cancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void B_Save_Click_1(object sender, EventArgs e)
        {
            if (TB_Min.Text != Minn.ToString() || TB_Max.Text != Maxx.ToString() || CHB_edittime.Checked != chb)
            {
                if (Convert.ToInt32(TB_Min.Text) <= Convert.ToInt32(TB_Max.Text))
                {
                    int TranChbToInt;
                    if (CHB_edittime.Checked == true)
                    {
                        TranChbToInt = 1;
                        DateAmountChange = TranChbToInt;
                    }
                    else
                    {
                        TranChbToInt = 0;
                        DateAmountChange = TranChbToInt;
                    }

                    Method.SQLMethod.InputSQLMSSQL(SQLDefault[1].Replace("{DateAmountChange}", TranChbToInt.ToString())
                        .Replace("{StartAmountMin}", TB_Min.Text)
                        .Replace("{StartAmountMax}", TB_Max.Text));
                    startAmountMin = Convert.ToInt32(TB_Min.Text);
                    startAmountMax = Convert.ToInt32(TB_Max.Text);
                    this.Hide();
                }
                else
                    MessageBox.Show("ค่าสูงสุดต้องไม่น้อยกว่าค่าต่ำสุด", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void TB_Max_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void TB_Min_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}

