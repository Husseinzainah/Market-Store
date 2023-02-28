using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class OrderDetial
    {
        public decimal DetId { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? DateOrder { get; set; }
        public decimal? OrdId { get; set; }
        public decimal? ProId { get; set; }

        public virtual Orderr Ord { get; set; }
        public virtual Product Pro { get; set; }
        
    }
}
