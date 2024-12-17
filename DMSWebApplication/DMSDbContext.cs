using DMSWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DMSWebApplication
{
    public class DMSDbContext:DbContext
    {
     


        public DMSDbContext(DbContextOptions<DMSDbContext> options) : base(options)
        {
        }

        public required DbSet<DMS> DMS { get; set; }
        public required DbSet<patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HMS;Username=postgres;Password=postgres;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
       // public DbSet<DMSWebApplication.Models.Patient> Patient { get; set; } = default!;
        //public DbSet<DMS> DMSS { get; set; } = default!;
    }

}
    
