﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupBCapstoneProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GroupBCapstoneProject.AuthorizationRequirements;
using GroupBCapstoneProject.Controllers.Helpers;

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
        async public Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserId(User);
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userID);
            if (currentUser.CompletedRegistration == false)
            {
                return RedirectToAction("GetStudentInfo");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Sign up for a class":
                    return RedirectToAction("RegisterForCourse");
                default:
                    break;
            }
            return View();
        }

        public IActionResult GetStudentInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetStudentInfo([Bind("ID,FirstName,LastName,Major,EmailAddress,PhoneNumber")] Student student)
        {
            student.Balance = 0;
            var userID = _userManager.GetUserId(User);
            student.AspNetUserID = userID;
            
            
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.FindByIdAsync(userID);
                currentUser.CompletedRegistration = true;
                _context.Add(student);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View("FailedToCreate");
        }

        public IActionResult RegisterForCourse()
        {
            RegistrationManager manager = new RegistrationManager(_context);
            ViewBag.listOfCoursesForRegistration = manager.GetListOfCoursesForRegistration();
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> RegisterForCourse(int courseID)
        {
            
            var userID = _userManager.GetUserId(User);
            RegistrationManager manager = new RegistrationManager(_context);
            await manager.AddBalanceToStudent(courseID, userID);
            int studentID = manager.GetStudentIDFromUserID(userID);
            Enrollment enrollment = new Enrollment()
            {
                CourseID = courseID,
                StudentID = studentID,
                Date = DateTime.Now,
            };

            _context.Add(enrollment);     
            await _context.SaveChangesAsync();

            return View("Index");
        }
    }
}
