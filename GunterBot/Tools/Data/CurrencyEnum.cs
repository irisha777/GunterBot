using System;

namespace GunterBot.Tools.Data
{
    public enum CurrencyEnum
    {
        USD = 840,
        RUB = 643
    }

    public static class CurrencyExtensions
    {
        public static string GetCurrencyName(this CurrencyEnum currencyEnum)
        {
            return currencyEnum switch
            {
                CurrencyEnum.USD => "USD",
                CurrencyEnum.RUB => "RUB",
                _ => throw new Exception("Unknown currency")
            };
        }
    }
}
