using AteshgahPracticalProject.Core.Entities.ComplexTypes;
using AteshgahPracticalProject.Core.Entities.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Client, Client>();
            CreateMap<Loan, Loan>();
            CreateMap<Invoice, Invoice>();
            CreateMap<LoanDetail, LoanDetail>();
        }
    }
}
