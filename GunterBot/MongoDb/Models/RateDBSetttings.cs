namespace GunterBot.MongoDb.Models
{
    public class RateDBSettings : IRateDBSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
