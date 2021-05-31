using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class DataSerializer<T> : List<T>
    {
        public void XmlSerialize(T data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                xmlSerializer.Serialize(streamWriter, data);
                streamWriter.Close();
            }
        }

        public T XmlDeserialize(string filePath)
        {
            object obj = null;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            return (T)obj;
        }
    }
}