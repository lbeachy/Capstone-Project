﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GroupBCapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using GroupBCapstoneProject.Data;
using Microsoft.AspNetCore.Identity;
using GroupBCapstoneProject.AuthorizationRequirements;

namespace GroupBCapstoneProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //this breaks things when it's not commented out; I should check it out, I just haven't gotten around to it
        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult FinancialAid()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded && user.RoleInSchool.Equals("Student"))
                {
                    if (user.CompletedRegistration)
                    {
                        return RedirectToAction("Index", "Student");
                    } else
                    {
                        return RedirectToAction("GetStudentInfo", "Student");
                    }
                    
                }            

                if (signInResult.Succeeded && user.RoleInSchool.Equals("Faculty"))
                {
                    if (user.CompletedRegistration)
                    {
                        return RedirectToAction("Index", "Faculty");
                    }
                    else
                    {
                        return RedirectToAction("GetFacultyInfo", "Faculty");
                    }
                }

                return RedirectToAction("Index", "Admin");
            }

            
            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string roleInSchool)
        {

            var user = new ApplicationUser
            {
                UserName = username,
                RoleInSchool = roleInSchool,
                CompletedRegistration = false,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded && user.RoleInSchool.Equals("Student"))
                {
                    return RedirectToAction("GetStudentInfo", "Student");
                } 

                if (signInResult.Succeeded && user.RoleInSchool.Equals("Faculty"))
                {
                    return RedirectToAction("GetFacultyInfo", "Faculty");
                }

                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
