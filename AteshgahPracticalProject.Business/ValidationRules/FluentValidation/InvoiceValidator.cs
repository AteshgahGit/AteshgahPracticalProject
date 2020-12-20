using AteshgahPracticalProject.Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.ValidationRules.FluentValidation
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.LoanID).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.DueDate).NotEmpty();
            RuleFor(x => x.InvoiceNr).NotEmpty();
            RuleFor(x => x.OrderNr).NotEmpty();
        }
    }
}
