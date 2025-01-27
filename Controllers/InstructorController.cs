using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers
{
    public class InstructorController : Controller
    {
        Assignment1DBContext DB = new Assignment1DBContext();
        public IActionResult Index()
        {
            List<Instructor> InstructorsModel= DB.Instructors.Include(I=> I.Department).Include(i=> i.Course).ToList();
            return View("Index", InstructorsModel);
        }




        public IActionResult Details(int id)
        {
            Instructor instructorModel= DB.Instructors.Include(i=>i.Course).Include(i=>i.Department).FirstOrDefault(i=> i.Id==id);
            return View("Details",instructorModel);
        }


        public IActionResult AddInstructor()
        {
            ViewBag.Courses = DB.Courses.ToList();
            return View("AddInstructor",DB.Departments.ToList());
        }

        public IActionResult SaveAdd(Instructor instructorReciever)
        {
            instructorReciever.ImageURL = "1.png";
            DB.Instructors.Add(instructorReciever);
            DB.SaveChanges();
           return  RedirectToAction("Index");
        }



        public IActionResult Edit(int id, string department, string course)
        {
           Instructor instructorModel= DB.Instructors.FirstOrDefault(i => i.Id == id);
            ViewBag.Departments= DB.Departments.ToList();
            ViewBag.Courses= DB.Courses.ToList();
            ViewBag.department=department;
            ViewBag.course=course;
            return View("Edit",instructorModel);
        }

        public IActionResult SaveEdit(Instructor instructorReciever) {

            instructorReciever.ImageURL = "1.png";
            
            Instructor targetInstructor = DB.Instructors.FirstOrDefault(i=> i.Id == instructorReciever.Id);
            if(targetInstructor != null)
            {
                targetInstructor.Id=instructorReciever.Id;
                targetInstructor.Address=instructorReciever.Address;
                targetInstructor.Salary=instructorReciever.Salary;
                targetInstructor.CourseId=instructorReciever.CourseId;
                targetInstructor.DepartmentId=instructorReciever.DepartmentId;
                targetInstructor.Course=instructorReciever.Course;
                targetInstructor.Department=instructorReciever.Department;

                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("failed to edit");
        }


        public IActionResult Search(string Name)
        {
           List<Instructor> matchListModel= DB.Instructors.Include(i => i.Department).Include(i => i.Course).Where(i => i.Name.Contains(Name)).ToList();

            return View("search",matchListModel);
        }


        public IActionResult Remove(int id)
        {
            Instructor MatchedInstructor =DB.Instructors.FirstOrDefault(i=> i.Id==id);
            DB.Instructors.Remove(MatchedInstructor);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
