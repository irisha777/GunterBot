using System.Threading.Tasks;
using GunterBot.Tools.Data;
using ShitBot.Models;
using RestSharp;

namespace GunterBot.Tools
{
    public class RatesReceiver
    {
        private static readonly RestClient _client = 
            new RestClient(string.Concat(AppSettings.RatesUrl, AppSettings.RatesKey));

        public static async Task<double> GetRates()
        {
            var response = await _client.GetAsync<Rate>(new RestRequest());

            var rates = response.Rates;

            var a = rates["RUB"];

            return a;
        }
    }
}
