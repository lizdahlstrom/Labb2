using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Uppgift1
{
    static class FileOperations
    {
        public static void Serialize(object objectToSerialize, string fileName)
        {
            try
            {
                var formatter = new BinaryFormatter();

                using (Stream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                { formatter.Serialize(fStream, objectToSerialize); }
            }
            catch (SerializationException e)
            {
                Console.WriteLine(@"Failed to serialize");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static object Deserialize(string fileName)
        {
            try
            {
                var formatter = new BinaryFormatter();

                using (Stream fStream = File.OpenRead(fileName))
                { return formatter.Deserialize(fStream); }

            }
            catch (SerializationException e)
            {
                Console.WriteLine(@"Failed to deserialize");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
