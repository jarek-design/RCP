using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rcpracy
{
    public static class Gfunc
    {
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
    }
}
