using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rcpracy
{
    public partial class F1okres : Form
    {
        Frejestr fr1;

        public F1okres(Frejestr fr1)
        {
            this.fr1 = fr1;
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            fr1.period1 = new Period(dateTimePicker1.Value, dateTimePicker2.Value);
            fr1.konektor();
            this.Close();
            
        }
    }
}
