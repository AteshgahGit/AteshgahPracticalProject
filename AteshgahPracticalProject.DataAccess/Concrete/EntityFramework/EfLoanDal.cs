using AteshgahPracticalProject.Core.DataAccess.EntityFramework;
using AteshgahPracticalProject.Core.Entities.ComplexTypes;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Concrete.EntityFramework
{
    public class EfLoanDal : EfEntityRepositoryBase<Loan, ProjectContext>, ILoanDal
    {
        public List<LoanDetail> GetLoanDetails()
        {
            using (var context = new ProjectContext())
            {
                var result = from ls in context.Loans
                             join cl in context.Clients on ls.ClientID equals cl.ID
                             select new LoanDetail
                             {
                                 ClientID = cl.ClientUniqueID,
                                 ClientFullName = cl.Name+" "+cl.Surname,
                                 LoanAmount = ls.Amount,
                                 PayoutDate = ls.PayoutDate,
                                 LoanID = ls.ID
                             };

                return result.ToList();
            }
        }
    }
}
