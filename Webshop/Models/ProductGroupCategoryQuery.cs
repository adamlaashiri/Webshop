using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Models
{
    class ProductGroupCategoryQuery
    {
        public string CategoryName { get; set; }
        public List<Product> ChildProducts { get; set; }

        // Data aggregating
        public int ChildCount { get => ChildProducts != null ? ChildProducts.Count : 0 ; }
        public decimal HighestPrice { get => ChildProducts != null ? ChildProducts.Max(p => p.Price) : 0.0M; }
        public decimal LowestPrice { get => ChildProducts != null ? ChildProducts.Min(p => p.Price) : 0.0M; }
        public decimal AveragePrice { get => ChildProducts != null ? ChildProducts.Average(p => p.Price) : 0.0M; }

        public decimal SumPrice { get => ChildProducts != null ? ChildProducts.Sum(p => p.Price) : 0.0M; }
    }
}
