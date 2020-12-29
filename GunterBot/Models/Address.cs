using System;
using System.Collections.Generic;

#nullable disable

namespace GunterBot.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostIndex { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
