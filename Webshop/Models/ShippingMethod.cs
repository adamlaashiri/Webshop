using System;
using System.Collections.Generic;

#nullable disable

namespace Webshop.Models
{
    public partial class ShippingMethod
    {
        public ShippingMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int ShippingMethodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
