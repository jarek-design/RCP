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
    public partial class F1rozliczenia : Form
    {
       
        int selectedPerson;
        bool formLoad;
        Period p1;
        List<int> personIdList;

        public F1rozliczenia()
        {
            formLoad = false;
            InitializeComponent();

            p1 = Funct.okres(0);

            selectedPerson = 0;
            personIdList = new List<int>();
            Funct.personListIni(nazwiskaComboBox2.ComboBox, personIdList);

            Funct.okresComboBoxFill(okresComboBox1);
            okresComboBox1.SelectedIndex = 0;
            nazwiskaComboBox2.SelectedIndex = 0;
            personIdList = new List<int>();
          
        }

        private void rozliczenieBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rozliczenieBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);

        }

        private void F1rozliczenia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rcpDataSet.pracownik' table. You can move, or remove it, as needed.
            this.pracownikTableAdapter.Fill(this.rcpDataSet.pracownik);
            formLoad = true; 
            rozliczenie(p1, 0);  
        }



        private void ButtonWejscia_Click(object sender, EventArgs e)
        {
            wejscia2 wej2 = new wejscia2();
            RcpDataSet.rozliczenieRow selectedRow = (RcpDataSet.rozliczenieRow)rcpDataSet.SelectedRow(rozliczenieBindingSource);
            wej2.Wejscia_Load(selectedRow.idroz);
            wej2.ShowDialog();
        }

        private void rozliczenieDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Funct.minut2hhmm((System.Windows.Forms.DataGridView)sender, e);  
        }

        private void nazwiskaComboBox2_Enter(object sender, EventArgs e)
        {
            if (nazwiskaComboBox2.Items.Count < 2)
                Funct.pracownikFill(nazwiskaComboBox2.ComboBox, rcpDataSet, personIdList);           
        }

       

        private void nazwiskaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedPerson = personIdList[nazwiskaComboBox2.SelectedIndex];
            
            rozliczenie(p1, selectedPerson);
        }

        private void okresComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (okresComboBox1.SelectedIndex < okresComboBox1.Items.Count - 1)
            {
                p1 = Funct.okres(okresComboBox1.SelectedIndex);
                rozliczenie(p1, selectedPerson);
            }
            else
            {
                okresComboBox1.Enabled = false;
                ucOkres1.Visible = true;
            }

        }

        void rozliczenie(Period p1, int selectedPerson)
        {           
            if (formLoad)  // okno zostało zainicjowane
            if (selectedPerson == 0)
                rozliczenieTableAdapter.FillByDate(rcpDataSet.rozliczenie, p1.d1, p1.d2);
            else
                rozliczenieTableAdapter.FillByDatePrac(rcpDataSet.rozliczenie, p1.d1, p1.d2, selectedPerson);

        }

        private void ucOkres1_ButtonClick(object sender, rcpracy.ucOkres.Okres_EventArgs e)
        {
            p1 = e.period;
            rozliczenie(p1, selectedPerson);
            ucOkres1.Visible = false;
            okresComboBox1.Enabled = true;
        }

      

       

      

   
    }
}
