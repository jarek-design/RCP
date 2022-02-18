using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rcpracy
{
    public partial class ucOkres : UserControl
    {
        public ucOkres()
        {
            InitializeComponent();
        }


        #region event ButtonClick
        // button powoduje przekazanie zmiennej Perion 
        public event EventHandler<Okres_EventArgs> ButtonClick;

        public class Okres_EventArgs : EventArgs
        {
            public Period period { get; set; }

            public Okres_EventArgs(DateTime Od, DateTime DO)
            {
                period = new Period(Od.Date, DO.Date.AddDays(1));

            }
        }
        private void button1Okres_Click(object sender, EventArgs e)
        {
            Okres_EventArgs arg = new Okres_EventArgs(dateTimePicker1.Value, dateTimePicker2.Value);

            this.ButtonClick(this, arg);

        }

        #endregion
                  
       
        private void panel1_VisibleChanged(object sender, EventArgs e)
        {

            if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
            {
                ///dateTimePicker1.Value = monthFirstDay(dateTimePicker1.Value.AddMonths(-1));
                dateTimePicker1.Value = monthFirstDay(dateTimePicker1.Value);
                dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1);
            }
        }

        private DateTime monthFirstDay (DateTime d1)
        {            
            return new DateTime(d1.Year, d1.Month, 1, 0, 0, 0);
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                label2Info.Text = "wyjście musi być późniejsze";
                label2Info.Visible = true;
                button1Okres.Enabled = false;
            }
            else
            {
                label2Info.Visible = false;
                button1Okres.Enabled = true;
            }
        }

    }
}
