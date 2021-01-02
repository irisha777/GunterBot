using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SalesDb.Models;

namespace GunterBot.Handlers
{
    public class CustomerHandler
    {
        public static async Task CreateCustomer(SalesDbContext salesDbContext, string phone, string nickName)
        {
            var customer = new Customer()
            {
                Phone = phone,
                NickName = nickName
            };

            await salesDbContext.AddAsync(customer);
            await salesDbContext.SaveChangesAsync();
        }

        public static async Task GetCustomerByNickName()
        {

        }
    }
}
