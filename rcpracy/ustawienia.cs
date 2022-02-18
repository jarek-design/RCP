using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace rcpracy
{
    public partial class Ustawienia : Form
    {
       
        System.Data.SqlClient.SqlConnectionStringBuilder GratyfDB, RCP_DB;
        
        public Ustawienia()
        {
            InitializeComponent();            
            GratyfDbSet();
            RcpDbSet();

            textBox4uzytk.Text = Authent.UserLogin.userName;
            passEye1.Text = Authent.UserLogin.password;
        }

        public void AdmDisable()
        {
            button4zapis.Enabled = false;
        }

        private void GratyfDbSet()
        {
            GratyfDB = new System.Data.SqlClient.SqlConnectionStringBuilder(Funct.GetGratyfConnectionStr());
            checkBox1.Checked = GratyfDB.IntegratedSecurity;
            textBox1Server.Text = GratyfDB.DataSource;
            textBox2db.Text = GratyfDB.InitialCatalog;
            textBox3user.Text = GratyfDB.UserID;
            textBox4pass.Text = GratyfDB.Password;
            panel2Credent.Enabled = !(checkBox1.Checked);           
        }

        private void RcpDbSet()
        {
            RCP_DB = new System.Data.SqlClient.SqlConnectionStringBuilder(Funct.RcpConnectionStr);
            checkBoxAutent.Checked = RCP_DB.IntegratedSecurity;
            textBoxServer.Text = RCP_DB.DataSource;
            textBoxDB.Text = RCP_DB.InitialCatalog;
            textBoxUser.Text = RCP_DB.UserID;
            textBoxPass.Text = RCP_DB.Password;
            panel1Credent.Enabled = !(checkBoxAutent.Checked);

            radioButtLocalDb.Checked = RCP_DB.ConnectionString.Contains("LocalDB");
            groupBox4.Enabled = ! radioButtLocalDb.Checked;

            radioButtonServerDB.Checked = !radioButtLocalDb.Checked;
            buttonLocalDbSave.Visible = false;
        }

        private void Ustawienia_Load(object sender, EventArgs e)
        {
            // dla ustawień rozliczania
            Configuration.Instance.ini();
            nocStartTextBox1.Text = Configuration.confData.nocStart.ToString();
            nocEndTextBox1.Text = Configuration.confData.nocEnd.ToString();
            textBoxTPZ.Text = Configuration.confData.toler.ToString();
            textBoxNormaDz.Text = Configuration.confData.normaDzienna.ToString();
            
            textBoxPrzerwa.Text = Configuration.confData.przerwaWpracy.ToString();
            
            if (Configuration.confData.maxGodz == 0)
                Configuration.confData.maxGodz = 12;

            textBoxMaxGodz.Text = Configuration.confData.maxGodz.ToString();
            checkBox2TPZ.Checked = Configuration.confData.zaokrTPZ;


            checkBoxRej.Checked = Configuration.confData.rejestratorW;
            checkBoxRej2.Checked = Configuration.confData.rejestratorZewn;            
           
           
            radioButton2.Checked = Configuration.confData.impPracUmowa;
            radioButton3.Checked = Configuration.confData.impPracCywPraw;
            

            if (String.IsNullOrEmpty(Configuration.confData.impSepa))
                Configuration.confData.impSepa = ";";

            if (String.IsNullOrEmpty(Configuration.confData.impWe))
                Configuration.confData.impWe = "0";

            textBox1Sepa.Text = Configuration.confData.impSepa;
            textBox2We.Text = Configuration.confData.impWe;
            checkBoxStart.Checked = Configuration.confData.limPoczPracy;
         


        }




        private void ButtonZapis_Click(object sender, System.EventArgs e)
        {
            string cstr1 = connectionStringGratyfCreate();            
            ChangeConnectionString(Funct.GratyfConnStringName, cstr1, textBoxInfo);
            //textBoxInfo.Text += "Zapisany connection string: " + cstr1 + "\r\n";
        }

        private string connectionStringGratyfCreate()
        {
            GratyfDB.IntegratedSecurity = checkBox1.Checked;
            GratyfDB.DataSource = textBox1Server.Text;
            GratyfDB.InitialCatalog = textBox2db.Text;

            if (GratyfDB.IntegratedSecurity)
            {
                GratyfDB.Remove("User ID");
                GratyfDB.Remove("Password");
            }
            else
            {
                GratyfDB.UserID = textBox3user.Text;
                GratyfDB.Password = textBox4pass.Text;
            }
            return GratyfDB.ToString();
        }

        private string connectionStringRCPCreate()
        {
            RCP_DB.IntegratedSecurity = checkBoxAutent.Checked;
            RCP_DB.DataSource = textBoxServer.Text;
            RCP_DB.InitialCatalog = textBoxDB.Text;

            if (RCP_DB.IntegratedSecurity)
            {
                RCP_DB.Remove("User ID");
                RCP_DB.Remove("Password");
                RCP_DB.Remove("AttachDBFilename");
            }
            else
            {
                RCP_DB.UserID = textBoxUser.Text;
                RCP_DB.Password = textBoxPass.Text;
            }
            return RCP_DB.ToString();
           
  
        }



        private bool ChangeConnectionString(string connStringName, string newValue, TextBox txb1)
        {
           // string s = System.Configuration.ConfigurationManager.ConnectionStrings["str"].ToString(); // get connectionString;
            try
            {
                //CreateXDocument and load configuration file
                XDocument doc = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                //Find all connection strings
                var query1 = from p in doc.Descendants("connectionStrings").Descendants()
                             select p;

                //Go throught each connection string elements find atribute specified by argument and replace its value with newVAlue
                foreach (var child in query1)
                {
                    foreach (var atr in child.Attributes())
                    {
                        if (atr.Name.LocalName == "name" && atr.Value == connStringName)
                            if (atr.NextAttribute != null && atr.NextAttribute.Name == "connectionString")
                                atr.NextAttribute.Value = newValue;
                    }
                }

                doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                
                txb1.Text += "\r\n Zmiany serwera zostały zapisane";
                txb1.Text += "\r\n Zmiany będą skuteczne po powtórnym uruchomieniu programu";
                txb1.Text += "\r\n Należy zamknąć i powtórnie uruchomić program! ";
                return true;
            }
            catch (Exception)
            {
                txb1.Text += "\r\n Nie wpisano zmian";
                return false;
            }
        }

        private void buttonGratyfTest_Click(object sender, EventArgs e)
        {
            string cstr1 = connectionStringGratyfCreate();
            //textBoxInfo.Text += "\r\n Nowy connection string: " + cstr1 + "\r\n";

            CennectionTest(cstr1, "SELECT TOP (2) slk_Id FROM dbo.sl_Kalendarz", textBoxInfo);
        }

        private void buttonRCPTest_Click(object sender, EventArgs e)
        {
            string cstr1 = connectionStringRCPCreate();
            //textBoxInfoRcp.Text += "\r\n Nowy connection string: " + cstr1 + "\r\n";
            CennectionTest(cstr1, "SELECT TOP (1) * FROM grupa", textBoxInfoRcp);
        }

        private void CennectionTest(string cstr1, string commandText, TextBox txb1)
        {
            try
            {
                using (SqlConnection rConnection = new SqlConnection(cstr1))
                {
                    rConnection.Open();
                    SqlCommand cmd1 = new SqlCommand(commandText);
                    cmd1.Connection = rConnection;
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                        txb1.Text = "Ustawienia połączenia z bazą danych prawidłowe";
                }
            }
            catch (Exception)
            {
                txb1.Text = "\r\n Brak połączenia z bazą danych";
            }
        }

     
        private void button3ustaw_Click(object sender, EventArgs e)
        {
            // zapis danych konfiguracyjnych
            Configuration.confData.nocStart = Convert.ToInt32(nocStartTextBox1.Text);
            Configuration.confData.nocEnd = Convert.ToInt32(nocEndTextBox1.Text);
            Configuration.confData.toler = Convert.ToInt32(textBoxTPZ.Text);
            Configuration.confData.normaDzienna = Convert.ToInt32(textBoxNormaDz.Text);
           
            Configuration.confData.przerwaWpracy = Convert.ToInt32(textBoxPrzerwa.Text);      
            Configuration.confData.maxGodz = Convert.ToInt32(textBoxMaxGodz.Text);
            Configuration.confData.zaokrTPZ = checkBox2TPZ.Checked;
            Configuration.confData.limPoczPracy = checkBoxStart.Checked;
            zapis();            
        }

        private void zapis()
        {
            try
            {
                Configuration.Instance.Serialize();
                MessageBox.Show("Zmiany zapisano");
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w zapisie", "Brak zapisu ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration.confData.rejestratorW = checkBoxRej.Checked;
            Configuration.confData.rejestratorZewn = checkBoxRej2.Checked;
            
            Configuration.confData.rejAdres = textBoxRej.Text;
            zapis(); 
        }

        private void testButton2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxRej.Text))
            {
                MessageBox.Show("Proszę wpisać adres bazy danych rejestratora", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                string rcpConnStr = Extensions1.Gfunc.setConnString("rejestr.sdf", textBoxRej.Text);
                System.Data.SqlClient.SqlConnection rcpConnection = new System.Data.SqlClient.SqlConnection(rcpConnStr);
                rcpConnection.Open();
                MessageBox.Show("Jest połączenie z bazą danych", "Połączone z rejestratorem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Adres nie jest wpisany właściwie", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

      
        private void button4zapis_Click(object sender, EventArgs e)
        {
            Authent.Authentication user = new Authent.Authentication(Funct.RcpConnectionStr);
            user.writeUser(textBox4uzytk.Text, passEye1.Text);            
        }

        private void button5Zapis_Click(object sender, EventArgs e)
        {
            //Configuration.confData.remote = checkBox5remote.Checked;
        }

        private void button2ImpPrac_Click(object sender, EventArgs e)
        {           
      
            Configuration.confData.impPracUmowa = radioButton2.Checked;
            Configuration.confData.impPracCywPraw = radioButton3.Checked;
            zapis();
        }

        private void radioButton2_Enter(object sender, EventArgs e)
        {
            label9Info.Text = @"Importowani są aktywni pracownicy zatrudnieni na umowę o pracę 
    podstawą do importu jest data końca umowy lub data zwolnienia.  Daty te mogą być puste
    - czyli pracownicy aktualnie zatrudnieni";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label9Info.Text = @"Importowani są aktywni pracownicy zatrudnieni na umowę cywilno-prawną
podstawą do importu jest data końca umowy lub data zwolnienia.  Daty te mogą być puste
    - czyli pracownicy aktualnie zatrudnieni";
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Configuration.confData.impSepa = textBox1Sepa.Text.Trim();
            Configuration.confData.impWe = textBox2We.Text.Trim();
            zapis();
        }

        private void radioButtonServerDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonServerDB.Checked)
            { groupBox4.Enabled = true;
                buttonLocalDbSave.Enabled = false;
            }

            else
            {
                groupBox4.Enabled = false;
                buttonLocalDbSave.Enabled = true;
            }
        }

        private void checkBoxAutent_CheckedChanged(object sender, EventArgs e)
        {
            panel1Credent.Enabled = !checkBoxAutent.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel2Credent.Enabled = !checkBox1.Checked;
        }

        //private void button4RcpTest_Click(object sender, EventArgs e)
        //{

        //}

        private void radioButtLocalDb_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtLocalDb.Checked)
                buttonLocalDbSave.Visible = true;
        }

        private void buttonLocalDbSave_Click(object sender, EventArgs e)
        {
            string cstr1 = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\RCP.mdf;Integrated Security=True";
            ChangeConnectionString(Funct.rcpConnStringName, cstr1, textBoxInfoRcp);

            zapis();
        }

        private void buttonServer4Rcp_Click(object sender, EventArgs e)
        {
            string cstr1 = connectionStringRCPCreate();           
            ChangeConnectionString(Funct.rcpConnStringName, cstr1, textBoxInfoRcp);
            
            zapis();
        }
    }
}




