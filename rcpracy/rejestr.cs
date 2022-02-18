using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using Extensions1;
using System.IO;
using System.Data.SqlClient;

namespace rcpracy
{
    public partial class Frejestr : Form
    {
        int selectedPerson;
        string selectedPersonName;
        //string rcpKod;
        List<int> personIdList, personIdList2;
        bool formLoad;
        public Period period1;
        int editRow = -1;
        importTxt2Rejestr impRej;

        bool DataChanged;
       

        public Frejestr()
        {           
            formLoad = false;
            InitializeComponent();
            period1 = Funct.okres(0);
            toolStripLabel1.Text = "";            
            selectedPerson = 0;
            personIdList = new List<int>();
            personIdList2 = new List<int>();
            Funct.personListIni(nazwiskaComboBox2.ComboBox, personIdList);
            Funct.personListIni(pr_IdComboBox, personIdList2, null);
            Funct.okresComboBoxFill(okresComboBox1);
            okresComboBox1.SelectedIndex = 0;
            nazwiskaComboBox2.SelectedIndex = 0;
            pr_IdComboBox.Enabled = false;
            impRej = null;
            DataChanged = false;
            rozlTmp_delete();

            Configuration.Instance.ini();
            if (!Configuration.confData.rejestratorZewn)
                refreshButton1.Visible = false;
            else
                refreshButton1.Visible = true;

        }

        private void rejestrBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            save();

        }

        private void rejestr_Load(object sender, EventArgs e)
        {
            this.pracownikTableAdapter.Fill(this.rcpDataSet.pracownik);
            //this.rejestrTableAdapter.Fill(this.rcpDataSet.rejestr);
            formLoad = true;
            loadRejestr(period1, 0);            
        }

        private void rozliczButton1_Click(object sender, EventArgs e)
        {

            rozliczButton1.Enabled = false;
            
            if (Configuration.confData.rejestratorZewn)
            {
                //impRejestr import1 = new impRejestr();
                //ProgressBar1.Visible = true;
                //import1.load(this.ProgressBar1);
            }
            if (rozliczenieGodzinOsoby())
            {
                loadRejestr(period1, selectedPerson);
                rozliczTmp rozlicz1 = new rozliczTmp();
                rozlicz1.ShowDialog();
            }
            else
            MessageBox.Show("Rozliczenie nie zostało przeprowadzone");
            rozliczButton1.Enabled = true;

        }

        private void nazwiskaComboBox2_Enter(object sender, EventArgs e)
        {
            if (nazwiskaComboBox2.Items.Count < 2)
                Funct.pracownikFill(nazwiskaComboBox2.ComboBox, rcpDataSet, personIdList);
        }



        private void nazwiskaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedPerson = personIdList[nazwiskaComboBox2.SelectedIndex];
            toolButton2print.Enabled = true;
            // personIdList zawiera id osób. Lista jest skojarzona z nazwiskami w pracownikFill (...)
            loadRejestr(period1, selectedPerson);
            if (nazwiskaComboBox2.SelectedIndex > 0)
            {
                selectedPersonName = nazwiskaComboBox2.SelectedItem.ToString();
                
                raportPracownikaToolStripMenuItem.Enabled = true;
                zestawienieSumujaceToolStripMenuItem.Enabled = false;
                toolButton2print.Text = "Wydruk ";
            }
            else
            {               
           
                raportPracownikaToolStripMenuItem.Enabled = false;
                zestawienieSumujaceToolStripMenuItem.Enabled = true;
                //raportPracownikaToolStripMenuItem.Text = "Proszę wybrać osobę ";
            }
        }

        private void okresComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolButton2print.Enabled = true;
            zestawienieSumujaceToolStripMenuItem.Enabled = true;
            if (okresComboBox1.SelectedIndex < okresComboBox1.Items.Count - 1)
            {
                period1 = Funct.okres(okresComboBox1.SelectedIndex);
                loadRejestr(period1, selectedPerson);
            }
            else
            {
                okresComboBox1.Enabled = false;
                ucOkres1.Visible = true;
            }



        }
        public void konektor()
        {
            loadRejestr(period1, selectedPerson);
            //rejestrDataGridView.Visible = true;
        }

        private void ucOkres1_ButtonClick(object sender, ucOkres.Okres_EventArgs e)
        {
            period1 = e.period;
            loadRejestr(period1, selectedPerson);
            ucOkres1.Visible = false;
            okresComboBox1.Enabled = true;
        }



        void loadRejestr(Period p1, int selectedPerson)
        {
            SaveBeforeClosing.CheckBefore(DataChanged, save);
            if (formLoad)  // okno zostało zainicjowane
            {
                toolStripLabel1.Text =  p1.d1.ToShortDateString() + " - " + p1.d2.ToShortDateString();
                DataChanged = false;

                if (selectedPerson == 0)
                    rejestrTableAdapter.FillByDate(rcpDataSet.rejestr, p1.d1, p1.d2);
                else
                    rejestrTableAdapter.FillDatePrac(rcpDataSet.rejestr, selectedPerson, p1.d1, p1.d2);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Visible = false;
            timer1.Enabled = false;
        }

        private void refreshButton1_Click(object sender, EventArgs e)
        {
            //Configuration.Instance.ini();
            //if (Configuration.confData.rejestratorZewn == true)
            //{
            //    impRejestr import1 = new impRejestr();
            //    ProgressBar1.Visible = true;

            //    import1.load(this.ProgressBar1);
            //    loadRejestr(period1, selectedPerson);
            //    MessageBox.Show(import1.info());
            //    timer1.Enabled = true;
            //}
            //if (Configuration.confData.remote == true)
            //{
            //    //ImpRemoteRej.Import();
            //}

        }



        private void rejestrDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //try
            //{
            //    if ((bool)rejestrDataGridView["przetw", e.RowIndex].Value)
            //    {
            //        rejestrDataGridView.Rows[e.RowIndex].ReadOnly = true;
            //    }
            //}
            //catch (Exception)
            //{

            //}
            if (rejestrDataGridView["czasWy", e.RowIndex].Value != null && rejestrDataGridView["czasWej", e.RowIndex].Value != null && e.CellStyle.BackColor != Color.Salmon)
            {
                if (rejestrDataGridView.Columns[e.ColumnIndex].Name == "czasWej")
                {
                if( rejestrDataGridView["czasWej", e.RowIndex].Value.ToString() != rejestrDataGridView["czasWe1", e.RowIndex].Value.ToString())
                {
                    if (rejestrDataGridView["czasWe1", e.RowIndex].Value.ToString().Length > 1)
                    {
                        rejestrDataGridView["czasWej", e.RowIndex].ToolTipText = ((DateTime)(rejestrDataGridView["czasWe1", e.RowIndex].Value)).ToString("dd-MMMM-yyyy  HH:mm");                        
                        e.CellStyle.BackColor = Color.Lavender;
                    }
                    else
                        e.CellStyle.BackColor = Color.PaleGoldenrod;
                }
                }
                else
                    if (rejestrDataGridView.Columns[e.ColumnIndex].Name == "czasWy" && rejestrDataGridView["CzasDo1", e.RowIndex].Value != DBNull.Value  &&  rejestrDataGridView["czasWej", e.RowIndex].Value != DBNull.Value )
                    {
                        if (rejestrDataGridView["czasWy", e.RowIndex].Value.ToString() != rejestrDataGridView["CzasDo1", e.RowIndex].Value.ToString())
                        {                            
                            DateTime dwe1 = Convert.ToDateTime(rejestrDataGridView["czasWej", e.RowIndex].Value);                            
                            DateTime dwy2 = Convert.ToDateTime(rejestrDataGridView["CzasDo1", e.RowIndex].Value);

                            if (rejestrDataGridView["CzasDo1", e.RowIndex].Value.ToString().Length > 1)
                            {
                                rejestrDataGridView["czasWy", e.RowIndex].ToolTipText = ((DateTime)(rejestrDataGridView["CzasDo1", e.RowIndex].Value)).ToString("dd-MMMM-yyyy  HH:mm");
                                if (dwe1.AddHours(Configuration.confData.maxGodz) < dwy2)
                                    e.CellStyle.BackColor = Color.Moccasin;
                                else
                                    e.CellStyle.BackColor = Color.Lavender;
                            }
                            else
                                e.CellStyle.BackColor = Color.PaleGoldenrod;
                        }
                        else
                            rejestrDataGridView["czasWy", e.RowIndex].ToolTipText = null;
                    }
                    else

                        if (rejestrDataGridView.Columns[e.ColumnIndex].Name == "praca")
                            try
                            {
                                int czasPracy = Convert.ToInt32(((DateTime)rejestrDataGridView["czasWy", e.RowIndex].Value
                                            - (DateTime)rejestrDataGridView["czasWej", e.RowIndex].Value).TotalMinutes);
                                e.Value = (czasPracy / 60).ToString() + ":" + (czasPracy % 60).ToString("00");
                                if (rejestrDataGridView["czasWej", e.RowIndex].Value.ToString() != rejestrDataGridView["czasWe1", e.RowIndex].Value.ToString() ||
                                   rejestrDataGridView["czasWy", e.RowIndex].Value.ToString() != rejestrDataGridView["CzasDo1", e.RowIndex].Value.ToString())
                                {
                                    czasPracy = Convert.ToInt32(((DateTime)rejestrDataGridView["CzasDo1", e.RowIndex].Value
                                            - (DateTime)rejestrDataGridView["czasWe1", e.RowIndex].Value).TotalMinutes);
                                    rejestrDataGridView["praca", e.RowIndex].ToolTipText = (czasPracy / 60).ToString() + ":" + (czasPracy % 60).ToString("00");
                                }

                            }
                            catch (Exception)
                            {

                            }
            }
        }
     

        private void raportPracownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedPerson > 0)
            {
                rozliczenieGodzinOsoby();
                reports.repStart report = new reports.repStart(Funct.RcpConnectionStr);
                report.RealizWydr(1, selectedPersonName, "okres: " + period1.d1.ToLongDateString() + " - " + period1.d2.AddDays(-1).ToLongDateString());
                report.Show();
            }
        }

        private void zestawienieSumujaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedPerson == 0)
            {
                rozliczenieGodzinOsoby();
                reports.repStart report = new reports.repStart(Funct.RcpConnectionStr);
                report.RealizWydr(2, "Zestawienie sumujące ", "okres: " + period1.d1.ToLongDateString() + " - " + period1.d2.AddDays(-1).ToLongDateString());
                report.Show();
            }

        }

        private bool rozliczenieGodzinOsoby()
        {
            List<SQLparam> par1 = new List<SQLparam> {
                new SQLparam { name =  "Pr_Id", val = selectedPerson.ToString()},
                new SQLparam { name = "D1" , val = period1.d1 },
                new SQLparam { name = "D2" , val = period1.d2 } };

            return Rozliczenie.rozlicz(ProgressBar1, timer1, par1);
        }


        private void godzinyDoOdebraniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedPerson > 0)
            {
                //string warSql = " where pr_Id = " + selectedPerson.ToString() +
                //      " AND czasWe BETWEEN '" + period1.d1.ToShortDateString() + "' AND '" + period1.d2.ToShortDateString()    + "' order by czasWe";

                reports.repStart report = new reports.repStart(Funct.RcpConnectionStr);
                List<reports.SQLparam> sqlPL = dateSqlParam();
                sqlPL.Add(new reports.SQLparam { name = "@idPrac", val = selectedPerson.ToString() });

                report.setParam(sqlPL);

                report.RealizWydr(3,
                    selectedPersonName, "okres: " + period1.d1.ToLongDateString() + " - " + period1.d2.AddDays(-1).ToLongDateString());
                report.Show();
            }
            else
            {
                //string warSql = " where czasWe BETWEEN '" + period1.d1.ToShortDateString() + "' AND '" + period1.d2.ToShortDateString()
                //    + "' Group By  Nazwisko , Imie ORDER by Nazwisko ";

                reports.repStart report = new reports.repStart(Funct.RcpConnectionStr);
                report.setParam(dateSqlParam());

                report.RealizWydr(5,
                    "Godziny do odebrania sumaryczne ", "okres: " + period1.d1.ToLongDateString() + " - " + period1.d2.AddDays(-1).ToLongDateString());
                report.Show();
            }

        }

        private List<reports.SQLparam> dateSqlParam()
        {
            List<reports.SQLparam> sqlPL = new List<reports.SQLparam>();
            sqlPL.Add(new reports.SQLparam { name = "@D1", val = period1.d1 });
            sqlPL.Add(new reports.SQLparam { name = "@D2", val = period1.d2 });
            return sqlPL;
        }




        private void rejestrDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (rejestrDataGridView["nazwisko", e.RowIndex].Value.ToString().Length > 0)
            {
                editRow = e.RowIndex;
                try
                {
                    if ((bool)rejestrDataGridView["przetw", e.RowIndex].Value)
                    {
                        TimePicker2we.Enabled = false;
                        TimePicker2Wy.Enabled = false;
                        dateTimePicker3We.Enabled = false;
                        dateTimePicker3Wy.Enabled = false;
                    }
                    else
                    {
                        TimePicker2we.Enabled = true;
                        TimePicker2Wy.Enabled = true;
                        dateTimePicker3We.Enabled = true;
                        dateTimePicker3Wy.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    TimePicker2we.Enabled = true;
                    TimePicker2Wy.Enabled = true;
                    dateTimePicker3We.Enabled = true;
                    dateTimePicker3Wy.Enabled = true;
                }

                DateTime d1, d2;


                try
                {
                    d1 = (DateTime)rejestrDataGridView["czasWej", editRow].Value;
                }
                catch (Exception)
                {
                    d1 = DateTime.Now;
                }

                try
                {
                    d2 = (DateTime)rejestrDataGridView["czasWy", editRow].Value;
                }
                catch (Exception)
                {
                    d2 = d1.AddHours(8);
                }
                edycjaGodzinPracy(d1, d2);
                pr_IdComboBox.SelectedIndex = personIdList2.IndexOf((int)rejestrDataGridView["nazwisko", e.RowIndex].Value);
                pr_IdComboBox.Enabled = false;
                
            }
            else
            {
                //rejestrDataGridView.CancelEdit();
                e.Cancel = true;
                MessageBox.Show("Pusty rekord nie podlega edycji\n Można dodać nowy rekord wciskając + ");
            }

        }

        private void edycjaGodzinPracy(DateTime d1, DateTime d2)
        {
            comboBoxPracFill();
            TimePicker2we.Value = d1;
            dateTimePicker3We.Value = d1;
            TimePicker2Wy.Value = d2;
            dateTimePicker3Wy.Value = d2;
            panel2.Show();
        }

        private void button2ESC_Click(object sender, EventArgs e)
        {

            panel2.Hide();
        }

        private void button2Zapis_Click(object sender, EventArgs e)
        {

            DateTime t1 = TimePicker2we.Value;
            DateTime t2 = TimePicker2Wy.Value;
            if (Extens.timeSplit(dateTimePicker3We.Value, t1.Hour, t1.Minute).AddHours(Configuration.confData.maxGodz) < Extens.timeSplit(dateTimePicker3Wy.Value, t2.Hour, t2.Minute))
            {
               MessageBox.Show("czas pracy jest zbyt długi", "Edycja dnia pracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            if (Extens.timeSplit(dateTimePicker3We.Value, t1.Hour, t1.Minute) < Extens.timeSplit(dateTimePicker3Wy.Value, t2.Hour, t2.Minute))
            {
                if (editRow >= 0)
                {

                    rejestrDataGridView["czasWej", editRow].Value = Extens.timeSplit(dateTimePicker3We.Value, t1.Hour, t1.Minute);
                    rejestrDataGridView["czasWy", editRow].Value = Extens.timeSplit(dateTimePicker3Wy.Value, t2.Hour, t2.Minute);

                }
                else
                    if (pr_IdComboBox.Enabled) // dodanie nowego rekordu
                    {
                        if (pr_IdComboBox.SelectedIndex == 0)
                        {
                            MessageBox.Show("Proszę wybrać pracownika lub nacisnąć ESC", "Dodawanie dnia pracy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        RcpDataSet.rejestrRow newRow = this.rcpDataSet.rejestr.NewrejestrRow();
                        newRow.czasWe = Extens.timeSplit(dateTimePicker3We.Value, t1.Hour, t1.Minute);
                        newRow.czasDo = Extens.timeSplit(dateTimePicker3Wy.Value, t2.Hour, t2.Minute);
                        newRow.pr_Id = personIdList2[pr_IdComboBox.SelectedIndex];
                        this.rcpDataSet.rejestr.Rows.Add(newRow);
                        pr_IdComboBox.Enabled = false;
                        save();
                    }

                editRow = -1;
                panel2.Hide();
                DataChanged = true;
            }
            else
                MessageBox.Show("czas wyjscia nie może być mniejszy od czasu wejścia", "Edycja dnia pracy", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void save()
        {
            this.Validate();
            this.rejestrBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rcpDataSet);
            DataChanged = false;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            edycjaGodzinPracy(DateTime.Now.AddHours(-4), DateTime.Now.AddHours(4));
            pr_IdComboBox.Enabled = true;
            pr_IdComboBox.SelectedIndex = 0;

        }

        private void comboBoxPracFill()
        {
            if (pr_IdComboBox.Items.Count < 2)
                Funct.pracownikFill(pr_IdComboBox, rcpDataSet, personIdList2, "wybierz osobę");
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (rejestrDataGridView.CurrentRow != null && !rejestrDataGridView.CurrentRow.IsNewRow)
            {
                DataGridViewCellStyle style0 = rejestrDataGridView.CurrentRow.Cells[0].Style;
                DataGridViewCellStyle style1 = new DataGridViewCellStyle();
                style1.BackColor = Color.Salmon;
                for (int i = 0; i < rejestrDataGridView.ColumnCount; i++)
                    rejestrDataGridView.CurrentRow.Cells[i].Style = style1;

                if (MessageBox.Show("Czy kasować rekord ?", "Kasowanie", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    rejestrDataGridView.Rows.RemoveAt(rejestrDataGridView.CurrentRow.Index);
                    MessageBox.Show("Rekord został skasowany, ale żeby to zatwierdzić\n należy zapisać zmiany", "Kasowanie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataChanged = true;
                }
                else
                    for (int i = 0; i < rejestrDataGridView.ColumnCount; i++)
                        rejestrDataGridView.CurrentRow.Cells[i].Style = style0;

            }
            else
                MessageBox.Show("Ten rekord nie może być skasowany", "Kasowanie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void importButton1_Click(object sender, EventArgs e)
        {

            SaveBeforeClosing.CheckBefore(DataChanged, save);
           // ProgressBar1.Visible = true;
            var file2ImportPath = string.Empty;
            string logFileP = "ImpRCPLog.txt";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "tekstowe (*.txt)|*.txt|Wszystkie (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    pictureLoad.Visible = true;
                    importButton1.Enabled = false;
                    rozliczButton1.Enabled = false;

                    file2ImportPath = openFileDialog.FileName;
                    iniProgressBar();
                    impRej = new importTxt2Rejestr();
                    impRej.importTxt2RejestrIni(file2ImportPath, logFileP);
                    impRej.importRejestrStart();
                    impRej.RaiseCustomEvent += MessageReceived;                                                         
                }
            }
            //MessageBox.Show("Wynik importu " , "Plik : " + logFileP , MessageBoxButtons.OK);
        }

        void MessageReceived(object sender, ImportEventArgs e)
        {
            switch (e.EventStatus)
            {
                case importEventStatus.stop:
                    pictureLoad.Visible = false;
                    loadRejestr(period1, 0);
                    importButton1.Enabled = true;
                    rozliczButton1.Enabled = true;
                    MessageBox.Show(e.Info.txt2, e.Info.txt1, System.Windows.Forms.MessageBoxButtons.OK);
                    ProgressBar1.Visible = false;
                    break;
                case importEventStatus.progres:
                    ProgressBar1.Value = e.ImportProgress;
                    break;
                case importEventStatus.info:
                    MessageBox.Show(e.Info.txt2, e.Info.txt1, System.Windows.Forms.MessageBoxButtons.OK);
                    break;
            }

        }

        void iniProgressBar()
        {
            ProgressBar1.Value = 0;
            ProgressBar1.Maximum = 100;
            ProgressBar1.Visible = true;
        }

        private void Frejestr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (impRej != null)
                impRej.importRejestrStop();

            SaveBeforeClosing.CheckFormClosing(DataChanged, save);
        }

        private void rozlTmp_delete()
        {
            using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
            {
                SqlCommand rcpCmd1 = new SqlCommand("Delete from rozTmRej ", rcpConnection);
                rcpConnection.Open();
                rcpCmd1.ExecuteNonQuery();
            }
        }
        //private void rejestrDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{

        //}






    }
}
