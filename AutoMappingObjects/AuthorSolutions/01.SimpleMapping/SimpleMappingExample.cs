using AutoMapper;
using System;
namespace _01.SimpleMapping
{
    class SimpleMappingExample
    {
        static void Main()
        {
            var employee = new Employee()
            {
                FirstName = "Harry",
                LastName = "Potter",
                Birthday = new DateTime(1990, 7, 31),
                Salary = 900.99m,
                Address = "4 Privet Drive, Little Whinging, Surrey"
            };

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
            var employeeDto = Mapper.Map<Employee, EmployeeDto>(employee);
            Console.WriteLine($"{employeeDto.FirstName} {employeeDto.LastName} {employeeDto.Salary}");
        }
    }
}
