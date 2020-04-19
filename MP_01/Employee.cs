using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace MP_01
{
    
    public class Employee : Person
    {
        

        private static double _additonalPercent = 1.0;
        public static double AdditionalPercent 
        {
            get => _additonalPercent;
            set 
            { 
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value of 'AdditioanPercent' can not be less then 0");
                }
                _additonalPercent = value;
            } 
        }

        private const double _vatRate = 1.23;

        private double _priceNetto;

        public double Salary 
        { 
            get => _priceNetto + (_priceNetto * AdditionalPercent); 
            set => _priceNetto = value / _vatRate;
        }



        public Employee(Guid guid, string lastName, string phoneNumber, string email, Adress? adress, double salaryGross, params string[] names) 
            : base(guid, lastName, phoneNumber, email, adress, names)
        {

            ExtenstionContainer.AddEmployee(this);
            Salary = salaryGross;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            var type = this.GetType();
            {
                builder.Append("Fields: [");
                System.Reflection.FieldInfo[] array = type.GetFields();
                for (int i = 0; i < array.Length; i++)
                {
                    System.Reflection.FieldInfo item = array[i];
                    builder.Append(item.GetValue(this));
                    if (i < array.Length - 1)
                    {
                        builder.Append(", ");
                    }
                }
                builder.Append("] ");
            }
            {
                builder.Append("Properties: [");
                System.Reflection.PropertyInfo[] array = type.GetProperties();
                for (int i = 0; i < array.Length; i++)
                {
                    System.Reflection.PropertyInfo item = array[i];
                    builder.Append(item.GetValue(this));
                    if (i < array.Length - 1)
                    {
                        builder.Append(", ");
                    }
                }
                builder.Append("]");
            }
            return builder.ToString() + base.ToString();
        }

        public static class ExtenstionContainer
        {
            private static List<Employee> Extenstion { get; }

            internal static void AddEmployee(Employee employee)
            {
                if (!Extenstion.Select(e => e.Identity).Where(e => e == employee.Identity).Any())
                {
                    Extenstion.Add(employee);
                }
                else
                {
                    throw new ArgumentException("Element already in collection");
                }
            }

            public static IEnumerable<Employee> GetEmployees => ImmutableList
                    .CreateRange(Extenstion);

            public static bool RemoveEmployee(Employee employee) => Extenstion
                    .Remove(employee);


            public static bool Serialized(StreamWriter writer)
            {
                try
                {
                    using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jsonWriter, Extenstion);
                        jsonWriter.Flush();
                    }

                    writer.Write(JsonConvert.SerializeObject(Extenstion));
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public static void DeSerialized(StreamReader reader)
            {
                using (JsonTextReader jsonReader = new JsonTextReader(reader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<Employee> fromFile = serializer.Deserialize<List<Employee>>(jsonReader);
                    Extenstion.Clear();
                    Extenstion.AddRange(fromFile);
                }
            }
            static ExtenstionContainer()
            {
                Extenstion = new List<Employee>();
            }

            public static void PrintExtenction()
            {
                foreach (var item in Extenstion)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
