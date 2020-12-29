using System;
using System.Collections.Generic;
using SalesDb.Models;

#nullable disable

namespace GunterBot.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Cost { get; set; }
        public string Descrition { get; set; }
        public bool? IsActive { get; set; }
        public int? ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
