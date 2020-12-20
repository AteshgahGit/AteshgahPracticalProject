using AteshgahPracticalProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable(@"Clients", @"dbo");
            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.ClientUniqueID).HasColumnName("ClientUniqueID").IsRequired().HasMaxLength(15);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.Surname).HasColumnName("Surname").IsRequired().HasMaxLength(50);
            Property(x => x.TelephoneNr).HasColumnName("TelephoneNr").IsRequired().HasMaxLength(20);
        }
    }
}
