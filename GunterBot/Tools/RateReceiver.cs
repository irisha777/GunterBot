using System.Threading.Tasks;
using GunterBot.Models;
using GunterBot.Models.Data;
using RestSharp;

namespace GunterBot.Tools
{
    public class RateReceiver
    {
        //private static readonly RestClient _client = 
        //    new RestClient(string.Concat(AppSettings.RatesUrl, AppSettings.RatesKey));

        //public static async Task<double> GetRates()
        //{
        //    var response = await _client.GetAsync<Rate>(new RestRequest());

        //    var rates = response.Rates;

        //    return rates["RUB"];
        //}

        private static readonly RestClient _client =
            new RestClient("mongodb://localhost:27017/db");

        public static async Task<double> GetRates()
        {
            var response = await _client.GetAsync<Rate>(new RestRequest());

            var rates = response.Rates;

            var a = rates["RUB"];

            return a;
        }
    }
}
