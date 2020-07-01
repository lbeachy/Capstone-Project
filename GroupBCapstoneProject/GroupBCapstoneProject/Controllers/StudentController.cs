using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBCapstoneProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GroupBCapstoneProject.AuthorizationRequirements;

namespace GroupBCapstoneProject.Controllers
{
    [Authorize(Policy = "IsStudent")]
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Sign up for a class":
                    return View("RegisterForCourse");
                default:
                    break;
            }
            return View();
        }

        public IActionResult RegisterForCourse()
        {
            RegistrationManager manager = new RegistrationManager(_context);
            ViewBag.listOfCoursesForRegistration = manager.GetListOfCoursesForRegistration();
            return View();
        }

        [HttpPost]
        public IActionResult RegisterForCourse(int courseID)
        {
            
            var userID = _userManager.GetUserId(User);
            RegistrationManager manager = new RegistrationManager(_context);
            int studentID = manager.GetStudentIDFromUserID(userID);
            //int courseID = manager.GetCourseIDFromSectionNumber(sectionNumber);
            Enrollment enrollment = new Enrollment()
            {
                CourseID = courseID,
                StudentID = studentID,
                Date = DateTime.Now,
            };

            _context.Add(enrollment);
            _context.SaveChangesAsync();

            return View("Index");
        }
    }
}
