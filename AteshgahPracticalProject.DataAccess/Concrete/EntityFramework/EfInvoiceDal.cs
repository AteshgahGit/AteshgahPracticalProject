using AteshgahPracticalProject.Core.DataAccess.EntityFramework;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using AteshgahPracticalProject.DataAccess.Abstract;
using AteshgahPracticalProject.DataAccess.Concrete.EntityFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Concrete.EntityFramework
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, ProjectContext>, IInvoiceDal
    {
        public List<Invoice> GetCalculatedInvoices(CalculateModel model)
        {
            List<Invoice> invoices = new List<Invoice>();

            using (var context = new ProjectContext())
            {
                for (int i = 1; i <= model.LoanPeriod; i++)
                {
                    Invoice invoice = new Invoice
                    {
                        Amount = SP_CalculateInvoiceAmount(model.LoanPeriod,model.LoanAmount,i,model.InterestRate),
                        DueDate = model.PayoutDate.AddMonths(i).Date,
                        InvoiceNr = context.Invoices.Count()+i,
                        OrderNr = i
                    };
                    invoices.Add(invoice);
                }
            }

            return invoices.OrderBy(x => x.OrderNr).ToList();
        }

        public decimal SP_CalculateInvoiceAmount(int period, decimal amount, int orderNumber, decimal percentageAsDecimal)
        {
            decimal result;

            using (var context = new ProjectContext())
            {
                var LoanPeriod = new SqlParameter();
                LoanPeriod.Value = period;
                LoanPeriod.ParameterName = "@LoanPeriod";
                LoanPeriod.SqlDbType = SqlDbType.Int;
                LoanPeriod.Direction = ParameterDirection.Input; 

                var LoanAmount = new SqlParameter();
                LoanAmount.Value = amount;
                LoanAmount.ParameterName = "@LoanAmount";
                LoanAmount.SqlDbType = SqlDbType.Money;
                LoanAmount.Direction = ParameterDirection.Input;

                var InvoiceOrderNr = new SqlParameter();
                InvoiceOrderNr.Value = orderNumber;
                InvoiceOrderNr.ParameterName = "@InvoiceOrderNr";
                InvoiceOrderNr.SqlDbType = SqlDbType.Int;
                InvoiceOrderNr.Direction = ParameterDirection.Input;

                var InterestRate = new SqlParameter();
                InterestRate.Value = percentageAsDecimal;
                InterestRate.ParameterName = "@InterestRate";
                InterestRate.SqlDbType = SqlDbType.Decimal;
                InterestRate.Direction = ParameterDirection.Input;

                var query = context.Database.SqlQuery<decimal>("declare @result AS MONEY EXEC @result = SP_Calculate_Invoice_Amount @LoanPeriod, @LoanAmount, @InvoiceOrderNr, @InterestRate SELECT @result", LoanPeriod, LoanAmount, InvoiceOrderNr, InterestRate);

                result = query.FirstOrDefault();
            }

            return result;
        }
    }
}