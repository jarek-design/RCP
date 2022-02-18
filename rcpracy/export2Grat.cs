using System;
using System.Data.SqlClient;
using System.IO;
using Extensions1;

namespace rcpracy
{
    class export2Grat
    {
        // System.Text.StringBuilder rozliczStr;
        SqlCommand rozliczenieCmd2;
        SqlCommand updateRejestrCmd3;
        SqlCommand rozliczenieLastIdCmd;
        SqlCommand rejestrCmd;


        SqlCommand zapisInsertCmd;
        SqlCommand obecnoscCmd;
        SqlCommand godzinaCmd;

        SqlCommand lastIdCmd;
        SqlCommand lastIdCmd2;

        SqlCommand pracownikCmd;
        SqlTransaction gratTrans1;
        SqlTransaction rozliczTrans2;

        StreamWriter Logfile;
        StreamWriter ErrLogfile;
        uint errorsCount = 0;
        static string logFileP = "export2Grat.log";
        const string readRozl = @"SELECT id, idprac, dzien, noc, dzienNad, nocNad, wejscie, czasDo, zgodny, rozTmRej.rozliczId FROM  rozlTmp 
                                  INNER JOIN  rozTmRej ON id = rozTmRej.rozliczId where (rozlTmp.rozlicz = 0) OR (rozlTmp.rozlicz IS NULL) ORDER BY id";

        const string countRozl = "SELECT count([id])  FROM rozlTmp where (rozlTmp.rozlicz = 0) OR (rozlTmp.rozlicz IS NULL)";

        const string updateRejestrStr = " UPDATE rejestr SET rozliczId = @rozId, przetw = 1  WHERE idr in (SELECT rejId FROM rozTmRej WHERE rozTmRej.rozliczId= @rozTmpId) ";
        const string updateRejestrStr2 = " UPDATE rejestr SET rozliczId = @rozId  WHERE idr in (SELECT rejId FROM rozTmRej WHERE rozTmRej.rozliczId= @rozTmpId) ";

        const string rozliczenieIdStr = " SELECT TOP (1) idroz FROM  rozliczenie ORDER BY idroz DESC";
        const string rejestrStr = "SELECT czasWe, czasDo FROM rejestr WHERE idr IN (SELECT rejId FROM rozTmRej WHERE rozliczId= @TmId )";

        const string rozliczStr = @"INSERT INTO rozliczenie 
       ( idprac,  dzien, noc, dzienNad, nocNad, zgodny,wejscie,czasDo )
        VALUES( @Idprac,  @Dzien, @Noc, @DzienNad, @NocNad, @Zgodny, @Wej, @CzasDo )";

         //@"SELECT pr_Id, godzNadl, pracaSob, pracaNiedz, gratyf FROM pracownik left outer join grupa on idGrup = pracownik.grupa
        const string pracownikTxt = "SELECT pr_Id, gratyf from pracownik left outer join grupa on idGrup = pracownik.grupa where pr_Id = @Idprac ";  

        //const string rejestrMark = " UPDATE rejestr SET rozliczId = @rozId WHERE idr in (SELECT rejId FROM rozTmRej WHERE rozTmRej.rozliczId= @rozTmpId) ";
        int idPrac;



        public export2Grat()
        {
            Logfile = new System.IO.StreamWriter(logFileP);
            ErrLogfile = new System.IO.StreamWriter("errorExportRejestr.log");
            Configuration.Instance.ini();
        }

        public bool eksport(System.Windows.Forms.ToolStripProgressBar progrBar1)
        {

            //try
            //{
            Logfile.WriteLine("Start.." + DateTime.Now.ToLongTimeString());
            Logfile.WriteLine("identyf Pracow ; wejscie  ;    WYjście  ;  zapId ; obecnId ; godziny-dzien; noc ; dzien Nadliczbowe ;  nocne Nadliczbowe ");
            

            using (SqlConnection gratConn = new SqlConnection(Funct.GetGratyfConnectionStr()))
            {
                int count = 0;
                rozliczTrans2 = null;

                gratConn.Open();
                zapisInsertCmd = new SqlCommand();
                zapisInsertCmd.Connection = gratConn;

                zapisIni();

                obecnoscCmd = new SqlCommand();
                obecnoscCmd.Connection = gratConn;

                obecnoscIni();

                godzinaCmd = new SqlCommand(null,gratConn);
                GodzinaIni();

                lastIdCmd = new SqlCommand();
                lastIdCmd.Connection = gratConn;
                lastIdCmd2 = new SqlCommand();
                lastIdCmd2.Connection = gratConn;
                

                using (SqlConnection rozliczenieConn = new SqlConnection(Funct.RcpConnectionStr))
                {
                    rozliczenieCmd2 = new SqlCommand(rozliczStr, rozliczenieConn);                    
                    rozliczenieParams();
                    rozliczenieConn.Open();
                    rozliczenieCmd2.Transaction = rozliczTrans2;
                    updateRejestrCmd3 = new SqlCommand(updateRejestrStr, rozliczenieConn);
                    updateRejestrParams();
                    updateRejestrCmd3.Transaction = rozliczTrans2;
                    rejestrCmd = new SqlCommand(rejestrStr, rozliczenieConn);
                    rejestrCmd.Parameters.Add(new SqlParameter("@TmId", System.Data.SqlDbType.Int));
                    rejestrCmd.Transaction = rozliczTrans2;
                    rozliczenieLastIdCmd = new SqlCommand(rozliczenieIdStr, rozliczenieConn);


                    using (SqlConnection pracConnection = new SqlConnection(Funct.RcpConnectionStr))
                    {
                        pracownikCmd = new SqlCommand(pracownikTxt, pracConnection);
                        pracownikParams();
                        pracConnection.Open();
                        bool pracExp2Grat = false;
                        using (SqlConnection rozlTmpConnection = new SqlConnection(Funct.RcpConnectionStr))
                        {                           
                            SqlCommand rozlReadCmd = new SqlCommand(countRozl, rozlTmpConnection);
                            rozlTmpConnection.Open();

                            SqlDataReader rozliczReadDr = rozlReadCmd.ExecuteReader();
                            progrBar1.Value = 0;  // aby był szary jeśli nie ma przetwarzania
                            if (rozliczReadDr.Read() && (count = rozliczReadDr.GetInt32(0)) > 0)
                            {
                                progrBar1.Maximum = count;
                                progrBar1.Visible = true;
                            }
                            else
                                return false;

                            rozliczReadDr.Close();
                            rozlReadCmd.CommandText = readRozl;
                            rozliczReadDr = rozlReadCmd.ExecuteReader();
                            int idTmp = 0;
                           
                            while (rozliczReadDr.Read())
                            {
                                gratTrans1 = null;
                                idPrac = rozliczReadDr.GetInt32(rozliczReadDr.GetOrdinal("idprac"));
                                pracExp2Grat =  pracownikExport2Grat(idPrac) ;
                                
                                if (idTmp != rozliczReadDr.GetInt32(0)) 
                                {

                                    
                                    try
                                    {
                                        rozliczTrans2 = rozliczenieConn.BeginTransaction();
                                        rozliczenieZapis(rozliczReadDr, pracExp2Grat);
                                        //if (!rozliczTmpDr.GetBoolean(rozliczTmpDr.GetOrdinal("zgodny")) && pracExp2Grat)
                                        if (pracExp2Grat)
                                        {
                                            // zapis do bazy danych gratyfikanta
                                            gratTrans1 = gratConn.BeginTransaction();
                                            zapis2Grat(rozliczReadDr);
                                            gratTrans1.Commit();
                                        }
                                        rozliczTrans2.Commit();                                        
                                        idTmp = rozliczReadDr.GetInt32(0);
                                        
                                    }
                                    catch (Exception e)
                                    {
                                      
                                        TransactionError(e);
                                        //rejestrErrorDump(idPrac);
                                        dumpReader(rozliczReadDr);
                                        errorsCount++;
                                        //endLog();
                                        //rozliczenieConn.Close();
                                        //return false;                                       
                                    }
                                }
                            }
                        }                     
                    }
                }
            }
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            if (errorsCount > 0)
            {
                System.Windows.Forms.MessageBox.Show("Błąd przy eksporcie do systemu INSERT\n Zobacz plik: errorExportRejestr.log ",
                            "Błąd exportu ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
                                               
            endLog();
            return true;
        }

        private void TransactionError(Exception e)
        {
            if (gratTrans1 != null)
                gratTrans1.Rollback();

            if (rozliczTrans2 != null)
                rozliczTrans2.Rollback();

            Logfile.WriteLine("Error ");
            ErrLogfile.WriteLine(e.Message);
            ErrLogfile.WriteLine(e.StackTrace);
            


        }

        private void dumpReader(SqlDataReader reader)
        {           
                ErrLogfile.WriteLine("");
               
                    for (int i = 0; i < reader.FieldCount; i++)
                        if (reader.GetValue(i) != DBNull.Value)
                        {
                           ErrLogfile.Write(reader.GetName(i) + ": " +
                            Convert.ToString(reader.GetValue(i)) + " , ");
                        }
                    ErrLogfile.WriteLine("");                                
        }

        private void rejestrErrorDump(int rejestrId)
        {
            string rejestrStr2 = "Select * from rejestr where idr = " + rejestrId.ToString();
            using (SqlConnection rozliczConn = new SqlConnection(Funct.RcpConnectionStr))
            {
                SqlCommand rozliczCmd = new SqlCommand(rejestrStr2, rozliczConn);
                rozliczConn.Open();
                SqlDataReader rozliczDr = rozliczCmd.ExecuteReader();
                dumpReader(rozliczDr);
            }

        }


        void endLog()
        {
            Logfile.WriteLine("Koniec.." + DateTime.Now.ToLongTimeString());
            Logfile.Close();
            ErrLogfile.Close();
        }

        private void rozliczenieParams()
        {
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@Idprac", System.Data.SqlDbType.Int));
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@Dzien", System.Data.SqlDbType.SmallInt));
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@Noc", System.Data.SqlDbType.SmallInt));
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@DzienNad", System.Data.SqlDbType.SmallInt));
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@NocNad", System.Data.SqlDbType.SmallInt));
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@Wej", System.Data.SqlDbType.DateTime));
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@CzasDo", System.Data.SqlDbType.DateTime));
            rozliczenieCmd2.Parameters.Add(new SqlParameter("@Zgodny", System.Data.SqlDbType.Bit));
            //rozliczenieCmd2.Prepare();
        }

        void pracownikParams()
        {
            pracownikCmd.Parameters.Add(new SqlParameter("@Idprac", System.Data.SqlDbType.Int));
        }

        bool pracownikExport2Grat(int idPrac)
        {            
            pracownikCmd.Parameters["@Idprac"].Value = idPrac;
            using (SqlDataReader pracRead = pracownikCmd.ExecuteReader())
            {
                if (pracRead.Read())
                    if (pracRead.IsDBNull(pracRead.GetOrdinal("gratyf")))
                        return true;
                    else
                        return (bool)pracRead.GetBoolean(pracRead.GetOrdinal("gratyf"));
            }
            return false;
        }

        private void updateRejestrParams()
        {
            updateRejestrCmd3.Parameters.Add(new SqlParameter("@rozId", System.Data.SqlDbType.Int));
            updateRejestrCmd3.Parameters.Add(new SqlParameter("@rozTmpId", System.Data.SqlDbType.BigInt));
            //updateRejestrCmd3.Prepare();
        }

        private void rozliczenieZapis(SqlDataReader rozliczDr, bool pracExp2Grat)
        {
            //rozliczenieCmd2.CommandText = rozliczStr.ToString();
            rozliczenieCmd2.Parameters["@Idprac"].Value = rozliczDr["idprac"];
            rozliczenieCmd2.Parameters["@Dzien"].Value = rozliczDr["dzien"];
            rozliczenieCmd2.Parameters["@Noc"].Value = rozliczDr["noc"];
            rozliczenieCmd2.Parameters["@DzienNad"].Value = rozliczDr["dzienNad"];
            rozliczenieCmd2.Parameters["@NocNad"].Value = rozliczDr["nocNad"];
            rozliczenieCmd2.Parameters["@Wej"].Value = rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie"));
            rozliczenieCmd2.Parameters["@CzasDo"].Value = rozliczDr.GetDateTime(rozliczDr.GetOrdinal("czasDo"));
            rozliczenieCmd2.Parameters["@Zgodny"].Value = rozliczDr["zgodny"];

            rozliczenieCmd2.ExecuteNonQuery();
            updateRejestr(rozliczDr.GetInt32(rozliczDr.GetOrdinal("id")), rozliczDr, pracExp2Grat);
        }

        private void updateRejestr(int rozTmpId, SqlDataReader rozliczDr, bool pracExp2Grat)
        {
            int rozId;

            using (SqlDataReader lastIdRoz = rozliczenieLastIdCmd.ExecuteReader())
            {
                lastIdRoz.Read();
                rozId = lastIdRoz.GetInt32(0);
                lastIdRoz.Close();
            }

            if (!pracExp2Grat)
                updateRejestrCmd3.CommandText = updateRejestrStr2;
            updateRejestrCmd3.Transaction = rozliczTrans2;

            updateRejestrCmd3.Parameters["@rozId"].Value = rozId;
            updateRejestrCmd3.Parameters["@rozTmpId"].Value = rozTmpId;
            updateRejestrCmd3.ExecuteNonQuery();
            
            if (!pracExp2Grat)
                updateRejestrCmd3.CommandText = updateRejestrStr;
        }

        private void obecnoscIni()
        {
            System.Text.StringBuilder obecnTxt;
            obecnTxt = new System.Text.StringBuilder("INSERT INTO ecp_Obecnosc ", 280);
            obecnTxt.Append("( ecpo_Id ,ecpo_IdZapis , ecpo_ZwykleDzienne , ecpo_ZwykleNocne , ecpo_NadlPlatne , ecpo_NadlPlatneNocne , ");
            obecnTxt.Append(" ecpo_NadlRozlicz , ecpo_AbsPotrac , ecpo_AbsRozlicz , ecpo_AbsRozlBezWnPrac ) ");
            obecnTxt.Append("VALUES (@obId, @zapId,@Dzien, @Noc, @DzienNad, @NocNad, ");
            obecnTxt.Append(" 0,0,0,0 )");

            obecnoscCmd.CommandText = obecnTxt.ToString();
            obecnoscCmd.Parameters.Add(new SqlParameter("@zapId", System.Data.SqlDbType.Int));
            obecnoscCmd.Parameters.Add(new SqlParameter("@obId", System.Data.SqlDbType.Int));
            obecnoscCmd.Parameters.Add(new SqlParameter("@Dzien", System.Data.SqlDbType.SmallInt));
            obecnoscCmd.Parameters.Add(new SqlParameter("@Noc", System.Data.SqlDbType.SmallInt));
            obecnoscCmd.Parameters.Add(new SqlParameter("@DzienNad", System.Data.SqlDbType.SmallInt));
            obecnoscCmd.Parameters.Add(new SqlParameter("@NocNad", System.Data.SqlDbType.SmallInt));            
        }


        private void zapisIni()
        {
            System.Text.StringBuilder zapisTxt;
            zapisTxt = new System.Text.StringBuilder("INSERT INTO ecp__Zapis ", 200);
            
            zapisTxt.Append(" (ecp_Id, ecp_IdPrac ,ecp_Data, ecp_DataDo, ecp_RodzajZapisu, ecp_PrzedKorekta, ecp_Korekta, ecp_KorektaRozliczWyplata)");
            zapisTxt.Append(" VALUES( @zapId, @idPrac, @Wej, @czasDo, @Rodzaj, ' ', 0, 0 )");

            zapisInsertCmd.CommandText = zapisTxt.ToString();

            zapisInsertCmd.Parameters.Add(new SqlParameter("@zapId", System.Data.SqlDbType.Int));
            zapisInsertCmd.Parameters.Add(new SqlParameter("@idPrac", System.Data.SqlDbType.Int));
            zapisInsertCmd.Parameters.Add(new SqlParameter("@Wej", System.Data.SqlDbType.DateTime));
            zapisInsertCmd.Parameters.Add(new SqlParameter("@czasDo", System.Data.SqlDbType.DateTime));
            zapisInsertCmd.Parameters.Add(new SqlParameter("@Rodzaj", System.Data.SqlDbType.Int));           
        }


        private void GodzinaIni()
        {
            godzinaCmd.CommandText = "INSERT INTO ecp_Godzina (ecpg_Id ,ecpg_IdZapis ,ecpg_Od ,ecpg_Do, ecpg_PoraDnia) VALUES( @godzId, @zapId,@Wej, @czasDo, @pora)";

            godzinaCmd.Parameters.Add(new SqlParameter("@godzId", System.Data.SqlDbType.Int));
            godzinaCmd.Parameters.Add(new SqlParameter("@zapId", System.Data.SqlDbType.Int));
            godzinaCmd.Parameters.Add(new SqlParameter("@Wej", System.Data.SqlDbType.Int));
            godzinaCmd.Parameters.Add(new SqlParameter("@czasDo", System.Data.SqlDbType.Int));
            godzinaCmd.Parameters.Add(new SqlParameter("@pora", System.Data.SqlDbType.Int));                       
        }

        private void zapis2Grat(SqlDataReader rozliczDr)
        {
            int zapisId, obecnId , godzId;
            DateTime dataPocz, wej, czasDo;
            zapisInsertCmd.Transaction = gratTrans1;
            obecnoscCmd.Transaction = gratTrans1;
            godzinaCmd.Transaction = gratTrans1;

            obecnId = GetLastId("ecp_Obecnosc", "ecpo_Id");
            UpdateIns_Ident("ecp_Obecnosc", obecnId + 1);
                       
            godzId = GetLastId("ecp_Godzina", "ecpg_Id");

            #region logFile
            Logfile.Write(rozliczDr.GetInt32(rozliczDr.GetOrdinal("idprac")).ToString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie")).ToShortDateString() + " : " + rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie")).ToShortTimeString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr.GetDateTime(rozliczDr.GetOrdinal("czasDo")).ToShortDateString() + " : " + rozliczDr.GetDateTime(rozliczDr.GetOrdinal("czasDo")).ToShortTimeString());
            Logfile.Write("; ");
            Logfile.Write(obecnId.ToString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr["dzien"].ToString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr["noc"].ToString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr["dzienNad"].ToString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr["nocNad"].ToString());
            Logfile.WriteLine(" ; ");

            #endregion

            rejestrCmd.Parameters["@TmId"].Value = rozliczDr["rozliczId"];
            SqlDataReader rejestrDr = rejestrCmd.ExecuteReader();
            
            zapisId = ZapisInsert(rozliczDr, 8);
            ZapisInsert(rozliczDr,4);
            dataPocz = rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie")).datePart();
            TimeSpan ts;
            int minuty;
            while (rejestrDr.Read())
            {                                
                wej = rejestrDr.GetDateTime(rejestrDr.GetOrdinal("czasWe"));
                czasDo = rejestrDr.GetDateTime(rejestrDr.GetOrdinal("czasDo"));
                ts = wej - dataPocz;
                minuty = (int)ts.TotalMinutes;
                godzinaCmd.Parameters["@godzId"].Value = godzId++;
                godzinaCmd.Parameters["@zapId"].Value = zapisId;
                godzinaCmd.Parameters["@Wej"].Value = (int) (wej - dataPocz).TotalMinutes;
                godzinaCmd.Parameters["@czasDo"].Value = (int)(czasDo - dataPocz).TotalMinutes;
                godzinaCmd.Parameters["@pora"].Value = 0;
                godzinaCmd.ExecuteNonQuery();
            }
            UpdateIns_Ident("ecp__Zapis", zapisId+1);
            UpdateIns_Ident("ecp_Godzina", godzId);
                      
            obecnoscCmd.Parameters["@zapId"].Value = zapisId+1;
            obecnoscCmd.Parameters["@obId"].Value = obecnId;
            obecnoscCmd.Parameters["@Dzien"].Value = rozliczDr["dzien"];
            obecnoscCmd.Parameters["@Noc"].Value = rozliczDr["noc"];
            obecnoscCmd.Parameters["@DzienNad"].Value = rozliczDr["dzienNad"];
            obecnoscCmd.Parameters["@NocNad"].Value = rozliczDr["nocNad"];
            obecnoscCmd.ExecuteNonQuery();
            
            lastIdCmd.Parameters.Clear();
            
        }

        private int ZapisInsert(SqlDataReader rozliczDr, int rodzaj)
        {
            DateTime wej, czasDo;
            int zapisId = GetLastId("ecp__Zapis", "ecp_Id");
            wej = rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie"));
            czasDo = rozliczDr.GetDateTime(rozliczDr.GetOrdinal("czasDo"));
            zapisInsertCmd.Parameters["@zapId"].Value = zapisId;
            zapisInsertCmd.Parameters["@idPrac"].Value = rozliczDr.GetInt32(rozliczDr.GetOrdinal("idprac"));
            zapisInsertCmd.Parameters["@Wej"].Value = wej.datePart();
            zapisInsertCmd.Parameters["@czasDo"].Value = czasDo.datePart();
            zapisInsertCmd.Parameters["@Rodzaj"].Value = rodzaj;
            zapisInsertCmd.ExecuteNonQuery();
            return zapisId;
        }
       


        private int GetLastId(string TableName, string nazwaPolaId)
        {
            int Id = -1;                      
                      
            System.Text.StringBuilder cmdTxt;    // nie da się do tego użyć  sql parametrs
            cmdTxt = new System.Text.StringBuilder("SELECT TOP 1 ");
            cmdTxt.Append(nazwaPolaId);
            cmdTxt.Append(" FROM ");
            cmdTxt.Append(TableName);
            cmdTxt.Append(" ORDER BY ");
            cmdTxt.Append(nazwaPolaId);
            cmdTxt.Append(" DESC ");
            lastIdCmd2.CommandText = cmdTxt.ToString();
            lastIdCmd2.Transaction = gratTrans1; 

            // znalezienie największego identyfikatora w tablicy TableName
            using (SqlDataReader dr = lastIdCmd2.ExecuteReader())
            {
                if (dr.Read())
                    Id = dr.GetInt32(0);
            }            
            // sprawdzenie tej wartości w tablicy ins_ident
            lastIdCmd.Transaction = gratTrans1;
            lastIdCmd.Parameters.AddWithValue("@nazwaTabeli",TableName);
            lastIdCmd.CommandText = "SELECT ido_wartosc FROM ins_ident where ido_nazwa = @nazwaTabeli";
            
            using (SqlDataReader dr1 = lastIdCmd.ExecuteReader())
            {
                if (dr1.Read())
                    Id = Math.Max(Id + 1, dr1.GetInt32(0));
            }
            lastIdCmd.Parameters.Clear();
            return Id;
        }

        private void UpdateIns_Ident(string TableName, int Id)
        {
            lastIdCmd.Transaction = gratTrans1;
   
            lastIdCmd.Parameters.AddWithValue("@nazwaTabeli", TableName);
            lastIdCmd.Parameters.AddWithValue("@id", Id);
            lastIdCmd.CommandText = "UPDATE ins_ident set ido_wartosc = @id WHERE ido_nazwa = @nazwaTabeli";
            
            lastIdCmd.ExecuteNonQuery();
            lastIdCmd.Parameters.Clear();
        }

    }




}
