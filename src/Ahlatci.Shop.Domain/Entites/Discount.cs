using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    public class Discount
    {
        public int CatergoryId { get; set; }
        public int? ProductId { get; set; }
        public decimal Amount { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
    }

    public enum DiscountType
    {
        Percent=1,
        Total=2
    }
}
