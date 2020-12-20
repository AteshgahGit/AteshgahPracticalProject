using AteshgahPracticalProject.Business.CustomViewHelper;
using AteshgahPracticalProject.Core.Entities.ComplexTypes;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AteshgahPracticalProject.MvcWebUI.Models.ViewModels
{
    public class LoanViewModel
    {
        public List<LoanDetail> LoanDetails { get; set; }
        public AcceptCalculateModel AcceptCalculate { get; set; }
        public List<Client> Clients { get; set; }
        public BusinessResult ViewResult { get; set; }
        public int MinPayPeriod { get; set; }
        public int MaxPayPeriod { get; set; }
    }
}