namespace _03.Projection
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ProjectionExample
    {
        static void Main()
        {

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.LastName)));

            IEnumerable<Employee> employeesToAdd = CreateManagers();

            var context = new EmployeeContext();
            context.Employees.AddRange(employeesToAdd);
            context.SaveChanges();
            var employees = context.Employees;

            var employeesOldernThan30 = employees
                .Where(e => e.Birthday.Year < 1990)
                .OrderByDescending(e => e.Salary)
                .ProjectTo<EmployeeDto>();

            foreach (EmployeeDto employeeDto in employeesOldernThan30)
            {
                Console.WriteLine(employeeDto);
            }
        }

        private static IEnumerable<Employee> CreateManagers()
        {
            var managers = new List<Employee>();
            for (int i = 0; i < 3; i++)
            {
                var manager = new Employee()
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Address = "Sofia, Tintyava 10",
                    Birthday = new DateTime(1992, 3, 2),
                    Salary = 100m
                };
                var employee1 = new Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Salary = 120.20m,
                    Birthday = new DateTime(1980, 3, 2),
                    Manager = manager
                };
                var employee2 = new Employee()
                {
                    FirstName = "Johny",
                    LastName = "Doing",
                    Salary = 120.22m,
                    Birthday = new DateTime(1982, 3, 2),
                    Manager = manager
                };
                var employee3 = new Employee()
                {
                    FirstName = "Johnnie",
                    LastName = "Doable",
                    Salary = 120.23m,
                    Birthday = new DateTime(1989, 3, 2),
                    Manager = manager
                };
                managers.Add(employee1);
                managers.Add(employee2);
                managers.Add(employee3);
                managers.Add(manager);
            }

            return managers;
        }
    }
}
