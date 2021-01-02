﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesDb.Models;

namespace GunterBot.Handlers
{
    public class CatalogHandler
    {
        public static async Task<Dictionary<int, string>> GetActualProductCategoryDictionaryAsync(SalesDbContext salesDbContext)
        {
            var activeProdCat = await salesDbContext.ProductCategories
                .Where(pc => (bool)pc.IsDone)
                .OrderBy(pc => pc.Id)
                .ToListAsync();

            return activeProdCat.ToDictionary(cat => cat.Id, cat => cat.Name);
        }

        public static async Task<Dictionary<int, string>> GetActualProductNameDictionaryByCategoryIdAsync(SalesDbContext salesDbContext, int productCategoryId)
        {
            var activeProd = await salesDbContext.Products
                .Where(p => (bool)p.IsActive && p.ProductCategoryId == productCategoryId)
                .OrderBy(p => p.Id)
                .ToListAsync();

            return activeProd.ToDictionary(prod => prod.Id, prod => prod.Name);
        }

        public static async Task<Product> GetProductByIdAsync(SalesDbContext salesDbContext, int id)
        {
            return await salesDbContext.Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}