using GunterBot.Tools.Data;

namespace ShitBot.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://b9ad3a5d305c.ngrok.io";
        public static string Name { get; set; } = "ShitBot";
        public static string Key { get; set; } = "1264975729:AAETMHOibYm9qS4untjUcw1iVwcTwuS970M";
        public static string RatesKey { get; set; } = "a9ce9c684b1041078a05a9e04d38ec3f";
        public static string RatesUrl { get; set; } = "https://openexchangerates.org/api/latest.json?app_id=";
        public static CurrencyEnum BaseCurrency { get; set; } = CurrencyEnum.USD;

    }
}
