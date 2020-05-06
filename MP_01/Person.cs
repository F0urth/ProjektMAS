using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MP_01
{
    public abstract class Person
    {

        // atrybut powtarzalny streamwriter do trwałości
        public Guid Identity { get; set; }
        public string[] Names { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Adress? Adress { get; set; }

        public Person(Guid guid, string lastName, string phoneNumber, string email, Adress? adress, params string[] names) =>
            (Identity, Names, LastName, PhoneNumber, Email, Adress) = (guid, names, lastName, phoneNumber, email, adress);

        public static bool operator ==(Person p1, Person p2) => p1.Identity == p2.Identity;
        public static bool operator !=(Person p1, Person p2) => p1.Identity != p2.Identity;

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("{\n")
                .Append("\tId: ").Append(Identity.ToString()).Append("\n");
            builder.Append("\tName: [");
            for (int i = 0; i < Names.Length; i++)
            {
                builder.Append(Names[i]);
                if (i < Names.Length - 1)
                {
                    builder.Append(", ");
                }
            }
            builder.Append("]\n");
            builder.Append("\tLastName: ").Append(LastName).Append("\n")
                .Append("\tPhoneNumber: ").Append(PhoneNumber).Append("\n")
                .Append("\tEmail: ").Append(Email).Append("\n")
                .Append("\tAdress: ").Append("[").Append(Adress?.HouseNumber)
                .Append(" ").Append(Adress?.Place).Append(" ")
                .Append(Adress?.ZipCode).Append("]")
                .Append("}");

            return builder.ToString();
        }
    }
    
    public struct Adress
    {
        
        public string Place { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }


        public Adress(string place, string houseNumber, string zipCode) =>
            (Place, HouseNumber, ZipCode) = (place, houseNumber, zipCode);

        public override string ToString()
        {
            return Place + " " + HouseNumber + " " + ZipCode;
        }
    }
}
