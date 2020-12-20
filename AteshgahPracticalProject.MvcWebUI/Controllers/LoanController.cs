using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Business.CustomViewHelper;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using AteshgahPracticalProject.MvcWebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AteshgahPracticalProject.MvcWebUI.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IInvoiceService _invoiceService;
        private readonly IClientService _clientService;
        public LoanController(ILoanService loanService, IInvoiceService invoiceService, IClientService clientService)
        {
            _loanService = loanService;
            _invoiceService = invoiceService;
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult GetLoansPage()
        {
            var businessResult = new BusinessResult
            {
                AlertColor = "",
                ResultMessage = "",
                ResultStatus = 0
            };

            var clients = _clientService.GetAll();

            LoanViewModel viewModel = new LoanViewModel
            {
                LoanDetails = _loanService.GetLoanDetails(),
                ViewResult = businessResult,
                Clients = clients,
                MinPayPeriod = 3,
                MaxPayPeriod = 24
            };
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AcceptedLoan(AcceptCalculateModel calculateModel)
        {
            BusinessResult businessResult = new BusinessResult();

            decimal interest = Convert.ToDecimal(calculateModel.InterestRate);

            CalculateModel model = new CalculateModel
            {
                ClientID = Convert.ToInt32(calculateModel.ClientID),
                LoanPeriod = Convert.ToInt32(calculateModel.LoanPeriod),
                InterestRate = interest,
                LoanAmount = Convert.ToDecimal(calculateModel.LoanAmount),
                TelephoneNr = calculateModel.TelephoneNr,
                PayoutDate = Convert.ToDateTime(calculateModel.PayoutDate)
            };

            var invoices = _invoiceService.GetCalculatedInvoices(model);

            if (invoices.Count>2)
            {
                Loan loan = new Loan
                {
                    ClientID = model.ClientID,
                    Amount = model.LoanAmount,
                    InterestRate = model.InterestRate,
                    LoanPeriod = model.LoanPeriod,
                    PayoutDate = model.PayoutDate
                };

                var result = _loanService.Add(loan);

                if (result != null)
                {
                    foreach (var item in invoices)
                    {
                        item.LoanID = result.ID;
                        _invoiceService.Add(item);
                    }

                    businessResult.AlertColor = "success";
                    businessResult.ResultMessage = "Successfully Created Loan and Invoices";
                }
                else
                {
                    businessResult.AlertColor = "danger";
                    businessResult.ResultMessage = "Sorry! Dataes Did not Created! May Be Server Did Not Respons You. . .";
                }
            }

            return PartialView("_PartialAlertNofification", businessResult);
        }

        [HttpPost]
        public ActionResult UpdateLoans()
        {
            var loanDetails = _loanService.GetLoanDetails();
            LoanViewModel viewModel = new LoanViewModel();

            viewModel.LoanDetails = loanDetails;

            return PartialView("_PartialLoanListCurrentTime", viewModel);
        }

    }
}