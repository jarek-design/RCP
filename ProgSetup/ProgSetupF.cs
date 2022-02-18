using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using progSetup; 

namespace ProgSetup
{
    public partial class progRegistrF : Form
    {
        
        int freeDays = 30;
        DateTime d1;
        //public bool isRegistered;
        Functions.registerReference.OrderVerifi ordVerify = null;
        

        public progRegistrF()
        {
            InitializeComponent();
            SerialData.showMessage = false;
            FirmaConfig.Instance.ini(); //f
            programSetup.Instance.ini(); //f
            infoLabel19.Text = string.Empty;
            
            //isRegistered = false;
            NazwaTextBox1.Text = FirmaConfig.configF.nazwa;
            miejscTextBox1.Text = FirmaConfig.configF.miejsc;
            kodpTextBox1.Text = FirmaConfig.configF.kodpoczt;
            adresTextBox1.Text = FirmaConfig.configF.adres;
            nipTextBox1.Text = FirmaConfig.configF.nip;
            telTextBox1.Text = FirmaConfig.configF.telefon;
            emailTextBox1.Text = FirmaConfig.configF.email;
            textBoxlicencja.Text = programSetup.register.licenceNr;
            if (String.IsNullOrEmpty(programSetup.register.ds))
            {
                if (programSetup.register.isRegistered || programSetup.register.zam)
                    MessageBox.Show("Błąd w rejestracji licencji");
                progSetup.programSetup.register.isRegistered = false;                
                progSetup.programSetup.register.ds = Authent.Cryptofunc.encrypt(DateTime.Now.AddDays(-24).Ticks.ToString());
                progSetup.programSetup.Instance.Serialize();
            }
            
            d1 = new DateTime(Convert.ToInt64(Authent.Cryptofunc.decrypt(programSetup.register.ds)));
            label04.Text = "";
           

            backgroundWorker1.RunWorkerAsync();
            if (programSetup.register.isRegistered)  
            {
                progRegistered();
                textBoxlicencja.Enabled = false;
                nipTextBox1.Enabled = false;
                info("opis3.xml");                   
            }
            else
            {
                label04.Text = "Program w wersji testowej będzie działał do ";
           
                if (programSetup.register.zam )
                {
                    progOrdered();
                }
                else
                {
                    infoLabel19.Text = "Proszę uzupełnić dane i wysłać zamówienie";
                    rejestrButton3.Enabled = false;
                    SendButton1.Visible = true;
                    label04.Text += d1.AddDays(freeDays).ToShortDateString() + " ";
                    info("opis1.xml"); 
                }
            }  
        }

        private void info(string opis)
        { //"opis1.xml"
            Info inf1 = (Info)SerialD.DeSerialize(opis, new Info());
            if (inf1 == null)
            {
                MessageBox.Show("Brak zbioru " + opis);
                tytLabel01.Text = null;
                tytlabel02.Text = null;
                Opislabel03.Text = null;
            }
            else
            {
                tytLabel01.Text = inf1.tyt;
                tytlabel02.Text = inf1.tyt2;
                Opislabel03.MaximumSize = new Size(this.Width - 3 * Opislabel03.Location.X, 0);
                Opislabel03.Text = inf1.opis1.Replace("\\r\\n", "\r\n");
            }
        }

        private void progOrdered()
        {
            // program zamówiony
            textBoxlicencja.Enabled = false;
            nipTextBox1.Enabled = false;
            SendButton1.Enabled = false;

            label04.Text += d1.AddDays(freeDays).ToShortDateString() + " ";
            info("opis2.xml");

        }

        private void progRegistered()
        {
            // program zarejestrowany
            SendButton1.Visible = false;
            rejestrButton3.Enabled = false;
            infoLabel19.Visible = true;
            //Info inf1 = (Info)SerialD.DeSerialize("opis3.xml", new Info());
            //isRegistered = true;
            label04.Visible = false;
            infoLabel19.Text = "Program zarejestrowany";
            info("opis3.xml");
            return;
        }

        //private void disable()
        //{
        //    emailTextBox1.Enabled = false;
        //    nipTextBox1.Enabled = false;
        //    textBoxlicencja.Enabled = false;
        //}



        private void SendButton1_Click(object sender, EventArgs e)
        {

            //wysłanie zamówienia ;
            int idFirm;

            FirmaConfig.configF.nazwa = NazwaTextBox1.Text;
            FirmaConfig.configF.miejsc = miejscTextBox1.Text;
            FirmaConfig.configF.kodpoczt = kodpTextBox1.Text;
            FirmaConfig.configF.adres = adresTextBox1.Text;
            FirmaConfig.configF.nip = nipTextBox1.Text;
            FirmaConfig.configF.telefon = telTextBox1.Text;
            FirmaConfig.configF.email = emailTextBox1.Text;
            FirmaConfig.Instance.Serialize();

            if (string.IsNullOrEmpty(nipTextBox1.Text))
            {
                MessageBox.Show("Konieczne jest podanie NIP firmy");
                return;
            }
            if (string.IsNullOrEmpty(emailTextBox1.Text))
            {
                MessageBox.Show("Konieczne jest podanie email firmy");
                return;
            }
            Functions.registerReference.Service1Client reg1 = null;
            try
            {
                reg1 = new Functions.registerReference.Service1Client();
                Functions.registerReference.FirmaD firma1 = reg1.GetFirma(FirmaConfig.configF.nip);
                if (firma1 == null)
                {
                    
                    idFirm = reg1.SetFirma(new Functions.registerReference.FirmaD
                    {
                        adres = FirmaConfig.configF.adres,
                        miejsc = FirmaConfig.configF.miejsc,
                        nazwa = FirmaConfig.configF.nazwa,
                        kodpoczt = FirmaConfig.configF.kodpoczt,
                        nip = FirmaConfig.configF.nip,
                        tel = FirmaConfig.configF.telefon
                    });
                    MessageBox.Show("Dane firmy zostały przesłane");
                    //isRegistered = true;
                    if (idFirm <= 0)
                    {
                        MessageBox.Show("Błąd podczas przesyłania danych firmy");
                        return;
                    }
                    FirmaConfig.configF.idfi = idFirm;
                    FirmaConfig.Instance.Serialize();
                }

                else
                    idFirm = firma1.idfi;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem przy przesyłaniu danych");
                return;
            }


            if (string.IsNullOrEmpty(textBoxlicencja.Text))
            {
                MessageBox.Show("Konieczne jest podanie nr licencji");
                return;
            }

            FirmaConfig.Instance.Serialize();


            programSetup.register.dataZam = DateTime.Now;
            programSetup.register.nip = FirmaConfig.configF.nip;
            programSetup.register.isRegistered = false;
            programSetup.register.licenceNr = textBoxlicencja.Text;
            programSetup.Instance.Serialize();


            Functions.registerReference.Order ord1 = new Functions.registerReference.Order
            {
                Idf = idFirm,
                Program = SetupFunc.ordProgram,
                Progver = SetupFunc.ordProgVer,
                OrderDate = DateTime.Now,
                licenceNr = textBoxlicencja.Text
            };
            if (reg1 != null)
            {
                ordVerify = reg1.SetOrder(ord1);
                if (ordVerify != null && ordVerify.RegistrId > 0)
                {
                    programSetup.register.zam = true;
                    programSetup.register.registerId = ordVerify.RegistrId;
                    programSetup.Instance.Serialize();

                    infoLabel19.Text = "Zamówienie wysłane";

                    rejestrButton3.Visible = true;
                    progOrdered();
                }
            }
        }
        //string nipChecker (string nip)
        //{
        //    nip = nip.Replace("-", "");
        //    return nip.Replace(" ", "");
        //}




        private void rejestrButton3_Click_1(object sender, EventArgs e)
        {
            Functions.registerReference.Service1Client reg1 = null;
            try
            {
                rejestrButton3.Enabled = false;
                reg1 = new Functions.registerReference.Service1Client();
            }
            catch (Exception)
            {
                MessageBox.Show("Problem przy przesyłaniu danych");
                return;
            }
            //registration register = (registration)SerialD.DeSerialize("prSetup.xml", new registration());


            if (reg1 != null && programSetup.register.registerId > 0)
            {
                sbyte s1 = reg1.P_register(programSetup.register.nip, programSetup.register.registerId).succes;
                if (s1 > 0)
                {
                    MessageBox.Show("Program został zarejestrowany");
                    infoLabel19.Visible = true;
                    programSetup.register.isRegistered = true;
                    programSetup.register.dataRej = DateTime.Now;
                    programSetup.Instance.Serialize();


                    FirmaConfig.configF.isRegistered = true;
                    FirmaConfig.Instance.Serialize();
                    progRegistered();
                }
                else
                    if (s1 == -5)
                        infoLabel19.Text = "Program jeszcze nie opłacony";

            }


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (FirmaConfig.configF.nip != null)  //  && programSetup.register.registerId > 0
            {
                try
                {
                    Functions.registerReference.Service1Client rej2 = new Functions.registerReference.Service1Client();
                    ordVerify = rej2.GetOrder(FirmaConfig.configF.nip, SetupFunc.ordProgram, programSetup.register.licenceNr);
                }
                catch (Exception)
                {
                    ordVerify = null;
                    rejestrButton3.Visible = false;
                    SendButton1.Visible = false;
                    //infoLabel19.Text = "Proszę sprawdzić połączenie sieciowe";
                    infoLabel19.Text = "Programu nie można zarejestrować";
                }

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ordVerify != null)
            {

                if (programSetup.register.registerId == 0 && ordVerify.RegistrId > 0)
                {
                    programSetup.register.registerId = ordVerify.RegistrId;
                    programSetup.Instance.Serialize();
                }

                if (!programSetup.register.zam && ordVerify.Payment == true)
                {
                    programSetup.register.zam = true;
                    programSetup.Instance.Serialize();
                }
                orderInfo();
            }
        }


        private void orderInfo()
        {
            if (programSetup.register.isRegistered && FirmaConfig.configF.isRegistered)
                progRegistered(); // możliwość włamania .. trzeba dołożyć inne warunki

            else
                if (ordVerify == null || ordVerify.RegistrId == 0)
                    infoLabel19.Text = "Proszę uzupełnić dane i wysłać zamówienie";
                else
                    if (ordVerify.Payment != true)
                    {
                        infoLabel19.Text = "Program jeszcze nie opłacony";
                        rejestrButton3.Visible = false;
                        progOrdered();
                    }
                    else
                        if (programSetup.register.isRegistered)
                            progRegistered();
                        else
                        {
                            rejestrButton3.Visible = true;
                            rejestrButton3.Enabled = true;
                            SendButton1.Visible = false;

                            progOrdered();
                            infoLabel19.Text = "Program opłacony, proszę zarejestrować";
                        }
        }

        private bool registerCheck()
        {
            if (!System.IO.File.Exists("prSetup.xml"))
            {
                SerialData.showMessage = false;
                SetupFunc.usingProgramStart();

            }

            return true;
        }
       
              
    }
}

