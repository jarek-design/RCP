using System;
using System.IO;

namespace progSetup
{
    public class SerialData 
    {
        Object confData;
        string xmlFileName;
        Type T;
        public static bool showMessage;
        public SerialData()
        {
           
        }

        public SerialData(Object confData, string xmlFileName)
        {
            this.confData = confData;
            this.T = confData.GetType();
            this.xmlFileName = xmlFileName;
            showMessage = false;
        }

        protected Object init(Object confData, string xmlFileName)
        {
            this.confData =  confData;            
            this.T = confData.GetType();
            this.xmlFileName = xmlFileName;

            if (File.Exists(xmlFileName))
            {
                confData = null;
                DeSerialize();
                return this.confData;
            }
            else
            {
                errorInfo();
                Serialize();
                return this.confData;
            }
        }
        public void ini()
        {
        }


        /// <summary>
        /// zapisuje do zbioru xml
        /// </summary>
        public void Serialize()
        {
            //System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, confData);
            //stream.Close();
            // to samo tylko xml

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(T);
            TextWriter tw = new StreamWriter(xmlFileName);
            serializer.Serialize(tw, confData);
            tw.Close();
        }
        /// <summary>
        /// Czyta ze zbioru xml
        /// </summary>
        private void DeSerialize()
        {

            //System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            //confData = (ConfData)formatter.Deserialize(stream);
            //stream.Close();
            
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(T);
            TextReader tr = new StreamReader(xmlFileName);

            confData = serializer.Deserialize(tr);
            tr.Close();
     
        }
        public Object getData()
        {
            if (File.Exists(xmlFileName))
            {
                DeSerialize();
                return this.confData;
            }
            else
                return null;
        }
        private void errorInfo()
        {
            if(showMessage)
                System.Windows.Forms.MessageBox.Show("Dane konfiguracyjne  nie zostały odczytane prawidłowo. \r\n Proszę skonfigurować parametry");
        }
       
        
    }

    public static class SerialD
    {
        public static Object DeSerialize(string xmlFileName, Object confData)
        {
            if (!File.Exists(xmlFileName))
                return null;
            
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(confData.GetType());
            TextReader tr = new StreamReader(xmlFileName);

            confData = serializer.Deserialize(tr);
            tr.Close();
            return confData;
        }
    }

  
    
}
