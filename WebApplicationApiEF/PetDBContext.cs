using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using WebApplicationApiEF.Models;

namespace WebApplicationApiEF
{
    public class PetDBContext : DbContext
    {
        public PetDBContext(DbContextOptions<PetDBContext> options) : base(options) { }

        public DbSet<PetAnimal>? petAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=petanimal;Username=postgres;Password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }





    }
}
