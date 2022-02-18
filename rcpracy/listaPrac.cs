using System.IO;
using System.Data.SqlClient;
using Extensions1;

namespace rcpracy
{
    public class listaPrac
    {
        TextWriter txtFile;
        SqlConnection rcpConnection;
        public listaPrac(string plik)
        {
            rcpConnection = new SqlConnection(Funct.RcpConnectionStr);
            txtFile = File.CreateText(plik);
            writePracFile();
        }

        void writePracFile()
        {
            SqlCommand rcpCmd1 = new SqlCommand();
            rcpCmd1.Connection = rcpConnection;
            rcpConnection.Open();
            rcpCmd1.CommandText = "SELECT  pr_Id, Imie, Nazwisko FROM pracownik order by Nazwisko ";
            SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();
            while (rcpPrac.Read())
            {
                for (int iii = 0; iii<3; iii++)
                {
                    if (iii == 0)
                        txtFile.Write("0".Repeat(3 - rcpPrac[0].ToString().Length));

                    txtFile.Write(rcpPrac[iii]);
                   
                    if (iii  < 2)
                        txtFile.Write(", ");
                }
                txtFile.WriteLine();
            }
            txtFile.Close();
        }

    }

}
