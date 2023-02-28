using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Store.Models
{
    public class JoinTable
    {
      public Customer customer { get; set; }
        public UserLogin userLogin { get; set; }
        public Category category { get; set; }
        public Product product { get; set; }
        public Login login { get; set; }
       public Productcustomer productcustomer { get; set; }
       

    }
}
