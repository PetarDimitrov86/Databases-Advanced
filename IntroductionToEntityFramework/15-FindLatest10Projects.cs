using System;
using System.Globalization;
using System.Linq;
using testing1;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new SoftUniContext())
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InstalledUICulture;
            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10);
            foreach (var project in projects.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
            }
        }
    }
}