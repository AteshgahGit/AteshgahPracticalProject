using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Entities.ComplexTypes
{
    public class LoanDetail
    {
        public string ClientID { get; set; }
        public string ClientFullName { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime PayoutDate { get; set; }
        public int LoanID { get; set; }
    }
}
