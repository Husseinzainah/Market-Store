using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Store.Models
{
    public partial class Store
    {
        public Store()
        {
            Categories = new HashSet<Category>();
        }

        public decimal StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string StoreLogo { get; set; }
        public string StoreDescription { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
