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
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
        }

        private void Loan_SizeChanged(object sender, EventArgs e)
        {
            Class.FromSettingMedtod.ChangeSizePanal(this, panel1);
        }

        private void CBB4Oppay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Loan_Load(object sender, EventArgs e)
        {

        }

        private void BSearchTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                Bank.Search IN = new Bank.Search(2);
                IN.ShowDialog();
                TBTeacherNo.Text = Bank.Search.Return[0];
                TBTeacherName.Text = Bank.Search.Return[1];
                TB_LoanStatus.Text = Bank.Search.Return[3];
                TB_IdLoan.Text = Bank.Search.Return[4];
                TB_Saving.Text = Bank.Search.Return[5];
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
        }

        private void TBTeacherNo_TextChanged(object sender, EventArgs e)
        {
            //ต้องพิมพ์รหัสอาจารย์ถึง 6 ตัวถึงจะเข้าเงื่อนไข if
            if (TBTeacherNo.Text.Length == 6)
            {
                Class.SQLMethod.ReSearchLoan(TBTeacherNo.Text, TBTeacherName, TB_IdLoan,TB_LoanStatus,TB_Saving);
            }
            else
            {
                TBTeacherName.Text = "";
                TB_IdLoan.Text = "";
                TB_LoanStatus.Text = "";
                TB_Saving.Text = "";
            }
        }
    }
}
