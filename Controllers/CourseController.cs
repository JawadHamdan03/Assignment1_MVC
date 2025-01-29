using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers;

public class CourseController : Controller
{

    public Assignment1DBContext DB =new Assignment1DBContext();

    public IActionResult Index()
    {
        var Courses = DB.Courses.Include(c=> c.Department).ToList();
        return View("Index",Courses);
    }

    public IActionResult AddCourse()
    {
        ViewBag.Departments = DB.Departments.ToList();
        return View("AddCourse");
    }

    public IActionResult saveCourse(Course RCVCourse)
    {
        DB.Courses.Add( RCVCourse );
        DB.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int Id)
    {
       var mathcedCourse= DB.Courses.FirstOrDefault(c=> c.Id==Id);
        DB.Courses.Remove(mathcedCourse);
        DB.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int Id) {
        var matchedCourse = DB.Courses.Include(c=>c.Department).FirstOrDefault(c=> c.Id==Id);
        ViewBag.Departments= DB.Departments.ToList();
        return View("Edit",matchedCourse);
    }
    public IActionResult Search(string Name )
    {
       var resultModel= DB.Courses.Include(c=> c.Department).Where(c=> c.Name.Contains(Name)).ToList();
        return View("Search", resultModel);
    }

}
