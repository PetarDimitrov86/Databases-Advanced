using _01_ImportTheSoftuniDatabase;
using System;
public class EmployeesFullInformation
{
    static void Main(string[] args)
    {
        using (var context = new SoftuniContext())
        {
            var employees = context.Employees;
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            }
        }
    }
}