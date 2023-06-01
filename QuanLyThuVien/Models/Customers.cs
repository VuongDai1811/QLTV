﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? LocationId { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
