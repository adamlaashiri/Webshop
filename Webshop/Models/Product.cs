using System;
using System.Collections.Generic;

#nullable disable

namespace Webshop.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            StockBalances = new HashSet<StockBalance>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Featured { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<StockBalance> StockBalances { get; set; }
    }
}
