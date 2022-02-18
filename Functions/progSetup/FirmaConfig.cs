using System;

namespace progSetup
{
    public class FirmaConfig : progSetup.SerialData
    {
        private static FirmaConfig m_oInstance = null;
        public static Firma configF;
        public FirmaConfig()
        {
            configF = (Firma)init(new Firma {isRegistered = false, idfi=0 }, "firma.xml");
        }

        public static FirmaConfig Instance
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new FirmaConfig();
                }
                return m_oInstance;
            }
        }        
    }


    [Serializable]
    public class Firma
    {
        public int idfi;
        public string nazwa;
        public string miejsc;
        public string adres;
        public string kodpoczt;
        public string nip;
        public string telefon;
        public string email;
        public bool isRegistered;
    }

}


///// <summary> Generic singleton with double check pattern and with instance parameter </summary>
///// <typeparam name="T"></typeparam>
//public class SingleObject<T> where T : class, new()
//{
//    /// <summary> Lock object </summary>
//    private static readonly object _lockingObject = new object();

//    /// <summary> Instance </summary>
//    private static T _singleObject;

//    /// <summary> Protected ctor </summary>
//    protected SingleObject()
//    {
//    }

//    /// <summary> Instance with parameter </summary>
//    /// <param name="param">Parameters</param>
//    /// <returns>Instance</returns>
//    public static T Instance(params dynamic[] param)
//    {
//        if (_singleObject == null)
//        {
//            lock (_lockingObject)
//            {
//                if (_singleObject == null)
//                {
//                    _singleObject = (T)Activator.CreateInstance(typeof(T), param);
//                }
//            }
//        }
//        return _singleObject;
//    }
//}