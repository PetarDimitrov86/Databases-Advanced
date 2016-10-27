using _01_ImportTheSoftuniDatabase;
using System;
using System.Linq;
public class EmployeesFullInformation
{
    static void Main(string[] args)
    {
        using (var context = new SoftuniContext())
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Research and Development").OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }
        }
    }
}