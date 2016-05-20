using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Playstation_Friends_List
{
    public class Serialization
    {
        private static string fullPath = (Application.StartupPath + @"\Settings");

        private static void CheckFolderExists()
        {
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
        }

        public static void Delete(string filename)
        {
            CheckFolderExists();
            filename = fullPath + @"\" + filename + ".xml";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        public static object Load(string filename, Type saveType)
        {
            object obj3 = null;
            CheckFolderExists();
            filename = fullPath + @"\" + filename + ".xml";
            if (!File.Exists(filename))
            {
                return null;
            }
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Open);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                stream.Dispose();
                stream = null;
                MemoryStream stream2 = new MemoryStream(buffer);
                object obj2 = new XmlSerializer(saveType).Deserialize(stream2);
                stream2.Close();
                stream2.Dispose();
                obj3 = obj2;
            }
            catch
            {
            }
            return obj3;
        }

        public static List<string> LoadList(string filename)
        {
            List<string> list = null;
            CheckFolderExists();
            if (!File.Exists(filename))
            {
                return null;
            }
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Open);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                stream.Dispose();
                stream = null;
                MemoryStream stream2 = new MemoryStream(buffer);
                object obj2 = new XmlSerializer(typeof(List<string>)).Deserialize(stream2);
                stream2.Close();
                stream2.Dispose();
                list = (List<string>)obj2;
            }
            catch
            {
            }
            return list;
        }

        public static void Save(string filename, Type saveType, object objSave)
        {
            CheckFolderExists();
            filename = fullPath + @"\" + filename + ".xml";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            try
            {
                FileStream stream = new FileStream(filename, FileMode.CreateNew);
                new XmlSerializer(saveType).Serialize((Stream)stream, objSave);
                stream.Flush();
                stream.Close();
                stream.Dispose();
                stream = null;
            }
            catch
            {
            }
        }

        private void SaveList(string Location, List<string> lst)
        {
            CheckFolderExists();
            if (lst != null)
            {
                if (File.Exists(Location))
                {
                    File.Delete(Location);
                }
                try
                {
                    FileStream stream = new FileStream(Location, FileMode.Create);
                    new XmlSerializer(typeof(List<string>)).Serialize((Stream)stream, lst);
                    stream.Close();
                    stream.Dispose();
                }
                catch
                {
                }
            }
        }
    }
}
