using System;
using System.Security.Cryptography;
using System.IO;
using System.Data.SqlClient;

namespace Authent
{
    public static class Cryptofunc
    {
        static string k1 = "oaEEMctGGuozDp";
        static string v1 = "52G4OXFLEBLHV7MYtRMggQ1+";
        static byte[] Key = Convert.FromBase64String(pk1()+k1);
        static byte[] IV = Convert.FromBase64String(v1);

       
        public static string encrypt(string Plain_Text)
        {
            //szyfrowanie

            RijndaelManaged Crypto = new RijndaelManaged();
            MemoryStream MemStream;
            ICryptoTransform Encryptor;
            CryptoStream Crypto_Stream;

            System.Text.UTF8Encoding Byte_Transform = new System.Text.UTF8Encoding();
            byte[] PlainBytes = Byte_Transform.GetBytes(Plain_Text);

            MemStream = new MemoryStream();
            Encryptor = Crypto.CreateEncryptor(Key, IV);
            Crypto_Stream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write);
            Crypto_Stream.Write(PlainBytes, 0, PlainBytes.Length);


            Crypto.Clear();
            Crypto_Stream.Close();
            return Convert.ToBase64String(MemStream.ToArray());
        }
        static string pk1()
        {
            UInt16 a1 = 15;
            UInt16 a2 = 5;
            return (a1 * 2 + a2).ToString();

        }

        public static string decrypt(string Cipher_Text)
        {
            RijndaelManaged Crypto = new RijndaelManaged();
            MemoryStream MemStream = null;
            ICryptoTransform Decryptor = null;
            CryptoStream Crypto_Stream = null;
            StreamReader Stream_Read = null;
            string Plain_Text;

            try
            {
                MemStream = new MemoryStream(Convert.FromBase64String(Cipher_Text));
                Decryptor = Crypto.CreateDecryptor(Key, IV);
                Crypto_Stream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read);

                Stream_Read = new StreamReader(Crypto_Stream);
                Plain_Text = Stream_Read.ReadToEnd();
            }
            catch (Exception e)
            {
                throw e;
            }

            finally
            {
                if (Crypto != null)
                    Crypto.Clear();
                MemStream.Flush();
                MemStream.Close();
            }
            return Plain_Text;
        }
    }

    public static class UserLogin
    {
        public static string userName;
        public static string password;
       
    }

    public class Authentication
    {
        string connStr;
       

        public Authentication(string connectionString)
        {
            connStr = connectionString;
        }
        public bool writeUser(string userName, string password)
        {
            string userCmdTxt;
            
            SqlConnection rcpConnection = new SqlConnection(connStr);
            rcpConnection.Open();
            SqlCommand rcpCmd1 = new SqlCommand("SELECT TOP (1) id FROM admin");
            rcpCmd1.Connection = rcpConnection;
            SqlDataReader userParam = rcpCmd1.ExecuteReader();
                //ExecuteResultSet(ResultSetOptions.Scrollable);
            
            if (!userParam.HasRows)
                userCmdTxt = " INSERT INTO admin (name, password, empty ) VALUES (@UserN , @Passw, @Empty)";
            else
            {
                //rcpRead.Read();
                //id = rcpRead.GetInt32(0);
                userCmdTxt = "UPDATE admin SET name = @UserN, password = @Passw, empty = @Empty ";
            }
            userParam.Close();
            //Cryptofunc.encrypt(password)
            rcpCmd1.Parameters.AddWithValue("@UserN", userName);
            rcpCmd1.Parameters.AddWithValue("@Passw", password);
            rcpCmd1.Parameters.AddWithValue("@Empty", 0);

            rcpCmd1.CommandText = userCmdTxt;
            rcpCmd1.ExecuteNonQuery();

            return true;

        }

        public bool testUser(string userName, string password)
        {
            string test = Cryptofunc.encrypt(password);
            try
            {
                 SqlConnection rcpConnection = new SqlConnection(connStr);
            rcpConnection.Open();
            SqlCommand rcpCmd1 = new SqlCommand("SELECT TOP (1) id FROM admin ");
            rcpCmd1.Connection = rcpConnection;
            
            
            SqlDataReader userParam = rcpCmd1.ExecuteReader();

            if (userParam.HasRows)
            {
                userParam.Close();
                rcpCmd1.Parameters.AddWithValue("@UserN", userName);
                rcpCmd1.Parameters.AddWithValue("@Passw", password);
                rcpCmd1.CommandText = "SELECT TOP (1) id FROM admin where name = @UserN and password = @Passw ";
                userParam = rcpCmd1.ExecuteReader();
                if (userParam.HasRows)
                    return true;
                else
                    return false;
            }
            else
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
         
            
        }


    }

    
    
}


