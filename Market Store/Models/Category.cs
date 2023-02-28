using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Store.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public decimal CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string Imagename { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public decimal? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
