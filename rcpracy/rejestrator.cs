using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace rcpracy
   
{
    using Extensions1;
    public partial class rejestrator : Form
    {
        int lastIdPrac = -1;
        bool barKodeRepeated = false;
        uint timerLoop = 0;
        Form sender1;

        public rejestrator()
        {
            InitializeComponent();
        }
        public void setSender(Form sender)
        {
            this.sender1 = sender;

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label2.Text = "skaner gotowy";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            label2.Text = "skaner nie jest gotowy \r\n";
            label2.Text += "umieść cursor myszy na okienku wczytywania kodu kreskowego";            
        }

        private void rejestrator_Enter(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 2)
            {
                zapisZeruj();
            }
        }

        private void zapisZeruj()
        {
            System.Media.SystemSounds.Beep.Play();
            timer1.Enabled = false;
            label3zegar.ForeColor = Color.Brown;
            czas();
            int idPrac = 0;
            try
            {
                idPrac = Convert.ToInt32(textBox1.Text);
                timerLoop = 0;
                if (lastIdPrac == idPrac) // powtórne odczytanie tej samej karty przed upływem 15 sek
                {                    
                    if (!barKodeRepeated)
                    {
                        label3.Text += ", karta już była wczytana ";
                        barKodeRepeated = true;
                    }
                }
                else                    
                if (testId(idPrac))
                {
                    zapisCzasuPracy(idPrac);
                    barKodeRepeated = false;
                    lastIdPrac = idPrac;
                }
            }
            catch (FormatException)
            {
                label2.Text = "Błąd odczytu kodu kreskowego";
                

                return;
            }
            finally
            {
                label3zegar.ForeColor = Color.Blue;
                timer1.Enabled = true;
                textBox1.Text = null;
            }
   
        }

        private void zapisCzasuPracy(int idPrac)
        {
            System.Text.StringBuilder cmdText1 = new StringBuilder();
            cmdText1.Append("SELECT idr FROM rejestr where pr_Id = ");
            cmdText1.Append(idPrac);
            cmdText1.Append("AND czasDo IS NULL");

            try
            {
                using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand rcpCmd1 = new SqlCommand();
                    rcpCmd1.Connection = rcpConnection;
                    rcpCmd1.CommandText = cmdText1.ToString();
                    rcpConnection.Open();

                    SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();
                 
                    if (rcpPrac.HasRows && rcpPrac.Read())
                    {                      
                        zapisWyjscia((Int64) rcpPrac.GetSqlInt64(0));
                       
                    }

                    else
                    {
                        zapisWejscia(idPrac);
                        
                    }
                }
            }
            catch (Exception)
            {

                label3.Text = "Błąd zapisu czasu pracy ";
            }
        }

        private void zapisWyjscia(Int64 rejestrId)
        {
            System.Text.StringBuilder cmdText1 = new StringBuilder();
            cmdText1.Append("UPDATE rejestr set czasDo = @czas, czasDo1 = @czas where idr = ");
            cmdText1.Append(rejestrId);

            try
            {
                using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand rcpCmd1 = new SqlCommand();
                    rcpCmd1.Connection = rcpConnection;
                    rcpConnection.Open();
                    rcpCmd1.CommandText = cmdText1.ToString();
                    rcpCmd1.Parameters.AddWithValue("@czas", DateTime.Now.dateHourMin() );
                  
                    rcpCmd1.ExecuteNonQuery();
                    label3.Text = "Koniec";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void zapisWejscia(int idPrac)
        {
            System.Text.StringBuilder cmdText1 = new StringBuilder();
            cmdText1.Append("INSERT INTO rejestr (pr_Id, czasWe, czasWe1) VALUES ");
            cmdText1.Append("(@prId, @czas, @czas  )");
           

            try
            {
               
                
                using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand rcpCmd1 = new SqlCommand();
                    rcpCmd1.Connection = rcpConnection;
                    rcpCmd1.CommandText = cmdText1.ToString();
                    rcpConnection.Open();
                    
                    {
                    
                    rcpCmd1.Parameters.AddWithValue("@prId", idPrac);
                    rcpCmd1.Parameters.AddWithValue("@czas",  DateTime.Now.dateHourMin() );
                    }
                    rcpCmd1.ExecuteNonQuery();
                    label3.Text = "Wejście";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool testId(int idPrac)
        {
            try
            {
                using (SqlConnection rcpConnection = new SqlConnection(Funct.RcpConnectionStr))
                {
                    SqlCommand rcpCmd1 = new SqlCommand();
                    rcpCmd1.Connection = rcpConnection;
                    rcpConnection.Open();
                    rcpCmd1.CommandText = "SELECT * FROM pracownik where pr_Id = " + idPrac.ToString();
                    SqlDataReader rcpPrac = rcpCmd1.ExecuteReader();
                    if (rcpPrac.HasRows && rcpPrac.Read())
                    {
                        label2.Text = rcpPrac["Nazwisko"].ToString() + " " + rcpPrac["Imie"];
                        return true;
                    }

                    else
                    {
                        label2.Text = "nie znaleziono pracownika";
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                label2.Text = "Błąd Sql podczas szukania pracownika";
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            czas();
            timerLoop++;
            if (timerLoop > 15)
            {
                lastIdPrac = -1;
                barKodeRepeated = false;
                timerLoop = 0;
                label2.Text = "skaner gotowy";
                label3.Text = null;
            }
        }

        private void czas()
        {
            label3zegar.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void rejestrator_Load(object sender, EventArgs e)
        {
            this.sender1.WindowState = FormWindowState.Minimized;
        }

        private void rejestrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            sender1.WindowState = FormWindowState.Normal;
        }


    }
}
