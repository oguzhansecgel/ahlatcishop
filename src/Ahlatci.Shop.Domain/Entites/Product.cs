using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    public class Product : AuditableEntity
    {

        public int CatergoryId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int UnitInStock { get; set; }
        public Decimal UnitPrice{ get; set; }
       
        
    }
}
