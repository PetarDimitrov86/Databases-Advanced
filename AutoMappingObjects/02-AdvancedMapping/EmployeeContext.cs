namespace _02_AdvancedMapping
{
    using System.Data.Entity;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }
         public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}