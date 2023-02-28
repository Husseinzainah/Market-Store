using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class UserLogin
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? CustomeId { get; set; }

        public virtual Customer Custome { get; set; }
    }
}
