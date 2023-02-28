using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Store.Models
{
    public partial class Aboutu
    {
        public decimal AboutId { get; set; }
        public string TextA { get; set; }
        public string Imagename { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string TextB { get; set; }
        public string Imagename2 { get; set; }
        [NotMapped]
        public IFormFile ImageFile2 { get; set; }
    }
}
