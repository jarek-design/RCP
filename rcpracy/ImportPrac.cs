using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace rcpracy
{
    static class ImportPrac
    
    {
       static ImportPrac()
        {

        }

        public static bool import()
        {
            string infoTxt = null;
            string sqlCond = " pr_Id= 0" ; // war false;
            Configuration.Instance.ini();
            try
            {
            if (Configuration.confData.impPracUmowa)
            {
                infoTxt = "Pracownicy aktualnie pracującu na umowę o pracę";
                sqlCond =
@"SELECT pr_Id, pr_Imie, pr_Imie2, pr_Nazwisko, pr_PESEL, pr_NIP, uk_WymiarLicznik , uk_WymiarMianownik , uk_WymiarDobowy FROM dbo.pr_Pracownik 
inner join plb_Umowa on pr_Id = up_IdPracownika 
inner join plb_UmowaKalendarz on up_Id = uk_IdUmowy 
where ((up_DataRozwiazania is NULL or up_DataRozwiazania > GETDATE() ) and (up_DataDo > GETDATE() or up_DataDo is NULL) ) 
and (uk_DataOd  <= GETDATE()  and (uk_DataDo > GETDATE() or uk_DataDo is NULL) )  ";
            }
            else       
            if (Configuration.confData.impPracCywPraw)
                {
                    infoTxt = "zatrudnieni na podstawie umowy cywilno-prawnej.";
                    sqlCond =  "SELECT pr_Id, pr_Imie, pr_Imie2, pr_Nazwisko,  pr_PESEL FROM dbo.pr_Pracownik  " +
                   "where pr_Id in ( select  ucp_IdPracownika  from plb_UmowaCP  where ucp_Rozwiazana = 0 and (ucp_DataDo  > GETDATE() or ucp_DataDo is NULL) )";
                }
                else
                {
                    MessageBox.Show("Błędne ustawienia.Proszę ustawić sposób importu pracowników w ustawieniach");
                    return false;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Brak ustawień. Proszę ustawić sposób importu pracowników w ustawieniach");
                return false;
            }
           
          
            DialogResult result = MessageBox.Show("Zostaną zaimportowani pracownicy " + infoTxt, "Import pracowników z Gratyfikanta", MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return false;
            }

            uint updated = 0, added = 0;

            if (!Funct.GratyfConnStrTest())
                return false;

            SqlConnection gratyfConnection = new SqlConnection(Funct.GetGratyfConnectionStr());
            SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr);

            SqlCommand rcpCmd1 = new SqlCommand();
            rcpCmd1.Connection = rcpConnection;
            
            SqlCommand rcpCmd2 = new SqlCommand();
            rcpCmd2.Connection = rcpConnection;
            //SqlDataReader localPracRead;
            System.Text.StringBuilder cmdText = new StringBuilder();
            gratyfConnection.Open();
            rcpConnection.Open();
            SqlCommand gCmd1 = new SqlCommand(sqlCond);

            gCmd1.Connection = gratyfConnection;

            string pr_Id;
            int WymiarLicznik, WymiarMianownik, WymiarDobowy ;

            SqlDataReader dr1 = gCmd1.ExecuteReader();
            while (dr1.Read())
            {
                pr_Id = dr1["pr_Id"].ToString();
                rcpCmd1.CommandText = "SELECT pr_Id FROM pracownik where pr_Id = " + dr1["pr_Id"].ToString();

                cmdText.Clear();
                SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();      // ExecuteResultSet(ResultSetOptions.Scrollable);
                if (rcpPrac.HasRows)
                {
                    cmdText.Append("UPDATE pracownik set Imie = @imie, Nazwisko = @nazw ");
                    //cmdText.Append(", NIP = @nip, PESEL = @pesel, wymiarPracy = @WymiarPracy  WHERE pr_Id = @id");
                    cmdText.Append(",  wymiarPracy = @WymiarPracy  WHERE pr_Id = @id");
                    updated++;
                    // parametrów jest za dużo
                }
                else
                {
                    cmdText.Append("INSERT INTO pracownik (pr_Id, Imie, Nazwisko, wymiarPracy ) VALUES ( ");
                    cmdText.Append("@id, @imie, @nazw, @WymiarPracy )");
                    added++;
                }
                WymiarLicznik = dr1.GetInt32(dr1.GetOrdinal("uk_WymiarLicznik"));
                WymiarMianownik = dr1.GetInt32(dr1.GetOrdinal("uk_WymiarMianownik"));
                WymiarDobowy = dr1.GetInt32(dr1.GetOrdinal("uk_WymiarDobowy"));
                
                WymiarDobowy = WymiarDobowy * WymiarLicznik / WymiarMianownik ;

                rcpCmd2.CommandText = cmdText.ToString();
                rcpCmd2.Parameters.AddWithValue("@id", dr1["pr_Id"]);
                rcpCmd2.Parameters.AddWithValue("@imie", dr1["pr_Imie"]);
                rcpCmd2.Parameters.AddWithValue("@nazw", dr1["pr_Nazwisko"]);
                rcpCmd2.Parameters.AddWithValue("@nip", dr1["pr_NIP"]);
                rcpCmd2.Parameters.AddWithValue("@pesel", dr1["pr_PESEL"]);
                rcpCmd2.Parameters.AddWithValue("@WymiarPracy", WymiarDobowy );



                rcpCmd2.ExecuteNonQuery();
                rcpCmd2.Parameters.Clear();

                rcpPrac.Close();
            }
            
            rcpConnection.Close();
            gratyfConnection.Close();
            System.Windows.Forms.MessageBox.Show(info(updated, added));
            return true;
        }

        static string info(uint updated, uint added)
        {
            StringBuilder info = new StringBuilder("Uaktualniono - ", 75);
            info.Append(updated.ToString() + "\n");
            info.Append("Dodano - ");
            info.Append(added.ToString() + "\n");
            info.Append("Ogółem pracowników jest w bazie danych: ");
            info.Append((updated + added).ToString());
            return info.ToString();
        }
    }
}


 //cmdText.Append("INSERT INTO pracownik (pr_Id, Imie, Nazwisko, NIP,PESEL) VALUES ( " );
 //                   cmdText.Append("id, @imie, @nazw, @nip, @pesel )");


