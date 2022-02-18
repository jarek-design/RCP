using System;
using System.Linq;
using System.Xml.Linq;

namespace Extensions1
{  
    public static class Gfunc
       
    {/// <summary>
     /// Funkcja do odczytu ConnectionString z pliku konfiguracji
     /// stosowana głównie w wydrukach i w tych bibliotekach które w momencie projektowania 
     /// nie mają jeszcze tych wartości określonych i nie mogą korzystać ze sposobu używanego w Funct.cs
     /// </summary>
     /// <param name="connStringName"></param>
     /// <returns></returns>
        public static string GetConnString(string connStringName)
        {
            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            //Find all connection strings
            var query1 = from p in doc.Descendants("connectionStrings").Descendants()
                         select p;

            //Go throught each connection string elements find atribute specified by argument and replace its value with newVAlue
            foreach (var child in query1)
            {
                foreach (var atr in child.Attributes())
                {
                    if (atr.Name.LocalName == "name" && atr.Value == connStringName)
                        if (atr.NextAttribute != null && atr.NextAttribute.Name == "connectionString")
                            return atr.NextAttribute.Value.ToString();
                }
            }
            return null;
        }

        public static string setConnString(string dataFile, string dbAdres)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder csBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            if (!String.IsNullOrEmpty(dbAdres))
            {
                csBuilder.DataSource = dbAdres;
                if (!csBuilder.DataSource.EndsWith(@"\"))
                    csBuilder.DataSource += @"\";
                csBuilder.DataSource += dataFile; //"rejestr.sdf";

                return csBuilder.ToString();
            }
            return null;
        }

        public static DateTime dtPickerSplit(System.Windows.Forms.DateTimePicker date1, System.Windows.Forms.DateTimePicker time1)
        {
            DateTime d1 = date1.Value;
            return new DateTime(d1.Year, d1.Month, d1.Day, time1.Value.Hour, time1.Value.Minute, 0);
        }

        public static DateTime dateValueDtPicker(System.Windows.Forms.DateTimePicker date1)
        {
            return date1.Value.Date;
        }

        public static DateTime datePart(DateTime d1)
        {
            return new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
        }

        public static DateTime timeSplit(DateTime actDate, int hour, int minutes)
        {
            return new DateTime(actDate.Year, actDate.Month, actDate.Day, hour, minutes, 0);
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

        

    }
}
