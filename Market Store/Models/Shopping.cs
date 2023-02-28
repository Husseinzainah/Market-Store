using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Shopping
    {
        public decimal ShopId { get; set; }
        public string NameShop { get; set; }
        public decimal Price { get; set; }
        public decimal? Total { get; set; }
        public string Imagename { get; set; }
        public decimal Quantity { get; set; }
        public decimal? ProducId { get; set; }
        public decimal? CuId { get; set; }

        public virtual Customer Cu { get; set; }
        public virtual Product Produc { get; set; }



        public Shopping()
        {

        }
        public Shopping(Product product)
        {
           ShopId = product.ProId;
            NameShop = product.ProductName;
            Price = (decimal)product.ProductPrice;
            Quantity = 1;
            Imagename = product.ProductImage;


        }

    }
}
