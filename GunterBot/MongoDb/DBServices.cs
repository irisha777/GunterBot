using System.Collections.Generic;
using GunterBot.MongoDb.Models;
using MongoDB.Driver;

namespace GunterBot.MongoDb
{
    public class RateDBServices
    {
        private readonly IMongoCollection<RateDB> _rates;

        public RateDBServices(IRateDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _rates = database.GetCollection<RateDB>(settings.CollectionName);
        }

        public List<RateDB> Get() =>
            _rates.Find(rate => true).ToList();

        public RateDB Get(string id) =>
            _rates.Find(rate => rate.Id == id).FirstOrDefault();

        public RateDB Create(RateDB rate)
        {
            _rates.InsertOne(rate);
            return rate;
        }

        public void Update(string id, RateDB rateIn) =>
            _rates.ReplaceOne(rate => rate.Id == id, rateIn);

        public void Remove(RateDB rateIn) =>
            _rates.DeleteOne(rate => rate.Id == rateIn.Id);

        public void Remove(string id) =>
            _rates.DeleteOne(rate => rate.Id == id);

    }
}
