using System.Text;

namespace _02_AdvancedMapping.DTOs
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string ManagerLastName { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.FirstName} {this.LastName} {this.Salary:f2} - Manager: ");
            if (this.ManagerLastName == null)
            {
                sb.Append("[no manager]");
            }
            else
            {
                sb.Append($"{this.ManagerLastName}");
            }
            return sb.ToString();
        }
    }
}