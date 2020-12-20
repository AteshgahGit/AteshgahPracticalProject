using AteshgahPracticalProject.Core.Entities.ComplexTypes;
using AteshgahPracticalProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.Abstract
{
    public interface IClientService
    {
        List<Client> GetAll(Expression<Func<Client, bool>> filter = null);
        Client Get(int id);
        Client Add(Client client);
    }
}
