using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AteshgahPracticalProject.WebAPI.Controllers
{
    public class LoansController : ApiController
    {
        private readonly ILoanService _loanService;


        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        public HttpResponseMessage GetLoan(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _loanService.Get(id));
        }

        public HttpResponseMessage GetLoans()
        {

            return Request.CreateResponse(HttpStatusCode.OK, _loanService.GetAll());
        }

        public HttpResponseMessage PostLoan(Loan loan)
        {
            try
            {
                if (_loanService.Add(loan) != null)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loan);
                    response.Headers.Location = new Uri(Request.RequestUri + "/" + loan.ID);
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Insert Process Failed.");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Please Contact with the admin. Process Did Not Successed");
            }
        }
    }
}
