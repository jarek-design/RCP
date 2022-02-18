using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace reports
{
    class Funkcje
    {
        columns columns1;

        public Funkcje(columns columns1)
        {
            this.columns1 = columns1;
        }


        public void formatDate(int nrcol)
        {
            wytnijString(nrcol, 10);
        }

        public void formatDateTime(int nrcol)
        {

            wytnijString(nrcol, 16);
            //columns1.row[nrcol][ii] = String.Format("{0:dd-mm-yyyy HH:mm}", Convert.ToDateTime(columns1.row[nrcol][ii]));
        }

        public void formatShortDateTime(int nrcol)
        {
            wytnijString(nrcol, 5, 11);
        }

        public void formatTime(int nrcol)
        {
            wytnijString(nrcol, 11, 5);
        }


        private void wytnijString(int nrcol, int strLen)
        {
            try
            {
                for (int ii = 1; ii < columns1.rowcount; ii++)
                {
                    if (columns1.row[nrcol][ii] != null && columns1.row[nrcol][ii].Length > strLen - 1)
                        columns1.row[nrcol][ii] = columns1.row[nrcol][ii].Substring(0, strLen);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void wytnijString(int nrcol, int start, int strLen)
        {
            try
            {
                for (int ii = 1; ii < columns1.rowcount; ii++)
                {
                    if (columns1.row[nrcol][ii] != null && columns1.row[nrcol][ii].Length > strLen - 1)
                        columns1.row[nrcol][ii] = columns1.row[nrcol][ii].Substring(start, strLen);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void formatHourMin(int nrcol)
        { // from minut
            try
            {
                for (int ii = 1; ii < columns1.rowcount; ii++)
                {
                    int min = Convert.ToInt32(columns1.row[nrcol][ii]);
                    columns1.row[nrcol][ii] = String.Format("{0,9}", (min / 60).ToString() + ":" + (min % 60).ToString("00"));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void sumInt(int nrcol)
        {
            try
            {
                for (int ii = 1; ii < columns1.rowcount; ii++)
                {
                    columns1.sumaInt[nrcol] += Convert.ToInt32(columns1.row[nrcol][ii]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void printSum(int nrcol)
        {
            if (!columns1.rowAdded)
            {
                columns1.rowAdded = true;
                columns1.addRow();
                columns1.row[0][columns1.rowcount - 1] = "Suma";

            }

            columns1.row[nrcol][columns1.rowcount - 1] = columns1.sumaInt[nrcol].ToString();
        }

    }

    class FunctionSet
    {
        public List<funcColumn> formatList;   // format columny
        public List<funcColumn> funcList;
        public List<funcColumn> endFuncList;

        public FunctionSet(List<funcColumn> formatList, List<funcColumn> funcList, List<funcColumn> endFuncList)
        {
            formatList = new List<funcColumn>();
            funcList = new List<funcColumn>();
            endFuncList = new List<funcColumn>();

            this.formatList = formatList;
            this.funcList = funcList;
            this.endFuncList = endFuncList;

        }


        public FunctionSet(ColumnData columnDef, Funkcje funkcje)
        {

            formatList = addFunctions(columnDef, funkcje, columnDef.formatList);
            funcList = addFunctions(columnDef, funkcje, columnDef.funcList);
            endFuncList = addFunctions(columnDef, funkcje, columnDef.endFuncList);

        }

        private List<funcColumn> addFunctions(ColumnData columnDef, Funkcje funkcje, List<string> columnDefFunc)
        {
            short jjj = 0;
            List<funcColumn> fList = new List<funcColumn>();
            foreach (string formatStr in columnDefFunc)
            {   // todo powinno być jjj>=0 ale dziala tylko jjj>0
                if (formatStr != null)
                {
                    switch (formatStr.ToLower().Trim())
                    {
                        case "date": fList.Add(new funcColumn(funkcje.formatDate, jjj));
                            break;
                        case "datetime": fList.Add(new funcColumn(funkcje.formatDateTime, jjj));
                            break;
                        case "hourmin": fList.Add(new funcColumn(funkcje.formatHourMin, jjj));
                            break;
                        case "suma": fList.Add(new funcColumn(funkcje.sumInt, jjj));
                            break;
                        case "printsum": fList.Add(new funcColumn(funkcje.printSum, jjj));
                            break;
                        case "shortdatetime": fList.Add(new funcColumn(funkcje.formatShortDateTime, jjj));

                            break;
                        case "time": fList.Add(new funcColumn(funkcje.formatTime, jjj));		
                            break;

                        default:
                            break;
                    }
                }

                jjj++;
            }
            return fList;
        }
    }
}
