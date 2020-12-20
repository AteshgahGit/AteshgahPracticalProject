using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Business.ValidationRules.FluentValidation;
using AteshgahPracticalProject.Core.Aspects.PostSharp.CacheAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.ExceptionAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.ValidationAspects;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.DataAccess.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.Concrete.Managers
{
    public class ClientManager : IClientService
    {
        private readonly IClientDal _clientDal;
        private readonly IMapper _mapper;

        public ClientManager(IClientDal clientDal, IMapper mapper)
        {
            _clientDal = clientDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(ClientValidator))]
        [CacheClearAspect(typeof(MemoryCacheManager))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public Client Add(Client client)
        {
            return _clientDal.Add(client);
        }

        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public Client Get(int id)
        {
            Client client = _clientDal.Get(x => x.ID == id);
            return _mapper.Map<Client>(client);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public List<Client> GetAll(Expression<Func<Client, bool>> filter = null)
        {
            List<Client> clients = _clientDal.GetAll(filter);
            return _mapper.Map<List<Client>>(clients);
        }
    }
}
