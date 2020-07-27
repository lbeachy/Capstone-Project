using GroupBCapstoneProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupBCapstoneProject.Controllers.Helpers
{
    public class PaymentManager
    {
        private readonly AppDbContext _context;

        public PaymentManager(AppDbContext context)
        {
            _context = context;
        }

        public void SubtractBalanceFromStudent(string userID, decimal amountToBePaid)
        {
            RegistrationManager manager = new RegistrationManager(_context);
            int studentID = manager.GetStudentIDFromUserID(userID);
            Student student = manager.GetStudentByStudentID(studentID);
            student.Balance -= amountToBePaid;
            _context.Update(student);
            _context.SaveChanges();
        }
    }
}
