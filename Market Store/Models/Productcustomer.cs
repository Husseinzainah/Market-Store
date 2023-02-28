using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Productcustomer
    {
        public decimal ProductId { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public decimal? ProId { get; set; }
        public decimal? CustId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Product Pro { get; set; }
    }
}
