using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentsDataAPI.Entities;
using StudentsDataAPI.Models;
using StudentsDataAPI.Profiles;

namespace StudentsDataAPI.DbContexts
{
    public partial class StudentsDataContext : DbContext
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
