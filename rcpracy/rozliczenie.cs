using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace rcpracy
{
    using Extensions1;
    static class Rozliczenie
    {
        static int przerwaWpracy;
        static string cmdText1, cmdCountText1;
        static List<SQLparam> par1 = null;

        static void zeruj()
        {
            string cmdText1 = "DELETE FROM rozlTmp";

            try
            {
                using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand rcpCmd1 = new SqlCommand(cmdText1, rcpConnection);
                    rcpCmd1.Connection = rcpConnection;
                    rcpCmd1.CommandText = cmdText1;
                    rcpConnection.Open();

                    rcpCmd1.ExecuteNonQuery();
                    rcpCmd1.CommandText = "DBCC CHECKIDENT ('rozlTmp', RESEED, 1) ";   // "ALTER TABLE [rozlTmp] ALTER COLUMN [Id] IDENTITY (1,1)";
                    rcpCmd1.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        
        public static bool rozlicz(System.Windows.Forms.ToolStripProgressBar progrBar1, System.Windows.Forms.Timer timer1)
        {            
            par1 = null;
            return rozlicz1(progrBar1, timer1, " WHERE (rozliczId IS NULL)");  //zmiana: przetw = 0 OR przetw IS NULL
        }

        public static bool rozlicz(System.Windows.Forms.ToolStripProgressBar progrBar1, System.Windows.Forms.Timer timer1, List<SQLparam> par12)
        {
            
            par1 = par12;
            int prId = Convert.ToInt32(par1.Find(x => x.name == "Pr_Id").val);
            if( prId > 0)
                return rozlicz1(progrBar1, timer1,  "WHERE (pr_Id = @Pr_Id and czasWe BETWEEN @D1 AND @D2 )" );    
            else
                return rozlicz1(progrBar1, timer1, "WHERE (czasWe BETWEEN @D1 AND @D2 )");
        }


        private static void setParams(SqlCommand rcpCmd1)
        {
            rcpCmd1.Parameters.AddWithValue("@Pr_Id",par1.Find(x => x.name == "Pr_Id").val) ;
            rcpCmd1.Parameters.AddWithValue("@D1", par1.Find(x => x.name == "D1").val) ;
            rcpCmd1.Parameters.AddWithValue("@D2", par1.Find(x => x.name == "D2").val) ;           
        }

        public static bool rozlicz1(System.Windows.Forms.ToolStripProgressBar progrBar1, System.Windows.Forms.Timer timer1, string war1)
        {
            Configuration.Instance.ini();
            przerwaWpracy = Configuration.confData.przerwaWpracy;

            bool pierwszeWe = true;
            DateTime ostatniPobyt = DateTime.MinValue;
            int idPrac = 0;
            Praca dzienPracy = null;
            cmdText1 = "SELECT idr, pr_Id, czasWe, czasDo, rozliczId FROM rejestr " + war1 + " ORDER BY pr_Id, czasWe  ";
            cmdCountText1 = "SELECT count([idr]) FROM rejestr " + war1;
                                 
            zeruj();

            //try
            //{
            using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
            {
                SqlCommand rcpCmd1 = new SqlCommand();
                rcpCmd1.Connection = rcpConnection;
                if (par1 != null)
                    setParams(rcpCmd1);

                rcpCmd1.CommandText = cmdCountText1;
               
                rcpConnection.Open();
                SqlDataReader rejestr = rcpCmd1.ExecuteReader();
                if (rejestr.HasRows)
                {
                    rejestr.Read();
                    int count = rejestr.GetInt32(0);
                    progrBar1.Value = 0;                   
                    progrBar1.Maximum = count;
                    progrBar1.Visible = true;
                }
                else
                    return false;

                rejestr.Close();    
                rcpCmd1.CommandText = cmdText1.ToString();
                rejestr = rcpCmd1.ExecuteReader();
           
                while (rejestr.Read())
                {
                    if (progrBar1.Value < progrBar1.Maximum)
                        progrBar1.Value++;
                    if (rejestr["czasWe"] != DBNull.Value && rejestr["czasDo"] != DBNull.Value)
                    {
                        if (pierwszeWe)
                            nowyDzien(rejestr, out ostatniPobyt, out idPrac, out dzienPracy, pierwszeWe);
                        else
                        if (idPrac == rejestr.GetInt32(1) && (rejestr.GetDateTime(rejestr.GetOrdinal("czasWe")) - ostatniPobyt).TotalHours < przerwaWpracy)
                        {
                            double h = (rejestr.GetDateTime(rejestr.GetOrdinal("czasWe")) - ostatniPobyt).TotalHours;
                            DateTime t = rejestr.GetDateTime(rejestr.GetOrdinal("czasWe"));

                            ostatniPobyt = rejestr.GetDateTime(rejestr.GetOrdinal("czasDo"));
                            dzienPracy.elementPracy(rejestr.GetDateTime(rejestr.GetOrdinal("czasWe")), rejestr.GetDateTime(rejestr.GetOrdinal("czasDo")), rejestr.GetInt64(0));

                        }
                        else
                        {
                            if (dzienPracy !=null)
                            dzienPracy.rozliczPrace();
                            nowyDzien(rejestr, out ostatniPobyt, out idPrac, out dzienPracy, pierwszeWe);
                        }

                        pierwszeWe = false;
                    }
                }
                if (dzienPracy != null)
                dzienPracy.rozliczPrace();
           
            }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            timer1.Enabled = true;
            return true;
        }

        private static void nowyDzien(SqlDataReader rejestr, out DateTime ostatniPobyt, out int idPrac, out Praca dzienPracy, bool pierwszeWe)
        {
            idPrac = rejestr.GetInt32(1);
            DateTime czasWe = rejestr.GetDateTime(rejestr.GetOrdinal("czasWe"));                       
            dzienPracy = new Praca(idPrac,czasWe);
            dzienPracy.elementPracy(czasWe, rejestr.GetDateTime(rejestr.GetOrdinal("czasDo")), rejestr.GetInt64(0));
            ostatniPobyt = rejestr.GetDateTime(rejestr.GetOrdinal("czasDo"));
            dzienPracy.rozliczony = !rejestr.IsDBNull(rejestr.GetOrdinal("rozliczId"));
            
        }

    }

    //class Przerwa
    //{
    //    DateTime lastEndWorkTime;
    //    DateTime newStartWorkTime;        
    //    double przerwaMinut;
    //}
  
    class Praca
    {
        static int nocStart;
        static int nocEnd;
        static int toler;

        //Int64 rejId;
        int idPrac;
        int total;
        int dzienna;
        int nocna;
        int dziennaNadliczb;
        int nocnaNadliczb;
        bool zgodny ;
        public bool rozliczony;
        DateTime startWorkTime;
        DateTime endWorkTime;

       
        int normaDzienna;
        int normaDziennaPrac;

        //int normaNocnaGrat;

        bool pierwszeWej;

        List<Obecnosc> w_pracy;

        public Praca(int idPrac, DateTime start )
        {
           
             nocStart = Configuration.confData.nocStart;
             nocEnd = Configuration.confData.nocEnd;
             toler = Configuration.confData.toler;
             normaDzienna = 60* Configuration.confData.normaDzienna; // przeliczenie na minuty         
             
            w_pracy = new List<Obecnosc>();
            //zerowanie();
            this.idPrac = idPrac;
            this.startWorkTime = start;
            this.endWorkTime = start;
            pierwszeWej = true;
        }


        void zerowanie ()
        {
             idPrac = 0 ;
             total = 0 ;
             dzienna = 0 ;
             nocna = 0 ;
             dziennaNadliczb = 0 ;
             nocnaNadliczb = 0 ;
             zgodny = false;
             w_pracy.Clear();
        }


        public void elementPracy (DateTime wejDoPracy,   DateTime koniecPracy, Int64 rejId2)
        {
            w_pracy.Add(new Obecnosc { wejDat = wejDoPracy.dateHourMin(), koniecDate = koniecPracy.dateHourMin(), rejId = rejId2 });
            endWorkTime = koniecPracy;
        }

       public void rozliczPrace ()
       {
           if (w_pracy.Capacity > 0)
           {
               //zgodnosc(w_pracy[0].wejDat);
               normaDziennaPrac = wymiarZatrudnienia();
               if (normaDziennaPrac > 0 )
                   normaDzienna = normaDziennaPrac;
              
               // if (normaNocnaGrat > 0 && !Configuration.confData.ignorujNormyGratyf)
              //     normaDzienna = normaNocnaGrat;
               

               foreach (Obecnosc elPracy in w_pracy)
               {
                   //warunek że start nie może zaczynać się od godzin nocnych (czyli wszelkie wejścia w nocy redukują się do godz. pocz. 1 zmiany
                   if (pierwszeWej && Configuration.confData.limPoczPracy)
                   {
                       pierwszeWej = false;
                        if (elPracy.wejDat.Hour < 6)                          // Steinborn
                            elPracy.wejDat = elPracy.wejDat.TimeSplit(6, 0);
                    }
                       
                   total += Convert.ToInt32((elPracy.koniecDate - elPracy.wejDat).TotalMinutes);
                   
                   if ((elPracy.koniecDate.Hour >= nocStart || elPracy.koniecDate.Hour <= nocEnd) && elPracy.wejDat.Hour < nocStart)
                       nocna += (int)((elPracy.koniecDate - Extens.timeSplit(elPracy.wejDat, nocStart, 0)).TotalMinutes);
                   else
                       if (elPracy.koniecDate.Hour >= nocStart || elPracy.koniecDate.Hour <= nocEnd && elPracy.wejDat.Hour >= nocStart)
                           nocna += (int)((elPracy.koniecDate - elPracy.wejDat).TotalMinutes);
                       else
                           if (elPracy.koniecDate.Hour > nocEnd && elPracy.wejDat.Hour >= nocStart)
                               nocna += (int)((elPracy.koniecDate - elPracy.wejDat).TotalMinutes);
                           else
                               if (elPracy.koniecDate.Hour > nocEnd && elPracy.wejDat.Hour < nocStart && elPracy.wejDat.Date < elPracy.koniecDate.Date)
                                   nocna += normaDzienna;
                               else
                                   if (elPracy.wejDat.Hour >= nocStart || elPracy.wejDat.Hour <= nocEnd)
                                       nocna += (int)Math.Min((elPracy.koniecDate - elPracy.wejDat).TotalMinutes, (Extens.timeSplit(elPracy.koniecDate, nocEnd, 0) - elPracy.wejDat).TotalMinutes);                   
               }  //end foreach

               if (nocna < toler)
                   nocna = 0;

               dzienna = total - nocna;

               if (dzienna < toler && total > toler)
               {
                   nocna = total;
                   dzienna = 0;
               }

           }
            if (total > 0)
           {
               if ((dzienna > normaDzienna && dzienna < normaDzienna + toler) || (nocna > normaDzienna && nocna < normaDzienna + toler))
                   zgodny = true;
                  
               if (total > normaDzienna + toler)    // są godz nadliczb      // poprawka - wstawiony =      
                   if (endWorkTime.Hour > nocEnd && endWorkTime.Hour <= nocStart) // koniec pracy w dzień                    
                   {
                       zgodny = false;
                       int nadliczb = total - normaDzienna;
                       dziennaNadliczb =Math.Min(nadliczb,dzienna)  ;
                       if ( dzienna > dziennaNadliczb ) 
                            dzienna -= dziennaNadliczb;
                       else
                       {                                                        
                           dziennaNadliczb = Math.Min(dziennaNadliczb, (int) (endWorkTime - Extens.timeSplit(endWorkTime, nocEnd, 0)).TotalMinutes );
                           nocnaNadliczb = nadliczb - dziennaNadliczb;
                           dzienna -= dziennaNadliczb;
                           nocna -= nocnaNadliczb;
                       }                      
                    }
                    else // koniec pracy w nocy
                    {
                       zgodny = false;
                       int nadliczb = total - normaDzienna;
                       nocnaNadliczb = Math.Min(nadliczb, nocna);
                                            
                       if (nocna > normaDzienna)              //=                                   
                         nocna -= nocnaNadliczb;
                       else
                       {
                           nocnaNadliczb = Math.Min(nocnaNadliczb, (int)(endWorkTime - Extens.timeSplit(startWorkTime, nocStart, 0)).TotalMinutes);
                           dziennaNadliczb = nadliczb - nocnaNadliczb;
                           dzienna -= dziennaNadliczb;
                           nocna -= nocnaNadliczb;
                       } 
                    }

               if ((dzienna >= normaDzienna && dzienna < normaDzienna + toler) && nocnaNadliczb + nocna + dziennaNadliczb < toler
                   || (nocna >= normaDzienna && nocna < normaDzienna + toler) && dziennaNadliczb + dzienna + nocnaNadliczb < toler)
               {
                   zgodny = true;
                   if (dzienna >= normaDzienna)
                       dzienna = normaDzienna;
                   else
                       if (nocna >= normaDzienna)
                           dzienna = normaDzienna;
               }

               dziennaNadliczb = zaokrDoGodzin(dziennaNadliczb);
               nocnaNadliczb = zaokrDoGodzin(nocnaNadliczb);
                

               zapisz();
           }
       }


       int zaokrDoGodzin(int minPracy)
       {
           if (Configuration.confData.zaokrNadliczb && minPracy % 60 < toler )
               minPracy -= minPracy % 60;
           return minPracy;
       }

        int wymiarZatrudnienia()
       {
           using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
           {
               SqlCommand rcpCmd1 = new SqlCommand();
               rcpCmd1.Connection = rcpConnection;
               rcpConnection.Open();
               rcpCmd1.CommandText = "SELECT wymiarPracy FROM pracownik where pr_id = " + idPrac;
               SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();
               if (rcpPrac.HasRows && rcpPrac.Read() && rcpPrac["wymiarPracy"] != DBNull.Value)
               {
                   return (Int32)rcpPrac.GetInt16(0);
               }
               return 0;
           }
       }


       

       public void zapisz()
       {
           System.Text.StringBuilder cmdText = new System.Text.StringBuilder("INSERT INTO rozlTmp ", 165);
           cmdText.Append("(idprac,  dzien, noc, dzienNad, nocNad, zgodny, wejscie, czasDo, rozlicz) ");
           cmdText.Append(" VALUES( @Idprac,  @Dzien, @Noc, @DzienNad, @NocNad, @Zgodny, @wej, @CzasDo, @Rozlicz) ");
           using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
           {
               SqlCommand rcpCmd2 = new SqlCommand();
               rcpCmd2.Connection = rcpConnection;
               rcpCmd2.CommandText = cmdText.ToString();
               rcpConnection.Open();
               rcpCmd2.Parameters.AddWithValue("@Idprac", idPrac);
               rcpCmd2.Parameters.AddWithValue("@Dzien", (short) dzienna);
               rcpCmd2.Parameters.AddWithValue("@Noc", (short) nocna);
               rcpCmd2.Parameters.AddWithValue("@DzienNad", (short)dziennaNadliczb);
               rcpCmd2.Parameters.AddWithValue("@NocNad", (short)nocnaNadliczb);
               rcpCmd2.Parameters.AddWithValue("@Zgodny", zgodny);
               rcpCmd2.Parameters.AddWithValue("@wej", startWorkTime);
               rcpCmd2.Parameters.AddWithValue("@CzasDo", endWorkTime);               
               rcpCmd2.Parameters.AddWithValue("@Rozlicz", rozliczony);
               rcpCmd2.ExecuteNonQuery();
               rcpCmd2.Parameters.Clear();

               //rcpCmd1.CommandText = "SELECT @@IDENTITY AS lastId ";
               rcpCmd2.CommandText = " SELECT TOP (1) id FROM  rozlTmp ORDER BY id DESC";
              

               SqlDataReader lastIdRoz = rcpCmd2.ExecuteReader();
               lastIdRoz.Read();
               int lastRozId = lastIdRoz.GetInt32(0);


               rcpCmd2.CommandText = "INSERT INTO rozTmRej (rejId, rozliczId) VALUES (@rId, @idroz) ";
               rcpCmd2.Parameters.AddWithValue("@idroz", lastRozId);
               rcpCmd2.Parameters.Add(new SqlParameter("@rId", System.Data.SqlDbType.Int));
               foreach (var pracaItem in w_pracy)
               {
                   rcpCmd2.Parameters["@rId"].Value = pracaItem.rejId;
                   rcpCmd2.ExecuteNonQuery();
               }
           }
       }

       class Obecnosc
       {
           public DateTime wejDat;
           public DateTime koniecDate;
           public Int64 rejId;
       }
     
	}

      public class SQLparam
       {
           public string name;
           public object val;

       }

  
}
