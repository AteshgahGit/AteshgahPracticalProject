using AteshgahPracticalProject.Core.Entities.Concrete;
using AteshgahPracticalProject.DataAccess.Concrete.EntityFramework.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Concrete.EntityFramework
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new LoanMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
        }
    }
}
