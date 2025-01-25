﻿namespace Assignment1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }


        public List<Instructor> instructors { get; set; }
        public List<Course> Courses { get; set; }

    }
}
