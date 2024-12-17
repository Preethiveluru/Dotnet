using System.Reflection;
using Microsoft.EntityFrameworkCore;
using samplewebapplication.Models;

namespace samplewebapplication
{
    public class EmployeeDbcontext : DbContext
    {

        public DbSet<Employee>? Employees { get; set; }

        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5103;Database=postgres;Username=postgres;Password=postgres;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }
    }
}
