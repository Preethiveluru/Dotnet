using System.Reflection;
using Medicines_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicines_Management
{
    
        public class MedicineDBContext : DbContext
        {

        public MedicineDBContext(DbContextOptions<MedicineDBContext> options) : base(options) { }

            public DbSet<Medicine>? Medicines { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Medicinemvc;Username=postgres;Password=postgres;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                base.OnModelCreating(modelBuilder);
            }
            public DbSet<Medicines_Management.Models.Medicine> Medicine { get; set; } = default!;



        }
    }



