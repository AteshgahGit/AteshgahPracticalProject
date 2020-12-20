using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.Core.Utilities.ViewTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AteshgahPracticalProject.MvcWebUI.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public List<Invoice> Invoices { get; set; }
        public CalculateModel CalculateModel { get; set; }
    }
}