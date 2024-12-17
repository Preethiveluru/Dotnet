using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace EFwithWebAPI
{
    
        public class StudentDbContext : DbContext
        {
           public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

            public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=HMS;Username=postgres;Password=postgres;");

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

        }
    }
}
        
