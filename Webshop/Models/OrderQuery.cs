using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Models
{
    class OrderQuery
    {
        public Order Order { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public PaymentDetail PaymentDetail { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
