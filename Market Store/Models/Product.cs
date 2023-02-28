using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Store.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetials = new HashSet<OrderDetial>();
            Orderrs = new HashSet<Orderr>();
            Productcustomers = new HashSet<Productcustomer>();
            Shoppings = new HashSet<Shopping>();
            Stocks = new HashSet<Stock>();
        }

        public decimal ProId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductSale { get; set; }
        public decimal? ProductStatus { get; set; }
        public string ProductColor { get; set; }
       
        public decimal? ProductQuntity { get; set; }
        public string ProductImage { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetial> OrderDetials { get; set; }
        public virtual ICollection<Orderr> Orderrs { get; set; }
        public virtual ICollection<Productcustomer> Productcustomers { get; set; }
        public virtual ICollection<Shopping> Shoppings { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }

      
    }
}
