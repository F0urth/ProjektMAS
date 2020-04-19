using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektMAS.ProjectCore.Abstraction
{
    public abstract class Person
    {
        private Guid Identity { get; }
        private string Name { get; }
        private string LastName { get; }
        private string PhoneNumber { get; }
        private string Email { get; }
        public Person(Guid guid, string name, string lastName, string phoneNumber, string email) =>
            (Identity, Name, LastName, PhoneNumber, Email) = (guid, name, lastName, phoneNumber, email);

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("{\n")
                .Append("\tId: ").Append(Identity.ToString()).Append("\n")
                .Append("\tName: ").Append(Name).Append("\n")
                .Append("\tLastName: ").Append(LastName).Append("\n")
                .Append("\tPhoneNumber: ").Append(PhoneNumber).Append("\n")
                .Append("\tEmail: ").Append(Email).Append("\n")
                .Append("}");

            return builder.ToString();
        }
    }

    
}
