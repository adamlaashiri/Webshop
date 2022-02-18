﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Webshop.Models
{
    public partial class StockBalance
    {
        public int StockBalance1 { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
