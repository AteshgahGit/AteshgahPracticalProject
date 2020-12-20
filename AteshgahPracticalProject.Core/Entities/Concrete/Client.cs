using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Entities.Concrete
{
    public class Client : EntityBase
    {
        public string ClientUniqueID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNr { get; set; }
    }
}
