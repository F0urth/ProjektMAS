using System;
using System.IO;
using System.Linq;
using static MP_01.Employee;

namespace MP_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"./Trwalosc";
           

            for (int i = 0; i < 10; i++)
            {
                var last = $"LastName{i}";
                new Employee(Guid.NewGuid(), last, i.ToString("000000000"), $"{last}@example.com",
                    new Adress($"place{i}", $"house{i}", i.ToString("00-000")) /*null*/, 1000 * (i + 1), $"FirstName{i}", $"SecName{i}");
            }
            var emps = ExtenstionContainer.GetEmployees;
            
            var writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate));

            ExtenstionContainer.Serialized(writer);
            // ----------
            var reader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate));
            ExtenstionContainer.DeSerialized(reader);
            ExtenstionContainer.PrintExtenction();

            var emps2 = ExtenstionContainer.GetEmployees;

            foreach (var ele in emps)
            {
                var ins = emps2.Where(e => e == ele).First();
                Console.WriteLine(ele.Identity);
                Console.WriteLine(ins.Identity);
                Console.WriteLine(ele.Adress);
                Console.WriteLine(ins.Adress);
                Console.WriteLine(ele.Email);
                Console.WriteLine(ins.Email);
                Console.WriteLine(ele.LastName);
                Console.WriteLine(ins.LastName);
                Console.WriteLine(ele.Names[0]);
                Console.WriteLine(ins.Names[0]);
                Console.WriteLine(ele.PhoneNumber);
                Console.WriteLine(ins.PhoneNumber);
                Console.WriteLine(ele.Salary);
                Console.WriteLine(ins.Salary);
                Console.WriteLine(emps2.Contains(ele));
                Console.WriteLine(emps.Where(e => e == ele).Any());
            }

            reader.Close();
            writer.Close();   
        }
    }
}
