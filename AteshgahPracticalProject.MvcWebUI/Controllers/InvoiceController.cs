using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.CustomHelpers;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using AteshgahPracticalProject.MvcWebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AteshgahPracticalProject.MvcWebUI.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILoanService _loanService;
        private readonly IClientService _clientService;

        public InvoiceController(IInvoiceService invoiceService, ILoanService loanService, IClientService clientService)
        {
            _invoiceService = invoiceService;
            _loanService = loanService;
            _clientService = clientService;
        }

        public ActionResult GetAllInvoices()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetInvoiceDetails(int id)
        {
            // ID is Loan ID
            Loan selectedLoan = _loanService.Get(id);
            List<Invoice> ownedInvoices = _invoiceService.GetAll(x => x.LoanID == selectedLoan.ID);

            InvoiceViewModel viewModel = new InvoiceViewModel
            {
                Invoices = ownedInvoices
            };

            return PartialView("_PartialInvoicesDetailsAfterClickTable", viewModel);
        }

        [HttpPost]
        public PartialViewResult GetCalculatedInvoiceDetails(AcceptCalculateModel calculateModel)
        {
            decimal interest = Convert.ToDecimal(calculateModel.InterestRate);

            CalculateModel model = new CalculateModel
            {
                ClientID = Convert.ToInt32(calculateModel.ClientID),
                LoanPeriod = Convert.ToInt32(calculateModel.LoanPeriod),
                InterestRate = interest/100,
                LoanAmount = Convert.ToDecimal(calculateModel.LoanAmount),
                TelephoneNr = calculateModel.TelephoneNr,
                PayoutDate = Convert.ToDateTime(calculateModel.PayoutDate)
            };

            InvoiceViewModel viewModel = new InvoiceViewModel();

            var invoices = _invoiceService.GetCalculatedInvoices(model);

            viewModel.Invoices = invoices;
            viewModel.CalculateModel = model;

            return PartialView("_PartialCalculatedInvoices", viewModel);
        }
    }
}