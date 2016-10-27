using _01_ImportTheSoftuniDatabase;
using System;
using System.Linq;
public class EmployeesFullInformation
{
    static void Main(string[] args)
    {
        using (var context = new SoftuniContext())
        {
            var project = context.Projects.Find(2);

            var employeesToRemove = project.Employees.Where(e => e.Projects == project);
            var employees = context.Employees;
            employees.RemoveRange(employeesToRemove);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Take(10);
            foreach (var proj in projects)
            {
                Console.WriteLine($"{proj.Name}");
            }
        }
    }
}