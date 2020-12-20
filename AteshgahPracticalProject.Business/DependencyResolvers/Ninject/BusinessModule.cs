using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Business.Concrete.Managers;
using AteshgahPracticalProject.Core.DataAccess;
using AteshgahPracticalProject.Core.DataAccess.EntityFramework;
using AteshgahPracticalProject.DataAccess.Abstract;
using AteshgahPracticalProject.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<ProjectContext>();

            Bind<IClientService>().To<ClientManager>().InSingletonScope();
            Bind<ILoanService>().To<LoanManager>().InSingletonScope();
            Bind<IInvoiceService>().To<InvoiceManager>().InSingletonScope();

            Bind<IClientDal>().To<EfClientDal>().InSingletonScope();
            Bind<ILoanDal>().To<EfLoanDal>().InSingletonScope();
            Bind<IInvoiceDal>().To<EfInvoiceDal>().InSingletonScope();
        }
    }
}
