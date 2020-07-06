using GroupBCapstoneProject.AuthorizationRequirements;
using GroupBCapstoneProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupBCapstoneProject.Controllers.Helpers
{
    public class RegistrationManager
    {
        private readonly AppDbContext _context;
        private decimal hourlyTuition = 300;

        public RegistrationManager(AppDbContext context)
        {
            _context = context;
        }
        public List<CourseForRegistration> GetListOfCoursesForRegistration()
        {
            var courses = from course in _context.Courses
                          join faculty in _context.Faculty on course.FacultyID equals faculty.ID
                          select new CourseForRegistration
                          {
                              ID = course.ID,
                              CourseNumber = course.CourseNumber,
                              SectionNumber = course.SectionNumber,
                              AvailableSeats = course.Capacity - course.Enrollment,
                              Faculty = $"{faculty.FirstName} {faculty.LastName}",
                              StartTime = course.StartTime,
                              EndTime = course.EndTime,
                              CreditHours = course.CreditHours,
                              BuildingName = course.BuildingName,
                              BuildingNumber = course.BuildingNumber,
                              MeetsOnMonday = course.MeetsOnMonday,
                              MeetsOnTuesday = course.MeetsOnTuesday,
                              MeetsOnWednesday = course.MeetsOnWednesday,
                              MeetsOnThursday = course.MeetsOnThursday,
                              MeetsOnFriday = course.MeetsOnFriday,
                              MeetsOnSaturday = course.MeetsOnSaturday
                          };
                            
             return courses.ToList();
        }

        public int GetCourseIDFromSectionNumber(string sectionNumber)
        {
            var courseID = _context.Courses
                .Where(c => c.SectionNumber.Equals(sectionNumber))
                .Select(c => c.ID)
                .ToArray();

            return courseID[0];
        }

        public Course GetCourseByCourseID(int courseID)
        {
            var courses = _context.Courses
                .Where(c => c.ID.Equals(courseID))
                 .Select(c => new Course
                 {
                     ID = c.ID,
                     CourseNumber = c.CourseNumber,
                     SectionNumber = c.SectionNumber,
                     Capacity = c.Capacity,
                     Enrollment = c.Enrollment,
                     FacultyID = c.FacultyID,
                     StartTime = c.StartTime,
                     EndTime = c.EndTime,
                     BuildingName = c.BuildingName,
                     BuildingNumber = c.BuildingNumber,
                     MeetsOnMonday = c.MeetsOnMonday,
                     MeetsOnTuesday = c.MeetsOnTuesday,
                     MeetsOnWednesday = c.MeetsOnWednesday,
                     MeetsOnThursday = c.MeetsOnThursday,
                     MeetsOnFriday = c.MeetsOnFriday,
                     MeetsOnSaturday = c.MeetsOnSaturday
                 })
                 .ToList();

                
            return courses[0];
        }

        public int GetStudentIDFromUserID(string userID)
        {
            var studentID = from user in _context.AspNetUsers
                            join student in _context.Students on user.Id equals student.AspNetUserID
                            where user.Id.Equals(userID)
                            select student.ID;

            int[] studentIDs = studentID.ToArray();

            // really should add some error catching for when this inevitably fails.

            return studentIDs[0];             
        }

        public int GetFacultyIDFromUserID(string userID)
        {
            var facultyID = from user in _context.AspNetUsers
                            join faculty in _context.Faculty on user.Id equals faculty.AspNetUserID
                            where user.Id.Equals(userID)
                            select faculty.ID;

            int[] facultyIDs = facultyID.ToArray();

            // really should add some error catching for when this inevitably fails.

            return facultyIDs[0];
        }

        async public Task AddBalanceToStudent(int courseID, string userID)
        {
            int creditHours = FindCreditHoursByCourseID(courseID);
            int studentID = GetStudentIDFromUserID(userID);
            Student student = GetStudentByStudentID(studentID);
            decimal balance = CalculateBalance(creditHours);
            student.Balance += balance;
            _context.Update(student);
            await _context.SaveChangesAsync();
        }

        private int FindCreditHoursByCourseID(int courseID)
        {
            var creditHours = _context.Courses
                .Where(c => c.ID.Equals(courseID))
                .Select(c => c.CreditHours)
                .ToList();

            return creditHours[0];
        }
        private decimal CalculateBalance(int creditHours)
        {
            return creditHours * hourlyTuition;
        }

        private Student GetStudentByStudentID(int studentID)
        {
            var students = _context.Students
                .Where(s => s.ID.Equals(studentID))
                .Select(s => new Student
                {
                    ID = s.ID,
                    AspNetUserID = s.AspNetUserID,
                    Balance = s.Balance,
                    EmailAddress = s.EmailAddress,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Major = s.Major,
                    PhoneNumber = s.PhoneNumber
                })
                .ToList();

            // really should add some error catching for when this inevitably fails.

            return students[0];
        }

    }
}
