namespace _03.Projection
{
    using System.Data.Entity;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}