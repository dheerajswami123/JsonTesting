using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialiseSample
{
    public class Employee
    {
        public int EmpId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }
        public int Serviceyear { get; set; }
        public string Address { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Email { get; set; }
    }
}
