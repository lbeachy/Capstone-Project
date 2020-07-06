using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBCapstoneProject.AuthorizationRequirements;
using GroupBCapstoneProject.Controllers.Helpers;
using GroupBCapstoneProject.Data;
using GroupBCapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GroupBCapstoneProject.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }

        
        public IActionResult Index()
        {
            DataIndexManager manager = new DataIndexManager(_context);
            ViewBag.listOfStudents = manager.GetListOfStudents();
            ViewBag.listOfFaculty = manager.GetListOfFaculty();
            ViewBag.listOfCourses = manager.GetListOfCourses();
            List<DataIndex_vm> dataIndices = manager.GetDatabaseInfo();
            return View(dataIndices);
        }

        [HttpPost]
        public IActionResult Index(string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Add Student":
                    return View("AddStudent");
                case "Add Faculty":
                    return View("AddFaculty");
                case "Add Course":
                    DataIndexManager manager = new DataIndexManager(_context);
                    ViewBag.listOfFaculty = manager.GetListOfFaculty();
                    return View("AddCourse");
                default:
                    break;
            }

            return View("FailedToCreate");
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent([Bind("ID,FirstName,LastName,Balance,Major,EmailAddress,PhoneNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("FailedToCreate");
        }

        public IActionResult AddFaculty()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFaculty([Bind("ID,FirstName,LastName,Department,EmailAddress,PhoneNumber")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("FailedToCreate");
        }

        public IActionResult AddCourse()
        {
            DataIndexManager manager = new DataIndexManager(_context);
            ViewBag.listOfFaculty = manager.GetListOfFaculty();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse([Bind("ID,CourseNumber,SectionNumber,Capacity,Enrollment,FacultyID,StartTime,EndTime,CreditHours,BuildingName,BuildingNumber," +
            "MeetsOnMonday,MeetsOnTuesday,MeetsOnWednesday,MeetsOnThursday,MeetsOnFriday,MeetsOnSaturday")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("FailedToCreate");
        }

        
            
    }
}
