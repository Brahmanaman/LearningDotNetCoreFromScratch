using LearningDotNetCoreFromScratch.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDotNetCoreFromScratch.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> Enrollments { get; set; }

        //if we have created the table and updated the database, but now i want to change the table name
        //we have OnModelCreated Method

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student_Table");
            modelBuilder.Entity<Course>().ToTable("Course_Table");
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse_Table");
        }
 

    }
}
