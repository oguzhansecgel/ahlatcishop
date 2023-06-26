using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    public class Address : AuditableEntity
    {
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }   
        public string Email { get; set; }
        public string AddressText { get; set; }
        public bool IsDefault{ get; set; }

        public Customer Customer { get; set; }
        public City City { get; set; }
    }
}
