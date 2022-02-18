using System;
using System.Collections.Generic;

#nullable disable

namespace Webshop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public bool Sex { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
