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
                                   .Where(e => e.Department.Name == "Engineering" 
                                    || e.Department.Name == "Tool Design" 
                                    || e.Department.Name == "Marketing" 
                                    || e.Department.Name == "Information Services");
            
            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 12 / 100;

                Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f6})");
            }
            //context.SaveChanges();
        }
    }
}