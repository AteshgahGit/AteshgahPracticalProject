using AteshgahPracticalProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Concrete.EntityFramework.Mappings
{
    public class LoanMap : EntityTypeConfiguration<Loan>
    {
        public LoanMap()
        {
            ToTable(@"Loans", @"dbo");
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.ClientID).HasColumnName("ClientID").IsRequired();
            Property(x => x.Amount).HasColumnName("Amount").IsRequired().HasPrecision(10, 2);
            Property(x => x.InterestRate).HasColumnName("InterestRate").IsRequired().HasPrecision(6, 2);
            Property(x => x.LoanPeriod).HasColumnName("LoanPeriod").IsRequired();
            Property(x => x.PayoutDate).HasColumnName("PayoutDate").IsRequired();
        }
    }
}
