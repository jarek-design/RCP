using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace rcpracy
{
    public partial class F1Grupy : Form
    {
        bool DataChanged;
        public F1Grupy()
        {
            InitializeComponent();
            DataChanged = false;
            
        }

        private void grupaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            saveData();

        }

        private void saveData()
        {
            this.Validate();
            this.grupaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);
            DataChanged = false;
        }

        private void F1Grupy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rcpDataSet.grupa' table. You can move, or remove it, as needed.
            this.grupaTableAdapter.Fill(this.rcpDataSet.grupa);
             DataChanged = false;
            if (grupaBindingSource.Count == 0)
                bindingNavigatorDeleteItem.Enabled = false;

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            RcpDataSet.grupaRow selRow;
            selRow = (RcpDataSet.grupaRow)rcpDataSet.SelectedRow(grupaBindingSource);
            int idGrup = selRow.idGrup;
            if (!IsPracInGroup(idGrup))
            {
                if (MessageBox.Show("Czy kasować rekord ?", "Kasowanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //rcpDataSet.grupa.RemovegrupaRow(selRow);
                    grupaBindingSource.RemoveCurrent();
                    DataChanged = true;
                }
            }
            else
            {
                MessageBox.Show("Rekord nie może być skasowany ponieważ grupa jest wykorzystywana", "Kasowanie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (grupaBindingSource.Count == 0)
                bindingNavigatorDeleteItem.Enabled = false;


        }

        private bool IsPracInGroup(int id)
        {
            using (SqlConnection rozliczenieConn = new SqlConnection(Funct.RcpConnectionStr))
            {
                string pracStr = "SELECT  pr_Id from pracownik where grupa =  " + id.ToString();
                SqlCommand pracCmd2 = new SqlCommand(pracStr, rozliczenieConn);
                rozliczenieConn.Open();                
                SqlDataReader rcpPrac = pracCmd2.ExecuteReader();
                if (rcpPrac.HasRows)
                    return true;
                else
                    return false;
            }

        }

       

        private void F1Grupy_FormClosing(object sender, FormClosingEventArgs e)

        {
            SaveBeforeClosing.CheckFormClosing(DataChanged, saveData);
            //CheckFormClosing();

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DataChanged = true;
        }

        private void TextBox_Changed(object sender, EventArgs e)
        {
            DataChanged = true;
        }
    }
}
