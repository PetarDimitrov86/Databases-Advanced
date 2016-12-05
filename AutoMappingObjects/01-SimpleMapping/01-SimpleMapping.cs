namespace _01_SimpleMapping
{
    using System;
    using AutoMapper;

    public class SimpleMapping
    {
        static void Main()
        {
            EmployeeContext context = new EmployeeContext();
            ConfigureMapping();

            Employee employee = new Employee
            {
                FirstName = "Petar",
                LastName = "Dimitrov",
                Birthday = DateTime.Now,
                Salary = 00000.1m
            };

            EmployeeDto emplDto = Mapper.Map<EmployeeDto>(employee);

            Console.WriteLine($"{emplDto.FirstName} {emplDto.LastName} receives ${emplDto.Salary} monthly salary.");

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        private static void ConfigureMapping()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
        }
    }
}