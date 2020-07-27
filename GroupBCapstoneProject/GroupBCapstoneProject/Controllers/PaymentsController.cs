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
    [Authorize(Policy = "IsStudent")]
    public class PaymentsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public PaymentsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index(string errorMessage)
        {
            if (String.IsNullOrEmpty(errorMessage))
            {
                return View();
            }
            ViewData["ErrorMessage"] = errorMessage;
            return View();
        }

        [HttpPost]
        public ActionResult Index(PaymentModel payment)
        {
            if (string.IsNullOrWhiteSpace(payment.FirstName) && string.IsNullOrWhiteSpace(payment.LastName) && string.IsNullOrWhiteSpace(payment.Address1) && string.IsNullOrWhiteSpace(payment.Address2) &&
                string.IsNullOrWhiteSpace(payment.Month) && string.IsNullOrWhiteSpace(payment.Year) && string.IsNullOrWhiteSpace(payment.PostCode) && string.IsNullOrWhiteSpace(payment.CardCode))
            {
                ModelState.AddModelError("CardNumber", "Cannot be empty and card number has to be 14 digits or greater");
            }
            if (!ModelState.IsValid)
            {
                View(payment);
            }

            TransactionResponse result = new PaymentProcesses().ChargeCredit(payment);

            if (result != null && result.ResultCode == AuthorizeNet.Api.Contracts.V1.messageTypeEnum.Ok)
            {
                PaymentManager manager = new PaymentManager(_context);
                string userID = _userManager.GetUserId(User);
                manager.SubtractBalanceFromStudent(userID, result.AmountPaid);

                TransactionResponse viewmodel = new TransactionResponse()
                {
                    TransId = result.TransId,
                    ResultCode = result.ResultCode,
                    ResponseCode = result.ResponseCode,
                    MessageCode = result.MessageCode,
                    AuthCode = result.AuthCode,
                    Description = result.Description,
                    AmountPaid = result.AmountPaid,
                };

                List<TransactionResponse> viewmodelList = new List<TransactionResponse>
                {
                    viewmodel
                };
                return View("TransactionResponse", viewmodelList);
            }
            else
            {
                PaymentModel model = new PaymentModel();

                TransactionResponse transaction = new TransactionResponse();

                if (transaction.ErrorCode == "6" || transaction.ErrorCode == "78" || transaction.ErrorCode == "316" || transaction.ErrorCode == "112")
                {
                    model.CardNumber = transaction.ErrorText;
                    return View("Index", model.CardNumber);
                }
                else
                {
                    return View("Index", model.CardNumber);
                }

            }
        }
    }
}
