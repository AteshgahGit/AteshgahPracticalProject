using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.Abstract
{
    public interface IInvoiceService
    {
        List<Invoice> GetAll(Expression<Func<Invoice, bool>> filter = null);
        Invoice Get(int id);
        Invoice Add(Invoice invoice);
        List<Invoice> GetCalculatedInvoices(CalculateModel model);

        decimal CalculateInvoiceAmount(int period, decimal amount, int orderNumber, decimal percentageAsDecimal);
    }
}
