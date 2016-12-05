namespace _02_AdvancedMapping
{
    using AutoMapper;
    using DTOs;
    using System;
    using System.Collections.Generic;

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
                OnHoliday = false
            };

            Employee fifthEmployee = new Employee
            {
                FirstName = "Georgi",
                LastName = "Gospodinov",
                Salary = 65124,
                Address = "Opylchenska",
                Birthday = DateTime.Now,
                OnHoliday = false
            };

            secondEmployee.Employees.Add(fifthEmployee);
            secondEmployee.Employees.Add(thirdEmployee);
            secondEmployee.Employees.Add(fourthEmployee);
            secondEmployee.Employees.Add(firstEmployee);

            thirdEmployee.Employees.Add(fifthEmployee);
            thirdEmployee.Employees.Add(firstEmployee);

            firstEmployee.Employees.Add(fourthEmployee);
            firstEmployee.Employees.Add(secondEmployee);

            fifthEmployee.Employees.Add(firstEmployee);
            fifthEmployee.Employees.Add(secondEmployee);
            
            List<Employee> emps = new List<Employee> { firstEmployee, secondEmployee, thirdEmployee, fourthEmployee, fifthEmployee};

            //context.Employees.AddRange(emps);
            //context.SaveChanges();

            var managerDtos = Mapper.Map<IEnumerable<ManagerDto>>(emps);

            foreach (var manager in managerDtos)
            {
                Console.WriteLine($"{manager.FirstName} {manager.LastName} | Employees : {manager.Count}");
                var employeesInCommandDtos = Mapper.Map<IEnumerable<EmployeeDto>>(manager.Employees);
                foreach (var employee in employeesInCommandDtos)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Salary}");
                }
            }
        }

        private static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(dto => dto.Employees,
                        configurationExpression => configurationExpression.MapFrom(manager => manager.Employees))
                    .ForMember(dto => dto.Count, cfgExpr => cfgExpr.MapFrom(man => man.Employees.Count));
            });
        }
    }
}