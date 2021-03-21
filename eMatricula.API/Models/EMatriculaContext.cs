using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMatricula.API.Models
{
    public class EMatriculaContext : DbContext
    {
        public EMatriculaContext(DbContextOptions<EMatriculaContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(c => c.Enrollments).WithOne(a => a.Student).OnDelete(DeleteBehavior.Cascade);           
            modelBuilder.Entity<Career>().HasMany(c => c.Courses).WithOne(a => a.Career).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>().HasMany(c => c.Requirements).WithOne(a => a.Course).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Enrollment>().HasMany(c => c.CourseSchedules).WithOne(a => a.Enrollment).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Professor>().HasMany(c => c.Counselours).WithOne(a => a.Professor).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>().HasMany(c => c.Counselors).WithOne(a => a.Student).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Career> Careers { get; set; }
        public DbSet<Course> Courses { get; set; }        
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<ProfessorCounselor> ProfessorCounselors { get; set; }
        public DbSet<Professor> Professors { get; set; }
    }
}
