using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace reports
{
    public partial class repStart : Form
    {

        string reportConString, connectionString;
        string queryString;
        
        string rapTitle;
        string rapTitle2;

        public List<SQLparam> paramList;
        SQLreport rap1;
        short parameterCount;
        List<string>  parName;
        
        Control mtb;
        Label lab;
        Button but;
        ColumnData columnDef, selectedColumn;

        public repStart(string connectionString)
        {            
            InitializeComponent();
            parName = new List<string> ();
           
            reportConString = Extensions1.Gfunc.GetConnString("RCPConnectionStr"); 
            this.connectionString = connectionString;
            columnDef = new ColumnData();
        }

        public void setParam(List<SQLparam> paramList)
        {
            this.paramList = paramList;
        }

        private void SzybkiWydr_Click(object sender, EventArgs e)
        {
            PrintSQL();            
            rap1.print();
        }


        private void Preview_Click(object sender, EventArgs e)
        {
            PrintSQL();
            rap1.preview();
        }


        private void Wydr_Click(object sender, EventArgs e)
        {
            PrintSQL();
            rap1.printDialog();
        }

        private void PrintSQL()
        {
            byte type;
            short pageBegin, pageEnd;
            this.Cursor = Cursors.WaitCursor;

            if (radioButton1.Checked)
                type = 1;
            else
                type = 2;

            if (textBox1.Text.Length == 0)
                pageBegin = 0;
            else
                pageBegin = Convert.ToInt16(textBox1.Text);

            if (textBox2.Text.Length == 0)
                pageEnd = 32000;
            else
                pageEnd = Convert.ToInt16(textBox2.Text);
            
            rapTitle2 = textBox2opis.Text.Trim();
            rapTitle = textBox1opis.Text.Trim();
            SelectFields();

            rap1 = new SQLreport(connectionString);
            rap1.setParam(paramList);
            this.Cursor = Cursors.Default;

            if (parameterCount > 1)
            {
                for (int jj = 1; jj < parameterCount; jj++)
                {
                    mtb = MaskedTextBox(jj);
                    if (mtb.Visible)
                        rap1.setParam(parName[jj], mtb.Text);
                    else
                    {
                        mtb = DateTimePicker(jj);
                        if (mtb.Visible)
                        {
                            DateTime tmpDate1 =  ((DateTimePicker)mtb).Value ;
                            rap1.setParam(parName[jj], tmpDate1);
                        }
                    }

                }
            }
            rap1.open(queryString, rapTitle, rapTitle2, selectedColumn, type, LpCheckBox1.Checked, ExportCheckBox2.Checked, ExpTextBox4.Text, pageBegin, pageEnd);

        }

        private DateTime StartDay(DateTime tmpDate)
        {            
            return new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, 0, 0, 0);
        }

        private DateTime EndDay(DateTime tmpDate)
        {
            return new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, 23, 59, 59);
        }

        private void F2print_Load(object sender, EventArgs e)
        {
                        
        }

 //     private void fieldsInitialize ()
       

        private void SelectFields()
        { 
        selectedColumn = new ColumnData();

        for (int ii = 0; ii < listBox1.Items.Count; ii++)
        {
            if (ii == 0 && LpCheckBox1.Checked)
            {   // jezeli jest Lp to nastepuje dodanie kolumny Lp               
                selectedColumn.add( "","Lp" );
                    
            } 
            if (listBox1.GetSelected(ii) == true)
            {

                selectedColumn.add(true, columnDef.fields[ii],
                    columnDef.ColumnHeaderTextList[ii],
                    columnDef.formatList[ii], columnDef.funcList[ii], columnDef.endFuncList[ii]);               
            }
        }
        //columnDef = selectedColumn;
        }
        public void RealizWydr(Int16 id, string opis1, string opis2)
        { // id identyfikator raportu
            textBox1opis.Text = opis1;
            textBox2opis.Text = opis2;
            RealizWydr(id);
        }


        public void RealizWydr(Int16 id, string sqlWar, string opis1, string opis2)
        { // id identyfikator raportu
            textBox1opis.Text = opis1;
            textBox2opis.Text = opis2;
            RealizWydr(id, sqlWar);
        }

        public void RealizWydr(Int16 id)
        {
            RealizWydr(id, null);
        }


        public void RealizWydr(Int16 id, string sqlWar)
        {
            parameterCount = 1;
            

            this.Cursor = Cursors.WaitCursor;
            //przypisanie parametrów wydruku
           
            SqlConnection reportConnection = new SqlConnection(reportConString);
            SqlCommand sqlCommand2 = new SqlCommand();
            SqlCommand reportCmd1 = sqlCommand2;
            reportCmd1.Connection = reportConnection;

            ReadReport(id, reportConnection, reportCmd1);
            queryString += sqlWar;

            listBox1.Items.Clear();
            for (int jj = 1; jj < 5; jj++)
            {
                lab = Label(jj);
                lab.Visible = false;
                mtb = MaskedTextBox(jj);
                mtb.Visible = false;
                mtb = DateTimePicker(jj);
                mtb.Visible = false;
                mtb = ComboBox(jj);
                mtb.Visible = false;

            }

            SqlDataReader repoRead;
            reportCmd1.CommandText = "SELECT * FROM reportParam where idrep = " + id.ToString();
            repoRead = reportCmd1.ExecuteReader();
            while (repoRead.Read())
            {
                lab = Label(parameterCount);
                if (repoRead["paramtype"].ToString().Trim() == "data")
                    mtb = DateTimePicker(parameterCount);
                else
                    if (repoRead["paramtype"].ToString().Trim() == "combo")
                    {
                        mtb = ComboBox(parameterCount);
                        Fill((ComboBox) mtb, repoRead["comboDataSql"].ToString());
                    }
                    else
                        mtb = MaskedTextBox(parameterCount);

                mtb.Visible = true;
                lab.Text = repoRead["label"].ToString();
                lab.Visible = true;
                parName.Add("@" + repoRead["paramname"].ToString());
                parameterCount++;
            }
           
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.BeginUpdate();

            foreach (string item1 in columnDef.ColumnHeaderTextList)
                if(item1!=null)
                listBox1.Items.Add(item1);

            for (int jj = 0; jj < columnDef.fieldcount; jj++)
                if (columnDef.ColumnHeaderTextList[jj] != null)
                    listBox1.SetSelected(jj, columnDef.initList[jj]);
            
            listBox1.EndUpdate();
            
            //selectFields();
            this.Cursor = Cursors.Default;
            listBox1.Visible = true;

            for (int jj =1; jj< 4; jj++)
            {
                but = button(jj);
                but.Enabled=true;
                but.ForeColor= Color.Black;
            }
        }

        private void ReadReport(Int16 id, SqlConnection reportConnection, SqlCommand reportCmd1)
        {
            reportCmd1.CommandText = "SELECT * FROM report where idreport = " + id.ToString();
            reportConnection.Open();
            SqlDataReader repoRead = reportCmd1.ExecuteReader();

            if (repoRead.Read())
            {
                queryString = repoRead["sql"].ToString();
                if (String.IsNullOrEmpty(textBox1opis.Text + textBox1opis.Text))
                {
                    textBox1opis.Text = repoRead["title"].ToString().TrimEnd();
                    textBox2opis.Text = repoRead["title2"].ToString().TrimEnd();
                }
            }
            repoRead.Close();

            reportCmd1.CommandText = "SELECT * FROM repcolumn where idrep = " + id.ToString();
            repoRead = reportCmd1.ExecuteReader();
            while (repoRead.Read())
            {
                columnDef.add(Init(repoRead),
                    repoRead["fields"].ToString(),
                    repoRead["headers"].ToString(),
                    repoRead["format"].ToString(),
                    repoRead["func"].ToString(),
                    repoRead["endFunc"].ToString());
            }
            repoRead.Close();

        }

        private bool Init(SqlDataReader repoRead)
        {
            if (repoRead["init"].ToString().Length > 0)
                return ((bool)repoRead["init"]);
            else
                return false;
        }

        private void Fill(ComboBox mtb, string sqlString )
        {
            throw new NotImplementedException();
        }

        Control MaskedTextBox(int jj)
        {
            switch (jj)
            {   case 1 : return maskedTextBox1;
                case 2 : return maskedTextBox2;
                case 3 : return maskedTextBox3;
                case 4 : return maskedTextBox4;
                default: return null;
            }
        }

        Control DateTimePicker(int jj)
        {
            switch (jj)
            {
                case 1: return dateTimePicker1;
                case 2: return dateTimePicker2;
                case 3: return dateTimePicker3;
                case 4: return dateTimePicker4;
                default: return null;
            }
        }
        
        Control ComboBox(int jj)
        {
            switch (jj)
            {
                case 1: return comboBox1;
                case 2: return comboBox2;
                case 3: return comboBox3;
                case 4: return comboBox4;
                default: return null;
            }
        }
        Label Label(int jj)
        {
            switch (jj)
            {   case 1: return label1; 
                case 2: return label2; 
                case 3: return label3; 
                case 4: return label4; 
                default: return null;
            }
        }

        Button button(int jj)
        {
            switch (jj)
            {   case 1: return button2;
                case 2: return button1;
                case 3: return button3;
                //case 4: return button4;
                default: return null;
            }
        }

        private void ExportCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ExportCheckBox2.Checked)
                ExpTextBox4.Visible = true;
            else
                ExpTextBox4.Visible = false;
        }


    
    }
}
