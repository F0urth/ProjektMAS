using System;
using System.IO;
using static MP_01.Employee;

namespace MP_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"./Saver.json";
           

            for (int i = 0; i < 10; i++)
            {
                var last = $"LastName{i}";
                new Employee(Guid.NewGuid(), last, i.ToString("000000000"), $"{last}@example.com",
                    new Adress($"place{i}", $"house{i}", i.ToString("00-000")), 1000 * (i + 1), $"FirstName{i}", $"SecName{i}");
            }

            
            var writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate));

            ExtenstionContainer.Serialized(writer);
            // ----------
            var reader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate));
            ExtenstionContainer.DeSerialized(reader);
            ExtenstionContainer.PrintExtenction();

            reader.Close();
            writer.Close();   
        }
    }
}
