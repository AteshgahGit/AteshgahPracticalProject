using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AteshgahPracticalProject.Core.Utilities.ViewTools
{ 
    public class CalculateModel
    {
        public int ClientID { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int LoanPeriod { get; set; }
        public DateTime PayoutDate { get; set; }
        public string TelephoneNr { get; set; }
    }
}