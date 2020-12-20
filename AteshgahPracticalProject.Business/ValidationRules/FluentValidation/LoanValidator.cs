using AteshgahPracticalProject.Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.ValidationRules.FluentValidation
{
    public class LoanValidator : AbstractValidator<Loan>
    {
        public LoanValidator()
        {
            RuleFor(x => x.ClientID).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(100).LessThan(5000);
            RuleFor(x => x.InterestRate).NotEmpty();
            RuleFor(x => x.LoanPeriod).NotEmpty().GreaterThan(3).LessThan(24);
            RuleFor(x => x.PayoutDate).NotEmpty();
        }
    }
}
