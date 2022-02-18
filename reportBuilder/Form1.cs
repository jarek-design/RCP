using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace reportBuilder
{
    partial class Form1 : Form
    {
        Color selectBackColor;
        Color fontDefaultColor;
        
        public Form1()
        {
            InitializeComponent();
            selectBackColor = repcolumnDataGridView.DefaultCellStyle.SelectionBackColor;
            fontDefaultColor = repcolumnDataGridView.ForeColor;
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'reportsDataSet.param' table. You can move, or remove it, as needed.
            DataLoad();
        }

        private void DataLoad()
        {
            this.paramTableAdapter.Fill(this.reportsDataSet.param);
            this.groupTableAdapter.Fill(this.reportsDataSet.group);
            this.repcolumnTableAdapter.Fill(this.reportsDataSet.repcolumn);
            this.reportTableAdapter.Fill(this.reportsDataSet.report);
        }

        private void BindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy kasować wzorzec wydruku?", "Kasowanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
             == DialogResult.Yes)
                reportBindingSource.RemoveCurrent();
        }

        private void ReportBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            //int p1 = reportBindingSource.Position;
            this.Validate();
            this.reportBindingSource.EndEdit();
            this.repcolumnBindingSource.EndEdit();
            this.paramBindingSource.EndEdit();
            this.groupBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.reportsDataSet);
            this.groupTableAdapter.Update(reportsDataSet);
            this.paramTableAdapter.Update(reportsDataSet);
            //if (! tabControl1.Enabled && !String.IsNullOrEmpty( menuTextBox.Text))
            //{
            //    tabCtrlEnable();
            
            //this.reportTableAdapter.Update(this.reportsDataSet);
            //this.reportTableAdapter.Fill(this.reportsDataSet.report);
            //reportBindingSource.Position = p1;
            //}
            //else
            //{
            //    tabCtrlDisable();
            //}
        }

        private void TabCtrlDisable()
        {
           
        }

        private void TabCtrlEnable()
        {
            tabControl1.Enabled = true;
            repcolumnDataGridView.ForeColor = fontDefaultColor;
            repcolumnDataGridView.DefaultCellStyle.SelectionBackColor = selectBackColor;
        }

        private void BindingNavigatorMove_Click(object sender, EventArgs e)
        {
            if (!tabControl1.Enabled)
            TabCtrlEnable();
        }

        private void KopiaButton1_Click(object sender, EventArgs e)
        {
            DataRow[] foundRows;
            string idrep =
              reportsDataSet.report[reportBindingSource.Position]["idreport"].ToString();
            int nrecID;
            reportsDataSet.reportRow rnewrow = reportsDataSet.report.NewreportRow();
            int p1 = reportBindingSource.Position;

            for (int jj = 1; jj < reportsDataSet.report.Columns.Count; jj++)
            {
                if (reportsDataSet.report[reportBindingSource.Position][jj] != reportsDataSet.report[reportBindingSource.Position]["idreport"])
                    rnewrow[jj] = reportsDataSet.report[reportBindingSource.Position][jj];
            }
            reportsDataSet.report.Rows.Add(rnewrow);


            this.reportTableAdapter.Update(this.reportsDataSet);
            reportsDataSet.AcceptChanges();
            this.reportTableAdapter.Fill(this.reportsDataSet.report);
            nrecID = (int)reportsDataSet.report.Rows[reportsDataSet.report.Rows.Count - 1]["idreport"];

            reportBindingSource.Position = p1;

            DataTable tabl = reportsDataSet.repcolumn;
            foundRows = tabl.Select("idrep= '" + idrep + "'");
            reportsDataSet.repcolumnRow rcnewrow;
            foreach (DataRow r1 in foundRows)
            {
                rcnewrow = reportsDataSet.repcolumn.NewrepcolumnRow();
                for (int jj = 1; jj < reportsDataSet.repcolumn.Columns.Count; jj++)
                {
                    if (r1[jj] != r1["idrepc"])
                        rcnewrow[jj] = r1[jj];
                }
                rcnewrow["idrep"] = nrecID;
                reportsDataSet.repcolumn.Rows.Add(rcnewrow);
            }
            MessageBox.Show("Kopia raportu wykonana pomyślnie");
            this.repcolumnTableAdapter.Update(reportsDataSet);

        }
    }
}
