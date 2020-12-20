using AteshgahPracticalProject.Business.Abstract;
using AteshgahPracticalProject.Business.ValidationRules.FluentValidation;
using AteshgahPracticalProject.Core.Aspects.PostSharp.CacheAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.ExceptionAspects;
using AteshgahPracticalProject.Core.Aspects.PostSharp.ValidationAspects;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using AteshgahPracticalProject.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using AteshgahPracticalProject.Core.Entities.ComplexTypes;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.DataAccess.Abstract;
using AteshgahPracticalProject.DataAccess.Concrete.EntityFramework;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.Concrete.Managers
{
    public class LoanManager : ILoanService
    {
        private readonly ILoanDal _loanDal;
        private readonly IMapper _mapper;

        public LoanManager(ILoanDal loanDal, IMapper mapper)
        {
            _loanDal = loanDal;
            _mapper = mapper;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger))]
        [FluentValidationAspect(typeof(LoanValidator))]
        [CacheClearAspect(typeof(MemoryCacheManager))]
        public Loan Add(Loan loan)
        {
            return _loanDal.Add(loan);
        }

        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public Loan Get(int id)
        {
            Loan loan = _loanDal.Get(x => x.ID == id);
            return _mapper.Map<Loan>(loan);
        }

        [ExceptionLogAspect(typeof(DatabaseLogger))]
        [CacheAspect(typeof(MemoryCacheManager),2)]
        public List<Loan> GetAll(Expression<Func<Loan, bool>> filter = null)
        {
            List<Loan> loans = _loanDal.GetAll(filter);
            return _mapper.Map<List<Loan>>(loans);
        }

        [ExceptionLogAspect(typeof(DatabaseLogger))]
        [CacheAspect(typeof(MemoryCacheManager),2)]
        public List<LoanDetail> GetLoanDetails()
        {
            List<LoanDetail> loanDetails = _loanDal.GetLoanDetails();
            return _mapper.Map<List<LoanDetail>>(loanDetails);
        }
    }
}
