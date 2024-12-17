using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication3.Models;

namespace WebApplication3
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
                optionsBuilder.UseNpgsql("Host=localhost;Port=5013;Database=postgres;Username=postgres;Password=postgres;");

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                base.OnModelCreating(modelBuilder);
            }

        }
    }

  
