using EmployeeApp.Models;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace EmployeeApp

{

    public class EmployeeDbContext : DbContext

    {

        public DbSet<Employee>? Employees { get; set; }


        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)

            : base(options) // Pass the options to the base DbContext constructor

        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }

    }

}


