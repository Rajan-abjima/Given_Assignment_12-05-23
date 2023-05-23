using Microsoft.EntityFrameworkCore;
using StudentsDataAPI.Entities;

namespace StudentsDataAPI.DbContexts
{
    public class StudentsDataContext : DbContext
    {
        public StudentsDataContext()
        {
        }


        public virtual DbSet<StudentData> StudentsDataTable { get; set; } = null!;
        public StudentsDataContext(DbContextOptions<StudentsDataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentData>();
        }
    }
}
