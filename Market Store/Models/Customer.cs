using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Market_Store.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orderrs = new HashSet<Orderr>();
            Payments = new HashSet<Payment>();
            Productcustomers = new HashSet<Productcustomer>();
            Shoppings = new HashSet<Shopping>();
            Testimonials = new HashSet<Testimonial>();
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal CustId { get; set; }
        public string CustFname { get; set; }
        public string CustLname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? RoleId { get; set; }
        public string Phone { get; set; }
        public string Imagename { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public virtual ICollection<Orderr> Orderrs { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Productcustomer> Productcustomers { get; set; }
        public virtual ICollection<Shopping> Shoppings { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
