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
    public class InvoicesController : ApiController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public HttpResponseMessage GetInvoice(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _invoiceService.Get(id));
        }

        public HttpResponseMessage GetInvoices()
        {

            return Request.CreateResponse(HttpStatusCode.OK, _invoiceService.GetAll());
        }

        public HttpResponseMessage PostLoan(Invoice invoice)
        {
            try
            {
                if (_invoiceService.Add(invoice) != null)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, invoice);
                    response.Headers.Location = new Uri(Request.RequestUri + "/" + invoice.ID);
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Insert Process Failed.");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please Contact with the admin. Process Did Not Successed");
            }
        }
    }
}
