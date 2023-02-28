using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Testimonial
    {
        public decimal TestId { get; set; }
        public string Masseges { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
