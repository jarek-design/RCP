using Extensions1;
using System;
using System.Data.SqlClient;
using System.IO;

namespace rcpracy
{
    class export2Grat
    {
        // System.Text.StringBuilder rozliczStr;
        SqlCommand rozliczenieCmd2;
        SqlCommand updateRejestrCmd3;
        SqlCommand rozliczenieLastIdCmd;

        SqlCommand zapisInsertCmd;
        SqlCommand obecnoscCmd;
        SqlCommand lastIdCmd;

        SqlCommand pracownikCmd;
        SqlTransaction gratTrans1;
        SqlTransaction rozliczTrans2;
        StreamWriter Logfile;
        StreamWriter ErrLogfile;
        uint errorsCount = 0;
        static string logFileP = "export2Grat.log";
        const string readRozl = @"SELECT id, idprac, dzien, noc, dzienNad, nocNad, wejscie, czasDo, zgodny, rozTmRej.rejId FROM  rozlTmp 
                                  INNER JOIN  rozTmRej ON id = rozTmRej.rozliczId where (rozlTmp.rozlicz = 0) OR (rozlTmp.rozlicz IS NULL) ORDER BY id";

        const string countRozl = "SELECT count([id])  FROM rozlTmp where (rozlTmp.rozlicz = 0) OR (rozlTmp.rozlicz IS NULL)";

        const string updateRejestrStr = " UPDATE rejestr SET rozliczId = @rozId, przetw = 1  WHERE idr in (SELECT rejId FROM rozTmRej WHERE rozTmRej.rozliczId= @rozTmpId) ";
        const string updateRejestrStr2 = " UPDATE rejestr SET rozliczId = @rozId  WHERE idr in (SELECT rejId FROM rozTmRej WHERE rozTmRej.rozliczId= @rozTmpId) ";

        const string rozliczenieIdStr = " SELECT TOP (1) idroz FROM  rozliczenie ORDER BY idroz DESC";

        const string rozliczStr = @"INSERT INTO rozliczenie 
       ( idprac,  dzien, noc, dzienNad, nocNad, zgodny,wejscie,czasDo )
        VALUES( @Idprac,  @Dzien, @Noc, @DzienNad, @NocNad, @Zgodny, @Wej, @CzasDo )";

         //@"SELECT pr_Id, godzNadl, pracaSob, pracaNiedz, gratyf FROM pracownik left outer join grupa on idGrup = pracownik.grupa
        const string pracownikTxt = "SELECT pr_Id, gratyf from pracownik left outer join grupa on idGrup = pracownik.grupa where pr_Id = @Idprac ";  

        const string rejestrMark = " UPDATE rejestr SET rozliczId = @rozId WHERE idr in (SELECT rejId FROM rozTmRej WHERE rozTmRej.rozliczId= @rozTmpId) ";
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

            if (!Funct.GratyfConnStrTest())
                return false;

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

                lastIdCmd = new SqlCommand();
                lastIdCmd.Connection = gratConn;

                using (SqlConnection rozliczenieConn = new SqlConnection(Funct.RcpConnectionStr))
                {
                    rozliczenieCmd2 = new SqlCommand(rozliczStr, rozliczenieConn);
                    rozliczenieParams();
                    rozliczenieConn.Open();
                    updateRejestrCmd3 = new SqlCommand(updateRejestrStr, rozliczenieConn);
                    updateRejestrParams();

                    rozliczenieLastIdCmd = new SqlCommand(rozliczenieIdStr, rozliczenieConn);


                    using (SqlConnection pracConnection = new SqlConnection(Funct.RcpConnectionStr))
                    {
                        pracownikCmd = new SqlCommand(pracownikTxt, pracConnection);
                        pracownikParams();
                        pracConnection.Open();
                        bool pracExp2Grat = false;
                        using (SqlConnection rozlTmpConnection = new SqlConnection(Funct.RcpConnectionStr))
                        {                           
                            SqlCommand rozlTmpCmd = new SqlCommand(countRozl, rozlTmpConnection);
                            rozlTmpConnection.Open();

                            SqlDataReader rozliczTmpDr = rozlTmpCmd.ExecuteReader();
                            progrBar1.Value = 0;  // aby był szary jeśli nie ma przetwarzania
                            if (rozliczTmpDr.Read() && (count = rozliczTmpDr.GetInt32(0)) > 0)
                            {
                                progrBar1.Maximum = count;
                                progrBar1.Visible = true;
                            }
                            else
                                return false;

                            rozliczTmpDr.Close();
                            rozlTmpCmd.CommandText = readRozl;
                            rozliczTmpDr = rozlTmpCmd.ExecuteReader();
                            int idTmp = 0;
                           
                            while (rozliczTmpDr.Read())
                            {
                                gratTrans1 = null;
                                idPrac = rozliczTmpDr.GetInt32(rozliczTmpDr.GetOrdinal("idprac"));
                                pracExp2Grat =  pracownikExport2Grat(idPrac) ;
                                
                                if (idTmp != rozliczTmpDr.GetInt32(0)) 
                                {

                                    
                                    try
                                    {
                                        rozliczTrans2 = rozliczenieConn.BeginTransaction();
                                        rozliczenieZapis(rozliczTmpDr, pracExp2Grat);
                                        //if (!rozliczTmpDr.GetBoolean(rozliczTmpDr.GetOrdinal("zgodny")) && pracExp2Grat)
                                        if (pracExp2Grat)
                                        {
                                            // zapis do bazy danych gratyfikanta
                                            gratTrans1 = gratConn.BeginTransaction();
                                            zapis2Grat(rozliczTmpDr);
                                            gratTrans1.Commit();
                                        }
                                        rozliczTrans2.Commit();                                        
                                        idTmp = rozliczTmpDr.GetInt32(0);
                                        
                                    }
                                    catch (Exception e)
                                    {
                                        TransactionError(e);
                                        //rejestrErrorDump(idPrac);
                                        dumpReader(rozliczTmpDr);
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
            if(errorsCount >0)
                System.Windows.Forms.MessageBox.Show("Błąd przy eksporcie do systemu INSERT\n Zobacz plik: errorExportRejestr.log ",
                            "Błąd exportu ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                               
                
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
            string rejestrStr = "Select * from rejestr where idr = " + rejestrId.ToString();
            using (SqlConnection rozliczConn = new SqlConnection(Funct.RcpConnectionStr))
            {
                SqlCommand rozliczCmd = new SqlCommand(rejestrStr, rozliczConn);
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
            
            updateRejestrCmd3.Parameters["@rozId"].Value = rozId;
            updateRejestrCmd3.Parameters["@rozTmpId"].Value = rozTmpId;
            updateRejestrCmd3.ExecuteNonQuery();
            
            if (!pracExp2Grat)
                updateRejestrCmd3.CommandText = updateRejestrStr;
        }

        private void zapisIni()
        {
            System.Text.StringBuilder zapisTxt;
            zapisTxt = new System.Text.StringBuilder("INSERT INTO ecp__Zapis ", 200);
            
            zapisTxt.Append(" (ecp_Id, ecp_IdPrac ,ecp_Data, ecp_DataDo, ecp_RodzajZapisu, ecp_PrzedKorekta, ecp_Korekta, ecp_KorektaRozliczWyplata)");
            zapisTxt.Append(" VALUES( @zapId, @idPrac, @Wej, @czasDo, 4, ' ', 0, 0 )");

            zapisInsertCmd.CommandText = zapisTxt.ToString();

            zapisInsertCmd.Parameters.Add(new SqlParameter("@zapId", System.Data.SqlDbType.Int));
            zapisInsertCmd.Parameters.Add(new SqlParameter("@idPrac", System.Data.SqlDbType.Int));
            zapisInsertCmd.Parameters.Add(new SqlParameter("@Wej", System.Data.SqlDbType.DateTime));
            zapisInsertCmd.Parameters.Add(new SqlParameter("@czasDo", System.Data.SqlDbType.DateTime));
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


        private void zapis2Grat(SqlDataReader rozliczDr)
        {
            int zapisId = 0;
            int obecnId = 0;
            DateTime wej, czasDo;
            //try
            //{         

            lastIdCmd.CommandText = "SELECT TOP 1 ecp_Id FROM ecp__Zapis ORDER BY ecp_Id DESC";
            lastIdCmd.Transaction = gratTrans1;
            using (SqlDataReader dr = lastIdCmd.ExecuteReader())
            {
                if (dr.Read())
                    zapisId = dr.GetInt32(0);
            }


            lastIdCmd.CommandText = "SELECT TOP 1 ecpo_Id FROM ecp_Obecnosc ORDER BY ecpo_Id DESC";

            using (SqlDataReader dr1 = lastIdCmd.ExecuteReader())
            {
                if (dr1.Read())
                    obecnId = dr1.GetInt32(0);
            }

            lastIdCmd.CommandText = "SELECT ido_wartosc FROM ins_ident where ido_nazwa = @nazwaTabeli";
            lastIdCmd.Parameters.Add(new SqlParameter("@nazwaTabeli", System.Data.SqlDbType.VarChar));

            lastIdCmd.Parameters["@nazwaTabeli"].Value = "ecp__Zapis";
            using (SqlDataReader dr1 = lastIdCmd.ExecuteReader())
            {
                if (dr1.Read())
                    zapisId = Math.Max(zapisId + 1, dr1.GetInt32(0));
            }

            lastIdCmd.Parameters["@nazwaTabeli"].Value = "ecp_Obecnosc";
            using (SqlDataReader dr1 = lastIdCmd.ExecuteReader())
            {
                if (dr1.Read())
                    obecnId = Math.Max(obecnId + 1, dr1.GetInt32(0));
            }
            lastIdCmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
            lastIdCmd.CommandText = "UPDATE ins_ident set ido_wartosc = @id WHERE ido_nazwa = @nazwaTabeli";
            lastIdCmd.Parameters["@id"].Value = obecnId + 1;
            lastIdCmd.ExecuteNonQuery();

            lastIdCmd.Parameters["@nazwaTabeli"].Value = "ecp__Zapis";
            lastIdCmd.Parameters["@id"].Value = zapisId + 1;
            lastIdCmd.ExecuteNonQuery();

            lastIdCmd.Parameters.Clear();

            zapisInsertCmd.Transaction = gratTrans1;
            obecnoscCmd.Transaction = gratTrans1;

            #region logFile
            Logfile.Write(rozliczDr.GetInt32(rozliczDr.GetOrdinal("idprac")).ToString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie")).ToShortDateString() + " : " + rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie")).ToShortTimeString());
            Logfile.Write("; ");
            Logfile.Write(rozliczDr.GetDateTime(rozliczDr.GetOrdinal("czasDo")).ToShortDateString() + " : " + rozliczDr.GetDateTime(rozliczDr.GetOrdinal("czasDo")).ToShortTimeString());
            Logfile.Write("; ");
            Logfile.Write(zapisId.ToString());
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

            zapisInsertCmd.Parameters["@zapId"].Value = zapisId;
            zapisInsertCmd.Parameters["@idPrac"].Value = rozliczDr.GetInt32(rozliczDr.GetOrdinal("idprac"));
            
            wej = rozliczDr.GetDateTime(rozliczDr.GetOrdinal("wejscie"));
            czasDo = rozliczDr.GetDateTime(rozliczDr.GetOrdinal("czasDo"));

            //if (Configuration.confData.exp2GratDateOnly)
            //{
            //    wej = wej.datePart();
            //    czasDo = czasDo.datePart();
            //}

            zapisInsertCmd.Parameters["@Wej"].Value = wej;
            zapisInsertCmd.Parameters["@czasDo"].Value = czasDo;
            
            
            obecnoscCmd.Parameters["@zapId"].Value = zapisId;
            obecnoscCmd.Parameters["@obId"].Value = obecnId;
            obecnoscCmd.Parameters["@Dzien"].Value = rozliczDr["dzien"];
            obecnoscCmd.Parameters["@Noc"].Value = rozliczDr["noc"];
            obecnoscCmd.Parameters["@DzienNad"].Value = rozliczDr["dzienNad"];
            obecnoscCmd.Parameters["@NocNad"].Value = rozliczDr["nocNad"];

            zapisInsertCmd.ExecuteNonQuery();

            obecnoscCmd.ExecuteNonQuery();

            //catch (Exception)
            //{                
            //    throw;
            //}
        }
    }




}
