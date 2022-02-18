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
    public partial class F2grupy : Form
    {
        public F2grupy()
        {
            InitializeComponent();
        }

        private void grupaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.grupaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);

        }

        private void F2grupy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rcpDataSet.grupa' table. You can move, or remove it, as needed.
            this.grupaTableAdapter.Fill(this.rcpDataSet.grupa);

        }
    }
}
