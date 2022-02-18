using System;

namespace progSetup
{
    public class programSetup : SerialData
    {
         private static programSetup m_oInstance = null;
         public static registration register;

         public programSetup()
        {
            register = (registration)init(new registration { isRegistered = false, zam =false }, "prSetup.xml");
        }

         public static programSetup Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new programSetup();
                }
                return m_oInstance;
            }
        }        
    }


    [Serializable]
    public class registration
    {
        public string ds;
        public DateTime? dataZam;
        public bool zam;
        public DateTime? dataRej;
        public bool isRegistered;
        public string nip;
        public int registerId;
        public string licenceNr;
    }

}
