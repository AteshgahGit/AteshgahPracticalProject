using AteshgahPracticalProject.Core.DataAccess.EntityFramework;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Concrete.EntityFramework
{
    public class EfClientDal : EfEntityRepositoryBase<Client,ProjectContext>, IClientDal
    {
    }
}
