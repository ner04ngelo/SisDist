using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using ContosoUniversity.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversity.DAL
{
    public class SchoolContext: DbContext
    {

        public SchoolContext() : base("SchoolContext")
        {

        }

        public DbSet<Student> Estudiantes { get; set; }
        public DbSet<Enrollment> Inscripciones { get; set; }
        public DbSet<Course> Cursos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}