using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop
{
    class ProductQuery
    {
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Featured { get; set; }

    }
}
