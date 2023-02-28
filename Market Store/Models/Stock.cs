using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Stock
    {
        public decimal StoId { get; set; }
        public string StoName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? PrdId { get; set; }

        public virtual Product Prd { get; set; }
    }
}
