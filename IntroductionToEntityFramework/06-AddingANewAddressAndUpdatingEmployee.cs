using _01_ImportTheSoftuniDatabase;
using System;
using System.Linq;
public class EmployeesFullInformation
{
    static void Main(string[] args)
    {
        using (var context = new SoftuniContext())
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            Employee employee = null;
            employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;
            
            //context.Employees.FirstOrDefault(e => e.LastName == "Nakov").Address = address;

            context.SaveChanges();
            var employees = context.Employees.OrderByDescending(e => e.AddressID).Take(10);
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Address.N}");
            }
        }
    }
}
