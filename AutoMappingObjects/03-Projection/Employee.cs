using System;
using System.Collections.Generic;
using System.Text;

namespace _02_AdvancedMapping
{
    public class Employee
    {
        public Employee()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public decimal Salary { get; set; }

        public bool OnHoliday { get; set; }

        public string Address { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}