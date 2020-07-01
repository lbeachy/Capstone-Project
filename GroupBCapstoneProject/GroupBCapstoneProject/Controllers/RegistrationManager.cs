using GroupBCapstoneProject.AuthorizationRequirements;
using GroupBCapstoneProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupBCapstoneProject.Controllers
{
    public class RegistrationManager
    {
        private readonly AppDbContext _context;

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
    }
}
