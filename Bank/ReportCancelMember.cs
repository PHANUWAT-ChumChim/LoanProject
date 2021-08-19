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
    public partial class ReportCancelMember : Form
    {
        public ReportCancelMember()
        {
            InitializeComponent();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReportCancelMember_SizeChanged(object sender, EventArgs e)
        {
            Class.Method.ChangeSizePanal(this, panel1);
        }

        private void ReportCancelMember_Load(object sender, EventArgs e)
        {

        }

        private void BSearchTeacher_Click(object sender, EventArgs e)
        {

        }
    }
}
