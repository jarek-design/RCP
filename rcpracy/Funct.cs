using System;
using System.Collections.Generic;
//rcpracy
namespace rcpracy
{
    public static class Funct
    {
        public static string rcpConnStringName = "RCPConnectionStr";
        public static string GratyfConnStringName = "GratyfConString";
        public static string RcpConnectionStr = System.Configuration.ConfigurationManager.ConnectionStrings[rcpConnStringName].ConnectionString;        

        public static void Clear(this System.Text.StringBuilder value)
        {
            value.Length = 0;
            value.Capacity = 0;
            value.Capacity = 16;
        }

        public static string GetGratyfConnectionStr ()
        {
            
            try
            {
                return  System.Configuration.ConfigurationManager.ConnectionStrings[GratyfConnStringName].ConnectionString;
            }
            catch (Exception)
            {

                return null;
            }
           
        }

        public static bool GratyfConnStrTest()
        {
            if (Funct.GetGratyfConnectionStr() == null)
            {
                System.Windows.Forms.MessageBox.Show("Należy określić serwer Gratyfikanta w ustawieniach", "Brak serwera Gratyfikanta",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static void minut2hhmm(System.Windows.Forms.DataGridView dgv, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex > 3 && e.ColumnIndex < 8 && dgv.Columns[e.ColumnIndex].ValueType == typeof(Int16) && Convert.ToInt16(dgv[e.ColumnIndex, e.RowIndex].Value) > 0)
            {
                //int aa = (int) e.Value;
                int min = Convert.ToInt16(dgv[e.ColumnIndex, e.RowIndex].Value);
                e.Value = (min / 60).ToString() + ":" + (min % 60).ToString("00");
            }

        }

        public static Period okres(int nrOkresu)
        {
            DateTime dzis=DateTime.Today.Date;
            Period p1;
            switch (nrOkresu)
            {
                case 1: p1 = new Period(dzis.AddDays(-1), dzis ); // wczoraj
                    break;
                case 2:  p1 = new Period( dzis.AddDays(-6), dzis.AddDays(1)); ; // tydzien
                    break;
                case 3:  p1 = new Period( dzis.AddDays(-30), dzis.AddDays(1)); // miesiac
                    break;

                default:  p1 = new Period(dzis, dzis.AddDays(1));   //dzisiaj
                    break;
            }
            return p1;
        }

        public static void okresComboBoxFill(System.Windows.Forms.ToolStripComboBox cb)
        {
            Okresy ok = new Okresy();
            cb.Items.Clear();
            foreach (string s1 in ok.listaOkresow)
                cb.Items.Add(s1);
        }
        public static void personListIni(System.Windows.Forms.ComboBox cbox, List<int> personIdList)
        {
            personListIni(cbox, personIdList, "wszyscy");
        }
        public static void personListIni(System.Windows.Forms.ComboBox cbox, List <int> personIdList, string zeroPersons)
        {
            cbox.Items.Clear();
            personIdList.Clear();
            if (zeroPersons != null)
            {
                personIdList.Add(0);
                cbox.Items.Add(zeroPersons);                
            }
        }
        public static void pracownikFill(System.Windows.Forms.ComboBox cbox, RcpDataSet ds, List<int> personIdList)
        {
            pracownikFill(cbox, ds, personIdList, "wszyscy");
        }

        public static void pracownikFill(System.Windows.Forms.ComboBox cbox, RcpDataSet ds, List<int> personIdList, string zeroPersons)
        {
            personListIni(cbox, personIdList, zeroPersons);
            System.Data.DataView pracView = new System.Data.DataView(ds.pracownik) { Sort = "Nazwisko, Imie" };
           
            foreach (System.Data.DataRowView dr in pracView)
            {
                cbox.Items.Add(dr["Nazwisko"] + " " + dr["Imie"] + (dr["rfidId"]!= null ?  " ; " + dr["rfidId"] : "" ) );
                personIdList.Add(Convert.ToInt32( dr["pr_Id"]));
            }                         
        }       
    }


    public class Okresy
    {
        public string[] listaOkresow = { "dzisiaj", "wczoraj", "tydzien", "miesiac", "definiowany" };
        
        public Okresy()
        {
         
        }

    }

    public class Period
    {
        public DateTime d1;
        public DateTime d2;
        public Period(DateTime d1, DateTime d2 )
        {
            this.d1 = d1;
            this.d2 = d2;
        }
    }

  
}
