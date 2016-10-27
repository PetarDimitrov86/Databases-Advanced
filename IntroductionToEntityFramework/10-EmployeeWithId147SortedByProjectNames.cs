using System;
using System.Linq;
using testing1;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new SoftUniContext())
        {
            var employee = context.Employees.Find(147);
            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            foreach (var project in employee.Projects.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{project.Name}");
            }
        }
    }
}