using System;

namespace progSetup
{
    public static class SetupFunc
    {

        public static short ordProgram = 7;
        public static byte ordProgVer = 5;

        public static bool registCheck()
        {
            if (!System.IO.File.Exists("prSetup.xml"))
            {
                SerialData.showMessage = false;
                SetupFunc.usingProgramStart();               
                return false;
            }
            return true;
        }


        public static void usingProgramStart()
        {

            progSetup.programSetup.Instance.ini();
            progSetup.programSetup.register.isRegistered = false;
            progSetup.programSetup.register.zam = false;
            progSetup.programSetup.register.ds = Authent.Cryptofunc.encrypt(DateTime.Now.Ticks.ToString());
            progSetup.programSetup.Instance.Serialize();
        }

       

    }
}
