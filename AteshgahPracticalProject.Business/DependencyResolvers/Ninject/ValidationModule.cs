using AteshgahPracticalProject.Business.ValidationRules.FluentValidation;
using AteshgahPracticalProject.Core.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Client>>().To<ClientValidator>().InSingletonScope();
            Bind<IValidator<Loan>>().To<LoanValidator>().InSingletonScope();
            Bind<IValidator<Invoice>>().To<InvoiceValidator>().InSingletonScope();
        }
    }
}
