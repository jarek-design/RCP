using System.Windows.Forms;

namespace rcpracy
{
    static class SaveBeforeClosing
    {

       public delegate void saveFunc();

        static public void CheckFormClosing(bool DataChanged, saveFunc saveF)
        {
            if (DataChanged)
                if (MessageBox.Show("Dane zostały zmienione, czy zapisać przed zamknięciem okna ?", "Konieczny zapis danych", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    saveF();
        }

        static public void CheckBefore(bool DataChanged, saveFunc saveF)
        {
            if (DataChanged)
                if (MessageBox.Show("Dane zostały zmienione, czy zapisać przed operacją?", "Konieczny zapis danych", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    saveF();
        }

        static public string CellValue(DataGridView dgv, int RowIndex, int ColumnIndex)
        {
            DataGridViewRow row = dgv.Rows[RowIndex];
            string cellval = row.Cells[ColumnIndex].Value.ToString();

            return cellval;
        }
    }
}
