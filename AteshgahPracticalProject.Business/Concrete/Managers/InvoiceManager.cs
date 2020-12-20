using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Business.ValidationRules.FluentValidation;
using AteshgahPracticalProject.Core.Aspects.PostSharp.CacheAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.ExceptionAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.ValidationAspects;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using AteshgahPracticalProject.DataAccess.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.Concrete.Managers
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;
        private readonly IMapper _mapper;

        public InvoiceManager(IInvoiceDal invoiceDal, IMapper mapper)
        {
            _invoiceDal = invoiceDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(InvoiceValidator))]
        [CacheClearAspect(typeof(MemoryCacheManager))]
        public Invoice Add(Invoice invoice)
        {
            return _invoiceDal.Add(invoice);
        }

        public decimal CalculateInvoiceAmount(int period, decimal amount, int orderNumber, decimal percentageAsDecimal)
        {
            return _invoiceDal.SP_CalculateInvoiceAmount(period, amount, orderNumber, percentageAsDecimal);
        }

        public Invoice Get(int id)
        {
            Invoice invoice = _invoiceDal.Get(x => x.ID == id);
            return _mapper.Map<Invoice>(invoice);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Invoice> GetAll(Expression<Func<Invoice, bool>> filter = null)
        {
            List<Invoice> invoices = _invoiceDal.GetAll(filter);
            return _mapper.Map<List<Invoice>>(invoices);
        }


        public List<Invoice> GetCalculatedInvoices(CalculateModel model)
        {
            List<Invoice> resultInvoices = _invoiceDal.GetCalculatedInvoices(model);
            return _mapper.Map<List<Invoice>, List<Invoice>>(resultInvoices);
        }
    }
}
