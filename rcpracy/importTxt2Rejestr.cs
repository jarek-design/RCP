using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Text;


namespace rcpracy
{

    class importTxt2Rejestr
    {     
        
        StreamWriter Logfile;
        System.Text.StringBuilder cmdText1;
        StreamReader impFile;
        int lineNr;
        //int lastNr;
        string file2RejestrPath, logFileP;
        bool importCanceled , FilesOpened;
        
       
        BackgroundWorker BackGndWorker1;
        
         string testWe = "SELECT idr, czasWe, czasDo  FROM rejestr  WHERE  pr_Id = @prId  AND ";
         string testDo; 
         
        public importTxt2Rejestr()
        {
            testDo = testWe + "czasDo = @czas ";
            testWe = testWe + "czasWe= @czas ";
            Configuration.Instance.ini();
            importCanceled = false;
        } 

        public void importTxt2RejestrIni(string file2RejestrPath, string logFileP1)
        {           
            cmdText1 = new StringBuilder();
            this.logFileP = logFileP1;
            Logfile = new System.IO.StreamWriter(logFileP);
            
            this.file2RejestrPath = file2RejestrPath;
            impFile = new StreamReader(file2RejestrPath);
            FilesOpened = true;
                      
            InitializeBackgroundWorker();                          
        }

        
        public event EventHandler<ImportEventArgs> RaiseCustomEvent;

        /// <summary>
        /// Wysyła informacje do klasy nadrzędnej w postaci zdarzenia
        /// </summary>
        /// <param name="e"> e określne w klasie ImportEventArgs</param>

        protected virtual void SendMessage(ImportEventArgs e)
        
        {          
            EventHandler<ImportEventArgs> raiseEvent = RaiseCustomEvent;
            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                raiseEvent(this, e);                
            }
        }

        int iniProgressBar(string file2RejestrPath)
        {
            int maxLineNr = 0;
            string line;
            using (StreamReader file = new StreamReader(file2RejestrPath))
            {
                while ((line = file.ReadLine()) != null && !importCanceled)
                {
                    maxLineNr++;
                }
            }
            return maxLineNr;
        }


        void InitializeBackgroundWorker()
        {
            this.BackGndWorker1 = new BackgroundWorker();
            BackGndWorker1.DoWork +=
                new DoWorkEventHandler(txt2Rejestr);
            
            BackGndWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

            BackGndWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            BackGndWorker1.WorkerReportsProgress = true;
        }

        public void importRejestrStart()
        {
            BackGndWorker1.RunWorkerAsync();
        }

        public void importRejestrStop()
        {
            importCanceled = true;
            if (BackGndWorker1.IsBusy)
            {
                if (FilesOpened)
                {
                    Logfile.WriteLine("Przerwano ");
                }
                SendMessage(new ImportEventArgs(importEventStatus.stop,
                    new MessageBoxInfo { isInfo = true, txt1 = "", txt2 = "Import został przerwany" }, 0));
                BackGndWorker1.CancelAsync();
                txt2RejClear();
            }

        }


         void txt2Rejestr(object sender,DoWorkEventArgs e)
        {
                        
            string line = "", NNN, WEwy;
            int  YYY, MM, DD, HH, min, KE, kk = 0, iii =0;
            string[] items;
            lineNr = 0;
            //lastNr = 0;
            Logfile.WriteLine("Start.." + DateTime.Now.ToLongTimeString());
            int maxLineNr = iniProgressBar(file2RejestrPath);
            maxLineNr = maxLineNr / 10;

            using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
            {              
                SqlCommand rcpCmd1 = new SqlCommand();
                rcpCmd1.Connection = rcpConnection;
                rcpConnection.Open();
               // rcpCmd1.Parameters.Add(new SqlParameter("@prId", SqlDbType.Int)); //("@prId", idPrac);
               // rcpCmd1.Parameters.Add(new SqlParameter("@czas", SqlDbType.DateTime));     // "@czas", DateTime.Now.dateHourMin());

                
                while ((line = impFile.ReadLine()) != null && !importCanceled)
                {
                    lineNr++;
                    if (iii > maxLineNr)
                    {   //wykonano 1/10 
                        BackGndWorker1.ReportProgress(10 * kk);
                        iii = 0;
                        kk++;
                        if (maxLineNr == 0 || kk > 10)
                            kk = 10; // dla b. krótkich plików
                        //10*k to wykonanie w procentach
                    }
                    try
                    {
                        items = line.Split(Configuration.confData.impSepa.ToCharArray(0,1));

                        NNN = items[0];
                        YYY = int.Parse(items[1]);
                        MM = int.Parse(items[2]);
                        DD = int.Parse(items[3]);
                        HH = int.Parse(items[4]);
                        min = int.Parse(items[5]);
                        WEwy = items[6];
                    }
                    catch (Exception)
                    {
                        WriteLog("Błąd odczytu ");                     
                        continue;
                    }
                    if (WEwy == Configuration.confData.impWe)
                        KE = 0;
                    else
                        KE = 1;

                        zapisRejestr(rcpCmd1, NNN, new DateTime(YYY, MM, DD, HH, min, 0), KE);
                }
            }
            Logfile.WriteLine("Koniec.." + DateTime.Now.ToLongTimeString());
            txt2RejClear();           
            return;         
        }

         private void backgroundWorker1_ProgressChanged(object sender,
             ProgressChangedEventArgs e)
         {
             if (e.ProgressPercentage< 100 )
                SendMessage(new ImportEventArgs(importEventStatus.progres, MessageBoxInfo.NoMessage(), e.ProgressPercentage));
         }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MessageBoxInfo Message;
            if (e.Error != null)
            {
                Message = new MessageBoxInfo { isInfo = true, txt1 = "Błąd", txt2 = e.Error.Message };
            }
            else
            {
                Message = new MessageBoxInfo { isInfo = true, txt1 = "Wynik importu", txt2 = "Plik : " + logFileP };
            }
            SendMessage(new ImportEventArgs(importEventStatus.stop, Message, 0));
            // wysyła informacje do innej klasy (w tym przypadku do klasy Rejestr)

        }
   


        private void txt2RejClear()
        {
            if (FilesOpened)
            {
                cmdText1.Clear();
                Logfile.Close();
                impFile.Close();
                FilesOpened = false;
            }
        }

      

        
         void clearRejestr(SqlCommand rcpCmd1)
         {
             rcpCmd1.CommandText = "Delete from rozTmRej";
             rcpCmd1.ExecuteNonQuery();
             //rcpCmd1.CommandText = "Delete from rozlTmp";
             //rcpCmd1.ExecuteNonQuery();
            
         }

         /// <summary>
         ///  
         /// </summary>
         /// <param name="rcpCmd1"></param>
         /// <param name="idRCP">identyfikator z czytników</param>
         /// <param name="czas"></param>
         /// <param name="weWy">0-wejscie 1-wyjście</param>
         /// <returns></returns>
         int zapisRejestr(SqlCommand rcpCmd1, string idRCP, DateTime czas, int weWy)
        {
          //  if (lineNr < 3)
           //     clearRejestr(rcpCmd1); // DANGER!! tylko debug, potem usunąc  - zob. func przed wlaczeniem


                PracownikGrupa pracGr = GetPracownik(idRCP);
                if (pracGr.idPrac <= 0)
                {
                    return 0;
                }
                if (testExistRejestr(rcpCmd1, pracGr.idPrac, czas, weWy))
                {
                    WriteLog("powtórzenie wpisu dla " + idRCP.ToString() + " -  "+ czas.ToShortDateString() +" " + czas.ToShortTimeString());
                    return 0;
                }
                if (!pracaNiedziela(czas, pracGr))
                {
                    WriteLog("praca w niedziele nie jest możliwa dla " + idRCP.ToString() + " -  " + czas.ToShortDateString() );
                    return 0;

                }
                if (!pracaSobota(czas, pracGr))
                {
                    WriteLog("praca w sobotę nie jest możliwa dla " + idRCP.ToString() + " -  " + czas.ToShortDateString());
                    return 0;

                }

                cmdText1.Clear();
                rcpCmd1.Parameters.Clear();
                cmdText1.Append("SELECT idr, czasWe, czasDo  FROM rejestr ");
                cmdText1.Append(" WHERE  pr_Id = @prId AND ( ");
                if (weWy == 0)
                    cmdText1.Append("czasWe IS NULL ");
                else
                     cmdText1.Append("czasDo IS NULL ");
                cmdText1.Append (" OR czasWe = @czas OR czasDo = @czas )" );
                if (weWy == 0)
                   cmdText1.Append(" ORDER BY czasDo Desc ");
                else
                    cmdText1.Append(" ORDER BY czasWe Desc ");
                rcpCmd1.CommandText = cmdText1.ToString();

                rcpCmd1.Parameters.AddWithValue("@prId", pracGr.idPrac);
                rcpCmd1.Parameters.AddWithValue("@czas", czas);
                try
                {
                    SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();
                 
                    if (rcpPrac.HasRows && rcpPrac.Read())
                        return AnalizaWyjscia(idRCP, czas, weWy, pracGr, rcpPrac, 0);

                    else
                    {
                        if (weWy == 0)
                            zapisWejscia(pracGr.idPrac, czas, 0L);
                        else
                        {                          
                            WriteLog("brak wejscia dla " + idRCP.ToString());
                            zapisWyjscia(0, czas, pracGr, czas); //utworzenie nowego rekordu z czasem wyjscia. czas wejścia fikcyjny ponieważ nie będzie użyty
                        }
                    }
                }
                catch (Exception)
                {                   
                    WriteLog("Błąd funkcji zapisRejestr() ");
                }                   
           
             return 1;

        }

         bool testExistRejestr(SqlCommand rcpCmd1, int idPrac, DateTime czas, int weWy)
         {

             rcpCmd1.Parameters.Clear();
             if (weWy == 0)
                  rcpCmd1.CommandText = testWe;
              else
                  rcpCmd1.CommandText = testDo;

             rcpCmd1.Parameters.AddWithValue("@prId", idPrac);
             rcpCmd1.Parameters.AddWithValue("@czas", czas);

             try
                {
                    SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();                 
                    if (rcpPrac.HasRows )
                        return true;
                }
                  catch (Exception)
                {                   
                    WriteLog("Błąd funkcji testExistRejestr() ");
                }      
             return false;
         }

         bool pracaSobota(DateTime d1, PracownikGrupa pracGr )
         {
             if (d1.DayOfWeek != DayOfWeek.Saturday)
                 return true;
             else
             if (d1.DayOfWeek == DayOfWeek.Saturday && pracGr.pracaSob)
                 return true;
             else
                 return false;
         }

         bool pracaNiedziela(DateTime d1, PracownikGrupa pracGr)
         {
             if (d1.DayOfWeek != DayOfWeek.Sunday)
                 return true;
             else
             if (d1.DayOfWeek == DayOfWeek.Sunday && pracGr.pracaNiedz)
                 return true;
             else
                 return false;
         }

         private int AnalizaWyjscia(string idRCP, DateTime czas, int weWy, PracownikGrupa pracGr, SqlDataReader rcpPrac, int iloscRekurencji)
         {

             if (rcpPrac["czasWe"] != DBNull.Value && rcpPrac["czasDo"] != DBNull.Value)
                
             {
                 WriteLog("powtórzenie wpisu dla " + idRCP.ToString());
                 return 0;
             }
             else
                 if (rcpPrac["czasWe"] != DBNull.Value && rcpPrac["czasDo"] == DBNull.Value && weWy == 1)
                 {
                     if (rcpPrac.GetDateTime(rcpPrac.GetOrdinal("czasWe")) > czas)
                     {
                         WriteLog("Czas wejscia jest pozniejszy niz wyjscia " + idRCP.ToString());
                         zapisWyjscia(0, czas, pracGr, czas); //utworzenie nowego rekordu z czasem wyjscia
                     }
                     else
                     if (rcpPrac.GetDateTime(rcpPrac.GetOrdinal("czasWe")).AddHours(18) > czas)
                         zapisWyjscia((Int64)rcpPrac.GetSqlInt64(0), rcpPrac.GetDateTime(rcpPrac.GetOrdinal("czasWe")), pracGr, czas); //dopisanie czasu wyjscia do ist. rekordu
                     else
                     {
                         WriteLog("Różnica wejscia i wyjscia wieksza niz 12h " + idRCP.ToString());
                         zapisWyjscia(0, czas, pracGr, czas); //utworzenie nowego rekordu z czasem wyjscia
                     }

                 }
                 else
                     if (rcpPrac["czasWe"] == DBNull.Value && rcpPrac["czasDo"] != DBNull.Value && weWy == 0)
                     {
                         if (czas < rcpPrac.GetDateTime(rcpPrac.GetOrdinal("czasDo")))
                             zapisWejscia(pracGr.idPrac, czas, (Int64)rcpPrac.GetSqlInt64(0));
                         else
                         {                            
                             if (iloscRekurencji < 3 && rcpPrac.Read())
                             {
                                 WriteLog("Brak rozwiazania dla " + idRCP.ToString());
                                 AnalizaWyjscia(idRCP, czas, weWy, pracGr, rcpPrac, iloscRekurencji++);
                                 return 2;                                                                                       
                             }
                             else
                             {
                                 WriteLog("Czas wyjścia wczesniejszy niz wejscia " + idRCP.ToString());
                                 zapisWejscia(pracGr.idPrac, czas, 0L);
                             }
                         }
                     }
             return 1;
         }

         private void WriteLog(string info)
         {
             Logfile.Write("linia nr " + lineNr.ToString() + " : ");
             Logfile.WriteLine(info);
         }




         PracownikGrupa GetPracownik(string rfidId)
        {
            using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
            {
                SqlCommand rcpCmd1 = new SqlCommand();
                rcpCmd1.Connection = rcpConnection;
                rcpConnection.Open();

                PracownikGrupa pracGrup = new PracownikGrupa();
                try
                {
                    rcpCmd1.CommandText = @"SELECT pr_Id, wymiarPracy, godzNadl, pracaSob, pracaNiedz, gratyf FROM pracownik left outer join grupa on idGrup = pracownik.grupa where rfidId = '" + rfidId +"'";
                    SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();
                    if (rcpPrac.HasRows && rcpPrac.Read())
                    {
                        pracGrup.idPrac = (Int32)rcpPrac.GetSqlInt32(0);
                        if (!rcpPrac.IsDBNull(2))
                        {
                            pracGrup.godzNadl = (bool)rcpPrac.GetBoolean(rcpPrac.GetOrdinal("godzNadl"));
                            pracGrup.pracaSob = (bool)rcpPrac.GetBoolean(rcpPrac.GetOrdinal("pracaSob"));
                            pracGrup.pracaNiedz = (bool)rcpPrac.GetBoolean(rcpPrac.GetOrdinal("pracaNiedz"));
                            pracGrup.gratyf = (bool)rcpPrac.GetBoolean(rcpPrac.GetOrdinal("gratyf"));
                            pracGrup.wymiarPracy = (short)rcpPrac.GetInt16(rcpPrac.GetOrdinal("wymiarPracy"));
                        }
                    }
                    else
                    {
                        WriteLog("Nie znaleziono pracownika " + rfidId);
                        pracGrup.idPrac = 0;
                    }

                }
                catch (Exception)
                {
                    WriteLog("Błąd Sql podczas szukania pracownika " + rfidId);
                    pracGrup.idPrac = - 1;
                }
                return pracGrup;
            }
        }
        /// <summary>
        /// zapisuje czas wyjscia do tabeli rejestr
        /// </summary>
        /// <param name="rejestrId">jezeli brak rekordu - 0</param>
        /// <param name="idPrac"> czas wejścia</param>
        /// <param name="idPrac"> id pracownika</param>
        /// <param name="czasPracy"> czas wyjścia</param>
        private  void zapisWyjscia(Int64 rejestrId, DateTime czasWe, PracownikGrupa pracGr, DateTime czasPracy)
        {
            DateTime czasPracy2 = czasPracy;  // czas przed zmianami
            cmdText1.Clear();
            if (rejestrId != 0)   // istnieje rekord z czasem wejścia.
            {
                if (czasWe.AddHours(Configuration.confData.maxGodz) < czasPracy)
                    czasPracy = czasWe.AddHours(Configuration.confData.maxGodz);
               
                if (!pracGr.godzNadl )
                    czasPracy = czasWe.AddMinutes(pracGr.wymiarPracy);  // jeżeli nie ma godzin nadliczbowych to wykazywane są godziny pracy wyn. z umowy
                                                                        // róznice przezentowane na wydrukach

                //if (!pracGr.godzNadl && czasWe.AddHours(Configuration.confData.normaDzienna) < czasPracy)
                //    czasPracy = czasWe.AddHours(Configuration.confData.normaDzienna);
                // if (!pracGr.godzNadl && czasWe.AddMinutes(pracGr.wymiarPracy) < czasPracy)  // warunek przed zmianą na potrzeby godz do odebrania


                cmdText1.Append("UPDATE rejestr set czasDo = @czas, czasDo1 = @czas2 where idr = ");
                cmdText1.Append(rejestrId);
            }
            else
            {
                czasPracy2 = czasPracy;
                cmdText1.Append("INSERT INTO rejestr (pr_Id, czasDo, czasDo1) VALUES ");
                cmdText1.Append("(@prId, @czas, @czas2  )");
            }

            try
            {
                using (SqlConnection updConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand updCmd1 = new SqlCommand();
                    updCmd1.Connection = updConnection;
                    updConnection.Open();
                    updCmd1.CommandText = cmdText1.ToString();
                    updCmd1.Parameters.AddWithValue("@czas", czasPracy);
                    updCmd1.Parameters.AddWithValue("@czas2", czasPracy2);
                    updCmd1.Parameters.AddWithValue("@prId", pracGr.idPrac);

                    updCmd1.ExecuteNonQuery();
                   // label3.Text = "Koniec";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrac">identyfikator pracownika</param>
        /// <param name="czas">czas wejscia</param>
        /// <param name="rejestrId">identyfikator rejestru z DB lub 0 jeżeli nie ma rekordu </param>

        private  void zapisWejscia(int idPrac, DateTime czas, Int64 rejestrId)
        {
            cmdText1.Clear();
            if (rejestrId == 0)
            {
                cmdText1.Append("INSERT INTO rejestr (pr_Id, czasWe, czasWe1) VALUES ");
                cmdText1.Append("(@prId, @czas, @czas  )");
            }
            else
            {
                cmdText1.Append("UPDATE rejestr set czasWe = @czas, czasWe1 = @czas where idr = ");
                cmdText1.Append(rejestrId);
            }

            try
            {
                using (SqlConnection addConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand addCmd1 = new SqlCommand();
                    addCmd1.Connection = addConnection;
                    addCmd1.CommandText = cmdText1.ToString();
                    addConnection.Open();
                    {
                        addCmd1.Parameters.AddWithValue("@prId", idPrac);
                        addCmd1.Parameters.AddWithValue("@czas", czas);
                    }
                    addCmd1.ExecuteNonQuery();
                   // label3.Text = "Wejście";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

    public class ImportEventArgs : EventArgs
    {
        public ImportEventArgs( importEventStatus eventStatus,  MessageBoxInfo info , int ImpProgress = 100)
        {
            //string message,
            //Message = message;   
            EventStatus = eventStatus;
            this.ImportProgress = ImpProgress;
            this.Info = info;

        }

        //public string Message { get; set; }
       
        public importEventStatus EventStatus { get; set; }
        public int ImportProgress { get; set; }
        public MessageBoxInfo Info {  get; set; }
}

    public struct MessageBoxInfo
    {
        public bool isInfo;
        public string txt1, txt2;

        static public MessageBoxInfo NoMessage()
        {
            return new MessageBoxInfo { isInfo = false, txt1 = null, txt2 = null };
        }
    }
    public enum importEventStatus
    { stop, progres, info }

    public class PracownikGrupa
   {
       public int idPrac;
       //public bool doOdebr; 
       public bool godzNadl;
       public bool pracaSob; 
       public bool pracaNiedz;
       public bool gratyf;
       public short wymiarPracy;
       
       public PracownikGrupa()
       {
           //doOdebr = true;
           godzNadl = true;
           pracaSob = true; pracaNiedz = true;
           gratyf = true;
           wymiarPracy = 480;
       }
   }
   
}
