using System;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class DataSerializer
    {
        public void XmlSerialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                xmlSerializer.Serialize(streamWriter, data);
                streamWriter.Close();
            }
        }

        public object XmlDeserialize(Type dataType, string filePath)
        {
            object obj = null;

            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            return obj;
        }
    }
}