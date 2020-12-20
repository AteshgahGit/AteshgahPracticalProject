using AteshgahPracticalProject.Core.DataAccess;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Abstract
{
    public interface IInvoiceDal : IEntityRepository<Invoice>
    {
        List<Invoice> GetCalculatedInvoices(CalculateModel model);

        decimal SP_CalculateInvoiceAmount(int period, decimal amount, int orderNumber, decimal percentageAsDecimal);
    }
}
