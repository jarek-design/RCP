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
    public partial class rozliczTmp : Form
    {
        

        public rozliczTmp()
        {
            InitializeComponent();            
        }

        private void rozlTmpBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rozlTmpBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);

        }

        private void rozliczTmp_Load(object sender, EventArgs e)
        {
            //this.pracownikTableAdapter.Connection.ConnectionString = "";
            // TODO: This line of code loads data into the 'rcpDataSet.pracownik' table. You can move, or remove it, as needed.
            this.pracownikTableAdapter.Fill(this.rcpDataSet.pracownik);
            // TODO: This line of code loads data into the 'rcpDataSet.rozlTmp' table. You can move, or remove it, as needed.
            this.rozlTmpTableAdapter.Fill(this.rcpDataSet.rozlTmp);
            Sumowanie();
        }

        private void detailsButton1_Click(object sender, EventArgs e)
        {
            Wejscia wej1 = new Wejscia();
            RcpDataSet.rozlTmpRow SelectedRow = (RcpDataSet.rozlTmpRow) rcpDataSet.SelectedRow(rozlTmpBindingSource);
            if (SelectedRow != null)
            {
                wej1.Wejscia_Load(SelectedRow.id);
                wej1.ShowDialog();
            }
        }

        private void exportButton2_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            export2Grat export1 = new export2Grat();
            if (export1.eksport(toolStripProgressBar1))
                MessageBox.Show("Dane zostały wysłane do systemu INSERT", "EXPORT OK",MessageBoxButtons.OK);
            else
                MessageBox.Show("Żadne dane nie zostały wysłane do systemu INSERT", "",MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();

        }

        private void rozliczenieDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Funct.minut2hhmm((System.Windows.Forms.DataGridView)sender, e);
        }


        private void rozliczTmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
            {
                SqlCommand rcpCmd1 = new SqlCommand { Connection = rcpConnection };

                rcpConnection.Open();
                rcpCmd1.CommandText = "Delete from rozTmRej";
                rcpCmd1.ExecuteNonQuery();
                rcpCmd1.CommandText = "Delete from rozlTmp";
                rcpCmd1.ExecuteNonQuery();
            }
        }


#region sumowanie

        

        private void Sumowanie()
        {
                ucDGVsum1.Initialize(rozlTmpDataGridView, 4, 4);
                string cmdText1 = "SELECT  sum( dzien), sum( noc), sum( dzienNad), sum(nocNad) FROM   RozlTmp ";
                using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand rcpCmd1 = new SqlCommand(cmdText1, rcpConnection);
                    rcpConnection.Open();
                    SqlDataReader rejestr = rcpCmd1.ExecuteReader();
                    if (rejestr.Read())
                    {
                        int min;
                        for (int ii = 0; ii < 4; ii++)
                        {
                            min = rejestr.GetInt32(ii);
                            ucDGVsum1.SetLabel(ii, min2HourMin(min));
                        }
                    }
                }
         
        }

        private string min2HourMin(int min)
        {
            return (min / 60).ToString() + ":" + (min % 60).ToString("00");
        }

        

        private void rozliczTmp_Resize(object sender, EventArgs e)
        {
            ucDGVsum1.LabelPositioning();
        }

#endregion
             
    }
}
