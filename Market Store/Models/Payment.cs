using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Payment
    {
        public decimal PayId { get; set; }
        public string PayType { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Expiry { get; set; }
        public decimal? CutId { get; set; }

        public virtual Customer Cut { get; set; }
    }
}
