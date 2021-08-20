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
    }
}
