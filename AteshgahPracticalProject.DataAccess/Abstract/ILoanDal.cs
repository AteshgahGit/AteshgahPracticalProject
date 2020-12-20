using AteshgahPracticalProject.Core.DataAccess;
using AteshgahPracticalProject.Core.Entities.ComplexTypes;
using AteshgahPracticalProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Abstract
{
    public interface ILoanDal : IEntityRepository<Loan>
    {
        List<LoanDetail> GetLoanDetails();
    }
}
