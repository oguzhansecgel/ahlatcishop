using Ahlatci.Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Domain.Entites
{
    public class Order : AuditableEntity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        OrderCreated =1,
        PaymentComplated = 2,
        Pending = 3,
        OrderDelivering =4,
        CargoDelivered =5,
        Complated=6
    }
}
