using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Store.Models
{
    public partial class Home
    {
        public decimal HId { get; set; }
        public string Text1 { get; set; }
        public string Imagename1 { get; set; }
        [NotMapped]
        public IFormFile ImageFile1 { get; set; }
        public string Imagename2 { get; set; }
       [NotMapped]
        public IFormFile ImageFile2 { get; set; }
        public string Imagename3 { get; set; }
        [NotMapped]
        public IFormFile ImageFile3 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Imagename4 { get; set; }
        [NotMapped]
        public IFormFile ImageFile4 { get; set; }
        public string Text4 { get; set; }
    }
}
