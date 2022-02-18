using System;
using System.Collections.Generic;

#nullable disable

namespace Webshop.Models
{
    public partial class PaymentDetail
    {
        public PaymentDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentDetailId { get; set; }
        public int PaymentMethodId { get; set; }
        public string Value { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
