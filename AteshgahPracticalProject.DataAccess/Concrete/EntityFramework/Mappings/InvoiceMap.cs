using AteshgahPracticalProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Concrete.EntityFramework.Mappings
{
    public class InvoiceMap : EntityTypeConfiguration<Invoice>
    {
        public InvoiceMap()
        {
            ToTable(@"Invoices", @"dbo");
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.Amount).HasColumnName("Amount").IsRequired().HasPrecision(10,2);
            Property(x => x.LoanID).HasColumnName("LoanID").IsRequired();
            Property(x => x.DueDate).HasColumnName("DueDate").IsRequired();
            Property(x => x.InvoiceNr).HasColumnName("InvoiceNr").IsRequired();
            Property(x => x.OrderNr).HasColumnName("OrderNr").IsRequired();
        }
    }
}
