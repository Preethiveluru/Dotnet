using System.Reflection;
using Microsoft.EntityFrameworkCore;
using webApplicationwebAPIEFwithmvc.Models;

namespace webApplicationwebAPIEFwithmvc
{
    public class PetDBContext:DbContext
    {
        public PetDBContext(DbContextOptions<PetDBContext> options) : base(options) { }

        public DbSet<PetAnimal>? petAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=petanimalmvc;Username=postgres;Password=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<webApplicationwebAPIEFwithmvc.Models.PetAnimal> PetAnimal { get; set; } = default!;



    }
}
