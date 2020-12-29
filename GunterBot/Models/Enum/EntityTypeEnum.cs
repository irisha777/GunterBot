using System;

namespace GunterBot.Models.Enum
{
    public enum EntityTypeEnum
    {
        ProductCategory = 1,
        Product = 2
    }

    public static class EntityTypeEnumExtensions
    {
        public static EntityTypeEnum GetEntityTypeEnumFromInt(int typeId)
        {
            return typeId switch
            {
                1 => EntityTypeEnum.ProductCategory,
                _ => throw new Exception("There is no EntityTypeEnum with such typeId")
            };
        }
    }
}
