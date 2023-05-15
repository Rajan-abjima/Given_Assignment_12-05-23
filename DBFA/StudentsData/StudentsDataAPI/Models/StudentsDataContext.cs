using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentsDataAPI.Models
{
    public partial class StudentsDataContext : DbContext
    {
        public StudentsDataContext()
        {
        }

        public StudentsDataContext(DbContextOptions<StudentsDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentsDataTable> StudentsDataTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsDataTable>(entity =>
            {
                entity.HasKey(e => e.RollNo);

                entity.ToTable("StudentsDataTable");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
