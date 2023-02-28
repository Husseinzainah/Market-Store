using System;
using System.Collections.Generic;

#nullable disable

namespace Market_Store.Models
{
    public partial class Login
    {
        public decimal LogId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Logintype { get; set; }
    }
}
