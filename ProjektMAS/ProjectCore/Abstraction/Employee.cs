using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace ProjektMAS.ProjectCore.Abstraction
{
    public abstract class Employee : Person
    {

        private static List<Employee> Extenction { get; }

        public static IEnumerable<Employee> GetAllEmployees()
        {
            return ImmutableList
                .CreateRange(Extenction);
        }

        public static bool RemoveEmployee(Employee employee)
        {
            return Extenction
                .Remove(employee);
        }

        public Employee this[int index]
        {
            get => Extenction[index];
        }

        static Employee()
        {
            Extenction = new List<Employee>();
        }

        public int Expirience { get; }

        public Employee(Guid guid, string name, string lastName, string phoneNumber, string email, int expirience) 
            : base(guid, name, lastName, phoneNumber, email)
        {
            Expirience = expirience;
            Extenction.Add(this);
        }




        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("<Employee>\n");
            foreach (var property in GetType().GetProperties())
            {
                builder.Append("<").Append(property.Name).Append(">").Append(property.GetValue(this)).Append("<").Append(property.Name).Append("/>\n");
            }
            builder.Append("<Employee/>\n");

            return base.ToString();
        }
    }
}
