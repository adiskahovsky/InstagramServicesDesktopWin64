using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServicesDesktopWin64
{
    public static class Serializer
    {
        public static void Serialize<T>(IList<T> list, string fileName)
        {
            using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                foreach (var user in list)
                {
                    formatter.Serialize(file, user);
                }
            }
        }

        public static IList<T> Deserialize<T>(string fileName) where T : new()
        {
            T res = new T();
            List<T> lres = new List<T>();
            using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (file.CanRead)
                    try
                    {
                        lres.Add((T)formatter.Deserialize(file));
                    }
                    catch (Exception)
                    { break; }
            }
            return lres;
        }
    }
}
