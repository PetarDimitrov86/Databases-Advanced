using System;
using System.Linq;
using testing1;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new SoftUniContext())
        {
            var addresses = context.Addresses.OrderByDescending(x => x.Employees.Count)
                .ThenBy(e => e.Town.Name)
                .Take(10);
            foreach (var address in addresses)
            {
                Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            }
        }
    }
}