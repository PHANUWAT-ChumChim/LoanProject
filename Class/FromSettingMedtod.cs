using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example.Class
{
    class FromSettingMedtod
    {
        public static void ChangeSizePanal(Form myForm, Panel myPanal)
        {
            myPanal.Location = new System.Drawing.Point(myForm.Width / 2 - myPanal.Size.Width / 2,
            myForm.Height / 2 - myPanal.Size.Height / 2);
        }

        
    }
}
