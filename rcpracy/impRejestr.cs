using System;
using System.Text;
using System.Data.SqlClient;


// importuje dane z rejestratora

namespace rcpracy
{
    class impRejestr
    {
        string rejestrConnStr;
        SqlConnection rcpConnection;
        SqlConnection rejestrConnection;
        int importRecordCount, updated;
              
        public impRejestr()
        {
            Configuration.Instance.ini();            
        }


        public void load(System.Windows.Forms.ToolStripProgressBar progrBar1)
        {   
            //rcpCmd1.CommandText = "SELECT TOP (1) remoteId FROM rejestr WHERE (czasDo IS NULL and remoteSt = 1) ORDER BY remoteId";
            rejestrConnStr = Extensions1.Gfunc.setConnString("rejestr.sdf", Configuration.confData.rejAdres);
            
            if (Configuration.confData.rejestratorZewn && rejestrConnStr != null)
            {
               rcpConnection = new SqlConnection(Funct.RcpConnectionStr); 
               rejestrConnection = new SqlConnection(rejestrConnStr);

               try
               {
                   rcpConnection.Open();
               }
               catch (Exception)
               {
                   System.Windows.Forms.MessageBox.Show("Problem z dostępem do bazy danych ",
                       "Błąd", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                   return;
               }

               Int64 lastId = lastRemoteId();

               SqlCommand rcpCmd1 = new SqlCommand();
               rcpCmd1.Connection = rcpConnection;
               rcpParams(rcpCmd1);
               
               SqlCommand rejCmd1 = new SqlCommand();
               rejCmd1.CommandText = "SELECT count([idr])  FROM rejestr WHERE idr >= " + lastId.ToString();

               try
               {
                   rejCmd1.Connection = rejestrConnection;
                   rejestrConnection.Open();
               }
               catch (Exception)
               {
                   System.Windows.Forms.MessageBox.Show("Problem z dostępem do bazy danych rejestratora ",
                       "Błąd", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                   return;
               }

               int  count;
               importRecordCount = 0;
               updated = 0;
               //bool onlyNew = false;
               SqlDataReader rejestr = rejCmd1.ExecuteReader();
               progrBar1.Value = 0;  // aby był szary jeśli niema przetwarzania
               if (rejestr.Read() && (count = rejestr.GetInt32(0) )>0)
               {                                     
                   progrBar1.Maximum = count + 10;  // zwiększone o przeciętną liczbę uzupełnianych rekordów.
                   progrBar1.Visible = true;
               }
               else
                   return;

               rejestr.Close();
               rejestrImport(progrBar1, lastId, rcpCmd1, rejCmd1, "SELECT idr, pr_Id, czasWe, czasDo FROM rejestr where idr >= " + lastId.ToString() + " ORDER BY idr");
               string appendRest = "SELECT idr, pr_Id, czasWe, czasDo FROM rejestr where idr IN " + listToUpdate();
               //rejestrImport(progrBar1, lastId, rcpCmd1, rejCmd1, appendRest); poszukiwanie błędu;

               rcpConnection.Close();
               rejestrConnection.Close();
             }                
         }


        private void rejestrImport(System.Windows.Forms.ToolStripProgressBar progrBar1, Int64 lastId, SqlCommand rcpCmd1, SqlCommand rejCmd1, string commandTxt)
        {
            int result;
            SqlDataReader rejestr;
            string updateCommandTxt = "UPDATE rejestr set  czasDo = @CzasDo, czasWe1 = @CzasWe, czasDo1 = @CzasDo WHERE remoteId = @RemoteId";
            string addCommandTxt = "INSERT INTO rejestr (pr_Id, czasWe, czasDo, czasWe1, czasDo1, remoteId, remoteSt ) Values (@Pr_Id, @CzasWe, @CzasDo, @CzasWe, @CzasDo,@RemoteId, @RemoteSt )";

            rejCmd1.CommandText = commandTxt;
            rejestr = rejCmd1.ExecuteReader();
            while (rejestr.Read())
            {
                rcpCmd1.CommandText = updateCommandTxt;
                updated++;

                if (progrBar1.Value < progrBar1.Maximum)
                    progrBar1.Value++;
                result = updateRcp(rcpCmd1, rejestr);

                if (result <= 0)
                {
                    importRecordCount++;
                    rcpCmd1.CommandText = addCommandTxt;
                    rcpCmd1.ExecuteNonQuery();
                }
            }
        }

        private int updateRcp(SqlCommand rcpCmd1,  SqlDataReader rejestr)
        {
            setRcpParams(rcpCmd1, rejestr);

            return rcpCmd1.ExecuteNonQuery();
        }
      

        private void setRcpParams(SqlCommand rcpCmd1, SqlDataReader rejDr)
        {
            rcpCmd1.Parameters["@Pr_Id"].Value = rejDr.GetInt32(rejDr.GetOrdinal("pr_Id"));
            rcpCmd1.Parameters["@CzasWe"].Value = rejDr.GetDateTime(rejDr.GetOrdinal("czasWe"));
            
            rcpCmd1.Parameters["@CzasDo"].Value = rejDr[rejDr.GetOrdinal("czasDo")];
           
            rcpCmd1.Parameters["@RemoteId"].Value = rejDr.GetInt64(rejDr.GetOrdinal("idr"));
            rcpCmd1.Parameters["@RemoteSt"].Value = 1;      //toDo
            
        }
          //if (rejDr[rejDr.GetOrdinal("czasDo")] != DBNull.Value)
          //      rcpCmd1.Parameters["@CzasDo"].Value = rejDr.GetDateTime(rejDr.GetOrdinal("czasDo"));
          //  else
          //      rcpCmd1.Parameters["@CzasDo"].Value = DBNull.Value;
        private void rcpParams(SqlCommand rcpCmd1)
        {
            rcpCmd1.Parameters.Add(new SqlParameter("@Pr_Id", System.Data.SqlDbType.Int));
            
            rcpCmd1.Parameters.Add(new SqlParameter("@CzasWe", System.Data.SqlDbType.DateTime));
            rcpCmd1.Parameters.Add(new SqlParameter("@CzasDo", System.Data.SqlDbType.DateTime));

            rcpCmd1.Parameters.Add(new SqlParameter("@RemoteId", System.Data.SqlDbType.BigInt));
            rcpCmd1.Parameters.Add(new SqlParameter("@RemoteSt", System.Data.SqlDbType.TinyInt));   
        }
        


        private Int64 lastRemoteId()
        {
            Int64 lastId=0;
            SqlCommand rcpCmd1 = new SqlCommand();
            rcpCmd1.CommandText = "SELECT TOP (20) remoteId, czasDo FROM rejestr WHERE ( remoteSt = 1) ORDER BY remoteId DESC";
            rcpCmd1.Connection = rcpConnection;

            SqlDataReader rcp = rcpCmd1.ExecuteReader();
            while (rcp.Read())
            {              
               lastId =  rcp.GetInt64(0);
               if (!rcp.IsDBNull(1))
                   break;     
            }
            rcp.Close();
            return lastId;
        }

        string listToUpdate()
        {
            StringBuilder remoteIdtoUpdate = new StringBuilder("( ");
            bool first = true;
            SqlCommand rcpCmd1 = new SqlCommand();
            rcpCmd1.CommandText = "SELECT TOP (20) remoteId FROM rejestr WHERE (czasDo IS NULL and remoteSt = 1)";
            rcpCmd1.Connection = rcpConnection;

            SqlDataReader rcp = rcpCmd1.ExecuteReader();
            
            while ( rcp.Read())
            {
                if (!first)
                {
                    remoteIdtoUpdate.Append(" , "); 
                }
                remoteIdtoUpdate.Append(rcp.GetInt64(0));
                first = false;
            }
            remoteIdtoUpdate.Append(" )");
            rcp.Close();
            return remoteIdtoUpdate.ToString();
        }

        public string info()
        {
            StringBuilder info = new StringBuilder("Ualktualniono - ", 75);
            info.Append(updated.ToString());
            if (updated<5) 
                info.Append("  rekordy \n");
            else
                info.Append("  rekordów \n");
            if (importRecordCount > 0)
            {
                info.Append("Dodano - ");
                info.Append((updated - importRecordCount).ToString());
                if (updated - importRecordCount <5 )
                    info.Append("  rekordy");
                else
                    info.Append("  rekordów");
                info.Append(" rejestru");
            }
            return info.ToString();
        }
                            
    }
}
