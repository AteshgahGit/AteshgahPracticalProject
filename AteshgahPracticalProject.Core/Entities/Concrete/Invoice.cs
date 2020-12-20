using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Entities.Concrete
{
    public class Invoice : EntityBase
    {
        public int LoanID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int InvoiceNr { get; set; }
        public int OrderNr { get; set; }
    }
}
