using System;
using System.IO;

namespace rcpracy
{  
    public class Configuration : progSetup.SerialData
    {  // singleton
        private static Configuration m_oInstance = null;
      
        public static ConfData confData;

        public static Configuration Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new Configuration();
                }
                return m_oInstance;
            }
        }

        private Configuration()
        {
            confData = (ConfData)init(new ConfData { nocStart = 22, nocEnd = 6, toler = 30, maxGodz = 12, impSepa = ";", impWe = "0" }, "config.xml");
        }
    }  
        [Serializable]
        public class ConfData
        {
            public int nocStart;
            public int nocEnd;
            public int toler;
            public int normaDzienna;
            public int maxGodz;
            public bool zaokrTPZ;
            //public int normaNocna;
            public int przerwaWpracy;
            public bool rejestratorW;
            public bool rejestratorZewn;
            public string rejAdres;
            //public bool ignorujNormyGratyf;
            //public bool local;
            public bool remote;
            public bool zaokrNadliczb;
            public bool impPracUmowa;
            public bool impPracCywPraw;
            //public bool exp2GratDateOnly;   // eksport do gratyfikanta godz min początku i końca pracy  (jeśli false to data i godz)
            public string impSepa;
            public string impWe;
            public bool limPoczPracy;
        }      
    }


