using AteshgahPracticalProject.Core.Entities.ComplexTypes;
using AteshgahPracticalProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.Abstract
{
    public interface ILoanService
    {
        List<Loan> GetAll(Expression<Func<Loan, bool>> filter = null);
        Loan Get(int id);
        Loan Add(Loan loan);
        List<LoanDetail> GetLoanDetails();
    }
}
