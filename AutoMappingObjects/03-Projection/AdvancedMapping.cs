namespace _02_AdvancedMapping
{
    using AutoMapper;
    using DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class AdvancedMapping
    {
        static void Main()
        {
            EmployeeContext context = new EmployeeContext();
            context.Database.Initialize(true);
            ConfigureMapping();

            Employee firstEmployee = new Employee
            {
                FirstName = "Petar",
                LastName = "Dimitrov",
                Salary = 2152,
                Address = "Vassil Aprilov 17",
                Birthday = DateTime.Now,
                OnHoliday = false
            };

            Employee secondEmployee = new Employee
            {
                FirstName = "Nikolai",
                LastName = "Petkov",
                Salary = 6141,
                Address = "Bitolq 1",
                Birthday = DateTime.Now,
                OnHoliday = true
            };

            Employee thirdEmployee = new Employee
            {
                FirstName = "Lidinka",
                LastName = "Plamenova",
                Salary = 113322,
                Address = "Raiko Aleksiev 34",
                Birthday = DateTime.Now,
                OnHoliday = true
            };

            Employee fourthEmployee = new Employee
            {
                FirstName = "Aleksandar",
                LastName = "Krystev",
                Salary = 151512,
                Address = "Manastirski Livadi",
                Birthday = DateTime.Now,
                OnHoliday = false,
                Manager = thirdEmployee
            };

            Employee fifthEmployee = new Employee
            {
                FirstName = "Georgi",
                LastName = "Gospodinov",
                Salary = 65124,
                Address = "Opylchenska",
                Birthday = DateTime.Now,
                OnHoliday = false,
                Manager = firstEmployee
            };
            
            List<Employee> emps = new List<Employee> { firstEmployee, secondEmployee, thirdEmployee, fourthEmployee, fifthEmployee};

            context.Employees.AddRange(emps);
            context.SaveChanges();

            var employees = context.Employees
                .Where(emp => emp.Birthday < DateTime.Now)
                .OrderBy(emp => emp.Salary)
                .ProjectTo<EmployeeDto>();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        private static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>().ForMember(dto => dto.ManagerLastName, cfgExpr => cfgExpr.MapFrom(emp => emp.Manager.LastName));
                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(dto => dto.Employees,
                        configurationExpression => configurationExpression.MapFrom(manager => manager.Employees))
                    .ForMember(dto => dto.Count, cfgExpr => cfgExpr.MapFrom(man => man.Employees.Count))
                    ;
            });
        }
    }
}