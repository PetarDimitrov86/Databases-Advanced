using System.Collections.Generic;

namespace _02_AdvancedMapping.DTOs
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Employees = new List<Employee>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Employee> Employees { get; set; }

        public int Count { get; set; }
    }
}