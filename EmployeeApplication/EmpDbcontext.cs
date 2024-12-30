using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EmployeeApplication.Models;

namespace EmployeeApplication
{
    public class EmpDbcontext : DbContext
    {
        public EmpDbcontext(DbContextOptions<EmpDbcontext> options) : base(options) { }

        public DbSet<EmpModel>? petAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=petanimalmvc;Username=postgres;Password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<EmployeeApplication.Models.EmpModel> PetAnimal { get; set; } = default!;



    }
}

