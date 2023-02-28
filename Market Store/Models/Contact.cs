using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Contact
    {
        public decimal ContId { get; set; }
        public string Fullname { get; set; }
        public string ConDescription { get; set; }
        public DateTime? ContDate { get; set; }
        public string ContEmail { get; set; }
        public decimal? ContPhone { get; set; }
    }
}
