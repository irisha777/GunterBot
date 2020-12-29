﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GunterBot.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
