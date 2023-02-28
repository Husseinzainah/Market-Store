using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Models
{
    public class ShopViewModel
    {
        public List<Shopping> shoppings{ get; set; }
        public decimal GrandTotal { get; set; }
    }
}
