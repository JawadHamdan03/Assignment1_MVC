namespace Assignment1.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public int Degree { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }



        public List<CourseResult> courseResults { get; set; }
    }
}
