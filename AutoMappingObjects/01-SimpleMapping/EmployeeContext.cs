namespace _01_SimpleMapping
{
    using System.Data.Entity;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

         public virtual DbSet<Employee> Employees { get; set; }
    }
}