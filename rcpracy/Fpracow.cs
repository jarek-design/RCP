using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace rcpracy
{
    public partial class Fpracow : Form
    {
        System.Globalization.CultureInfo deDe;
        bool DataChanged;
        string valBefore;
        public Fpracow()
        {
            deDe = new System.Globalization.CultureInfo("de-De");
            InitializeComponent();

        }

        private void pracownikBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveData();

        }

        private void SaveData()
        {
            this.Validate();
            this.pracownikBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);
            DataChanged = false;
        }

        private void Fpracow_Load(object sender, EventArgs e)
        {
           
            this.grupaTableAdapter.Fill(this.rcpDataSet.grupa);           
            this.pracownikTableAdapter.Fill(this.rcpDataSet.pracownik);           
            DataChanged = false;
        }

        private void toolButton1_Click(object sender, EventArgs e)
        {
            ImportPrac.import();
            this.pracownikTableAdapter.Fill(this.rcpDataSet.pracownik);
            pracownikDataGridView.Update();
            pracownikDataGridView.Refresh();
            DataChanged = true;
        }

        private void txtFileButton_Click(object sender, EventArgs e)
        {
            var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
            if (drives.Count() > 0)
                saveFileDialog1.InitialDirectory = drives.Last().Name;
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new listaPrac(saveFileDialog1.FileName);
        }

        private void pracownikDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1 && pracownikDataGridView.Rows.Count > 0)
            {


                DataGridViewRow row = pracownikDataGridView.Rows[e.RowIndex];

                if (row.Cells[wymiarPracy.Index].Value != null)
                {
                    string w = row.Cells[wymiarPracy.Index].Value.ToString();
                    int wii;
                    if (int.TryParse(w, out wii))
                    {
                        row.Cells[Column1.Index].Value = (wii / 60).ToString("F1", deDe);
                    }
                }
                if (row.Cells[rfidId.Index].Value != null)
                {
                    String rfId = row.Cells[rfidId.Index].Value.ToString();
                    if (!String.IsNullOrEmpty(rfId) && rfId.Length > 8)
                        row.Cells[rfidId.Index].Value = rfId.Trim().Substring(0, 8);
                }
            }

            //rfidId
        }

        private void pracownikDataGridView_Paint(object sender, PaintEventArgs e)
        {
            string w;
            int wii;

            foreach (DataGridViewRow row in pracownikDataGridView.Rows)
            {
                try
                {
                    w = row.Cells[wymiarPracy.Index].Value.ToString();

                    if (int.TryParse(w, out wii))
                    {
                        row.Cells[Column1.Index].Value = (wii / 60).ToString("F1", deDe);
                    }
                }
                catch (Exception)
                {
                }
            }

        }

       


        private void pracownikDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            valBefore = SaveBeforeClosing.CellValue(pracownikDataGridView, e.RowIndex, e.ColumnIndex);
        }



        private void pracownikDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != Column1.Index)   //Column1 jest kolumną wyliczaną
            {
                string valBefore1 = SaveBeforeClosing.CellValue(pracownikDataGridView, e.RowIndex, e.ColumnIndex);
                if (valBefore != valBefore1)
                    DataChanged = true;
            }
        }




        private void Fpracow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveBeforeClosing.CheckFormClosing(DataChanged, SaveData);
        }
    }
}
