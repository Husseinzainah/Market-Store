using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Orderr
    {
        public Orderr()
        {
            OrderDetials = new HashSet<OrderDetial>();
        }

        public decimal OrdId { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? OrdDate { get; set; }
        public string UserAddress { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }
        public string UserNote { get; set; }
        public string CustName { get; set; }
        public decimal? Price { get; set; }
        public decimal? ProdId { get; set; }
        public decimal? CustoId { get; set; }

        public virtual Customer Custo { get; set; }
        public virtual Product Prod { get; set; }
        public virtual ICollection<OrderDetial> OrderDetials { get; set; }
    }
}
