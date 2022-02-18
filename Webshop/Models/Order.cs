using System;
using System.Collections.Generic;

#nullable disable

namespace Webshop.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShippingMethodId { get; set; }
        public int PaymentDetailId { get; set; }
        public int CustomerId { get; set; }
        public bool Complete { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PaymentDetail PaymentDetail { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
