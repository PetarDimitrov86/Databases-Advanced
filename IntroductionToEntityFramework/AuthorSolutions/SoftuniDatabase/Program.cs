namespace SoftuniDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using SoftuniDatabase.Models;

    class Program
    {
        static void Main()
        {
            var context = new SoftuniContext();
            StringBuilder content = new StringBuilder();

            #region //Employees full information         
            //IEnumerable<Employee> employees = context.Employees;
            //foreach (Employee employee in employees)
            //{
            //    content.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            //}
            #endregion

            #region //Employees with Salary Over 50 000
            //var employeesNames = context.Employees
            //                            .Where(x => x.Salary > 50000)
            //                            .Select(em => em.FirstName);
            //
            //foreach (string employeeName in employeesNames)
            //{
            //    content.AppendLine(employeeName);
            //}
            #endregion

            #region//Employees from Seattle                
            //var employees =
            //    context.Employees
            //        .Where(employee => employee.Department.Name == "Research and Development")
            //        .OrderBy(employee => employee.Salary)
            //        .ThenByDescending(employee => employee.FirstName);
            //
            //foreach (var employee in employees)
            //{
            //    content.AppendLine($"{employee.FirstName} {employee.LastName} " +
            //                      $"from {employee.Department.Name} - ${employee.Salary:F2}");
            //}
            #endregion

            #region//Adding a New Address and Updating Employee  
            //var address = new Address() { AddressText = "Vitoshka 15", TownID = 4 };
            //var nakovEmployee = context.Employees.First(employee => employee.LastName == "Nakov");
            //nakovEmployee.Address = address;
            //
            //context.SaveChanges();
            //
            //var employeeAddresses = context.Employees
            //    .OrderByDescending(employee => employee.Address.AddressID)
            //    .Take(10)
            //    .Select(employee => employee.Address.AddressText);
            //
            //foreach (string employeeAddress in employeeAddresses)
            //{
            //    content.AppendLine(employeeAddress);
            //}
            #endregion

            #region//Delete Project by Id   
            //var project = context.Projects.Find(2);
            //var employees = project.Employees;
            //foreach (Employee employee in employees)
            //{
            //    employee.Projects.Remove(project);
            //}
            //context.SaveChanges();
            //
            //context.Projects.Remove(project);
            //context.SaveChanges();
            //
            //var projects = context.Projects.Take(10).Select(project1 => project1.Name);
            //foreach (string proj in projects)
            //{
            //    content.AppendLine(proj);
            //}
            #endregion

            #region//Find employees in period        

            //var employees = context.Employees
            //    .Where(employee => employee.Projects
            //        .Count(project => project.StartDate.Year >= 2001 && project.StartDate.Year <= 2003) > 0).Take(30);
            //
            //foreach (var employee in employees)
            //{
            //    content.AppendLine($"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");
            //    foreach (Project project in employee.Projects)
            //    {
            //        content.AppendLine($"--{project.Name} {project.StartDate} {project.EndDate}");
            //    }
            //}
            #endregion

            #region //Addresses by town name 
            //var addresses =
            //    context.Addresses
            //        .OrderByDescending(address => address.Employees.Count)
            //        .ThenBy(address => address.Town.Name)
            //        .Take(10);
            //
            //foreach (Address address in addresses)
            //{
            //    content.AppendLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            //}
            #endregion

            #region//Employee with id 147 sorted by project names                                       
            //Employee employee = context.Employees.Find(147);
            //IEnumerable<Project> projects = employee.Projects.OrderBy(project => project.Name);
            //content.AppendLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            //foreach (var project in projects)
            //{
            //    content.AppendLine(project.Name);
            //}
            #endregion

            #region//Departments with more than 5 employees  
            //IEnumerable<Department> departments = context
            //    .Departments.Where(department => department.Employees.Count > 5)
            //    .OrderBy(department => department.Employees.Count);
            //foreach (Department department in departments)
            //{
            //    content.AppendLine($"{department.Name} {department.Employee.FirstName}");
            //    foreach (Employee employee in department.Employees)
            //    {
            //        content.AppendLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            //    }
            //}
            #endregion

            #region//Native SQL Query    
            //context.Addresses.Count();

            //var timer = new Stopwatch();

            //timer.Start();
            //PrintNameWithLinq(context);
            //timer.Stop();
            //content.AppendLine($"Linq: {timer.Elapsed}");
            //timer.Reset();


            //timer.Start();
            //PrintNamesWithNativeQuery(context);
            //timer.Stop();
            //content.AppendLine($"Native: {timer.Elapsed}");
            //timer.Reset();    
            #endregion

            #region//Find Latest 10 Projects    
            //var latestStartedProjects =
            //    context.Projects.OrderByDescending(project => project.StartDate)
            //        .Take(10)
            //        .OrderBy(project => project.Name);
            //
            //foreach (var latestStartedProject in latestStartedProjects)
            //{
            //    content.AppendLine($"{latestStartedProject.Name} {latestStartedProject.Description} {latestStartedProject.StartDate} {latestStartedProject.EndDate}");
            //}      
            #endregion

            #region//Increase salaries  

            //var employees = context.Employees.Where(employee =>
            //    employee.Department.Name == "Engineering"
            //    || employee.Department.Name == "Tool Design"
            //    || employee.Department.Name == "Marketing"
            //    || employee.Department.Name == "Information Services");
            //
            //foreach (var employee in employees)
            //{
            //    employee.Salary *= 1.12m;
            //    content.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            //}
            //
            //
            //context.SaveChanges();

            #endregion

            #region//Remove Towns   

            //string townName = Console.ReadLine();
            //Town wantedTown = context.Towns.FirstOrDefault(town => town.Name == townName);
            //Address[] townAddresses = wantedTown.Addresses.ToArray();
            //foreach (Address townAddress in townAddresses)
            //{
            //    Employee[] employeesAddresses = townAddress.Employees.ToArray();
            //    foreach (var employee in employeesAddresses)
            //    {
            //        employee.AddressID = null;
            //    }
            //}
            //
            //context.Addresses.RemoveRange(townAddresses);
            //context.Towns.Remove(wantedTown);
            //context.SaveChanges();     
            //content.AppendLine($"{townAddresses.Length} address in {townName} was deleted");  

            #endregion

            #region//Find Employees by First Name starting with ‘SA’  

            //string pattern = "SA";
            //var employeesByNamePattern = context.Employees
            //    .Where(employee => employee.FirstName.StartsWith(pattern));
            //
            //foreach (var employeeByPattern in employeesByNamePattern)
            //{
            //    content.AppendLine($"{employeeByPattern.FirstName} {employeeByPattern.LastName} " +
            //                      $"- {employeeByPattern.JobTitle} - (${employeeByPattern.Salary})");
            //}   

            #endregion

            File.WriteAllText("temp.txt", content.ToString());
        }

        private static void PrintNameWithLinq(SoftuniContext context)
        {
            var employeesNames =
                context.Employees
                    .Where(employee =>
                        employee.Projects.Count(project => project.StartDate.Year == 2002) != 0)
                    .Select(employee => employee.FirstName).GroupBy(s => s);
            foreach (var s in employeesNames)
            {

            }
        }

        private static void PrintNamesWithNativeQuery(SoftuniContext context)
        {
            string query = "SELECT em.FirstName FROM Employees em " +
                           "JOIN EmployeesProjects emproj " +
                           "ON emproj.EmployeeId = em.EmployeeId " +
                           "JOIN Projects proj " +
                           "ON emproj.ProjectId = proj.ProjectId AND YEAR(proj.StartDate) = 2002 " +
                           "GROUP BY em.FirstName";
            var result = context.Database.SqlQuery<string>(query);
            foreach (var f in result)
            {

            }

        }
    }
}
