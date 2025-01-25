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
    }
}
