using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AdvancedMapping
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"    - {FirstName} {LastName} {Salary}";
        }
    }
}
