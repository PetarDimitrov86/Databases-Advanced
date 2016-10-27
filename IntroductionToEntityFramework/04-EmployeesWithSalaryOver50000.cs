using _01_ImportTheSoftuniDatabase;
using System;
using System.Linq;
public class EmployeesFullInformation
{
    static void Main(string[] args)
    {
        using (var context = new SoftuniContext())
        {
            var employees = context.Employees.Where(e => e.Salary > 50000);
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName}");
            }
        }
    }
}