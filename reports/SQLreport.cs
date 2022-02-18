using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace reports
{

    class SQLreport
        {
            // kolumn report
            public columns rapColumns;
            dataBrowser db;
            reportEngine rap;
            ReportExport repExp1 = null;
                      
            List<SQLparam> sqlparam;



            public SQLreport(string connectionString)
            {
                db = new dataBrowser(connectionString);
                rap = new reportEngine();
                sqlparam = new List<SQLparam>();

        }

        // <summary>
        /// dodaje listę parametrów do listy parametrów SQL
        /// </summary>
        /// <param name="sqlPar"></param>
        public void setParam(List<SQLparam> sqlPar)
        {
            foreach (SQLparam sp in sqlPar)
                sqlparam.Add(sp);
        }

        public void setParam(string pName, object pVal)
        {
            sqlparam.Add(new SQLparam { name = pName, val = pVal });
            //, parType = paramType , string paramType
        }

        // todo mozna tu przeniesc z SQLreport() inne inicjacje i przypisania uzyskujac
        // w ten sposob mozliwosc jednej instancji SQL report (a wiec takze reportEngin ) na wiele wydrukow
        // - oszcz. pamieci i mozliwosc wstepnych ustawien reportEngin

        public void open(string queryString,
                       
                         string rapTitle,
                         string rapTitle2,
                         ColumnData columnDef,
                         byte type,
                         bool isLp, bool isExport, string exportPath,
                         short pageBegin, short pageEnd)
            {
                rapColumns = new columns(columnDef.fieldcount);
                rapColumns.setColumnHeaderText(columnDef.ColumnHeaderTextList);
                Funkcje funkcje = new Funkcje(rapColumns);
                FunctionSet fs = new FunctionSet(columnDef, funkcje);
                if (isExport)
                    repExp1 = new ReportExport(exportPath, rapColumns);

                rap.setData(rapColumns, rapTitle, rapTitle2, db, type, pageBegin, pageEnd, repExp1);
                db.setData(columnDef.fields.ToArray(), rapColumns, fs, queryString, sqlparam, isLp);

            }

            public void print()
            {
                rap.Print();
            }

            public void preview()
            {
                rap.ShowPageSettings();
                rap.ShowPreview();
            }

            public void printDialog()
            {
                rap.ShowPageSettings();
                rap.ShowPrintDialog();
            }
        }
      
        class funcColumn
        {
            public delegate void func(int nrcol);
            public func f1;
            public int nrcol;
            public funcColumn(func f1, int nrcol)
            {
                this.f1 = f1;
                this.nrcol = nrcol;
            }
        }
       
        class columns
        {
            public List<List<string>> row;
            public int colquantity;
            public int rowcount;
          
            public List<Int32> sumaInt;
            public bool rowAdded = false;            
            string [] headerText;

            public columns(int cq)
            {
                row = new List<List<string>>();
                colquantity = cq;
                rowcount = 0;
                sumaInt = new List<int>();
                for (int i = 0; i < colquantity; i++)
                {
                    addEmptyColumn();
                    sumaInt.Add(0);                   
                }
            }

            public void addEmptyColumn()
            {
                List<string> column = new List<string>();
                row.Add(column);
            }
            public void addRow(string[] items)
            {
                rowcount++;
                for (int ii = 0; ii < colquantity; ii++)
                {
                    row[ii].Add(items[ii]);

                }
            }

            public void addRow()
            {
                rowcount++;
                for (int ii = 0; ii < colquantity; ii++)
                {
                    row[ii].Add(null);

                }
            }

            public void setColumnHeaderText(List<string> headerTextList)
            {
                this.headerText = headerTextList.ToArray();
                this.addRow(headerText);
            }

            public void clear()
            {
                for (int ii = 0; ii < this.colquantity; ii++)
                    row[ii].Clear();
                rowcount = 0;
               
                this.addRow(this.headerText);
            }

            public void clearAll()
            {
                clear();
               
                for (int i = 0; i < colquantity; i++)
                 sumaInt[i] = 0;
              
                rowAdded = false;                

            }

           
        }



        class dataBrowser
        {

            //string connectionString;
            //string queryString;
            bool connectionOpen;

            SqlConnection connection;
            SqlCommand SQLcmd1;
            SqlDataReader dr;
            string[] fields;
            columns page;
            bool isLp;
            int lp;
          
            FunctionSet funSet;


            public dataBrowser(string connectionString1)
            {
                connection = new SqlConnection(connectionString1);
                connectionOpen = false;
            }


            public void open()
            {
                if (!connectionOpen)
                // connection.State == System.Data.ConnectionState.Open
                {
                    try
                    {
                        page.clearAll();
                        lp = 1;
                        connection.Open();
                        dr = SQLcmd1.ExecuteReader();
                        connectionOpen = true;
                    }
                    catch
                    {
                        MessageBox.Show("nie można zrealizować zapytania SQL");

                    }

                }
            }

          

            public void setData(string[] fields, columns page, FunctionSet funSet, string queryString1, List<SQLparam> param, bool isLp)
            {
                this.fields = fields;
                this.page = page;
                this.funSet = funSet;
                this.isLp = isLp;
                lp = 1;

                SQLcmd1 = new SqlCommand(queryString1, connection);

             
                if (param != null)
                    foreach (var parItem in param)
                    {
                    SQLcmd1.Parameters.Add(new SqlParameter(parItem.name, parItem.val));
                }
             }

            public bool readPage(float rowsToRead)
            {
                //bool columnsFormated = false;
                if (!this.connectionOpen)
                {
                    //MessageBox.Show("Koniec czytania danych");
                    return false;
                }

                string[] items = new string[page.colquantity];
                try
                {
                    page.clear();
                    while (dr.Read())
                    {

                        for (int ii = 0; ii < page.colquantity; ii++)
                        {
                            if (ii == 0 && isLp)
                            {
                                items[0] = (lp++).ToString();
                                continue;
                            }
                            //Type t;

                            items[ii] = dr[fields[ii]].ToString();

                            //if (dr[fields[ii]].GetType() is  )
                            //items[ii] = dr["nazwisko"].ToString();
                        }

                        page.addRow(items);


                        // Jeżeli są jeszcze rekordy do przeczytania to będą one przeczytane następnym razem.
                        if (rowsToRead-- < 1)
                        {
                            funcColumn(funSet.funcList);
                            funcColumn(funSet.formatList);
                            return true;
                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    funcColumn(funSet.formatList);
                    this.close();
                    return false;

                }
                funcColumn(funSet.funcList);
                funcColumn(funSet.endFuncList);
                funcColumn(funSet.formatList);
                this.close();
                return false;
            }

          
            private void funcColumn(List<funcColumn> funcList)
            {
                foreach (funcColumn fcolumn in funcList)
                {
                    fcolumn.f1(fcolumn.nrcol);
                }
            }
            

            public void close()
            {
                if (this.connectionOpen)
                {
                    dr.Close();
                    connection.Close();
                    connectionOpen = false;
                }
            }
        }


        class reportEngine : PrintDocument
        {
            private Font printFont;
            private Font headerFont;
            private Font infoFont;
            private SizeF stringSize;
            Brush printBrush;
        readonly Pen pen = new Pen(Color.DarkKhaki, 3);
        readonly Pen pen1 = new Pen(Color.DarkKhaki, 1);

            float leftMargin;
            float topMargin;
            float rightMargin;
            float pageHight;
            float lineYpos;

        //float leftPos;

            readonly StringFormat format;
            string reportHeader;
            string reportHeader2;
            columns columns1;
            dataBrowser db;
            ReportExport repExp1;
            private int pagenum;
            byte type;
            short pageBegin, pageEnd;

            float yPos;
            int rowsToRead;
            float linesPerPage;
            List<string> naglFirma;

            public List<string> NaglFirma { get => naglFirma; set => naglFirma = value; }

        enum printAction
            {
                rewind,
                print
            }

            public reportEngine()
            {
                printFont = new Font("Arial", 10);
                headerFont = new Font("Arial", 16);
                infoFont = new Font("Arial", 8);
                stringSize = new SizeF();
                format = new StringFormat(StringFormat.GenericTypographic);
                pagenum = 0;
                progSetup.FirmaConfig.Instance.ini();
                //string a = progSetup. FirmaConfig.configF.miejsc;
                NaglFirma = new List<string> { progSetup.FirmaConfig.configF.nazwa, progSetup.FirmaConfig.configF.miejsc };               
            }

            public void setData(columns columns1, string reportHeader, string reportHeader2, dataBrowser db,
                byte type, short pageBegin, short pageEnd, ReportExport repExp1)
            {
                this.reportHeader = reportHeader;
                this.reportHeader2 = reportHeader2;
                this.columns1 = columns1;
                this.db = db;
                this.type = type;
                this.pageBegin = pageBegin;
                this.pageEnd = pageEnd;
                this.repExp1 = repExp1;
            }

            protected override void OnBeginPrint(PrintEventArgs ev)
            {
                base.OnBeginPrint(ev);
                pagenum = 1;
                db.open();
            }


            protected override void OnPrintPage(PrintPageEventArgs ev)
            {

                leftMargin = ev.MarginBounds.Left;
                topMargin = ev.MarginBounds.Top;
                rightMargin = ev.MarginBounds.Right;
                pageHight = ev.MarginBounds.Height;
                base.OnPrintPage(ev);

                while (pagenum < pageBegin)
                    Page(printAction.rewind, ev);

                Page(printAction.print, ev);
            }

            protected override void OnEndPrint(PrintEventArgs e)
            {
                base.OnEndPrint(e);
                if (repExp1 != null)
                    repExp1.close();
            }

            private void Page(printAction action, PrintPageEventArgs ev)
            {
                //try
                //{
                    //printPageHeader 
                    if (pagenum == 1)
                    {
                        if (action == printAction.print)
                            yPos = printInfoText(ev.Graphics, topMargin);

                        yPos = printReportHeader(action, ev.Graphics);

                        linesPerPage = (pageHight - yPos) /
                        printFont.GetHeight(ev.Graphics);

                    }
                    else
                    {
                        yPos = topMargin;
                        linesPerPage = pageHight /
                               printFont.GetHeight(ev.Graphics);

                    }

                    if (type == 1)
                    {
                        ev.HasMorePages = db.readPage(linesPerPage - 2) && pagenum < pageEnd;
                        if (action == printAction.print)
                            printColumns(ev.Graphics, yPos, columns1);
                    }
                    else
                    {
                        rowsToRead = (int)(linesPerPage - 6) / (columns1.colquantity + 2);
                        ev.HasMorePages = db.readPage(rowsToRead) && pagenum < pageEnd;
                        if (action == printAction.print)
                            yPos = printPlain(ev.Graphics, yPos, columns1);
                    }
                    //printFooter
                //}
                //catch
                //{
                //    db.close();
                //    MessageBox.Show("Błąd tworzenia wydruku");
                //}

                pagenum++;
            }

            float printReportHeader(printAction action, Graphics evgraf)
            {

                stringSize = evgraf.MeasureString(reportHeader, headerFont);
                float lf = leftMargin + (rightMargin - leftMargin - stringSize.Width) / 2;
                float linehight = headerFont.GetHeight(evgraf);


                if (action == printAction.print)
                {

                    evgraf.DrawString(reportHeader, headerFont, Brushes.DarkOliveGreen,
                                  lf, yPos, format);
                    yPos += linehight;
                    if (reportHeader2.Trim().Length > 1)
                    {
                        stringSize = evgraf.MeasureString(reportHeader2, printFont);
                        lf = leftMargin + (rightMargin - leftMargin - stringSize.Width) / 2;
                        evgraf.DrawString(reportHeader2, printFont, Brushes.Black,
                                      lf, yPos, format);
                    }
                }
                return yPos + linehight * 2;

            }

            float printInfoText(Graphics evgraf, float yPos)
            {
                

                float linehight = infoFont.GetHeight(evgraf);
 
               
                foreach (string line3 in NaglFirma)
                {
                    evgraf.DrawString(line3, infoFont, Brushes.DarkOliveGreen,
                                                       leftMargin, yPos, format);
                    yPos += linehight;
                }
                return yPos;
            }

            float printColumns(Graphics evgraf, float colTopMargin, columns columns1)
            {
                const float leftspace = 3;

                float linehight = printFont.GetHeight(evgraf);
                //float yPos = colTopMargin;
                float stringWitdh = 0;
                float colMargin = leftMargin + leftspace;
                bool head;
                for (int ii = 0; ii < columns1.colquantity; ii++)
                {
                    colMargin = colMargin + stringWitdh + leftspace;
                    yPos = colTopMargin;
                    stringWitdh = 0;
                    head = true;
                    printBrush = Brushes.Blue;
                    //foreach (string line3 in columns1.row[ii])
                    for (int jj = 0 ; jj < columns1.rowcount; jj++ )                    
                    {
                        string line3 = columns1.row[ii][jj];
                        if (jj == columns1.rowcount - 1 && columns1.rowAdded)
                        {                           
                            yPos += 0.2f*linehight;
                        }
                        yPos += linehight;
                        stringSize = evgraf.MeasureString(line3, printFont);
                        stringWitdh = maxI(stringWitdh, stringSize.Width);
                        evgraf.DrawString(line3, printFont, printBrush,
                                               colMargin, yPos, format);
                        if (head)
                        {
                            lineYpos = yPos + (float)0.7;
                            yPos += (float)3.7;
                            printBrush = Brushes.Black;
                            head = false;
                        }

                       
                    }
                    evgraf.DrawLine(pen1, colMargin - (float)1.5 * leftspace, lineYpos,
                                  colMargin - (float)1.5 * leftspace, yPos + linehight);
                }
                float lineLenght = colMargin + stringWitdh;
                //góra ramki na tytuły
                evgraf.DrawLine(pen, leftMargin - 1, lineYpos - 1,
                                  lineLenght + 1, lineYpos - 1);
                //dół ramki na tytuły
                evgraf.DrawLine(pen, leftMargin, lineYpos + linehight + 2,
                                  lineLenght, lineYpos + linehight + 2);
                //lewa ramka tabeli
                evgraf.DrawLine(pen, leftMargin, lineYpos - 2,
                                  leftMargin, yPos + linehight);
                evgraf.DrawLine(pen, lineLenght, lineYpos - 2,
                                 lineLenght, yPos + 1.1f * linehight);
                if (columns1.rowAdded)
                    evgraf.DrawLine(pen, leftMargin - 1, yPos - .1f * linehight,
                                 lineLenght, yPos - .1f * 1.1f * linehight);

                evgraf.DrawLine(pen, leftMargin - 1.5f, yPos + 1.1f*linehight,
                                 lineLenght+1.5f, yPos + 1.1f * linehight);
                if (repExp1 != null)
                    repExp1.write();
                return yPos;
            }



            float printPlain(Graphics evgraf, float yPos1, columns columns1)
            {
                float linehight = printFont.GetHeight(evgraf);
                float yPos = yPos1;
                float stringWitdh;
                float colMargin;
                string line3;
                Brush pBrush = Brushes.Black;

                for (int el1 = 1; el1 < columns1.rowcount; el1++)
                {
                    yPos1 = yPos;
                    colMargin = leftMargin;
                    stringWitdh = 0;
                    for (int col1 = 0; col1 <= el1; col1 += el1)
                    {
                        yPos = yPos1;
                        colMargin = colMargin + stringWitdh + 15;
                        for (int ii = 0; ii < columns1.colquantity; ii++)
                        {
                            yPos += linehight;
                            line3 = columns1.row[ii][col1];
                            evgraf.DrawString(line3, printFont, pBrush,
                                                       colMargin, yPos, format);

                            stringSize = evgraf.MeasureString(line3, printFont);
                            stringWitdh = maxI(stringWitdh, stringSize.Width);
                        }
                    }
                    yPos += linehight + linehight;
                    evgraf.DrawLine(pen, leftMargin, yPos, rightMargin, yPos);
                }

                return yPos + linehight;
            }


            public void ShowPageSettings()
            {

                PageSetupDialog setup = new PageSetupDialog();
                PageSettings settings = DefaultPageSettings;
                setup.PageSettings = settings;

                // display the dialog and, 
                if (setup.ShowDialog() == DialogResult.OK)
                    DefaultPageSettings = setup.PageSettings;
            }
            // ShowPrintDialog - display the print dialog... 

            public void ShowPrintDialog()
            {

                PrintDialog dialog = new PrintDialog{ PrinterSettings = PrinterSettings, Document=this };
          
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // save the changes... 
                    PrinterSettings = dialog.PrinterSettings;
                    // do the printing... 
                    Print();
                }
            }


            public void ShowPreview()
            {
                // now, show the print dialog... 
                PrintPreviewDialog dialog = new PrintPreviewDialog{ Document = this };
      
                // show the dialog... 
                dialog.ShowDialog();
            }



            private float maxI(float aa, float bb)
            {
                if (aa > bb)
                    return aa;
                else
                    return bb;
            }

        }

        class ReportExport
        {
            List<string[]> kolumny = new List<string[]>();
            StreamWriter exportWriter;
            //string reportHeader;
            //string reportHeader2;
            // , string reportHeader, string reportHeader2
            columns columns1;
            int pocz;
            public ReportExport(string exportPath, columns columns1)
            {
                exportWriter = new StreamWriter(exportPath, false, Encoding.GetEncoding("Windows-1250"));
                this.columns1 = columns1;
                pocz = 0;

                //this.reportHeader = reportHeader;
                //this.reportHeader2 = reportHeader2;
            }

            public void write()
            {
                kolumny.Clear();
                foreach (List<string> column1 in columns1.row)
                {
                    kolumny.Add(column1.ToArray()); // przygotwanie kolumn
                }

                for (int jj = pocz; jj < columns1.rowcount; jj++)
                {
                    foreach (string[] c in kolumny)
                    {
                        exportWriter.Write(c[jj] + ";");
                    }
                    exportWriter.WriteLine();
                }
                pocz = 1; // tylko pierwsz stron zawiera nagłowki ktore znajduja sie w pierwszej linii.
            }

            public void close()
            {
                exportWriter.Close();
            }

            //exportWriter.Close();
        }

        public class SQLparam
        {
            public string name;
            public object val;
           
        }

        public class ColumnData
        {
            public List<bool> initList;
            public List<string> fields;
            public List<string> ColumnHeaderTextList;
            public List<string> formatList;
            public List<string> funcList;
            public List<string> endFuncList;
            public short fieldcount;

            public ColumnData()
            {
                initList = new List<bool>();
                fields = new List<string>();
                ColumnHeaderTextList = new List<string>();
                formatList = new List<string>();
                funcList = new List<string>();
                endFuncList = new List<string>();
                fieldcount = 0;
            }
            public short add (bool init, string field, string ColumnHeaderText, string  format, string  func, string endFunc)
            {
                initList.Add(init);
                fields.Add(field);
                ColumnHeaderTextList.Add(ColumnHeaderText);
                formatList.Add(format);
                funcList.Add(func);
                endFuncList.Add(endFunc);
                fieldcount = (short)fields.Count;
                return fieldcount;
            }
            public short add( string field, string ColumnHeaderText)
            {
                initList.Add(true);
                fields.Add(field);
                ColumnHeaderTextList.Add(ColumnHeaderText);
               
                fieldcount = (short)fields.Count;
                return fieldcount;
            }

        }

 }

