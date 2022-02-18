using System;
using System.Windows.Forms;
using System.Diagnostics;


namespace progSetup
{
    public class licence
    {
        int freeDays = 30;
        int freeDays2;
        short ordProgram;
        byte ordProgVer;        
        //BackgroundWorker backgroundWorker2;
        registration cf;
        public bool progRegisterd;

        public int FreeDays { get => freeDays; set => freeDays = value; }
        public int FreeDays2 { get => freeDays2; set => freeDays2 = value; }
        public short OrdProgram { get => ordProgram; set => ordProgram = value; }
        public byte OrdProgVer { get => ordProgVer; set => ordProgVer = value; }

        public licence(Form f1, short ordProgram2, byte ordProgVer2)
        {

            FreeDays2 = FreeDays - 10;   // pocz wyśw. konieczności rejestracji
            this.OrdProgram = ordProgram2;
            this.OrdProgVer = ordProgVer2;
            //backgroundWorker2 = new BackgroundWorker();
            progRegisterd = false;
            if (!licenceCheck())
            {
                MessageBox.Show("Naruszone zostały zasady licencji.\r\n Program nie może zostać uruchomiony");
                f1.Enabled = false;
            }
        }

      private bool licenceCheck()
        {
            DateTime d1;
            if (SetupFunc.registCheck())
           
            {
                cf = (registration)progSetup.SerialD.DeSerialize("prSetup.xml", new registration());
                if (String.IsNullOrEmpty( cf.ds ))
                {
                    rejestracja();

                }
                else
                    if (!cf.isRegistered)
                    {
                        try
                        {
                            d1 = new DateTime(Convert.ToInt64(Authent.Cryptofunc.decrypt(cf.ds)));
                            if (DateTime.Now > d1.AddDays(FreeDays2))
                            {
                           
                                MessageBox.Show("Program nie został w terminie zarejestrowany. \r\n Proszę zarejestrować program");
                                rejestracja();
                                if (DateTime.Now > d1.AddDays(FreeDays))
                                    return false;
                                else
                                    return true;
                            }
                            else
                                return true;
                         
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(("Proszę zainstalować program powtórnie"));
                            rejestracja();
                            return false;
                        }
                    }
                    else
                    {
                        progRegisterd = true;
                        //if ((int)DateTime.Today.DayOfWeek == 3)
                        //{
                        //   Process licenTest = new Process();
                        // licenTest.StartInfo.FileName = @"D:\Projects\project7\rcpracy\studio8\gratCon\registerServ\bin\Debug\progReg.exe";
                        //   licenTest.Start();
                        //}
                    }
                        
            }
            else
                rejestracja();
            return true;
        }

      public static void rejestracja()
      {

          SetupFunc.usingProgramStart();
          Process rejestracja = new Process();
          //rejestracja.StartInfo.FileName = @"D:\Projects\project7\rcpracy\studio8\gratCon\ProgSetup\bin\Debug\ProgSetup.exe";
          rejestracja.StartInfo.FileName = @"ProgSetup.exe";
          rejestracja.Start();
          rejestracja.WaitForExit();
      }        
        
    }
}

