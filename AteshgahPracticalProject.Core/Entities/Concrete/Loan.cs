using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Entities.Concrete
{
    public class Loan : EntityBase
    {
        public int ClientID { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }
    }
}
