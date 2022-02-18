using System;
using System.Collections.Generic;

#nullable disable

namespace Webshop.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int PaymentMethodId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
