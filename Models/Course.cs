using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Display(Name="Course Name")]
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }




        public List<CourseResult> CourseResults { get; set; }

    }
}
