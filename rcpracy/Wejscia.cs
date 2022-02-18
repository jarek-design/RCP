using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace rcpracy
{
    public partial class Wejscia : Form
    {
        public Wejscia()
        {
            InitializeComponent();
        }

        private void rozTmRejBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rozTmRejBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);

        }

        //private void Wejscia_Load(object sender, EventArgs e)
        //{

        //    this.rejestrTableAdapter.Fill(this.rcpDataSet.rejestr);

        //    this.rozTmRejTableAdapter.Fill(this.rcpDataSet.rozTmRej);

        //}

        public void Wejscia_Load(int rozliczId1)
        {
            this.rejestrTableAdapter.Fill(this.rcpDataSet.rejestr);
            rozTmRejTableAdapter.FillBy(this.rcpDataSet.rozTmRej, rozliczId1);
        }

        
     }

}

