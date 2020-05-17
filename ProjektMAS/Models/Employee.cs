using System;
using System.Collections.Generic;
using System.Text;


/*
 *
 * @author F0urth
 *
 * @date - 5/13/2020 1:09:08 AM
 *
 */

namespace ProjektMAS.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public double Expirience { get; set; }

    }
}
