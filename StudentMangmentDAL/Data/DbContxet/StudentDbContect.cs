using Microsoft.EntityFrameworkCore;
using StudentMangmentDAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangmentDAL.DbContxet
{
    public class StudentDbContect : DbContext
    {
        public StudentDbContect(DbContextOptions<StudentDbContect> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Student> students { get; set; }

        public DbSet<Subject> subjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
    }
}