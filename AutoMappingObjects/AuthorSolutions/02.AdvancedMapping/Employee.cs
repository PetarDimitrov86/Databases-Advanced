using System;
using System.Collections.Generic;

namespace _02.AdvancedMapping
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsOnHoliday { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public Employee Manager { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
