using System;
using System.Windows.Forms;

namespace progSetup
{
    public partial class progrRegister1 : UserControl
    {
        public progrRegister1()
        {
            InitializeComponent();
            FirmaConfig.Instance.ini();
            programSetup.Instance.ini();

            NazwaTextBox1.Text = FirmaConfig.configF.nazwa;
            miejscTextBox1.Text = FirmaConfig.configF.miejsc;
            kodpTextBox1.Text = FirmaConfig.configF.kodpoczt;
            adresTextBox1.Text = FirmaConfig.configF.adres;
            nipTextBox1.Text = FirmaConfig.configF.nip;
            telTextBox1.Text = FirmaConfig.configF.telefon;
            emailTextBox1.Text = FirmaConfig.configF.email;
           
            
            if (programSetup.register.isRegistered)
            {
                SendButton1.Visible = false;
                rejestrButton3.Enabled = false; 
                label19.Visible = true;
            }
            else
                label19.Visible = false;

            if (programSetup.register.zam)
            {
                SendButton1.Visible = false;
                rejestrButton3.Visible = true;
            }
            else
            {
                rejestrButton3.Enabled = false;
                SendButton1.Visible = true;
            }

           
        }

        private void SendButton1_Click(object sender, EventArgs e)
        {
            int idFirm;

            FirmaConfig.configF.nazwa = NazwaTextBox1.Text;
            FirmaConfig.configF.miejsc = miejscTextBox1.Text;
            FirmaConfig.configF.kodpoczt = kodpTextBox1.Text;   
            FirmaConfig.configF.adres = adresTextBox1.Text;
            FirmaConfig.configF.nip = nipTextBox1.Text;
            FirmaConfig.configF.telefon = telTextBox1.Text;
            FirmaConfig.configF.email = emailTextBox1.Text;
            FirmaConfig.Instance.Serialize();          
            Authent.RegisterService.Service1Client reg1 = new Authent.RegisterService.Service1Client();
            Authent.RegisterService.FirmaD firma1 = reg1.GetFirma(FirmaConfig.configF.nip);
            if (firma1 == null)
            {
               idFirm =  reg1.SetFirma(new Authent.RegisterService.FirmaD {
                 adres = FirmaConfig.configF.adres,
                 miejsc = FirmaConfig.configF.miejsc,
                 nazwa = FirmaConfig.configF.nazwa,
                 kodpoczt = FirmaConfig.configF.kodpoczt,
                 nip = FirmaConfig.configF.nip,
                 tel = FirmaConfig.configF.telefon
                });
               MessageBox.Show("Dane firmy zostały przesłane");
                if (idFirm <=0 )
                {
                    MessageBox.Show("Błąd podczas przesyłania danych firmy");
                    return;
                }
            }

            else
                idFirm = firma1.idfi;

            Authent.RegisterService.Order ord1 = new Authent.RegisterService.Order
            {
                Idf = idFirm,
                Program = 7,
                Progver = 2,
                OrderDate = DateTime.Now
            };

            Authent.RegisterService.OrderVerifi ov = reg1.SetOrder(ord1);

            programSetup.Instance.ini();
            programSetup.register.dataZam = ord1.OrderDate;
            programSetup.register.nip = FirmaConfig.configF.nip;
            programSetup.register.isRegistered = false;
            programSetup.register.registerId = ov.RegistrId;
            programSetup.Instance.Serialize();
           
            MessageBox.Show("Zamówienie przesłane.\nProszę sprawdzić skrzynkę pocztową");
            rejestrButton3.Visible = true;
            this.Visible = false;

        }
        //string nipChecker (string nip)
        //{
        //    nip = nip.Replace("-", "");
        //    return nip.Replace(" ", "");
        //}


     

        private void rejestrButton3_Click_1(object sender, EventArgs e)
        {
            Authent.RegisterService.Service1Client reg1 = new Authent.RegisterService.Service1Client();
            //registration register = (registration)SerialD.DeSerialize("prSetup.xml", new registration());
            programSetup.Instance.ini();

            if (programSetup.register.registerId > 0)
            {
                if (reg1.P_register(programSetup.register.nip, programSetup.register.registerId).succes > 0)
                {
                    MessageBox.Show("Program został zarejestrowany");
                    label19.Visible = true;
                    programSetup.register.isRegistered = true;
                    programSetup.register.dataRej = DateTime.Now;
                    programSetup.Instance.Serialize();
                }

            }

            this.Visible = false;
        }

              
    }
}
