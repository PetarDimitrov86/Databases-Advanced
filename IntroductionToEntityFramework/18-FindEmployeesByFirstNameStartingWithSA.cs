using System;
using System.Linq;
using testing1;

class IncreaseSalaries
{
    static void Main(string[] args)
    {
        using (var context = new SoftUniContext())
        {
            var employees = context.Employees
                                   .Where(e => e.FirstName.StartsWith("Sa"));
            
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
            }
            //context.SaveChanges();
        }
    }
}