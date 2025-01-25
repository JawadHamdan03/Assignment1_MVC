using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models
{
    public class Assignment1DBContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        public Assignment1DBContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
     optionsBuilder.UseSqlServer("Data Source=JAWAD-HAMDAN;Initial Catalog=Assignment1_MVC_DB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }
    }
}
