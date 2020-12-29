using System;
using System.Collections.Generic;

#nullable disable

namespace GunterBot.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? AddressId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDone { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
