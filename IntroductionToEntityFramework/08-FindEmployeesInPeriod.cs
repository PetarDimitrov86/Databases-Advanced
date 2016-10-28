using _01_ImportTheSoftuniDatabase;
using System;
using System.Linq;
using System.Globalization;
public class EmployeesFullInformation
{
    static void Main(string[] args)
    {
        using (var context = new SoftuniContext())
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InstalledUICulture;
            var employees = context.Employees.Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0).Take(30);
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine($"--{project.Name} {project.StartDate} {project.EndDate}");
                }
            }           
        }
    }
}