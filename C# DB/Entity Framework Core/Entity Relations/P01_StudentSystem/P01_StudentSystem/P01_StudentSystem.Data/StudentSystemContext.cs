using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext([NotNull] DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-NNIGS3T\SQLEXPRESS;Database=StudentSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<StudentCourse>(x =>
            {
                x.HasKey(x => new { x.CourseId, x.StudentId });
            });

             modelBuilder.Entity<Student>(s =>
             {
                 s.Property(p => p.PhoneNumber)
                     .IsRequired(false)
                     .IsUnicode(false);
             });

             modelBuilder.Entity<Course>(c =>
             {
                 c.Property(c => c.Description)
                     .IsRequired(false);
             });

             modelBuilder.Entity<Resource>(e =>
             {
                 e.Property(e => e.Url)
                     .IsUnicode(false);
             });

             modelBuilder.Entity<Homework>(e =>
             {
                 e.Property(e => e.Content)
                     .IsUnicode(false);
             });
        }
    }
}
