using System;
using System.Linq;
using testing1;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new SoftUniContext())
        {
            var departments = context.Departments.Where(x => x.Employees.Count > 5).OrderBy(x => x.Employees.Count);
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} {context.Employees.FirstOrDefault(x => x.EmployeeID == department.ManagerID).FirstName}");
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
                }
            }
        }
    }
}