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

            var employeesProjectsToRemove = project.Employees.Where(e => e.Projects == project);
            foreach (var employeeProject in employeesProjectsToRemove)
            {
                employeeProject.Projects.Remove(project);
            }

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