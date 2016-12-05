using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AdvancedMapping
{
    public class ManagerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeesCount { get; set; }
        public IList<EmployeeDto> Employees { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{FirstName} {LastName} | Employees: { EmployeesCount}");
            foreach (var employee in this.Employees)
            {
                result.AppendLine(employee.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
