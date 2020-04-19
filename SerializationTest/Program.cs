using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"./testFile.json";
            var path2 = @"./testFile2.dat";
            var list = new List<TestToSerialize>();

            var obj = new TestToSerialize(10, "hahaha");
            var obj2 = new TestToSerialize(11, "hahahaNope");
            list.Add(obj);
            list.Add(obj2);
            
            File.WriteAllText(path, JsonConvert.SerializeObject(list));
            var it = new FileStream(path, FileMode.Create);
            var objDes = JsonConvert.DeserializeObject<List<TestToSerialize>>(File.ReadAllText(path));

            
            new StreamWriter(it).Write("asdsad");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Att1: [Before: {list[i].Attribute1}, Affter: {objDes[i].Attribute1}], " +
                $"Att2: [Before: {list[i].Attribute2}, Affter: {objDes[i].Attribute2}]");
            }

            SerializeData(path2, list);

            foreach (var ele in DeSerializeData(path2))
            {
                Console.WriteLine($"Attribute1: {ele.Attribute1}, Attribute2: {ele.Attribute2} ");
            }
        }


        static void SerializeData(string path, List<TestToSerialize> data)
        {
            FileStream fs = new FileStream(path, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                
                formatter.Serialize(fs, data);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Error couse by: " + ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static List<TestToSerialize> DeSerializeData(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                return (List<TestToSerialize>) formatter.Deserialize(fs);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Error couse by: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
    }

    
    class TestToSerialize
    {
        public int Attribute1 { get; set; }
        public string Attribute2 { get; set; }

        public TestToSerialize(int attribute1, string attribute2)
        {
            Attribute1 = attribute1;
            Attribute2 = attribute2;
        }
    }
}
