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
    public partial class wejscia2 : Form
    {
        public wejscia2()
        {
            InitializeComponent();
        }

        private void rejestrBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rejestrBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);

        }

        //private void wejscia2_Load(object sender, EventArgs e)
        //{
        //    // TODO: This line of code loads data into the 'rcpDataSet.rejestr' table. You can move, or remove it, as needed.
        //    this.rejestrTableAdapter.Fill(this.rcpDataSet.rejestr);

        //}

        public void Wejscia_Load(int rozliczId1)
        {
            this.rejestrTableAdapter.FillBy(this.rcpDataSet.rejestr, rozliczId1);
           
        }
    }
}
