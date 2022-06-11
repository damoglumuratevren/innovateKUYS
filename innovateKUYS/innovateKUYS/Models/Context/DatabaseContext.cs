using innovateKUYS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace innovateKUYS.Models.Context
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=MEVREN-DAMOGLU;Database=innovateKUYSDB;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
                optionsBuilder.UseLazyLoadingProxies();

            }
        }
    }
}
