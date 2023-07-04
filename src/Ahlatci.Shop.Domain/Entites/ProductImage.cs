using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    public class ProductImage : AuditableEntity
    {
        public int ProductId{ get; set; }
        public string FileName { get; set; }
        public int Order { get; set; }
        public bool IsThumbnail{ get; set; }
        
        public Product Product { get; set; }
    }
}
